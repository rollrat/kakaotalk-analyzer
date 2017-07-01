'/*************************************************************************
'
'   Copyright (C) 2017. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class frmStatics

    Private pbs As List(Of ProgressBar)
    Private cbs As List(Of CheckBox)
    Private vpbs As List(Of ProgressBar)

    Dim wds As Boolean() = {False, False, False, False, False, False, False}
    Dim onshow As Boolean = False
    Dim _name As String

    Public Sub New(ByVal name As String)

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        _name = name

    End Sub

    Private Sub frmStatics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()

        pbs = New List(Of ProgressBar)({pb1, pb2, pb3, pb4, pb5, pb6, pb7})
        cbs = New List(Of CheckBox)({cb1, cb2, cb3, cb4, cb5, cb6, cb7})
        vpbs = New List(Of ProgressBar)({vpb1, vpb2, vpb3, vpb4, vpb5, vpb6, vpb7, vpb8, vpb9, vpb10,
            vpb11, vpb12, vpb13, vpb14, vpb15, vpb16, vpb17, vpb18, vpb19, vpb20, vpb21, vpb22, vpb23, vpb24})

        onshow = True
        refresh_pbs()
        refresh_vpbs()
    End Sub

    Private Sub cb1_CheckedChanged(sender As Object, e As EventArgs) Handles cb1.CheckedChanged
        wds(0) = Not wds(0) : refresh_vpbs()
    End Sub
    Private Sub cb2_CheckedChanged(sender As Object, e As EventArgs) Handles cb2.CheckedChanged
        wds(1) = Not wds(1) : refresh_vpbs()
    End Sub
    Private Sub cb3_CheckedChanged(sender As Object, e As EventArgs) Handles cb3.CheckedChanged
        wds(2) = Not wds(2) : refresh_vpbs()
    End Sub
    Private Sub cb4_CheckedChanged(sender As Object, e As EventArgs) Handles cb4.CheckedChanged
        wds(3) = Not wds(3) : refresh_vpbs()
    End Sub
    Private Sub cb5_CheckedChanged(sender As Object, e As EventArgs) Handles cb5.CheckedChanged
        wds(4) = Not wds(4) : refresh_vpbs()
    End Sub
    Private Sub cb6_CheckedChanged(sender As Object, e As EventArgs) Handles cb6.CheckedChanged
        wds(5) = Not wds(5) : refresh_vpbs()
    End Sub
    Private Sub cb7_CheckedChanged(sender As Object, e As EventArgs) Handles cb7.CheckedChanged
        wds(6) = Not wds(6) : refresh_vpbs()
    End Sub

    Private Sub refresh_pbs()
        Dim t As Integer() = frmMain.parser.get_weeks_statics(_name)
        Dim max As Integer = 0
        For Each i As Integer In t
            max = Math.Max(max, i)
        Next
        For i As Integer = 0 To 6
            pbs(i).Maximum = max
            pbs(i).Value = t(i)
        Next
    End Sub
    Private Sub refresh_vpbs()
        If onshow Then
            Dim t As Integer() = frmMain.parser.get_times_statics(_name, wds)
            Dim max As Integer = 0
            For Each i As Integer In t
                max = Math.Max(max, i)
            Next
            For i As Integer = 0 To 23
                vpbs(i).Maximum = max
                vpbs(i).Value = t(i)
            Next
        End If
    End Sub

End Class