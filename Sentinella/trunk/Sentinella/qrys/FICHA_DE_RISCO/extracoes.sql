
DECLARE @dataInicial varchar(10) = '2020-04-01'
DECLARE @dataFinal varchar(10) = '2020-04-30'

 ---------------------------------------------------------------------------------------CRIAÇÃO DE USUÁRIOS AD X TICKETS
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


--------------------------------------------------------------------------------------------------PROCESSOS HOMOLOGADOS
Select prod from [UDPTAMNUNDB01].tamnun.dbo.ut_ProcessAll_csv 
where format([Date],'yyyy-MM-dd') between @dataInicial and @dataFinal
group by prod



------------------------------------------------------------------------------------------------TICKETS VPN 
select * from  [UDPITSMCLSDB].[mdb].[dbo].[z_ServiceDesk]
where [categoria] like '%VPN%'
AND format(DATA_ABERTURA,'yyyy-MM-dd') between @dataInicial and @dataFinal