select c.cod_trilha, 
c.des_trilha, 
c.des_nome, 
replace(replace(c.cod_cpf, '.', ''), '-', '') as cpf, 
count(c.des_conteudo) as total_cursos, 
sum(iif(c.num_conclusao = '0', 1, 0)) as vol_nao_concluido, 
sum(iif(c.num_conclusao = '100', 1, 0)) as vol_concluido, 
sum(iif(c.num_conclusao = '100', 1, 0)) * 100 / count(c.des_conteudo) as percentual_concluido, 
max(dt_fim) as data_conclusao_ultimo_curso_trilha, 
(select Nom_Usuario from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Matricula = (Select Cod_Gestor_Hierarq_1 from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Cpf = replace(replace(c.cod_cpf, '.', ''), '-', ''))) gestor_1, 
(select Nom_Usuario from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Matricula = (Select Cod_Gestor_Hierarq_2 from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Cpf = replace(replace(c.cod_cpf, '.', ''), '-', ''))) gestor_2, 
(select Nom_Usuario from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Matricula = (Select Cod_Gestor_Hierarq_3 from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Cpf = replace(replace(c.cod_cpf, '.', ''), '-', ''))) gestor_3, 
(select Nom_Usuario from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Matricula = (Select Cod_Gestor_Hierarq_4 from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Cpf = replace(replace(c.cod_cpf, '.', ''), '-', ''))) gestor_4, 
(select Nom_Usuario from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Matricula = (Select Cod_Gestor_Hierarq_5 from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Cpf = replace(replace(c.cod_cpf, '.', ''), '-', ''))) gestor_5, 
(select iif(Dt_Admissao is null, '1900-01-01',convert(date,Dt_Admissao,109)) from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Cpf = replace(replace(c.cod_cpf, '.', ''), '-', '')) data_admissao, 
(select iif(Dt_Demissao is null, '1900-01-01',convert(date,Dt_Demissao,109)) from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Cpf = replace(replace(c.cod_cpf, '.', ''), '-', '')) data_demissao, 
(select iif(Dt_inicio_ferias is null, '1900-01-01',convert(date,Dt_inicio_ferias,109)) from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Cpf = replace(replace(c.cod_cpf, '.', ''), '-', '')) data_ferias_inicio, 
(select iif(Dt_fim_ferias is null, '1900-01-01',convert(date,Dt_fim_ferias,109)) from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Cpf = replace(replace(c.cod_cpf, '.', ''), '-', '')) data_ferias_fim, 
(select iif(Dt_inicio_afastamento is null, '1900-01-01',convert(date,Dt_inicio_afastamento,109)) from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Cpf = replace(replace(c.cod_cpf, '.', ''), '-', '')) data_afastamento_inicio, 
(select iif(Dt_fim_afastamento is null, '1900-01-01',convert(date,Dt_fim_afastamento,109)) from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Cpf = replace(replace(c.cod_cpf, '.', ''), '-', '')) data_afastamento_fim, 
GETDATE() as data_importacao, 
1 as id_importacao 
from db_TreinamentoSinergyRH.dbo.TB_TRILHAS c 
inner join w_trilhasTreinamentos_cursos f on c.Id_Conteudo = f.cod_curso 
inner join w_trilhasTreinamentos_trilhas t on c.cod_trilha = t.cod_trilha 
where c.des_status = 'Ativo' 
group by 
c.cod_trilha, 
c.des_trilha, 
c.des_nome, 
c.cod_cpf 