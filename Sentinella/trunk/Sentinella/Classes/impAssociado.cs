using System;
using System.Data;
using System.Windows.Forms;

namespace Sentinella {
    class impAssociado {

        #region TABELAS
        //Linked Server
        //select top 10 * from db_Corporate_V3.dbo.tb_Imp_Associado
        #endregion

        #region VARIÁVEIS
        string sql = "";
        //long retorno = 0;
        //bool validacao = false;        
        Uteis.Conexao objCon = new Uteis.Conexao(Uteis.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Uteis.Helpers hlp = new Uteis.Helpers();
        logs log = new logs();
        #endregion

        #region DTO
        public string Cod_Empresa { get; set; }
        public string Cod_Matricula { get; set; }
        public string Nom_Usuario { get; set; }
        public string Tp_Sexo { get; set; }
        public string Dt_Nascimento { get; set; }
        public string Dt_Admissao { get; set; }
        public string Dt_Inicio_Ferias { get; set; }
        public string Dt_Fim_Ferias { get; set; }
        public string Dt_Inicio_Afastamento { get; set; }
        public string Dt_Fim_Afastamento { get; set; }
        public string Dt_Demissao { get; set; }
        public string Cod_Cpf { get; set; }
        public string Cod_Cargo { get; set; }
        public string Nom_Cargo { get; set; }
        public string num_Centro_Custo { get; set; }
        public string Nom_Centro_Custo { get; set; }
        public string Flg_Duplicidade { get; set; }
        public string idt_Categoria { get; set; }
        public string Cod_CR { get; set; }
        public string Idt_Num_PIS { get; set; }
        public string Nom_Empresa { get; set; }
        public string Des_Email { get; set; }
        public string Idt_Telefone_Usuario { get; set; }
        public string Idt_Celular_Usuario { get; set; }
        public string Cod_Matricula_Superior { get; set; }
        public string Nom_Usuario_Superior { get; set; }
        public string Num_Centro_Custo_Superior { get; set; }
        public string Nom_Centro_Custo_Superior { get; set; }
        public string Des_Endereco { get; set; }
        public string Nom_Bairro { get; set; }
        public string Nom_Localidade { get; set; }
        public string Num_Cep { get; set; }
        public string Num_RG { get; set; }
        public string Nom_CR { get; set; }
        public string Cod_CR_Superior { get; set; }
        public string Nom_CR_Superior { get; set; }
        public string Des_Motivo_Afastamento { get; set; }
        public string Num_Endereco { get; set; }
        public string Des_Complemento { get; set; }
        public string UF_Localidade { get; set; }
        public DateTime Dt_Inicio_Estabilidade_CIPA { get; set; }
        public DateTime Dt_Fim_Estabilidade_CIPA { get; set; }
        public DateTime Dt_Venc_Contrato_1 { get; set; }
        public DateTime Dt_Venc_Contrato_2 { get; set; }
        public string Nom_Tipo_Cargo { get; set; }
        public string Cod_Gestor_Hierarq_1 { get; set; }
        public string Cod_Gestor_Hierarq_2 { get; set; }
        public string Cod_Gestor_Hierarq_3 { get; set; }
        public string Cod_Gestor_Hierarq_4 { get; set; }
        public string Cod_Gestor_Hierarq_5 { get; set; }
        public string Cod_GH { get; set; }
        public string Cod_Empresa_Gestor_Hierarq_1 { get; set; }
        public string Cod_Empresa_Gestor_Hierarq_2 { get; set; }
        public string Cod_Empresa_Gestor_Hierarq_3 { get; set; }
        public string Cod_Empresa_Gestor_Hierarq_4 { get; set; }
        public string Cod_Empresa_Gestor_Hierarq_5 { get; set; }
        public string Cod_Empresa_FPW { get; set; }
        public DateTime Dt_Atualizacao_FPW { get; set; }
        public DateTime Dt_Retorno_Afastamento { get; set; }
        public string ind_PTH { get; set; }
        public string ind_Readmitido { get; set; }
        public DateTime Dt_Readmissao { get; set; }
        public string Des_Tipo_Rescisao { get; set; }
        public string Des_Submotivo_Rescisao { get; set; }

        //Relação baseada no supervisor imediato de cada sucessão de chefia
        public string _gestor1 { get; set; }
        public string _gestor2 { get; set; }
        public string _gestor3 { get; set; }
        public string _gestor4 { get; set; }
        public string _gestor5 { get; set; }

        public string _gestor1_email { get; set; }
        public string _gestor2_email { get; set; }
        public string _gestor3_email { get; set; }
        public string _gestor4_email { get; set; }
        public string _gestor5_email { get; set; }

        #endregion

        #region CONSTRUTORES
        public impAssociado() { }

        private impAssociado _impAssociadoObjSupImediado(DataTable dt) {

            impAssociado obj = new impAssociado();
            try {


                foreach (DataRow item in dt.Rows) {

                    obj.Cod_Empresa = item["Cod_Empresa"].ToString();
                    obj.Cod_Matricula = item["Cod_Matricula"].ToString();
                    obj.Nom_Usuario = item["Nom_Usuario"].ToString();
                    obj.Tp_Sexo = item["Tp_Sexo"].ToString();
                    obj.Dt_Nascimento = item["Dt_Nascimento"].ToString();
                    obj.Dt_Admissao = item["Dt_Admissao"].ToString();
                    obj.Dt_Inicio_Ferias = item["Dt_Inicio_Ferias"].ToString();
                    obj.Dt_Fim_Ferias = item["Dt_Fim_Ferias"].ToString();
                    obj.Dt_Inicio_Afastamento = item["Dt_Inicio_Afastamento"].ToString();
                    obj.Dt_Fim_Afastamento = item["Dt_Fim_Afastamento"].ToString();
                    obj.Dt_Demissao = item["Dt_Demissao"].ToString();
                    obj.Cod_Cpf = item["Cod_Cpf"].ToString();
                    obj.Cod_Cargo = item["Cod_Cargo"].ToString();
                    obj.Nom_Cargo = item["Nom_Cargo"].ToString();
                    obj.num_Centro_Custo = item["num_Centro_Custo"].ToString();
                    obj.Nom_Centro_Custo = item["Nom_Centro_Custo"].ToString();
                    obj.Flg_Duplicidade = item["Flg_Duplicidade"].ToString();
                    obj.idt_Categoria = item["idt_Categoria"].ToString();
                    obj.Cod_CR = item["Cod_CR"].ToString();
                    obj.Idt_Num_PIS = item["Idt_Num_PIS"].ToString();
                    obj.Nom_Empresa = item["Nom_Empresa"].ToString();
                    obj.Des_Email = item["Des_Email"].ToString();
                    obj.Idt_Telefone_Usuario = item["Idt_Telefone_Usuario"].ToString();
                    obj.Idt_Celular_Usuario = item["Idt_Celular_Usuario"].ToString();
                    obj.Cod_Matricula_Superior = item["Cod_Matricula_Superior"].ToString();
                    obj.Nom_Usuario_Superior = item["Nom_Usuario_Superior"].ToString();
                    obj.Num_Centro_Custo_Superior = item["Num_Centro_Custo_Superior"].ToString();
                    obj.Nom_Centro_Custo_Superior = item["Nom_Centro_Custo_Superior"].ToString();
                    obj.Des_Endereco = item["Des_Endereco"].ToString();
                    obj.Nom_Bairro = item["Nom_Bairro"].ToString();
                    obj.Nom_Localidade = item["Nom_Localidade"].ToString();
                    obj.Num_Cep = item["Num_Cep"].ToString();
                    obj.Num_RG = item["Num_RG"].ToString();
                    obj.Nom_CR = item["Nom_CR"].ToString();
                    obj.Cod_CR_Superior = item["Cod_CR_Superior"].ToString();
                    obj.Nom_CR_Superior = item["Nom_CR_Superior"].ToString();
                    obj.Des_Motivo_Afastamento = item["Des_Motivo_Afastamento"].ToString();
                    obj.Num_Endereco = item["Num_Endereco"].ToString();
                    obj.Des_Complemento = item["Des_Complemento"].ToString();
                    obj.UF_Localidade = item["UF_Localidade"].ToString();

                    if (item["Dt_Inicio_Estabilidade_CIPA"].ToString() != "") {
                        obj.Dt_Inicio_Estabilidade_CIPA = DateTime.Parse(item["Dt_Inicio_Estabilidade_CIPA"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Inicio_Estabilidade_CIPA"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Inicio_Estabilidade_CIPA"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Inicio_Estabilidade_CIPA = DateTime.Parse("1900-01-01");
                    }

                    if (item["Dt_Fim_Estabilidade_CIPA"].ToString() != "") {
                        obj.Dt_Fim_Estabilidade_CIPA = DateTime.Parse(item["Dt_Fim_Estabilidade_CIPA"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Fim_Estabilidade_CIPA"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Fim_Estabilidade_CIPA"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Fim_Estabilidade_CIPA = DateTime.Parse("1900-01-01");
                    }

                    if (item["Dt_Venc_Contrato_1"].ToString() != "") {
                        obj.Dt_Venc_Contrato_1 = DateTime.Parse(item["Dt_Venc_Contrato_1"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Venc_Contrato_1"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Venc_Contrato_1"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Venc_Contrato_1 = DateTime.Parse("1900-01-01");
                    }

                    if (item["Dt_Venc_Contrato_2"].ToString() != "") {
                        obj.Dt_Venc_Contrato_2 = DateTime.Parse(item["Dt_Venc_Contrato_2"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Venc_Contrato_2"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Venc_Contrato_2"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Venc_Contrato_2 = DateTime.Parse("1900-01-01");
                    }

                    obj.Nom_Tipo_Cargo = item["Nom_Tipo_Cargo"].ToString();
                    obj.Cod_Gestor_Hierarq_1 = item["Cod_Gestor_Hierarq_1"].ToString();
                    obj.Cod_Gestor_Hierarq_2 = item["Cod_Gestor_Hierarq_2"].ToString();
                    obj.Cod_Gestor_Hierarq_3 = item["Cod_Gestor_Hierarq_3"].ToString();
                    obj.Cod_Gestor_Hierarq_4 = item["Cod_Gestor_Hierarq_4"].ToString();
                    obj.Cod_Gestor_Hierarq_5 = item["Cod_Gestor_Hierarq_5"].ToString();
                    obj.Cod_GH = item["Cod_GH"].ToString();
                    obj.Cod_Empresa_Gestor_Hierarq_1 = item["Cod_Empresa_Gestor_Hierarq_1"].ToString();
                    obj.Cod_Empresa_Gestor_Hierarq_2 = item["Cod_Empresa_Gestor_Hierarq_2"].ToString();
                    obj.Cod_Empresa_Gestor_Hierarq_3 = item["Cod_Empresa_Gestor_Hierarq_3"].ToString();
                    obj.Cod_Empresa_Gestor_Hierarq_4 = item["Cod_Empresa_Gestor_Hierarq_4"].ToString();
                    obj.Cod_Empresa_Gestor_Hierarq_5 = item["Cod_Empresa_Gestor_Hierarq_5"].ToString();
                    obj.Cod_Empresa_FPW = item["Cod_Empresa_FPW"].ToString();


                    if (item["Dt_Atualizacao_FPW"].ToString() != "") {
                        obj.Dt_Atualizacao_FPW = DateTime.Parse(item["Dt_Atualizacao_FPW"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Atualizacao_FPW"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Atualizacao_FPW"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Atualizacao_FPW = DateTime.Parse("1900-01-01");
                    }


                    if (item["Dt_Retorno_Afastamento"].ToString() != "") {
                        obj.Dt_Retorno_Afastamento = DateTime.Parse(item["Dt_Retorno_Afastamento"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Retorno_Afastamento"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Retorno_Afastamento"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Retorno_Afastamento = DateTime.Parse("1900-01-01");
                    }


                    obj.ind_PTH = item["ind_PTH"].ToString();
                    obj.ind_Readmitido = item["ind_Readmitido"].ToString();

                    if (item["Dt_Readmissao"].ToString() != "") {
                        obj.Dt_Readmissao = DateTime.Parse(item["Dt_Readmissao"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Readmissao"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Readmissao"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Readmissao = DateTime.Parse("1900-01-01");
                    }

                    obj.Des_Tipo_Rescisao = item["Des_Tipo_Rescisao"].ToString();
                    obj.Des_Submotivo_Rescisao = item["Des_Submotivo_Rescisao"].ToString();

                    //Hierarquia de superior conforme coluna Nom_Usuario_Superior
                    string[] lista = new string[2];

                    lista = _getNomeSuperiorImediatoPorNomeUsuario(obj.Nom_Usuario);
                    if (lista != null) {
                        obj._gestor1 = lista[0];
                        obj._gestor1_email = lista[1];
                        obj.Cod_Gestor_Hierarq_1 = lista[2];

                    }

                    if (obj._gestor1 != null) {
                        lista = _getNomeSuperiorImediatoPorNomeUsuario(obj._gestor1);
                        if (lista != null) {
                            obj._gestor2 = lista[0];
                            obj._gestor2_email = lista[1];
                            obj.Cod_Gestor_Hierarq_2 = lista[2];

                        }
                    }


                    if (obj._gestor2 != null) {
                        lista = _getNomeSuperiorImediatoPorNomeUsuario(obj._gestor2);
                        if (lista != null) {
                            obj._gestor3 = lista[0];
                            obj._gestor3_email = lista[1];
                            obj.Cod_Gestor_Hierarq_3 = lista[2];

                        }
                    }

                    if (obj._gestor3 != null) {
                        lista = _getNomeSuperiorImediatoPorNomeUsuario(obj._gestor3);
                        if (lista != null) {
                            obj._gestor4 = lista[0];
                            obj._gestor4_email = lista[1];
                            obj.Cod_Gestor_Hierarq_4 = lista[2];

                        }
                    }

                    if (obj._gestor4 != null) {
                        lista = _getNomeSuperiorImediatoPorNomeUsuario(obj._gestor4);
                        if (lista != null) {
                            obj._gestor5 = lista[0];
                            obj._gestor5_email = lista[1];
                            obj.Cod_Gestor_Hierarq_5 = lista[2];
                        }
                    }
                }

                return obj;
            }
            catch (Exception) {

                return null;
            }
        }

        private impAssociado _impAssociadoObjGestoresTabelao(DataTable dt) {

            impAssociado obj = new impAssociado();
            try {


                foreach (DataRow item in dt.Rows) {

                    obj.Cod_Empresa = item["Cod_Empresa"].ToString();
                    obj.Cod_Matricula = item["Cod_Matricula"].ToString();
                    obj.Nom_Usuario = item["Nom_Usuario"].ToString();
                    obj.Tp_Sexo = item["Tp_Sexo"].ToString();
                    obj.Dt_Nascimento = item["Dt_Nascimento"].ToString();
                    obj.Dt_Admissao = item["Dt_Admissao"].ToString();
                    obj.Dt_Inicio_Ferias = item["Dt_Inicio_Ferias"].ToString();
                    obj.Dt_Fim_Ferias = item["Dt_Fim_Ferias"].ToString();
                    obj.Dt_Inicio_Afastamento = item["Dt_Inicio_Afastamento"].ToString();
                    obj.Dt_Fim_Afastamento = item["Dt_Fim_Afastamento"].ToString();
                    obj.Dt_Demissao = item["Dt_Demissao"].ToString();
                    obj.Cod_Cpf = item["Cod_Cpf"].ToString();
                    obj.Cod_Cargo = item["Cod_Cargo"].ToString();
                    obj.Nom_Cargo = item["Nom_Cargo"].ToString();
                    obj.num_Centro_Custo = item["num_Centro_Custo"].ToString();
                    obj.Nom_Centro_Custo = item["Nom_Centro_Custo"].ToString();
                    obj.Flg_Duplicidade = item["Flg_Duplicidade"].ToString();
                    obj.idt_Categoria = item["idt_Categoria"].ToString();
                    obj.Cod_CR = item["Cod_CR"].ToString();
                    obj.Idt_Num_PIS = item["Idt_Num_PIS"].ToString();
                    obj.Nom_Empresa = item["Nom_Empresa"].ToString();
                    obj.Des_Email = item["Des_Email"].ToString();
                    obj.Idt_Telefone_Usuario = item["Idt_Telefone_Usuario"].ToString();
                    obj.Idt_Celular_Usuario = item["Idt_Celular_Usuario"].ToString();
                    obj.Cod_Matricula_Superior = item["Cod_Matricula_Superior"].ToString();
                    obj.Nom_Usuario_Superior = item["Nom_Usuario_Superior"].ToString();
                    obj.Num_Centro_Custo_Superior = item["Num_Centro_Custo_Superior"].ToString();
                    obj.Nom_Centro_Custo_Superior = item["Nom_Centro_Custo_Superior"].ToString();
                    obj.Des_Endereco = item["Des_Endereco"].ToString();
                    obj.Nom_Bairro = item["Nom_Bairro"].ToString();
                    obj.Nom_Localidade = item["Nom_Localidade"].ToString();
                    obj.Num_Cep = item["Num_Cep"].ToString();
                    obj.Num_RG = item["Num_RG"].ToString();
                    obj.Nom_CR = item["Nom_CR"].ToString();
                    obj.Cod_CR_Superior = item["Cod_CR_Superior"].ToString();
                    obj.Nom_CR_Superior = item["Nom_CR_Superior"].ToString();
                    obj.Des_Motivo_Afastamento = item["Des_Motivo_Afastamento"].ToString();
                    obj.Num_Endereco = item["Num_Endereco"].ToString();
                    obj.Des_Complemento = item["Des_Complemento"].ToString();
                    obj.UF_Localidade = item["UF_Localidade"].ToString();

                    if (item["Dt_Inicio_Estabilidade_CIPA"].ToString() != "") {
                        obj.Dt_Inicio_Estabilidade_CIPA = DateTime.Parse(item["Dt_Inicio_Estabilidade_CIPA"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Inicio_Estabilidade_CIPA"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Inicio_Estabilidade_CIPA"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Inicio_Estabilidade_CIPA = DateTime.Parse("1900-01-01");
                    }

                    if (item["Dt_Fim_Estabilidade_CIPA"].ToString() != "") {
                        obj.Dt_Fim_Estabilidade_CIPA = DateTime.Parse(item["Dt_Fim_Estabilidade_CIPA"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Fim_Estabilidade_CIPA"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Fim_Estabilidade_CIPA"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Fim_Estabilidade_CIPA = DateTime.Parse("1900-01-01");
                    }

                    if (item["Dt_Venc_Contrato_1"].ToString() != "") {
                        obj.Dt_Venc_Contrato_1 = DateTime.Parse(item["Dt_Venc_Contrato_1"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Venc_Contrato_1"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Venc_Contrato_1"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Venc_Contrato_1 = DateTime.Parse("1900-01-01");
                    }

                    if (item["Dt_Venc_Contrato_2"].ToString() != "") {
                        obj.Dt_Venc_Contrato_2 = DateTime.Parse(item["Dt_Venc_Contrato_2"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Venc_Contrato_2"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Venc_Contrato_2"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Venc_Contrato_2 = DateTime.Parse("1900-01-01");
                    }

                    obj.Nom_Tipo_Cargo = item["Nom_Tipo_Cargo"].ToString();
                    obj.Cod_Gestor_Hierarq_1 = item["Cod_Gestor_Hierarq_1"].ToString();
                    obj.Cod_Gestor_Hierarq_2 = item["Cod_Gestor_Hierarq_2"].ToString();
                    obj.Cod_Gestor_Hierarq_3 = item["Cod_Gestor_Hierarq_3"].ToString();
                    obj.Cod_Gestor_Hierarq_4 = item["Cod_Gestor_Hierarq_4"].ToString();
                    obj.Cod_Gestor_Hierarq_5 = item["Cod_Gestor_Hierarq_5"].ToString();
                    obj.Cod_GH = item["Cod_GH"].ToString();
                    obj.Cod_Empresa_Gestor_Hierarq_1 = item["Cod_Empresa_Gestor_Hierarq_1"].ToString();
                    obj.Cod_Empresa_Gestor_Hierarq_2 = item["Cod_Empresa_Gestor_Hierarq_2"].ToString();
                    obj.Cod_Empresa_Gestor_Hierarq_3 = item["Cod_Empresa_Gestor_Hierarq_3"].ToString();
                    obj.Cod_Empresa_Gestor_Hierarq_4 = item["Cod_Empresa_Gestor_Hierarq_4"].ToString();
                    obj.Cod_Empresa_Gestor_Hierarq_5 = item["Cod_Empresa_Gestor_Hierarq_5"].ToString();
                    obj.Cod_Empresa_FPW = item["Cod_Empresa_FPW"].ToString();


                    if (item["Dt_Atualizacao_FPW"].ToString() != "") {
                        obj.Dt_Atualizacao_FPW = DateTime.Parse(item["Dt_Atualizacao_FPW"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Atualizacao_FPW"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Atualizacao_FPW"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Atualizacao_FPW = DateTime.Parse("1900-01-01");
                    }


                    if (item["Dt_Retorno_Afastamento"].ToString() != "") {
                        obj.Dt_Retorno_Afastamento = DateTime.Parse(item["Dt_Retorno_Afastamento"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Retorno_Afastamento"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Retorno_Afastamento"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Retorno_Afastamento = DateTime.Parse("1900-01-01");
                    }


                    obj.ind_PTH = item["ind_PTH"].ToString();
                    obj.ind_Readmitido = item["ind_Readmitido"].ToString();

                    if (item["Dt_Readmissao"].ToString() != "") {
                        obj.Dt_Readmissao = DateTime.Parse(item["Dt_Readmissao"].ToString().Substring(0, 4) + "-"
                                                                        + item["Dt_Readmissao"].ToString().Substring(4, 2) + "-"
                                                                        + item["Dt_Readmissao"].ToString().Substring(6, 2));
                    } else {
                        obj.Dt_Readmissao = DateTime.Parse("1900-01-01");
                    }

                    obj.Des_Tipo_Rescisao = item["Des_Tipo_Rescisao"].ToString();
                    obj.Des_Submotivo_Rescisao = item["Des_Submotivo_Rescisao"].ToString();

                    //Hierarquia de superior conforme coluna Nom_Usuario_Superior
                    string[] lista = new string[2];

                    lista = _getNomeSuperiorImediatoPorMatricula(obj.Cod_Gestor_Hierarq_1);
                    if (lista != null) {
                        obj._gestor1 = lista[0];
                        obj._gestor1_email = lista[1];
                        obj.Cod_Gestor_Hierarq_1 = lista[2];

                    }

                    if (obj._gestor1 != null) {
                        lista = _getNomeSuperiorImediatoPorMatricula(obj.Cod_Gestor_Hierarq_2);
                        if (lista != null) {
                            obj._gestor2 = lista[0];
                            obj._gestor2_email = lista[1];
                            obj.Cod_Gestor_Hierarq_2 = lista[2];

                        }
                    }


                    if (obj._gestor2 != null) {
                        lista = _getNomeSuperiorImediatoPorMatricula(obj.Cod_Gestor_Hierarq_3);
                        if (lista != null) {
                            obj._gestor3 = lista[0];
                            obj._gestor3_email = lista[1];
                            obj.Cod_Gestor_Hierarq_3 = lista[2];

                        }
                    }

                    if (obj._gestor3 != null) {
                        lista = _getNomeSuperiorImediatoPorMatricula(obj.Cod_Gestor_Hierarq_4);
                        if (lista != null) {
                            obj._gestor4 = lista[0];
                            obj._gestor4_email = lista[1];
                            obj.Cod_Gestor_Hierarq_4 = lista[2];

                        }
                    }

                    if (obj._gestor4 != null) {
                        lista = _getNomeSuperiorImediatoPorMatricula(obj.Cod_Gestor_Hierarq_5);
                        if (lista != null) {
                            obj._gestor5 = lista[0];
                            obj._gestor5_email = lista[1];
                            obj.Cod_Gestor_Hierarq_5 = lista[2];
                        }
                    }
                }

                return obj;
            }
            catch (Exception) {

                return null;
            }
        }

        #endregion

        #region DAL
        private DataTable _getDataTableSuperiorImediato(string _getHieraraquiaPor, string _infoBusca) {
            DataTable table = new DataTable();
            try {

                DataColumn column;
                DataRow row;

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "cpf";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "matricula";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "data_admissao";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "data_demissao";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Nome";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Gestor_1";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Gestor_2";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Gestor_3";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Gestor_4";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Gestor_5";
                table.Columns.Add(column);


                //listar informações da IMP Associado
                sql = "SELECT * FROM db_Corporate_V3.dbo.tb_Imp_Associado WHERE ";
                switch (_getHieraraquiaPor.ToUpper()) {
                    case "CPF":
                        sql += "Cod_Cpf = " + objCon.valorSql(_infoBusca) + " ";
                        break;
                    case "MATRICULA":
                        sql += "Cod_Matricula = " + objCon.valorSql(_infoBusca) + " ";
                        break;
                    case "NOME ASSOCIADO":
                        sql += "Nom_Usuario like '%" + _infoBusca + "%' ";
                        break;
                }
                DataTable dt_geral = new DataTable();
                dt_geral = objCon.retornaDataTable(sql);

                //Carregar as informações após validar cada um dos superiores imediatos...
                if (dt_geral.Rows.Count > 0) {
                    foreach (DataRow item in dt_geral.Rows) {

                        impAssociado info = new impAssociado();
                        info = getPorCPFSupImediado(item["Cod_Cpf"].ToString());

                        row = table.NewRow();
                        row["cpf"] = item["Cod_Cpf"].ToString();
                        row["matricula"] = item["Cod_Matricula"].ToString();
                        row["data_admissao"] = hlp.formataStringDataYYYYMMDD(item["Dt_Admissao"].ToString());
                        row["data_demissao"] = hlp.formataStringDataYYYYMMDD(item["Dt_Demissao"].ToString());
                        row["Nome"] = item["Nom_Usuario"].ToString();
                        row["Gestor_1"] = info._gestor1;
                        row["Gestor_2"] = info._gestor2;
                        row["Gestor_3"] = info._gestor3;
                        row["Gestor_4"] = info._gestor4;
                        row["Gestor_5"] = info._gestor5;
                        table.Rows.Add(row);
                    }
                }

                return table;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMP ASSOCIADO - DATATABLE INFO SUPERIOR IMEDIATO (DAL)");
                return null;
            }
        }


        private impAssociado _getPorNomeUsuarioSupImediado(string _nomeUsuario) {
            try {

                sql = "select top 1 * from db_Corporate_V3.dbo.tb_Imp_Associado " +
                            "where Nom_Usuario = " + objCon.valorSql(_nomeUsuario) + " ";
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(sql);
                return _impAssociadoObjSupImediado(dt);

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMP ASSOCIADO - CAPTURAR POR NOME USUÁRIO (DAL)");
                return null;
            }
        }

        private impAssociado _getPorCPFSupImediado(string _cpf) {
            try {

                sql = "select top 1 * from db_Corporate_V3.dbo.tb_Imp_Associado " +
                            "where Cod_Cpf = " + objCon.valorSql(_cpf) + " ";
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(sql);
                return _impAssociadoObjSupImediado(dt);

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMP ASSOCIADO - CAPTURAR POR CPF (DAL)");
                return null;
            }
        }

        private impAssociado _getPorCPFGestoresTabelao(string _cpf) {
            try {

                sql = "select top 1 * from db_Corporate_V3.dbo.tb_Imp_Associado " +
                            "where Cod_Cpf = " + objCon.valorSql(_cpf) + " ";
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(sql);
                return _impAssociadoObjGestoresTabelao(dt);

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMP ASSOCIADO - CAPTURAR POR CPF (DAL)");
                return null;
            }
        }

        private impAssociado _getPorMatriculaSupImediado(string _matricula) {
            try {

                sql = "select top 1 * from db_Corporate_V3.dbo.tb_Imp_Associado " +
                            "where Cod_Matricula = " + objCon.valorSql(_matricula) + " ";
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(sql);
                return _impAssociadoObjSupImediado(dt);

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMP ASSOCIADO - CAPTURAR POR MATRICULA (DAL)");
                return null;
            }
        }

        private string[] _getNomeSuperiorImediatoPorNomeUsuario(string _nomeUsuario) {
            try {

                sql = "select * " +
                        "from db_Corporate_V3.dbo.tb_Imp_Associado " +
                        "where Nom_Usuario = " +
                        "(select Nom_Usuario_Superior from db_Corporate_V3.dbo.tb_Imp_Associado where Nom_Usuario = " + objCon.valorSql(_nomeUsuario) + ") ";

                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(sql);
                if (dt.Rows.Count > 0) {
                    foreach (DataRow item in dt.Rows) {
                        string[] lista = new string[3];
                        lista[0] = item["Nom_Usuario"].ToString();
                        lista[1] = item["Des_Email"].ToString();
                        lista[2] = item["Cod_Matricula"].ToString();
                        return lista;
                    }
                }

                return null;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMP ASSOCIADO - CAPTURAR NOME SUPERIOR IMEDIATO POR NOME USUARIO (DAL)");
                return null;
            }
        }

        private string[] _getNomeSuperiorImediatoPorMatricula(string _matricula) {
            try {

                sql = "select * " +
                        "from db_Corporate_V3.dbo.tb_Imp_Associado " +
                        "where Nom_Usuario = " +
                        "(select Nom_Usuario_Superior from db_Corporate_V3.dbo.tb_Imp_Associado where Cod_Matricula = " + objCon.valorSql(_matricula) + ") ";

                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(sql);
                if (dt.Rows.Count > 0) {
                    foreach (DataRow item in dt.Rows) {
                        string[] lista = new string[3];
                        lista[0] = item["Nom_Usuario"].ToString();
                        lista[1] = item["Des_Email"].ToString();
                        lista[2] = item["Cod_Matricula"].ToString();
                        return lista;
                    }
                }

                return null;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMP ASSOCIADO - CAPTURAR NOME SUPERIOR IMEDIATO POR MATRICULA (DAL)");
                return null;
            }
        }

        #endregion

        #region BLL
        public string getNomeSuperiorImediatoPorNomeUsuario(string _nomeUsuario) {
            string[] lista = new string[2];
            lista = _getNomeSuperiorImediatoPorNomeUsuario(_nomeUsuario);
            return lista[0];
        }

        public impAssociado getPorMatriculaSupImediado(string _matricula) {
            return _getPorMatriculaSupImediado(_matricula);
        }

        public impAssociado getPorCPFSupImediado(string _cpf) {
            return _getPorCPFSupImediado(_cpf);
        }

        public impAssociado getPorCPFGestoresTabelao(string _cpf) {
            return _getPorCPFGestoresTabelao(_cpf);
        }

        public impAssociado getPorNomeUsuarioSupImediado(string _nomeUsuario) {
            return _getPorNomeUsuarioSupImediado(_nomeUsuario);
        }

        public DataTable getDataTableGestoresPorCpf(string _cpf, bool supImediato = true) {

            try {


                impAssociado info = new impAssociado();

                if (supImediato) {
                    info = getPorCPFSupImediado(_cpf);
                } else {
                    info = getPorCPFGestoresTabelao(_cpf);
                }

                DataTable table = new DataTable();
                DataColumn column;
                DataRow row;

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "cpf";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "matricula";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Nome";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Gestor_1";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Gestor_2";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Gestor_3";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Gestor_4";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Gestor_5";
                table.Columns.Add(column);


                row = table.NewRow();
                row["cpf"] = info.Cod_Cpf;
                row["matricula"] = info.Cod_Matricula;
                row["Nome"] = info.Nom_Usuario;
                row["Gestor_1"] = info._gestor1;
                row["Gestor_2"] = info._gestor2;
                row["Gestor_3"] = info._gestor3;
                row["Gestor_4"] = info._gestor4;
                row["Gestor_5"] = info._gestor5;
                table.Rows.Add(row);


                return table;

            }
            catch (Exception ex) {

                log.registrarLog(ex.ToString(), "IMP ASSOCIADO - DATATABLE GESTORES (BLL)");
                return null;
            }



        }

        public ListView CarregarListViewGestores(ListView lst, string _cpf, bool supImediato = true) {
            try {
                DataTable dt = new DataTable();
                dt = getDataTableGestoresPorCpf(_cpf, supImediato);
                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = false;
                lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("CPF", 120, HorizontalAlignment.Center);
                lst.Columns.Add("MATRICULA", 120, HorizontalAlignment.Center);
                lst.Columns.Add("NOME", 270, HorizontalAlignment.Left);
                lst.Columns.Add("1º GESTOR", 250, HorizontalAlignment.Left);
                lst.Columns.Add("2º GESTOR", 250, HorizontalAlignment.Left);
                lst.Columns.Add("3º GESTOR", 250, HorizontalAlignment.Left);
                lst.Columns.Add("4º GESTOR", 250, HorizontalAlignment.Left);
                lst.Columns.Add("5º GESTOR", 250, HorizontalAlignment.Left);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["CPF"].ToString();
                        item.SubItems.Add(linha["MATRICULA"].ToString());
                        item.SubItems.Add(linha["NOME"].ToString());
                        item.SubItems.Add(linha["gestor_1"].ToString());
                        item.SubItems.Add(linha["gestor_2"].ToString());
                        item.SubItems.Add(linha["gestor_3"].ToString());
                        item.SubItems.Add(linha["gestor_4"].ToString());
                        item.SubItems.Add(linha["gestor_5"].ToString());
                        item.ImageKey = "9";
                        lst.Items.Add(item);

                    }
                }
                return lst;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DADOS CADASTRAIS IMP ASSOCIADO - LISTVIEW (BLL)");
                return null;
            }
        }

        public void carregarDataGridViewSuperiorImediato(string _getHieraraquiaPor, string _infoBusca, DataGridView dgv) {

            DataTable dt = new DataTable();
            dt = _getDataTableSuperiorImediato(_getHieraraquiaPor, _infoBusca);
            dgv.DataSource = dt;
        }


        #endregion

    }
}
