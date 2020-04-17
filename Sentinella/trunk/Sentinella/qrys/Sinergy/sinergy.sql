--select f.gestor_1, f.gestor_2, f.gestor_3, f.gestor_4, f.gestor_5, MAX(f.dataAtualizacao) as dataAtualizacao, b.des_turma, b.des_conteudo, b.des_nome, b.cpf, b.num_conclusao 
--from w_funcionarios_historico f inner join (
--select c.des_turma, c.des_conteudo, c.des_nome, replace(replace(c.cod_cpf,'.',''),'-','') as cpf, c.num_conclusao 
--from db_TreinamentoSinergyRH.dbo.TB_TRILHAS c 
--where c.des_turma like '%TRILHA SGI%' and c.des_status = 'Ativo' and c.num_conclusao = 0) b on f.cpf = b.cpf 
--group by f.gestor_1, f.gestor_2, f.gestor_3, f.gestor_4, f.gestor_5, b.des_turma, b.des_conteudo, b.des_nome, b.cpf, b.num_conclusao 
--order by b.des_nome, b.des_turma, dataAtualizacao  


--select c.des_turma, c.des_conteudo, replace(replace(c.cod_cpf,'.',''),'-','') as cpf, c.des_nome,   

--DELETE w_trilhasTreinamentos

insert into w_trilhasTreinamentos (
des_turma,
des_nome,
cpf,
total_cursos,
vol_nao_concluido,
vol_concluido,
percentual_concluido,
gestor_1,
gestor_2,
gestor_3,
gestor_4,
gestor_5, 
data_importacao, 
id_importacao
) select c.des_turma, c.des_nome, replace(replace(c.cod_cpf, '.',''),'-','') as cpf,   
count(c.des_conteudo) as total_cursos, 
sum(iif(c.num_conclusao = '0',1,0)) as vol_nao_concluido, 
sum(iif(c.num_conclusao = '100',1,0)) as vol_concluido, 
sum(iif(c.num_conclusao = '100',1,0))*100 / count(c.des_conteudo) as percentual_concluido, 
(select top 1 gestor_1 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf,'.',''),'-','') order by dataAtualizacao desc) as gestor_1, 
(select top 1 gestor_2 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf,'.',''),'-','') order by dataAtualizacao desc) as gestor_2,
(select top 1 gestor_3 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf,'.',''),'-','') order by dataAtualizacao desc) as gestor_3, 
(select top 1 gestor_4 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf,'.',''),'-','') order by dataAtualizacao desc) as gestor_4, 
(select top 1 gestor_5 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf,'.',''),'-','') order by dataAtualizacao desc) as gestor_5, 
GETDATE(), 
1 
from db_TreinamentoSinergyRH.dbo.TB_TRILHAS c left join w_trilhasTreinamentos t on c.des_nome = t.des_nome and c.des_turma = t.des_turma and t.cpf = replace(replace(c.cod_cpf, '.',''),'-','') 
where c.des_turma like '%TRILHA SGI%' 
and c.des_status = 'Ativo' 
and (t.id is null or t.email_enviado = 1) 
group by c.des_turma, c.des_nome, c.cod_cpf  
having sum(iif(c.num_conclusao = '100',1,0))*100 / count(c.des_conteudo) < 100 
order by c.des_nome 
