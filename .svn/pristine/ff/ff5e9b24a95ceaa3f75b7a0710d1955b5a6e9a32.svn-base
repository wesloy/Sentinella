using System;
using System.Data;
using System.Windows.Forms;

namespace Sentinella {
    class tamnun {

        #region TABELAS TAMNUN
        // CREATE TABLE[dbo].[w_tamnun_base](
        //    [id] INT IDENTITY(1, 1) NOT NULL,
        //    [data_registro] DATETIME DEFAULT(getdate()) NULL,
        //    [fonte] NVARCHAR(100) NULL,
        //    [categoria] NVARCHAR(100) NULL,
        //    [caminho] NVARCHAR(MAX) NULL,
        //    [dominio] NVARCHAR(100) NULL,
        //    [id_rede] NVARCHAR(100) NULL,
        //    [cpf] NVARCHAR(15)  NULL,
        //    [nome_completo] NVARCHAR(150) NULL,
        //    [matricula] NVARCHAR(15)  NULL,
        //    [white_list] BIT DEFAULT((0)) NOT NULL,
        //    [data_importacao] DATETIME DEFAULT(getdate()) NULL,
        //    [id_importacao] NVARCHAR(150) NULL,
        //    [id_tbl_tamnun] INT DEFAULT((0)) NOT NULL,
        //    [nome_tbl_tamnun] NVARCHAR(150) NULL,
        //    [id_tbl_trabalho] INT DEFAULT((0)) NOT NULL,
        //    [flag_trabalho] BIT DEFAULT((0)) NOT NULL,
        //    [id_fila_trabalho] INT DEFAULT((0)) NOT NULL,
        //    CONSTRAINT[PK_w_tamnun_base] PRIMARY KEY CLUSTERED([id] ASC)
        //);

        //CREATE TABLE [dbo].[w_tamnun_filtros] (
        //   [id]              INT            IDENTITY (1, 1) NOT NULL,
        //   [fonte]           NVARCHAR (100) NULL,
        //   [categoria]       NVARCHAR (100) NULL,
        //   [valorBusca]      NVARCHAR (100) NULL,
        //   [ativo]           BIT            DEFAULT ((0)) NOT NULL,
        //   [dataAtualizacao] DATETIME       DEFAULT (getdate()) NULL,
        //   [idAtualizacao]   NCHAR (10)     NULL,
        //   CONSTRAINT [PK_w_tamnun_filtros] PRIMARY KEY CLUSTERED ([id] ASC)
        //;

        // CREATE TABLE [dbo].[w_tamnun_white_list] (
        //    [id]               INT            IDENTITY (1, 1) NOT NULL,
        //    [nome]             NVARCHAR (100) NULL,
        //    [matricula]        NVARCHAR (15)  NULL,
        //    [cpf]              NVARCHAR (15)  NULL,
        //    [id_rede]          NVARCHAR (25)  NULL,
        //    [cod_centro_custo] NVARCHAR (100) NULL,
        //    [centro_custo]     NVARCHAR (100) NULL,
        //    [cargo_associado]  NVARCHAR (100) NULL,
        //    [data_manutencao]  DATETIME       DEFAULT (getdate()) NULL,
        //    [id_manutencao]    INT            DEFAULT ((0)) NULL,
        //    CONSTRAINT [PK_w_tamnun_white_list] PRIMARY KEY CLUSTERED ([id] ASC)
        //);
        #endregion

        #region Variaveis 
        string sql = "";
        long retorno = 0;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        #endregion

        #region Camada DAL - Dados

        private DataTable _listarTodosRegistrosPorIDBase(int _id) {
            try {
                sql = "Select * from w_tamnun_base Where 1 = 1 ";
                sql += "and id_tbl_trabalho = " + objCon.valorSql(_id) + " ";
                sql += "and flag_trabalho = 0 ";
                sql += "Order by data_registro ";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - LISTA DE REGISTROS POR ID TRABALHO (DAL)");
                return null;
            }
        }

        private bool _finalizarRegistrosTrabalhados(int _id_base) {
            try {
                sql = "Update w_tamnun_base set ";
                sql += "flag_trabalho = 1";
                sql += "from w_tamnun_base where id_tbl_trabalho = " + objCon.valorSql(_id_base) + " ";
                return objCon.executaQuery(sql, ref retorno);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - FINALIZAR REGISTROS TRABALHADOS (DAL)");
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

        public ListView CarregaListView(ListView lst, int _id, ref string _nomeAssociadoTamnun) {
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
                lst.Columns.Add("FONTE", 150, HorizontalAlignment.Left);
                lst.Columns.Add("CATEGORIA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("CAMINHO", 500, HorizontalAlignment.Left);
                lst.Columns.Add("DOMINIO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("USUÁRIO REDE", 200, HorizontalAlignment.Left);
                lst.Columns.Add("CPF", 150, HorizontalAlignment.Left);
                lst.Columns.Add("NOME", 300, HorizontalAlignment.Left);
                lst.Columns.Add("MATRICULA", 150, HorizontalAlignment.Left);                

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = hlp.retornaDataTextBox(linha["data_registro"].ToString());
                        item.SubItems.Add(linha["fonte"].ToString());
                        item.SubItems.Add(linha["categoria"].ToString());
                        item.SubItems.Add(linha["caminho"].ToString());
                        item.SubItems.Add(linha["dominio"].ToString());
                        item.SubItems.Add(linha["id_rede"].ToString());
                        item.SubItems.Add(linha["cpf"].ToString());
                        item.SubItems.Add(linha["nome_completo"].ToString());
                        item.SubItems.Add(linha["matricula"].ToString());                        
                        item.ImageKey = "9";
                        lst.Items.Add(item);

                        _nomeAssociadoTamnun = linha["nome_completo"].ToString();
                    }
                }
                return lst;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - LISTVIEW (BLL)");
                return null;
            }
        }

        #endregion

    }
}
