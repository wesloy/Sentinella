--insert into w_trilhasTreinamentos 
--(des_turma, des_nome, cpf, total_cursos, vol_nao_concluido, 
--vol_concluido, percentual_concluido, gestor_1, gestor_2, gestor_3, 
--gestor_4, gestor_5, data_importacao, id_importacao ) 

select a.*, datediff(DAY,getdate(),datefromparts(year(getdate()), month(a.data_de_admissao), day(a.data_de_admissao))) as periodoCobranca  
from ( 
select c.des_turma, c.des_nome, 
replace(replace(c.cod_cpf, '.', ''), '-', '') as cpf, 
count(c.des_conteudo) as total_cursos, 
sum(iif(c.num_conclusao = '0', 1, 0)) as vol_nao_concluido, 
sum(iif(c.num_conclusao = '100', 1, 0)) as vol_concluido, 
sum(iif(c.num_conclusao = '100', 1, 0)) * 100 / count(c.des_conteudo) as percentual_concluido, 
(select top 1 gestor_1 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_1, 
(select top 1 gestor_2 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_2, 
(select top 1 gestor_3 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_3, 
(select top 1 gestor_4 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_4, 
(select top 1 gestor_5 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_5, 
(select top 1 data_de_admissao from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_de_admissao, 
(select top 1 data_demissao from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_demissao, 
GETDATE() as data_importacao, 
1 as id_importacao 
from db_TreinamentoSinergyRH.dbo.TB_TRILHAS c 
left join w_trilhasTreinamentos t on c.des_nome = t.des_nome and c.des_turma = t.des_turma and t.cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') 
where c.des_turma like '%TRILHA SGI%' 
and c.des_status = 'Ativo' 
and (t.id is null or t.email_enviado = 1) 
group by c.des_turma, c.des_nome, c.cod_cpf 
having sum(iif(c.num_conclusao = '100', 1, 0)) * 100 / count(c.des_conteudo) < 100 
) a  
where a.data_demissao = '1900-01-01' or a.data_demissao is null

