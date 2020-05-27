select G.grupo, F.pasta, A.nome_associado from w_AD_grupos_descricoes G 
left join w_AD_file_serve F on G.grupo = F.grupo 
left join w_AD_grupos_lista_associados A on A.grupo = G.grupo 
group by G.grupo, F.pasta, A.nome_associado 
order by G.grupo, F.pasta, A.nome_associado 