Imports System.Configuration
Module mdl_constantes

    'Path de configurações do sistema
    Public PATH_ICONS As String = Application.StartupPath & ConfigurationManager.AppSettings("PATH_ICONS")
    Public PATH_PASTA_MIS As String = Application.StartupPath & ConfigurationManager.AppSettings("PATH_PASTA_MIS")
    Public PATH_PASTA_ANEXO As String = Application.StartupPath & ConfigurationManager.AppSettings("PATH_PASTA_ANEXO")
    Public PATH_LOG_IMPORT As String = Application.StartupPath & ConfigurationManager.AppSettings("PATH_LOG_IMPORT")
    Public PATH_MODELOS As String = Application.StartupPath & ConfigurationManager.AppSettings("PATH_MODELOS")
    Public PATH_REPORT As String = Application.StartupPath & ConfigurationManager.AppSettings("PATH_REPORT")
    Public Const TITULO_ALERTA = "Alerta do Sistema"

    'const BD ALGAR
    Public ALGAR_BD As String = ConfigurationManager.AppSettings("ALGAR_BD")
    Public ALGAR_SERVIDOR As String = ConfigurationManager.AppSettings("ALGAR_SERVIDOR")
    Public ALGAR_USER As String = ConfigurationManager.AppSettings("ALGAR_USER")
    Public ALGAR_PWD As String = GetConfig("ALGAR_PWD")


    Public Function GetConfig(key As String) As String
        Dim crypt As New mdl_Criptografia
        Return crypt.Decrypt(ConfigurationManager.AppSettings(key))
    End Function
    Public Enum FlagAcao
        Insert = 1
        Update = 2
        Delete = 3
        NoAction = 0
    End Enum
    Public Function imglist() As ImageList
        'cria um imagelist se necessario
        Dim imageListSmall As New ImageList
        With imageListSmall
            '.ImageSize = New Size(16, 16) ' (the default is 16 x 16).
            .Images.Add(1, Image.FromFile(PATH_ICONS & "01.ico"))
            .Images.Add(2, Image.FromFile(PATH_ICONS & "02.ico"))
            .Images.Add(3, Image.FromFile(PATH_ICONS & "03.ico"))
            .Images.Add(4, Image.FromFile(PATH_ICONS & "04.ico"))
            .Images.Add(5, Image.FromFile(PATH_ICONS & "05.ico"))
            .Images.Add(6, Image.FromFile(PATH_ICONS & "06.ico"))
            .Images.Add(7, Image.FromFile(PATH_ICONS & "07.ico"))
            .Images.Add(8, Image.FromFile(PATH_ICONS & "08.ico"))
            .Images.Add(9, Image.FromFile(PATH_ICONS & "09.ico"))
            .Images.Add(10, Image.FromFile(PATH_ICONS & "10.ico"))
            .Images.Add(11, Image.FromFile(PATH_ICONS & "11.ico"))
            .Images.Add(12, Image.FromFile(PATH_ICONS & "12.ico"))
            .Images.Add(13, Image.FromFile(PATH_ICONS & "13.ico"))
            .Images.Add(14, Image.FromFile(PATH_ICONS & "14.ico"))
        End With
        'fim da criacao do imagelist
        Return imageListSmall
    End Function
End Module
