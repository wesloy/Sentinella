Module Telas
    Private hlp As New Algar.Utils.Helpers
    Private qtdeTentativas As Integer = 0
#Region "B2K"

    Public Function Login_CNPBCOT1(Mainframe As MF_DTO) As Object
        'Variaveis do sistema de telas
        Dim obSystem As Object
        Dim obSessionB2K As Object
        Dim telaB2K As Object = Nothing
        Dim clsB2K As New MF_DTO
        Dim contador As Integer = 0

        Try
            'Captura sessao, usuario e senha do Mainframe registradas no db
            clsB2K = Mainframe
            If clsB2K Is Nothing Then
                Return Nothing
            End If
            '************************************************************
            'Abrindo as telas necessarias do Mainframe
            obSystem = CreateObject("EXTRA.System")
            If (obSystem Is Nothing) Then
                Return Nothing
            End If
            obSessionB2K = obSystem.Sessions.Open(clsB2K.SESSAO)
            If obSessionB2K Is Nothing Then
                Return Nothing
            End If
            obSessionB2K.Visible = True
            telaB2K = obSessionB2K.Screen
            '***********************************************************
            'Caso tenha tido problema na abertura da sessão
            If telaB2K Is Nothing Then
                obSystem.quit()
                Return Nothing
            End If

            With telaB2K
                .WaitHostQuiet(3000)
                'Validar se o sistema já esta logado/aberto
                If Trim(.GetString(10, 14, 32)) <> "Departamentos e Empresas Ligadas" Then

                    .putstring("i", 1, 7)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(250)

                    If Trim(.getString(1, 23, 27)) <> "ACCOUNT INQUIRY ( PAGE 1 )" Then 'Validando se a tela já está aberta
                        LogoffSystemB2K(telaB2K)

                        'Tentado até 3x logar na tela preta
                        Do While Not .getstring(24, 2, 44) = "DFHCE3549 Sign-on is complete (Language ENU)" And contador < 2

                            If contador = 1 Then
                                LogoffSystemB2K(telaB2K)
                            End If

                            .PutString("CNPBCOT1", 20, 5)
                            .SendKeys("<Enter>")
                            .WaitHostQuiet(800)

                            'Emulando Pause Break
                            .SendKeys("<Clear>")
                            .WaitHostQuiet(500)
                            .SendKeys("<Clear>")
                            .WaitHostQuiet(500)
                            .PutString("CESN", 5, 5)
                            .SendKeys("<Enter>")
                            .WaitHostQuiet(1000)

                            'Login
                            .PutString(clsB2K.USUARIO, 10, 26, 7)
                            .PutString(clsB2K.SENHA, 11, 26)
                            .WaitHostQuiet(500)
                            .SendKeys("<Enter>")
                            .WaitHostQuiet(500)
                            contador += 1

                        Loop

                    End If

                Else

                    'Tentado até 3x logar na tela preta
                    Do While Not .getstring(24, 2, 44) = "DFHCE3549 Sign-on is complete (Language ENU)" And contador < 2

                        If contador = 1 Then
                            LogoffSystemB2K(telaB2K)
                        End If

                        .PutString("CNPBCOT1", 20, 5)
                        .SendKeys("<Enter>")
                        .WaitHostQuiet(800)

                        'Emulando Pause Break
                        .SendKeys("<Clear>")
                        .WaitHostQuiet(500)
                        .SendKeys("<Clear>")
                        .WaitHostQuiet(500)
                        .PutString("CESN", 5, 5)
                        .SendKeys("<Enter>")
                        .WaitHostQuiet(1000)

                        'Login
                        .PutString(clsB2K.USUARIO, 10, 26, 7)
                        .PutString(clsB2K.SENHA, 11, 26)
                        .WaitHostQuiet(500)
                        .SendKeys("<Enter>")
                        .WaitHostQuiet(500)
                        contador += 1

                    Loop


                End If

            End With


            If Trim(telaB2K.getstring(24, 2, 44)) = "DFHCE3549 Sign-on is complete (Language ENU)" Or Trim(telaB2K.getString(1, 23, 27)) = "ACCOUNT INQUIRY ( PAGE 1 )" Then
                Return telaB2K
            Else
                obSystem.quit
                Return Nothing
            End If

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function Login_CNQBCO00(Mainframe As MF_DTO) As Object
        'Variaveis do sistema de telas
        Dim obSystem As Object
        Dim obSessionB2K As Object
        Dim telaB2K As Object = Nothing
        Dim clsB2K As New MF_DTO

        Try
            'Captura sessao, usuario e senha do Mainframe registradas no db
            clsB2K = Mainframe
            If clsB2K Is Nothing Then
                Return Nothing
            End If
            '************************************************************
            'Abrindo as telas necessarias do Mainframe
            obSystem = CreateObject("EXTRA.System")
            If (obSystem Is Nothing) Then
                Return Nothing
            End If
            obSessionB2K = obSystem.Sessions.Open(clsB2K.SESSAO)
            If obSessionB2K Is Nothing Then
                Return Nothing
            End If
            obSessionB2K.Visible = True
            telaB2K = obSessionB2K.Screen
            '***********************************************************
            'Caso tenha tido problema na abertura da sessão
            If telaB2K Is Nothing Then
                obSystem.quit()
                Return Nothing
            End If

            With telaB2K
                .WaitHostQuiet(3000)
                'Validar se o sistema já esta logado/aberto
                If Trim(.GetString(10, 14, 32)) <> "Departamentos e Empresas Ligadas" Then
                    LogoffSystemB2K(telaB2K)
                End If

                .PutString("CNQBCO00", 20, 1)
                .SendKeys("<Enter>")
                .WaitHostQuiet(800)
                'Emulando Pause Break
                .SendKeys("<Clear>")
                .WaitHostQuiet(500)
                .SendKeys("<Clear>")
                .WaitHostQuiet(500)
                .PutString("CESN", 5, 5)
                .SendKeys("<Enter>")
                .WaitHostQuiet(800)
                'Login
                .PutString(clsB2K.USUARIO, 10, 26, 7)
                .PutString(clsB2K.SENHA, 11, 26)
                .WaitHostQuiet(500)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)
            End With
            Return telaB2K
        Catch ex As Exception
            Return telaB2K
        End Try

    End Function

    Public Sub LogoffSystemB2K(ByVal obj As Object)
        Try
            With obj
                'Emulando Pause Break
                .SendKeys("<Clear>")
                .WaitHostQuiet(1000)
                .SendKeys("<Clear>")
                .WaitHostQuiet(1000)
                .SendKeys("<Clear>")
                .WaitHostQuiet(1000)
                .PutString("cesf logoff", 5, 5)
                .WaitHostQuiet(1000)
                .SendKeys("<Enter>")
                .WaitHostQuiet(1000)
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, TITULO_ALERTA)
        End Try
    End Sub

    Public Function B2K_DesbloqueiaCartao(tela As Object, cartao As String) As Boolean
        Try
            Dim cartaoBin As String = Microsoft.VisualBasic.Left(cartao, 6)
            Dim cartaoFim As String = RN_capturaFinalCartao(cartao)
            Dim msgErro As String = ""
            Dim obSystem As Object
            obSystem = CreateObject("EXTRA.System")
            If tela Is Nothing Then
                obSystem.quit()
                Return False
            End If
            With tela
                .WaitHostQuiet(1000)
                .PutString("UA", 1, 7)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)
                .PutString(cartaoBin.ToString, 2, 17)
                .PutString(cartaoFim.ToString, 2, 24)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)
                .SendKeys("<PF7>")
                msgErro = Trim(.GetString(23, 2, 79))

                'volta para tela inicial
                .SendKeys("<Clear>")
                .WaitHostQuiet(500)
                .SendKeys("<Clear>")
                .WaitHostQuiet(500)
                .SendKeys("<Clear>")
            End With
            'obSystem.quit
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function B2K_RegistraMemo(tela As Object, cartao As String, memo As Memo, ByVal Optional file As String = "", Optional task As String = "PR058") As Boolean
        Try
            Dim cartaoBin As String = Microsoft.VisualBasic.Left(cartao, 6)
            Dim cartaoFim As String = RN_capturaFinalCartao(cartao)
            Dim msgErro As String = ""
            Dim obSystem As Object
            obSystem = CreateObject("EXTRA.System")
            If tela Is Nothing Then
                obSystem.quit()
                Return False
            End If
            With tela
                .WaitHostQuiet(500)
                .PutString("SV", 1, 7)
                .SendKeys("<Enter>")
                .WaitHostQuiet(250)
                .PutString(cartaoBin.ToString, 2, 17)
                .PutString(cartaoFim.ToString, 2, 24)
                .SendKeys("<Enter>")
                .WaitHostQuiet(250)
                .PutString(file.ToString, 18, 5)
                .PutString(task.ToString, 18, 13)

                'adiciona as 4 linhas do memo
                If memo IsNot Nothing Then
                    For i = 0 To (memo.memo.Count - 1)
                        .PutString(memo.memo(i).linha1.ToString, 18, 19)
                        .PutString(memo.memo(i).linha2.ToString, 19, 19)
                        .PutString(memo.memo(i).linha3.ToString, 20, 29)
                        .PutString(memo.memo(i).linha4.ToString, 21, 19)
                    Next
                End If
                .SendKeys("<Enter>")
                .WaitHostQuiet(300)
                'msgErro = Trim(.GetString(22, 2, 79))

                'volta para tela inicial
                .SendKeys("<Clear>")
                .WaitHostQuiet(100)
                .SendKeys("<Clear>")
                .WaitHostQuiet(100)
                .SendKeys("<Clear>")
            End With
            'obSystem.quit
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function B2K_BloqueiaCartao(tela As Object, cartao As String) As Boolean
        Try
            Dim cartaoBin As String = Microsoft.VisualBasic.Left(cartao, 6)
            Dim cartaoFim As String = RN_capturaFinalCartao(cartao)
            Dim msgErro As String = ""
            Dim obSystem As Object
            obSystem = CreateObject("EXTRA.System")
            If tela Is Nothing Then
                obSystem.quit()
                Return False
            End If
            With tela
                .WaitHostQuiet(1000)
                .PutString("UA", 1, 7)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)
                .PutString(cartaoBin.ToString, 2, 17)
                .PutString(cartaoFim.ToString, 2, 24)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)

                .PutString("X", 12, 18)
                .PutString("S", 12, 20)
                .PutString("999", 17, 16)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)

                msgErro = Trim(.GetString(23, 2, 79))

                'volta para tela inicial
                .SendKeys("<Clear>")
                .WaitHostQuiet(500)
                .SendKeys("<Clear>")
                .WaitHostQuiet(500)
                .SendKeys("<Clear>")
            End With
            'obSystem.quit
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Public Function B2K_IncluirOKChip(tela As Object, cartao As String, bandeira As String) As Boolean
    '    Try
    '        Dim POS_OKCHIP() As String = RN_getArrayPOS_OKCHIP(bandeira) 'CAPTURA O POS PARA EXCEÇÃO
    '        Dim codResp As String = RN_getCOD_RESP(bandeira) 'CAPTURA O COD RESP POR BANDEIRA
    '        Dim msgErro As String = ""
    '        Dim periodo As Integer = 90 'dias
    '        Dim cartaoBin As String = Microsoft.VisualBasic.Left(cartao, 6)
    '        Dim cartaoFim As String = RN_capturaFinalCartao(cartao)
    '        Dim dataINICIAL As Date = Today
    '        Dim dataFINAL As Date = Today.AddDays(periodo)
    '        Dim Idia As String = dataINICIAL.ToString("dd")
    '        Dim Imes As String = dataINICIAL.ToString("MM")
    '        Dim Iano As String = dataINICIAL.ToString("yyyy")
    '        Dim Fdia As String = dataFINAL.ToString("dd")
    '        Dim Fmes As String = dataFINAL.ToString("MM")
    '        Dim Fano As String = dataFINAL.ToString("yyyy")
    '        Dim retorno As Boolean = False
    '        Dim sucessoOKChip As Boolean = False
    '        'limite de 8 POS para o OK CHIP
    '        Dim CODIGODEEXECECAO() As String = {"", "", "", "", "", "", "", ""}

    '        'CONFIGURA O CODIGO DE EXECEÇÃO NAO SUAS POSIÇOES CORRETAS
    '        For i = 0 To UBound(POS_OKCHIP)
    '            If POS_OKCHIP(i) IsNot Nothing Then
    '                CODIGODEEXECECAO(i) = POS_OKCHIP(i).ToString
    '            End If
    '        Next

    '        Dim obSystem As Object
    '        obSystem = CreateObject("EXTRA.System")
    '        If tela Is Nothing Then
    '            obSystem.quit()
    '            Return False
    '        End If

    '        With tela
    '            .WaitHostQuiet(1000)
    '            .PutString("ACCI", 1, 7)
    '            .SendKeys("<Enter>")
    '            .WaitHostQuiet(500)
    '            .PutString(cartaoBin.ToString, 2, 24)
    '            .PutString(cartaoFim.ToString, 2, 31)
    '            .SendKeys("<Enter>")
    '            .WaitHostQuiet(500)

    '            .PutString("XS", 2, 55)
    '            .PutString(Idia, 3, 25)
    '            .PutString(Imes, 3, 30)
    '            .PutString(Iano, 3, 35)
    '            .PutString(Fdia, 3, 45)
    '            .PutString(Fmes, 3, 50)
    '            .PutString(Fano, 3, 55)

    '            'Preenchendo os codigos de exceção
    '            .PutString(CODIGODEEXECECAO(0).ToString, 20, 14)
    '            .PutString(CODIGODEEXECECAO(1).ToString, 20, 18)
    '            .PutString(CODIGODEEXECECAO(2).ToString, 20, 22)
    '            .PutString(CODIGODEEXECECAO(3).ToString, 20, 26)
    '            .PutString(CODIGODEEXECECAO(4).ToString, 20, 30)
    '            .PutString(CODIGODEEXECECAO(5).ToString, 20, 34)
    '            .PutString(CODIGODEEXECECAO(6).ToString, 20, 38)
    '            .PutString(CODIGODEEXECECAO(7).ToString, 20, 42)

    '            .PutString("I", 20, 60)
    '            .PutString(codResp.ToString, 20, 65)

    '            .PutString("00", 20, 71)
    '            .PutString("950", 20, 77)
    '            .SendKeys("<PF1>")
    '            .WaitHostQuiet(500)

    '            msgErro = Trim(.GetString(23, 2, 79))

    '            'volta para tela inicial
    '            .SendKeys("<Clear>")
    '            .WaitHostQuiet(500)
    '            .SendKeys("<Clear>")
    '            .WaitHostQuiet(500)
    '            .SendKeys("<Clear>")
    '        End With
    '        'obSystem.quit
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    Public Function B2K_RemoverOKChip(tela As Object, cartao As String, bandeira As String) As Boolean
        Try
            Dim msgErro As String = ""
            Dim periodo As Integer = 90 'dias
            Dim cartaoBin As String = Microsoft.VisualBasic.Left(cartao, 6)
            Dim cartaoFim As String = RN_capturaFinalCartao(cartao)
            Dim dataINICIAL As Date = Today
            Dim dataFINAL As Date = Today.AddDays(periodo)
            Dim Idia As String = dataINICIAL.ToString("dd")
            Dim Imes As String = dataINICIAL.ToString("MM")
            Dim Iano As String = dataINICIAL.ToString("yyyy")
            Dim Fdia As String = dataFINAL.ToString("dd")
            Dim Fmes As String = dataFINAL.ToString("MM")
            Dim Fano As String = dataFINAL.ToString("yyyy")
            Dim retorno As Boolean = False
            Dim sucessoOKChip As Boolean = False

            Dim obSystem As Object
            obSystem = CreateObject("EXTRA.System")
            If tela Is Nothing Then
                obSystem.quit()
                Return False
            End If

            With tela
                .WaitHostQuiet(1000)
                .PutString("ACCI", 1, 7)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)
                .PutString(cartaoBin.ToString, 2, 24)
                .PutString(cartaoFim.ToString, 2, 31)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)
                .SendKeys("<PF3>")
                .WaitHostQuiet(500)
                .PutString(Idia, 3, 25)
                .PutString(Imes, 3, 30)
                .PutString(Iano, 3, 35)
                .PutString(Fdia, 3, 45)
                .PutString(Fmes, 3, 50)
                .PutString(Fano, 3, 55)
                .WaitHostQuiet(500)
                .SendKeys("<PF3>")
                .WaitHostQuiet(500)
                msgErro = Trim(.GetString(23, 2, 79))

                'volta para tela inicial
                .SendKeys("<Clear>")
                .WaitHostQuiet(500)
                .SendKeys("<Clear>")
                .WaitHostQuiet(500)
                .SendKeys("<Clear>")
            End With
            'obSystem.quit
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function B2K_IncluirByPass(tela As Object, cartao As String, Optional strQdias As String = "2") As Boolean
        Try

            Dim cartaoBin As String = RN_formataCartao19Posicoes(cartao.ToString)
            Dim msgErro As String = ""
            Dim dt_hora As DateTime = Now()

            Dim todasRegras As String = "N"
            Dim RegrasCase As String = "N"
            Dim RegrasAutorizador As String = "S"
            Dim QtdDias As String = Microsoft.VisualBasic.Right("000" & strQdias, 3)
            Dim aPartirDeData As String = dt_hora.ToString("ddMMyyyy") '09012018 yyyy-MM-dd HH:mm:ss
            Dim aPartirDeHora As String = dt_hora.ToString("HHmmss") '1544

            '@TODASREGRAS
            '@REGRACASE
            '@REGRAS_AUTORIZADORAS
            '@QUANT_DIAS
            '@A_PARTIR_DE_DATA
            '@A_PARTIR_DE_HORA

            Dim obSystem As Object
            obSystem = CreateObject("EXTRA.System")
            If tela Is Nothing Then
                obSystem.quit()
                Return False
            End If

            With tela
                .WaitHostQuiet(1000)
                .PutString("SRHA", 1, 1)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)
                .PutString(cartaoBin.ToString, 5, 19)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)

                .PutString(todasRegras, 11, 28)
                .PutString(RegrasCase, 12, 28)
                .PutString(RegrasAutorizador, 13, 28)
                .PutString(QtdDias, 21, 20)
                .PutString(aPartirDeData, 21, 51)
                .PutString(aPartirDeHora, 21, 73)
                .WaitHostQuiet(500)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)
                msgErro = Trim(.GetString(24, 3, 76))

                'volta para tela inicial
                .SendKeys("<Clear>")
                .WaitHostQuiet(700)
                .SendKeys("<Clear>")
                .WaitHostQuiet(500)
                .SendKeys("<Clear>")
                .WaitHostQuiet(500)

                If msgErro Like "*CARTAO INVALIDO*" Then
                    Return False
                End If

            End With
            'obSystem.quit
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function B2K_CancelarCartao(tela As Object, cartao As String) As Boolean
        Try
            Dim cartaoBin As String = Microsoft.VisualBasic.Left(cartao, 6)
            Dim cartaoFim As String = RN_capturaFinalCartao(cartao)
            Dim msgErro As String = ""
            Dim obSystem As Object
            Dim dataINICIAL As Date = Today
            Dim Idia As String = dataINICIAL.ToString("dd")
            Dim Imes As String = dataINICIAL.ToString("MM")
            Dim Iano As String = dataINICIAL.ToString("yy")
            obSystem = CreateObject("EXTRA.System")
            If tela Is Nothing Then
                obSystem.quit()
                Return False
            End If
            With tela
                .WaitHostQuiet(1000)
                .PutString("LM", 1, 7)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)
                .PutString(cartaoBin.ToString, 2, 17)
                .PutString(cartaoFim.ToString, 2, 24)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)

                .PutString("S", 4, 23)
                .PutString("F", 4, 27)
                .PutString("F", 5, 23)
                .PutString(Idia & Imes & Iano, 6, 23)
                .PutString("331", 9, 7)
                .SendKeys("<Enter>")
                .WaitHostQuiet(500)

                msgErro = Trim(.GetString(23, 2, 79))

                'volta para tela inicial
                .SendKeys("<Clear>")
                .WaitHostQuiet(500)
                .SendKeys("<Clear>")
                .WaitHostQuiet(500)
                .SendKeys("<Clear>")
            End With
            'obSystem.quit
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function B2K_BuscaCartoesPorCpf(mainFrame As Object, tela As Object, numCpf As String, cartoesAtivos As Boolean, Optional ByRef status_execucao As Boolean = True, Optional ByRef msgErro As String = "") As List(Of String)
        Try

