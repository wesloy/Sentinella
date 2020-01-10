Public Class MF_BLL
    Private dal As New MF_DAL
    Public Function GetMainframe() As DataTable
        Return dal.GetMainframe
    End Function
    Public Function GetMainframePorId(ByVal id As Integer) As MF_DTO
        Return dal.GetMainframePorId(id)
    End Function
    Public Function Salvar(ByVal dto As MF_DTO) As Boolean
        If dto.ACAO = FlagAcao.Insert Then
            Return dal.Incluir(dto)
        ElseIf dto.ACAO = FlagAcao.Update Then
            Return dal.Atualizar(dto)
        ElseIf dto.ACAO = FlagAcao.Delete Then
            Return dal.Deletar(dto.ID)
        End If
        Return False
    End Function

    Public Sub carregarComboBox_listaMainFrame(frm As Form, cb As ComboBox)
        dal.carregarComboBox_listaMainFrame(frm, cb)
    End Sub
End Class
