
declare @dataInicial date = '2020-05-01',
		@dataFinal date = '2020-05-31' 

--FINALIZACÕES NÃO CONFORME
select b.id Protocolo_Sentinella, b.data_Abertura, fin.descricao Finalizacao, sfin.descricao SubFinalizacao, b.observacao  
from w_base b 
inner join w_sysFinalizacoes fin on b.finalizacao_id = fin.id 
inner join w_sysSubFinalizacoes sfin on b.subFinalizacao_id = sfin.id 
where b.data_Abertura between @dataInicial and @dataFinal 
and fin.descricao = 'NAO CONFORME' 