REINICIAR:
            Dim obSystem As Object
            Dim cards = New List(Of String)
            Dim contador As Integer = 0

            obSystem = CreateObject("EXTRA.System")
            If tela Is Nothing Then
                obSystem.quit()
                status_execucao = False
                Return Nothing
            End If

            With tela
                Do While Not .getString(1, 26, 18).ToString.Trim = "CUSTOMER SEARCH" And contador < 3 'Navegando para a tela de captura
                    .putstring("A", 1, 7)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(100)
                    contador += 1

                    If contador > 2 Then
                        .SendKeys("<Clear>")
                        .WaitHostQuiet(500)
                        .SendKeys("<Clear>")
                        .WaitHostQuiet(500)
                    End If

                Loop

                'Reconectando o MainFrame
                If Not .getString(1, 23, 26).ToString.Trim = "CUSTOMER SEARCH" Then
                    LogoffSystemB2K(tela)
                    Login_CNPBCOT1(mainFrame)
                    'paginando para tela principal da função
                    .putstring("A", 1, 7)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(50)
                End If

                'Validando se o acesso foi concluído com sucesso
                If Not .getString(1, 26, 18).ToString.Trim = "CUSTOMER SEARCH" Then
                    status_execucao = False
                    Return Nothing
                Else
                    contador = 0
                End If

                'Rodando todos os registros da TELA e paginando caso necessário
                Dim linha As Integer = 4 'Inicia na linha 4 e o máximo é a linha 21
                Dim fim As Boolean = False 'Validar se a qtde de cartões pelo CPF digitado já chegou ao fim
                Dim cartao As String = ""
                Dim nome As String = ""
                Dim endereco As String = ""
                Dim numResidencia As String = ""
                Dim cidade As String = ""
                Dim estado As String = ""
                Dim cep As String = ""
                Dim bloqueio As String = ""
                Dim tipoCartao As String = ""

                'Configurando o tamanho do CPF
                If numCpf.Length < 11 Then
                    For i As Integer = numCpf.Length To 10 'CPF são 11 dígitos, mas devido a funcionalidade do FOR é válidado com 10 dígitos
                        numCpf = numCpf.Insert(0, "0")
                    Next
                End If
                'Inserindo o CPF
                .PutString(numCpf, 3, 67, 12)
                'Incluíndo cartões INATIVOS na captura
                If Not cartoesAtivos Then
                    .PutString("N", 3, 33, 1)
                Else
                    .PutString("S", 3, 33, 1)
                End If

                .sendKeys("<Enter>")
                .WaitHostQuiet(50)

                While linha < 22 And Not fim

                    cartao = .getstring(linha, 55, 19)
                    cartao = cartao.Substring(2, cartao.Length - 2).Trim
                    nome = .getstring(linha, 5, 40).trim
                    endereco = .getstring(linha + 1, 5, 35).trim
                    numResidencia = .getstring(linha + 1, 41, 7).trim
                    bloqueio = .getstring(linha + 1, 77, 4).trim
                    cidade = .getstring(linha + 2, 10, 25).trim
                    estado = .getstring(linha + 2, 39, 2).trim
                    cep = .getstring(linha + 2, 46, 10).trim
                    tipoCartao = .getstring(linha + 2, 70, 11).trim

                    fim = cartao.Contains("*") Or cartao.Trim().Length = 0 'Gerando resposta boolean POSITIVA caso encontre * ou esteja vazio
                    linha += 3 'Saltando para a próxima linha válida para captura de cartão

                    'Salvando na lista o cartão capturado, desde que seja válido
                    If Not fim Then
                        cards.Add(cartao & ";" & nome & ";" & endereco & ";" & numResidencia & ";" & cidade & ";" & estado & ";" & cep & ";" & tipoCartao & ";" & bloqueio)
                    Else
                        Exit While
                    End If

                    'Validando se precisa paginar a tela preta
                    If linha > 21 Then
                        linha = 4
                        .sendkeys("<PF8>")
                        .WaitHostQuiet(50)
                    End If
                    'Validando se a paginação não trouxe mais nenhuma resultado
                    If .GetString(22, 2, 15).ToString().Equals("FIM DE PESQUISA") Then
                        Exit While
                    End If

                End While
            End With

            status_execucao = True
            qtdeTentativas = 0
            Return cards

        Catch ex As Exception
            If qtdeTentativas > 3 Then
                status_execucao = False
                msgErro = ex.Message & " - " & numCpf
                Return Nothing
            Else
                qtdeTentativas += 1
                GoTo REINICIAR
                Throw New Exception
            End If
        End Try
    End Function

    Public Function B2K_CapturarDadosCadastrais(mainFrame As Object, tela As Object, numCartao As String, Optional ByRef status_execucao As Boolean = True, Optional ByRef msgErro As String = "") As dadosCadastrais_DTO

        Try

