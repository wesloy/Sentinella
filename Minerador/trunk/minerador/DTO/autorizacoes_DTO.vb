Public Class autorizacoes_DTO

    Public Property id As Integer
    Public Property cartao As String
    Public Property bin As String
    Public Property cpf As String
    Public Property dataCorte As Date
    Public Property dataVencimento As Date
    Public Property dataTransacao As Date
    Public Property dataInclusaoFatura As Date
    Public Property codReferencia As String
    Public Property codAutorizacao As String
    Public Property estabelecimento As String
    Public Property valorTransacao As Double
    Public Property pos As String
    Public Property ecMaquineta As String
    Public Property ecNome As String
    Public Property ecNumero As String
    Public Property ecCidade As String
    Public Property ecCodPais As String
    Public Property codMoeda As String
    Public Property codRamoAtividade As String
    Public Property dataAtualizacao As Date
    Public Property idAtualizacao As String
    Public Property fatura As fatura_DTO


    'CREATE TABLE [dbo].[w_autorizacoes] (
    '    [id]                 INT           IDENTITY (1, 1) Not NULL,
    '    [cartao]             NVARCHAR(20) NULL,
    '    [bin]                NVARCHAR(6)  NULL,
    '    [cpf]                NVARCHAR(20) NULL,
    '    [dataCorte]          DATE          DEFAULT ('1900-01-01') NOT NULL,
    '    [dataVencimento]     DATE          DEFAULT ('1900-01-01') NOT NULL,
    '    [dataTransacao]      DATE          DEFAULT ('1900-01-01') NOT NULL,
    '    [dataInclusaoFatura] DATE          DEFAULT ('1900-01-01') NOT NULL,
    '    [codReferencia]      NVARCHAR(50) NULL,
    '    [codAutorizacao]     NVARCHAR(50) NULL,
    '    [estabelecimento]    NVARCHAR(50) NULL,
    '    [valorTransacao]     MONEY         NULL,
    '    [pos]                NVARCHAR(10) NULL,
    '    [ecMaquineta]        NVARCHAR(50) NULL,
    '    [ecNome]              NVARCHAR(50) NULL,
    '    [ecNumero]           NVARCHAR(50) NULL,
    '    [ecCidade]           NVARCHAR(50) NULL,
    '    [ecCodPais]          NVARCHAR(50) NULL,
    '    [codMoeda]           NVARCHAR(50) NULL,
    '    [codRamoAtividade]   NVARCHAR(50) NULL,
    '    [dataAtualizacao]    DATETIME      Default (getdate()) Not NULL,
    '    [idAtualizacao]      NCHAR(10)    NULL,
    '    CONSTRAINT [PK_w_autorizacoes] PRIMARY KEY CLUSTERED ([id] ASC)
    ');




End Class
