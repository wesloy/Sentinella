using System;
using System.Data;
using System.Windows.Forms;

namespace Sentinella {

    //CREATE TABLE [dbo].[w_funcionarios_historico] (
    //    [id]                       INT            IDENTITY (1, 1) NOT NULL,
    //    [nome_empresa]             NVARCHAR (255) NULL,
    //    [cod_empresa]              INT            DEFAULT ((0)) NOT NULL,
    //    [cpf]                      NVARCHAR (255) NULL,
    //    [matricula]                NVARCHAR (20)  NULL,
    //    [ub]                       NVARCHAR (20)  NULL,
    //    [nome_associado]           NVARCHAR (255) NULL,
    //    [data_de_admissao]         DATE           DEFAULT ('1900-01-01') NOT NULL,
    //    [data_demissao]            DATE           DEFAULT ('1900-01-01') NOT NULL,
    //    [codcentro_de_custo]       NVARCHAR (255) NULL,
    //    [descrcentro_de_custo]     NVARCHAR (255) NULL,
    //    [cargo_do_associado]       NVARCHAR (255) NULL,
    //    [sexo]                     NVARCHAR (255) NULL,
    //    [rua]                      NVARCHAR (255) NULL,
    //    [numero]                   NVARCHAR (255) NULL,
    //    [complemento]              NVARCHAR (255) NULL,
    //    [bairro]                   NVARCHAR (255) NULL,
    //    [cidade]                   NVARCHAR (255) NULL,
    //    [estado]                   NVARCHAR (255) NULL,
    //    [cep]                      NVARCHAR (255) NULL,
    //    [data_de_nascimento]       DATE           DEFAULT ('1900-01-01') NOT NULL,
    //    [telefone]                 NVARCHAR (255) NULL,
    //    [celular]                  NVARCHAR (255) NULL,
    //    [email]                    NVARCHAR (255) NULL,
    //    [gestor_1]                 NVARCHAR (255) NULL,
    //    [gestor_2]                 NVARCHAR (255) NULL,
    //    [gestor_3]                 NVARCHAR (255) NULL,
    //    [gestor_4]                 NVARCHAR (255) NULL,
    //    [gestor_5]                 NVARCHAR (255) NULL,
    //    [cod_emp_gestor_1]         NVARCHAR (255) DEFAULT ((0)) NOT NULL,
    //    [cod_emp_gestor_2]         NVARCHAR (255) DEFAULT ((0)) NOT NULL,
    //    [cod_emp_gestor_3]         NVARCHAR (255) DEFAULT ((0)) NOT NULL,
    //    [cod_emp_gestor_4]         NVARCHAR (255) DEFAULT ((0)) NOT NULL,
    //    [cod_emp_gestor_5]         NVARCHAR (255) DEFAULT ((0)) NOT NULL,
    //    [matricula_gestor_1]       NVARCHAR (255) NULL,
    //    [matricula_gestor_2]       NVARCHAR (255) NULL,
    //    [matricula_gestor_3]       NVARCHAR (255) NULL,
    //    [matricula_gestor_4]       NVARCHAR (255) NULL,
    //    [matricula_gestor_5]       NVARCHAR (255) NULL,
    //    [data_estabilidade_inicio] DATE           DEFAULT ('1900-01-01') NOT NULL,
    //    [data_estabilidade_fim]    DATE           DEFAULT ('1900-01-01') NOT NULL,
    //    [dataAtualizacao]          DATETIME       DEFAULT (getdate()) NOT NULL,
    //    [idAtualizacao]            NVARCHAR (255) NULL
    //);


    class dadosCadastraisTH {

