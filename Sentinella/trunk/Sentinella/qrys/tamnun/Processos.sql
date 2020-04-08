select Date, tc.ComputerName, pr.Name, Path, SZ as Size, CRE as Createdate, UPD as UpdateDate, VER as Version, Maker, Prod as Product,
[Desc] as description, Orig as OriginalName, Parent, User, Args as Arguments, Svc as Service, Mode as ServiceStatus, Start as ServiceStart,
T_CPU as CPU, WS_K as MEM, IO_MB as IO, Active as ActiveTime  

from ut_TCPAddress tc, ut_ProcessAll_csv pr,  ut_Organization org
where tc.id = pr.ComputerId  and tc.Organization = org.Id

and date = '2020-01-02' -- Filtro de data
--and org.Name = 'Outros'
--and tc.ComputerName like 'Bra%'
--and pr.name = 'svcenergy.exe' -- filtro nome do processo