REINICIAR:

            Dim obSystem As Object
            Dim dadosCadastrais As New dadosCadastrais_DTO
            Dim contador As Integer = 0
            Dim dados As String 'Para trabalhar dados de tela
            Dim linha As Integer = 0

            obSystem = CreateObject("EXTRA.System")
            If tela Is Nothing Then
                obSystem.quit()
                status_execucao = False
                Return Nothing
            End If

            With tela
                Do While Not .getString(1, 23, 26).ToString.Trim = "ACCOUNT INQUIRY ( PAGE 4 )" And contador < 3 'Navegando para a tela de captura
                    .putstring("I4", 1, 7)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(25)
                    contador += 1
                Loop

                'Reconectando o MainFrame
                If Not .getString(1, 23, 26).ToString.Trim = "ACCOUNT INQUIRY ( PAGE 4 )" Then
                    LogoffSystemB2K(tela)
                    Login_CNPBCOT1(mainFrame)
                    'paginando para tela principal da função
                    .putstring("I4", 1, 7)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(25)
                End If

                'Validando se o acesso foi concluído com sucesso
                If Not .getString(1, 23, 26).ToString.Trim = "ACCOUNT INQUIRY ( PAGE 4 )" Then
                    status_execucao = False
                    Return Nothing
                Else
                    'Limpando o cartão anterior
                    .putstring("                   ", 2, 16)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(25)

                    'Inserindo novo cartão
                    numCartao = numCartao.Insert(6, " ")
                    .putstring(numCartao, 2, 17)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(25)
                    contador = 0
                End If
            End With

            If tela.getString(23, 2, 50).ToString.Trim = "" Then
                With dadosCadastrais

                    'Alterações Realizadas no cadastro
                    dados = tela.GetString(3, 44, 10).trim
                    .data_alteracao_End = hlp.FormataDataAbreviada(IIf(dados = "0/ 0/ 0", "1/1/1900", dados))
                    dados = tela.GetString(3, 71, 10).trim
                    .data_alteracao_telefones = hlp.FormataDataAbreviada(IIf(dados = "0/ 0/ 0", "1/1/1900", dados))

                    'Nome Portador e Data de Nascimento
                    linha = 6
                    dados = tela.GetString(linha, 63, 2).trim & "/" & tela.GetString(linha, 65, 2).trim & "/" & tela.GetString(linha, 67, 4).trim
                    Do While dados = "//" 'Tem situações que o cadastro não está na primeira linha NM1
                        linha += 1
                        dados = tela.GetString(linha, 63, 2).trim & "/" & tela.GetString(linha, 65, 2).trim & "/" & tela.GetString(linha, 67, 4).trim
                    Loop
                    .data_Nascimento = hlp.FormataDataAbreviada(IIf(dados = "0/ 0/ 0" Or dados = "" Or IsDate(dados) = False, "1/1/1900", dados))
                    .nome = tela.GetString(linha, 7, 41).trim
                    .sexo = tela.GetString(linha, 73, 2).trim

                    'Nomes de familiares (Pai.. Mãe..)
                    .nome_2 = tela.GetString(7, 7, 41).trim
                    .nome_3 = tela.GetString(8, 7, 41).trim
                    .nome_4 = tela.GetString(9, 7, 41).trim

                    'Telefones
                    .tel_residencial = Replace(tela.GetString(10, 10, 18), " ", "")
                    .tel_empresa = Replace(tela.GetString(10, 35, 18), " ", "")
                    .tel_celular = Replace(tela.GetString(10, 61, 18), " ", "")

                    'Endereco de cobranca
                    .end_cobranca = tela.GetString(12, 8, 47).trim & " " & tela.GetString(12, 61, 19).trim & " " & tela.GetString(13, 8, 31).Trim
                    .cidade_cobranca = tela.GetString(13, 44, 36).trim
                    .estado_cobranca = tela.GetString(14, 43, 3).trim
                    .cep_cobranca = tela.GetString(14, 47, 12).trim

                    'Endereco de anterior
                    .end_anterior = tela.GetString(16, 8, 47).trim & " " & tela.GetString(16, 61, 19).trim & " " & tela.GetString(17, 8, 31).Trim
                    .cidade_anterior = tela.GetString(17, 44, 36).trim
                    .estado_anterior = tela.GetString(18, 43, 3).trim
                    .cep_anterior = tela.GetString(18, 47, 12).trim

                    'Endereco de correspondencia
                    .end_correspondencia = tela.GetString(20, 8, 47).trim & " " & tela.GetString(20, 61, 19).trim & " " & tela.GetString(21, 8, 31).Trim
                    .cidade_correspondencia = tela.GetString(21, 44, 36).trim
                    .estado_correspondencia = tela.GetString(22, 43, 3).trim
                    .cep_correspondencia = tela.GetString(22, 47, 12).trim

                    'Produto que é o cartão.. PLATINUM, GOLD, GREEN, BLACK, INFINITE... mas trata-se do código
                    .produto = tela.GetString(2, 61, 12).trim
                End With

                status_execucao = True
                Return dadosCadastrais

            End If

            status_execucao = True
            qtdeTentativas = 0
            Return Nothing

        Catch ex As Exception
            If qtdeTentativas > 3 Then
                status_execucao = False
                msgErro = ex.Message & " - " & numCartao
                Return Nothing
            Else
                qtdeTentativas += 1
                GoTo REINICIAR
                Throw New Exception
            End If
        End Try
    End Function

    Public Function B2K_CapturarDadosCartaoConta(mainframe As Object, tela As Object, numCartao As String, tipoCartao As String, Optional ByRef status_execucao As Boolean = True, Optional ByRef msgErro As String = "") As cartoes_DTO

        Try

