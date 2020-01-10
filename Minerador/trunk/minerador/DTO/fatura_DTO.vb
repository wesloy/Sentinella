Public Class fatura_DTO
    Public Property id As Integer
    Public Property cartao As String
    Public Property bin As String
    Public Property cpf As String
    Public Property dataCorte As Date
    Public Property dataVencimento As Date
    Public Property dataPagamento As Date
    Public Property valorFatura As Double
    Public Property valorPagamento As Double
    Public Property dataAtualizacao As Date
    Public Property idAtualizacao As String
    Public Property listaAutorizacoes As List(Of autorizacoes_DTO)

    'CREATE TABLE [dbo].[w_faturas] (
    '    [id]              INT           IDENTITY (1, 1) Not NULL,
    '    [cartao]          NVARCHAR(20) NULL,
    '    [bin]             NVARCHAR(6)  NULL,
    '    [cpf]             NVARCHAR(20) NULL,
    '    [dataCorte]       DATE          NULL,
    '    [dataVencimento]  DATE          NULL,
    '    [dataPagamento]   DATE          NULL,
    '    [valorFatura]     MONEY         NULL,
    '    [valorPagamento]  MONEY         NULL,
    '    [dataAtualizacao] DATETIME      Default (getdate()) NULL,
    '    [idAtualizacao]   NCHAR(10)    NULL,
    '    CONSTRAINT [PK_w_faturas] PRIMARY KEY CLUSTERED ([id] ASC)
    ');


End Class
