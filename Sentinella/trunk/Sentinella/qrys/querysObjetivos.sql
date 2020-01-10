
declare @dataInicial date = '2018-06-01',
		@dataFinal date = '2019-06-30' 
		
----BASE GERAL BUSCA POR PERÍODO OU PROTOCOLO
--select 
--b.id as PROTOCOLO, 
--b.cpf AS CPF, 
--b.data_Registro AS DATA_REGISTRO, 
--f.descricao as FILA, 
--case
--when b.status_id = 0 then
--'ABERTO'
--when b.status_id = 1 then
--'TRABALHANDO'
--when b.status_id = 3 then
--'FINALIZADO'
--END AS STATUS, 
--uCat.nome as ANALISTA_CAT,
--fin.descricao as FINALIZACAO, 
--sFin.descricao as SUBFINALIZACAO,
--b.observacao as OBSERVACAO, 
--b.data_Trabalho as DATA_TRABALHO, 
--b.hora_Inicial as HORA_INICIAL, 
--b.hora_Final as HORA_FINAL, 
--b.tempo_Trabalho_Segundos as TEMPO_TRABALHO_SEGUNDOS, 
--b.valor_Envolvido as VALOR_ENVOLVIDO, 
--iif(b.sla_cumprido = 1,'SIM','NÃO') as SLA_CUMPRIDO, 
--iif(b.gerado_fup = 1,'SIM','NÃO') as GERADO_FUP, 
--b.id_Historico as PROTOCOLO_HISTORICO, 
--b.data_Abertura as DATA_ABERTURA,
--uImp.nome as ANALISTA_IMP 
--from w_base b 
--inner join w_sysFilas f on b.fila_id = f.id 
--left join w_sysUsuarios uCat on b.idCat = uCat.idRede 
--left join w_sysFinalizacoes fin on b.finalizacao_id = fin.id 
--left join w_sysSubFinalizacoes sFin on b.subFinalizacao_id = sFin.id 
--left join w_sysUsuarios uImp on b.id_Abertura = uImp.idRede 
--where 1 = 1 
--and format(b.data_trabalho,'d') between @dataInicial and @dataFinal 

----% Resolução por Analista
--select u.nome as Analista, u.idRede AS ID_REDE, count(b.id) as VOL_TRABALHADO, 
--format(count(b.id)/CONVERT(decimal(5,2),(select count(id) from w_base where data_Trabalho between @dataInicial and @dataFinal)),'P') as Percentual
--from w_base b
--inner join w_sysUsuarios u on b.idCat = u.idRede 
--where 1=1
--and b.status_id = 3 
--and b.data_Trabalho between @dataInicial and @dataFinal
--group by u.nome, u.idRede



--Produtividade por Dia (Entrante X Trabalhado)

----ENTRANTE	
--select 
--f.descricao as FILA, 
--format(b.data_Abertura,'d') as DATA, 
--count(b.id) as ENTRANTE, 
--0 as TRABALHADO 
--from w_base b 
--inner join w_sysfilas f on b.fila_id = f.id 
--where 1=1 
--and format(b.data_Abertura,'d') between @dataInicial and @dataFinal 
--group by f.descricao, b.data_Abertura 

----TRABALHADO
--select 
--f.descricao as FILA, 
--format(b.data_trabalho,'d') as DATA, 
--0 as ENTRANTE, 
--sum(iif(B.status_id = 3, 1, 0)) as TRABALHADO 
--from w_base b 
--inner join w_sysfilas f on b.fila_id = f.id 
--where 1=1 
--and format(b.data_trabalho,'d') between @dataInicial and @dataFinal 
--group by f.descricao, b.data_trabalho 
	


--Resolução diária evolutiva por fila
--select b.data_Trabalho as DATA_TRABALHO, 
--f.descricao as FILA, count(b.id) as VOLUME 
--from w_base b
--inner join w_sysfilas f on b.fila_id = f.id 
--where 1=1
--and b.status_id = 3 
--and b.data_Trabalho between @dataInicial and @dataFinal
--group by f.descricao, b.data_Trabalho 
--order by b.data_Trabalho asc, f.descricao asc


----Resolução diária evolutiva por analista/fila
--select b.data_Trabalho as DATA_TRABALHO, 
--f.descricao as FILA, 
--u.nome, u.idRede, count(b.id) as VOLUME 
--from w_base b
--inner join w_sysUsuarios u on b.idCat = u.idRede  
--inner join w_sysfilas f on b.fila_id = f.id 
--where 1=1
--and b.status_id = 3 
--and b.data_Trabalho between @dataInicial and @dataFinal
--group by u.nome, u.idRede, b.data_Trabalho, f.descricao  
--order by b.data_Trabalho asc, f.descricao asc, u.nome asc


----MIS vs Devolutiva Ouvidoria
--select 
--fila.descricao as FILA, 
--format(br.data_Registro,'yyyy-MM-dd') as DATA_INCIDENTE, 
--format(br.data_Abertura,'yyyy-MM-dd') as DATA_ABERTURA, 
--format(br.data_Trabalho,'yyyy-MM-dd') as DATA_TRABALHO, 
--br.sla_cumprido, 
--case
--when br.status_id = 0 then 
--'ABERTO'
--when br.status_id = 1 then
--'TRABALHANDO'
--when br.status_id = 3 then
--'FINALIZADO'
--END AS STATUS,
--f.descricao as FINALIZACAO, 
--sf.descricao as SUBFINALIZACAO,
--br.observacao 
--from w_base b 
--inner join w_baseRetornoOuvidoria br on b.id = br.id_base_principal 
--left join w_sysFilas fila on b.fila_id = fila.id 
--left join w_sysFinalizacoes f on br.finalizacao_id = f.id 
--left join w_sysSubFinalizacoes sf on br.subFinalizacao_id = sf.id 
--where 1=1
--and b.status_id = 3 
--and b.data_Trabalho between @dataInicial and @dataFinal 



----Medir Target de 90% dos Laudos no Prazo
--select u.nome as Analista, u.idRede AS ID_REDE, count(b.id) as VOL_TRABALHADO, 
--sum(iif(b.sla_cumprido = 1,1,0)) as SLA_CUMPRIDO, 
--sum(iif(b.sla_cumprido = 0,1,0)) as SLA_NAO_CUMPRIDO, 
--format(sum(iif(b.sla_cumprido = 1,1,0))/Convert(decimal(5,2),count(b.id)),'P') as [TARGET 90%]
--from w_base b 
--inner join w_sysUsuarios u on b.idCat = u.idRede 
--where 1=1
--and b.status_id = 3 
--and b.data_Trabalho between @dataInicial and @dataFinal 
--group by u.nome, u.idRede






--SELECT * from w_base where idCat = 'A095840' 