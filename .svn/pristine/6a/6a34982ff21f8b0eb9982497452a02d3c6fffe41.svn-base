using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella {

    //	CREATE TABLE [dbo].[w_sysFilas] (
    //	    [id]              INT            IDENTITY (1, 1) NOT NULL,
    //	    [descricao]       NVARCHAR (100) NULL,
    //	    [grupo]           NVARCHAR (100) NULL,
    //	    [sla]             INT            DEFAULT ((1)) NOT NULL,
    //	    [regraNegocio]    NVARCHAR (500) NULL,
    //	    [ativo]           BIT            DEFAULT ((0)) NOT NULL,
    //	    [dataAtualizacao] DATETIME       DEFAULT (getdate()) NULL,
    //	    [idAtualizacao]   NCHAR (10)     NULL,
    //	    CONSTRAINT [PK_w_sysFilas] PRIMARY KEY CLUSTERED ([id] ASC)
    //	);


    class filas {

        #region Variaveis 
        string sql = "";
        long retorno = 0;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        #endregion

        #region Construtores
        public filas() {
            // construtor vazio
        }

        public filas(string _descricao, string _grupo, string _regraNegocio, bool _ativo, int _sla, int _id = 0) {
            Descricao = _descricao;
            Grupo = _grupo;
            RegraNegocio = _regraNegocio;
            Ativo = _ativo;
            Sla = _sla;
            DataAtualizacao = hlp.dataHoraAtual();
            IdAtualizacao = Constantes.idlogadoFerramenta;
            Id = _id;
        }
        #endregion

        #region Camada DTO - Entidades

        #region Atributos
        private int _id, _sla;
        private string _descricao, _grupo, _regraNegocio, _idAtualizacao;
        private bool _ativo;
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

        public int Sla {
            get {
                return _sla;
            }

            set { //SLA NÃO PODE SER MENOR OU IGUAL A ZERO
                if (value <= 0) { _sla = 1; } else { _sla = value; }
            }
        }

        public string Descricao {
            get {
                return _descricao.Trim();
            }

            set {
                _descricao = hlp.desacentua(value).ToUpper().Trim();
            }
        }

        public string Grupo {
            get {
                return _grupo.Trim();
            }

            set {
                _grupo = Convert.ToString(hlp.desacentua(value)).ToUpper().Trim();
            }
        }

        public string RegraNegocio {
            get {
                return _regraNegocio.Trim();
            }

            set {
                _regraNegocio = hlp.desacentua(value).ToUpper().Trim();
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

        private string IdAtualizacao {
            get {
                return _idAtualizacao.Trim();
            }

            set {
                _idAtualizacao = value.Trim();
            }
        }


        private DateTime DataAtualizacao {
            get {

                return _dataAtualizacao;
            }

            set {
                _dataAtualizacao = hlp.dataHoraAtual();
            }
        }

        #endregion

        #endregion        
        
        #region Camada DAL - Dados

        private bool _incluir(filas obj) {
            try {
                bool validacao = false;
                sql = "Insert into w_sysFilas ";
                sql += "(Descricao,";
                sql += "Grupo,";
                sql += "RegraNegocio,";
                sql += "Ativo,";
                sql += "Sla, ";
                sql += "IdAtualizacao, ";
                sql += "DataAtualizacao) ";
                sql += "values( ";
                sql += objCon.valorSql(obj.Descricao) + ",";
                sql += objCon.valorSql(obj.Grupo) + ",";
                sql += objCon.valorSql(obj.RegraNegocio) + ",";
                sql += objCon.valorSql(obj.Ativo) + ",";
                sql += objCon.valorSql(obj.Sla) + ", ";
                sql += objCon.valorSql(obj.IdAtualizacao) + ",";
                sql += objCon.valorSql(obj.DataAtualizacao) + ") ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando

                if (validacao) {
                    log.registrarLog("FILA: " + obj.Descricao.ToString(), "FILAS - INCLUIR"); //regitrando log
                }

                return validacao; //retorno

            } catch (Exception ex) {

                log.registrarLog(ex.ToString(), "FILAS - INCLUIR(DAL)");
                return false;
            }

        }

        private bool _atualizar(filas obj) {
            try {
                bool validacao = false;
                sql = "Update w_sysFilas ";
                sql += "set Descricao = " + objCon.valorSql(obj.Descricao) + ",";
                sql += "Grupo = " + objCon.valorSql(obj.Grupo) + ",";
                sql += "RegraNegocio = " + objCon.valorSql(obj.RegraNegocio) + ",";
                sql += "Ativo = " + objCon.valorSql(obj.Ativo) + ",";
                sql += "Sla = " + objCon.valorSql(obj.Sla) + ",";
                sql += "IdAtualizacao = " + objCon.valorSql(obj.IdAtualizacao) + ",";
                sql += "DataAtualizacao = " + objCon.valorSql(obj.DataAtualizacao) + " ";
                sql += "where id = " + objCon.valorSql(obj.Id) + " ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando
                if (validacao) {
                    log.registrarLog("FILA: " + obj.Descricao.ToString() + "/ ID: " + obj.Id.ToString(), "FILAS - ATUALIZAR"); //regitrando log
                }
                return validacao; //retorno

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FILAS - ATUALIZAR(DAL)");
                return false;
            }
        }


        private bool _deletar(filas obj) {
            try {
                bool validacao = false;

                //Validando se existe registros para a fila que foi solicitada exclusão.
                // se houver registros não se pode excluir.
                sql = "Select count(id) from w_base where fila_id = " + objCon.valorSql(obj.Id) + " ";
                objCon.executaQuery(sql, ref retorno);
                if (retorno > 0) {
                    MessageBox.Show("A Fila " + obj.Descricao + ", possui registros vinculados. Ela não pode ser exluida, porém pode ser DESATIVDA.", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

                sql = "delete w_sysFilas ";
                sql += "where id = " + objCon.valorSql(obj.Id) + " ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando
                if (validacao) {
                    MessageBox.Show(obj.Descricao + " exluída com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    log.registrarLog("FILA: " + obj.Descricao.ToString() + "/ ID: " + obj.Id.ToString(), "FILAS - DELETAR"); //regitrando log
                } else {
                    MessageBox.Show("Não foi possível exluir a fila, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return validacao; //retorno

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FILAS - DELETAR(DAL)");
                return false;
            }
        }


        private bool _valorDuplicado(filas obj) {
            try {
                sql = "Select * from w_sysfilas where descricao like " + objCon.valorSql(obj.Descricao) + " ";
                objCon.executaQuery(sql, ref retorno);
                if (retorno > 0) { return true; } else { return false; }

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FILAS - VALIDAR DUPLICADO (DAL)");
                return false;
            }
        }

        private filas _capturarFilaPorID(int _id) {
            try {
                DataTable dt = new DataTable();
                filas oDados = new filas();
                sql = "Select * from w_sysfilas where id like " + objCon.valorSql(_id) + " ";
                dt = objCon.retornaDataTable(sql);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow ln in dt.Rows) {                        
                        oDados.Id = int.Parse(ln["id"].ToString());
                        oDados.Ativo = bool.Parse(ln["ativo"].ToString());
                        oDados.Descricao = (ln["Descricao"].ToString());
                        oDados.Grupo = (ln["Grupo"].ToString());
                        oDados.Sla = int.Parse(ln["sla"].ToString());
                        oDados.RegraNegocio = (ln["RegraNegocio"].ToString());
                        oDados.IdAtualizacao = (ln["IdAtualizacao"].ToString());
                        oDados.DataAtualizacao = DateTime.Parse(ln["DataAtualizacao"].ToString());
                    }

                    return oDados;
                } else { return null; }


            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FILAS - CAPTURAR FILA POR ID (DAL)");
                return null;
            }
        }

        private DataTable _listarFilas(string filtro = "") {
            try {
                sql = "Select * from w_sysFilas where descricao like '" + filtro + "%' order by id ";
                return objCon.retornaDataTable(sql);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FILAS - LISTA DE FILAS (DAL)");
                return null;
            }
        }

        #endregion

        #region Camada BLL - Negocio

        public filas capturarFilaPorID(int _id) {
            try {
                return _capturarFilaPorID(_id);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FILAS - CAPTURAR FILA POR ID (BLL)");
                return null;
            }
        }

        public ListView CarregaListView(ListView lst, string filtro = "") {
            try {
                DataTable dt = new DataTable();
                dt = _listarFilas(filtro);
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
                lst.Columns.Add("FILA", 300, HorizontalAlignment.Left);
                lst.Columns.Add("GRUPO MIS", 150, HorizontalAlignment.Left);
                lst.Columns.Add("SLA", 80, HorizontalAlignment.Center);
                lst.Columns.Add("REGRA DE NEGÓCIO", 200, HorizontalAlignment.Left);
                lst.Columns.Add("ID ATUALIZAÇÃO", 150, HorizontalAlignment.Center);
                lst.Columns.Add("DATA ATUALIZAÇÃO", 150, HorizontalAlignment.Center);
                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem(); 
                        item.Text = linha["id"].ToString();
                        item.SubItems.Add(linha["descricao"].ToString());
                        item.SubItems.Add(linha["grupo"].ToString());
                        item.SubItems.Add(linha["sla"].ToString());
                        item.SubItems.Add(linha["regraNegocio"].ToString());
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
                log.registrarLog(ex.ToString(), "FILAS - LISTVIEW (BLL)");
                return null;
            }
        }

        public bool incluir(filas obj) {
            try {
                if (!_valorDuplicado(obj)) {
                    if (!_incluir(obj)) {
                        MessageBox.Show("Não foi possível criar a fila, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    } else {
                        MessageBox.Show(obj.Descricao + " criada com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                } else {
                    MessageBox.Show("Fila já está na base!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            } catch (Exception ex) {
                MessageBox.Show("Não foi possível criar a fila, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "FILAS - INCLUIR(BLL)");
                return false;
            }
        }

        public bool atualizar(filas obj) {
            try {
                if (!_atualizar(obj)) {
                    MessageBox.Show("Não foi possível atualizar a fila, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                } else {
                    MessageBox.Show(obj.Descricao + " atualizada com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Não foi possível atualizar a fila, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "FILAS - ATUALIZAR(BLL)");
                return false;
            }
        }

        public bool excluir(filas obj) {
            try {
                if (!_deletar(obj)) {
                    return false;
                } else {
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Não foi possível exluir a fila, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "FILAS - EXCLUIR(BLL)");
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
                MessageBox.Show("Não foi carregar a lista de Filas, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "FILAS - CARREGAR COMBOBOX (BLL)");                
            }

        }

        #endregion

    }
}
