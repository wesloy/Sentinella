using System;
using System.Data;
using System.Windows.Forms;

namespace Sentinella {

    //	CREATE TABLE [dbo].[w_sysFinalizacoes] (
    //	    [id]              INT            IDENTITY (1, 1) NOT NULL,
    //	    [descricao]       NVARCHAR (100) NULL,
    //	    [ativo]           BIT            DEFAULT ((0)) NOT NULL,
    //	    [fila_id]         INT            NULL,
    //	    [geraNovoCaso]    BIT            DEFAULT ((0)) NOT NULL,
    //	    [agingNovoCaso]   INT            DEFAULT ((0)) NOT NULL,
    //	    [filaNovoCaso]    INT            DEFAULT ((0)) NOT NULL,
    //	    [dataAtualizacao] DATETIME       DEFAULT (getdate()) NULL,
    //	    [idAtualizacao]   NCHAR (10)     NULL
    //	);


    class finalizacoes {

        #region Variaves
        string sql = "";
        long retorno = 0;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        filas filas = new filas();
        #endregion

        #region Camada DTO - Entidades

        #region Atributos
        private int _id, _fila_id, _filaNovoCaso, _agingNovoCaso;
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
        public finalizacoes() {
            //Construtor vazio
        }

        public finalizacoes(bool _ativo, string _descricao, int _filaID, bool _geraNovoCaso, int _agingNovoCaso, int _filaNovoCaso, int _id = 0) {
            Id = _id;
            Ativo = _ativo;
            Descricao = _descricao;
            Fila_id = _filaID;
            GeraNovoCaso = _geraNovoCaso;
            AgingNovoCaso = _agingNovoCaso;
            FilaNovoCaso = _filaNovoCaso;
            DataAtualizacao = hlp.dataHoraAtual();
            IdAtualizacao = Constantes.idlogadoFerramenta;
        } 
        #endregion

        #region Camada DAL - Dados

        private bool _incluir(finalizacoes obj) {
            try {
                bool validacao = false;
                sql = "Insert into w_sysFinalizacoes ";
                sql += "(Descricao,";
                sql += "Ativo,";
                sql += "Fila_id,";
                sql += "GeraNovoCaso,";
                sql += "AgingNovoCaso, ";
                sql += "FilaNovoCaso, ";
                sql += "IdAtualizacao, ";
                sql += "DataAtualizacao) ";
                sql += "values( ";
                sql += objCon.valorSql(obj.Descricao) + ",";
                sql += objCon.valorSql(obj.Ativo) + ",";
                sql += objCon.valorSql(obj.Fila_id) + ",";
                sql += objCon.valorSql(obj.GeraNovoCaso) + ",";
                sql += objCon.valorSql(obj.AgingNovoCaso) + ", ";
                sql += objCon.valorSql(obj.FilaNovoCaso) + ", ";
                sql += objCon.valorSql(obj.IdAtualizacao) + ",";
                sql += objCon.valorSql(obj.DataAtualizacao) + ") ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando

                if (validacao) {
                    log.registrarLog("FINALIZACAO: " + obj.Descricao.ToString(), "FINALIZACAO - INCLUIR"); //regitrando log
                }

                return validacao; //retorno

            } catch (Exception ex) {

                log.registrarLog(ex.ToString(), "FINALIZACAO - INCLUIR(DAL)");
                return false;
            }

        }

        private bool _atualizar(finalizacoes obj) {
            try {
                bool validacao = false;
                sql = "Update w_sysFinalizacoes ";
                sql += "set Descricao = " + objCon.valorSql(obj.Descricao) + ",";
                sql += "Ativo = " + objCon.valorSql(obj.Ativo) + ",";
                sql += "Fila_id = " + objCon.valorSql(obj.Fila_id) + ",";
                sql += "GeraNovoCaso = " + objCon.valorSql(obj.GeraNovoCaso) + ",";
                sql += "AgingNovoCaso = " + objCon.valorSql(obj.AgingNovoCaso) + ",";
                sql += "FilaNovoCaso = " + objCon.valorSql(obj.FilaNovoCaso) + ",";
                sql += "IdAtualizacao = " + objCon.valorSql(obj.IdAtualizacao) + ",";
                sql += "DataAtualizacao = " + objCon.valorSql(obj.DataAtualizacao) + " ";
                sql += "where id = " + objCon.valorSql(obj.Id) + " ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando
                if (validacao) {
                    log.registrarLog("FINALIZACAO: " + obj.Descricao.ToString() + "/ ID: " + obj.Id.ToString(), "FINALIZACAO - ATUALIZAR"); //regitrando log
                }
                return validacao; //retorno

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FINALIZACAO - ATUALIZAR(DAL)");
                return false;
            }
        }

