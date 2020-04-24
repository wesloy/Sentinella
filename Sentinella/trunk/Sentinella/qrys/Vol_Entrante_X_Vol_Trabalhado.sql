
Select
E.nome, E.Fila, E.data_Hora, E.vol_Entrante, iif(T.vol_Trabalhado is null, 0, T.vol_Trabalhado) as Vol_Trabalhado 
from 

(select 
U.nome,
F.descricao as Fila,
VE.data_Hora, 
Sum(VE.qtde_registros) as vol_Entrante  
from w_sysUsuariosVolParaTrabalho VE 
inner join w_sysUsuarios U on VE.id_usuario = U.id 
inner join w_sysFilas F on VE.fila_id = F.id 
where Month(VE.data_Hora) = 4 and Year(VE.data_Hora) = 2020 
group by U.nome, F.descricao, VE.data_Hora
--order by VE.data_Hora, F.descricao, U.nome
) E 

left join  

(select 
U.nome, 
F.descricao as Fila, 
VT.data_Abertura,  
Sum(iif(vt.status_id = 3, 1, 0)) as vol_Trabalhado, 
Sum(iif(vt.status_id < 3, 1, 0)) as vol_Disponivel 
from w_base VT 
inner join w_sysFilas F on vt.fila_id = F.id 
left join w_sysUsuarios U on VT.idCat = U.id 
where Month(vt.data_Abertura) = 4 and Year(vt.data_Abertura) = 2020 
group by U.nome, F.descricao, VT.data_Abertura
--order by VT.data_Abertura, F.descricao, U.nome
) T 

on E.Fila = T.Fila and E.nome = T.nome and E.data_Hora = T.data_Abertura 
group by E.nome, E.Fila, E.data_Hora, E.vol_Entrante, T.vol_Trabalhado 
order by E.data_Hora, E.Fila, E.nome