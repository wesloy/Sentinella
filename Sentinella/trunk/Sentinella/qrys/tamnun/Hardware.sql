       select * from (select Date, c.name as Unit, Computername, a.Name, value as val from (
			select SystemInfo.Name.value('NAME[1]','varchar(255)')  as [Name],
			SystemInfo.Name.value('VALUE[1]','varchar(256)') as [Value],
			convert(varchar(10),His.[Date],120) as [Date],
			His.ComputerId as ComputerId
				from (select convert(XML,[InnerXML]) as [InnerXML],ComputerID,[Date] from ut_Hardware a with (nolock)
						WHERE [Date] = (SELECT MAX([Date]) FROM ut_Hardware, ut_TCPAddress t with (nolock) 
							where ComputerID = A.ComputerID and ComputerID = t.ID  
								and  innerxml like '%<INFO>%' and  innerxml like '%</INFO>%'))  
			His cross apply [InnerXML].nodes('.//INFO/NODE') AS SystemInfo([Name]) ) a, ut_tcpaddress b, ut_Organization c with (nolock)
             where b.id = a.COMPUTERID and b.Organization = c.Id) as a
             
			 pivot (max(val) FOR a.name in ([Processor], [Motherboard], [BIOS], [BIOS_VERSION], [BusType], [PhysMemory], [VirtMemory], [HardDisk], [CD_Manufacture], [Sound], [Video], [MachineName], [UserName], [LocalIP], [Network_Card], [Offline NetCard_1], [Offline NetCard_2], [Offline NetCard_3], [Offline NetCard_4], [Offline NetCard_5], [Locale_Info], [PlatformVersion])) as pvt 
				
				where Unit = 'Outros' -- Filtro Grupo
				--and computername like 'Br%' -- Filtro Nome ma máquina
				
			 
