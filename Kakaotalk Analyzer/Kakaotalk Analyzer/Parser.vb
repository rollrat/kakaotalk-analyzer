'/*************************************************************************
'
'   Copyright (C) 2017. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.IO
Imports System.Text

Public Class Parser

    ' Kakaotalk Analyzer 0.1 Parser

    Private Structure Talk
        Dim Index As Integer
        Dim Name As String
        Dim Time As Date
        Dim Talk As String
    End Structure

    Private Structure Member
        Dim Name As String
        Dim Talks As List(Of Talk)
    End Structure

    Private lines As New List(Of String)
    Private _title As String = ""
    Private talks As New List(Of Talk)
    Private members As New Dictionary(Of String, Member)

    Public ReadOnly Property Title() As String
        Get
            Return _title
        End Get
    End Property

    Public ReadOnly Property CMember() As Integer
        Get
            Return members.Count
        End Get
    End Property

    Public ReadOnly Property CTalk() As Integer
        Get
            Return talks.Count
        End Get
    End Property

    Public Sub loadfile(ByVal pathstr As String)
        Dim srt As StreamReader = New StreamReader(pathstr, Encoding.UTF8)
        While Not srt.EndOfStream
            lines.Add(srt.ReadLine())
        End While
        parse_title()
        parse_talk()
        parse_members()
    End Sub

    Private Sub parse_title()
        _title = lines(0).Replace(" 님과 카카오톡 대화", "")
    End Sub

    Private Sub parse_talk()
        Dim now_date As Date
        Dim index As Integer = 1

        For i = 3 To lines.Count - 1
            Dim n As String = lines(i)
            If mat(n, "--------------- (\d+)년 (\d+)월 (\d+)일 \w+ ---------------") Then
                Dim d As String() = reg(n, "--------------- (\d+)년 (\d+)월 (\d+)일 \w+ ---------------")
                now_date = New Date(d(1), d(2), d(3))
            ElseIf mat(n, "\[(.*?)\] \[(\w+) (\d+)\:(\d+)\] (.*?)") Then
                Dim s As String() = reg(n, "\[(.*?)\] \[(\w+) (\d+)\:(\d+)\]([\w\W]+)")
                Dim t As Talk
                t.Index = index
                t.Name = s(1)
                Dim time As Integer = s(3)
                If s(2) = "오후" Then
                    If time <> 12 Then
                        time += 12
                    End If
                Else
                    If time = 12 Then
                        time = 0
                    End If
                End If
                t.Time = New Date(now_date.Year, now_date.Month, now_date.Day, time, s(4), 0)
                t.Talk = s(5).Trim
                talks.Add(t)
                index += 1
            ElseIf Not mat(n, ".*?님이 .*?님을 초대하였습니다.") AndAlso Not mat(n, ".*?님이 들어왔습니다.") Then
                Dim t As Talk
                t.Index = talks(talks.Count - 1).Index
                t.Name = talks(talks.Count - 1).Name
                t.Time = talks(talks.Count - 1).Time
                t.Talk = talks(talks.Count - 1).Talk + " " + n
                talks(talks.Count - 1) = t
            End If
        Next
    End Sub

    Private Sub parse_members()
        For Each t As Talk In talks
            If Not members.ContainsKey(t.Name) Then
                Dim m As Member
                m.Talks = New List(Of Talk)
                m.Name = t.Name
                m.Talks.Add(t)
                members.Add(t.Name, m)
            Else
                members(t.Name).Talks.Add(t)
            End If
        Next
    End Sub

    Private Function reg(ByVal src As String, ByVal pat As String) As String()
        Dim result As New List(Of String)
        Dim match As RegularExpressions.Match
        match = RegularExpressions.Regex.Match(src, pat)
        For i = 0 To match.Groups.Count - 1
            result.Add(match.Groups(i).Value)
        Next
        Return result.ToArray
    End Function

    Private Function mat(ByVal src As String, ByVal pat As String) As Boolean
        Dim match As RegularExpressions.Match
        match = RegularExpressions.Regex.Match(src, pat)
        Return match.Success
    End Function

    Public Sub show_member()
        Dim l As New List(Of List(Of String))
        Dim index As String = 1
        For Each i As KeyValuePair(Of String, Member) In members
            Dim x As New List(Of String)
            x.Add(index)
            x.Add(i.Key)
            x.Add(i.Value.Talks.Count)
            x.Add(i.Value.Talks(i.Value.Talks.Count - 1).Time.ToLocalTime)
            l.Add(x)
            index += 1
        Next
        Dim f As New frmMember(l)
        f.Show()
    End Sub

    Public Sub show_talks(ByVal name As String)
        Dim l As New List(Of List(Of String))
        For Each i As Talk In members(name).Talks
            Dim x As New List(Of String)
            x.Add(i.Index)
            x.Add(i.Talk)
            x.Add(i.Time.ToLocalTime)
            l.Add(x)
        Next
        Dim f As New frmTalks(l, name)
        f.Show()
    End Sub

    Private Talks_form As frmAllTalks

    Public Sub show_alltalks()
        Dim l As New List(Of List(Of String))
        Dim nn As String = ""
        For Each i As Talk In talks
            Dim x As New List(Of String)
            x.Add(i.Index)
            If i.Name = nn Then
                x.Add("")
            Else
                x.Add(i.Name)
                nn = i.Name
            End If
            x.Add(i.Talk)
            x.Add(i.Time.ToLocalTime)
            l.Add(x)
        Next
        Talks_form = New frmAllTalks(l)
        Talks_form.Show()
    End Sub

    Public Sub FocusingItem(ByVal index As Integer)
        Talks_form.FocusingItem(index)
        Talks_form.Focus()
    End Sub

    Public Function get_weeks_statics(ByVal n As String) As Integer()
        Dim l(7) As Integer
        If members.ContainsKey(n) Then
            For Each t As Talk In talks
                If t.Name = n Then
                    l(t.Time.DayOfWeek) += 1
                End If
            Next
        Else
            For Each t As Talk In talks
                l(t.Time.DayOfWeek) += 1
            Next
        End If
        Return l
    End Function

    Public Function get_times_statics(ByVal n As String, ByVal w As Boolean()) As Integer()
        Dim l(24) As Integer
        If members.ContainsKey(n) AndAlso n <> "" Then
            For Each t As Talk In talks
                If t.Name = n Then
                    If w(t.Time.DayOfWeek) Then
                        l(t.Time.Hour) += 1
                    End If
                End If
            Next
        Else
            For Each t As Talk In talks
                If w(t.Time.DayOfWeek) Then
                    l(t.Time.Hour) += 1
                End If
            Next
        End If
        Return l
    End Function

End Class
