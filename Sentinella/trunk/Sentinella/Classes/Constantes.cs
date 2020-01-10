using System;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;


//outras tabelas necessárias
//	CREATE TABLE [dbo].[w_execucao] (
//	    [id]                  INT            IDENTITY (1, 1) NOT NULL,
//	    [mainFrame]           NCHAR (20)     NOT NULL,
//	    [macroExecutadaNome]  NVARCHAR (255) NULL,
//	    [usuarioMainFrame]    NCHAR (20)     NOT NULL,
//	    [apenasCartoesAtivos] BIT            DEFAULT ((0)) NOT NULL,
//	    [macroExecutadaOK]    BIT            DEFAULT ((0)) NOT NULL,
//	    [logErro]             NVARCHAR (255) NULL,
//	    [dataPesquisa]        DATETIME       DEFAULT (getdate()) NULL,
//	    [idRedePesquisa]      NCHAR (20)     NULL,
//	    [dataConclusao]       DATETIME       NULL,
//	    CONSTRAINT [PK_w_execucao] PRIMARY KEY CLUSTERED ([id] ASC)
//	);


//	CREATE TABLE [dbo].[w_MainFrame] (
//	    [id]               INT            IDENTITY (1, 1) NOT NULL,
//	    [status]           BIT            DEFAULT ((0)) NOT NULL,
//	    [mainframe]        NVARCHAR (255) NULL,
//	    [nome]             NVARCHAR (255) NULL,
//	    [usuario]          NVARCHAR (255) NULL,
//	    [senha]            NVARCHAR (255) NULL,
//	    [sessao]           NVARCHAR (255) NULL,
//	    [dt_alterar_senha] DATE           NULL,
//	    CONSTRAINT [PK_w_MainFrame] PRIMARY KEY CLUSTERED ([id] ASC)
//	);



namespace Sentinella
{
    public static class Constantes
    {
        //Variáveis para reaproveitamento e transportes de informações
        public static Boolean autenticacao { get; set; } = false;
        public static Boolean finalizacaoOkay { get; set; }
        public static int nivelAcesso { get; set; } = 0;    
        public static string idlogadoFerramenta { get; set; } = "";
        public static string nomeAssociadoLogado { get; set; } = "";
        public enum FlagAcao { Insert = 1, Update = 2, Delete = 3, NoAction = 0 }
        public static string Titulo_MSG { get; private set; } = "Alerta Senttinela!";
        public struct FlagSGBD { const string SQL = "SQL"; const string ACESS = "MSACESS"; }

        //Path de configurações do sistema
        public static string PATH_ICONS { get; private set; } = Application.StartupPath + ConfigurationManager.AppSettings["PATH_ICONS"].ToString();
        public static string PATH_PASTA_MIS { get; private set; } = Application.StartupPath + ConfigurationManager.AppSettings["PATH_PASTA_MIS"].ToString();
        public static string PATH_PASTA_ANEXO { get; private set; } = Application.StartupPath + ConfigurationManager.AppSettings["PATH_PASTA_ANEXO"].ToString();
        public static string PATH_LOG_IMPORT { get; private set; } = Application.StartupPath + ConfigurationManager.AppSettings["PATH_LOG_IMPORT"].ToString();
        public static string PATH_MODELOS { get; private set; } = Application.StartupPath + ConfigurationManager.AppSettings["PATH_MODELOS"].ToString();
        public static string PATH_REPORT { get; private set; } = Application.StartupPath + ConfigurationManager.AppSettings["PATH_REPORT"].ToString();
        
        //Banco de DADOS
        public static string ALGAR_BD { get; private set; } = ConfigurationManager.AppSettings["ALGAR_BD"].ToString();
        public static string ALGAR_SERVIDOR { get; private set; } = ConfigurationManager.AppSettings["ALGAR_SERVIDOR"].ToString();
        public static string ALGAR_USER { get; private set; } = ConfigurationManager.AppSettings["ALGAR_USER"].ToString();
        public static string ALGAR_PWD { get; private set; } = GetConfig("ALGAR_PWD");


        //Decriptando a senha
        public static string GetConfig(string key)
        {
            Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
            return hlp.Decrypt(ConfigurationManager.AppSettings[key].ToString());
        }

        //Lista de ICONES
        public static ImageList imglist()
        {
            // cria um imagelist se necessario
            ImageList imageListSmall = new ImageList();
            imageListSmall.Images.Add("1", Image.FromFile(PATH_ICONS + "01.ico"));
            imageListSmall.Images.Add("2", Image.FromFile(PATH_ICONS + "02.ico"));
            imageListSmall.Images.Add("3", Image.FromFile(PATH_ICONS + "03.ico"));
            imageListSmall.Images.Add("4", Image.FromFile(PATH_ICONS + "04.ico"));
            imageListSmall.Images.Add("5", Image.FromFile(PATH_ICONS + "05.ico"));
            imageListSmall.Images.Add("6", Image.FromFile(PATH_ICONS + "06.ico"));
            imageListSmall.Images.Add("7", Image.FromFile(PATH_ICONS + "07.ico"));
            imageListSmall.Images.Add("8", Image.FromFile(PATH_ICONS + "08.ico"));
            imageListSmall.Images.Add("9", Image.FromFile(PATH_ICONS + "09.ico"));
            imageListSmall.Images.Add("10", Image.FromFile(PATH_ICONS + "10.ico"));
            imageListSmall.Images.Add("11", Image.FromFile(PATH_ICONS + "11.ico"));
            imageListSmall.Images.Add("12", Image.FromFile(PATH_ICONS + "12.ico"));
            imageListSmall.Images.Add("13", Image.FromFile(PATH_ICONS + "13.ico"));
            imageListSmall.Images.Add("14", Image.FromFile(PATH_ICONS + "14.ico"));
            return imageListSmall;
        }


    }
}
