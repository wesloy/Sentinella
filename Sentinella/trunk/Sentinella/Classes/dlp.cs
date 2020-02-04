using System;
using System.Data;
using System.Windows.Forms;

namespace Sentinella {
    class dlp {

        //	CREATE TABLE [dbo].[w_dlp] (
        //	    [id]                         INT            IDENTITY (1, 1) NOT NULL,
        //	    [generated_]                 DATETIME       NULL,
        //	    [received]                   DATETIME       NULL,
        //	    [severity]                   NVARCHAR (150) NULL,
        //	    [status_]                    NVARCHAR (150) NULL,
        //	    [manager]                    NVARCHAR (150) NULL,
        //	    [department]                 NVARCHAR (150) NULL,
        //	    [policy_]                    NVARCHAR (150) NULL,
        //	    [product_entity_endpoint]    NVARCHAR (150) NULL,
        //	    [product]                    NVARCHAR (150) NULL,
        //	    [product_endpoint_ip]        NVARCHAR (150) NULL,
        //	    [product_endpoint_mac]       NVARCHAR (150) NULL,
        //	    [managing_server]            NVARCHAR (150) NULL,
        //	    [endpoint_]                  NVARCHAR (150) NULL,
        //	    [incident_source_ad_account] VARCHAR (50)   DEFAULT ('N/I') NOT NULL,
        //	    [incident_source_sender]     NVARCHAR (150) NULL,
        //	    [website]                    NVARCHAR (MAX) NULL,
        //	    [recipient]                  NVARCHAR (MAX) NULL,
        //	    [subject_]                   NVARCHAR (MAX) NULL,
        //	    [file_location]              NVARCHAR (MAX) NULL,
        //	    [file_]                      NVARCHAR (MAX) NULL,
        //	    [file_data_size]             NVARCHAR (150) NULL,
        //	    [rule_]                      NVARCHAR (150) NULL,
        //	    [template]                   NVARCHAR (150) NULL,
        //	    [channel]                    NVARCHAR (150) NULL,
        //	    [destination]                NVARCHAR (MAX) NULL,
        //	    [action_]                    NVARCHAR (150) NULL,
        //	    [incidents]                  NVARCHAR (150) NULL,
        //	    [cloud_service_vendor]       NVARCHAR (150) NULL,
        //	    [chave_duplicidade]          NVARCHAR (MAX) NULL,
        //	    [matricula]                  NCHAR (10)     NULL,
        //	    [nome_completo]              NCHAR (200)    NULL,
        //	    [cpf]                        NVARCHAR (15)  NULL,
        //	    [data_importacao]            DATETIME       DEFAULT (getdate()) NULL,
        //	    [id_importacao]              NVARCHAR (150) NULL,
        //	    [id_tbl_trabalho]            INT            DEFAULT ((0)) NOT NULL,
        //	    [flag_trabalho]              BIT            DEFAULT ((0)) NOT NULL,
        //	    [id_fila_trabalho]           INT            DEFAULT ((0)) NOT NULL,
        //	    CONSTRAINT [PK_w_dlp] PRIMARY KEY CLUSTERED ([id] ASC)
        //	);


        #region Variaveis 
        string sql = "";
        long retorno = 0;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        #endregion

        #region Atributos
        public int id { get; set; }
        public string generated_ { get; set; }
        public string received { get; set; }
        public string severity { get; set; }
        public string status_ { get; set; }
        public string manager { get; set; }
        public string department { get; set; }
        public string policy_ { get; set; }
        public string product_entity_endpoint { get; set; }
        public string product { get; set; }
        public string product_endpoint_ip { get; set; }
        public string product_endpoint_mac { get; set; }
        public string managing_server { get; set; }
        public string endpoint_ { get; set; }
        public string incident_source_ad_account { get; set; }
        public string incident_source_sender { get; set; }
        public string website { get; set; }
        public string recipient { get; set; }
        public string subject_ { get; set; }
        public string file_location { get; set; }
        public string file_ { get; set; }
        public string file_data_size { get; set; }
        public string rule_ { get; set; }
        public string template { get; set; }
        public string channel { get; set; }
        public string destination { get; set; }
        public string action_ { get; set; }
        public string incidents { get; set; }
        public string cloud_service_vendor { get; set; }
        public string chave_duplicidade { get; set; }
        public string matricula { get; set; }
        public string nome_completo { get; set; }
        public string cpf { get; set; }
        public int id_fila_trabalho { get; set; }
        public DateTime data_importacao { get; set; }
        public string id_importacao { get; set; }

        #endregion

        #region Camada DAL - Dados
        private DataTable _listarTodosRegistrosPorIDBase(int _id) {
            try {
                sql = "Select * from w_dlp Where 1 = 1 ";
                sql += "and id_tbl_trabalho = " + objCon.valorSql(_id) + " ";
                sql += "and flag_trabalho = 0 ";
                sql += "Order by generated_ ";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DLP - LISTA DE REGISTROS POR ID TRABALHO (DAL)");
                return null;
            }
        }

        private bool _finalizarRegistrosTrabalhados(int _id_base) {
            try {
                sql = "Update w_dlp set ";
                sql += "flag_trabalho = 1";
                sql += "from w_dlp where id_tbl_trabalho = " + objCon.valorSql(_id_base) + " ";
                return objCon.executaQuery(sql, ref retorno);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DLP - FINALIZAR REGISTROS TRABALHADOS (DAL)");
                return false;
            }
        }

        #endregion

        #region Camada BLL - Negócio

        public bool finalizarRegistrosTrabalho(int _id_trabalho) {
            try {
                return _finalizarRegistrosTrabalhados(_id_trabalho);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DLP - FINALIZAR REGISTROS TRABALHADOS (BLL)");
                return false;
            }
        }

        public ListView CarregaListView(ListView lst, int _id) {
            try {
                DataTable dt = new DataTable();
                dt = _listarTodosRegistrosPorIDBase(_id);
                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = false;
                lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("DATA EVENTO", 150, HorizontalAlignment.Center);
                lst.Columns.Add("REGRA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("TEMPLATE", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DEPARTAMENTO", 300, HorizontalAlignment.Left);
                lst.Columns.Add("USUÁRIO REDE", 200, HorizontalAlignment.Left);
                lst.Columns.Add("NOME", 300, HorizontalAlignment.Left);
                lst.Columns.Add("ARQUIVO/SITE", 1000, HorizontalAlignment.Left);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = hlp.retornaDataTextBox(linha["generated_"].ToString());
                        item.SubItems.Add(linha["rule_"].ToString());
                        item.SubItems.Add(linha["template"].ToString());
                        if (string.IsNullOrEmpty(linha["department"].ToString())) {
                            item.SubItems.Add("");
                        } else {
                            item.SubItems.Add(linha["department"].ToString().Substring(0, 8));
                        }
                        item.SubItems.Add(linha["incident_source_ad_account"].ToString());
                        item.SubItems.Add(linha["nome_completo"].ToString());
                        item.SubItems.Add(linha["destination"].ToString());
                        item.ImageKey = "9";
                        lst.Items.Add(item);

                    }
                }
                return lst;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DLP - LISTVIEW (BLL)");
                return null;
            }
        }

        #endregion

    }
}
