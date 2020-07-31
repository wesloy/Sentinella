﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Sentinella {

    //	CREATE TABLE [dbo].[w_sysUsuarios] (
    //	    [id]              INT            IDENTITY (1, 1) NOT NULL,
    //	    [idRede]          NVARCHAR (20)  DEFAULT ('SEM INFO') NOT NULL,
    //	    [idRedeBRA]          NVARCHAR (20)  DEFAULT ('SEM INFO') NOT NULL,
    //	    [ativo]           BIT            DEFAULT ((0)) NOT NULL,
    //	    [nome]            NVARCHAR (100) NULL,
    //	    [perfilAcesso]    INT            DEFAULT ((0)) NOT NULL,
    //	    [online]          BIT            DEFAULT ((0)) NOT NULL,
    //	    [ultimoAcesso]    DATETIME       DEFAULT (getdate()) NOT NULL,
    //	    [dataModificacao] DATETIME       DEFAULT (getdate()) NULL,
    //	    [idModificacao]   NCHAR (10)     NULL,
    //	    CONSTRAINT [PK_w_sysUsuarios] PRIMARY KEY CLUSTERED ([id] ASC)
    //	);

    //	CREATE TABLE [dbo].[w_sysUsuariosPerfilDeAcesso] (
    //	    [id]           INT           IDENTITY (1, 1) NOT NULL,
    //	    [perfilAcesso] NVARCHAR (50) NULL,
    //	    CONSTRAINT [PK_w_usuariosPerfilDeAcesso] PRIMARY KEY CLUSTERED ([id] ASC)
    //	);

    class usuarios {

        #region Variaveis 
        string sql = "";
        long retorno = 0;
        Uteis.Conexao objCon = new Uteis.Conexao(Uteis.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Uteis.Helpers hlp = new Uteis.Helpers();
        logs log = new logs();        
        #endregion

        #region Camada DTO - Entidades

        #region Atributos
        int _id;
        string _idRede;
        string _idRedeBRA;
        bool _ativo;
        string _nome;
        int _perfilAcesso;
        bool _online;
        DateTime _ultimoAcesso;
        DateTime _dataModificacao;
        string _idModificacao;
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

        public string IdRede {
            get {
                return _idRede;
            }

            set {
                _idRede = hlp.desacentua(value).ToUpper().Trim();
            }
        }
        public string IdRedeBRA {
            get {
                return _idRedeBRA;
            }

            set {
                _idRedeBRA = hlp.desacentua(value).ToUpper().Trim();
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

        public string Nome {
            get {
                return _nome;
            }

            set {
                _nome = hlp.desacentua(value).ToUpper().Trim();
            }
        }

        public int PerfilAcesso {
            get {
                return _perfilAcesso;
            }

            set {
                _perfilAcesso = value;
            }
        }

        public bool Online {
            get {
                return _online;
            }

            set {
                _online = value;
            }
        }

        public DateTime UltimoAcesso {
            get {
                return _ultimoAcesso;
            }

            set {
                _ultimoAcesso = value;
            }
        }

        public DateTime DataModificacao {
            get {
                return _dataModificacao;
            }

            set {
                _dataModificacao = value;
            }
        }

        public string IdModificacao {
            get {
                return _idModificacao;
            }

            set {
                _idModificacao = value;
            }
        }
        #endregion

        #endregion

        #region Construtores
        public usuarios() {
            //Construtor vazio
        }

        public usuarios(bool online) {
            //Utilizado para logar e deslogar na ferramenta            
            Online = online;
            IdRede = Constantes.id_REDE_logadoFerramenta;
            UltimoAcesso = hlp.dataHoraAtual();
        }

        public usuarios(int id, string idRede, string idRedeBRA, bool ativo, string nome, int perfilAcesso) {
            //usado para o CRUD
            Id = id;
            IdRede = idRede;
            IdRedeBRA = idRedeBRA;
            Ativo = ativo;
            Nome = nome;
            PerfilAcesso = perfilAcesso;
            DataModificacao = hlp.dataHoraAtual();
            IdModificacao = Constantes.id_REDE_logadoFerramenta;
        } 
        #endregion

        #region Camada DAL - Dados

        /// <summary>
        /// O nível de acesso dos usuários do Sentinella está numa escala em que qto maior o número mais privilégios, sendo que 0 não possui acesso.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int _autenticacao(usuarios obj) {
            try {
                DataTable dt = new DataTable();
                int nivelAcesso = 0;
                sql = "Select perfilAcesso as PA from w_sysUsuarios where ativo = 1 and " + 
                                "(idRede = " + objCon.valorSql(obj.IdRede) + 
                                " or idRedeBRA like " + objCon.valorSql(IdRede) + ") ";
                dt = objCon.retornaDataTable(sql);
                if (dt.Rows.Count > 0) {
                    foreach (DataRow ln in dt.Rows) {
                        nivelAcesso = int.Parse(ln["PA"].ToString());
                    }
                } else {
                    nivelAcesso = 0;
                }
                return nivelAcesso;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "USUARIO - AUTENTICAR(DAL)");
                return 0;
            }

        }

        /// <summary>
        /// Informar se o usuário está com o Sentinella aperto (Online) ou fechado (Offline)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>        
        private bool _on_off(usuarios obj) {
            try {
                sql = "Update w_sysUsuarios set ";
                sql += "online = " + objCon.valorSql(obj.Online) + ", ";
                sql += "UltimoAcesso = " + objCon.valorSql(obj.UltimoAcesso) + " ";
                sql += "Where idRede = " + objCon.valorSql(obj.IdRede) + " ";
                return objCon.executaQuery(sql, ref retorno);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "USUARIO - ON_OFF(DAL)");
                return false;
            }
        }

        private bool _incluir(usuarios obj) {
            try {
                bool validacao = false;
                sql = "Insert into w_sysUsuarios ";
                sql += "(IdRede,";
                sql += "IdRedeBRA,";
                sql += "Ativo,";
                sql += "Nome,";
                sql += "PerfilAcesso,";
                sql += "DataModificacao, ";
                sql += "IdModificacao) ";
                sql += "values( ";
                sql += objCon.valorSql(obj.IdRede) + ",";
                sql += objCon.valorSql(obj.IdRedeBRA) + ",";
                sql += objCon.valorSql(obj.Ativo) + ",";
                sql += objCon.valorSql(obj.Nome) + ",";
                sql += objCon.valorSql(obj.PerfilAcesso) + ",";
                sql += objCon.valorSql(obj.DataModificacao) + ",";
                sql += objCon.valorSql(obj.IdModificacao) + ") ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando

                if (validacao) {
                    log.registrarLog("USUARIO: " + obj.IdRede.ToString() + " | " + obj.Nome.ToString(), "USUARIO - INCLUIR"); //regitrando log
                }
                return validacao; //retorno

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "USUARIO - INCLUIR(DAL)");
                return false;
            }

        }

        private bool _atualizar(usuarios obj) {
            try {
                bool validacao = false;
                sql = "Update w_sysUsuarios ";
                sql += "set IdRede = " + objCon.valorSql(obj.IdRede) + ",";
                sql += "IdRedeBRA = " + objCon.valorSql(obj.IdRedeBRA) + ",";
                sql += "Ativo = " + objCon.valorSql(obj.Ativo) + ",";
                sql += "Nome = " + objCon.valorSql(obj.Nome) + ",";
                sql += "PerfilAcesso = " + objCon.valorSql(obj.PerfilAcesso) + ",";
                sql += "DataModificacao = " + objCon.valorSql(obj.DataModificacao) + ",";
                sql += "IdModificacao = " + objCon.valorSql(obj.IdModificacao) + " ";
                sql += "where id = " + objCon.valorSql(obj.Id) + " ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando
                if (validacao) {
                    log.registrarLog("USUARIO: " + obj.IdRede.ToString() + "| ID: " + obj.Id.ToString(), "USUARIO - ATUALIZAR"); //regitrando log
                }
                return validacao; //retorno

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "USUARIO - ATUALIZAR(DAL)");
                return false;
            }
        }

        private bool _deletar(usuarios obj) {
            try {
                bool validacao = false;

                //Validando se existe registros para a fila que foi solicitada exclusão.
                // se houver registros não se pode excluir.
                sql = "Select count(id) from w_base where idCat = " + objCon.valorSql(obj.Id) + " ";
                objCon.executaQuery(sql, ref retorno);
                if (retorno > 0) {
                    MessageBox.Show("O usuário " + obj.Nome + ", possui registros vinculados. Ela não pode ser exluido, porém pode ser DESATIVDO.", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

                sql = "delete w_sysUsuarios ";
                sql += "where id = " + objCon.valorSql(obj.Id) + " ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando
                if (validacao) {
                    MessageBox.Show("Usuário " + obj.Nome + " exluído com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    log.registrarLog("USUARIO: " + obj.Nome.ToString() + "/ ID: " + obj.Id.ToString(), "USUARIO - DELETAR"); //regitrando log
                } else {
                    MessageBox.Show("Não foi possível exluir o usuário, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return validacao; //retorno

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "USUARIO - DELETAR(DAL)");
                return false;
            }
        }
        /// <summary>
        /// Utilizado para evitar cadastros dupllicados
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool valorDuplicado(usuarios obj) {
            try {
                sql = "Select * from w_sysUsuarios where IdRede like " + objCon.valorSql(obj.IdRede) + " ";
                objCon.executaQuery(sql, ref retorno);
                if (retorno > 0) { return true; } else { return false; }

            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "USUARIO - VALIDAR DUPLICADO");
                return false;
            }
        }

        public usuarios capturarUsuariosPorID(int _id) {
            try {
                DataTable dt = new DataTable();
                usuarios oDados = new usuarios();
                sql = "Select * from w_sysUsuarios where id like " + objCon.valorSql(_id) + " ";
                dt = objCon.retornaDataTable(sql);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow ln in dt.Rows) {
                        ;
                        oDados.Id = int.Parse(ln["id"].ToString());
                        oDados.IdRede = (ln["IdRede"].ToString());
                        oDados.IdRedeBRA = (ln["IdRedeBRA"].ToString());
                        oDados.Ativo = bool.Parse(ln["ativo"].ToString());
                        oDados.Nome = (ln["Nome"].ToString());
                        oDados.PerfilAcesso = int.Parse(ln["PerfilAcesso"].ToString());
                        oDados.Online = bool.Parse(ln["Online"].ToString());
                        oDados.UltimoAcesso = DateTime.Parse(ln["UltimoAcesso"].ToString());
                        oDados.IdModificacao = (ln["IdModificacao"].ToString());
                        oDados.DataModificacao = DateTime.Parse(ln["DataModificacao"].ToString());
                    }

                    return oDados;
                } else { return null; }


            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "USUARIO - CAPTURAR USUARIO POR ID");
                return null;
            }
        }

        public usuarios capturarUsuariosPorIDRede(string _idRede)
        {
            try
            {
                DataTable dt = new DataTable();
                usuarios oDados = new usuarios();
                sql = "Select * from w_sysUsuarios where idRede like " + objCon.valorSql(_idRede) + " or idRedeBRA like " + objCon.valorSql(_idRede) + " ";
                dt = objCon.retornaDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow ln in dt.Rows)
                    {
                        ;
                        oDados.Id = int.Parse(ln["id"].ToString());
                        oDados.IdRede = (ln["IdRede"].ToString());
                        oDados.IdRedeBRA = (ln["IdRedeBRA"].ToString());
                        oDados.Ativo = bool.Parse(ln["ativo"].ToString());
                        oDados.Nome = (ln["Nome"].ToString());
                        oDados.PerfilAcesso = int.Parse(ln["PerfilAcesso"].ToString());
                        oDados.Online = bool.Parse(ln["Online"].ToString());
                        oDados.UltimoAcesso = DateTime.Parse(ln["UltimoAcesso"].ToString());
                        oDados.IdModificacao = (ln["IdModificacao"].ToString());
                        oDados.DataModificacao = DateTime.Parse(ln["DataModificacao"].ToString());
                    }

                    return oDados;
                }
                else { return null; }


            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "USUARIO - CAPTURAR USUARIO POR ID DE REDE");
                return null;
            }
        }

        private DataTable listarUsuarios(string filtro = "", Boolean somenteAtivo = false) {
            try {
                sql = "Select u.id, u.idRede, u.idRedeBRA, u.ativo, u.nome, p.perfilAcesso, u.online, u.ultimoAcesso, u.idModificacao, u.dataModificacao ";
                sql += "from w_sysUsuarios u inner join w_sysUsuariosPerfilDeAcesso p ON u.PerfilAcesso = p.id ";
                sql += "where u.nome like '" + filtro + "%' ";
                if (somenteAtivo) {
                    sql += "and u.ativo = 1";
                }
                sql += "order by id ";
                return objCon.retornaDataTable(sql);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "USUARIO - LISTA USUARIOS");
                return null;
            }
        }


        private string _capturarEmailAnalistaSeguranca() {
            try {
                sql = "select idrede from w_sysUsuarios where id = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + " ";
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(sql);
                if (dt.Rows.Count > 0) {
                    foreach (DataRow item in dt.Rows) {
                        return item["idrede"].ToString() + "@algartech.com";
                    }
                }
                return "";
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - CAPTURAR E-MAIL ANALISTA SEGURANÇA (DAL)");
                return "";
            }
        }

        #endregion

        #region Camada BLL - Negocio

        public int auttenticacoUsuario(usuarios obj) {

            try {
                int nivelAcesso = _autenticacao(obj);
                if (nivelAcesso == 0) {
                    MessageBox.Show("Favor procurar um adiministrador do Sentinella, pois você não possui um acesso ativo ou válido para acessar a aplicação!",
                        Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                return nivelAcesso;

            } catch (Exception ex) {
                MessageBox.Show("Falha na autenticação do usuário, favor tentar novamente mais tarde!",
                    Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                log.registrarLog(ex.ToString(), "USUARIO - AUTENTICAR(BLL)");
                return 0;
            }
        }

        public void setStatusUsuario(usuarios obj) {
            _on_off(obj);
        }

        public void carregarComboBoxPerfilAcesso(Form frm, ComboBox cbx) {

            try {
                DataTable dt = new DataTable();
                sql = "Select * from w_sysUsuariosPerfilDeAcesso Order by id";
                dt = objCon.retornaDataTable(sql);
                hlp.carregaComboBox(dt, frm, cbx, false, "", "", true);
            } catch (Exception ex) {
                MessageBox.Show("Não foi carregar a lista de Perfil de Acesso, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "USUARIO - CARREGAR COMBOBOX PERFIL DE ACESSO (BLL)");
            }
        }

        public ListView CarregarListViewParaConfiguracoes(ListView lst, string filtro = "") {
            try {
                DataTable dt = new DataTable();
                dt = listarUsuarios(filtro, true);
                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = true;
                //lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("ID", 60, HorizontalAlignment.Center);
                lst.Columns.Add("NOME", 280, HorizontalAlignment.Left);
                lst.Columns.Add("ID REDE", 100, HorizontalAlignment.Left);
                lst.Columns.Add("ID REDE BRA", 100, HorizontalAlignment.Left);                        
                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["id"].ToString();
                        item.SubItems.Add(linha["nome"].ToString());
                        item.SubItems.Add(linha["idRede"].ToString());
                        item.SubItems.Add(linha["idRedeBRA"].ToString());                                       
                        if (linha["ativo"].Equals(false)) { item.ImageKey = "3"; } else { item.ImageKey = "1"; }
                        lst.Items.Add(item);
                    }
                }
                return lst;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "USUARIO - LISTVIEW CONFIGURACOES");
                return null;
            }
        }

        public ListView CarregaListView(ListView lst, string filtro = "") {
            try {
                DataTable dt = new DataTable();
                dt = listarUsuarios(filtro);
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
                lst.Columns.Add("ID REDE", 100, HorizontalAlignment.Left);
                lst.Columns.Add("ID REDE BRA", 100, HorizontalAlignment.Left);
                lst.Columns.Add("NOME", 300, HorizontalAlignment.Left);
                lst.Columns.Add("PERFIL DE ACESSO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("ONLINE", 100, HorizontalAlignment.Left);
                lst.Columns.Add("ÚLT. ACESSO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("ID MODIFICAÇÃO", 100, HorizontalAlignment.Left);
                lst.Columns.Add("DATA DE MODIFICAÇÃO", 150, HorizontalAlignment.Left);
                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["id"].ToString();
                        item.SubItems.Add(linha["idRede"].ToString());
                        item.SubItems.Add(linha["idRedeBRA"].ToString());
                        item.SubItems.Add(linha["nome"].ToString());
                        item.SubItems.Add(linha["perfilAcesso"].ToString());
                        if (linha["online"].Equals(true)) { item.SubItems.Add("SIM"); } else { item.SubItems.Add("NÃO"); };
                        item.SubItems.Add(linha["ultimoAcesso"].ToString());
                        item.SubItems.Add(linha["idModificacao"].ToString());
                        item.SubItems.Add(linha["dataModificacao"].ToString());
                        if (linha["ativo"].Equals(false)) { item.ImageKey = "3"; } else { item.ImageKey = "1"; }
                        lst.Items.Add(item);
                    }
                }
                return lst;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "USUARIO - LISTVIEW");
                return null;
            }

        }

        public bool incluir(usuarios obj) {
            try {
                if (!valorDuplicado(obj)) {
                    if (!_incluir(obj)) {
                        MessageBox.Show("Não foi possível criar o usuário, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    } else {
                        MessageBox.Show("Usuário de " + obj.Nome + " criado com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                } else {
                    MessageBox.Show("Este usuário já está na base!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            } catch (Exception ex) {
                MessageBox.Show("Não foi possível criar o usuário, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "USUARIO - INCLUIR(BLL)");
                return false;
            }
        }

        public bool atualizar(usuarios obj) {
            try {
                if (!_atualizar(obj)) {
                    MessageBox.Show("Não foi possível atualizar a finalização, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                } else {
                    MessageBox.Show("Usuário de " + obj.Nome + " atualizadO com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Não foi possível atualizar o usuário, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "USUARIO - ATUALIZAR(BLL)");
                return false;
            }
        }

        public bool excluir(usuarios obj) {
            try {
                if (!_deletar(obj)) {
                    return false;
                } else {
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Não foi possível exluir o usuário, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "USUARIO - EXCLUIR(BLL)");
                return false;
            }
        }


        public string capturarEmailAnalistaSeguranca() {
            try {
                return _capturarEmailAnalistaSeguranca();
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - CAPTURAR E-MAIL ANALISTA SEGURANÇA (BLL)");
                return "";
            }
        }

        #endregion

    }
}
