
--declare @DataIni varchar(10), @DataFim varchar(10)
--set @DataIni = '2020/03/01'
--set @DataFim = '2020/03/31'

select tc.ComputerName, app.date,app.name, app.vendor, app.version, app.installdate
	from ut_ApplicationSummary app with (nolock), ut_TCPAddress tc with (nolock), ut_Organization org with (nolock)
	where app.ComputerId = tc.ID and tc.Organization = org.Id
	--and org.Name = 'Outros' -- Filtro por grupo
    --and tc.ComputerName like 'Bra%' -- Filtro por nome da máquina
	and app.Name not like '%kb[0-9]%' -- Filtrar atualizações
	--and app.vendor not like 'Microsoft%' --Filtra fabricante
	and DATE = (select MAX(date) from ut_ApplicationSummary b with (nolock) where b.ComputerId = app.computerid) --Pega o último inventário de cada máquina
	--and DATE = (select MAX(date) from ut_ApplicationSummary b with (nolock) where b.ComputerId = app.computerid and DATE >= @DataIni and DATE <= @DataFim) --Pega o último inventário de cada máquina em um periodo

