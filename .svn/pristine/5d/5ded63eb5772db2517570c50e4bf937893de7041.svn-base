Public Class execucao_BLL
    Private dal As New execucao_DAL
    Public Function cadastrarProcessoExecucao(execucaoDTO As execucao_DTO) As Boolean
        Dim duplicidade As Boolean = False
        cadastrarProcessoExecucao = dal.cadastrarProcessoDeExecucao(execucaoDTO, duplicidade)
        If duplicidade Then
            MsgBox("Não foi cadastrado o processo " & execucaoDTO.macroExecutadaNome & " de execução, porque já tem um processo cadastrado e não finalizado!")
        End If
        Return cadastrarProcessoExecucao
    End Function
    Public Function atualiarListView() As DataTable
        Return dal.atualizacaoListView
    End Function
    Public Function finalizarProcesso(execDTO As execucao_DTO) As Boolean
        Return dal.finalizarProcesso(execDTO)
    End Function

    Public Function deletarTarefa(id As Integer) As Boolean
        Return dal.Deletar(id)
    End Function

End Class
