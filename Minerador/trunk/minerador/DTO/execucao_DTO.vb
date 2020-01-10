Public Class execucao_DTO

    Public Property ID As Integer
    Public Property mainFrame As String
    Public Property macroExecutadaNome As String
    Public Property usuarioMainFrame As String
    Public Property apenasCartoesAtivos As Boolean
    Public Property macroExecutadaOK As Boolean
    Public Property logErro As String
    Public Property dataPesquisa As Date
    Public Property idRedePesquisa As String
    Public Property dataConclusao As Date

    'CREATE TABLE [dbo].[w_execucao] (
    '    [id]                   INT             IDENTITY (1, 1) Not NULL,
    '     [mainFrame]           NCHAR (20)      NOT NULL,
    '    [macroExecutadaNome]   NVARCHAR(255)   NULL,
    '    [usuarioMainFrame]	    NCHAR (20)      not null,
    '    [macroExecutadaOK]     BIT             Default ((0)) Not NULL,
    '    [logErro]       NvarCHAR(255)       NULL,
    '    [apenasCartoesAtivos]  BIT             DEFAULT ((0)) NOT NULL,
    '    [dataPesquisa]         DATETIME        Default (getdate()) NULL,
    '    [idRedePesquisa]       NCHAR(10)       NULL,
    '    [dataConclusao]         DATETIME        NULL,
    '    CONSTRAINT [PK_w_execucao] PRIMARY KEY CLUSTERED ([id] ASC)
    ');



End Class
