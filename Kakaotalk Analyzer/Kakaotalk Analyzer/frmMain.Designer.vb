<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAddress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bMember = New System.Windows.Forms.Button()
        Me.bStatics = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbTalkCount = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbMemberCount = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "대화목록 파일:"
        '
        'tbAddress
        '
        Me.tbAddress.AllowDrop = True
        Me.tbAddress.BackColor = System.Drawing.SystemColors.Window
        Me.tbAddress.Location = New System.Drawing.Point(103, 8)
        Me.tbAddress.Name = "tbAddress"
        Me.tbAddress.ReadOnly = True
        Me.tbAddress.Size = New System.Drawing.Size(352, 23)
        Me.tbAddress.TabIndex = 1
        Me.tbAddress.Text = "이 곳에 대화목록 파일을 끌어 놓으십시오."
        Me.tbAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(193, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(262, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Copyright (C) 2017. rollrat. All Rights Reserved."
        '
        'bMember
        '
        Me.bMember.Enabled = False
        Me.bMember.Location = New System.Drawing.Point(358, 37)
        Me.bMember.Name = "bMember"
        Me.bMember.Size = New System.Drawing.Size(95, 24)
        Me.bMember.TabIndex = 7
        Me.bMember.Text = "멤버 목록"
        Me.bMember.UseVisualStyleBackColor = True
        '
        'bStatics
        '
        Me.bStatics.Enabled = False
        Me.bStatics.Location = New System.Drawing.Point(257, 37)
        Me.bStatics.Name = "bStatics"
        Me.bStatics.Size = New System.Drawing.Size(95, 24)
        Me.bStatics.TabIndex = 8
        Me.bStatics.Text = "빈도 분석"
        Me.bStatics.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "대화 수: "
        '
        'lbTalkCount
        '
        Me.lbTalkCount.AutoSize = True
        Me.lbTalkCount.Location = New System.Drawing.Point(103, 37)
        Me.lbTalkCount.Name = "lbTalkCount"
        Me.lbTalkCount.Size = New System.Drawing.Size(14, 15)
        Me.lbTalkCount.TabIndex = 10
        Me.lbTalkCount.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "참여자 수: "
        '
        'lbMemberCount
        '
        Me.lbMemberCount.AutoSize = True
        Me.lbMemberCount.Location = New System.Drawing.Point(103, 52)
        Me.lbMemberCount.Name = "lbMemberCount"
        Me.lbMemberCount.Size = New System.Drawing.Size(14, 15)
        Me.lbMemberCount.TabIndex = 12
        Me.lbMemberCount.Text = "0"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 88)
        Me.Controls.Add(Me.lbMemberCount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbTalkCount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bStatics)
        Me.Controls.Add(Me.bMember)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbAddress)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.Text = "카카오톡 대화분석기 "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbAddress As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents bMember As Button
    Friend WithEvents bStatics As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lbTalkCount As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbMemberCount As Label
End Class
