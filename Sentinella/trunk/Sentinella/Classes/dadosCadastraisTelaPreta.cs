using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentinella {

    //	CREATE TABLE [dbo].[w_dadosCadastrais] (
    //	    [id]                       INT            IDENTITY (1, 1) NOT NULL,
    //	    [cpf]                      NVARCHAR (20)  NOT NULL,
    //	    [cartao]                   NVARCHAR (20)  NULL,
    //	    [bin]                      NVARCHAR (6)   NULL,
    //	    [produto]                  NVARCHAR (20)  NULL,
    //	    [data_alteracao_End]       DATE           DEFAULT ('1900-01-01') NOT NULL,
    //	    [data_alteracao_telefones] DATE           DEFAULT ('1900-01-01') NOT NULL,
    //	    [nome]                     NVARCHAR (100) NULL,
    //	    [data_Nascimento]          DATE           NULL,
    //	    [sexo]                     NVARCHAR (2)   NULL,
    //	    [nome_2]                   NVARCHAR (100) NULL,
    //	    [nome_3]                   NVARCHAR (100) NULL,
    //	    [nome_4]                   NVARCHAR (100) NULL,
    //	    [tel_residencial]          NVARCHAR (100) NULL,
    //	    [tel_empresa]              NVARCHAR (100) NULL,
    //	    [tel_celular]              NVARCHAR (100) NULL,
    //	    [end_cobranca]             NVARCHAR (250) NULL,
    //	    [cidade_cobranca]          NVARCHAR (100) NULL,
    //	    [estado_cobranca]          NVARCHAR (5)   NULL,
    //	    [cep_cobranca]             NVARCHAR (20)  NULL,
    //	    [end_anterior]             NVARCHAR (250) NULL,
    //	    [cidade_anterior]          NVARCHAR (100) NULL,
    //	    [estado_anterior]          NVARCHAR (5)   NULL,
    //	    [cep_anterior]             NVARCHAR (20)  NULL,
    //	    [end_correspondencia]      NVARCHAR (250) NULL,
    //	    [cidade_correspondencia]   NVARCHAR (100) NULL,
    //	    [estado_correspondencia]   NVARCHAR (5)   NULL,
    //	    [cep_correspondencia]      NVARCHAR (20)  NULL,
    //	    [dataAtualizacao]          DATETIME       DEFAULT (getdate()) NOT NULL,
    //	    [idAtualizacao]            NVARCHAR (15)  NULL,
    //	    CONSTRAINT [PK_w_dadosCadastrais] PRIMARY KEY CLUSTERED ([id] ASC)
    //	);


    class dadosCadastraisTelaPreta {

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
        string _cpf;
        string _cartao;
        string _bin;
        string _produto;
        DateTime _data_alteracao_End;
        DateTime _data_alteracao_telefones;
        string _nome;
        DateTime _data_Nascimento;
        string _sexo;
        string _nome_2;
        string _nome_3;
        string _nome_4;
        string _tel_residencial;
        string _tel_empresa;
        string _tel_celular;
        string _end_cobranca;
        string _cidade_cobranca;
        string _estado_cobranca;
        string _cep_cobranca;
        string _end_anterior;
        string _cidade_anterior;
        string _estado_anterior;
        string _cep_anterior;
        string _end_correspondencia;
        string _cidade_correspondencia;
        string _estado_correspondencia;
        string _cep_correspondencia;
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
                return objCon.retornaVazioParaValorNulo(_cpf).ToString().Replace("  "," ").Trim();
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

        public string Produto {
            get {
                return objCon.retornaVazioParaValorNulo(_produto).ToString().Replace("  ", " ").Trim();
            }

            set {
                _produto = value;
            }
        }

        public DateTime Data_alteracao_End {
            get {
                DateTime dt;
                 if (_data_alteracao_End == null) { dt = DateTime.Parse("1900-01-01"); } else { dt = _data_alteracao_End; }
                return dt;
            }

            set {
                _data_alteracao_End = value;
            }
        }

        public DateTime Data_alteracao_telefones {
            get {
                DateTime dt;
                if (_data_alteracao_telefones == null) { dt = DateTime.Parse("1900-01-01"); } else { dt = _data_alteracao_telefones; }
                return dt;                
            }

            set {
                _data_alteracao_telefones = value;
            }
        }

        public string Nome {
            get {
                return objCon.retornaVazioParaValorNulo(_nome).ToString().Replace("  ", " ").Trim();                
            }

            set {
                _nome = value;
            }
        }

        public DateTime Data_Nascimento {
            get {
                DateTime dt;
                if (_data_Nascimento == null) { dt = DateTime.Parse("1900-01-01"); } else { dt = _data_Nascimento; }
                return dt;                
            }

            set {
                _data_Nascimento = value;
            }
        }

        public string Sexo {
            get {
                return objCon.retornaVazioParaValorNulo(_sexo).ToString().Replace("  ", " ").Trim();
            }

            set {
                _sexo = value;
            }
        }

        public string Nome_2 {
            get {
                return objCon.retornaVazioParaValorNulo(_nome_2).ToString().Replace("  ", " ").Trim();
            }

            set {
                _nome_2 = value;
            }
        }

        public string Nome_3 {
            get {
                return objCon.retornaVazioParaValorNulo(_nome_3).ToString().Replace("  ", " ").Trim();
            }

            set {
                _nome_3 = value;
            }
        }

        public string Nome_4 {
            get {
                return objCon.retornaVazioParaValorNulo(_nome_4).ToString().Replace("  ", " ").Trim();
            }

            set {
                _nome_4 = value;
            }
        }

        public string Tel_residencial {
            get {
                return objCon.retornaVazioParaValorNulo(_tel_residencial).ToString().Replace("  ", " ").Trim();
            }

            set {
                _tel_residencial = value;
            }
        }

        public string Tel_empresa {
            get {
                return objCon.retornaVazioParaValorNulo(_tel_empresa).ToString().Replace("  ", " ").Trim();
            }

            set {
                _tel_empresa = value;
            }
        }

        public string Tel_celular {
            get {
                return objCon.retornaVazioParaValorNulo(_tel_celular).ToString().Replace("  ", " ").Trim();
            }

            set {
                _tel_celular = value;
            }
        }

        public string End_cobranca {
            get {
                return objCon.retornaVazioParaValorNulo(_end_cobranca).ToString().Replace("  ", " ").Trim();
            }

            set {
                _end_cobranca = value;
            }
        }

        public string Cidade_cobranca {
            get {
                return objCon.retornaVazioParaValorNulo(_cidade_cobranca).ToString().Replace("  ", " ").Trim();
            }

            set {
                _cidade_cobranca = value;
            }
        }

        public string Estado_cobranca {
            get {
                return objCon.retornaVazioParaValorNulo(_estado_cobranca).ToString().Replace("  ", " ").Trim();
            }

            set {
                _estado_cobranca = value;
            }
        }

        public string Cep_cobranca {
            get {
                return objCon.retornaVazioParaValorNulo(_cep_cobranca).ToString().Replace("  ", " ").Trim();
            }

            set {
                _cep_cobranca = value;
            }
        }

        public string End_anterior {
            get {
                return objCon.retornaVazioParaValorNulo(_end_anterior).ToString().Replace("  ", " ").Trim();
            }

            set {
                _end_anterior = value;
            }
        }

        public string Cidade_anterior {
            get {
                return objCon.retornaVazioParaValorNulo(_cidade_anterior).ToString().Replace("  ", " ").Trim();
            }

            set {
                _cidade_anterior = value;
            }
        }

        public string Estado_anterior {
            get {
                return objCon.retornaVazioParaValorNulo(_estado_anterior).ToString().Replace("  ", " ").Trim();
            }

            set {
                _estado_anterior = value;
            }
        }

        public string Cep_anterior {
            get {
                return objCon.retornaVazioParaValorNulo(_cep_anterior).ToString().Replace("  ", " ").Trim();
            }

            set {
                _cep_anterior = value;
            }
        }

        public string End_correspondencia {
            get {
                return objCon.retornaVazioParaValorNulo(_end_correspondencia).ToString().Replace("  ", " ").Trim();
            }

            set {
                _end_correspondencia = value;
            }
        }

        public string Cidade_correspondencia {
            get {
                return objCon.retornaVazioParaValorNulo(_cidade_correspondencia).ToString().Replace("  ", " ").Trim();
            }

            set {
                _cidade_correspondencia = value;
            }
        }

        public string Estado_correspondencia {
            get {
                return objCon.retornaVazioParaValorNulo(_estado_correspondencia).ToString().Replace("  ", " ").Trim();
            }

            set {
                _estado_correspondencia = value;
            }
        }

        public string Cep_correspondencia {
            get {
                return objCon.retornaVazioParaValorNulo(_cep_correspondencia).ToString().Replace("  ", " ").Trim();
            }

            set {
                _cep_correspondencia = value;
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

        private string _sql(string _cpf, string _bin = "") {
            //Captura comum às funções
            sql = "select * from w_dadosCadastrais ";
            sql += "where cpf = " + objCon.valorSql(_cpf);
            if (_bin != "") {
                sql += " and bin = " + objCon.valorSql(_bin) + " ";
            }
            return sql;
        }

        private dadosCadastraisTelaPreta _capturarDadosCadastraisPorCpfBin(string _sql) {
            try {
                dadosCadastraisTelaPreta oDados = new dadosCadastraisTelaPreta();
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(_sql);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow ln in dt.Rows) {
                        oDados.Id = int.Parse(ln["Id"].ToString());
                        oDados.Cpf = ln["Cpf"].ToString();
                        oDados.Cartao = ln["Cartao"].ToString();
                        oDados.Bin = ln["Bin"].ToString();
                        oDados.Produto = ln["Produto"].ToString();
                        oDados.Data_alteracao_End = DateTime.Parse(ln["Data_alteracao_End"].ToString());
                        oDados.Data_alteracao_telefones = DateTime.Parse(ln["Data_alteracao_telefones"].ToString());
                        oDados.Nome = ln["Nome"].ToString();
                        oDados.Data_Nascimento = DateTime.Parse(ln["Data_Nascimento"].ToString());
                        oDados.Sexo = ln["Sexo"].ToString();
                        oDados.Nome_2 = ln["Nome_2"].ToString();
                        oDados.Nome_3 = ln["Nome_3"].ToString();
                        oDados.Nome_4 = ln["Nome_4"].ToString();
                        oDados.Tel_residencial = ln["Tel_residencial"].ToString();
                        oDados.Tel_empresa = ln["Tel_empresa"].ToString();
                        oDados.Tel_celular = ln["Tel_celular"].ToString();
                        oDados.End_cobranca = ln["End_cobranca"].ToString();
                        oDados.Cidade_cobranca = ln["Cidade_cobranca"].ToString();
                        oDados.Estado_cobranca = ln["Estado_cobranca"].ToString();
                        oDados.Cep_cobranca = ln["Cep_cobranca"].ToString();
                        oDados.End_anterior = ln["End_anterior"].ToString();
                        oDados.Cidade_anterior = ln["Cidade_anterior"].ToString();
                        oDados.Estado_anterior = ln["Estado_anterior"].ToString();
                        oDados.Cep_anterior = ln["Cep_anterior"].ToString();
                        oDados.End_correspondencia = ln["End_correspondencia"].ToString();
                        oDados.Cidade_correspondencia = ln["Cidade_correspondencia"].ToString();
                        oDados.Estado_correspondencia = ln["Estado_correspondencia"].ToString();
                        oDados.Cep_correspondencia = ln["Cep_correspondencia"].ToString();
                        oDados.DataAtualizacao = DateTime.Parse(ln["DataAtualizacao"].ToString());
                        oDados.IdAtualizacao = ln["IdAtualizacao"].ToString();
                    }
                }
                return oDados;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS - CAPTURAR POR CPF E BIN (DAL)");
                return null;
            }
        }

        private DataTable _capturarConjuntoDadosCadastraisPorCPF(string _sql) {
            try {
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(_sql);
                return dt;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS - CAPTURAR POR CPF (DAL)");
                return null;
            }
        }

        #endregion

        #region Camada BLL - Negócio
        public dadosCadastraisTelaPreta getDadosCadastraisPorCpfBin(string _cpf, string _bin) {
            try {
                sql = _sql(_cpf, _bin);
                return _capturarDadosCadastraisPorCpfBin(sql);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS - CAPTURAR POR CPF E BIN (BLL)");
                return null;
            }
        }

        public DataTable getConjuntoDadosCadastraisPorCPF(string _cpf) {
            try {
                sql = _sql(_cpf);
                return _capturarConjuntoDadosCadastraisPorCPF(sql);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS - CAPTURAR POR CPF (BLL)");
                return null;
            }
        }

        #endregion
        
    }
}
