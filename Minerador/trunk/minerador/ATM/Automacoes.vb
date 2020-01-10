Module Automacoes


#Region "GERAL"

    Dim sql As String = ""
    Dim dt As DataTable
    Dim rs As New ADODB.Recordset
    Dim rsDados As New ADODB.Recordset
    Dim rsDadosUpdate As New ADODB.Recordset, rsDadosUpdate2 As New ADODB.Recordset
    Dim hlp As New Algar.Utils.Helpers
    Dim objCon As New Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, ALGAR_PWD, ALGAR_BD, ALGAR_SERVIDOR, ALGAR_USER, "")
    Dim mainframe As MF_DTO
    Dim mainframe_sessao2 As MF_DTO
    Dim memo As String = ""
    Dim objMemo As Memo
    Dim TelaCNPBCOT1 As Object = Nothing
    Dim TelaCNQBCO00 As Object = Nothing
    Public Function GetAcessoMF(ByVal NomeMainframe As String, strNome As String) As MF_DTO
        Dim dto As New MF_DTO
        sql = "select * from w_MainFrame "
        sql += "where 1 = 1 "
        sql += "and mainframe = " & objCon.valorSql(NomeMainframe) & " "
        sql += "and nome = " & objCon.valorSql(strNome) & " "
        sql += "and status = 1 "
        dt = objCon.retornaDataTable(sql)
        If dt.Rows.Count > 0 Then 'verifica se existem registros
            For Each drRow As DataRow In dt.Rows 'efetua o loop até o fim
                With dto
                    .ID = objCon.retornaVazioParaValorNulo(drRow("ID"))
                    .MAINFRAME = objCon.retornaVazioParaValorNulo(drRow("MAINFRAME"))
                    .NOME = objCon.retornaVazioParaValorNulo(drRow("NOME"))
                    .USUARIO = objCon.retornaVazioParaValorNulo(drRow("USUARIO"))
                    .SENHA = hlp.Decrypt(objCon.retornaVazioParaValorNulo(drRow("SENHA")))
                    .SESSAO = objCon.retornaVazioParaValorNulo(drRow("SESSAO"))
                    '.SESSAO = Replace(.SESSAO, "{HOSTNAME}", Environ("COMPUTERNAME"))
                    .STATUS = objCon.retornaVazioParaValorNulo(drRow("STATUS"))
                End With
            Next drRow
        End If
        Return dto
    End Function

#End Region

