Public Class MF_DAL
    Private hlp As New Algar.Utils.Helpers
    Private objCon As New Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, ALGAR_PWD, ALGAR_BD, ALGAR_SERVIDOR, ALGAR_USER, "")
    Private sql As String
    Private dt As DataTable

    Public Function GetMainframe() As DataTable
        Try
            sql = "Select * "
            sql += "from w_MainFrame "
            sql += "order by status desc "
            GetMainframe = objCon.retornaDataTable(sql)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function Atualizar(ByVal dto As MF_DTO) As Boolean
        Try
            With dto
                sql = "Update w_MainFrame "
                sql += "set mainframe = " & objCon.valorSql(.MAINFRAME.Trim) & ", "
                sql += "nome = " & objCon.valorSql(.NOME.Trim) & ", "
                sql += "usuario = " & objCon.valorSql(.USUARIO.Trim) & ", "
                sql += "senha = " & objCon.valorSql(hlp.Encrypt(.SENHA.Trim)) & ", "
                sql += "sessao = " & objCon.valorSql(.SESSAO.Trim) & ", "
                sql += "status = " & objCon.valorSql(.STATUS) & " "
                sql += "where id = " & objCon.valorSql(.ID) & " "
            End With
            Return objCon.executaQuery(sql)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Incluir(ByVal mainframe As MF_DTO) As Boolean
        Try
            With mainframe
                sql = "Insert into w_MainFrame "
                sql += "(mainframe,"
                sql += "nome,"
                sql += "usuario, "
                sql += "senha, "
                sql += "sessao, "
                sql += "status) "
                sql += "values( "
                sql += objCon.valorSql(.MAINFRAME) & ","
                sql += objCon.valorSql(.NOME) & ","
                sql += objCon.valorSql(.USUARIO) & ","
                sql += objCon.valorSql(hlp.Encrypt(.SENHA)) & ","
                sql += objCon.valorSql(.SESSAO) & ","
                sql += objCon.valorSql(.STATUS) & ")"
            End With
            Return objCon.executaQuery(sql)
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function GetMainframePorId(ByVal id As Integer) As MF_DTO
        Try
            sql = "Select * from w_MainFrame where id=" & objCon.valorSql(id)
            dt = objCon.retornaDataTable(sql)
            Dim dto As New MF_DTO
            If dt.Rows.Count > 0 Then 'verifica se existem registros
                For Each drRow As DataRow In dt.Rows 'efetua o loop até o fim
                    With dto
                        .ID = objCon.retornaVazioParaValorNulo(drRow("id"))
                        .MAINFRAME = objCon.retornaVazioParaValorNulo(drRow("mainframe"))
                        .NOME = objCon.retornaVazioParaValorNulo(drRow("nome"))
                        .USUARIO = objCon.retornaVazioParaValorNulo(drRow("usuario"))
                        .SENHA = objCon.retornaVazioParaValorNulo(hlp.Decrypt(drRow("senha")))
                        .SESSAO = objCon.retornaVazioParaValorNulo(drRow("sessao"))
                        .STATUS = objCon.retornaVazioParaValorNulo(drRow("status"))
                        .Acao = FlagAcao.NoAction
                    End With
                Next drRow
            End If
            Return dto
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function Deletar(ByVal id As Integer) As Boolean
        Try
            sql = "Delete from w_MainFrame where id=" & objCon.valorSql(id)
            Return objCon.executaQuery(sql)
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub carregarComboBox_listaMainFrame(frm As Form, cb As ComboBox)
        Try
            sql = "select id, mainframe + ' - ' + nome as usuario from w_mainframe order by id desc "
            dt = objCon.retornaDataTable(sql)
        Catch ex As Exception
            dt = Nothing
        End Try
        hlp.carregaComboBox(dt, frm, cb, False, "", "", False)
    End Sub
End Class
