using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella {

    //	CREATE TABLE [dbo].[w_faturas] (
    //	    [id]              INT           IDENTITY (1, 1) NOT NULL,
    //	    [cartao]          NVARCHAR (20) NULL,
    //	    [bin]             NVARCHAR (6)  NULL,
    //	    [cpf]             NVARCHAR (20) NULL,
    //	    [dataCorte]       DATE          DEFAULT ('1900-01-01') NOT NULL,
    //	    [dataVencimento]  DATE          DEFAULT ('1900-01-01') NOT NULL,
    //	    [dataPagamento]   DATE          DEFAULT ('1900-01-01') NOT NULL,
    //	    [valorFatura]     MONEY         NULL,
    //	    [valorPagamento]  MONEY         NULL,
    //	    [dataAtualizacao] DATETIME      DEFAULT (getdate()) NOT NULL,
    //	    [idAtualizacao]   NCHAR (10)    NULL,
    //	    CONSTRAINT [PK_w_faturas] PRIMARY KEY CLUSTERED ([id] ASC)
    //	);


    class faturas {

        #region Variaveis 
        string sql = "";
        //long retorno = 0;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        #endregion

        #region Camada DTO - Dados

        #region Atributos
        int _id;
        string _cartao;
        string _bin;
        string _cpf;
        DateTime _dataCorte;
        DateTime _dataVencimento;
        DateTime _dataPagamento;
        double _valorFatura;
        double _valorPagamento;
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

        public string Cpf {
            get {
                return objCon.retornaVazioParaValorNulo(_cpf).ToString().Replace("  ", " ").Trim();
            }

            set {
                _cpf = value;
            }
        }

        public DateTime DataCorte {
            get {
                DateTime dt;
                if (_dataCorte == null) { dt = DateTime.Parse("1900-01-01"); } else { dt = _dataCorte; }
                return dt;
            }

            set {
                _dataCorte = value;
            }
        }

        public DateTime DataVencimento {
            get {
                DateTime dt;
                if (_dataVencimento == null) { dt = DateTime.Parse("1900-01-01"); } else { dt = _dataVencimento; }
                return dt;
            }

            set {
                _dataVencimento = value;
            }
        }

        public DateTime DataPagamento {
            get {
                DateTime dt;
                if (_dataPagamento == null) { dt = DateTime.Parse("1900-01-01"); } else { dt = _dataPagamento; }
                return dt;
            }

            set {
                _dataPagamento = value;
            }
        }

        public double ValorFatura {
            get {
                return _valorFatura;
            }

            set {
                _valorFatura = value;
            }
        }

        public double ValorPagamento {
            get {
                return _valorPagamento;
            }

            set {
                _valorPagamento = value;
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

        #region Camada DAL - Dados
        private DataTable _listarManutencoes(string _cpf, string _bin) {
            try {
                sql = "Select * from w_faturas Where 1 = 1 ";
                sql += "and Cpf = " + objCon.valorSql(_cpf) + " ";
                sql += "and Bin = " + objCon.valorSql(_bin) + " ";
                sql += "Order by cartao, dataCorte ";
                return objCon.retornaDataTable(sql);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FATURAS - LISTA DE FATURAS (DAL)");
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
                lst.Columns.Add("DATA CORTE", 150, HorizontalAlignment.Center);
                lst.Columns.Add("DATA VENCIMENTO", 150, HorizontalAlignment.Center);
                lst.Columns.Add("DATA PAGAMENTO", 150, HorizontalAlignment.Center);
                lst.Columns.Add("VALOR FATURA", 150, HorizontalAlignment.Center);
                lst.Columns.Add("VALOR PAGAMENTO", 150, HorizontalAlignment.Center);                
                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["cartao"].ToString();
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["dataCorte"].ToString()).Substring(0, 10));
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["dataVencimento"].ToString()).Substring(0, 10));
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["dataPagamento"].ToString()).Substring(0, 10));
                        item.SubItems.Add(linha["valorFatura"].ToString());
                        item.SubItems.Add(linha["valorPagamento"].ToString());                        
                        item.ImageKey = "9";
                        lst.Items.Add(item);
                    }
                }
                return lst;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "FATURAS - LISTVIEW (BLL)");
                return null;
            }
        }

        #endregion

    }
}
