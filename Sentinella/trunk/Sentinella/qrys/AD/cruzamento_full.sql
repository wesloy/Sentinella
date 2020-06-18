select G.grupo, F.pasta, A.nome_associado from w_AD_grupos_descricoes G 
left join w_AD_file_serve F on G.grupo = F.grupo 
left join w_AD_grupos_lista_associados A on A.grupo = G.grupo 
group by G.grupo, F.pasta, A.nome_associado 
order by G.grupo, F.pasta, A.nome_associado 


--Pesquisa sobre perfis com internet
select * from (

select 
cad.matricula, 
cad.nome_associado, 
u.Nom_OUs, 
g.grupo, 
u.Nom_email, 
cad.codcentro_de_custo, 
cad.cargo_do_associado,
cad.gestor_1, 
cad.gestor_2, 
cad.gestor_3, 
cad.gestor_4, 
cad.gestor_5,
cad.dataAtualizacao 
from w_funcionarios_historico cad 
inner join w_AD_grupos_lista_associados g on cad.nome_associado = g.nome_associado 
inner join db_ControleAD.dbo.Tbl_UsuariosAD u on cad.cpf = u.Cod_CPF collate Latin1_General_CI_AS

where g.grupo like 'internet%' or g.grupo like 'i.%' or g.grupo like 'i_%'

group by 
cad.matricula, 
cad.nome_associado, 
u.Nom_OUs, 
g.grupo, 
u.Nom_email, 
cad.codcentro_de_custo, 
cad.cargo_do_associado,
cad.gestor_1, 
cad.gestor_2, 
cad.gestor_3, 
cad.gestor_4, 
cad.gestor_5,
cad.dataAtualizacao 

) a 
where a.grupo like 'internet%' or a.grupo like 'i.%' or a.grupo like 'i_%'
order by nome_associado, grupo, dataAtualizacao