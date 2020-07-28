using System;
using System.Data;
using System.Windows.Forms;

namespace Sentinella {

    //	CREATE TABLE [dbo].[w_sysSubFinalizacoes] (
    //	    [id]              INT            IDENTITY (1, 1) NOT NULL,
    //	    [descricao]       NVARCHAR (100) NOT NULL,
    //	    [ativo]           BIT            DEFAULT ((0)) NOT NULL,
    //	    [finalizacao_id]  INT            NULL,
    //	    [fila_id]         INT            NULL,
    //	    [geraNovoCaso]    BIT            DEFAULT ((0)) NOT NULL,
    //	    [agingNovoCaso]   INT            DEFAULT ((0)) NOT NULL,
    //	    [filaNovoCaso]    INT            DEFAULT ((0)) NULL,
    //	    [dataAtualizacao] DATETIME       DEFAULT (getdate()) NULL,
    //	    [idAtualizacao]   NCHAR (10)     NULL
    //	);

    class subFinalizacoes {

        #region Variaves
        string sql = "";
        long retorno = 0;
        Uteis.Conexao objCon = new Uteis.Conexao(Uteis.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Uteis.Helpers hlp = new Uteis.Helpers();
        logs log = new logs();
        filas filas = new filas();
        finalizacoes finalizacoes = new finalizacoes();
        #endregion

        #region Camada DTO - Entidades

        #region Atributos
        private int _id, _fila_id, _finalizacao_id, _filaNovoCaso, _agingNovoCaso;
        private string _descricao, _idAtualizacao;
        private bool _ativo, _geraNovoCaso;
        private DateTime _dataAtualizacao;
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

        public int Fila_id {
            get {
                return _fila_id;
            }

            set {
                _fila_id = value;
            }
        }

        public int Finalizacao_id {
            get {
                return _finalizacao_id;
            }

            set {
                _finalizacao_id = value;
            }
        }

        public int FilaNovoCaso {
            get {
                return _filaNovoCaso;
            }

            set {
                _filaNovoCaso = value;
            }
        }

        public int AgingNovoCaso {
            get {
                return _agingNovoCaso;
            }

            set {
                if (value < 0) { _agingNovoCaso = 0; } else { _agingNovoCaso = value; };
            }
        }

        public string Descricao {
            get {
                return _descricao;
            }

            set {
                _descricao = hlp.desacentua(value).ToUpper().Trim();
            }
        }

        public string IdAtualizacao {
            get {
                return _idAtualizacao;
            }

            set {
                _idAtualizacao = value.Trim().ToUpper();
            }
        }

        public bool Ativo {
            get {
                return _ativo;
            }

            set {
                _ativo = value;
            }
        }

        public bool GeraNovoCaso {
            get {
                return _geraNovoCaso;
            }

            set {
                _geraNovoCaso = value;
            }
        }

        public DateTime DataAtualizacao {
            get {
                return _dataAtualizacao;
            }

            set {
                _dataAtualizacao = hlp.dataHoraAtual();
            }
        }
        #endregion

        #endregion

        #region Construtores
        public subFinalizacoes() {
            //Construtor vazio
        }

        public subFinalizacoes(bool _ativo, string _descricao, int _filaID, int _finalizacaoID, bool _geraNovoCaso, int _agingNovoCaso, int _filaNovoCaso, int _id = 0) {
            Id = _id;
            Ativo = _ativo;
            Descricao = _descricao;
            Fila_id = _filaID;
            Finalizacao_id = _finalizacaoID;
            GeraNovoCaso = _geraNovoCaso;
            AgingNovoCaso = _agingNovoCaso;
            FilaNovoCaso = _filaNovoCaso;
            DataAtualizacao = hlp.dataHoraAtual();
            IdAtualizacao = Constantes.id_REDE_logadoFerramenta;
        } 
        #endregion

        #region Camada DAL - Dados

        private bool _incluir(subFinalizacoes obj) {
            try {
                bool validacao = false;
                sql = "Insert into w_sysSubFinalizacoes ";
                sql += "(Descricao,";
                sql += "Ativo,";
                sql += "Fila_id,";
                sql += "Finalizacao_id,";
                sql += "GeraNovoCaso,";
                sql += "AgingNovoCaso, ";
                sql += "FilaNovoCaso, ";
                sql += "IdAtualizacao, ";
                sql += "DataAtualizacao) ";
                sql += "values( ";
                sql += objCon.valorSql(obj.Descricao) + ",";
                sql += objCon.valorSql(obj.Ativo) + ",";
                sql += objCon.valorSql(obj.Fila_id) + ",";
                sql += objCon.valorSql(obj.Finalizacao_id) + ",";
                sql += objCon.valorSql(obj.GeraNovoCaso) + ",";
                sql += objCon.valorSql(obj.AgingNovoCaso) + ", ";
                sql += objCon.valorSql(obj.FilaNovoCaso) + ", ";
                sql += objCon.valorSql(obj.IdAtualizacao) + ",";
                sql += objCon.valorSql(obj.DataAtualizacao) + ") ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando

                if (validacao) {
                    log.registrarLog("SUBFINALIZAÇÃO: " + obj.Descricao.ToString(), "SUBFINALIZACAO - INCLUIR"); //regitrando log
                }

                return validacao; //retorno

            } catch (Exception ex) {

                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - INCLUIR(DAL)");
                return false;
            }

        }

        private bool _atualizar(subFinalizacoes obj) {
            try {
                bool validacao = false;
                sql = "Update w_sysSubFinalizacoes ";
                sql += "set Descricao = " + objCon.valorSql(obj.Descricao) + ",";
                sql += "Ativo = " + objCon.valorSql(obj.Ativo) + ",";
                sql += "Fila_id = " + objCon.valorSql(obj.Fila_id) + ",";
                sql += "Finalizacao_id = " + objCon.valorSql(obj.Finalizacao_id) + ",";
                sql += "GeraNovoCaso = " + objCon.valorSql(obj.GeraNovoCaso) + ",";
                sql += "AgingNovoCaso = " + objCon.valorSql(obj.AgingNovoCaso) + ",";
                sql += "FilaNovoCaso = " + objCon.valorSql(obj.FilaNovoCaso) + ",";
                sql += "IdAtualizacao = " + objCon.valorSql(obj.IdAtualizacao) + ",";
                sql += "DataAtualizacao = " + objCon.valorSql(obj.DataAtualizacao) + " ";
                sql += "where id = " + objCon.valorSql(obj.Id) + " ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando
                if (validacao) {
                    log.registrarLog("SUBFINALIZACAO: " + obj.Descricao.ToString() + "/ ID: " + obj.Id.ToString(), "SUBFINALIZACAO - ATUALIZAR"); //regitrando log
                }
                return validacao; //retorno

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - ATUALIZAR(DAL)");
                return false;
            }
        }

        private bool _deletar(subFinalizacoes obj) {
            try {
                bool validacao = false;

                //Validando se existe registros para a fila que foi solicitada exclusão.
                // se houver registros não se pode excluir.
                sql = "Select count(id) from w_base where subFinalizacao_id = " + objCon.valorSql(obj.Id) + " ";
                objCon.executaQuery(sql, ref retorno);
                if (retorno > 0) {
                    MessageBox.Show("A finalização " + obj.Descricao + ", possui registros vinculados. Ela não pode ser exluida, porém pode ser DESATIVDA.", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

                sql = "delete w_sysSubFinalizacoes ";
                sql += "where id = " + objCon.valorSql(obj.Id) + " ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando
                if (validacao) {
                    MessageBox.Show(obj.Descricao + " exluída com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    log.registrarLog("SUBFINALIZACAO: " + obj.Descricao.ToString() + "/ ID: " + obj.Id.ToString(), "SUBFINALIZACAO - DELETAR"); //regitrando log
                } else {
                    MessageBox.Show("Não foi possível exluir a finalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return validacao; //retorno

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - DELETAR(DAL)");
                return false;
            }
        }

        private bool valorDuplicado(subFinalizacoes obj) {
            try {
                sql = "Select * from w_sysSubFinalizacoes where descricao like " + objCon.valorSql(obj.Descricao) + " ";
                objCon.executaQuery(sql, ref retorno);
                if (retorno > 0) { return true; } else { return false; }

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - VALIDAR DUPLICADO");
                return false;
            }
        }


        public subFinalizacoes capturarSubFinalizacaoPorID(int _id) {
            try {
                DataTable dt = new DataTable();
                subFinalizacoes oDados = new subFinalizacoes();
                sql = "Select * from w_sysSubFinalizacoes where id like " + objCon.valorSql(_id) + " ";
                dt = objCon.retornaDataTable(sql);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow ln in dt.Rows) {
                        ;
                        oDados.Id = int.Parse(ln["id"].ToString());
                        oDados.Ativo = bool.Parse(ln["ativo"].ToString());
                        oDados.Descricao = (ln["Descricao"].ToString());
                        oDados.Fila_id = int.Parse(ln["Fila_id"].ToString());
                        oDados.Finalizacao_id = int.Parse(ln["Finalizacao_id"].ToString());
                        oDados.GeraNovoCaso = bool.Parse(ln["GeraNovoCaso"].ToString());
                        oDados.AgingNovoCaso = int.Parse(ln["AgingNovoCaso"].ToString());
                        oDados.FilaNovoCaso = int.Parse(ln["FilaNovoCaso"].ToString());
                        oDados.IdAtualizacao = (ln["IdAtualizacao"].ToString());
                        oDados.DataAtualizacao = DateTime.Parse(ln["DataAtualizacao"].ToString());

                    }

                    return oDados;
                } else { return null; }


            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - CAPTURAR FINALIZACAO POR ID");
                return null;
            }
        }

        private DataTable listarFinalizacoes(string filtro = "") {
            try {
                sql = "Select sf.id, sf.descricao as subfinalizacao, f.id as idFinalizacao, f.descricao as finalizacao, fl.id as idFila, fl.descricao as fila, sf.geraNovoCaso, sf.agingNovoCaso, fl_R.id as idFilaFUP, fl_R.descricao as FilaFUP, sf.idAtualizacao, sf.dataAtualizacao, sf.ativo ";
                sql += "from w_sysSubFinalizacoes sf inner join w_sysFilas fl on sf.fila_id = fl.id left join w_sysFinalizacoes f on sf.finalizacao_id = f.id left join w_sysFilas fl_R on sf.filaNovoCaso = fl_R.id  ";
                sql += "where sf.descricao like '" + filtro + "%' order by f.id ";
                return objCon.retornaDataTable(sql);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - LISTA SUBFINALIZACOES");
                return null;
            }
        }

        #endregion

        #region Camada BLL - Negocio
        public ListView CarregaListView(ListView lst, string filtro = "") {
            try {
                DataTable dt = new DataTable();
                dt = listarFinalizacoes(filtro);
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
                lst.Columns.Add("SUBFINALIZAÇÃO", 300, HorizontalAlignment.Left);
                lst.Columns.Add("ID FINALIZAÇÃO", 100, HorizontalAlignment.Center);
                lst.Columns.Add("FINALIZAÇÃO", 300, HorizontalAlignment.Left);
                lst.Columns.Add("ID FILA", 100, HorizontalAlignment.Center);
                lst.Columns.Add("FILA", 300, HorizontalAlignment.Left);
                lst.Columns.Add("GERAR FUP", 80, HorizontalAlignment.Center);
                lst.Columns.Add("DIAS PARA RETORNO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("ID FILA RETORNO", 100, HorizontalAlignment.Center);
                lst.Columns.Add("FILA DE RETORNO", 300, HorizontalAlignment.Left);
                lst.Columns.Add("ID ATUALIZAÇÃO", 150, HorizontalAlignment.Center);
                lst.Columns.Add("DATA ATUALIZAÇÃO", 150, HorizontalAlignment.Center);
                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["id"].ToString();
                        item.SubItems.Add(linha["subfinalizacao"].ToString());
                        item.SubItems.Add(linha["idfinalizacao"].ToString());
                        item.SubItems.Add(linha["finalizacao"].ToString());
                        item.SubItems.Add(linha["idFila"].ToString());
                        item.SubItems.Add(linha["fila"].ToString());
                        item.SubItems.Add(linha["geraNovoCaso"].ToString());
                        item.SubItems.Add(linha["agingNovoCaso"].ToString());
                        item.SubItems.Add(linha["idFilaFUP"].ToString());
                        item.SubItems.Add(linha["FilaFUP"].ToString());
                        item.SubItems.Add(linha["idAtualizacao"].ToString());
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
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - LISTVIEW");
                return null;
            }

        }

        public bool incluir(subFinalizacoes obj) {
            try {
                if (!valorDuplicado(obj)) {
                    if (!_incluir(obj)) {
                        MessageBox.Show("Não foi possível criar a subfinalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    } else {
                        MessageBox.Show(obj.Descricao + " criada com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                } else {
                    MessageBox.Show("Esta subfinalização já está na base!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            } catch (Exception ex) {
                MessageBox.Show("Não foi possível criar a subfinalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - INCLUIR(BLL)");
                return false;
            }
        }

        public bool atualizar(subFinalizacoes obj) {
            try {
                if (!_atualizar(obj)) {
                    MessageBox.Show("Não foi possível atualizar a subfinalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                } else {
                    MessageBox.Show(obj.Descricao + " atualizada com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Não foi possível atualizar a subfinalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - ATUALIZAR(BLL)");
                return false;
            }
        }

        public bool excluir(subFinalizacoes obj) {
            try {
                if (!_deletar(obj)) {
                    return false;
                } else {
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Não foi possível exluir a subfinalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - EXCLUIR(BLL)");
                return false;
            }
        }

        public void carregarComboboxFilas(Form frm, ComboBox cbx, bool apenasFilasAtivas = true) {
            try {
                DataTable dt = new DataTable();
                sql = "Select id, descricao from w_sysFilas ";
                if (apenasFilasAtivas) {
                    sql += "where ativo = 1";
                }
                sql += "order by id";
                dt = objCon.retornaDataTable(sql);
                hlp.carregaComboBox(dt, frm, cbx, false, "", "", true);
            } catch (Exception ex) {
                MessageBox.Show("Não foi carregar a lista de filas ativas, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - CARREGAR COMBOBOX FILAS (BLL)");
            }
        }

        public void carregarComboboxFinalizacoes(Form frm, ComboBox cbx, int filaID, bool apenasFinalizacoessAtivas = true) {
            try {
                DataTable dt = new DataTable();
                sql = "Select id, descricao from w_sysFinalizacoes where fila_id = " + filaID + " ";
                if (apenasFinalizacoessAtivas) {
                    sql += "and ativo = 1";
                }
                sql += "order by id";
                dt = objCon.retornaDataTable(sql);
                hlp.carregaComboBox(dt, frm, cbx, false, "", "", true);
            } catch (Exception ex) {
                MessageBox.Show("Não foi carregar a lista de finalizações ativas, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - CARREGAR COMBOBOX FINALIZACOES (BLL)");
            }
        }

        public void carregarComboboxSubFinalizacoes(Form frm, ComboBox cbx, int finalizacaoID, bool apenasSubFinalizacoessAtivas = true) {
            try {
                DataTable dt = new DataTable();
                sql = "Select id, descricao from w_sysSubFinalizacoes where finalizacao_id = " + finalizacaoID + " ";
                if (apenasSubFinalizacoessAtivas) {
                    sql += "and ativo = 1";
                }
                sql += "order by id";
                dt = objCon.retornaDataTable(sql);
                hlp.carregaComboBox(dt, frm, cbx, false, "", "", true);
            } catch (Exception ex) {
                MessageBox.Show("Não foi carregar a lista de subfinalizações ativas, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - CARREGAR COMBOBOX SUBFINALIZACOES (BLL)");
            }
        }

        /// <summary>
        /// Utilizado para validar se a subfinalização selecionada precisa de gerar ou não um novo caso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public subFinalizacoes validarFups(int id) {
            try {
                subFinalizacoes subFin = new subFinalizacoes();
                subFin = capturarSubFinalizacaoPorID(id);
                if (subFin.GeraNovoCaso) {
                    return subFin;
                } else {
                    return null;
                }
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "SUBFINALIZACAO - VALIDACAO DE FUP");
                return null;
            }
        }

        #endregion

    }
}
