Public Class frm_execucao_robos
    Private hlp As New Algar.Utils.Helpers
    Private mf_bll As New MF_BLL
    Private execucao_bll As New execucao_BLL
    Private execDTO As New execucao_DTO
    Private dt As DataTable = Nothing

    Public Sub atualizarBarraDeStaus(ByVal min As Integer, ByVal max As Integer, ByVal totalAtual As Integer)

        Me.status_Percentual.Visible = True
        Me.status_progressBar.Visible = True

        'Zerando status
        If totalAtual <= 1 Then
            Me.status_progressBar.Value = 1
        End If

        Me.status_progressBar.Minimum = min
        Me.status_progressBar.Maximum = max
        Me.status_progressBar.Increment(1)
        Me.status_Percentual.Text = FormatPercent(totalAtual / max, 2)

        If max = totalAtual Then
            Me.status_Percentual.Text = "100%"
            Me.status_progressBar.Value = max
        End If
    End Sub

    Public Sub atualizarStatusLabel(ByVal texto As String)
        Me.status_label.Text = texto
    End Sub

    Private Function atualizarListView()
        Me.ListView1.Clear()
        Me.txtTotalCasosPendentes.Text = 0

        'AJUSTANDO AS COLUNAS
        With Me.ListView1
            .View = View.Details
            .LabelEdit = False
            .CheckBoxes = False
            .SmallImageList = imglist() 'Utilizando um modulo publico
            .GridLines = True
            .FullRowSelect = True ' True
            .HideSelection = False
            .MultiSelect = False
            .Columns.Add("Protocolo", 80, HorizontalAlignment.Left) 'ID
            .Columns.Add("MainFrame", 90, HorizontalAlignment.Left)
            .Columns.Add("Nome Macro", 300, HorizontalAlignment.Left)
            .Columns.Add("Usuário MainFrame", 110, HorizontalAlignment.Left)
            .Columns.Add("Cartões Ativos", 80, HorizontalAlignment.Left)
            .Columns.Add("Usuário Solicitou Pesquisa", 140, HorizontalAlignment.Left)
            .Columns.Add("Data Inclusão Pesquisa", 120, HorizontalAlignment.Left)
            .Columns.Add("Executado", 100, HorizontalAlignment.Left)
            .Columns.Add("Data Início Pesquisa", 120, HorizontalAlignment.Left)
            .Columns.Add("Data Conclusão Pesquisa", 120, HorizontalAlignment.Left)
            .Columns.Add("Logs de Erro", 300, HorizontalAlignment.Left)
        End With
        'Dim i As Integer = 0
        'POPULANDO
        dt = execucao_bll.atualiarListView
        If dt.Rows.Count > 0 Then 'verifica se existem registros
            For Each drRow As DataRow In dt.Rows
                Dim item As New ListViewItem()
                item.Text = drRow("id")
                item.SubItems.Add("" & drRow("mainframe"))
                item.SubItems.Add("" & drRow("macroExecutadaNome"))
                item.SubItems.Add("" & drRow("usuarioMainFrame"))
                item.SubItems.Add("" & drRow("apenasCartoesAtivos"))
                item.SubItems.Add("" & drRow("idRedePesquisa"))
                item.SubItems.Add("" & drRow("dataPesquisa"))
                item.SubItems.Add("" & drRow("macroExecutadaOK"))
                item.SubItems.Add("" & drRow("dataInicio"))
                item.SubItems.Add("" & drRow("dataConclusao"))
                item.SubItems.Add("" & drRow("logErro"))
                If IsDBNull(drRow("dataConclusao")) Then
                    item.ImageKey = 4 '(AZUL CLARO) Pendente
                    Me.txtTotalCasosPendentes.Text += 1
                Else
                    If drRow("macroExecutadaOK") = False Then
                        item.ImageKey = 3 '(VERMELHO) concluído porém com erro de execução
                    Else
                        item.ImageKey = 7 '(AZUL ESCURO) concluído sem erro
                    End If

                End If
                Me.ListView1.Items.Add(item)
            Next drRow
        Else
            Me.ListView1.Clear()
            Me.txtTotalCasosPendentes.Text = 0
        End If
        Return True
    End Function

    Private Sub pb_mais_usuario_Click(sender As Object, e As EventArgs) Handles pb_mais_usuario.Click
        hlp.abrirForm(frm_Cad_MainFrame, True, False)
    End Sub


    Private Sub frm_execucao_robos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hlp.limparCampos(Me)
        mf_bll.carregarComboBox_listaMainFrame(Me, cb_mainFrame)
        atualizarListView()
    End Sub


    Private Sub btn_inserirExecucao_Click(sender As Object, e As EventArgs) Handles btn_inserirExecucao.Click

        'Validando se todos os campos obrigatórios foram preenchidos
        If Not hlp.validaCamposObrigatorios(Me, "cb_mainFrame") Then Exit Sub
        If Not validarOpcaoPassosRobo() Then
            MsgBox("É necessário selecionar pelo menos um passo para a execução do robô!", vbInformation, TITULO_ALERTA)
            Exit Sub
        End If

        'Tratando nome do usário dono do Mainframe
        Dim nomeUsuarioMF As String() = Split(cb_mainFrame.Text, " - ")

        If cb_1.Checked Then
            If Not Automacoes.logarB2K(nomeUsuarioMF(1)) Is Nothing Then
                Me.status_label.Text = "B2K aberto e logado com sucesso!"
                Me.cb_1.Checked = False
                cb_1_CheckedChanged(Nothing, Nothing)
            Else
                MsgBox("Erro ao fazer login, favor tentar novamente!", vbInformation, TITULO_ALERTA)
            End If

            Exit Sub
        End If

        'Registrando passoas para execução da Macro
        With execDTO
            .usuarioMainFrame = nomeUsuarioMF(1).Trim
            .mainFrame = nomeUsuarioMF(0).Trim
            .idRedePesquisa = hlp.capturaIdRede
            .dataPesquisa = Now
            .macroExecutadaOK = 0
            .apenasCartoesAtivos = IIf(cb_2.Checked, False, True)
        End With
        'Validando checkbox marcados
        If cb_4.Checked Then

            'BuscaCartoesPorCpf
            execDTO.macroExecutadaNome = "BuscaCartoesPorCpf"
            If execucao_bll.cadastrarProcessoExecucao(execDTO) Then
                Me.status_label.Text = "Inclusão de processo realizada com sucesso!"
            End If

        End If

        If cb_5.Checked Then

            'CapturarDadosCadastrais
            execDTO.macroExecutadaNome = "CapturarDadosCadastrais"
            If execucao_bll.cadastrarProcessoExecucao(execDTO) Then
                Me.status_label.Text = "Inclusão de processo realizada com sucesso!"
            End If

        End If


        If cb_6.Checked Then

            'CapturarDadosCartaoConta
            execDTO.macroExecutadaNome = "CapturarDadosCartaoConta"
            If execucao_bll.cadastrarProcessoExecucao(execDTO) Then
                Me.status_label.Text = "Inclusão de processo realizada com sucesso!"
            End If

        End If


        If cb_7.Checked Then

            'CapturarLogsManutencao
            execDTO.macroExecutadaNome = "CapturarLogsManutencao"
            If execucao_bll.cadastrarProcessoExecucao(execDTO) Then
                Me.status_label.Text = "Inclusão de processo realizada com sucesso!"
            End If

        End If

        If cb_8.Checked Then

            'CapturarDadosFatura
            execDTO.macroExecutadaNome = "CapturarDadosFatura"
            If execucao_bll.cadastrarProcessoExecucao(execDTO) Then
                Me.status_label.Text = "Inclusão de processo realizada com sucesso!"
            End If

        End If

        atualizarListView()
    End Sub

    Private Sub btn_executar_Click(sender As Object, e As EventArgs) Handles btn_executar.Click
        'Chamando as Automacoes
        If Me.txtTotalCasosPendentes.Text > 0 Then

            'Irá ficar em looping enquanto o retorno for verdadeiro
            Do While Automacoes.execucaoDeAutomacoesSequenciais(hlp.removerCharEspecial(txtCpfEspecifico.Text).Replace(".", "").Replace("-", ""))
                Me.status_progressBar.Visible = False
                Me.status_Percentual.Visible = False
                Me.status_progressBar.Value = 1
                If Me.ListView1.InvokeRequired Then
                    Me.ListView1.Invoke(New MethodInvoker(AddressOf atualizarListView))
                End If
                Application.DoEvents()
            Loop

            Me.status_label.Text = "Execução de processos finalizada!"
            Me.status_Percentual.Visible = False
            Me.status_progressBar.Visible = False
            atualizarListView()

        Else
            MsgBox("Não existe nenhuma processo para ser executado!" & vbNewLine & "Insira algum processo e depois tente outra vez." & vbNewLine & vbNewLine & "Agradecemos a compreensão!", vbInformation, TITULO_ALERTA)
        End If
    End Sub

    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        If Me.ListView1.Sorting = SortOrder.Ascending Then
            Me.ListView1.Sorting = SortOrder.Descending
        Else
            Me.ListView1.Sorting = SortOrder.Ascending
        End If
        Me.ListView1.ListViewItemSorter = New mdl_OrdenacaoListView(e.Column, Me.ListView1.Sorting)
    End Sub


    Private Function validarOpcaoPassosRobo() As Boolean
        If cb_1.Checked Or
                cb_2.Checked Or
                cb_3.Checked Or
                cb_4.Checked Or
                cb_5.Checked Or
                cb_8.Checked Or
                cb_6.Checked Or
                cb_7.Checked Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub cb_1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_1.CheckedChanged
        'Limpar qualque outra seleção de passo
        If cb_1.Checked Then
            'Tirando seleção
            cb_2.Checked = False
            cb_3.Checked = False
            cb_4.Checked = False
            cb_5.Checked = False
            cb_8.Checked = False
            cb_6.Checked = False
            cb_7.Checked = False

            'Desabilitando
            cb_2.Enabled = False
            cb_3.Enabled = False
            cb_4.Enabled = False
            cb_5.Enabled = False
            cb_8.Enabled = False
            cb_6.Enabled = False
            cb_7.Enabled = False

            Me.btn_inserirExecucao.Text = "&Abrir o B2K"
        Else
            'Habilitando
            cb_2.Enabled = True
            cb_3.Enabled = True
            cb_4.Enabled = True
            cb_5.Enabled = True
            cb_8.Enabled = True
            cb_6.Enabled = True
            cb_7.Enabled = True

            Me.btn_inserirExecucao.Text = "&Inserir Processo para Execução"
        End If
    End Sub

    Private Sub cb_2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_2.CheckedChanged
        cb_1_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub cb_3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_3.CheckedChanged

        If cb_3.Checked Then
            cb_3.Text = "Desmarcar Todos"
            cb_4.Checked = True
            cb_5.Checked = True
            cb_8.Checked = True
            cb_6.Checked = True
            cb_7.Checked = True

        Else
            cb_3.Text = "Marcar Todos"
            cb_4.Checked = False
            cb_5.Checked = False
            cb_8.Checked = False
            cb_6.Checked = False
            cb_7.Checked = False

        End If

    End Sub

    Private Sub cb_4_CheckedChanged(sender As Object, e As EventArgs) Handles cb_4.CheckedChanged
        cb_1_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub cb_5_CheckedChanged(sender As Object, e As EventArgs)
        cb_1_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub cb_6_CheckedChanged(sender As Object, e As EventArgs) Handles cb_5.CheckedChanged
        cb_1_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub cb_6_CheckedChanged_1(sender As Object, e As EventArgs) Handles cb_8.CheckedChanged
        cb_1_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub cb_7_CheckedChanged(sender As Object, e As EventArgs) Handles cb_6.CheckedChanged
        cb_1_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub cb_8_CheckedChanged(sender As Object, e As EventArgs) Handles cb_7.CheckedChanged
        cb_1_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick

        Dim finalizado As String = Me.ListView1.SelectedItems(0).SubItems(9).Text

        If MsgBox("Deseja deletar esta tarefa?", vbQuestion + vbYesNo, TITULO_ALERTA) = vbNo Then
            Exit Sub
        End If


        If String.IsNullOrEmpty(finalizado) Or finalizado = "" Then

            If execucao_bll.deletarTarefa(Me.ListView1.SelectedItems(0).SubItems(0).Text) Then
                MsgBox("Deleção de tarefa, realizada com sucesso!", MsgBoxStyle.Information, TITULO_ALERTA)
            Else
                MsgBox("Deleção de tarefa, finalizada com erro!", MsgBoxStyle.Information, TITULO_ALERTA)
            End If
        Else
            MsgBox("Apenas tarefas que ainda não foram finalizadas poderão ser deletadas!", MsgBoxStyle.Information, TITULO_ALERTA)
            Exit Sub
        End If

        atualizarListView()
    End Sub
End Class