'/*************************************************************************
'
'   Copyright (C) 2017. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Security.Principal

Public Class frmMain

    Public Shared parser As New Parser

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' 관리자 권한 체크
        If (New WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator) Then
            ShowMsgCritical("이 프로그램은 관리자권한으로 실행할 수 없습니다.") : End
        End If

        Text += Version.VersionText

    End Sub

#Region "Message Box"

    Public Shared Sub ShowMsgCritical(ByVal body As String, Optional ByVal title As String = Version.ProgramName)
        MsgBox(body, MsgBoxStyle.Critical, title)
    End Sub
    Public Shared Sub ShowMsgWarning(ByVal body As String, Optional ByVal title As String = Version.ProgramName)
        MsgBox(body, MsgBoxStyle.Exclamation, title)
    End Sub
    Public Shared Sub ShowMsgInform(ByVal body As String, Optional ByVal title As String = Version.ProgramName)
        MsgBox(body, MsgBoxStyle.Information, title)
    End Sub

#End Region

#Region "Drag & Drop"

    Private Sub tbAddress_DragDrop(sender As Object, e As DragEventArgs) Handles tbAddress.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If filePaths.Length <> 1 Then
                ShowMsgCritical("하나의 폴더만 끌어오십시오.")
            Else
                Load_File(CType(e.Data.GetData(DataFormats.FileDrop), String())(0))
            End If
        End If
    End Sub
    Private Sub tbAddress_DragEnter(sender As Object, e As DragEventArgs) Handles tbAddress.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

#End Region

    Private Sub Load_File(ByVal pathstr As String)
        If My.Computer.FileSystem.FileExists(pathstr) Then
            tbAddress.Text = pathstr
            Application.DoEvents()
            parser.loadfile(pathstr)
            tbAddress.Text = parser.Title()
            lbTalkCount.Text = parser.CTalk
            lbMemberCount.Text = parser.CMember
            bMember.Enabled = True
            bStatics.Enabled = True
        Else
            ShowMsgCritical("유효한 경로가 아닙니다.")
        End If
    End Sub

    Private Sub bMember_Click(sender As Object, e As EventArgs) Handles bMember.Click
        parser.show_alltalks()
        parser.show_member()
    End Sub

    Private Sub bStatics_Click(sender As Object, e As EventArgs) Handles bStatics.Click
        Dim f As New frmStatics("")
        f.Show()
    End Sub

End Class