REINICIAR:

            Dim obSystem As Object
            Dim dadosCartaoConta As New cartoes_DTO
            Dim contador As Integer = 0
            Dim dados As String 'Para trabalhar dados de tela

            obSystem = CreateObject("EXTRA.System")
            If tela Is Nothing Then
                obSystem.quit()
                status_execucao = False
                Return Nothing
            End If


            With tela
                Do While Not .getString(1, 23, 26).ToString.Trim = "ACCOUNT INQUIRY ( PAGE 5 )" And contador < 3 'Navegando para a tela de captura
                    .putstring("I5", 1, 7)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(25)
                    contador += 1
                Loop

                'Reconectando o MainFrame
                If Not .getString(1, 23, 26).ToString.Trim = "ACCOUNT INQUIRY ( PAGE 5 )" Then
                    LogoffSystemB2K(tela)
                    Login_CNPBCOT1(mainframe)
                    'paginando para tela principal da função
                    .putstring("I5", 1, 7)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(25)
                End If


                'Validando se o acesso foi concluído com sucesso
                If Not .getString(1, 23, 26).ToString.Trim = "ACCOUNT INQUIRY ( PAGE 5 )" Then
                    status_execucao = False
                    Return Nothing
                Else
                    'Limpando o cartão anterior
                    .putstring("                   ", 2, 16)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(25)

                    'Inserindo novo cartão
                    numCartao = numCartao.Insert(6, " ")
                    .putstring(numCartao, 2, 16)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(25)
                    contador = 0
                End If
            End With

            If Not tela.getString(23, 2, 50).ToString.Trim = "" Then
                status_execucao = True
                Return Nothing
            End If

            'Existe informações que estão presentes apenas no PLASTICO (Cartão) e outras apenas na CONTA
            'Por isso determinar qual "tipo de cartao" para saber quais dados capturar
            If Trim(tipoCartao.ToUpper) = "CONTA" Then

                With dadosCartaoConta

                    'Alterações Realizadas no Limite de Crédito
                    .limite_Data_Alteracao = hlp.FormataDataAbreviada(IIf(tela.GetString(19, 70, 10).trim = "00/00/00", "01/01/1900", tela.GetString(19, 70, 10).trim))
                    .limite_Credito_Anterior = hlp.transformarMoeda(tela.GetString(18, 65, 15).trim) 'Na tela I5 captura o limite MAJORADO, depois subtrai este valor do limite de credito
                    .limite_Fonte_Alteracao = tela.GetString(20, 70, 10).trim

                    'Dados capturados na TELA I1
                    Do While (Not tela.getString(1, 12, 7).ToString.Trim = "BCP06M" Or Not tela.getString(1, 23, 26).ToString.Trim = "ACCOUNT INQUIRY ( PAGE 1 )") And contador < 3 'Navegando para a tela de captura
                        tela.putstring("I1", 1, 7)
                        tela.sendKeys("<Enter>")
                        tela.WaitHostQuiet(50)
                        contador += 1
                    Loop
                    'Confirmando se está na TELA i1
                    If tela.getString(1, 12, 7).ToString.Trim = "BCP06M" Or tela.getString(1, 23, 26).ToString.Trim = "ACCOUNT INQUIRY ( PAGE 1 )" Then

                        'Limite
                        .limite_Credito = hlp.transformarMoeda(tela.GetString(20, 17, 12).trim)
                        .limite_Credito_Disponivel = hlp.transformarMoeda(tela.GetString(20, 48, 12).trim)
                        'Calculando limite de crédito anterior
                        dados = .limite_Credito - .limite_Credito_Anterior
                        .limite_Credito_Anterior = hlp.transformarMoeda(dados)
                        'Saque
                        .limite_Saque = hlp.transformarMoeda(tela.GetString(21, 17, 12).trim)
                        .limite_Saque_Disponivel = hlp.transformarMoeda(tela.GetString(21, 48, 12).trim)
                        'Data Abertura da Conta
                        .data_Abertura_Conta = hlp.FormataDataAbreviada(IIf(tela.GetString(5, 11, 9).trim = "00/00/00", "01/01/1900", tela.GetString(5, 11, 9).trim))
                        .data_Desbloqueio = hlp.FormataDataAbreviada(IIf(tela.GetString(5, 27, 9).trim = "00/00/00", "01/01/1900", tela.GetString(5, 27, 9).trim))
                    End If

                End With

                status_execucao = True
                Return dadosCartaoConta
            End If 'fim do processo caso seja CONTA

            'Captura de informaçõs de cartões de tipo <> de CONTA

            'Dados capturados na TELA I1
            Do While (Not tela.getString(1, 12, 7).ToString.Trim = "BCP08M" Or Not tela.getString(1, 23, 26).ToString.Trim = "ACCOUNT INQUIRY ( PAGE 3 )") And contador < 3 'Navegando para a tela de captura
                tela.putstring("I3", 1, 7)
                tela.sendKeys("<Enter>")
                tela.WaitHostQuiet(100)
                contador += 1
            Loop
            'Confirmando se está na TELA i1
            If tela.getString(1, 12, 7).ToString.Trim = "BCP08M" Or tela.getString(1, 23, 26).ToString.Trim = "ACCOUNT INQUIRY ( PAGE 3 )" Then
                With dadosCartaoConta
                    'Data de Emissão do Cartão
                    .data_Emissao = hlp.FormataDataAbreviada(IIf(tela.GetString(15, 34, 9).trim = "00/00/00", "01/01/1900", tela.GetString(15, 34, 9).trim))
                End With
            End If

            status_execucao = True
            qtdeTentativas = 0
            Return dadosCartaoConta

        Catch ex As Exception
            If qtdeTentativas > 3 Then
                status_execucao = False
                msgErro = ex.Message & " - " & numCartao
                'MsgBox(ex.Message)
                Return Nothing
            Else
                qtdeTentativas += 1
                GoTo REINICIAR
                Throw New Exception
            End If
        End Try
    End Function

    Public Function B2K_CapturarManutencoes(mainframe As Object, tela As Object, cpf As String, numCartao As String, dataLimite As Date, Optional ByRef status_execucao As Boolean = True, Optional ByRef msgErro As String = "") As List(Of manutencoes_DTO)

        Try


