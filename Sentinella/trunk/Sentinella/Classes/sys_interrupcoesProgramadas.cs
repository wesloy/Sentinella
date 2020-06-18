using System;

namespace Sentinella {
    class sys_interrupcoesProgramadas {


        //CREATE TABLE [dbo].[w_sysInterrupcaoProgramada] (
        //    [id]              INT            IDENTITY (1, 1) NOT NULL,
        //    [mensagem]        NVARCHAR (100) NULL,
        //    [dataHoraInicial] DATETIME       DEFAULT (getdate()) NULL,
        //    [dataHoraFinal]   DATETIME       DEFAULT (getdate()) NULL,
        //    [ativo]           BIT            DEFAULT ((0)) NOT NULL,
        //    [dataAtualizacao] DATETIME       DEFAULT (getdate()) NULL,
        //    [idAtualizacao]   NVARCHAR (150) NULL,
        //    CONSTRAINT [PK_w_sysInterrupcaoProgramada] PRIMARY KEY CLUSTERED ([id] ASC)
        //);


        #region VARIÁVEIS
        string sql = "";
        long retorno = 0;
        bool validacao = false;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        #endregion

        #region DTO
        public int _id { get; set; }
        public string _mensagem { get; set; }
        public DateTime _dataHoraInicial { get; set; }
        public DateTime _dataHoraFinal { get; set; }
        public bool _ativo { get; set; }
        public DateTime _dataAtualizacao { get; set; }
        public int _idAtualizacao { get; set; }
        #endregion

        #region CONSTRUTORES
        public sys_interrupcoesProgramadas() { }
        #endregion

        #region DAL
        private bool _insert(sys_interrupcoesProgramadas _obj) {
            try {

                sql = "insert into w_sysInterrupcaoProgramada ( " +                           
                           "mensagem, " +
                           "dataHoraInicial, " +
                           "dataHoraFinal, " +
                           "ativo, " +
                           "dataAtualizacao, " +
                           "idAtualizacao " +
                           ") values( " +                            
                            objCon.valorSql(_obj._mensagem) + ", " +
                            objCon.valorSql(_obj._dataHoraInicial) + ", " +
                            objCon.valorSql(_obj._dataHoraFinal) + ", " +
                            objCon.valorSql(_obj._ativo) + ", " +
                            objCon.valorSql(_obj._dataAtualizacao) + ", " +
                            objCon.valorSql(_obj._idAtualizacao) + ") ";

                validacao = objCon.executaQuery(sql, ref retorno);
                return validacao; //retorno

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - INSERT (DAL)");
                return false;
            }
        }

        private bool _update(sys_interrupcoesProgramadas _obj) {
            try {

                sql = "Update into w_sysInterrupcaoProgramada set " +
                           "mensagem = " + objCon.valorSql(_obj._mensagem) + ", " +
                           "dataHoraInicial = " + objCon.valorSql(_obj._dataHoraInicial) + ", " +
                           "dataHoraFinal = " + objCon.valorSql(_obj._dataHoraFinal) + ", " +
                           "ativo = " + objCon.valorSql(_obj._ativo) + ", " +
                           "dataAtualizacao = " + objCon.valorSql(_obj._dataAtualizacao) + ", " +
                           "idAtualizacao = " + objCon.valorSql(_obj._idAtualizacao) + ") ";


                validacao = objCon.executaQuery(sql, ref retorno);
                return validacao; //retorno

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - INSERT (DAL)");
                return false;
            }
        }

        #endregion

        #region BLL
        #endregion

    }
}
