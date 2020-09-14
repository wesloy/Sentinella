declare @nomeGestor varchar(100) = 'Vinicius Silva Grevy%'

select base.* from (
	select ia.Nom_Usuario, ia.Cod_Matricula, ia.Nom_Centro_Custo, ia.Nom_Cargo, 
	(select top 1 Nom_Usuario from db_ControleAD.dbo.Tbl_UsuariosAD where Cod_Matricula = ia.Cod_Gestor_Hierarq_1 collate Latin1_General_CI_AS group by Nom_usuario) gestor_1, 
	(select top 1 Nom_Usuario from db_ControleAD.dbo.Tbl_UsuariosAD where Cod_Matricula = ia.Cod_Gestor_Hierarq_2 collate Latin1_General_CI_AS group by Nom_usuario) gestor_2, 
	(select top 1 Nom_Usuario from db_ControleAD.dbo.Tbl_UsuariosAD where Cod_Matricula = ia.Cod_Gestor_Hierarq_3 collate Latin1_General_CI_AS group by Nom_usuario) gestor_3, 
	(select top 1 Nom_Usuario from db_ControleAD.dbo.Tbl_UsuariosAD where Cod_Matricula = ia.Cod_Gestor_Hierarq_4 collate Latin1_General_CI_AS group by Nom_usuario) gestor_4, 
	(select top 1 Nom_Usuario from db_ControleAD.dbo.Tbl_UsuariosAD where Cod_Matricula = ia.Cod_Gestor_Hierarq_5 collate Latin1_General_CI_AS group by Nom_usuario) gestor_5, 
	ia.Dt_Admissao,
	ad.Nom_email, ad.Nom_OUs 
	from db_Corporate_V3.dbo.tb_Imp_Associado ia
	left join db_ControleAD.dbo.Tbl_UsuariosAD ad on ia.Cod_Matricula = ad.Cod_Matricula collate Latin1_General_CI_AS
	where ia.Dt_Demissao is null
) base

where base.gestor_1 like @nomeGestor
or base.gestor_2 like @nomeGestor
or base.gestor_3 like @nomeGestor
or base.gestor_4 like @nomeGestor
or base.gestor_5 like @nomeGestor

group by 
base.Nom_Usuario, 
base.Cod_Matricula, 
base.Nom_Centro_Custo, 
base.Nom_Cargo,
base.gestor_1, 
base.gestor_2, 
base.gestor_3, 
base.gestor_4, 
base.gestor_5, 
base.Dt_Admissao, 
base.Nom_email, 
base.Nom_OUs 

order by base.Nom_Usuario

