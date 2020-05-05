--grupos por usuário
select nome_associado, grupo from w_AD_grupos_lista_associados 
where nome_associado = 'wesley eloy'
group by nome_associado, grupo
order by grupo, nome_associado

--qtde de associados por grupo
select g.grupo, count(a.id) as qtde 
from w_AD_grupos_lista_associados a right join w_AD_grupos_descricoes g on a.grupo = g.grupo 
where g.grupo like '340001210'
group by g.grupo
order by g.grupo 


--grupos sem usuários
select g.grupo, count(a.id) as qtde 
from w_AD_grupos_lista_associados a right join w_AD_grupos_descricoes g on a.grupo = g.grupo 
group by g.grupo
having count(a.id) = 0
order by g.grupo 

--usuários com apenas 1 grupo
select nome_associado, count(grupo) as qtde_Grupos from w_AD_grupos_lista_associados 
group by nome_associado 
having count(grupo) = 1
order by nome_associado

--usuários por grupo
select grupo, nome_associado from w_AD_grupos_lista_associados 
where grupo like '340001210'
group by grupo, nome_associado
order by grupo, nome_associado