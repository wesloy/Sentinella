
select [ComputerName], [Date], [HostDest], [VirtualDirectory], [HostDest]+'/'+[VirtualDirectory] as Url, [UrlFile], [UrlParams],[Count], [UserAgent], [UsagePeriod], [Users]
  from ut9_Url url, ut_TCPAddress tc, ut_Organization org
  where url.ComputerId = tc.ID and tc.Organization = org.Id
and date = '2020-02-20' -- Filtro de data
--and org.Name = 'Outros'
--and tc.ComputerName like 'Bra%'
