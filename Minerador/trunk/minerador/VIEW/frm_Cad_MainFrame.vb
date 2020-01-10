Public Class frm_Cad_MainFrame
    Private hlp As New Algar.Utils.Helpers
    Private dto As New MF_DTO
    Private bll As New MF_BLL
    Private camposObrigatorios As String = ""
    Private nomeDosCampos As String = ""
    Private dt As New DataTable

    Private Sub liberaBotoes()
        Me.btnAlterar.Enabled = True
        Me.btnExcluir.Enabled = True
        Me.btnIncluir.Enabled = False
        Me.btnCancelar.Enabled = True
    End Sub

    Private Sub bloqueiaBotoes()
        Me.btnIncluir.Enabled = True
        Me.btnAlterar.Enabled = False
        Me.btnExcluir.Enabled = False
    End Sub
    Private Function AtualizaListViewMainframe() As Boolean
        dt = bll.GetMainframe()
        Me.ListView1.Clear()
        'AJUSTANDO AS COLUNAS
        With Me.ListView1
            .Clear()
            .View = View.Details
            .LabelEdit = False
            .CheckBoxes = False
            .SmallImageList = imglist() 'Utilizando um modulo publico
            .GridLines = True
            .FullRowSelect = True
            .HideSelection = False
            .MultiSelect = False
            .Columns.Add("ID", 50, HorizontalAlignment.Center)
            .Columns.Add("MAINFRAME", 80, HorizontalAlignment.Left)
            .Columns.Add("NOME", 80, HorizontalAlignment.Left)
            .Columns.Add("USUARIO", 80, HorizontalAlignment.Left)
            .Columns.Add("SENHA", 80, HorizontalAlignment.Left)
            .Columns.Add("SESSAO", 350, HorizontalAlignment.Left)
            .Columns.Add("DT. ALTERAR SENHA", 60, HorizontalAlignment.Left)

        End With
        'POPULANDO
        If dt.Rows.Count > 0 Then 'verifica se existem registros
            For Each drRow As DataRow In dt.Rows
                Dim item As New ListViewItem()
                item.Text = drRow("id")
                item.SubItems.Add(drRow("mainframe").ToString)
                item.SubItems.Add(drRow("nome").ToString)
                item.SubItems.Add(drRow("usuario").ToString)
                item.SubItems.Add(drRow("senha").ToString)
                item.SubItems.Add(drRow("sessao").ToString)
                item.SubItems.Add(drRow("dt_alterar_senha").ToString)

                'item.SubItems.Add(drRow("situacao"))
                If drRow("STATUS") Then
                    item.ImageKey = 1 'verde
                Else
                    item.ImageKey = 3 'vermelho
                End If

                Me.ListView1.Items.Add(item)
            Next drRow
        End If
        Return True
    End Function

    Private Sub frm_Cad_MainFrame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hlp.limparCampos(Me)
        AtualizaListViewMainframe()
    End Sub

    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        camposObrigatorios = "cbMainFrame;txtNome;txtUser;txtSenha;txtSessao"
        nomeDosCampos = "Mainframe;Nome;Usuario,Senha,Sessão"
        If hlp.validaCamposObrigatorios(Me, camposObrigatorios, nomeDosCampos) Then
            With dto
                .MAINFRAME = Me.cbMainFrame.Text
                .NOME = Me.txtNome.Text.Trim
                .USUARIO = Me.txtUser.Text.Trim
                .SENHA = Me.txtSenha.Text.Trim
                .SESSAO = Me.txtSessao.Text.Trim
                .STATUS = Me.cbkAtivo.Checked
                .ACAO = FlagAcao.Insert
            End With
            If bll.Salvar(dto) Then
                AtualizaListViewMainframe()
                MsgBox("Registro salvo com sucesso!", vbInformation, TITULO_ALERTA)
                hlp.limparCampos(Me)
                bloqueiaBotoes()
            Else
                MsgBox("Registro não pode ser incluído!", vbInformation, TITULO_ALERTA)
            End If

        End If
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        camposObrigatorios = "cbMainFrame;txtNome;txtUser;txtSenha;txtSessao"
        nomeDosCampos = "Mainframe;Nome;Usuario,Senha,Sessão"
        If String.IsNullOrEmpty(Me.txtID.Text) Or Me.txtID.Text = 0 Then
            MsgBox("Nenhum registro foi selecionado!", MsgBoxStyle.Information, TITULO_ALERTA)
            Exit Sub
        Else

            If hlp.validaCamposObrigatorios(Me, camposObrigatorios, nomeDosCampos) Then
                dto = bll.GetMainframePorId(Me.txtID.Text)
                With dto
                    .ID = Me.txtID.Text
                    .MAINFRAME = Me.cbMainFrame.Text
                    .NOME = Me.txtNome.Text.Trim
                    .USUARIO = Me.txtUser.Text.Trim
                    .SENHA = Me.txtSenha.Text.Trim
                    .SESSAO = Me.txtSessao.Text.Trim
                    .STATUS = Me.cbkAtivo.Checked
                    .ACAO = FlagAcao.Update
                End With
                If bll.Salvar(dto) Then
                    AtualizaListViewMainframe()
                    hlp.limparCampos(Me)
                    bloqueiaBotoes()
                    MsgBox("Registro alterado com sucesso!", vbInformation, TITULO_ALERTA)
                Else
                    MsgBox("Registro não pode ser alterado!", vbInformation, TITULO_ALERTA)
                End If
            End If
        End If
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        Dim valor As Integer = 0
        valor = IIf(IsDBNull(Me.txtID.Text), vbEmpty, Me.txtID.Text) 'captura o valor do id, se existir.
        If String.IsNullOrEmpty(valor) Or valor = 0 Then
            MsgBox("Nenhum registro foi selecionado!", MsgBoxStyle.Information, TITULO_ALERTA)
            Exit Sub
        End If

        If MsgBox("Tem certeza que deseja remover " & Me.txtNome.Text.Trim.ToUpper & " (" & Me.cbMainFrame.Text & ") do sistema?", vbQuestion + vbYesNo, TITULO_ALERTA) = vbYes Then
            With dto
                .ID = Me.txtID.Text
                .ACAO = FlagAcao.Delete
            End With
            If bll.Salvar(dto) Then
                AtualizaListViewMainframe()
                MsgBox("Registro exluído com sucesso.", vbInformation, TITULO_ALERTA)
            Else
                MsgBox("Registro não pode ser excluído!", vbInformation, TITULO_ALERTA)
            End If
        End If
        hlp.limparCampos(Me)
        bloqueiaBotoes()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        hlp.limparCampos(Me)
        AtualizaListViewMainframe()
        bloqueiaBotoes()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Dim id_registro As Integer
        id_registro = Me.ListView1.SelectedItems(0).SubItems(0).Text 'captura informações da primeira coluna selecionada
        If String.IsNullOrEmpty(id_registro) Or id_registro = 0 Then
            MsgBox("Nenhum registro foi selecionado!", MsgBoxStyle.Information, TITULO_ALERTA)
            Exit Sub
        Else
            dto = bll.GetMainframePorId(id_registro)
            With dto
                Me.txtID.Text = .ID
                Me.cbMainFrame.Text = .MAINFRAME
                Me.txtNome.Text = .NOME
                Me.txtUser.Text = .USUARIO
                Me.txtSenha.Text = .SENHA
                Me.txtSessao.Text = .SESSAO
                'Me.txtMacro.Text = .DT_ALTERAR_SENHA
                Me.cbkAtivo.Checked = .STATUS
                .ACAO = FlagAcao.NoAction
            End With
        End If
        liberaBotoes()
    End Sub

End Class