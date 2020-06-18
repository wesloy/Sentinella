using System;
using System.Windows.Forms;



namespace Sentinella {

    //	CREATE TABLE [dbo].[w_sysLogs] (
    //	    [id]              INT             IDENTITY (1, 1) NOT NULL,
    //	    [data]            DATETIME        DEFAULT (getdate()) NULL,
    //	    [idRede]          NVARCHAR (20)   NULL,
    //	    [idFerramenta]    NVARCHAR (20)   NULL,
    //	    [log]             NVARCHAR (1000) NULL,
    //	    [funcaoExecutada] NVARCHAR (255)  NULL,
    //	    [versaoSistema]   NVARCHAR (255)  NULL,
    //	    [idioma]          NCHAR (50)      NULL,
    //	    [hostname]        NCHAR (50)      NULL,
    //	    [ip]              NVARCHAR (30)   NULL,
    //	    [macAddress]      NVARCHAR (30)   NULL,
    //	    CONSTRAINT [PK_w_sysLogs] PRIMARY KEY CLUSTERED ([id] ASC)
    //	);

    class logs {

        #region Variaveis 
        string sql = "";
        long retorno = 0;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        #endregion

        #region Camada DTO - Entidades

        #region Atributos
        int _id;
        DateTime _data;
        string _idRede, _idFerramenta, _log, _funcaoExecutada, versaoSistema, _idioma, _hostname;
        string _ip, _macAddress;
        #endregion

        #region Propriedades

        private int Id {
            get {
                return _id;
            }

            set {
                _id = value;
            }
        }

        private DateTime Data {
            get {
                return hlp.dataHoraAtual();
            }

            set {
                _data = hlp.dataHoraAtual();
            }
        }

        private string IdRede {
            get {
                return Constantes.id_REDE_logadoFerramenta;
            }

            set {
                _idRede = Constantes.id_REDE_logadoFerramenta;
            }
        }

        private string Log {
            get {
                return _log;
            }

            set {
                if (value.Length > 1000) {
                    _log = value.Substring(0, 1000);
                } else {
                    _log = value.ToString();
                }
                
            }
        }

        private string FuncaoExecutada {
            get {
                return _funcaoExecutada;
            }

            set {
                _funcaoExecutada = value;
            }
        }

        private string VersaoSistema {
            get {
                return hlp.versaoSistema();
            }

            set {
                versaoSistema = hlp.versaoSistema();
            }
        }

        private string Idioma {
            get {
                return hlp.retornaIdiomaPC();
            }

            set {
                _idioma = hlp.retornaIdiomaPC();
            }
        }

        private string Hostname {
            get {
                return System.Environment.MachineName.ToString();
            }

            set {
                _hostname = System.Environment.MachineName.ToString();
            }
        }

        public string Ip {
            get {
                return hlp.capturaEnderecoIP();
            }

            set {
                _ip = value;
            }
        }

        public string MacAddress {
            get {
                return hlp.capturaMac();
            }

            set {
                _macAddress = value;
            }
        }

        public string IdFerramenta {
            get {
                return Constantes.id_REDE_logadoFerramenta;
            }

            set {
                _idFerramenta = value;
            }
        }
        #endregion

        #endregion

        #region CONSTRUTORES
        #endregion

        #region Camada DAL - DADOS

        private bool _incluir(logs obj) {
            try {

                sql = "insert into w_syslogs ( ";
                sql += "data, ";
                sql += "idRede, ";
                sql += "idFerramenta, ";
                sql += "log, ";
                sql += "funcaoExecutada, ";
                sql += "VersaoSistema, ";
                sql += "idioma, ";
                sql += "hostname, ";
                sql += "ip, ";
                sql += "macAddress) ";
                sql += "values ( ";
                sql += objCon.valorSql(obj.Data) + ", ";
                sql += objCon.valorSql(obj.IdRede) + ", ";
                sql += objCon.valorSql(obj.IdFerramenta) + ", ";
                sql += objCon.valorSql(hlp.removerCharEspecial(hlp.RemoverSimbolos(obj.Log))) + ", ";
                sql += objCon.valorSql(obj.FuncaoExecutada) + ", ";
                sql += objCon.valorSql(obj.VersaoSistema) + ", ";
                sql += objCon.valorSql(obj.Idioma) + ", ";
                sql += objCon.valorSql(obj.Hostname) + ", ";
                sql += objCon.valorSql(obj.Ip) + ", ";
                sql += objCon.valorSql(obj.MacAddress) + ") ";
                return objCon.executaQuery(sql, ref retorno);

            } catch {
                return false;
            }

        }
        #endregion

        #region Camada BLL - NEGOCIO
        public void registrarLog(string _log = "", string _funcaoExecutada = "") {
            try {
                logs log = new logs();
                log.Log = _log.ToString();
                log.FuncaoExecutada = _funcaoExecutada.ToString();
                log._incluir(log);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        #endregion


    }
}
