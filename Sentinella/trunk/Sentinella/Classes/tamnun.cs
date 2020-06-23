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
        bool validacao = false;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        #endregion
        
        #region CAMADA DTO
        public int _filtros_id { get; set; }
        public string _filtros_fonte { get; set; }
        public string _filtros_categoria { get; set; }
        public string _filtros_valorBusca { get; set; }
        public bool _filtros_ativo { get; set; }
        public DateTime _filtros_dataAtualizacao { get; set; }
        public int _filtros_idAtualizacao { get; set; }
        #endregion

        #region CONSTRUTORES

        public tamnun() {}

        public tamnun(int filtro_id, string filtros_fonte, string filtros_categoria, string filtros_valorBusca, bool filtros_ativo) {
            _filtros_id = filtro_id;
            _filtros_fonte = filtros_fonte;
            _filtros_categoria = filtros_categoria;
            _filtros_valorBusca = filtros_valorBusca;
            _filtros_ativo = filtros_ativo;
            _filtros_dataAtualizacao = hlp.dataHoraAtual();
            _filtros_idAtualizacao = Constantes.id_BD_logadoFerramenta;
        }

        public tamnun(DataTable dt) {

            foreach (DataRow item in dt.Rows) {
                _filtros_id = int.Parse(item["id"].ToString());
                _filtros_fonte = item["fonte"].ToString();
                _filtros_categoria = item["categoria"].ToString();
                _filtros_valorBusca = item["valorBusca"].ToString();
                _filtros_ativo = bool.Parse(item["ativo"].ToString());
                _filtros_dataAtualizacao = DateTime.Parse(item["dataAtualizacao"].ToString());
                _filtros_idAtualizacao = int.Parse(item["idAtualizacao"].ToString());                
            }

        }

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

        private DataTable _listarTodosFiltros(string _categoria) {
            try {
                sql = "Select f.*, u.nome from " + 
                    "w_tamnun_filtros f inner join w_sysUsuarios u on f.idAtualizacao = u.id Where 1 = 1 ";
                sql += "and categoria like " + objCon.valorSql(_categoria) + " ";
                sql += "Order by id asc ";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - LISTAR FILTROS (DAL)");
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

        private DataTable _listaCategorias() {
            try {
                sql = "select 1 id, categoria from w_tamnun_filtros group by categoria order by categoria";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - LISTAR CATEGORIAS (DAL)");
                return null;
            }
        }

        private DataTable _listaFontes() {
            try {
                sql = "select 1 id, fonte from w_tamnun_filtros group by fonte order by fonte";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - LISTAR FONTES (DAL)");
                return null;
            }
        }

        private bool _insertFiltro(tamnun _obj) {
            try {

                sql = "insert into w_tamnun_filtros ( " +
                           "fonte, " +
                           "categoria, " +
                           "valorBusca, " +
                           "ativo, " +                           
                           "dataAtualizacao, " +
                           "idAtualizacao " +
                           ") values ( " +
                            objCon.valorSql(_obj._filtros_fonte) + ", " +
                            objCon.valorSql(_obj._filtros_categoria) + ", " +
                            objCon.valorSql(_obj._filtros_valorBusca) + ", " +
                            objCon.valorSql(_obj._filtros_ativo) + ", " +
                            objCon.valorSql(_obj._filtros_dataAtualizacao) + ", " +
                            objCon.valorSql(_obj._filtros_idAtualizacao) + ") ";                            

                validacao = objCon.executaQuery(sql, ref retorno);
                return validacao; //retorno

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - INSERT FILTRO (DAL)");
                return false;
            }
        }

        private bool _updateFiltro(tamnun _obj) {
            try {

                sql = "Update w_tamnun_filtros set " +
                           "fonte = " + objCon.valorSql(_obj._filtros_fonte) + ", " +
                           "categoria = " + objCon.valorSql(_obj._filtros_categoria) + ", " +
                           "valorBusca = " + objCon.valorSql(_obj._filtros_valorBusca) + ", " +
                           "ativo = " + objCon.valorSql(_obj._filtros_ativo) + ", " +
                           "dataAtualizacao = " + objCon.valorSql(_obj._filtros_dataAtualizacao) + ", " +
                           "idAtualizacao = " + objCon.valorSql(_obj._filtros_idAtualizacao) + " " +                           
                           "Where id = " + objCon.valorSql(_obj._filtros_id) + " ";

                validacao = objCon.executaQuery(sql, ref retorno);
                return validacao; //retorno

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - UPDATE FILTRO (DAL)");
                return false;
            }
        }

        private bool _deleteFiltro(tamnun _obj) {
            try {

                //registrando log
                log.registrarLog("CATEGORIA: " + _obj._filtros_categoria + " | FILTRO: " + _obj._filtros_valorBusca + " | ID DELEÇÃO: " + _obj._filtros_idAtualizacao, "DELEÇÃO FILTRO TAMNUN");


                sql = "Delete w_tamnun_filtros " +
                           "Where id = " + objCon.valorSql(_obj._filtros_id) + " ";

                validacao = objCon.executaQuery(sql, ref retorno);
                return validacao; //retorno

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - DELETE FILTRO (DAL)");
                return false;
            }
        }

        private tamnun _capturarObjFiltroPorId(int _id) {
            try {
                sql = "SELECT I.*, U.nome from w_tamnun_filtros I inner join w_sysUsuarios U on I.idAtualizacao = U.id WHERE I.id = " + objCon.valorSql(_id) + " order by id desc";
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(sql);
                tamnun obj = new tamnun(dt);
                return obj;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - CAPTURAR OBJ FILTRO POR ID (DAL)");
                return null;
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

        public ListView carregarListViewListaTrabalho(ListView lst, int _id, ref string _nomeAssociadoTamnun) {
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
                        item.Text = hlp.retornaDataTextBox(linha["data_registro"].ToString()).Substring(0, 10);
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
                log.registrarLog(ex.ToString(), "TAMNUN - LISTVIEW LISTA TRABALHO (BLL)");
                return null;
            }
        }

        public ListView carregarListViewConfigFiltros(ListView lst, string categoria = "%") {
            try {
                DataTable dt = new DataTable();
                dt = _listarTodosFiltros(categoria);
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
                lst.Columns.Add("FONTE", 150, HorizontalAlignment.Left);
                lst.Columns.Add("CATEGORIA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("VALOR BUSCA", 500, HorizontalAlignment.Left);
                lst.Columns.Add("DATA ATUALIZAÇAO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("USUÁRIO ATUALIZOU", 200, HorizontalAlignment.Left);


                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["id"].ToString();
                        item.SubItems.Add(linha["fonte"].ToString());
                        item.SubItems.Add(linha["categoria"].ToString());
                        item.SubItems.Add(linha["valorBusca"].ToString());
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["dataAtualizacao"].ToString()));
                        item.SubItems.Add(linha["nome"].ToString());

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
                log.registrarLog(ex.ToString(), "TAMNUN - LISTVIEW CONFIG FILTROS (BLL)");
                return null;
            }
        }

        public void carregarComboboxCategorias(Form frm, ComboBox cbx) {
            DataTable dt = new DataTable();
            dt = _listaCategorias();
            hlp.carregaComboBox(dt, frm, cbx);
        }

        public void carregarComboboxFontes(Form frm, ComboBox cbx) {
            DataTable dt = new DataTable();
            dt = _listaFontes();
            hlp.carregaComboBox(dt, frm, cbx);
        }

        public bool insertFiltro(tamnun _obj) {
            try {

                //Inserção
                if (_insertFiltro(_obj)) {
                    MessageBox.Show("Inclusão de filtro com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                } else {
                    MessageBox.Show("Erro de inclusão de filtro!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - INSERT FILTRO (BLL)");
                return false;
            }
        }

        public bool updateFiltro(tamnun _obj) {
            try {

                if (_updateFiltro(_obj)) {
                    MessageBox.Show("Atualização de filtro realizada com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                } else {
                    MessageBox.Show("Erro de atualização de filtro!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - UPDATE FILTRO (BLL)");
                return false;
            }
        }

        public bool deletarFiltrorPorId(int _id) {
            try {
                tamnun obj = new tamnun();
                obj = _capturarObjFiltroPorId(_id);

                if (_deleteFiltro(obj)) {
                    MessageBox.Show("Deleção de filtro realizada com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                } else {
                    MessageBox.Show("Erro durante a deleção de filtro!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FILTRO - DELETAR FILTRO POR ID (BLL)");
                return false;
            }
        }

        public tamnun capturarObjFiltroPorId(int _id) {
            try {
                tamnun obj = new tamnun();
                obj = _capturarObjFiltroPorId(_id);
                return obj;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TAMNUN - CAPTURAR OBJ FILTRO POR ID (BLL)");
                return null;
            }
        }


        #endregion

    }
}
