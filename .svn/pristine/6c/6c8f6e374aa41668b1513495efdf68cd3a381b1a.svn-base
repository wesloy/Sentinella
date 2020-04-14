
select  b.ComputerName, a.date, a.name
	from ut_SecurityAdminTab a with (nolock), ut_TCPAddress b with (nolock), ut_Organization c  with (nolock)
	where a.ComputerId = b.ID and b.Organization = c.Id
		--and c.Name = 'Outros' -- Filtro por grupo
		--and b.ComputerName like 'Bra%' -- Filtro por nome da máquina
		and a.name not like 'S-%' 
		and a.value like '%adm%'  
		and DATE = (select MAX(date) from ut_SecurityAdminTab c with (nolock) where b.id = c.computerid) -- Para pegar o último registro de cada máquina
		--and DATE = '2020-03-30' -- Para consultar data especifica
