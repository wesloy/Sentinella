
Public Class cartoes_DTO

    Public Property ID As Integer
    Public Property CPF As String
    Public Property cartao As String
    Public Property bin As String
    Public Property tipoCartao As String 'TITULAR / ADICIONAL / CONTA
    Public Property nome As String
    Public Property endereco As String
    Public Property numResidencial As String
    Public Property cidade As String
    Public Property estado As String
    Public Property cep As String
    Public Property bloqueio As String
    Public Property ativo As Boolean
    Public Property limite_Credito As Decimal
    Public Property limite_Credito_Anterior As Decimal
    Public Property limite_Credito_Disponivel As Decimal
    Public Property limite_Saque As Decimal
    Public Property limite_Saque_Disponivel As Decimal
    Public Property limite_Data_Alteracao As Date
    Public Property limite_Fonte_Alteracao As String
    Public Property data_Emissao As Date
    Public Property data_Desbloqueio As Date
    Public Property data_Abertura_Conta As Date

    Public Property dataAtualizacao As Date
    Public Property idAtuaizacao As String

    'CREATE TABLE [dbo].[w_cartoes] (
    '    [id]                        INT            IDENTITY (1, 1) Not NULL,
    '    [cpf]                       NVARCHAR(20)  Not NULL,
    '    [cartao]                    NVARCHAR(20)  NULL,
    '    [bin]                       NVARCHAR(6)   NULL,
    '    [tipoCartao]                NVARCHAR(20)  NULL,
    '    [nome]                      NVARCHAR(100) NULL,
    '    [endereco]                  NVARCHAR(100) NULL,
    '    [numResidencial]            NVARCHAR(10)  NULL,
    '    [cidade]                    NVARCHAR(100) NULL,
    '    [estado]                    NVARCHAR(100) NULL,
    '    [cep]                       NVARCHAR(20)  NULL,
    '    [bloqueio]                  NVARCHAR(20)  NULL,
    '    [ativo]                     BIT            Default ((0)) Not NULL,
    '    [limite_Credito]            DECIMAL (18)   DEFAULT ((0)) NULL,
    '    [limite_Credito_Anterior]   DECIMAL (18)   DEFAULT ((0)) NULL,
    '    [limite_Credito_Disponivel] DECIMAL (18)   DEFAULT ((0)) NULL,
    '    [limite_Saque]              DECIMAL (18)   DEFAULT ((0)) NULL,
    '    [limite_Saque_Disponivel]   DECIMAL (18)   DEFAULT ((0)) NULL,
    '    [limite_Data_Alteracao]     DATE           NULL,
    '    [limite_Fonte_Alteracao]    NVARCHAR(50)  NULL,
    '    [data_Emissao]              DATE           NULL,
    '    [data_Desbloqueio]          DATE           NULL,
    '    [data_Abertura_Conta]       DATE           NULL,
    '    [dataAtualizacao]           DATETIME       Default (getdate()) NULL,
    '    [idAtualizacao]             NVARCHAR(15)  NULL,
    '    CONSTRAINT [PK_w_cartoes] PRIMARY KEY CLUSTERED ([id] ASC)
    ');



End Class
