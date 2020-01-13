Public Class execucao_DAL
    Private hlp As New Algar.Utils.Helpers
    Private objCon As New Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, ALGAR_PWD, ALGAR_BD, ALGAR_SERVIDOR, ALGAR_USER, "")
    Private sql As String
    Private dt As DataTable
    Public Function cadastrarProcessoDeExecucao(execucaoDTO As execucao_DTO, Optional ByRef duplicidadeCadastro As Boolean = False) As Boolean
        Try
            With execucaoDTO

                'Validando se já existe processo similar cadastrado e ainda não executado
                'SIM: devolve informação de duplicidade
                'NÃO: cadastra o processo
                sql = "Select id from w_execucao where macroExecutadaNome = '" & .macroExecutadaNome & "' and dataConclusao is null"
                dt = objCon.retornaDataTable(sql)
                If dt.Rows.Count > 0 Then
                    duplicidadeCadastro = True
                    Return True
                End If

                sql = "Insert into w_execucao "
                sql += "(macroExecutadaNome, "
                sql += "mainframe, "
                sql += "usuarioMainFrame, "
                sql += "apenasCartoesAtivos, "
                sql += "macroExecutadaOK, "
                sql += "dataPesquisa, "
                sql += "idRedePesquisa) "
                sql += "values( "
                sql += objCon.valorSql(.macroExecutadaNome) & ","
                sql += objCon.valorSql(.mainFrame) & ","
                sql += objCon.valorSql(.usuarioMainFrame) & ","
                sql += objCon.valorSql(.apenasCartoesAtivos) & ","
                sql += objCon.valorSql(.macroExecutadaOK) & ","
                sql += objCon.valorSql(.dataPesquisa) & ","
                sql += objCon.valorSql(.idRedePesquisa) & ")"
            End With
            Return objCon.executaQuery(sql)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function atualizacaoListView() As DataTable
        Try
            'Capturando os últimos 365 dias de passos executados
            sql = "Select * from w_execucao where dataPesquisa > dateadd(day,-365,getDate()) order by id desc "
            Return objCon.retornaDataTable(sql)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function finalizarProcesso(execDTO As execucao_DTO) As Boolean
        Try
            sql = "Update w_execucao set "
            sql += "dataConclusao = " & objCon.valorSql(Now()) & ", "
            sql += "macroExecutadaOK = " & objCon.valorSql(execDTO.macroExecutadaOK) & ", "
            sql += "logErro = " & objCon.valorSql(IIf(Not String.IsNullOrEmpty(execDTO.logErro), execDTO.logErro, vbNull)) & " "
            sql += "where id = " & objCon.valorSql(execDTO.ID) & " "
            Return objCon.executaQuery(sql)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Deletar(ByVal id As Integer) As Boolean
        Try
            sql = "Delete from w_execucao where id=" & objCon.valorSql(id)
            Return objCon.executaQuery(sql)
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
