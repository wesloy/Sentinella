select a.Date, c.Name as Unit, b.ComputerName, Category, OeEvent as Event, ' ' + convert(varchar(2000),[OeItem]) as Item, OeId, OeUser as 'User'
      from [ut_AlertOE] a with(nolock), ut_TCPAddress b with(nolock), ut_Organization c with (nolock)
      where a.ComputerId = b.ID and b.Organization = c.Id and OeEvent <> 'File Probably Copied' and OeUser <> '' and OeUser is not null and OeUser not like '%,%' and OeUser not like '\'
		-- and Category  = 'File' -- Arquivos
		--and Category  = 'Device' -- Dispositivos
		--and convert(varchar(10),[Date],120) = '2020-01-31' -- Filtro Data
		
		