        #region Variaveis 
        string sql = "";
        //long retorno = 0;
        Uteis.Conexao objCon = new Uteis.Conexao(Uteis.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Uteis.Helpers hlp = new Uteis.Helpers();
        logs log = new logs();
        #endregion

        #region Camada DTO - Entidades

        #region Atributos
        public int Id { get; set; }
        public string Nome_empresa { get; set; }
        public string Matricula { get; set; }
        public string Ub { get; set; }
        public string Nome_associado { get; set; }
        public DateTime Data_de_admissao { get; set; }
        public DateTime Data_demissao { get; set; }
        public string Codcentro_de_custo { get; set; }
        public string Descrcentro_de_custo { get; set; }
        public string Cargo_do_associado { get; set; }
        public string Sexo { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Cpf { get; set; }
        public DateTime Data_de_nascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        public string gestor_1 { get; set; }
        public string gestor_2 { get; set; }
        public string gestor_3 { get; set; }
        public string gestor_4 { get; set; }
        public string gestor_5 { get; set; }

        public string cod_emp_gestor_1 { get; set; }
        public string cod_emp_gestor_2 { get; set; }
        public string cod_emp_gestor_3 { get; set; }
        public string cod_emp_gestor_4 { get; set; }
        public string cod_emp_gestor_5 { get; set; }

        public string matricula_gestor_1 { get; set; }
        public string matricula_gestor_2 { get; set; }
        public string matricula_gestor_3 { get; set; }
        public string matricula_gestor_4 { get; set; }
        public string matricula_gestor_5 { get; set; }

        public DateTime data_estabilidade_inicio { get; set; }
        public DateTime data_estabilidade_fim { get; set; }

        public DateTime Dataatualizacao { get; set; }
        public string Idatualizacao { get; set; }
        #endregion

        //#region Propriedades
        //public int Id {
        //    get {
        //        return _id;
        //    }

        //    set {
        //        _id = value;
        //    }
        //}

        //public string Nome_empresa {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_empresa).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_empresa = value;
        //    }
        //}

        //public string Matricula {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_matricula).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _matricula = value;
        //    }
        //}

        //public string UB {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_ub).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _ub = value;
        //    }
        //}

        //public string Nome_associado {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_associado).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_associado = value;
        //    }
        //}

        //public DateTime Data_de_admissao {
        //    get {
        //        DateTime dt;
        //        if (_data_de_admissao == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _data_de_admissao; }
        //        return dt;
        //    }

        //    set {
        //        _data_de_admissao = value;
        //    }
        //}

        //public DateTime Data_demissao {
        //    get {
        //        DateTime dt;
        //        if (_data_demissao == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _data_demissao; }
        //        return dt;
        //    }

        //    set {
        //        _data_demissao = value;
        //    }
        //}

        //public string Codcentro_de_custo {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_codcentro_de_custo).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _codcentro_de_custo = value;
        //    }
        //}

        //public string Descrcentro_de_custo {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_descrcentro_de_custo).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _descrcentro_de_custo = value;
        //    }
        //}

        //public string Cargo_do_associado {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cargo_do_associado).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cargo_do_associado = value;
        //    }
        //}

        //public string Sexo {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_sexo).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _sexo = value;
        //    }
        //}

        //public string Rua {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_rua).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _rua = value;
        //    }
        //}

        //public string Numero {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_numero).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _numero = value;
        //    }
        //}

        //public string Complemento {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_complemento).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _complemento = value;
        //    }
        //}

        //public string Bairro {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_bairro).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _bairro = value;
        //    }
        //}

        //public string Cidade {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cidade).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cidade = value;
        //    }
        //}

        //public string Estado {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_estado).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _estado = value;
        //    }
        //}

        //public string Cep {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cep).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cep = value;
        //    }
        //}

        //public string Pais {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_pais).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _pais = value;
        //    }
        //}

        //public string Cpf {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cpf).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cpf = value;
        //    }
        //}

        //public DateTime Data_de_nascimento {
        //    get {
        //        DateTime dt;
        //        if (_data_de_nascimento == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _data_de_nascimento; }
        //        return dt;
        //    }

        //    set {
        //        _data_de_nascimento = value;
        //    }
        //}

        //public int Num_filhos {
        //    get {
        //        return _num_filhos;
        //    }

        //    set {
        //        _num_filhos = value;
        //    }
        //}

        //public string Nome_do_pai {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_do_pai).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_do_pai = value;
        //    }
        //}

        //public string Nome_da_mae {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_da_mae).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_da_mae = value;
        //    }
        //}

        //public string Nome_do_conjuge {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_do_conjuge).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_do_conjuge = value;
        //    }
        //}

        //public string Nome_dependente_01 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_dependente_01).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_dependente_01 = value;
        //    }
        //}

        //public string Cpf_dependente_01 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cpf_dependente_01).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cpf_dependente_01 = value;
        //    }
        //}

        //public string Relacao_dependente_01 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_relacao_dependente_01).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _relacao_dependente_01 = value;
        //    }
        //}

        //public string Nome_dependente_02 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_dependente_02).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_dependente_02 = value;
        //    }
        //}

        //public string Cpf_dependente_02 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cpf_dependente_02).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cpf_dependente_02 = value;
        //    }
        //}

        //public string Relacao_dependente_02 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_relacao_dependente_02).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _relacao_dependente_02 = value;
        //    }
        //}

        //public string Nome_dependente_03 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_dependente_03).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_dependente_03 = value;
        //    }
        //}

        //public string Cpf_dependente_03 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cpf_dependente_03).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cpf_dependente_03 = value;
        //    }
        //}

        //public string Relacao_dependente_03 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_relacao_dependente_03).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _relacao_dependente_03 = value;
        //    }
        //}

        //public string Nome_dependente_04 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_dependente_04).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_dependente_04 = value;
        //    }
        //}

        //public string Cpf_dependente_04 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cpf_dependente_04).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cpf_dependente_04 = value;
        //    }
        //}

        //public string Relacao_dependente_04 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_relacao_dependente_04).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _relacao_dependente_04 = value;
        //    }
        //}

        //public string Nome_dependente_05 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_dependente_05).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_dependente_05 = value;
        //    }
        //}

        //public string Cpf_dependente_05 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cpf_dependente_05).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cpf_dependente_05 = value;
        //    }
        //}

        //public string Relacao_dependente_05 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_relacao_dependente_05).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _relacao_dependente_05 = value;
        //    }
        //}

        //public string Nome_dependente_06 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_dependente_06).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_dependente_06 = value;
        //    }
        //}

        //public string Cpf_dependente_06 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cpf_dependente_06).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cpf_dependente_06 = value;
        //    }
        //}

        //public string Relacao_dependente_06 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_relacao_dependente_06).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _relacao_dependente_06 = value;
        //    }
        //}

        //public string Nome_dependente_07 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_dependente_07).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_dependente_07 = value;
        //    }
        //}

        //public string Cpf_dependente_07 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cpf_dependente_07).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cpf_dependente_07 = value;
        //    }
        //}

        //public string Relacao_dependente_07 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_relacao_dependente_07).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _relacao_dependente_07 = value;
        //    }
        //}

        //public string Nome_dependente_08 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_dependente_08).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_dependente_08 = value;
        //    }
        //}

        //public string Cpf_dependente_08 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cpf_dependente_08).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cpf_dependente_08 = value;
        //    }
        //}

        //public string Relacao_dependente_08 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_relacao_dependente_08).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _relacao_dependente_08 = value;
        //    }
        //}

        //public string Nome_dependente_09 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_dependente_09).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_dependente_09 = value;
        //    }
        //}

        //public string Cpf_dependente_09 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cpf_dependente_09).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cpf_dependente_09 = value;
        //    }
        //}

        //public string Relacao_dependente_09 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_relacao_dependente_09).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _relacao_dependente_09 = value;
        //    }
        //}

        //public string Nome_dependente_10 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_nome_dependente_10).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _nome_dependente_10 = value;
        //    }
        //}

        //public string Cpf_dependente_10 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_cpf_dependente_10).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _cpf_dependente_10 = value;
        //    }
        //}

        //public string Relacao_dependente_10 {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_relacao_dependente_10).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _relacao_dependente_10 = value;
        //    }
        //}

        //public string Ddd {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_ddd).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _ddd = value;
        //    }
        //}

        //public string Telefone {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_telefone).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _telefone = value;
        //    }
        //}

        //public string Celular {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_celular).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _celular = value;
        //    }
        //}

        //public string Email {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_email).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _email = value;
        //    }
        //}

        //public string Responsavel_gh {
        //    get {
        //        return _responsavel_gh;
        //        //return objCon.retornaVazioParaValorNulo(_responsavel_gh).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _responsavel_gh = value;
        //    }
        //}

        //public DateTime Dataatualizacao {
        //    get {
        //        DateTime dt;
        //        if (_dataatualizacao == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _dataatualizacao; }
        //        return dt;
        //    }

        //    set {
        //        _dataatualizacao = value;
        //    }
        //}

        //public string Idatualizacao {
        //    get {
        //        return objCon.retornaVazioParaValorNulo(_idatualizacao).ToString().Replace("  ", " ").Trim();
        //    }

        //    set {
        //        _idatualizacao = value;
        //    }
        //}
        //#endregion

        #endregion

        #region CONSTRUTORES
        #endregion

        #region Camada DAL - Dados

        private string _todosCamposLeiDLP() {
            return "id, " +
                        "nome_empresa," +
                        "cod_empresa," +
                        "cpf," +
                        "matricula," +
                        "ub," +
                        "nome_associado," +
                        "data_de_admissao," +
                        "data_demissao," +
                        "codcentro_de_custo," +
                        "descrcentro_de_custo," +
                        "cargo_do_associado," +
                        //"sexo," +
                        "rua," +
                        "numero," +
                        "complemento," +
                        "bairro," +
                        "cidade," +
                        "estado," +
                        "cep," +
                        "data_de_nascimento," +
                        "telefone," +
                        "celular," +
                        "email," +
                        "gestor_1," +
                        "gestor_2," +
                        "gestor_3," +
                        "gestor_4," +
                        "gestor_5," +
                        "cod_emp_gestor_1," +
                        "cod_emp_gestor_2," +
                        "cod_emp_gestor_3," +
                        "cod_emp_gestor_4," +
                        "cod_emp_gestor_5," +
                        "matricula_gestor_1," +
                        "matricula_gestor_2," +
                        "matricula_gestor_3," +
                        "matricula_gestor_4," +
                        "matricula_gestor_5," +
                        "data_estabilidade_inicio," +
                        "data_estabilidade_fim," +
                        "data_inicio_ferias," +
                        "data_fim_ferias," +
                        "data_inicio_afastamento," +
                        "data_fim_afastamento," +
                        "dataAtualizacao," +
                        "idAtualizacao";

        }

        private dadosCadastraisTH _carregarObjeto(DataTable dt) {
            try {

                dadosCadastraisTH oDados = new dadosCadastraisTH();

                if (dt.Rows.Count > 0) {
                    foreach (DataRow ln in dt.Rows) {
                        oDados.Id = int.Parse(ln["Id"].ToString());
                        oDados.Nome_empresa = ln["Nome_empresa"].ToString();
                        oDados.Matricula = ln["Matricula"].ToString();
                        oDados.Ub = ln["UB"].ToString();
                        oDados.Nome_associado = ln["Nome_associado"].ToString();
                        oDados.Data_de_admissao = DateTime.Parse(ln["Data_de_admissao"].ToString());
                        oDados.Data_demissao = DateTime.Parse(ln["Data_demissao"].ToString());
                        oDados.Codcentro_de_custo = ln["Codcentro_de_custo"].ToString();
                        oDados.Descrcentro_de_custo = ln["Descrcentro_de_custo"].ToString();
                        oDados.Cargo_do_associado = ln["Cargo_do_associado"].ToString();
                        //oDados.Sexo = ln["Sexo"].ToString();
                        oDados.Rua = ln["Rua"].ToString();
                        oDados.Numero = ln["Numero"].ToString();
                        oDados.Complemento = ln["Complemento"].ToString();
                        oDados.Bairro = ln["Bairro"].ToString();
                        oDados.Cidade = ln["Cidade"].ToString();
                        oDados.Estado = ln["Estado"].ToString();
                        oDados.Cep = ln["Cep"].ToString();
                        oDados.Cpf = ln["Cpf"].ToString();
                        oDados.Data_de_nascimento = DateTime.Parse(ln["Data_de_nascimento"].ToString());
                        oDados.Telefone = ln["Telefone"].ToString();
                        oDados.Celular = ln["Celular"].ToString();
                        oDados.Email = ln["Email"].ToString();
                        oDados.gestor_1 = ln["gestor_1"].ToString();
                        oDados.gestor_2 = ln["gestor_2"].ToString();
                        oDados.gestor_3 = ln["gestor_3"].ToString();
                        oDados.gestor_4 = ln["gestor_4"].ToString();
                        oDados.gestor_5 = ln["gestor_5"].ToString();
                        oDados.cod_emp_gestor_1 = ln["cod_emp_gestor_1"].ToString();
                        oDados.cod_emp_gestor_2 = ln["cod_emp_gestor_2"].ToString();
                        oDados.cod_emp_gestor_3 = ln["cod_emp_gestor_3"].ToString();
                        oDados.cod_emp_gestor_4 = ln["cod_emp_gestor_4"].ToString();
                        oDados.cod_emp_gestor_5 = ln["cod_emp_gestor_5"].ToString();
                        oDados.matricula_gestor_1 = ln["matricula_gestor_1"].ToString();
                        oDados.matricula_gestor_2 = ln["matricula_gestor_2"].ToString();
                        oDados.matricula_gestor_3 = ln["matricula_gestor_3"].ToString();
                        oDados.matricula_gestor_4 = ln["matricula_gestor_4"].ToString();
                        oDados.matricula_gestor_5 = ln["matricula_gestor_5"].ToString();
                        oDados.data_estabilidade_inicio = DateTime.Parse(ln["data_estabilidade_inicio"].ToString());
                        oDados.data_estabilidade_fim = DateTime.Parse(ln["data_estabilidade_fim"].ToString());

                        oDados.Dataatualizacao = DateTime.Parse(ln["Dataatualizacao"].ToString());
                        oDados.Idatualizacao = ln["Idatualizacao"].ToString();
                    }
                }


                return oDados;

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - CARREGAR OBJETO (DAL)");
                return null;
            }
        }

        /// <summary>
        /// Um mesmo CPF pode ter mais de uma matrícula, devido histórico de contratação ou até mesmo transf internas, entre as empresas do grupo.
        /// Por isso, a chave de captura para um registro único é a matrícula.
        /// </summary>
        /// <param name="_matricula"></param>
        /// <returns></returns>
        /// 
        private dadosCadastraisTH _capturarDadosCadastraisPorMatricula(string _matricula) {
            try {
                dadosCadastraisTH oDados = new dadosCadastraisTH();
                DataTable dt = new DataTable();
                sql = "select top 1 " + _todosCamposLeiDLP() +  " from w_funcionarios_historico where matricula = " + objCon.valorSql(_matricula) + " order by dataAtualizacao desc ";
                dt = objCon.retornaDataTable(sql);
                oDados = _carregarObjeto(dt);
                return oDados;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - POR MATRICULA (DAL)");
                return null;
            }
        }

        private dadosCadastraisTH _capturarDadosCadastraisPorNomeAssociado(string _nomeAssociado, bool localizacaoExata = false) {
            try {
                dadosCadastraisTH oDados = new dadosCadastraisTH();
                DataTable dt = new DataTable();
                sql = "select top 1 " + _todosCamposLeiDLP() + " from w_funcionarios_historico where nome_associado ";
                if (localizacaoExata) {
                    sql += "= '" + _nomeAssociado + "' ";
                } else {
                    sql += "like '%" + _nomeAssociado + "%' ";
                }
                sql += "Order By dataAtualizacao desc ";

                dt = objCon.retornaDataTable(sql);
                oDados = _carregarObjeto(dt);
                return oDados;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - POR NOME ASSOCIADO (DAL)");
                return null;
            }
        }

        private DataTable _capturarDadosCadastraisPorCpf_tbl(string _cpf) {
            try {
                // retirando os zeros a esquerda para testar as duas formas de busca, visto falta de padrão CSC
                long cpf_sem_zeros_esq = long.Parse(_cpf);

                if (_cpf != "") {
                    sql = "Select " + _todosCamposLeiDLP() + " from w_funcionarios_historico Where 1 = 1 ";
                    sql += "and (Cpf like '%" + _cpf + "%' or Cpf like '%" + cpf_sem_zeros_esq.ToString() + "%') ";
                    sql += "Order by id desc ";
                    return objCon.retornaDataTable(sql);
                }
                return null;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - LISTA DE HISTORICO CPF (DAL)");
                return null;
            }
        }

        private DataTable _capturarDadosCadastraisPorMatricula_tbl(string _matricula) {
            try {
                sql = "select " + _todosCamposLeiDLP() + " from w_funcionarios_historico where matricula = " + objCon.valorSql(_matricula) + " order by dataAtualizacao desc ";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - LISTA DE HISTORICO MATRICULA (DAL)");
                return null;
            }
        }

        private DataTable _capturarDadosCadastraisPorNomeAssociado_tbl(string _nomeAssociado) {
            try {
                sql = sql = "select " + _todosCamposLeiDLP() + " from w_funcionarios_historico where nome_associado like '%" + _nomeAssociado + "%' order by dataAtualizacao desc";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - LISTA DE HISTORICO NOME ASSOCIADO (DAL)");
                return null;
            }
        }

        private DataTable _carregarComboboxMatriculas(string _cpf) {
            try {
                DataTable dt = new DataTable();
                sql = "select 1 as id, matricula from w_funcionarios_historico where cpf = " + objCon.valorSql(_cpf) + " ";
                sql += "group by matricula ";
                sql += "order by matricula";
                dt = objCon.retornaDataTable(sql);
                return dt;
            }
            catch (Exception ex) {

                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - CARREGAR COMBOBOX MATRICULAS (DAL)");
                return null;
            }
        }

        private string _ultimaMatriculaAtivaPorCpf(string _cpf) {
            try {
                DataTable dt = new DataTable();
                string mat = "";
                sql = "Select top 1 matricula from w_funcionarios_historico where cpf = " + objCon.valorSql(_cpf) + " ";
                sql += "Order by id desc";
                dt = objCon.retornaDataTable(sql);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        mat = linha["matricula"].ToString();
                    }
                }

                return mat;
            }
            catch (Exception ex) {

                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - CARREGAR ULTIMA MATRICULA ATIVA (DAL)");
                return "";
            }
        }