REINICIAR:
            Dim obSystem As Object
            Dim contador As Integer = 0, linha As Integer = 0
            Dim dados As String = ""
            Dim nomeTela(1) As String
            Dim historicoLog = New List(Of manutencoes_DTO)

            obSystem = CreateObject("EXTRA.System")
            If tela Is Nothing Then
                obSystem.quit()
                status_execucao = False
                Return Nothing
            End If

            nomeTela(0) = "SERVICE WORK SCREEN"
            nomeTela(1) = "SERVICE WORK SCREEN - RIGHT"

entrando_na_tela:
            With tela
                'Validando se a tela travou e voltando para a principal
                If .GetString(22, 2, 34).trim() = "NO ACTION TAKEN" Then
                    .putstring("I", 1, 7)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(50)
                End If

                Do While Not .getString(1, 21, 30).ToString.Trim = nomeTela(0) And contador < 3 'Navegando para a tela de captura

                    If .getString(1, 21, 30).ToString.Trim = nomeTela(1) Then 'SV + F5
                        .sendKeys("<PF5>") 'Voltando para a tela "SERVICE WORK SCREEN"
                        .WaitHostQuiet(50)
                    Else
                        .putstring("SV", 1, 7) 'Navegando para a tela de MEMO, caso esteja em outra tela
                        .sendKeys("<Enter>")
                        .WaitHostQuiet(50)
                    End If
                    contador += 1
                Loop

                'Reconectando o MainFrame
                If Not .getString(1, 23, 26).ToString.Trim = nomeTela(0) Then
                    LogoffSystemB2K(tela)
                    Login_CNPBCOT1(mainframe)
                    'paginando para tela principal da função
                    If .getString(1, 21, 30).ToString.Trim = nomeTela(1) Then 'SV + F5
                        .sendKeys("<PF5>") 'Voltando para a tela "SERVICE WORK SCREEN"
                        .WaitHostQuiet(50)
                    Else
                        .putstring("SV", 1, 7) 'Navegando para a tela de MEMO, caso esteja em outra tela
                        .sendKeys("<Enter>")
                        .WaitHostQuiet(50)
                    End If
                End If

                'Validando se o acesso foi concluído com sucesso
                If Not .getString(1, 21, 30).ToString.Trim = nomeTela(0) Then
                    status_execucao = False
                    Return Nothing
                Else

                    'Limpando o cartão anterior
                    .putstring("                   ", 2, 17)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(50)

                    'Inserindo novo cartão
                    numCartao = numCartao.Insert(6, " ")
                    .putstring(numCartao, 2, 17)
                    'Ordena por data mais recente
                    .PutString("Y", 2, 80, 1)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(50)
                    contador = 0
                End If

                If .GetString(22, 2, 34).trim() = "NO ACTION TAKEN" Then
                    GoTo entrando_na_tela
                End If

            End With

            Select Case tela.getString(22, 2, 50).ToString.Trim
                Case "CHECK DIGIT IS INVALID", "ACCOUNT NUM NOT FOUND"
                    status_execucao = True
                    Return Nothing
            End Select


            linha = 7
            While linha < 18 'Até a linha 18 visto que existe a área de input de MEMO que fica statica na tela
                Dim manutencoes As New manutencoes_DTO
                Dim descTask = String.Empty
                Dim saltoLinha As Integer = 1

                'Navegando para a tela "SERVICE WORK SCREEN - RIGHT"
                contador = 0
                Do While Not tela.getString(1, 21, 30).ToString.Trim = nomeTela(0) And contador < 2 'Navegando para a tela "SERVICE WORK SCREEN"
                    tela.sendKeys("<PF5>")
                    tela.WaitHostQuiet(50)
                    contador += 1
                Loop
                If Not tela.getString(1, 21, 30).ToString.Trim = nomeTela(0) Then
                    Return Nothing
                End If

                With manutencoes 'Capturando e alimentando objeto
                    Dim endRecord = tela.GetString(22, 2, 34).trim()
                    .task = tela.GetString(linha, 13, 5).Trim()

                    If Not String.IsNullOrEmpty(.task) Then 'Validando se a linha é capturável, possue info ou é complemento de memo

                        .dataManutencao = Trim(tela.GetString(linha, 70, 6)).Insert(2, "/").Insert(5, "/")
                        If Not dataLimite < .dataManutencao Then
                            Exit While 'A data limite informa até qdo se deve capturar os MEMOs
                        End If


                        .cartao = Replace(numCartao, " ", "")
                        .bin = Left(.cartao, 6)
                        .cpf = cpf
                        .horaManutencao = Trim(tela.GetString(linha, 77, 4)).Insert(2, ":") + ":00"
                        'Montando o MEMO
                        dados = Trim(tela.GetString(linha, 19, 50))
                        'validando se a o MEMO continua na próxima linha
                        Do While tela.GetString(linha + saltoLinha, 13, 5).ToString.Trim = ""
                            dados += Trim(tela.GetString(linha + saltoLinha, 19, 50)).Insert(0, " ")
                            saltoLinha += 1
                        Loop
                        .descricaoManutencao = Replace(dados, "  ", " ")

                        'Navegando para a tela "SERVICE WORK SCREEN - RIGHT"
                        contador = 0
                        Do While Not tela.getString(1, 21, 30).ToString.Trim = nomeTela(1) And contador < 3 'Navegando para a tela de captura
                            tela.sendKeys("<PF5>")
                            tela.WaitHostQuiet(50)
                            contador += 1
                        Loop
                        If tela.getString(1, 21, 30).ToString.Trim = nomeTela(1) Then
                            'Capturando informações referente ao analista que realizou a manutenção e departamento
                            .usuarioRealizouManutencao = tela.getString(linha, 67, 8).Trim
                            .departamentoManutencao = tela.getString(linha, 76, 5).Trim
                        End If

                        'Inserindo na lista de histórico de manutenções
                        historicoLog.Add(manutencoes)
                    End If

                    If String.IsNullOrEmpty(.task) And (endRecord.Equals("NO MORE DATA FOR FORWARD SCROLLING") Or endRecord.TrimEnd().Equals("NO ENTRIES TO BE DISPLAYED")) Then
                        Exit While
                    End If

                    'Paginando caso tenha mais informações para acessar
                    If linha > 16 Then
                        'captura de tela para comparação
                        Dim capturaTela As String = tela.getString(3, 1, 1680).ToString.Trim

                        If endRecord.Equals("NO MORE DATA FOR FORWARD SCROLLING") Or endRecord.TrimEnd().Equals("NO ENTRIES TO BE DISPLAYED") Then
                            Exit While
                        End If
                        linha = 7
                        tela.sendKeys("<PF8>")
                        tela.WaitHostQuiet(50)

                        'COMPARAR TEXTO DA TELA E SE IDENTICO SAIR DO WHILE
                        If capturaTela = tela.getString(3, 1, 1680).ToString.Trim Then
                            Exit While
                        End If

                    Else
                        linha += 1
                    End If
                End With
            End While

            status_execucao = True
            qtdeTentativas = 0
            Return historicoLog

        Catch ex As Exception

            If qtdeTentativas > 3 Then
                status_execucao = False
                msgErro = ex.Message & " - " & numCartao
                Return Nothing
            Else
                qtdeTentativas += 1
                GoTo REINICIAR
                Throw New Exception
            End If

        End Try
    End Function

    Public Function B2K_CapturarFaturas(mainframe As Object, tela As Object, cpf As String, numCartao As String, dataLimite As Date, Optional ByRef status_execucao As Boolean = True, Optional ByRef msgErro As String = "") As List(Of fatura_DTO)

        Try

