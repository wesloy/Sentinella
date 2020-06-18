
declare @dataInicial date = '2020-02-01',
		@dataFinal date = '2020-06-20',
		@gestor nvarchar(255) = 'FERNANDO POLATI DA SILVEIRA'

--FINALIZACÕES NÃO CONFORME / POR GESTOR
select * from (
select b.id Protocolo_Sentinella, 
b.data_Abertura,
b.data_Registro,
b.data_Trabalho, fila.descricao fila, fin.descricao Finalizacao, sfin.descricao SubFinalizacao, b.observacao,  
(select top 1 gestor_1 from w_funcionarios_historico where cpf = b.cpf order by dataAtualizacao desc) gestor_1,
(select top 1 gestor_2 from w_funcionarios_historico where cpf = b.cpf order by dataAtualizacao desc) gestor_2,
(select top 1 gestor_3 from w_funcionarios_historico where cpf = b.cpf order by dataAtualizacao desc) gestor_3,
(select top 1 gestor_4 from w_funcionarios_historico where cpf = b.cpf order by dataAtualizacao desc) gestor_4,
(select top 1 gestor_5 from w_funcionarios_historico where cpf = b.cpf order by dataAtualizacao desc) gestor_5,
t.categoria, t.filtro, t.caminho 
from w_base b 
inner join w_sysFilas fila on b.fila_id = fila.id 
inner join w_sysFinalizacoes fin on b.finalizacao_id = fin.id 
inner join w_sysSubFinalizacoes sfin on b.subFinalizacao_id = sfin.id 
inner join w_tamnun_base t on b.id = t.id_tbl_trabalho 
where b.data_Abertura between @dataInicial and @dataFinal 
and fin.descricao = 'NAO CONFORME' 
and b.fila_id = 12
and t.white_list = 0 
and t.flag_trabalho = 1
) A
Where A.gestor_1 
+ A.gestor_2  
+ A.gestor_3  
+ A.gestor_4  
+ A.gestor_5 like '%' + @gestor + '%'
order by Protocolo_Sentinella, data_Abertura 
