select a.Date, b.Name as Unit, Computername, a.Value as OS from 
	(select a.*, computername from 
		(select SystemInfo.Name.value('NAME[1]','varchar(255)') as [Name], SystemInfo.Name.value('VALUE[1]','varchar(256)') as [Value],	CONVERT(VARCHAR(10),His.[Date],120)  AS [Date],His.COMPUTERID as COMPUTERID  from 
			(select convert(XML,[InnerXML]) AS [InnerXML],ComputerID,[Date] from ut_Hardware a with (nolock) 
				where (innerxml like '%<INFO>%' and innerxml like '%</INFO>%')  
					and innerxml not like '%<?xml version="1.0" encoding="UTF-8" ?>%'  
					and [Date] = (select max([Date]) from ut_Hardware with (nolock) WHERE ComputerID = a.ComputerID)
			) 
						His cross apply [InnerXML].nodes('.//INFO/NODE') AS SystemInfo([Name]) 
		) a, ut_tcpaddress b where name in ('PlatformVersion') and b.id = a.COMPUTERID
	) a, ut_Organization b 
	where a.computerId = b.Id
  --and b.Name = 'Outros' -- Filtro por grupo
  --and a.ComputerName like 'Bra%' -- Filtro por nome da máquina
