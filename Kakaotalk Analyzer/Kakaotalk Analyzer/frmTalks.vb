'/*************************************************************************
'
'   Copyright (C) 2017. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class frmTalks

    Dim data As List(Of List(Of String))

    Public Sub New(ByVal p As List(Of List(Of String)), ByVal name As String)
        InitializeComponent()

        Dim ch As New List(Of ColumnHeader)
        For Each c As ColumnHeader In lvList.Columns
            ch.Add(New ColHeader(c.Text, c.Width, c.TextAlign, True))
        Next
        lvList.Clear()
        For Each c As ColumnHeader In ch
            lvList.Columns.Add(c)
        Next

        Text = name + Text

        data = p
    End Sub

    Private Sub frmTalks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each d As List(Of String) In data
            lvList.Items.Add(New ListViewItem(d.ToArray))
        Next
    End Sub

    Private Sub lvList_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvList.ColumnClick
        On Error Resume Next

        Dim clickedCol As ColHeader = CType(lvList.Columns(e.Column), ColHeader)
        clickedCol.ascending = Not clickedCol.ascending
        Dim numItems As Integer = lvList.Items.Count
        Me.lvList.BeginUpdate()

        Dim SortArray As New ArrayList
        Dim i As Integer
        For i = 0 To numItems - 1
            SortArray.Add(New SortWrapper(lvList.Items(i), e.Column))
        Next i

        SortArray.Sort(0, SortArray.Count, New SortWrapper.SortComparer(clickedCol.ascending))

        lvList.Items.Clear()
        Dim z As Integer
        For z = 0 To numItems - 1
            lvList.Items.Add(CType(SortArray(z), SortWrapper).sortItem)
        Next z

        lvList.EndUpdate()
    End Sub

    Private Sub lvList_DoubleClick(sender As Object, e As EventArgs) Handles lvList.DoubleClick
        If lvList.SelectedItems.Count = 1 Then
            frmMain.parser.FocusingItem(lvList.SelectedItems(0).SubItems(0).Text)
        End If
    End Sub

End Class