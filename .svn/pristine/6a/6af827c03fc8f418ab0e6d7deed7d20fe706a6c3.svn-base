select org.name as Grupo, tcpip_address as IP, computername as Nome, agentversion as [Versão Tamnun],
(select max(Date) from ut_hardware har with (nolock) where har.computerid = tc.id )  [Último Inventário], 
 lastupdate [Última Comunicação], [MacAddress], CreateDate, InstalledAt
from ut_TCPAddress tc with (nolock), ut_organization org with (nolock)
where tc.organization = org.id
