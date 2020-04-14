select  a.date, c.Name as Unit, ComputerName, a.name as Share, 
		(select value from string_split(a.Value, ',') where value like '%Path=%') as Path

  from ut_ConfigSharedDirTab a with (nolock), ut_TCPAddress b  with (nolock), ut_Organization c  with (nolock)
  where a.ComputerId = b.ID and b.Organization = c.Id
  --and c.Name = 'Outros' -- Filtro por grupo
  --and b.ComputerName like 'Bra%' -- Filtro por nome da máquina
  and date = (select max(date) from ut_ConfigSharedDirTab d with (nolock) where d.computerId = b.Id) --Pega o último inventário de cada máquina
  -- date = '2020-03-01'
