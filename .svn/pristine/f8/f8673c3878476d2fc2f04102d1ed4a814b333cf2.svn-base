select ComputerName, CONVERT(VARCHAR(10),P.Date,120) AS Date
,CpuUsage.Cpu.value('CPU[1]','varchar(20)')AS [CPU]
,CpuUsage.Cpu.value('MEM_AVR[1]','varchar(20)')AS [MEM_AVR]
,CpuUsage.Cpu.value('MEM_MIN[1]','varchar(20)')AS [MEM_MIN]
,CpuUsage.Cpu.value('MEM_MAX[1]','varchar(20)')AS [MEM_MAX]
,CpuUsage.Cpu.value('PAGE_AVR[1]','varchar(20)')AS [PAGE_AVR]
,CpuUsage.Cpu.value('PAGE_MIN[1]','varchar(20)')AS [PAGE_MIN]
,CpuUsage.Cpu.value('PAGE_MAX[1]','varchar(20)')AS [PAGE_MAX]
from ut_CpuUsage as P with(nolock) CROSS APPLY [InnerXML].nodes('//COUNTRUN_CPU/PERF') AS CpuUsage(Cpu),
ut_tcpaddress AS b with(nolock)
WHERE P.ComputerID = B.ID
--AND Date = '2020-03-27' 
--AND b.ComputerName like 'Bra%'
