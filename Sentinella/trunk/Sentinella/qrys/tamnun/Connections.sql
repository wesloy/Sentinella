select mt.Date, tc.Computername, mt.LocalIP, mt.RemoteIP, mt.RemotePort, mt.Protocol, mt.BaseName, mt.MB_IN, mt.MB_OUT, mt.UserName
	from [ut_TCPAddress] tc with (nolocK), [ut9_Matrix] mt with (nolocK)
	where tc.ID = mt.ComputerId 
		and mt.date >= getdate() - 7 --Filtra os últimos 7 dias

