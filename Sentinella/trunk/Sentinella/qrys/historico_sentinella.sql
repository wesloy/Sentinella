declare @cpf varchar(15) = '05404868686'

select 
format(b.data_Registro, 'yyyy-MM-dd') as data_registro, 
b.data_Trabalho, 
fila.descricao as fila, 
f.descricao as finalizacao, 
s.descricao as subfinalizacao, 
b.observacao, 
u.nome as analista_trabalhou 
from w_base b 
inner join w_sysFilas fila on b.fila_id = fila.id 
inner join w_sysUsuarios u on b.idCat = u.id 
inner join w_sysFinalizacoes f on b.finalizacao_id = f.id 
left join w_sysSubFinalizacoes s on b.subFinalizacao_id = s.id 
where 1 = 1 
and b.cpf = @cpf 
and b.status_id = 3 
order by b.data_Trabalho desc