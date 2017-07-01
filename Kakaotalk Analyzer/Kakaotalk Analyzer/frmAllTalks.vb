'/*************************************************************************
'
'   Copyright (C) 2017. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class frmAllTalks

    Dim data As List(Of List(Of String))

    Public Sub New(ByVal p As List(Of List(Of String)))
        InitializeComponent()
        data = p
    End Sub

    Private Sub frmList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each d As List(Of String) In data
            lvList.Items.Add(New ListViewItem(d.ToArray))
            Application.DoEvents()
        Next
    End Sub

    Private Sub frmAllTalks_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub

    Public Sub FocusingItem(ByVal index As Integer)
        lvList.Items.Item(index - 1).Selected = True
        lvList.Items.Item(index - 1).EnsureVisible()
    End Sub

End Class