#Region "B2K"

    ''' <summary>
    ''' USADO APENAS PARA INICIAR O B2K PARA FAZER TESTES
    ''' </summary>
    ''' <param name="nomeAcessoMainFrame"></param>
    Public Function logarB2K(nomeAcessoMainFrame As String) As Object
        mainframe = New MF_DTO
        mainframe = GetAcessoMF("B2K", nomeAcessoMainFrame)
        TelaCNPBCOT1 = Login_CNPBCOT1(mainframe)
        Return TelaCNPBCOT1
    End Function

    Public Function execucaoDeAutomacoesSequenciais(Optional ByVal cpfEspecifico As String = "") As Boolean
        Dim rsExecucoes As ADODB.Recordset
        Dim exec_DTO As New execucao_DTO
        Dim exec_BLL As New execucao_BLL

        rsExecucoes = objCon.retornaRs("Select top 1 * from w_execucao where dataConclusao is null and dataInicio is null order by dataPesquisa asc")
        'Validando se existe processo a ser executado
        If rsExecucoes.RecordCount > 0 Then

            With exec_DTO
                .ID = rsExecucoes.Fields("ID").Value
                .mainFrame = rsExecucoes.Fields("mainFrame").Value.ToString.Trim
                .macroExecutadaNome = rsExecucoes.Fields("macroExecutadaNome").Value.ToString.Trim
                .usuarioMainFrame = rsExecucoes.Fields("usuarioMainFrame").Value.ToString.Trim
                .apenasCartoesAtivos = rsExecucoes.Fields("apenasCartoesAtivos").Value
                .macroExecutadaOK = rsExecucoes.Fields("macroExecutadaOK").Value
                .dataPesquisa = rsExecucoes.Fields("dataPesquisa").Value

                'Marcando o início da execução da macro
                sql = "Update w_execucao set dataInicio = getdate() where id = " & .ID & " "
                objCon.executaQuery(sql)

                Select Case .macroExecutadaNome
                    Case "BuscaCartoesPorCpf"
                        .macroExecutadaOK = BuscaCartoesPorCpf(exec_DTO, Replace(.logErro, "'", ""), cpfEspecifico)
                    Case "CapturarDadosCadastrais"
                        .macroExecutadaOK = CapturarDadosCadastrais(exec_DTO, .logErro, cpfEspecifico)
                    Case "CapturarDadosCartaoConta"
                        .macroExecutadaOK = CapturarDadosCartaoConta(exec_DTO, .logErro, cpfEspecifico)
                    Case "CapturarLogsManutencao"
                        .macroExecutadaOK = CapturarLogsManutencao(exec_DTO, .logErro, cpfEspecifico)
                    Case "CapturarDadosFatura"
                        .macroExecutadaOK = CapturarDadosFatura(exec_DTO, .logErro, cpfEspecifico)
                End Select

                'Atualizando tabela de processos
                .dataConclusao = hlp.dataHoraAtual()
                exec_BLL.finalizarProcesso(exec_DTO)

            End With

            'Limpando rs
            rsExecucoes = Nothing

            'Caso de algum erro na tela preta sair da função
            If Not exec_DTO.macroExecutadaOK Then
                Return False
            Else
                Return True
            End If

        Else
            Return False
        End If

    End Function


    Public Function BuscaCartoesPorCpf(ByVal exec_DTO As execucao_DTO, Optional ByRef msgErro As String = "", Optional ByVal cpfEspecifico As String = "") As Boolean
        Dim msg = String.Empty
        Dim status_execucao As Boolean = True
        Dim dados = New List(Of String)
        Dim info() As String
        Dim inicioProcesso As Date = Now
        Dim contador As Integer = 1

        Try
            With exec_DTO

                mainframe = New MF_DTO
                mainframe = GetAcessoMF("B2K", .usuarioMainFrame)
                frm_execucao_robos.atualizarStatusLabel("Macro em Execução - Capturar Cartões " & IIf(exec_DTO.apenasCartoesAtivos, "Ativos - ", "Ativos/Inativos - "))
                Application.DoEvents()

                'Capturando todos os CPFs para pesquisa
                Dim rsCPFs As ADODB.Recordset
                rsCPFs = objCon.retornaRs("Select cpf from w_funcionarios where DATA_DEMISSAO = '1/1/1900' order by DATA_DEMISSAO DESC")
                If rsCPFs.RecordCount = 0 Then
                    'Saindo da execucao visto que são tem nenhum cpf válido para pesquisar
                    rsCPFs = Nothing
                    Return False
                End If

                'acessando tela
                TelaCNPBCOT1 = Login_CNPBCOT1(mainframe)
                'chamndo tela de captura dos cartões
                If Not TelaCNPBCOT1 Is Nothing Then
                    Dim rsDados As ADODB.Recordset

                    frm_execucao_robos.atualizarBarraDeStaus(1, rsCPFs.RecordCount, contador)
                    Application.DoEvents()

                    rsCPFs.MoveFirst()
                    Do While rsCPFs.EOF() = False

                        Dim cpf = IIf(cpfEspecifico = "", rsCPFs.Fields("CPF").Value, cpfEspecifico)

                        dados = B2K_BuscaCartoesPorCpf(mainframe, TelaCNPBCOT1, cpf, .apenasCartoesAtivos, status_execucao, msgErro)
                        'Caso de algum erro na tela preta sair da função
                        If Not status_execucao Then
                            Return False
                        End If

                        'validando se houve retorno de informações válidas e salvando na tabela 
                        If dados.Count > 0 Then

                            For Each cartao In dados
                                info = Split(cartao, ";")
                                rsDados = objCon.retornaRs("Select * from w_cartoes where cpf = '" & cpf & "' and cartao = '" & info(0) & "'")

                                'Se encontrar informações deve-se editar senão deve-se adicionar
                                If rsDados.RecordCount = 0 Then
                                    rsDados.AddNew()
                                    rsDados.Fields("CPF").Value = cpf
                                End If
                                rsDados.Fields("cartao").Value = info(0)
                                rsDados.Fields("bin").Value = Left(info(0), 6)
                                rsDados.Fields("nome").Value = info(1)
                                rsDados.Fields("endereco").Value = info(2)
                                rsDados.Fields("numResidencial").Value = info(3)
                                rsDados.Fields("cidade").Value = info(4)
                                rsDados.Fields("estado").Value = info(5)
                                rsDados.Fields("cep").Value = info(6)
                                rsDados.Fields("tipoCartao").Value = info(7)
                                rsDados.Fields("bloqueio").Value = info(8)
                                rsDados.Fields("ativo").Value = IIf(Left(info(8), 1) = "S", False, True)
                                rsDados.Fields("dataAtualizacao").Value = hlp.dataHoraAtual
                                rsDados.Fields("idAtualizacao").Value = hlp.capturaIdRede
                                rsDados.Update()
                            Next

                        End If


                        If cpfEspecifico <> "" Then
                            Exit Do
                        End If
                        rsCPFs.MoveNext()
                        contador += 1
                        frm_execucao_robos.atualizarBarraDeStaus(0, rsCPFs.RecordCount, contador)
                        Application.DoEvents()
                    Loop
                End If

                rsCPFs = Nothing
                rsDados = Nothing
                Return True
            End With

        Catch ex As Exception
            msgErro = ex.Message
            Return False
        End Try


    End Function

    Public Function CapturarDadosCadastrais(ByVal exec_DTO As execucao_DTO, Optional ByRef msgErro As String = "", Optional ByVal cpfEspecifico As String = "") As Boolean
        Dim msg = String.Empty
        Dim status_execucao As Boolean = True
        Dim dados As New dadosCadastrais_DTO
        Dim inicioProcesso As Date = Now
        Dim contador As Integer = 1

        Try


            With exec_DTO

                mainframe = New MF_DTO
                mainframe = GetAcessoMF("B2K", .usuarioMainFrame)
                frm_execucao_robos.atualizarStatusLabel("Macro em Execução - Dados Cadastrais " & IIf(.apenasCartoesAtivos, "Ativos - ", "Ativos/Inativos - "))
                Application.DoEvents()

                'Capturando todos os cartões para pesquisa
                'Não é necessário função de AGREGAÇÃO visto que a função de CARTÕES por CPF não permite duplicados.
                Dim rsCards As ADODB.Recordset
                sql = "Select * from w_cartoes where tipoCartao <> 'CONTA' and ativo = " & objCon.valorSql(.apenasCartoesAtivos) & " "
                sql += IIf(cpfEspecifico <> "", "and cpf = " & objCon.valorSql(cpfEspecifico) & " ", "")
                rsCards = objCon.retornaRs(sql)
                If rsCards.RecordCount = 0 Then
                    'Saindo da execucao visto que não tem nenhum cartão válido para pesquisar
                    rsCards = Nothing
                    Return False
                End If

                'acessando tela
                TelaCNPBCOT1 = Login_CNPBCOT1(mainframe)
                'chamndo tela de captura dos cartões
                If Not TelaCNPBCOT1 Is Nothing Then

                    frm_execucao_robos.atualizarBarraDeStaus(1, rsCards.RecordCount, contador)
                    Application.DoEvents()

                    rsCards.MoveFirst()
                    Do While rsCards.EOF() = False

                        dados = B2K_CapturarDadosCadastrais(mainframe, TelaCNPBCOT1, rsCards.Fields("cartao").Value, status_execucao, msgErro)
                        'Caso de algum erro na tela preta sair da função
                        If Not status_execucao Then
                            Return False
                        End If

                        'validando se houve retorno de informações válidas e salvando na tabela 
                        If Not dados Is Nothing Then

                            rsDados = objCon.retornaRs("Select * from w_dadosCadastrais where cpf = '" & rsCards.Fields("CPF").Value & "' and cartao = '" & rsCards.Fields("cartao").Value & "'")

                            With dados

                                'Se encontrar informações deve-se editar senão deve-se adicionar
                                If rsDados.RecordCount = 0 Then
                                    rsDados.AddNew()
                                    rsDados.Fields("CPF").Value = rsCards.Fields("CPF").Value
                                    rsDados.Fields("cartao").Value = rsCards.Fields("cartao").Value
                                    rsDados.Fields("bin").Value = Left(rsCards.Fields("cartao").Value, 6)
                                End If

                                rsDados.Fields("produto").Value = .produto.Trim
                                rsDados.Fields("data_alteracao_End").Value = .data_alteracao_End
                                rsDados.Fields("data_alteracao_telefones").Value = .data_alteracao_telefones

                                rsDados.Fields("nome").Value = .nome.Trim
                                rsDados.Fields("nome_2").Value = .nome_2.Trim
                                rsDados.Fields("nome_3").Value = .nome_3.Trim
                                rsDados.Fields("nome_4").Value = .nome_4.Trim
                                rsDados.Fields("data_Nascimento").Value = .data_Nascimento
                                rsDados.Fields("sexo").Value = .sexo.Trim

                                rsDados.Fields("tel_residencial").Value = .tel_residencial.Trim
                                rsDados.Fields("tel_empresa").Value = .tel_empresa.Trim
                                rsDados.Fields("tel_celular").Value = .tel_celular.Trim

                                rsDados.Fields("end_cobranca").Value = .end_cobranca.Trim
                                rsDados.Fields("cep_cobranca").Value = .cep_cobranca.Trim
                                rsDados.Fields("cidade_cobranca").Value = .cidade_cobranca.Trim
                                rsDados.Fields("estado_cobranca").Value = .estado_cobranca.Trim

                                rsDados.Fields("end_correspondencia").Value = .end_correspondencia.Trim
                                rsDados.Fields("cep_correspondencia").Value = .cep_correspondencia.Trim
                                rsDados.Fields("cidade_correspondencia").Value = .cidade_correspondencia.Trim
                                rsDados.Fields("estado_correspondencia").Value = .estado_correspondencia.Trim

                                rsDados.Fields("end_anterior").Value = .end_anterior.Trim
                                rsDados.Fields("cep_anterior").Value = .cep_anterior.Trim
                                rsDados.Fields("cidade_anterior").Value = .cidade_anterior.Trim
                                rsDados.Fields("estado_anterior").Value = .estado_anterior.Trim

                                rsDados.Fields("dataAtualizacao").Value = hlp.dataHoraAtual
                                rsDados.Fields("idAtualizacao").Value = hlp.capturaIdRede
                                rsDados.Update()
                            End With

                        End If

                        rsCards.MoveNext()
                        contador += 1
                        frm_execucao_robos.atualizarBarraDeStaus(0, rsCards.RecordCount, contador)
                        Application.DoEvents()
                    Loop
                End If

                rsCards = Nothing
                rsDados = Nothing
                Return True
            End With

        Catch ex As Exception
            msgErro = ex.Message
            Return False
        End Try


    End Function

    Public Function CapturarDadosCartaoConta(ByVal exec_DTO As execucao_DTO, Optional ByRef msgErro As String = "", Optional ByVal cpfEspecifico As String = "") As Boolean
        Dim msg = String.Empty
        Dim status_execucao As Boolean = True
        Dim dados As New cartoes_DTO
        Dim inicioProcesso As Date = Now
        Dim contador As Integer = 1

        Try

            With exec_DTO

                mainframe = New MF_DTO
                mainframe = GetAcessoMF("B2K", .usuarioMainFrame)
                frm_execucao_robos.atualizarStatusLabel("Macro em Execução - Dados Cartão / Conta " & IIf(.apenasCartoesAtivos, "Ativos - ", "Ativos/Inativos - "))
                Application.DoEvents()

                'Capturando todos os cartões para pesquisa
                Dim rsCards As ADODB.Recordset
                sql = "Select * from w_cartoes where ativo = " & objCon.valorSql(.apenasCartoesAtivos) & " "
                sql += IIf(cpfEspecifico <> "", "and cpf = " & objCon.valorSql(cpfEspecifico) & " ", "")
                rsCards = objCon.retornaRs(sql)
                If rsCards.RecordCount = 0 Then
                    'Saindo da execucao visto que são tem nenhum cartão válido para pesquisar
                    rsCards = Nothing
                    Return False
                End If

                'acessando tela
                TelaCNPBCOT1 = Login_CNPBCOT1(mainframe)
                'chamndo tela de captura dos cartões
                If Not TelaCNPBCOT1 Is Nothing Then

                    frm_execucao_robos.atualizarBarraDeStaus(1, rsCards.RecordCount, contador)
                    Application.DoEvents()

                    rsCards.MoveFirst()
                    Do While rsCards.EOF() = False
                        dados = B2K_CapturarDadosCartaoConta(mainframe, TelaCNPBCOT1, rsCards.Fields("cartao").Value, rsCards.Fields("tipoCartao").Value, status_execucao, msgErro)
                        'Caso de algum erro na tela preta sair da função
                        If Not status_execucao Then
                            Return False
                        End If

                        'validando se houve retorno de informações válidas e salvando na tabela 
                        If Not dados Is Nothing Then

                            With dados

                                If rsCards.Fields("tipoCartao").Value = "CONTA" Then
                                    rsCards.Fields("limite_Credito").Value = .limite_Credito
                                    rsCards.Fields("limite_Credito_Anterior").Value = .limite_Credito_Anterior
                                    rsCards.Fields("limite_Credito_Disponivel").Value = .limite_Credito_Disponivel
                                    rsCards.Fields("limite_Saque").Value = .limite_Saque
                                    rsCards.Fields("limite_Saque_Disponivel").Value = .limite_Saque_Disponivel
                                    rsCards.Fields("limite_Data_Alteracao").Value = .limite_Data_Alteracao
                                    rsCards.Fields("limite_Fonte_Alteracao").Value = .limite_Fonte_Alteracao
                                    rsCards.Fields("data_Desbloqueio").Value = .data_Desbloqueio
                                    rsCards.Fields("data_Abertura_Conta").Value = .data_Abertura_Conta
                                Else
                                    rsCards.Fields("data_Emissao").Value = .data_Emissao
                                End If

                                rsCards.Fields("dataAtualizacao").Value = hlp.dataHoraAtual
                                rsCards.Fields("idAtualizacao").Value = hlp.capturaIdRede
                                rsCards.Update()
                            End With

                        End If

                        rsCards.MoveNext()
                        contador += 1
                        frm_execucao_robos.atualizarBarraDeStaus(0, rsCards.RecordCount, contador)
                        Application.DoEvents()
                    Loop
                End If

                'Atualização dos produtos na tabela w_cartoes
                sql = "update c set c.produto = p.produto from w_cartoes c inner join w_sysProdutos p on c.bin = p.bin"
                objCon.executaQuery(sql)

                rsCards = Nothing
                rsDados = Nothing
                Return True
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            msgErro = ex.Message
            Return False
        End Try

    End Function

    Public Function CapturarLogsManutencao(ByVal exec_DTO As execucao_DTO, Optional ByRef msgErro As String = "", Optional ByVal cpfEspecifico As String = "") As Boolean
        Dim msg = String.Empty
        Dim status_execucao As Boolean = True
        Dim historicoManutencao = New List(Of manutencoes_DTO)
        Dim inicioProcesso As Date = Now
        Dim contador As Integer = 1
        Dim dataLimite As Date
        Try
            With exec_DTO

                mainframe = New MF_DTO
                mainframe = GetAcessoMF("B2K", .usuarioMainFrame)
                frm_execucao_robos.atualizarStatusLabel("Macro em Execução - Logs de Manutenção " & IIf(.apenasCartoesAtivos, "Ativos - ", "Ativos/Inativos - "))
                Application.DoEvents()

                'Capturando todos os cartões para pesquisa
                Dim rsCards As ADODB.Recordset

                ''Qry para ser utilizada como complemento da ação de captura qdo acontece um erro e o processo é forçado a finalizar
                'sql = "select c.cartao, c.cpf from w_cartoes c left join w_manutencoes m on c.cpf = m.cpf and c.cartao = m.cartao "
                'sql += "where m.cartao is null group by c.cartao, c.cpf"

                sql = "Select cpf, cartao from w_cartoes where ativo = " & objCon.valorSql(.apenasCartoesAtivos) & " "
                sql += IIf(cpfEspecifico <> "", "and cpf = " & objCon.valorSql(cpfEspecifico) & " ", " ")
                sql += "group by cpf, cartao"
                rsCards = objCon.retornaRs(sql)

                If rsCards.RecordCount = 0 Then
                    'Saindo da execucao visto que não tem nenhum cartão válido para pesquisar
                    rsCards = Nothing
                    Return False
                Else
                    'Determinar qual deve ser o período inicial da captura das manutenções
                    'Manter um histórico mínimo de 12 meses
                    sql = "select cpf, cartao,  max(dataManutencao) as dtManutencao from w_manutencoes "
                    sql += "group by  cpf, cartao "
                    rsDados = objCon.retornaRs(sql)

                    sql = "Select top 1 * from w_manutencoes"
                    rsDadosUpdate = objCon.retornaRs(sql)
                End If

                'acessando tela
                TelaCNPBCOT1 = Login_CNPBCOT1(mainframe)
                'chamndo tela de captura dos cartões
                If Not TelaCNPBCOT1 Is Nothing Then

                    frm_execucao_robos.atualizarBarraDeStaus(1, rsCards.RecordCount, contador)
                    Application.DoEvents()

                    rsCards.MoveFirst()
                    Do While rsCards.EOF() = False
                        rsDados.Filter = ""
                        rsDados.Filter = "cpf = '" & rsCards.Fields("CPF").Value & "' and cartao = '" & rsCards.Fields("cartao").Value & "'"
                        If rsDados.RecordCount = 0 Then
                            'Quando não tem dados de manutenções capturados
                            'Selecionar o período máximo
                            dataLimite = Date.Now.AddMonths(-12).Date
                        Else
                            dataLimite = rsDados.Fields("dtManutencao").Value
                        End If

                        historicoManutencao = B2K_CapturarManutencoes(mainframe, TelaCNPBCOT1, rsCards.Fields("cpf").Value, rsCards.Fields("cartao").Value, dataLimite, status_execucao, msgErro)
                        'Caso de algum erro na tela preta sair da função
                        If Not status_execucao Then
                            Return False
                        End If

                        'validando se houve retorno de informações válidas e salvando na tabela 
                        If Not historicoManutencao Is Nothing Then
                            For Each manutencao In historicoManutencao
                                With manutencao
                                    rsDadosUpdate.AddNew()
                                    rsDadosUpdate.Fields("CPF").Value = .cpf
                                    rsDadosUpdate.Fields("cartao").Value = .cartao
                                    rsDadosUpdate.Fields("bin").Value = .bin
                                    rsDadosUpdate.Fields("task").Value = .task
                                    rsDadosUpdate.Fields("descricaoManutencao").Value = .descricaoManutencao
                                    rsDadosUpdate.Fields("dataManutencao").Value = .dataManutencao
                                    rsDadosUpdate.Fields("horaManutencao").Value = .horaManutencao
                                    rsDadosUpdate.Fields("usuarioRealizouManutencao").Value = .usuarioRealizouManutencao
                                    rsDadosUpdate.Fields("departamentoManutencao").Value = .departamentoManutencao
                                    rsDadosUpdate.Fields("dataAtualizacao").Value = hlp.dataAbreviada()
                                    rsDadosUpdate.Fields("idAtualizacao").Value = hlp.capturaIdRede()
                                    rsDadosUpdate.Update()
                                End With
                            Next
                        End If

                        rsCards.MoveNext()
                        contador += 1
                        frm_execucao_robos.atualizarBarraDeStaus(0, rsCards.RecordCount, contador)
                        Application.DoEvents()

                        'Caso de algum erro na tela preta sair da função
                        If Not status_execucao Then
                            Return False
                        End If
                    Loop

                End If

                rsCards = Nothing
                rsDados = Nothing
                Return True
            End With

        Catch ex As Exception
            msgErro = ex.Message
            Return False
        End Try
    End Function

    Public Function CapturarDadosFatura(ByVal exec_DTO As execucao_DTO, Optional ByRef msgErro As String = "", Optional ByVal cpfEspecifico As String = "") As Boolean
        Dim msg = String.Empty
        Dim status_execucao As Boolean = True
        Dim historicoFaturas = New List(Of fatura_DTO)
        Dim inicioProcesso As Date = Now
        Dim contador As Integer = 1
        Dim dataLimite As Date
        Try
            With exec_DTO

                mainframe = New MF_DTO
                mainframe = GetAcessoMF("B2K", .usuarioMainFrame)
                frm_execucao_robos.atualizarStatusLabel("Macro em Execução - Logs de Manutenção " & IIf(.apenasCartoesAtivos, "Ativos - ", "Ativos/Inativos - "))
                Application.DoEvents()

                'Capturando todos os cartões para pesquisa
                Dim rsCards As ADODB.Recordset

                'Qry para ser utilizada como complemento da ação de captura qdo acontece um erro e o processo é forçado a finalizar
                'sql = "select c.cartao, c.cpf from w_cartoes c left join w_manutencoes m on c.cpf = m.cpf and c.cartao = m.cartao "
                'sql += "where m.cartao is null group by c.cartao, c.cpf"

                sql = "Select cpf, cartao from w_cartoes where ativo = " & objCon.valorSql(.apenasCartoesAtivos) & " and tipoCartao = 'CONTA' "
                sql += IIf(cpfEspecifico <> "", "and cpf = " & objCon.valorSql(cpfEspecifico) & " ", " ")
                sql += "group by cpf, cartao"
                rsCards = objCon.retornaRs(sql)

                If rsCards.RecordCount = 0 Then
                    'Saindo da execucao visto que não tem nenhum cartão válido para pesquisar
                    rsCards = Nothing
                    Return False
                Else
                    'Determinar qual deve ser o período inicial da captura das faturas
                    'Manter um histórico mínimo de 12 meses
                    sql = "select cpf, cartao,  max(dataCorte) as dtCorte from w_faturas "
                    sql += "group by  cpf, cartao "
                    rsDados = objCon.retornaRs(sql)

                    sql = "Select top 1 * from w_faturas "
                    rsDadosUpdate = objCon.retornaRs(sql)

                    sql = "Select top 1 * from w_autorizacoes "
                    rsDadosUpdate2 = objCon.retornaRs(sql)
                End If

                'acessando tela
                TelaCNPBCOT1 = Login_CNPBCOT1(mainframe)
                'chamndo tela de captura dos cartões
                If Not TelaCNPBCOT1 Is Nothing Then

                    frm_execucao_robos.atualizarBarraDeStaus(1, rsCards.RecordCount, contador)
                    Application.DoEvents()

                    rsCards.MoveFirst()
                    Do While rsCards.EOF() = False
                        rsDados.Filter = ""
                        rsDados.Filter = "cpf = '" & rsCards.Fields("CPF").Value & "' and cartao = '" & rsCards.Fields("cartao").Value & "'"
                        If rsDados.RecordCount = 0 Then
                            'Quando não tem dados de manutenções capturados
                            'Selecionar o período máximo
                            'Usado 13 meses para evitar problemas na captura do 12º mês devido ao dia do corte
                            dataLimite = Date.Now.AddMonths(-13).Date
                        Else
                            dataLimite = rsDados.Fields("dtCorte").Value
                        End If

                        historicoFaturas = B2K_CapturarFaturas(mainframe, TelaCNPBCOT1, rsCards.Fields("cpf").Value, rsCards.Fields("cartao").Value, dataLimite, status_execucao, msgErro)
                        'Caso de algum erro na tela preta sair da função
                        If Not status_execucao Then
                            Return False
                        End If

                        'validando se houve retorno de informações válidas e salvando na tabela 
                        If Not historicoFaturas Is Nothing Then
                            For Each fatura In historicoFaturas 'Salvando as faturas
                                With fatura
                                    rsDadosUpdate.AddNew()
                                    rsDadosUpdate.Fields("CPF").Value = .cpf
                                    rsDadosUpdate.Fields("cartao").Value = .cartao
                                    rsDadosUpdate.Fields("bin").Value = .bin
                                    rsDadosUpdate.Fields("dataCorte").Value = .dataCorte
                                    rsDadosUpdate.Fields("dataVencimento").Value = .dataVencimento
                                    rsDadosUpdate.Fields("dataPagamento").Value = .dataPagamento
                                    rsDadosUpdate.Fields("valorFatura").Value = .valorFatura
                                    rsDadosUpdate.Fields("valorPagamento").Value = .valorPagamento
                                    rsDadosUpdate.Fields("dataAtualizacao").Value = hlp.dataHoraAtual()
                                    rsDadosUpdate.Fields("idAtualizacao").Value = hlp.capturaIdRede()
                                    rsDadosUpdate.Update()
                                End With
                                For Each autorizacao As autorizacoes_DTO In fatura.listaAutorizacoes 'Salvando cada autorizacao da fatura salva acima
                                    With autorizacao
                                        rsDadosUpdate2.AddNew()
                                        rsDadosUpdate2.Fields("CPF").Value = .cpf
                                        rsDadosUpdate2.Fields("cartao").Value = .cartao
                                        rsDadosUpdate2.Fields("bin").Value = .bin
                                        rsDadosUpdate2.Fields("dataCorte").Value = .dataCorte
                                        rsDadosUpdate2.Fields("dataVencimento").Value = .dataVencimento
                                        rsDadosUpdate2.Fields("dataTransacao").Value = .dataTransacao
                                        rsDadosUpdate2.Fields("dataInclusaoFatura").Value = .dataInclusaoFatura
                                        rsDadosUpdate2.Fields("codReferencia").Value = .codReferencia
                                        rsDadosUpdate2.Fields("codAutorizacao").Value = .codAutorizacao
                                        rsDadosUpdate2.Fields("estabelecimento").Value = .estabelecimento
                                        rsDadosUpdate2.Fields("valorTransacao").Value = .valorTransacao
                                        rsDadosUpdate2.Fields("pos").Value = .pos
                                        rsDadosUpdate2.Fields("ecMaquineta").Value = .ecMaquineta
                                        rsDadosUpdate2.Fields("ecCodPais").Value = .ecCodPais
                                        rsDadosUpdate2.Fields("ecCidade").Value = .ecCidade
                                        rsDadosUpdate2.Fields("ecNome").Value = .ecNome
                                        rsDadosUpdate2.Fields("codMoeda").Value = .codMoeda
                                        rsDadosUpdate2.Fields("codRamoAtividade").Value = .codRamoAtividade
                                        rsDadosUpdate2.Fields("dataAtualizacao").Value = hlp.dataHoraAtual()
                                        rsDadosUpdate2.Fields("idAtualizacao").Value = hlp.capturaIdRede()
                                        rsDadosUpdate2.Update()
                                    End With
                                Next
                            Next
                        End If

                        rsCards.MoveNext()
                        contador += 1
                        frm_execucao_robos.atualizarBarraDeStaus(0, rsCards.RecordCount, contador)
                        Application.DoEvents()

                        'Caso de algum erro na tela preta sair da função
                        If Not status_execucao Then
                            Return False
                        End If
                    Loop

                End If

                rsCards = Nothing
                rsDados = Nothing
                Return True
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            msgErro = ex.Message
            Return False
        End Try
    End Function

#End Region

End Module
