--17/04/20 >>> Time de BD 

--------------------------------------------------------------------------
-- Busca Associados Brasil com falha no CPF ou no Ticket de criação
--------------------------------------------------------------------------
select 'Associado BR' as Tipo, Nom_login, Cod_Empresa, Cod_Matricula,
case Cod_CPF when '' then ' ???' else Cod_CPF end as Cod_CPF,
case Cod_TicketCriacao when '' then ' ???' else Cod_TicketCriacao end as Cod_TicketCriacao,
        Nom_Usuario, Dat_Criacao
INTO #TMP_AssociadoBR_Falha
  from Vw_UsrAD_Associados
  where Dat_Criacao >= cast(getdate()-1 as Date)
    and (Cod_CPF='' or
         len(cod_cpf) <> 11 or
    Cod_TicketCriacao = '')
  order by Dat_Criacao, Nom_Usuario

--------------------------------------------------------------------------
-- Busca associados Latam sem o Ticket de criação
--------------------------------------------------------------------------
select 'Associado Latam' as Tipo, Nom_login, Cod_Empresa, Cod_Matricula, Cod_CPF,
case Cod_TicketCriacao when '' then ' ???' else Cod_TicketCriacao end as Cod_TicketCriacao,
        Nom_Usuario, Dat_Criacao
INTO #TMP_AssociadoLatam_Falha
  from db_ControleAD.dbo.Vw_UsrAD_AssociadosLatam
  where Dat_Criacao >= cast(getdate()-1 as Date)
    and Cod_TicketCriacao = ''
  order by Dat_Criacao, Nom_Usuario

--------------------------------------------------------------------------
-- Busca contas de serviço sem o Ticket de criação
--------------------------------------------------------------------------
select 'Conta Serviço' as Tipo, Nom_login, Cod_Empresa, Cod_Matricula, Cod_CPF,
case Cod_TicketCriacao when '' then ' ???' else Cod_TicketCriacao end as Cod_TicketCriacao,
Nom_Usuario, Dat_Criacao
INTO #TMP_Servico_Falha
  from db_ControleAD.dbo.Vw_UsrAD_ContasServico
  where Dat_Criacao >= cast(getdate()-1 as Date)
    and Cod_TicketCriacao = ''
  order by Dat_Criacao, Nom_Usuario

--------------------------------------------------------------------------
-- Busca contas de Terceiros com falha no CPF, no Ticket de criação
--  ou na Data de Expiracao da Conta
--------------------------------------------------------------------------
select 'Terceiro' as Tipo, Nom_login, Cod_Empresa, Cod_Matricula, Cod_CPF,
case Cod_TicketCriacao when '' then ' ???' else Cod_TicketCriacao end as Cod_TicketCriacao,
Nom_Usuario, Dat_Criacao, Dat_ExpiracaoConta
INTO #TMP_Terceiro_Falha
  from db_ControleAD.dbo.Vw_UsrAD_Terceiros
  where Dat_Criacao >= cast(getdate()-1 as Date)
    and (Cod_TicketCriacao = '' or
    Dat_ExpiracaoConta IS NULL)
  order by Dat_Criacao, Nom_Usuario

  ---------------------------------------------------------------------------
  --modificação para atender necessidades SI
  ---------------------------------------------------------------------------
  

  -- Busca Associados Brasil
  select 'Associado BR' as Tipo, *  
  from db_ControleAD.dbo.Vw_UsrAD_Associados 
  where Cod_TicketCriacao = ''

  -- Busca associados Latam
    select 'Associado Latam' as Tipo, *  
  from db_ControleAD.dbo.Vw_UsrAD_AssociadosLatam 
  where Cod_TicketCriacao = ''

  -- Busca contas de serviço
    select 'Conta Serviço' as Tipo, *  
  from db_ControleAD.dbo.Vw_UsrAD_ContasServico 
  where Cod_TicketCriacao = ''

  -- Busca contas de Terceiros
    select 'Terceiro' as Tipo, *  
  from db_ControleAD.dbo.Vw_UsrAD_Terceiros 
  where Cod_TicketCriacao = ''



------------------------------------------------------------------------
--Qry para capturar FICHA DE RISCO - Criação X Ticket
------------------------------------------------------------------------
DECLARE @dataInicial varchar(10) = '2020-04-01'
DECLARE @dataFinal varchar(10) = '2020-04-30'

  
 -- Busca Associados Brasil
select 'Associado BR' as Tipo, *  
from db_ControleAD.dbo.Vw_UsrAD_Associados 
where format(Dat_Criacao,'yyyy-MM-dd') between @dataInicial and @dataFinal

union all 

  -- Busca associados Latam
 select 'Associado Latam' as Tipo, *  
 from db_ControleAD.dbo.Vw_UsrAD_AssociadosLatam 
where format(Dat_Criacao,'yyyy-MM-dd') between @dataInicial and @dataFinal

union all 

  -- Busca contas de serviço
select 'Conta Serviço' as Tipo, *  
from db_ControleAD.dbo.Vw_UsrAD_ContasServico 
where format(Dat_Criacao,'yyyy-MM-dd') between @dataInicial and @dataFinal

union all 

  -- Busca contas de Terceiros
select 'Terceiro' as Tipo, *  
from db_ControleAD.dbo.Vw_UsrAD_Terceiros 
where format(Dat_Criacao,'yyyy-MM-dd') between @dataInicial and @dataFinal

