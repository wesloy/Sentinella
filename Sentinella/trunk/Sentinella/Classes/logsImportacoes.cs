using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella {

    //	CREATE TABLE [dbo].[w_sysLogImportacao] (
    //	    [id]             INT            IDENTITY (1, 1) NOT NULL,
    //	    [acao]           NVARCHAR (50)  NULL,
    //	    [data_Hora]      DATETIME       NULL,
    //	    [fila_id]        INT            DEFAULT ((0)) NOT NULL,
    //	    [fila_nome]      NVARCHAR (50)  NULL,
    //	    [qtde_registros] INT            DEFAULT ((0)) NOT NULL,
    //	    [id_rede]        NVARCHAR (10)  NULL,
    //	    [hostname]       NVARCHAR (20)  NULL,
    //	    [ip]             NVARCHAR (20)  NULL,
    //	    [mac]            NVARCHAR (20)  NULL,
    //	    [versao_Sistema] NVARCHAR (255) NULL
    //	);

    class logsImportacoes {

        #region Variaveis 
        string sql = "";
        long retorno = 0;
        Uteis.Conexao objCon = new Uteis.Conexao(Uteis.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Uteis.Helpers hlp = new Uteis.Helpers();
        logs log = new logs();
        #endregion

        #region Camada DTO - ENTIDADES

        #region Atributos
        int _id;
        string _acao;
        DateTime _data_Hora;
        int _fila_id;
        string _fila_nome;
        long _qtde_registros;
        string id_rede;
        string hostname;
        string ip;
        string mac;
        string versao_Sistema;
        #endregion

        #region Propriedades
        public int Id {
            get {
                return _id;
            }

            set {
                _id = value;
            }
        }

        public string Acao {
            get {
                return _acao;
            }

            set {
                _acao = value;
            }
        }

        public DateTime Data_Hora {
            get {
                return _data_Hora;
            }

            set {
                _data_Hora = value;
            }
        }

        public int Fila_id {
            get {
                return _fila_id;
            }

            set {
                _fila_id = value;
            }
        }

        public string Fila_nome {
            get {
                return _fila_nome;
            }

            set {
                _fila_nome = hlp.desacentua(value).ToUpper().Trim();
            }
        }

        public long Qtde_registros {
            get {
                return _qtde_registros;
            }

            set {
                _qtde_registros = value;
            }
        }

        public string Id_rede {
            get {
                return id_rede;
            }

            set {
                id_rede = value;
            }
        }

        public string Hostname {
            get {
                return hostname;
            }

            set {
                hostname = value;
            }
        }

        public string Ip {
            get {
                return ip;
            }

            set {
                ip = value;
            }
        }

        public string Mac {
            get {
                return mac;
            }

            set {
                mac = value;
            }
        }

        public string Versao_Sistema {
            get {
                return versao_Sistema;
            }

            set {
                versao_Sistema = value;
            }
        }
        #endregion

        #endregion

        #region Construtores
        public logsImportacoes() {
            // CONSTRUTUOR VAZIO
        }
        public logsImportacoes(string _acao, DateTime _dataHora, int _filaID, string _filaNome, long _qtdeRegistros) {
            // CONSTRUTOR PARA INPUTS NA BASE
            Acao = _acao;
            Data_Hora = _dataHora;
            Fila_id = _filaID;
            Fila_nome = _filaNome;
            Qtde_registros = _qtdeRegistros;
            Id_rede = Constantes.id_REDE_logadoFerramenta;
            Hostname = hlp.capturaHostname();
            Ip = hlp.capturaEnderecoIP();
            Mac = hlp.capturaMac();
            versao_Sistema = hlp.versaoSistema();
        } 
        #endregion

        #region Camada DAL - DADOS

        private bool _incluir(logsImportacoes obj) {
            try {

                sql = "insert into w_sysLogImportacao ( ";
                sql += "Acao, ";
                sql += "Data_Hora, ";
                sql += "Fila_id, ";
                sql += "Fila_nome, ";
                sql += "Qtde_registros, ";
                sql += "Id_rede, ";
                sql += "Hostname, ";
                sql += "Ip, ";
                sql += "Mac, ";
                sql += "versao_Sistema) ";
                sql += "values ( ";
                sql += objCon.valorSql(obj.Acao) + ", ";
                sql += objCon.valorSql(obj.Data_Hora) + ", ";
                sql += objCon.valorSql(obj.Fila_id) + ", ";
                sql += objCon.valorSql(obj.Fila_nome) + ", ";
                sql += objCon.valorSql(obj.Qtde_registros) + ", ";
                sql += objCon.valorSql(obj.Id_rede) + ", ";
                sql += objCon.valorSql(obj.Hostname) + ", ";
                sql += objCon.valorSql(obj.Ip) + ", ";
                sql += objCon.valorSql(obj.Mac) + ", ";
                sql += objCon.valorSql(obj.versao_Sistema) + ") ";
                return objCon.executaQuery(sql, ref retorno);

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "LOGS IMPORTACAO - INCLUIR(DAL)");
                return false;
            }
        }

        private DataTable _listarLogs(string filtro = "") {
            try {
                sql = "Select * ";
                sql += "from w_sysLogImportacao ";
                //sql += "where data_hora >= dateadd(day,-30,getdate()) "; //últimos 30 dias
                sql += "Order by id desc";
                return objCon.retornaDataTable(sql);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "LOGS IMPORTACAO - LISTA DE LOGS(DAL)");
                return null;
            }
        }

        #endregion

        #region Camada BLL - Negocio
        public ListView CarregaListView(ListView lst, string filtro = "") {
            try {
                DataTable dt = new DataTable();
                dt = _listarLogs(filtro);
                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = false;
                lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("ID", 50, HorizontalAlignment.Center);
                lst.Columns.Add("AÇÃO", 130, HorizontalAlignment.Left);
                lst.Columns.Add("DATA HORA", 130, HorizontalAlignment.Left);
                lst.Columns.Add("FILA COD", 100, HorizontalAlignment.Center);
                lst.Columns.Add("FILA NOME", 150, HorizontalAlignment.Center);
                lst.Columns.Add("QTDE REGISTROS", 80, HorizontalAlignment.Center);
                lst.Columns.Add("ID REDE", 100, HorizontalAlignment.Center);
                lst.Columns.Add("HOSTNAME", 80, HorizontalAlignment.Center);
                lst.Columns.Add("IP", 80, HorizontalAlignment.Center);
                lst.Columns.Add("MAC", 80, HorizontalAlignment.Center);
                lst.Columns.Add("VERSÃO SISTEMA", 150, HorizontalAlignment.Center);
                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["id"].ToString();
                        item.SubItems.Add(linha["acao"].ToString());
                        item.SubItems.Add(linha["data_hora"].ToString());
                        item.SubItems.Add(linha["fila_id"].ToString());
                        item.SubItems.Add(linha["fila_nome"].ToString());
                        item.SubItems.Add(linha["qtde_registros"].ToString());
                        item.SubItems.Add(linha["id_rede"].ToString());
                        item.SubItems.Add(linha["hostname"].ToString());
                        item.SubItems.Add(linha["ip"].ToString());
                        item.SubItems.Add(linha["mac"].ToString());
                        item.SubItems.Add(linha["versao_sistema"].ToString());
                        lst.Items.Add(item);
                    }
                }
                return lst;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "LOGS IMPORTACAO - LISTVIEW(BLL)");
                return null;
            }

        }

        public bool incluir(logsImportacoes obj) {
            try {

                if (!_incluir(obj)) {
                    MessageBox.Show("Não foi possível registrar log da importação!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                } else {
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Não foi possível registrar log da importação!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "LOGS IMPORTACAO - LISTA DE LOGS(BLL)");
                return false;
            }
        }

        #endregion
    }
}
