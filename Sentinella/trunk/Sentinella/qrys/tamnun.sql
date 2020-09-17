--select * from  [UDPITSMCLSDB].mdb.dbo.z_relatorio_catalago_sdm
--where data_reg_chamado >= '2020-02-21' and data_reg_chamado <= '2020-03-22' 


Select * from [UDPTAMNUNDB01].tamnun.dbo.ut_ProcessAll_csv 
where Date Between FORMAT(DATEADD(day,-8,getdate()),'yyyy-MM-dd') and format(getdate(),'yyyy-MM-dd')
and prod not like '%Trend%' 
and prod not like '%OfficeScan%' 
and prod not like '%Microsoft%' 
and prod not like '%Tamnun%' 
and prod not like '%Adobe%' 
and prod not like '%CA %' 
and prod not like '%CA-%' 
and prod not like '%TeamViewer%' 
and prod not like '%Realtek%' 
and prod not like '%Intel(R)%' 
and prod not like '%NICE%' 
and prod not like '%Citrix%' 
and prod not like '%Internet Explorer%' 
and prod not like '%Google Chrome%' 
and prod not like '%Lenovo%' 
order by date

Select * from [UDPTAMNUNDB01].tamnun.dbo.ut9_Url
where Date Between FORMAT(DATEADD(day,-8,getdate()),'yyyy-MM-dd') and format(getdate(),'yyyy-MM-dd')
and HostDest not like '%algar%' 
and HostDest not like '%sinergy%' 
and HostDest not like '%serviceview%' 
and HostDest not like '%mail.google.com%' 
and HostDest not like '%bradesco%' 
order by date
