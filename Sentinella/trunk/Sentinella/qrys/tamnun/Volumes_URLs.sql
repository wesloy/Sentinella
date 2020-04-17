
select format(data_registro,'yyyy-MM-dd') as Data_Evento,
count(id) as Eventos_Totais,
sum(iif(t.caminho like '%whatsapp%',1,0)) as Eventos_WhatsApp 
from w_tamnun_base t 
where 1 = 1 
and t.fonte = 'URL' 
group by data_registro
order by data_registro



select 
'2020-03-24 ATÉ 2020-04-16' AS PERIODO,
categoria,
count(id) as Eventos_Totais 
from w_tamnun_base t 
where 1 = 1 
and t.fonte = 'URL' 
and format(data_registro,'yyyy-MM-dd') between '2020-03-24' and '2020-04-16'
group by categoria 
order by categoria 


