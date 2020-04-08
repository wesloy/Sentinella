select 
org.Name as Unit
,tc.[ComputerName]
,svc.[Date]
,svc.[Name] as ServiceName
,svc.[Desc]
,svc.[Path]
,svc.[State]
,svc.[Start]
,svc.[User]
,svc.[Arguments]

from
ut_TCPAddress tc, ut_ConfigServiceInfTab svc, ut_Organization org
where tc.id = svc.ComputerId and tc.Organization = org.Id

--and org.Name = 'Outros'
and tc.ComputerName like 'Bra%' 
and svc.Date = '2020-01-05'