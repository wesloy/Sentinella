using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella {

    //	CREATE TABLE [dbo].[w_autorizacoes] (
    //	    [id]                 INT           IDENTITY (1, 1) NOT NULL,
    //	    [cartao]             NVARCHAR (20) NULL,
    //	    [bin]                NVARCHAR (6)  NULL,
    //	    [cpf]                NVARCHAR (20) NULL,
    //	    [dataCorte]          DATE          DEFAULT ('1900-01-01') NOT NULL,
    //	    [dataVencimento]     DATE          DEFAULT ('1900-01-01') NOT NULL,
    //	    [dataTransacao]      DATE          DEFAULT ('1900-01-01') NOT NULL,
    //	    [dataInclusaoFatura] DATE          DEFAULT ('1900-01-01') NOT NULL,
    //	    [codReferencia]      NVARCHAR (50) NULL,
    //	    [codAutorizacao]     NVARCHAR (50) NULL,
    //	    [estabelecimento]    NVARCHAR (50) NULL,
    //	    [valorTransacao]     MONEY         NULL,
    //	    [dataAtualizacao]    DATETIME      DEFAULT (getdate()) NOT NULL,
    //	    [idAtualizacao]      NCHAR (10)    NULL,
    //	    CONSTRAINT [PK_w_autorizacoes] PRIMARY KEY CLUSTERED ([id] ASC)
    //	);
    
    class autorizacoes {

        #region Variaveis 
        string sql = "";
        //long retorno = 0;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        #endregion

        #region Camada DTO - Entidades

        #region Atributos
        int _id;
        string _cartao;
        string _bin;
        string _cpf;
        DateTime _dataCorte;
        DateTime _dataVencimento;
        DateTime _dataTransacao;
        DateTime _dataInclusaoFatura;
        string _codReferencia;
        string _codAutorizacao;
        string _estabelecimento;
        double _valorTransacao;
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

        public DateTime DataTransacao {
            get {
                DateTime dt;
                if (_dataTransacao == null) { dt = DateTime.Parse("1900-01-01"); } else { dt = _dataTransacao; }
                return dt;
            }

            set {
                _dataTransacao = value;
            }
        }

        public DateTime DataInclusaoFatura {
            get {
                DateTime dt;
                if (_dataInclusaoFatura == null) { dt = DateTime.Parse("1900-01-01"); } else { dt = _dataInclusaoFatura; }
                return dt;
            }

            set {
                _dataInclusaoFatura = value;
            }
        }

        public string CodReferencia {
            get {
                return objCon.retornaVazioParaValorNulo(_codReferencia).ToString().Replace("  ", " ").Trim();
            }

            set {
                _codReferencia = value;
            }
        }

        public string CodAutorizacao {
            get {
                return objCon.retornaVazioParaValorNulo(_codAutorizacao).ToString().Replace("  ", " ").Trim();
            }

            set {
                _codAutorizacao = value;
            }
        }

        public string Estabelecimento {
            get {
                return objCon.retornaVazioParaValorNulo(_estabelecimento).ToString().Replace("  ", " ").Trim();
            }

            set {
                _estabelecimento = value;
            }
        }

        public double ValorTransacao {
            get {
                return _valorTransacao;
            }

            set {
                _valorTransacao = value;
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
        private autorizacoes _capturarAutorizacaoPorID(int _id) {
            try {
                DataTable dt = new DataTable();
                autorizacoes obj = new autorizacoes();
                sql = "Select * from w_autorizacoes where id = " + _id + " ";
                dt = objCon.retornaDataTable(sql);
                if (dt.Rows.Count > 0) {
                    foreach (DataRow ln in dt.Rows) {
                        obj.Id = int.Parse(ln["id"].ToString());
                        obj.Cartao = ln["Cartao"].ToString();
                        obj.Bin = ln["Bin"].ToString();
                        obj.Cpf = ln["Cpf"].ToString();
                        obj.DataCorte = DateTime.Parse(ln["DataCorte"].ToString());
                        obj.DataVencimento = DateTime.Parse(ln["DataVencimento"].ToString());
                        obj.DataTransacao = DateTime.Parse(ln["DataTransacao"].ToString());
                        obj.DataInclusaoFatura = DateTime.Parse(ln["DataInclusaoFatura"].ToString());
                        obj.CodReferencia = ln["CodReferencia"].ToString();
                        obj.CodAutorizacao = ln["CodAutorizacao"].ToString();
                        obj.Estabelecimento = ln["Estabelecimento"].ToString();
                        obj.ValorTransacao = double.Parse(ln["ValorTransacao"].ToString());
                        obj.DataAtualizacao = DateTime.Parse(ln["DataAtualizacao"].ToString());
                        obj.IdAtualizacao = ln["IdAtualizacao"].ToString();
                    }
                }
                return obj;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "AUTORIZACOES - CAPTURAR POR ID (DAL)");
                return null;
            }
        }

        private DataTable _capturarConjuntoAutorizacoesPorCPF(string _cpf) {
            try {
                DataTable dt = new DataTable();                
                sql = "Select * from w_autorizacoes where cpf = " + objCon.valorSql(_cpf) + " ";
                dt = objCon.retornaDataTable(sql);                
                return dt;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "AUTORIZACOES - CAPTURAR POR CPF (DAL)");
                return null;
            }
        }

        private DataTable _capturarConjuntoAutorizacoesPorDataCorte(string _bin, string _cpf, DateTime _dataCorte) {
            try {
                DataTable dt = new DataTable();
                sql = "Select * from w_autorizacoes where bin = " + objCon.valorSql(_bin) + " and cpf = " + objCon.valorSql(_cpf) + " and DataCorte = " + objCon.valorSql(_dataCorte) + " ";
                dt = objCon.retornaDataTable(sql);
                return dt;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "AUTORIZACOES - CAPTURAR POR DATA CORTE (DAL)");
                return null;
            }
        }

        #endregion

        #region Camada BLL - Negócios
        public autorizacoes getAutorizacaoPorID(int _id) {
            try {
                return _capturarAutorizacaoPorID(_id);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "AUTORIZACOES - CAPTURAR POR ID (BLL)");
                return null;
            }
        }
        
        private DataTable getConjuntoAutorizacoesPorCPF(string _cpf) {
            try {
                return _capturarConjuntoAutorizacoesPorCPF(_cpf);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "AUTORIZACOES - CAPTURAR POR CPF (BLL)");
                return null;
            }
        }

        private DataTable getConjuntoAutorizacoesPorDataCorte(string _bin, string _cpf, DateTime _dataCorte) {
            try {
                return _capturarConjuntoAutorizacoesPorDataCorte(_bin, _cpf, _dataCorte);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "AUTORIZACOES - CAPTURAR POR DATA CORTE (BLL)");
                return null;
            }
        }

        public ListView CarregaListView(ListView lst, string _bin, string _cpf, DateTime _dataCorte) {
            try {
                DataTable dt = new DataTable();
                dt = _capturarConjuntoAutorizacoesPorDataCorte(_bin, _cpf, _dataCorte);
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
                lst.Columns.Add("DATA TRANSAÇÃO", 150, HorizontalAlignment.Center);
                lst.Columns.Add("DATA LANÇAMENTO", 150, HorizontalAlignment.Center);
                lst.Columns.Add("REFERÊNCIA", 150, HorizontalAlignment.Center);
                lst.Columns.Add("AUTORIZAÇÃO", 150, HorizontalAlignment.Center);
                lst.Columns.Add("ESTABELECIMENTO", 150, HorizontalAlignment.Center); 
                lst.Columns.Add("VALOR TRANSAÇÃO", 150, HorizontalAlignment.Center);                
                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["cartao"].ToString();
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["dataCorte"].ToString()).Substring(0, 10));
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["dataVencimento"].ToString()).Substring(0, 10));
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["dataTransacao"].ToString()).Substring(0, 10));
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["DataInclusaoFatura"].ToString()).Substring(0, 10));
                        item.SubItems.Add(linha["CodReferencia"].ToString());
                        item.SubItems.Add(linha["CodAutorizacao"].ToString());
                        item.SubItems.Add(linha["Estabelecimento"].ToString());
                        item.SubItems.Add(linha["ValorTransacao"].ToString());
                        item.ImageKey = "9";
                        lst.Items.Add(item);
                    }
                }
                return lst;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "AUTORIZACOES - LISTVIEW (BLL)");
                return null;
            }
        }
        #endregion

    }
}
