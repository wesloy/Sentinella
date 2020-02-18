using System;
using System.Data;

namespace Sentinella {

    //	CREATE TABLE [dbo].[w_sysUsuariosVolParaTrabalho] (
    //	    [id]             INT            IDENTITY (1, 1) NOT NULL,    
    //	    [data_Hora]      DATETIME       NULL,
    //	    [fila_id]        INT            DEFAULT ((0)) NOT NULL,
    //	    [fila_nome]      NVARCHAR (50)  NULL,
    //	    [qtde_registros] INT            DEFAULT ((0)) NOT NULL,
    //	    [id_usuario]        INT   DEFAULT ((0)) NOT NULL 
    //	);


    class usuariosVolParaTrabalho {

        #region Variaveis 
        string sql = "";
        long retorno = 0;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        #endregion

        #region Atributos
        public int id { get; set; }
        public DateTime data_Hora { get; set; }
        public int fila_id { get; set; }
        public int qtde_registros { get; set; }
        public int id_usuario { get; set; }
        #endregion

        #region CONSTRUTORES
        public usuariosVolParaTrabalho() {
        }

        public usuariosVolParaTrabalho(DateTime _dtHora, int _idFila, int _qtdeRegistros, int _idUsuarios) {
            data_Hora = _dtHora;
            fila_id = _idFila;
            qtde_registros = _qtdeRegistros;
            id_usuario = _idUsuarios;
        }
        #endregion


        #region DAL

        private bool _valorDuplicado(usuariosVolParaTrabalho _dto) {
            try {

                sql = "Select * from w_sysUsuariosVolParaTrabalho ";
                sql += "where data_hora = " + objCon.valorSql(_dto.data_Hora) + " ";
                sql += "and fila_id = " + objCon.valorSql(_dto.fila_id) + " ";
                sql += "and id_usuario = " + objCon.valorSql(_dto.id_usuario) + " ";
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(sql);
                
                if (dt.Rows.Count > 0) {
                    dt = null;
                    return true; // duplicado
                } else {
                    dt = null;
                    return false; // novo registro
                }
            }
            catch (Exception ex) {

                log.registrarLog(ex.ToString(), "VOL REGISTROS POR USUARIO - VALIDACAO DUPLICIDADE (DAL)");
                return false;
            }
        }

        private bool _registrarVolume(usuariosVolParaTrabalho _dto) {
            try {

                if (_valorDuplicado(_dto)) {
                    return true; // registro duplicado. Não registra mas retorna TRUE pois não é erro.
                }

                sql = "Insert into w_sysUsuariosVolParaTrabalho (";
                sql += "data_hora, fila_id, qtde_registros, id_usuario) values (";
                sql += objCon.valorSql(_dto.data_Hora) + ", ";
                sql += objCon.valorSql(_dto.fila_id) + ", ";
                sql += objCon.valorSql(_dto.qtde_registros) + ", ";
                sql += objCon.valorSql(_dto.id_usuario) + ") ";
                return objCon.executaQuery(sql, ref retorno);
            }
            catch (Exception ex) {

                log.registrarLog(ex.ToString(), "VOL REGISTROS POR USUARIO - INSERT (DAL)");
                return false;
            }
        }

        private int _capturarVolPorFilaPorUsuario(usuariosVolParaTrabalho _dto) {
            try {
                sql = "select qtde_registros from sysUsuariosVolParaTrabalho where ";
                sql += "data_Hora = " + objCon.valorSql(_dto.data_Hora) + " and ";
                sql += "fila_id = " + objCon.valorSql(_dto.fila_id) + " and ";
                sql += "id_usuario = " + objCon.valorSql(_dto.id_usuario) + " ";
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(sql);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow item in dt.Rows) {
                        return int.Parse(item["qtde_registros"].ToString());
                    }
                } else {
                    return 0;
                }

                return 0;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "VOL REGISTROS POR USUARIO - CAPTURAR VOL POR USUARIO (DAL)");
                return 0;
            }

        }

        #endregion

        #region BLL
        public bool registrarVolume(usuariosVolParaTrabalho _dto) {
            try {

                return _registrarVolume(_dto);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "VOL REGISTROS POR USUARIO - INSERT (BLL)");
                return false;
            }

        }

        public int capturarVolPorFilaPorUsuario(usuariosVolParaTrabalho _dto) {
            try {
                return _capturarVolPorFilaPorUsuario(_dto);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "VOL REGISTROS POR USUARIO - CAPTURAR VOL POR USUARIO (BLL)");
                return 0;
            }

        }

        #endregion

    }
}