        private bool _deletar(finalizacoes obj) {
            try {
                bool validacao = false;

                //Validando se existe registros para a fila que foi solicitada exclusão.
                // se houver registros não se pode excluir.
                sql = "Select count(id) from w_base where finalizacao_id = " + objCon.valorSql(obj.Id) + " ";
                objCon.executaQuery(sql, ref retorno);
                if (retorno > 0) {
                    MessageBox.Show("A finalização " + obj.Descricao + ", possui registros vinculados. Ela não pode ser exluida, porém pode ser DESATIVDA.", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

                sql = "delete w_sysFinalizacoes ";
                sql += "where id = " + objCon.valorSql(obj.Id) + " ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando
                if (validacao) {
                    MessageBox.Show(obj.Descricao + " exluída com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    log.registrarLog("FINALIZACAO: " + obj.Descricao.ToString() + "/ ID: " + obj.Id.ToString(), "FINALIZACAO - DELETAR"); //regitrando log
                } else {
                    MessageBox.Show("Não foi possível exluir a finalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return validacao; //retorno

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FINALIZACAO - DELETAR(DAL)");
                return false;
            }
        }

        private bool valorDuplicado(finalizacoes obj) {
            try {
                sql = "Select * from w_sysFinalizacoes where descricao like " + objCon.valorSql(obj.Descricao) + " ";
                objCon.executaQuery(sql, ref retorno);
                if (retorno > 0) { return true; } else { return false; }

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FINALIZACAO - VALIDAR DUPLICADO");
                return false;
            }
        }


        public finalizacoes capturarFinalizacaoPorID(int _id) {
            try {
                DataTable dt = new DataTable();
                finalizacoes oDados = new finalizacoes();
                sql = "Select * from w_sysFinalizacoes where id like " + objCon.valorSql(_id) + " ";
                dt = objCon.retornaDataTable(sql);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow ln in dt.Rows) {
                        oDados.Id = int.Parse(ln["id"].ToString());
                        oDados.Ativo = bool.Parse(ln["ativo"].ToString());
                        oDados.Descricao = (ln["Descricao"].ToString());
                        oDados.Fila_id = int.Parse(ln["Fila_id"].ToString());
                        oDados.GeraNovoCaso = bool.Parse(ln["GeraNovoCaso"].ToString());
                        oDados.AgingNovoCaso = int.Parse(ln["AgingNovoCaso"].ToString());
                        oDados.FilaNovoCaso = int.Parse(ln["FilaNovoCaso"].ToString());
                        oDados.IdAtualizacao = (ln["IdAtualizacao"].ToString());
                        oDados.DataAtualizacao = DateTime.Parse(ln["DataAtualizacao"].ToString());

                    }

                    return oDados;
                } else { return null; }


            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FINALIZACAO - CAPTURAR FINALIZACAO POR ID");
                return null;
            }
        }

        private DataTable listarFinalizacoes(string filtro = "") {
            try {
                sql = "Select f.id, f.descricao as finalizacao, fl.id as idFila, fl.descricao as fila, f.geraNovoCaso, f.agingNovoCaso, fl_R.id as idFilaFUP, fl_R.descricao as FilaFUP, f.idAtualizacao, f.dataAtualizacao, f.ativo ";
                sql += "from w_sysFinalizacoes f inner join w_sysFilas fl on f.fila_id = fl.id left join w_sysFilas fl_R on f.filaNovoCaso = fl_R.id ";
                sql += "where f.descricao like '" + filtro + "%' order by f.id ";
                return objCon.retornaDataTable(sql);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FINALIZACAO - LISTA FINALIZACOES");
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
                lst.Columns.Add("FINALIZAÇÃO", 300, HorizontalAlignment.Left);
                lst.Columns.Add("ID FILA", 50, HorizontalAlignment.Left);
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
                log.registrarLog(ex.ToString(), "FINALIZACAO - LISTVIEW");
                return null;
            }

        }

        public bool incluir(finalizacoes obj) {
            try {
                if (!valorDuplicado(obj)) {
                    if (!_incluir(obj)) {
                        MessageBox.Show("Não foi possível criar a finalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    } else {
                        MessageBox.Show(obj.Descricao + " criada com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                } else {
                    MessageBox.Show("Esta finalização já está na base!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            } catch (Exception ex) {
                MessageBox.Show("Não foi possível criar a finalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "FINALIZACAO - INCLUIR(BLL)");
                return false;
            }
        }

        public bool atualizar(finalizacoes obj) {
            try {
                if (!_atualizar(obj)) {
                    MessageBox.Show("Não foi possível atualizar a finalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                } else {
                    MessageBox.Show(obj.Descricao + " atualizada com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Não foi possível atualizar a finalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "FINALIZACAO - ATUALIZAR(BLL)");
                return false;
            }
        }

        public bool excluir(finalizacoes obj) {
            try {
                if (!_deletar(obj)) {
                    return false;
                } else {
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Não foi possível exluir a finalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "FINALIZACAO - EXCLUIR(BLL)");
                return false;
            }
        }

        /// <summary>
        /// Utilizado para cadastros de finalizações
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="cbx"></param>
        /// <param name="apenasFinalizacoessAtivas"></param>
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
                log.registrarLog(ex.ToString(), "FINALIZACAO - CARREGAR COMBOBOX FILAS (BLL)");
            }

        }

        /// <summary>
        /// Utilizado para carregar os commbobox que terão as listas das finalizações
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="cbx"></param>
        /// <param name="filaID"></param>
        /// <param name="apenasFinalizacoessAtivas"></param>
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
                log.registrarLog(ex.ToString(), "FINALIZACAO - CARREGAR COMBOBOX FINALIZACOES (BLL)");
            }
        }

        /// <summary>
        /// Utilizado para validar se a finalização selecionada precisa de gerar ou não um novo caso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public finalizacoes validarFups(int id) {
            try {
                finalizacoes fin = new finalizacoes();
                fin = capturarFinalizacaoPorID(id);
                if (fin.GeraNovoCaso) {
                    return fin;
                } else {
                    return null;
                }
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FINALIZACAO - VALIDACAO DE FUP");
                return null;
            }
        }

        #endregion

    }
}
