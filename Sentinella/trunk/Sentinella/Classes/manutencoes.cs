using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella {

    //	CREATE TABLE [dbo].[w_manutencoes] (
    //	    [id]                        INT            IDENTITY (1, 1) NOT NULL,
    //	    [cpf]                       NVARCHAR (20)  NULL,
    //	    [cartao]                    NVARCHAR (20)  NULL,
    //	    [bin]                       NVARCHAR (6)   NULL,
    //	    [task]                      NVARCHAR (10)  NULL,
    //	    [descricaoManutencao]       NVARCHAR (255) NULL,
    //	    [dataManutencao]            DATE           DEFAULT ('1900-01-01') NOT NULL,
    //	    [horaManutencao]            NVARCHAR (20)  DEFAULT ('00:00:00') NOT NULL,
    //	    [usuarioRealizouManutencao] NVARCHAR (10)  NULL,
    //	    [departamentoManutencao]    NVARCHAR (10)  NULL,
    //	    [dataAtualizacao]           DATETIME       DEFAULT (getdate()) NOT NULL,
    //	    [idAtualizacao]             NCHAR (10)     NULL,
    //	    CONSTRAINT [PK_w_manutencoes] PRIMARY KEY CLUSTERED ([id] ASC)
    //	);


    class manutencoes {

        #region Variaveis 
        string sql = "";
        //long retorno = 0;
        Uteis.Conexao objCon = new Uteis.Conexao(Uteis.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Uteis.Helpers hlp = new Uteis.Helpers();
        logs log = new logs();
        #endregion

        #region Camada DTO - Entidades

        #region Atributos
        int _id;
        string _cpf;
        string _cartao;
        string _bin;
        string _task;
        string _descricaoManutencao;
        DateTime _dataManutencao;
        string _horaManutencao;
        string _usuarioRealizouManutencao;
        string _departamentoManutencao;
        DateTime _dataAtualizacao;
        string _idAtualizacao;
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

        public string Cpf {
            get {
                return objCon.retornaVazioParaValorNulo(_cpf).ToString().Replace("  ", " ").Trim();
            }

            set {
                _cpf = value;
            }
        }

        public string Cartao {
            get {
                return objCon.retornaVazioParaValorNulo(_cartao).ToString().Replace("  ", " ").Trim();
            }

            set {
                _cartao = value;
            }
        }

        public string Bin {
            get {
                return objCon.retornaVazioParaValorNulo(_bin).ToString().Replace("  ", " ").Trim();
            }

            set {
                _bin = value;
            }
        }

        public string Task {
            get {
                return objCon.retornaVazioParaValorNulo(_task).ToString().Replace("  ", " ").Trim();
            }

            set {
                _task = value;
            }
        }

        public string DescricaoManutencao {
            get {
                return objCon.retornaVazioParaValorNulo(_descricaoManutencao).ToString().Replace("  ", " ").Trim();
            }

            set {
                _descricaoManutencao = value;
            }
        }

        public DateTime DataManutencao {
            get {
                DateTime dt;
                if (_dataManutencao == null) { dt = DateTime.Parse("1900-01-01"); } else { dt = _dataManutencao; }
                return dt;
            }

            set {
                _dataManutencao = value;
            }
        }

        public string HoraManutencao {
            get {
                return objCon.retornaVazioParaValorNulo(_horaManutencao).ToString().Replace("  ", " ").Trim();
            }

            set {
                _horaManutencao = value;
            }
        }

        public string UsuarioRealizouManutencao {
            get {
                return objCon.retornaVazioParaValorNulo(_usuarioRealizouManutencao).ToString().Replace("  ", " ").Trim();
            }

            set {
                _usuarioRealizouManutencao = value;
            }
        }

        public string DepartamentoManutencao {
            get {
                return objCon.retornaVazioParaValorNulo(_departamentoManutencao).ToString().Replace("  ", " ").Trim();
            }

            set {
                _departamentoManutencao = value;
            }
        }

        public DateTime DataAtualizacao {
            get {
                DateTime dt;
                if (_dataAtualizacao == null) { dt = DateTime.Parse("1900-01-01"); } else { dt = _dataAtualizacao; }
                return dt;
            }

            set {
                _dataAtualizacao = value;
            }
        }

        public string IdAtualizacao {
            get {
                return objCon.retornaVazioParaValorNulo(_idAtualizacao).ToString().Replace("  ", " ").Trim();
            }

            set {
                _idAtualizacao = value;
            }
        }
        #endregion

        #endregion

        #region CONSTRUTORES
        #endregion

        #region Camada DAL - Dados
        private DataTable _listarManutencoes(string _cpf, string _bin) {
            try {
                sql = "Select * from w_manutencoes Where 1 = 1 ";
                sql += "and Cpf = " + objCon.valorSql(_cpf) + " ";
                sql += "and Bin = " + objCon.valorSql(_bin) + " ";
                sql += "Order by cartao, dataManutencao";
                return objCon.retornaDataTable(sql);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "MANUTENCOES - LISTA DE MANUTENCOES (DAL)");
                return null;
            }
        }
        #endregion

        #region Camada BLL - Negócio
        public ListView CarregaListView(ListView lst, string _cpf, string _bin) {
            try {
                DataTable dt = new DataTable();
                dt = _listarManutencoes(_cpf, _bin);
                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = false;
                lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("CARTÃO", 140, HorizontalAlignment.Center);
                lst.Columns.Add("TASK", 80, HorizontalAlignment.Left);
                lst.Columns.Add("DESCRIÇÃO MANUTENÇÃO", 1000, HorizontalAlignment.Left);
                lst.Columns.Add("DATA", 80, HorizontalAlignment.Center);
                lst.Columns.Add("HORA", 80, HorizontalAlignment.Left);
                lst.Columns.Add("USUÁRIO", 80, HorizontalAlignment.Center);
                lst.Columns.Add("DEPARTAMENTO", 100, HorizontalAlignment.Center);
                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["cartao"].ToString();
                        item.SubItems.Add(linha["task"].ToString());
                        item.SubItems.Add(linha["descricaoManutencao"].ToString());
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["dataManutencao"].ToString()).Substring(0,10));
                        item.SubItems.Add(linha["horaManutencao"].ToString().Substring(0,8));
                        item.SubItems.Add(linha["usuarioRealizouManutencao"].ToString());
                        item.SubItems.Add(linha["departamentoManutencao"].ToString());
                        item.ImageKey = "9";
                        lst.Items.Add(item);
                       
                    }
                }
                return lst;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "MANUTENCOES - LISTVIEW (BLL)");
                return null;
            }
        }

        #endregion

    }
}
