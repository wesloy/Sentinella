Imports Microsoft.Office.Interop

Module fncGenericas

    Private sql As String
    Private dt As DataTable
    Private hlp As New Algar.Utils.Helpers

    Public Function ExportListViewToExcel(listView As ListView) As Boolean
        Try
            Dim objExcel As New Excel.Application
            Dim bkWorkBook As Excel.Workbook
            Dim shWorkSheet As Excel.Worksheet
            Dim i As Integer
            Dim j As Integer
            objExcel = New Excel.Application
            bkWorkBook = objExcel.Workbooks.Add
            shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)
            shWorkSheet.Cells().NumberFormat = "@" 'Formatando as celulas como texto
            For i = 0 To listView.Columns.Count - 1
                shWorkSheet.Cells(1, i + 1) = listView.Columns(i).Text
            Next
            For i = 0 To listView.Items.Count - 1
                For j = 0 To listView.Items(i).SubItems.Count - 1
                    shWorkSheet.Cells(i + 2, j + 1) = listView.Items(i).SubItems(j).Text.ToString
                Next
            Next
            objExcel.Visible = True
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Function RN_capturaFinalCartao(cartao As String) As String
        Try
            If cartao.Length = 15 Then
                Return Microsoft.VisualBasic.Right(cartao, 9)
            ElseIf cartao.Length = 16 Then
                Return Microsoft.VisualBasic.Right(cartao, 10)
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    Public Function RN_formataCartao19Posicoes(cartao As String) As String
        Try
            Dim novoCard As String
            novoCard = Microsoft.VisualBasic.Right("0000" & cartao, 19)
            Return novoCard.ToString
        Catch ex As Exception
            Return cartao
        End Try
    End Function
    Public Function RN_montagemMemo(strMemo As String, cartao As String) As Memo
        Try
            Dim objMemo As New Memo
            Dim ListLinhasMemo As New List(Of Object)
            Dim limitePorLinha As Integer = 50
            Dim TotalLinhasMemo As Integer = 4
            Dim nroCaracteres As Long
            Dim TotalDeLinhasCalculadas As Long
            Dim TotalDeMemo As Long
            Dim count As Long = 0
            Dim cursorLinhas As Long = 0
            Dim finalCartao As String = Microsoft.VisualBasic.Right(cartao, 3)

            'Montagem do memo por limite de 50 caracteres por linha
            nroCaracteres = strMemo.Length
            TotalDeLinhasCalculadas = Math.Ceiling(nroCaracteres / limitePorLinha)
            TotalDeMemo = Math.Ceiling(TotalDeLinhasCalculadas / TotalLinhasMemo)

            'predefinir o limite de 4 linhas sempre
            If TotalDeLinhasCalculadas Mod 4 <> 0 Then
                For p = 1 To 4
                    TotalDeLinhasCalculadas += 1
                    If TotalDeLinhasCalculadas Mod 4 = 0 Then
                        Exit For
                    End If
                Next
            End If

            'preencher as linhas
            For i = 0 To (TotalDeLinhasCalculadas - 1)
                If i = 0 Then
                    ListLinhasMemo.Add(Mid(strMemo, 1, limitePorLinha))
                Else
                    ListLinhasMemo.Add(Mid(strMemo, ((limitePorLinha * count) + 1), limitePorLinha))
                End If
                count += 1
            Next

            'Monta a quantidade de memos a serem registrados respeitando o limite de 4 linhas com 50 caracteres
            objMemo.memo = New List(Of MemoItens)
            For i = 1 To TotalDeMemo
                With objMemo
                    .memo.Add(New MemoItens With {
                    .linha1 = hlp.removerCharEspecial(ListLinhasMemo(0).ToString),
                    .linha2 = hlp.removerCharEspecial(ListLinhasMemo(1).ToString),
                    .linha3 = hlp.removerCharEspecial(ListLinhasMemo(2).ToString),
                    .linha4 = hlp.removerCharEspecial(ListLinhasMemo(3).ToString)
                    })
                End With
                ListLinhasMemo.RemoveAt(3)
                ListLinhasMemo.RemoveAt(2)
                ListLinhasMemo.RemoveAt(1)
                ListLinhasMemo.RemoveAt(0)
            Next
            Return objMemo
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub RN_STATUS_ROBO(ByVal _ONLINE As Boolean)
        Dim sql As String
        Dim objCon As New Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, ALGAR_PWD, ALGAR_BD, ALGAR_SERVIDOR, ALGAR_USER, "")
        Dim hlp As New Algar.Utils.Helpers
        Try

            If _ONLINE Then
                sql = "Update Desbloqueio_StatusRobo SET online = 1 where Chave = 1 "
            Else
                sql = "Update Desbloqueio_StatusRobo SET online = 0 where Chave = 1 "
            End If
            objCon.executaQuery(sql)
        Catch ex As Exception
        End Try
    End Sub
    'Public Function RN_CAPTURA_STATUS_ROBO() As Boolean
    '    Try
    '        Dim sql As String
    '        Dim objCon As New Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, ALGAR_PWD, ALGAR_BD, ALGAR_SERVIDOR, ALGAR_USER, "")
    '        Dim hlp As New Algar.Utils.Helpers
    '        sql = "Select * from Desbloqueio_StatusRobo where chave = 1"
    '        dt = objCon.retornaDataTable(sql)
    '        Dim objeto As New Dados
    '        If dt.Rows.Count > 0 Then
    '            For Each drRow As DataRow In dt.Rows
    '                Return drRow("online")
    '            Next drRow
    '        End If
    '        Return False
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function


    'Public Function RN_Schedule() As Boolean
    '    Try
    '        If hlp.FormataDataHoraCompleta(Now()) < hlp.FormataDataHoraCompleta(DT_INICIAL) _
    '        Or hlp.FormataDataHoraCompleta(Now()) > hlp.FormataDataHoraCompleta(DT_FINAL) Then
    '            'fora do horario
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Public Sub RN_ValidaSchedule()
    '    Try
    '        If Not RN_Schedule() Then
    '            MsgBox("Este aplicativo apenas poderá ser acessado entre os dias: " & vbNewLine &
    '               " " & hlp.FormataDataHoraCompleta(DT_INICIAL).ToString & " até " & hlp.FormataDataHoraCompleta(DT_FINAL).ToString, vbInformation, TITULO_ALERTA)
    '            Application.ExitThread()
    '            Application.Exit()
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

End Module
