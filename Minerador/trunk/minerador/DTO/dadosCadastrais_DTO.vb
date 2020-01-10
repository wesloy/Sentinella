Public Class dadosCadastrais_DTO

    Public Property id As Integer
    Public Property cpf As String
    Public Property cartao As String
    Public Property bin As String
    Public Property produto As String
    Public Property data_alteracao_End As Date
    Public Property data_alteracao_telefones As Date
    Public Property nome As String
    Public Property data_Nascimento As Date
    Public Property sexo As String
    Public Property nome_2 As String
    Public Property nome_3 As String
    Public Property nome_4 As String
    Public Property tel_residencial As String
    Public Property tel_empresa As String
    Public Property tel_celular As String
    Public Property end_cobranca As String
    Public Property cidade_cobranca As String
    Public Property estado_cobranca As String
    Public Property cep_cobranca As String
    Public Property end_anterior As String
    Public Property cidade_anterior As String
    Public Property estado_anterior As String
    Public Property cep_anterior As String
    Public Property end_correspondencia As String
    Public Property cidade_correspondencia As String
    Public Property estado_correspondencia As String
    Public Property cep_correspondencia As String
    Public Property dataAtualizacao As Date
    Public Property idAtualizacao As String


    'TELA I4 - B2K
    '    CREATE TABLE [dbo].[w_dadosCadastrais] (
    '    [id]                       INT            IDENTITY (1, 1) Not NULL,
    '    [cpf]                      NVARCHAR(20)  Not NULL,
    '    [cartao]                   NVARCHAR(20)  NULL,
    '    [produto]                  NVARCHAR(20)  NULL,
    '    [data_alteracao_End]       DATE           NULL,
    '    [data_alteracao_telefones] DATE           NULL,
    '    [nome]                     NVARCHAR(100) NULL,
    '    [data_Nascimento]          DATE           NULL,
    '    [sexo]                     NVARCHAR(2)   NULL,
    '    [nome_2]                   NVARCHAR(100) NULL,
    '    [nome_3]                   NVARCHAR(100) NULL,
    '    [nome_4]                   NVARCHAR(100) NULL,
    '    [tel_residencial]          NVARCHAR(100) NULL,
    '    [tel_empresa]              NVARCHAR(100) NULL,
    '    [tel_celular]              NVARCHAR(100) NULL,
    '    [end_cobranca]             NVARCHAR(250) NULL,
    '    [cidade_cobranca]          NVARCHAR(100) NULL,
    '    [estado_cobranca]          NVARCHAR(5)   NULL,
    '    [cep_cobranca]             NVARCHAR(20)  NULL,
    '    [end_anterior]             NVARCHAR(250) NULL,
    '    [cidade_anterior]          NVARCHAR(100) NULL,
    '    [estado_anterior]          NVARCHAR(5)   NULL,
    '    [cep_anterior]             NVARCHAR(20)  NULL,
    '    [end_correspondencia]      NVARCHAR(250) NULL,
    '    [cidade_correspondencia]   NVARCHAR(100) NULL,
    '    [estado_correspondencia]   NVARCHAR(5)   NULL,
    '    [cep_correspondencia]      NVARCHAR(20)  NULL,
    '    [dataAtualizacao]          DATETIME       Default (getdate()) NULL,
    '    [idAtualizacao]            NVARCHAR(15)  NULL,
    '    CONSTRAINT [PK_w_dadosCadastrais] PRIMARY KEY CLUSTERED ([id] ASC)
    ');
End Class
