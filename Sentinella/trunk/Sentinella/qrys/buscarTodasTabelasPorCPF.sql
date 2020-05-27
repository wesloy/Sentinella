--select * from w_funcionarios_historico where nome_associado = 'GABRIELE SOUZA DE OLIVEIRA'



declare @cpf varchar(15) = '48751941880'

--select 
--format(b.data_Registro, 'yyyy-MM-dd') as data_registro, 
--b.data_Trabalho, 
--fila.descricao as fila, 
--f.descricao as finalizacao, 
--s.descricao as subfinalizacao, 
--b.observacao, 
--u.nome as analista_trabalhou 
--from w_base b 
--inner join w_sysFilas fila on b.fila_id = fila.id 
--inner join w_sysUsuarios u on b.idCat = u.id 
--inner join w_sysFinalizacoes f on b.finalizacao_id = f.id 
--left join w_sysSubFinalizacoes s on b.subFinalizacao_id = s.id 
--where 1 = 1 
--and b.cpf = @cpf 
--and b.status_id = 3 
--order by b.data_Trabalho desc



select * from w_base where cpf = @cpf
select * from w_funcionarios_historico where cpf = @cpf
select * from w_dadosCadastrais where cpf = @cpf
select * from w_cartoes where cpf = @cpf
select * from w_faturas where cpf = @cpf
select * from w_autorizacoes where cpf = @cpf
select * from w_tamnun_base where cpf = @cpf
select * from w_dlp where cpf = @cpf

--captura dados dos cartões
select conta.*, cartao.data_Emissao from 
(select * from w_cartoes where tipoCartao = 'CONTA' or tipoCartao = 'ADICIONAL') conta 
left join 
(select cpf, bin, data_Emissao from w_cartoes where tipoCartao = 'TITULAR') cartao 
on conta.cpf = cartao.cpf and conta.bin = cartao.bin 
where conta.cpf = @cpf