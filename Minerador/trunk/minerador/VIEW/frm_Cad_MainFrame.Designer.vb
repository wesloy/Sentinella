<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Cad_MainFrame
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Cad_MainFrame))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbkAtivo = New System.Windows.Forms.CheckBox()
        Me.btnNovaSenha = New System.Windows.Forms.Button()
        Me.txtSessao = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.btnIncluir = New System.Windows.Forms.Button()
        Me.cbMainFrame = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 193)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "Status (Ativo):"
        '
        'cbkAtivo
        '
        Me.cbkAtivo.AutoSize = True
        Me.cbkAtivo.Location = New System.Drawing.Point(96, 192)
        Me.cbkAtivo.Name = "cbkAtivo"
        Me.cbkAtivo.Size = New System.Drawing.Size(15, 14)
        Me.cbkAtivo.TabIndex = 84
        Me.cbkAtivo.Tag = "Ativo"
        Me.cbkAtivo.UseVisualStyleBackColor = True
        '
        'btnNovaSenha
        '
        Me.btnNovaSenha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNovaSenha.Enabled = False
        Me.btnNovaSenha.Location = New System.Drawing.Point(249, 90)
        Me.btnNovaSenha.Name = "btnNovaSenha"
        Me.btnNovaSenha.Size = New System.Drawing.Size(80, 22)
        Me.btnNovaSenha.TabIndex = 83
        Me.btnNovaSenha.Text = "Alterar senha"
        Me.btnNovaSenha.UseVisualStyleBackColor = True
        '
        'txtSessao
        '
        Me.txtSessao.Location = New System.Drawing.Point(96, 113)
        Me.txtSessao.Multiline = True
        Me.txtSessao.Name = "txtSessao"
        Me.txtSessao.Size = New System.Drawing.Size(452, 73)
        Me.txtSessao.TabIndex = 77
        Me.txtSessao.Tag = "sessao"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "End. Sessão:"
        '
        'txtSenha
        '
        Me.txtSenha.Location = New System.Drawing.Point(96, 92)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.Size = New System.Drawing.Size(147, 20)
        Me.txtSenha.TabIndex = 75
        Me.txtSenha.Tag = "senha"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Senha:"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(96, 71)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(147, 20)
        Me.txtUser.TabIndex = 73
        Me.txtUser.Tag = "Usuario"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Usuário:"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(96, 50)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(147, 20)
        Me.txtNome.TabIndex = 71
        Me.txtNome.Tag = "Nome"
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(479, 241)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(69, 20)
        Me.txtID.TabIndex = 66
        Me.txtID.Tag = "id"
        Me.txtID.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Nome:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "MainFrame:"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(450, 241)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 20)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Id:"
        Me.Label1.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(254, 231)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 30)
        Me.btnCancelar.TabIndex = 64
        Me.btnCancelar.Text = "   Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnExcluir
        '
        Me.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExcluir.Enabled = False
        Me.btnExcluir.Image = CType(resources.GetObject("btnExcluir.Image"), System.Drawing.Image)
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnExcluir.Location = New System.Drawing.Point(173, 231)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(75, 30)
        Me.btnExcluir.TabIndex = 63
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'btnAlterar
        '
        Me.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAlterar.Enabled = False
        Me.btnAlterar.Image = CType(resources.GetObject("btnAlterar.Image"), System.Drawing.Image)
        Me.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAlterar.Location = New System.Drawing.Point(92, 231)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(75, 30)
        Me.btnAlterar.TabIndex = 62
        Me.btnAlterar.Text = "Alterar"
        Me.btnAlterar.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Location = New System.Drawing.Point(12, 267)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(536, 231)
        Me.ListView1.TabIndex = 65
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'btnIncluir
        '
        Me.btnIncluir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIncluir.Image = CType(resources.GetObject("btnIncluir.Image"), System.Drawing.Image)
        Me.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnIncluir.Location = New System.Drawing.Point(11, 231)
        Me.btnIncluir.Name = "btnIncluir"
        Me.btnIncluir.Size = New System.Drawing.Size(75, 30)
        Me.btnIncluir.TabIndex = 61
        Me.btnIncluir.Text = "Incluir"
        Me.btnIncluir.UseVisualStyleBackColor = True
        '
        'cbMainFrame
        '
        Me.cbMainFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMainFrame.FormattingEnabled = True
        Me.cbMainFrame.Items.AddRange(New Object() {"B2K", "IBI"})
        Me.cbMainFrame.Location = New System.Drawing.Point(96, 28)
        Me.cbMainFrame.Name = "cbMainFrame"
        Me.cbMainFrame.Size = New System.Drawing.Size(147, 21)
        Me.cbMainFrame.TabIndex = 86
        '
        'frm_Cad_MainFrame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 510)
        Me.Controls.Add(Me.cbMainFrame)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbkAtivo)
        Me.Controls.Add(Me.btnNovaSenha)
        Me.Controls.Add(Me.txtSessao)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSenha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnAlterar)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.btnIncluir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Cad_MainFrame"
        Me.Text = ".: Cadastro de MainFrame :."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents cbkAtivo As CheckBox
    Friend WithEvents btnNovaSenha As Button
    Friend WithEvents txtSessao As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSenha As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtUser As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNome As TextBox
    Friend WithEvents txtID As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents btnAlterar As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents btnIncluir As Button
    Friend WithEvents cbMainFrame As ComboBox
End Class
