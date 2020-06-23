using System;
using System.Data;
using System.Windows.Forms;

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
        public string _tempoInterrupcao { get; set; }
        public DateTime _dataHoraInicial { get; set; }
        public DateTime _dataHoraFinal { get; set; }
        public bool _ativo { get; set; }
        public DateTime _dataAtualizacao { get; set; }
        public int _idAtualizacao { get; set; }
        #endregion

        #region CONSTRUTORES
        public sys_interrupcoesProgramadas() { }
        public sys_interrupcoesProgramadas(int id, bool ativo, string mensagem, string tempoInterrupcao, DateTime dtHoraInicial, DateTime dtHoraFinal) {
            _id = id;
            _ativo = ativo;
            _mensagem = mensagem;
            _tempoInterrupcao = tempoInterrupcao;
            _dataHoraInicial = dtHoraInicial;
            _dataHoraFinal = dtHoraFinal;
            _idAtualizacao = Constantes.id_BD_logadoFerramenta;
            _dataAtualizacao = hlp.dataHoraAtual();
        }

        public sys_interrupcoesProgramadas(DataTable dt) {

            foreach (DataRow item in dt.Rows) {
                _id = int.Parse(item["id"].ToString());
                _ativo = bool.Parse(item["ativo"].ToString());
                _mensagem = item["mensagem"].ToString();
                _tempoInterrupcao = item["tempoInterrupcao"].ToString();
                _dataHoraInicial = DateTime.Parse(item["dataHoraInicial"].ToString());
                _dataHoraFinal = DateTime.Parse(item["dataHoraFinal"].ToString());
                _idAtualizacao = int.Parse(item["idAtualizacao"].ToString());
                _dataAtualizacao = DateTime.Parse(item["dataAtualizacao"].ToString());
            }

        }
        #endregion

        #region DAL
        private bool _insert(sys_interrupcoesProgramadas _obj) {
            try {

                sql = "insert into w_sysInterrupcaoProgramada ( " +
                           "mensagem, " +
                           "tempoInterrupcao, " +
                           "dataHoraInicial, " +
                           "dataHoraFinal, " +
                           "ativo, " +
                           "dataAtualizacao, " +
                           "idAtualizacao " +
                           ") values( " +
                            objCon.valorSql(_obj._mensagem) + ", " +
                            objCon.valorSql(_obj._tempoInterrupcao) + ", " +
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

        private sys_interrupcoesProgramadas _capturarObjPorId(int _id) {
            try {
                sql = "SELECT I.*, U.nome from w_sysInterrupcaoProgramada I inner join w_sysUsuarios U on I.idAtualizacao = U.id WHERE I.id = " + objCon.valorSql(_id) + " order by id desc";
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(sql);
                sys_interrupcoesProgramadas obj = new sys_interrupcoesProgramadas(dt);
                return obj;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - CAPTURAR OBJ POR ID (DAL)");
                return null;
            }
        }
        private bool _delete(sys_interrupcoesProgramadas _obj) {
            try {

                //registrando log
                log.registrarLog(_obj._tempoInterrupcao + " | ID INSERIU: " + _obj._idAtualizacao
                                    + " | DATA/HORA INICIAL: " + _obj._dataHoraInicial, "DELEÇÃO TEMPO INTERRUPCAO");


                sql = "Delete w_sysInterrupcaoProgramada " +
                           "Where id = " + objCon.valorSql(_obj._id) + " ";

                validacao = objCon.executaQuery(sql, ref retorno);
                return validacao; //retorno

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - DELETE (DAL)");
                return false;
            }
        }

        private bool _update(sys_interrupcoesProgramadas _obj) {
            try {

                sql = "Update w_sysInterrupcaoProgramada set " +
                           "mensagem = " + objCon.valorSql(_obj._mensagem) + ", " +
                           "tempoInterrupcao = " + objCon.valorSql(_obj._tempoInterrupcao) + ", " +
                           "dataHoraInicial = " + objCon.valorSql(_obj._dataHoraInicial) + ", " +
                           "dataHoraFinal = " + objCon.valorSql(_obj._dataHoraFinal) + ", " +
                           "ativo = " + objCon.valorSql(_obj._ativo) + ", " +
                           "dataAtualizacao = " + objCon.valorSql(_obj._dataAtualizacao) + ", " +
                           "idAtualizacao = " + objCon.valorSql(_obj._idAtualizacao) + " " +
                           "Where id = " + objCon.valorSql(_obj._id) + " ";

                validacao = objCon.executaQuery(sql, ref retorno);
                return validacao; //retorno

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - UPDATE (DAL)");
                return false;
            }
        }

        private DataTable _listar() {
            try {

                sql = "Select I.*, U.nome from w_sysInterrupcaoProgramada I inner join w_sysUsuarios U on I.idAtualizacao = U.id  order by id desc";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - LISTAR (DAL)");
                return null;
            }
        }

        private DataTable _capturarInterrupcao() {
            try {

                sql = "select * from w_sysInterrupcaoProgramada I " +
                            "where I.ativo = 1 ";
                //"and GETDATE() <= I.dataHoraFinal " +
                //"order by dataHoraFinal asc";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - CAPTURAR INTERRUPÇÃO (DAL)");
                return null;
            }
        }

        #endregion

        #region BLL
        private bool validacoes(sys_interrupcoesProgramadas _obj) {
            try {

                //01
                if (_obj._dataHoraInicial < hlp.dataHoraAtual()) {
                    MessageBox.Show("Inclusão/Alteração de interrupções devem ser futuras! " + Environment.NewLine +
                                        "Data/Hora interrupção menor que agora.", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                //02
                if (_obj._dataHoraInicial < hlp.dataHoraAtual().AddMinutes(5)) {
                    MessageBox.Show("Menor tempo para iniciar uma interrupeção é de " + hlp.dataHoraAtual().AddMinutes(5) + "!" + Environment.NewLine +
                                        "Tente outra vez alterando a data/hora inicial para um período de pelo menos 5 min após o momento atual.", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;

            }
            catch (Exception ex) {

                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - VALIDACOES (BLL)");
                return false;
            }
        }


        public bool insert(sys_interrupcoesProgramadas _obj) {
            try {

                if (!validacoes(_obj)) {
                    return false;
                }

                //Inserção
                if (_insert(_obj)) {
                    MessageBox.Show("Inclusão de interrupção programada criada com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                } else {
                    MessageBox.Show("Erro de inclusão de interrupção programada!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - INSERT (BLL)");
                return false;
            }
        }

        public bool update(sys_interrupcoesProgramadas _obj) {
            try {

                if (!validacoes(_obj)) {
                    return false;
                }

                if (_update(_obj)) {
                    MessageBox.Show("Atualização de interrupção programada realizada com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                } else {
                    MessageBox.Show("Erro de atualização de interrupção programada!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - UPDATE (BLL)");
                return false;
            }
        }

        public bool deletarPorId(int _id) {
            try {
                sys_interrupcoesProgramadas obj = new sys_interrupcoesProgramadas();
                obj = _capturarObjPorId(_id);

                if (_delete(obj)) {
                    MessageBox.Show("Deleção de interrupção programada realizada com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                } else {
                    MessageBox.Show("Erro durante a deleção da interrupção programada!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - DELETAR POR ID (BLL)");
                return false;
            }
        }

        public ListView CarregaListView(ListView lst) {
            try {
                DataTable dt = new DataTable();
                dt = _listar();
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
                lst.Columns.Add("MENSAGEM", 450, HorizontalAlignment.Left);
                lst.Columns.Add("TEMPO INTERRUPCAO", 250, HorizontalAlignment.Left);
                lst.Columns.Add("DATA/HORA INICIAL", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DATA/HORA FINAL", 150, HorizontalAlignment.Left);
                lst.Columns.Add("RESPONSÁVEL", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DATA/HORA INCLUSÃO", 200, HorizontalAlignment.Left);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["id"].ToString();
                        item.SubItems.Add(linha["mensagem"].ToString());
                        item.SubItems.Add(linha["tempoInterrupcao"].ToString());
                        item.SubItems.Add(linha["dataHoraInicial"].ToString());
                        item.SubItems.Add(linha["dataHoraFinal"].ToString());
                        item.SubItems.Add(linha["nome"].ToString());
                        item.SubItems.Add(linha["dataAtualizacao"].ToString());

                        if (linha["ativo"].Equals(false)) {
                            item.ImageKey = "3";
                        } else {
                            item.ImageKey = "1";
                        }
                        lst.Items.Add(item);
                    }
                }
                return lst;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - LISTVIEW (BLL)");
                return null;
            }
        }

        public sys_interrupcoesProgramadas capturarObjPorId(int _id) {
            try {
                return _capturarObjPorId(_id);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - CAPTURAR OBJ POR ID (BLL)");
                return null;
            }
        }

        public bool interromperSistema() {
            try {

                sys_interrupcoesProgramadas obj = new sys_interrupcoesProgramadas();
                DataTable dt = new DataTable();
                dt = _capturarInterrupcao();

                foreach (DataRow item in dt.Rows) {

                    obj = _capturarObjPorId(int.Parse(item["id"].ToString()));

                    //Desativar interrupções já ocorridas
                    if (DateTime.Parse(item["dataHoraFinal"].ToString()) < hlp.dataHoraAtual() && bool.Parse(item["ativo"].ToString())) {
                        obj._ativo = false;
                        _update(obj);
                    }


                    //Confirmar a interrupção, enviando info para fechar a aplicação ou não deixar abrir a aplicaçãof
                    if (hlp.dataHoraAtual()  >= DateTime.Parse(item["dataHoraInicial"].ToString()) && hlp.dataHoraAtual() <= DateTime.Parse(item["dataHoraFinal"].ToString()) ) {

                        hlp.AutoCloseMsgBox("O Sentinella está em período de interrupção programada." + Environment.NewLine +
                                            "Estará disponível após " + obj._dataHoraFinal + ".", Constantes.Titulo_MSG.ToString(), 5);

                        return true;
                    }

                    //Enviar msg de aviso para interrupções em alguns minutos à frente
                    //5 min antes do fechamento enviar msg
                    if (DateTime.Parse(item["dataHoraInicial"].ToString()).AddMinutes(5) > hlp.dataHoraAtual()) {

                        hlp.AutoCloseMsgBox("O Sentinella será fechado em instantes." + Environment.NewLine +
                                            "Fica a dica: Salve seu trabalho e feche você mesmo, pois depois de " + obj._dataHoraInicial + " será fechado automaticamente.", Constantes.Titulo_MSG.ToString(), 5);

                        return false;
                    }

                }

                return false;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SYS INTERRUPCOES PROGRAMADAS - INTERRUPCAO SISTEMA (BLL)");
                return false;
            }
        }





        #endregion

    }
}