        #endregion

        #region Camada BLL - Negócio
        /// <summary>
        /// Retorna todos os dados cadastrais, dentro de um OBJETO
        /// </summary>
        /// <param name="_matricula"></param>
        /// <returns></returns>
        public dadosCadastraisTH getDadosCadastraisPorMatricula(string _matricula) {
            try {
                return _capturarDadosCadastraisPorMatricula(_matricula);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - CAPTURAR RESPONSAVEL TH (BLL)");
                return null;
            }
        }

        public ListView CarregarListviewSimplificado(ListView lst, string _cpf) {
            try {
                DataTable dt = new DataTable();
                dt = _capturarDadosCadastraisPorCpf_tbl(_cpf);
                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = false;
                lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("PROTOCOLO", 120, HorizontalAlignment.Center);
                lst.Columns.Add("EMPRESA", 120, HorizontalAlignment.Left);
                lst.Columns.Add("CPF", 120, HorizontalAlignment.Center);
                lst.Columns.Add("MATRÍCULA", 120, HorizontalAlignment.Center);
                lst.Columns.Add("NOME", 200, HorizontalAlignment.Left);
                lst.Columns.Add("1º GESTOR", 150, HorizontalAlignment.Left);
                lst.Columns.Add("2º GESTOR", 150, HorizontalAlignment.Left);
                lst.Columns.Add("3º GESTOR", 150, HorizontalAlignment.Left);
                lst.Columns.Add("4º GESTOR", 150, HorizontalAlignment.Left);
                lst.Columns.Add("5º GESTOR", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DT. ATUALIZAÇÃO", 150, HorizontalAlignment.Center);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["id"].ToString();
                        item.SubItems.Add(linha["nome_empresa"].ToString());
                        item.SubItems.Add(linha["cpf"].ToString());
                        item.SubItems.Add(linha["matricula"].ToString());
                        item.SubItems.Add(linha["nome_associado"].ToString());
                        item.SubItems.Add(linha["matricula_gestor_1"].ToString() + " - " + linha["gestor_1"].ToString());
                        item.SubItems.Add(linha["matricula_gestor_2"].ToString() + " - " + linha["gestor_2"].ToString());
                        item.SubItems.Add(linha["matricula_gestor_3"].ToString() + " - " + linha["gestor_3"].ToString());
                        item.SubItems.Add(linha["matricula_gestor_4"].ToString() + " - " + linha["gestor_4"].ToString());
                        item.SubItems.Add(linha["matricula_gestor_5"].ToString() + " - " + linha["gestor_5"].ToString());
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["dataAtualizacao"].ToString()));
                        item.ImageKey = "9";
                        lst.Items.Add(item);

                    }
                }
                return lst;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - LISTVIEW (BLL)");
                return null;
            }
        }

        public ListView CarregaListView(ListView lst, string _cpf) {
            try {
                DataTable dt = new DataTable();
                dt = _capturarDadosCadastraisPorCpf_tbl(_cpf);
                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = false;
                lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("PROTOCOLO", 120, HorizontalAlignment.Center);
                //lst.Columns.Add("EMPRESA", 120, HorizontalAlignment.Left);
                //lst.Columns.Add("CPF", 120, HorizontalAlignment.Center);
                //lst.Columns.Add("MATRÍCULA", 120, HorizontalAlignment.Center);
                //lst.Columns.Add("NOME", 200, HorizontalAlignment.Left);
                //lst.Columns.Add("SEXO", 70, HorizontalAlignment.Center);
                lst.Columns.Add("DT. ADMISSÃO", 150, HorizontalAlignment.Center);
                lst.Columns.Add("DT. DEMISSÃO", 150, HorizontalAlignment.Center);
                lst.Columns.Add("CENTRO DE CUSTO", 200, HorizontalAlignment.Left);
                lst.Columns.Add("CARGO", 140, HorizontalAlignment.Left);
                lst.Columns.Add("ENDEREÇO", 300, HorizontalAlignment.Left);
                lst.Columns.Add("DT. NASCIMENTO", 150, HorizontalAlignment.Center);
                lst.Columns.Add("TEL. FIXO", 80, HorizontalAlignment.Center);
                lst.Columns.Add("CELULAR", 80, HorizontalAlignment.Center);
                lst.Columns.Add("E-MAIL", 120, HorizontalAlignment.Left);
               //lst.Columns.Add("1º GESTOR", 150, HorizontalAlignment.Left);
               //lst.Columns.Add("2º GESTOR", 150, HorizontalAlignment.Left);
               //lst.Columns.Add("3º GESTOR", 150, HorizontalAlignment.Left);
               //lst.Columns.Add("4º GESTOR", 150, HorizontalAlignment.Left);
               //lst.Columns.Add("5º GESTOR", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DT. ATUALIZAÇÃO", 150, HorizontalAlignment.Center);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["id"].ToString();
                        //item.SubItems.Add(linha["nome_empresa"].ToString());
                        //item.SubItems.Add(linha["cpf"].ToString());
                        //item.SubItems.Add(linha["matricula"].ToString());
                        //item.SubItems.Add(linha["nome_associado"].ToString());
                        //item.SubItems.Add(linha["sexo"].ToString());
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["data_de_admissao"].ToString()));
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["data_demissao"].ToString()));
                        item.SubItems.Add(linha["codcentro_de_custo"].ToString() + " - " + linha["descrcentro_de_custo"].ToString());
                        item.SubItems.Add(linha["cargo_do_associado"].ToString());
                        item.SubItems.Add(linha["rua"].ToString() + ", " + linha["numero"].ToString() + " - Bairro: " + linha["bairro"].ToString()
                                               + " | " + linha["cidade"].ToString() + " " + linha["estado"].ToString() + "CEP: " + linha["cep"].ToString());
                        item.SubItems.Add(linha["data_de_nascimento"].ToString());
                        item.SubItems.Add(linha["telefone"].ToString());
                        item.SubItems.Add(linha["celular"].ToString());
                        item.SubItems.Add(linha["email"].ToString());
                        //item.SubItems.Add(linha["matricula_gestor_1"].ToString() + " - " + linha["gestor_1"].ToString());
                        //item.SubItems.Add(linha["matricula_gestor_2"].ToString() + " - " + linha["gestor_2"].ToString());
                        //item.SubItems.Add(linha["matricula_gestor_3"].ToString() + " - " + linha["gestor_3"].ToString());
                        //item.SubItems.Add(linha["matricula_gestor_4"].ToString() + " - " + linha["gestor_4"].ToString());
                        //item.SubItems.Add(linha["matricula_gestor_5"].ToString() + " - " + linha["gestor_5"].ToString());
                        item.SubItems.Add(hlp.retornaDataTextBox(linha["dataAtualizacao"].ToString()));
                        item.ImageKey = "9";
                        lst.Items.Add(item);

                    }
                }
                return lst;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - LISTVIEW (BLL)");
                return null;
            }
        }

        public string ultimaMatriculaAtivaPorCpf(string _cpf) {
            try {
                return _ultimaMatriculaAtivaPorCpf(_cpf);
            }
            catch (Exception ex) {

                MessageBox.Show("Não foi possível capturar a matrícula mais recetente para o registro de trabalho atual, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - CARREGAR ULTIMA MATRICULA ATIVA (BLL)");
                return "";
            }
        }

        public void carregarComboboxMatriculas(Form frm, ComboBox cbx, string _cpf) {
            try {
                DataTable dt = new DataTable();
                dt = _carregarComboboxMatriculas(_cpf);
                if (dt != null) {
                    hlp.carregaComboBox(dt, frm, cbx, false, "", "", true);
                }

            }
            catch (Exception ex) {
                MessageBox.Show("Não foi carregar a lista de Matrículas, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - CARREGAR COMBOBOX MATRICULAS (BLL)");
            }
        }

        public void carregarDataGridView_CPF(string cpf, DataGridView dgv) {
            DataTable dt = new DataTable();
            dt = _capturarDadosCadastraisPorCpf_tbl(cpf);
            carregarDataGridView(dgv, dt);
        }

        public void carregarDataGridView_NomeAssociado(string nomeAssociado, DataGridView dgv) {
            DataTable dt = new DataTable();
            dt = _capturarDadosCadastraisPorNomeAssociado_tbl(nomeAssociado);
            carregarDataGridView(dgv, dt);
        }

        public void carregarDataGridView_Matricula(string matricula, DataGridView dgv) {
            DataTable dt = new DataTable();
            dt = _capturarDadosCadastraisPorMatricula_tbl(matricula);
            carregarDataGridView(dgv, dt);
        }

        private void carregarDataGridView(DataGridView dgv, DataTable dt) {
            dgv.DataSource = dt;
        }

        public dadosCadastraisTH infoMaisRecentePorNomeEspecifico(string _nomeAssociado) {
            try {
                return _capturarDadosCadastraisPorNomeAssociado(_nomeAssociado, true);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS TH - INFO MAIS RECENTE POR NOME ASSOCIADO (BLL)");
                return null;
            }

        }

        #endregion

    }
}