REINICIAR:
            Dim obSystem As Object
            Dim contador As Integer = 0, linha As Integer = 0
            Dim dados As String = ""
            Dim nomeTela(1) As String
            Dim historicoFaturas = New List(Of fatura_DTO)

            obSystem = CreateObject("EXTRA.System")
            If tela Is Nothing Then
                obSystem.quit()
                status_execucao = False
                Return Nothing
            End If

            nomeTela(0) = "STATEMENT INQUIRY SCREEN"

            With tela
                'Validando se a tela travou e voltando para a principal
                If .GetString(22, 2, 34).trim() = "NO ACTION TAKEN" Then
                    .putstring("I", 1, 7)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(50)
                End If

                Do While Not .getString(1, 21, 30).ToString.Trim = nomeTela(0) And contador < 3 'Navegando para a tela de captura

                    .putstring("S", 1, 7) 'Navegando para a tela de MEMO, caso esteja em outra tela
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(100)
                    contador += 1
                Loop

                'Reconectando o MainFrame
                If Not .getString(1, 23, 26).ToString.Trim = nomeTela(0) Then
                    LogoffSystemB2K(tela)
                    Login_CNPBCOT1(mainframe)
                    'paginando para tela principal da função
                    .putstring("S", 1, 7) 'Navegando para a tela de MEMO, caso esteja em outra tela
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(100)
                End If

                'Validando se o acesso foi concluído com sucesso
                If Not .getString(1, 21, 30).ToString.Trim = nomeTela(0) Then
                    status_execucao = False
                    Return Nothing
                Else

                    'Limpando o cartão anterior
                    .putstring("                   ", 2, 18)
                    .sendKeys("<Enter>")
                    .WaitHostQuiet(50)

                    'Inserindo novo cartão
                    numCartao = numCartao.Insert(6, " ")
                    .putstring(numCartao, 2, 17)
                End If
            End With

            'Iniciando o CICLO 01
            'Total de ciclos possíveis da CONTA
            'Não é utilizado o CICLO 00 que é a fatura aberta
            tela.PutString("01", 3, 8, 2)
            tela.sendKeys("<Enter>")
            tela.WaitHostQuiet(50)



            Do While Not tela.GetString(22, 2, 30).trim().Equals("TECLA PF1 INATIVA") _
                        And Not tela.GetString(22, 2, 30).trim().Equals("NAO CONSTA FAT. ANTERIOR") _
                            And Not tela.GetString(22, 2, 30).trim().Equals("ARQ FATURA INDISPONIVEL") _
                                And Not tela.GetString(22, 2, 30).trim().Equals("REG AGENDA N/ ENCONT") _
                                    And Not tela.GetString(22, 2, 30).trim().Equals("NRO CTA N/ ENCONTRADO") 'FIM DAS FATURAS

                'Iniciando objetos
                Dim fatura = New fatura_DTO()
                Dim ListaAutorizacoes As New List(Of autorizacoes_DTO)

                'Regras de navegação:
                ' - entre a paginação das transaçãoes de uma mesma fatura usar o F8 até a msg "TECLA PF8 INATIVA" for informada na tela
                ' - entre as faturas de um mesmo cliente usar o F1, desta forma navegará entre os CICLOS de forma crescente. 
                ' - Lembrando que a fatura de ciclo 01 é a última fatura fechada a ciclo 02 a penúltima e assim por diante...
                ' - ao finalizar a coleta das autorizações de um ciclo, clicar <F1> e passar para o ciclo seguinte..
                ' - validar a data limite para captura das faturas/transacoes

                'If numCartao = "4551821001673874" Then
                '    MsgBox("PARADA PARA ANÁLISE")
                'End If

                With fatura
                    .cartao = Replace(numCartao, " ", "")
                    .bin = Left(.cartao, 6)
                    .cpf = cpf
                    .valorFatura = hlp.transformarMoeda(tela.GetString(9, 65, 15).ToString().Trim()) 'Valor da fatura atual
                    .valorPagamento = hlp.transformarMoeda(tela.GetString(7, 65, 15).ToString().Trim()) 'Valor de pgto
                    .dataVencimento = hlp.FormataDataAbreviada(tela.GetString(2, 65, 8).ToString().Trim()) 'Data Vencimento
                    .dataCorte = hlp.FormataDataAbreviada(tela.GetString(6, 18, 8).ToString().Trim()) 'Data de Corte
                    .dataPagamento = hlp.FormataDataAbreviada("01/01/1900") 'Esta data está disponível entre as autorizações e a captura será feita durante a captura das autorizações
                End With

                'Validando a data de corte, parâmetro recuperado da tabela de faturas, desta forma não precisa-se repetir capturas já realizadas anteriormente
                If fatura.dataCorte <= dataLimite Then Exit Do
                Dim qtdeF8 As Integer = 0
                Do While Not tela.GetString(22, 2, 17).ToString() = "TECLA PF8 INATIVA" 'FIM DAS AUTORIZACOES
                    For i = 11 To 21
                        linha = i
                        Dim autorizacao = New autorizacoes_DTO()

                        Dim numReferencia = tela.GetString(linha, 4, 24).ToString().Trim() 'Capturando campo de referência
                        If numReferencia.Trim().Length > 0 Then 'Validando se a linha capturada é válida para ser armazenada
                            With autorizacao

                                'Capturar POS
                                tela.PutString("E", linha, 2, 1)
                                tela.sendKeys("<PF6>")
                                tela.WaitHostQuiet(25)
                                .pos = tela.GetString(14, 17, 3).ToString().Trim()
                                'Capturar Ramo atividade, pais, cidade, nome ec, maquineta e cod moeda
                                tela.sendKeys("<PF8>")
                                tela.WaitHostQuiet(25)
                                .ecMaquineta = tela.GetString(11, 36, 16).ToString().Trim()
                                .ecCodPais = tela.GetString(10, 76, 4).ToString().Trim()
                                .ecCidade = tela.GetString(10, 44, 13).ToString().Trim()
                                .ecNome = tela.GetString(10, 11, 25).ToString().Trim()
                                .codMoeda = tela.GetString(7, 40, 5).ToString().Trim()
                                .codRamoAtividade = tela.GetString(11, 11, 6).ToString().Trim()

                                'Voltando para tela de lista de despesas
                                tela.sendKeys("<PF7>")
                                tela.WaitHostQuiet(25)
                                tela.sendKeys("<PF9>")
                                tela.WaitHostQuiet(25)

                                'Calculando qtos F8 devem ser clicados
                                If qtdeF8 > 0 Then
                                    For f8 = 1 To qtdeF8
                                        tela.sendKeys("<PF8>")
                                        tela.WaitHostQuiet(25)
                                    Next
                                End If

                                .cartao = fatura.cartao
                                .bin = fatura.bin
                                .cpf = fatura.cpf
                                .dataCorte = fatura.dataCorte
                                .dataVencimento = fatura.dataVencimento
                                .codReferencia = numReferencia
                                .dataTransacao = hlp.FormataDataAbreviada(tela.GetString(linha, 34, 4).ToString().Insert(2, "/") + "/" + fatura.dataCorte.Year.ToString())
                                .dataInclusaoFatura = hlp.FormataDataAbreviada(tela.GetString(linha, 29, 4).ToString().Insert(2, "/") + "/" + fatura.dataCorte.Year.ToString())
                                .estabelecimento = tela.GetString(linha, 40, 24).ToString().Trim()
                                .valorTransacao = hlp.transformarMoeda(tela.GetString(linha, 65, 15).ToString())
                                'Validando se o valor é um crédito, exemplo o crédito de pgto
                                If tela.GetString(linha, 80, 1).ToString().Equals("-") Then
                                    .valorTransacao = .valorTransacao * -1
                                    fatura.dataPagamento = .dataTransacao 'Captura da data de pagamento para a tabela de faturas
                                Else
                                    .codAutorizacao = tela.GetString(linha + 1, 74, 6).ToString()
                                End If


                            End With
                            'Adicionando a lista de autorizações
                            ListaAutorizacoes.Add(autorizacao)
                        End If
                    Next

                    'Próxima página com autroizações
                    qtdeF8 += 1 'Necessário armazenar qtde de F8 para que após capturar o POS da transação possa retornar para a tela que estava sendo feita a captura
                    tela.sendKeys("<PF8>")
                    tela.WaitHostQuiet(50)
                Loop

                'Incluindo a lista de autorizações dentro da fatura
                fatura.listaAutorizacoes = ListaAutorizacoes
                historicoFaturas.Add(fatura)

                'Próxima fatura
                tela.sendKeys("<PF1>")
                tela.WaitHostQuiet(50)
            Loop

            status_execucao = True
            qtdeTentativas = 0
            Return historicoFaturas

        Catch ex As Exception
            If qtdeTentativas > 3 Then
                'MsgBox(ex.Message)
                status_execucao = False
                msgErro = ex.Message & " - " & numCartao
                Return Nothing
            Else
                qtdeTentativas += 1
                GoTo REINICIAR
                msgErro = ex.ToString()
                Throw New Exception
            End If
        End Try
    End Function




#End Region


End Module
