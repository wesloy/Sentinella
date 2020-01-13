
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentinella {

    //CREATE TABLE [dbo].[w_cartoes] (
    //[id]                        INT            IDENTITY (1, 1) NOT NULL,
    //[cpf]                       NVARCHAR (20)  NOT NULL,
    //[cartao]                    NVARCHAR (20)  NULL,
    //[bin]                       NVARCHAR (6)   NULL,
    //[tipoCartao]                NVARCHAR (20)  NULL,
    //[nome]                      NVARCHAR (100) NULL,
    //[endereco]                  NVARCHAR (100) NULL,
    //[numResidencial]            NVARCHAR (10)  NULL,
    //[cidade]                    NVARCHAR (100) NULL,
    //[estado]                    NVARCHAR (100) NULL,
    //[cep]                       NVARCHAR (20)  NULL,
    //[bloqueio]                  NVARCHAR (20)  NULL,
    //[ativo]                     BIT            DEFAULT ((0)) NOT NULL,
    //[limite_Credito]            DECIMAL (18)   DEFAULT ((0)) NULL,
    //[limite_Credito_Anterior]   DECIMAL (18)   DEFAULT ((0)) NULL,
    //[limite_Credito_Disponivel] DECIMAL (18)   DEFAULT ((0)) NULL,
    //[limite_Saque]              DECIMAL (18)   DEFAULT ((0)) NULL,
    //[limite_Saque_Disponivel]   DECIMAL (18)   DEFAULT ((0)) NULL,
    //[limite_Data_Alteracao]     DATE           NULL,
    //[limite_Fonte_Alteracao]    NVARCHAR (50)  NULL,
    //[data_Emissao]              DATE           NULL,
    //[data_Desbloqueio]          DATE           NULL,
    //[data_Abertura_Conta]       DATE           NULL,
    //[dataAtualizacao]           DATETIME       DEFAULT (getdate()) NULL,
    //[idAtualizacao]             NVARCHAR (15)  NULL,
    //CONSTRAINT [PK_w_cartoes] PRIMARY KEY CLUSTERED ([id] ASC)
    //);

    class cartoes {

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
        string _cpf; //dados CARTAO e tb CONTA
        string _cartao; //dados CARTAO e tb CONTA
        string _bin; //dados CARTAO e tb CONTA
        string _produto; //dados CARTAO e tb CONTA
        string _tipoCartao; //dados CARTAO e tb CONTA
        string _nome; //dados CARTAO e tb CONTA
        string _endereco; //dados CARTAO e tb CONTA
        string _numResidencial; //dados CARTAO e tb CONTA
        string _cidade; //dados CARTAO e tb CONTA
        string _estado; //dados CARTAO e tb CONTA
        string _cep; //dados CARTAO e tb CONTA
        string _bloqueio; //dados CARTAO e tb CONTA
        bool _ativo; //dados CARTAO e tb CONTA
        double _limite_Credito; //dados que vem do CONTA
        double _limite_Credito_Anterior; //dados que vem do CONTA
        double _limite_Credito_Disponivel; //dados que vem do CONTA
        double _limite_Saque; //dados que vem do CONTA
        double _limite_Saque_Disponivel; //dados que vem do CONTA
        DateTime _limite_Data_Alteracao; //dados que vem do CONTA
        string _limite_Fonte_Alteracao; //dados que vem do CONTA
        DateTime _data_Desbloqueio; //dados que vem do CONTA
        DateTime _data_Abertura_Conta; //dados que vem do CONTA
        DateTime _data_Emissao; //dados que vem do CARTAO
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

        public string TipoCartao {
            get {
                return objCon.retornaVazioParaValorNulo(_tipoCartao).ToString().Replace("  ", " ").Trim();
            }

            set {
                _tipoCartao = value;
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

        public string Endereco {
            get {
                return objCon.retornaVazioParaValorNulo(_endereco).ToString().Replace("  ", " ").Trim();
            }

            set {
                _endereco = value;
            }
        }

        public string NumResidencial {
            get {
                return objCon.retornaVazioParaValorNulo(_numResidencial).ToString().Replace("  ", " ").Trim();
            }

            set {
                _numResidencial = value;
            }
        }

        public string Cidade {
            get {
                return objCon.retornaVazioParaValorNulo(_cidade).ToString().Replace("  ", " ").Trim();
            }

            set {
                _cidade = value;
            }
        }

        public string Estado {
            get {
                return objCon.retornaVazioParaValorNulo(_estado).ToString().Replace("  ", " ").Trim();
            }

            set {
                _estado = value;
            }
        }

        public string Cep {
            get {
                return objCon.retornaVazioParaValorNulo(_cep).ToString().Replace("  ", " ").Trim();
            }

            set {
                _cep = value;
            }
        }

        public string Bloqueio {
            get {
                return objCon.retornaVazioParaValorNulo(_bloqueio).ToString().Replace("  ", " ").Trim();
            }

            set {
                _bloqueio = value;
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

        public double Limite_Credito {
            get {
                return _limite_Credito;
            }

            set {
                _limite_Credito = value;
            }
        }

        public double Limite_Credito_Anterior {
            get {
                return _limite_Credito_Anterior;
            }

            set {
                _limite_Credito_Anterior = value;
            }
        }

        public double Limite_Credito_Disponivel {
            get {
                return _limite_Credito_Disponivel;
            }

            set {
                _limite_Credito_Disponivel = value;
            }
        }

        public double Limite_Saque {
            get {
                return _limite_Saque;
            }

            set {
                _limite_Saque = value;
            }
        }

        public double Limite_Saque_Disponivel {
            get {
                return _limite_Saque_Disponivel;
            }

            set {
                _limite_Saque_Disponivel = value;
            }
        }

        public DateTime Limite_Data_Alteracao {
            get {
                DateTime dt;
                if (_limite_Data_Alteracao == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _limite_Data_Alteracao; }
                return dt;
            }

            set {
                _limite_Data_Alteracao = value;
            }
        }

        public string Limite_Fonte_Alteracao {
            get {
                return objCon.retornaVazioParaValorNulo(_limite_Fonte_Alteracao).ToString().Replace("  ", " ").Trim();
            }

            set {
                _limite_Fonte_Alteracao = value;
            }
        }

        public DateTime Data_Desbloqueio {
            get {
                DateTime dt;
                if (_data_Desbloqueio == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _data_Desbloqueio; }
                return dt;
            }

            set {
                _data_Desbloqueio = value;
            }
        }

        public DateTime Data_Abertura_Conta {
            get {
                DateTime dt;
                if (_data_Abertura_Conta == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _data_Abertura_Conta; }
                return dt;
            }

            set {
                _data_Abertura_Conta = value;
            }
        }

        public DateTime Data_Emissao {
            get {
                DateTime dt;
                if (_data_Emissao == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _data_Emissao; }
                return dt;
            }

            set {
                _data_Emissao = value;
            }
        }

        public DateTime DataAtualizacao {
            get {
                DateTime dt;
                if (_dataAtualizacao == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _dataAtualizacao; }
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

        public string Produto { get => objCon.retornaVazioParaValorNulo(_produto).ToString().Replace("  ", " ").Trim(); set => _produto = value; }
        #endregion

        #endregion

        #region Camada DAL - Dados

        private string _sql(string _cpf, string _bin = "") {
            //Query filtra sem duplicidade por BIN e CPF
            //Necessário já que o robo captura informações de CONTA e CARTAO salvando em registros distintos dentro da tabela
            sql = "select conta.*, cartao.data_Emissao from ";
            sql += "(select * from w_cartoes where tipoCartao <> 'TITULAR') conta ";
            sql += "left join ";
            sql += "(select cpf, bin, data_Emissao from w_cartoes where tipoCartao = 'TITULAR') cartao ";
            sql += "on conta.cpf = cartao.cpf and conta.bin = cartao.bin ";
            sql += "where conta.cpf = " + objCon.valorSql(_cpf);
            if (_bin != "") {
                sql += " and conta.bin = " + objCon.valorSql(_bin) + " ";
            }
            return sql;
        }


        private cartoes _capturarDadosCartaoPorCpfBin(string _sql) {
            try {
                cartoes oDados = new cartoes();
                DataTable dt = new DataTable();                
                dt = objCon.retornaDataTable(_sql);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow ln in dt.Rows) {
                        oDados.Id = int.Parse(ln["Id"].ToString());
                        oDados.Cpf = ln["Cpf"].ToString();
                        oDados.Cartao = ln["Cartao"].ToString();
                        oDados.Bin = ln["Bin"].ToString();
                        oDados.Produto = ln["Produto"].ToString();
                        oDados.TipoCartao = ln["TipoCartao"].ToString();
                        oDados.Nome = ln["Nome"].ToString();
                        oDados.Endereco = ln["Endereco"].ToString();
                        oDados.NumResidencial = ln["NumResidencial"].ToString();
                        oDados.Cidade = ln["Cidade"].ToString();
                        oDados.Estado = ln["Estado"].ToString();
                        oDados.Bloqueio = ln["Bloqueio"].ToString();
                        oDados.Ativo = bool.Parse(ln["Ativo"].ToString());
                        oDados.Limite_Credito = double.Parse(ln["Limite_Credito"].ToString());
                        oDados.Limite_Credito_Anterior = double.Parse(ln["Limite_Credito_Anterior"].ToString());
                        oDados.Limite_Credito_Disponivel = double.Parse(ln["Limite_Credito_Disponivel"].ToString());
                        oDados.Limite_Saque = double.Parse(ln["Limite_Saque"].ToString());
                        oDados.Limite_Saque_Disponivel = double.Parse(ln["Limite_Saque_Disponivel"].ToString());
                        oDados.Limite_Data_Alteracao = DateTime.Parse(ln["Limite_Data_Alteracao"].ToString());
                        oDados.Limite_Fonte_Alteracao = ln["Limite_Fonte_Alteracao"].ToString();
                        oDados.Data_Desbloqueio = DateTime.Parse(ln["Data_Desbloqueio"].ToString());
                        oDados.Data_Abertura_Conta = DateTime.Parse(ln["Data_Abertura_Conta"].ToString());
                        oDados.Data_Emissao = DateTime.Parse(ln["Data_Emissao"].ToString());
                        oDados.DataAtualizacao = DateTime.Parse(ln["DataAtualizacao"].ToString());
                        oDados.IdAtualizacao = ln["IdAtualizacao"].ToString();
                    }
                }
                return oDados;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS DO CARTAO - CAPTURAR POR CPF E BIN (DAL)");
                return null;
            }
        }

        private DataTable _capturarConjuntoCartoesPorCPF(string _sql) {
            try {
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(_sql);
                return dt;
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS DO CARTAO - CAPTURAR POR CPF (DAL)");
                return null;
            }
        }

        #endregion

        #region Camada BLL - Negócio
        public cartoes getDadosCartaoPorCpfBin(string _cpf, string _bin) {
            try {
                sql = _sql(_cpf, _bin);
                return _capturarDadosCartaoPorCpfBin(sql);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS DO CARTAO - CAPTURAR POR CPF E BIN (BLL)");
                return null;
            }
        }

        public DataTable getConjuntoCartoesPorCPF(string _cpf) {
            try {
                sql = _sql(_cpf);
                return _capturarConjuntoCartoesPorCPF(sql);
            } catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS DO CARTAO - CAPTURAR POR CPF (BLL)");
                return null;
            }
        }

        #endregion

    }
}
