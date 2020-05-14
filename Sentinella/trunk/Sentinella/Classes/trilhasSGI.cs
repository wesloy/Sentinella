﻿using System;
using System.Data;
using System.Windows.Forms;


namespace Sentinella {


    //CREATE TABLE [dbo].[w_trilhasTreinamentos] (
    //    [id]                    INT            IDENTITY (1, 1) NOT NULL,
    //    [fila]                  NVARCHAR (100) DEFAULT ('SEM INFO') NOT NULL,
    //    [periodoCobranca]       INT            NULL,
    //    [des_turma]             NVARCHAR (MAX) DEFAULT ('SEM INFO') NOT NULL,
    //    [des_nome]              NVARCHAR (MAX) DEFAULT ('SEM INFO') NOT NULL,
    //    [cpf]                   NVARCHAR (15)  DEFAULT ('SEM INFO') NOT NULL,
    //    [total_cursos]          INT            DEFAULT ((0)) NOT NULL,
    //    [vol_nao_concluido]     INT            DEFAULT ((0)) NOT NULL,
    //    [vol_concluido]         INT            DEFAULT ((0)) NOT NULL,
    //    [percentual_concluido]  INT            DEFAULT ((0)) NOT NULL,
    //    [gestor_1]              NVARCHAR (MAX) DEFAULT ('SEM INFO') NULL,
    //    [gestor_2]              NVARCHAR (MAX) DEFAULT ('SEM INFO') NULL,
    //    [gestor_3]              NVARCHAR (MAX) DEFAULT ('SEM INFO') NULL,
    //    [gestor_4]              NVARCHAR (MAX) DEFAULT ('SEM INFO') NULL,
    //    [gestor_5]              NVARCHAR (MAX) DEFAULT ('SEM INFO') NULL,
    //    [data_admissao]         DATETIME       NULL,
    //    [data_demissao]         DATETIME       NULL,
    //    [data_importacao]       DATETIME       DEFAULT ('1900-01-01 00:00:00') NOT NULL,
    //    [id_importacao]         INT            DEFAULT ((0)) NOT NULL,
    //    [email_enviado]         BIT            DEFAULT ((0)) NOT NULL,
    //    [emails_enderecos]      NVARCHAR (MAX) DEFAULT ('SEM INFO') NULL,
    //    [data_envio_email]      DATETIME       DEFAULT ('1900-01-01 00:00:00') NOT NULL,
    //    [id_analista_seguranca] INT            DEFAULT ((0)) NOT NULL
    //);


    class trilhasSGI {

        #region Variaveis 
        string sql = "";
        long retorno = 0;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        #endregion

        #region DTO
        public int id { get; set; }
        public string fila { get; set; }
        public int periodoCobranca { get; set; }
        public string des_turma { get; set; }
        public string des_nome { get; set; }
        public string cpf { get; set; }
        public int total_cursos { get; set; }
        public int vol_nao_concluido { get; set; }
        public int vol_concluido { get; set; }
        public int percentual_concluido { get; set; }
        public string gestor_1 { get; set; }
        public string gestor_2 { get; set; }
        public string gestor_3 { get; set; }
        public string gestor_4 { get; set; }
        public string gestor_5 { get; set; }
        public DateTime data_admissao { get; set; }
        public DateTime data_demissao { get; set; }
        public DateTime data_importacao { get; set; }
        public int id_importacao { get; set; }
        public bool email_enviado { get; set; }
        public string emails_enderecos { get; set; }
        public DateTime data_envio_email { get; set; }
        public int id_analista_seguranca { get; set; }
        #endregion

        #region CONSTRUTORES
        public trilhasSGI() { }

        /// <summary>
        /// Capturar registro através do ID
        /// </summary>
        /// <param name="_id"></param>
        public trilhasSGI(int _id) {
            DataTable dt = new DataTable();
            dt = _capturarRegistroPorID(_id);
            if (dt.Rows.Count > 0) {
                foreach (DataRow item in dt.Rows) {
                    id = int.Parse(item["id"].ToString());
                    des_turma = item["des_turma"].ToString();
                    des_nome = item["des_nome"].ToString();
                    cpf = item["cpf"].ToString();
                    total_cursos = int.Parse(item["total_cursos"].ToString());
                    vol_nao_concluido = int.Parse(item["vol_nao_concluido"].ToString());
                    vol_concluido = int.Parse(item["vol_concluido"].ToString());
                    percentual_concluido = int.Parse(item["percentual_concluido"].ToString());
                    gestor_1 = item["gestor_1"].ToString();
                    gestor_2 = item["gestor_2"].ToString();
                    gestor_3 = item["gestor_3"].ToString();
                    gestor_4 = item["gestor_4"].ToString();
                    gestor_5 = item["gestor_5"].ToString();
                    data_importacao = DateTime.Parse(item["data_importacao"].ToString());
                    id_importacao = int.Parse(item["id_importacao"].ToString());
                    email_enviado = bool.Parse(item["email_enviado"].ToString());
                    data_envio_email = DateTime.Parse(item["data_envio_email"].ToString());
                    id_analista_seguranca = int.Parse(item["id_analista_seguranca"].ToString());
                }

            }
        }

        /// <summary>
        /// Utilizar para finalizar registros, visto que atualiza os campos de envio de e-mail, data de envio, id do analista que enviou.
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_email_enviado"></param>
        public trilhasSGI(int _id, bool _email_enviado, string _emails_enderecos) {

            DataTable dt = new DataTable();
            dt = _capturarRegistroPorID(_id);

            if (dt.Rows.Count > 0) {
                foreach (DataRow item in dt.Rows) {
                    id = int.Parse(item["id"].ToString());
                    fila = item["fila"].ToString();
                    periodoCobranca = int.Parse(item["periodoCobranca"].ToString());
                    des_turma = item["des_turma"].ToString();
                    des_nome = item["des_nome"].ToString();
                    cpf = item["cpf"].ToString();
                    total_cursos = int.Parse(item["total_cursos"].ToString());
                    vol_nao_concluido = int.Parse(item["vol_nao_concluido"].ToString());
                    vol_concluido = int.Parse(item["vol_concluido"].ToString());
                    percentual_concluido = int.Parse(item["percentual_concluido"].ToString());
                    gestor_1 = item["gestor_1"].ToString();
                    gestor_2 = item["gestor_2"].ToString();
                    gestor_3 = item["gestor_3"].ToString();
                    gestor_4 = item["gestor_4"].ToString();
                    gestor_5 = item["gestor_5"].ToString();
                    data_importacao = DateTime.Parse(item["data_importacao"].ToString());
                    id_importacao = int.Parse(item["id_importacao"].ToString());
                    email_enviado = _email_enviado;
                    emails_enderecos = _emails_enderecos;
                    data_envio_email = hlp.dataHoraAtual();
                    id_analista_seguranca = Constantes.id_BD_logadoFerramenta;
                }

            }
        }
        #endregion

        #region DAL

        private DataTable _listarPendenciasPorLider(string filtro) {
            try {
                sql = "select 1, ";

                switch (filtro) {
                    case "GESTOR 2":
                        sql += "iif(gestor_2 is null,'SEM INFO', gestor_2) as lider ";
                        sql += "from w_trilhasTreinamentos ";
                        sql += "group by gestor_2 ";
                        sql += "order by gestor_2 ";
                        break;
                    case "GESTOR 3":
                        sql += "iif(gestor_3 is null,'SEM INFO',gestor_3) as lider ";
                        sql += "from w_trilhasTreinamentos ";
                        sql += "group by gestor_3 ";
                        sql += "order by gestor_3 ";
                        break;
                    case "GESTOR 4":
                        sql += "iif(gestor_4 is null,'SEM INFO',gestor_4) as lider ";
                        sql += "from w_trilhasTreinamentos ";
                        sql += "group by gestor_4 ";
                        sql += "order by gestor_4 ";
                        break;
                    case "GESTOR 5":
                        sql += "iif(gestor_5 is null,'SEM INFO',gestor_5) as lider ";
                        sql += "from w_trilhasTreinamentos ";
                        sql += "group by gestor_5 ";
                        sql += "order by gestor_5 ";
                        break;
                }

                return objCon.retornaDataTable(sql);

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - LISTAR COORDENADORES (DAL)");
                return null;
            }

        }

        private long _abrirProducao() {
            try {

                long volAtualizado = 0;

                #region documentacao
                //01 - atualizar historico de funcionarios
                //garantir que esteja atualizado a base de henriquecimento de informações

                //02 - capturar todos os registros da base Sinergy das trilhas:
                //646722 #SouAlgar Operações (Atendentes e operadores)
                //646350 #SouAlgar (demais cargos)
                //640280 Trilhas SGI

                //03 - calculuar percentual concluído dos cursos ligados a SGI

                //04 - henriquecimento de informação com a tabela imp_associados
                //Hierarquia, data admissao, data demissao, afastamento, férias

                //05 - Carregar base w_trilhasTreinamento
                //validar se deve ser insert (novo registro) ou update (registro que ainda não teve a trilha concluída na vigencia atual)

                //06 - seperar os novatos 
                //até 10 meses - devem ter feito os cursos SGI dentro das trilhas #SouAlgar ou #SouAlgar Operações
                //entre 10 e 12 meses, já se pode fazer alerta a respeito da trilha SGI, que dever ser feita anualmente no aniversário de empresa do associado
                //mais que 1 ano, refazer o curso anualmente (TRILHA SGI), com vencimento no aniversário do associado

                //07 - importar ou atualizar


                //Observações:
                //período inicial de cobrança/alerta à partir de 60 dias antes do aniversário de empresa
                //futuramente terá o prazo máximo de 30 dias pós aniversário para cobrança, depois disto laudo de incidente de segurança
                //este controle ficará na tela de análise e categorização
                #endregion

                //carregar form Barra de Progresso de preparação dos dados
                frmProgressBar frm = new frmProgressBar(3);
                frm.Show();


                //passo 01
                importacoes imp = new importacoes();
                imp.CadastroGeralProcedure(false);
                frm.atualizarBarra(1);

                //passo 02 a 04

                sql = "select c.cod_trilha, c.des_trilha, c.des_nome, ";
                sql += "replace(replace(c.cod_cpf, '.', ''), '-', '') as cpf, ";
                sql += "count(c.des_conteudo) as total_cursos, ";
                sql += "sum(iif(c.num_conclusao = '0', 1, 0)) as vol_nao_concluido, ";
                sql += "sum(iif(c.num_conclusao = '100', 1, 0)) as vol_concluido, ";
                sql += "sum(iif(c.num_conclusao = '100', 1, 0)) * 100 / count(c.des_conteudo) as percentual_concluido, "; //calculo de percentual concluído
                sql += "max(dt_fim) as data_conclusao_ultimo_curso_trilha, "; //data do último curso da trilha feito, usar para validar se trilha concluída dentro da vigencia atual
                sql += "(select top 1 gestor_1 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_1, "; //inicio do henriquecimento
                sql += "(select top 1 gestor_2 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_2, ";
                sql += "(select top 1 gestor_3 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_3, ";
                sql += "(select top 1 gestor_4 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_4, ";
                sql += "(select top 1 gestor_5 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_5, ";
                sql += "(select top 1 data_de_admissao from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_admissao, ";
                sql += "(select top 1 data_demissao from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_demissao, ";
                sql += "(select top 1 data_inicio_ferias from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_ferias_inicio, ";
                sql += "(select top 1 data_fim_ferias from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_ferias_fim, ";
                sql += "(select top 1 data_inicio_afastamento from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_afastamento_inicio, ";
                sql += "(select top 1 data_fim_afastamento from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_afastamento_fim, "; //fim do henriquecimento
                sql += "GETDATE() as data_importacao, "; //data-hora única de importação
                sql += Constantes.id_BD_logadoFerramenta + " as id_importacao "; //setando o id do importador
                sql += "from db_TreinamentoSinergyRH.dbo.TB_TRILHAS c ";
                sql += "inner join w_trilhasTreinamentos_cursos f on c.Id_Conteudo = f.cod_curso "; //Garantindo que sejam apenas os cursos SGI                
                sql += "inner join w_trilhasTreinamentos_trilhas t on c.cod_trilha = t.cod_trilha "; //Garantindo que sejam apenas os Trilhas monitoradas 
                sql += "where c.des_status = 'Ativo' ";
                sql += "group by c.cod_trilha, c.des_trilha, c.des_nome, c.cod_cpf ";


                #region DECOMISSIONADO_06052020
                //Selecionando informações do banco de dados com filtro de usuários que ainda não finalizaram a trilha SGI
                //sql = "Select c.des_turma, c.des_nome, " +
                //            "replace(replace(c.cod_cpf, '.', ''), '-', '') as cpf, " +
                //            "count(c.des_conteudo) as total_cursos, " +
                //            "sum(iif(c.num_conclusao = '0', 1, 0)) as vol_nao_concluido, " +
                //            "sum(iif(c.num_conclusao = '100', 1, 0)) as vol_concluido, " +
                //            "sum(iif(c.num_conclusao = '100', 1, 0)) * 100 / count(c.des_conteudo) as percentual_concluido, " +
                //            "(select top 1 gestor_1 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_1, " +
                //            "(select top 1 gestor_2 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_2, " +
                //            "(select top 1 gestor_3 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_3, " +
                //            "(select top 1 gestor_4 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_4, " +
                //            "(select top 1 gestor_5 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_5, " +
                //            "(select top 1 data_de_admissao from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_admissao, " +
                //            "(select top 1 data_demissao from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_demissao, " +
                //            "GETDATE() as data_importacao, " +
                //            Constantes.id_BD_logadoFerramenta + " as id_importacao " +
                //            "from db_TreinamentoSinergyRH.dbo.TB_TRILHAS c left join w_trilhasTreinamentos t on c.des_nome = t.des_nome and c.des_turma = t.des_turma and t.cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') " +
                //            "where c.cod_trilha in(646722, 646350, 640280) and c.des_status = 'Ativo' and (t.id is null or t.email_enviado = 1) " +
                //            "group by c.des_turma, c.des_nome, c.cod_cpf " +
                //            "having sum(iif(c.num_conclusao = '100', 1, 0)) * 100 / count(c.des_conteudo) < 100 ";
                #endregion

                DataTable dt_TrilhasSGI = new DataTable();
                dt_TrilhasSGI = objCon.retornaDataTable(sql);
                frm.atualizarBarra(2);

                //Validando se tem vol para trabalhar
                if (dt_TrilhasSGI.Rows.Count == 0) {
                    return 0;
                }


                //passo 05
                sql = "Select * from w_trilhasTreinamentos ";
                sql += "Where 1 = 1 ";
                sql += "and vigencia_ano = " + objCon.valorSql(DateTime.Today.Year);
                DataTable dt_base = new DataTable();
                dt_base = objCon.retornaDataTable(sql);
                frm.atualizarBarra(3);

                frm.Close();



                //passo 06 e 07
                //carregar form Barra de Progresso de preparação dos dados
                frmProgressBar frm2 = new frmProgressBar(dt_TrilhasSGI.Rows.Count);
                //frm2.atualizarBarra(0);
                frm2.Show();

                //Passando por cada linha das trilhas para importar ou não
                int totalRegistros = 0;
                foreach (DataRow item in dt_TrilhasSGI.Rows) {


                    totalRegistros += 1;

                    //sem data de admissião
                    if (item["data_admissao"].ToString().Equals("")) {
                        frm2.atualizarBarra(totalRegistros);
                        continue;
                    }



                    TimeSpan intervaloContratacao = DateTime.Today - DateTime.Parse(item["data_admissao"].ToString());
                    int vigencia_ano = DateTime.Today.Year;
                    DateTime vigencia_inicio = new DateTime();
                    DateTime vigencia_fim = new DateTime();
                    bool importar = false;

                    if (intervaloContratacao.Days < 301) {
                        //se até 10 meses cobrar trilhas:
                        //646722 #SouAlgar Operações (Atendentes e operadores)
                        //646350 #SouAlgar (demais cargos)
                        //data de inicio e fim de vigência é diferente

                        if (int.Parse(item["cod_trilha"].ToString()).Equals(646722) || int.Parse(item["cod_trilha"].ToString()).Equals(646350)) {
                            //validando se a trilha que esta sendo lida no momento é equivalente ao tempo de contratação

                            vigencia_inicio = DateTime.Parse(item["data_admissao"].ToString());
                            vigencia_fim = DateTime.Parse(item["data_admissao"].ToString()).AddMonths(10);

                            importar = true;
                        }

                    } else {
                        //Mais que 10 meses cobrar trilha:
                        //640280 Trilhas SGI
                        //data de inicio e fim de vigência é diferente

                        if (int.Parse(item["cod_trilha"].ToString()).Equals(640280)) {
                            //validando se a trilha que esta sendo lida no momento é equivalente ao tempo de contratação

                            vigencia_inicio = Convert.ToDateTime(((DateTime.Today.Year - 1) + "- " + DateTime.Parse(item["data_admissao"].ToString()).Month + "- " + DateTime.Parse(item["data_admissao"].ToString()).Day));
                            vigencia_fim = Convert.ToDateTime((DateTime.Today.Year + "- " + DateTime.Parse(item["data_admissao"].ToString()).Month + "- " + DateTime.Parse(item["data_admissao"].ToString()).Day));

                            importar = true;
                        }


                    }


                    if (!importar) {
                        // continuando caso não seja um registro à ser importado
                        frm2.atualizarBarra(totalRegistros);
                        continue;
                    }


                    //filtrar registro na base já importada para o Sentinella e determinar se é um INSERT ou UPDATE
                    string expressao = "";
                    DataRow[] resultado = null;
                    expressao = "vigencia_ano = " + vigencia_ano + " and cpf = '" + item["cpf"].ToString() + "' and des_trilha = '" + item["des_trilha"].ToString() + "'";
                    resultado = dt_base.Select(expressao);
                    DateTime valorData = new DateTime();

                    if (resultado.Length > 0) {

                        // se foi localizado algum registro deve ser feito atualização DESDE QUE o registro da base não esteja 100% concluído  

                        foreach (DataRow filtro in resultado) {
                            // passando por cada item da lista de resultado, geralmente é apenas 1 registro

                            if (int.Parse(filtro["percentual_concluido"].ToString()) < 100) {
                                //validando se a trilha já não fora concluída

                                sql = "Update w_trilhasTreinamentos set ";
                                sql += "total_cursos = " + objCon.valorSql(int.Parse(item["total_cursos"].ToString())) + ", ";
                                sql += "vol_nao_concluido = " + objCon.valorSql(int.Parse(item["vol_nao_concluido"].ToString())) + ", ";
                                sql += "vol_concluido = " + objCon.valorSql(int.Parse(item["vol_concluido"].ToString())) + ", ";
                                sql += "percentual_concluido = " + objCon.valorSql(int.Parse(item["percentual_concluido"].ToString())) + ", ";

                                valorData = DateTime.Parse("1900-01-01");
                                if (item["data_conclusao_ultimo_curso_trilha"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_conclusao_ultimo_curso_trilha"].ToString()); };
                                sql += "data_ult_conteudo_cursado = " + objCon.valorSql(valorData) + ", ";

                                sql += "gestor_1 = " + objCon.valorSql(item["gestor_1"].ToString()) + ", ";
                                sql += "gestor_2 = " + objCon.valorSql(item["gestor_2"].ToString()) + ", ";
                                sql += "gestor_3 = " + objCon.valorSql(item["gestor_3"].ToString()) + ", ";
                                sql += "gestor_4 = " + objCon.valorSql(item["gestor_4"].ToString()) + ", ";
                                sql += "gestor_5 = " + objCon.valorSql(item["gestor_5"].ToString()) + ", ";

                                valorData = DateTime.Parse("1900-01-01");
                                if (item["data_demissao"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_demissao"].ToString()); };
                                sql += "data_demissao = " + objCon.valorSql(valorData) + ", ";

                                valorData = DateTime.Parse("1900-01-01");
                                if (item["data_ferias_inicio"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_ferias_inicio"].ToString()); };
                                sql += "data_ferias_inicio = " + objCon.valorSql(valorData) + ", ";

                                valorData = DateTime.Parse("1900-01-01");
                                if (item["data_ferias_fim"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_ferias_fim"].ToString()); };
                                sql += "data_ferias_fim = " + objCon.valorSql(valorData) + ", ";

                                valorData = DateTime.Parse("1900-01-01");
                                if (item["data_afastamento_inicio"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_afastamento_inicio"].ToString()); };
                                sql += "data_afastamento_inicio = " + objCon.valorSql(valorData) + ", ";

                                valorData = DateTime.Parse("1900-01-01");
                                if (item["data_afastamento_fim"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_afastamento_fim"].ToString()); };
                                sql += "data_afastamento_fim = " + objCon.valorSql(valorData) + ", ";

                                sql += "data_importacao = " + objCon.valorSql(DateTime.Parse(item["data_importacao"].ToString())) + ", ";
                                sql += "id_importacao = " + objCon.valorSql(int.Parse(item["id_importacao"].ToString())) + " ";
                                sql += "where id = " + objCon.valorSql(filtro["id"]) + " ";
                                objCon.executaQuery(sql, ref retorno);
                                volAtualizado += 1;
                            }

                        }


                    } else {
                        sql = "insert into w_trilhasTreinamentos (" +
                                      "vigencia_ano, " +
                                      "vigencia_inicio_data, " +
                                      "vigencia_fim_data, " +
                                      "des_trilha, " +
                                      "des_nome, " +
                                      "cpf, " +
                                      "total_cursos, " +
                                      "vol_nao_concluido, " +
                                      "vol_concluido, " +
                                      "percentual_concluido, " +
                                      "data_ult_conteudo_cursado, " +
                                      "gestor_1, " +
                                      "gestor_2, " +
                                      "gestor_3, " +
                                      "gestor_4, " +
                                      "gestor_5, " +
                                      "data_admissao, " +
                                      "data_demissao, " +
                                      "data_ferias_inicio, " +
                                      "data_ferias_fim, " +
                                      "data_afastamento_inicio, " +
                                      "data_afastamento_fim, " +
                                      "data_importacao, " +
                                      "id_importacao " +
                                      ") values (";
                        sql += objCon.valorSql(vigencia_ano) + ", ";
                        sql += objCon.valorSql(vigencia_inicio) + ", ";
                        sql += objCon.valorSql(vigencia_fim) + ", ";
                        sql += objCon.valorSql(item["des_trilha"].ToString()) + ", ";
                        sql += objCon.valorSql(item["des_nome"].ToString()) + ", ";
                        sql += objCon.valorSql(item["cpf"].ToString()) + ", ";
                        sql += objCon.valorSql(int.Parse(item["total_cursos"].ToString())) + ", ";
                        sql += objCon.valorSql(int.Parse(item["vol_nao_concluido"].ToString())) + ", ";
                        sql += objCon.valorSql(int.Parse(item["vol_concluido"].ToString())) + ", ";
                        sql += objCon.valorSql(int.Parse(item["percentual_concluido"].ToString())) + ", ";

                        valorData = DateTime.Parse("1900-01-01");
                        if (item["data_conclusao_ultimo_curso_trilha"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_conclusao_ultimo_curso_trilha"].ToString()); };
                        sql += objCon.valorSql(valorData) + ", ";

                        sql += objCon.valorSql(item["gestor_1"].ToString()) + ", ";
                        sql += objCon.valorSql(item["gestor_2"].ToString()) + ", ";
                        sql += objCon.valorSql(item["gestor_3"].ToString()) + ", ";
                        sql += objCon.valorSql(item["gestor_4"].ToString()) + ", ";
                        sql += objCon.valorSql(item["gestor_5"].ToString()) + ", ";

                        valorData = DateTime.Parse("1900-01-01");
                        if (item["data_admissao"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_admissao"].ToString()); };
                        sql += objCon.valorSql(valorData) + ", ";

                        valorData = DateTime.Parse("1900-01-01");
                        if (item["data_demissao"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_demissao"].ToString()); };
                        sql += objCon.valorSql(valorData) + ", ";

                        valorData = DateTime.Parse("1900-01-01");
                        if (item["data_ferias_inicio"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_ferias_inicio"].ToString()); };
                        sql += objCon.valorSql(valorData) + ", ";

                        valorData = DateTime.Parse("1900-01-01");
                        if (item["data_ferias_fim"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_ferias_fim"].ToString()); };
                        sql += objCon.valorSql(valorData) + ", ";

                        valorData = DateTime.Parse("1900-01-01");
                        if (item["data_afastamento_inicio"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_afastamento_inicio"].ToString()); };
                        sql += objCon.valorSql(valorData) + ", ";

                        valorData = DateTime.Parse("1900-01-01");
                        if (item["data_afastamento_fim"].ToString().Equals("")) { valorData = DateTime.Parse("1900-01-01"); } else { valorData = DateTime.Parse(item["data_afastamento_fim"].ToString()); };
                        sql += objCon.valorSql(valorData) + ", ";

                        sql += objCon.valorSql(DateTime.Parse(item["data_importacao"].ToString())) + ", ";
                        sql += objCon.valorSql(int.Parse(item["id_importacao"].ToString())) + " ";
                        sql += ")";
                        objCon.executaQuery(sql, ref retorno);
                        volAtualizado += 1;
                    }

                    frm2.atualizarBarra(totalRegistros);
                }

                frm2.Close();
                return volAtualizado;

            }

            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - ABERTURA PRODUÇÃO (DAL)");
                return 0;
            }
        }

        private DataTable _capturarRegistroPorID(int id) {
            try {
                sql = "Select * from w_trilhasTreinamentos where id = " + objCon.valorSql(id) + " ";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - CAPTURAR REGISTRO POR ID (DAL)");
                return null;
            }
        }

        private DataTable _listarRegistrosPorLider(string _lider, string _hierarquia) {

            try {
                sql = "select * from w_trilhasTreinamentos ";
                sql += "where 1 = 1 ";
                sql += "and data_demissao = '1900-01-01' ";
                sql += "and locado_analise = 0 ";

                //selecionando qual coluna deve ser filtrada
                switch (_hierarquia) {
                    case "GESTOR 2":
                        sql += "and gestor_2 ";
                        break;
                    case "GESTOR 3":
                        sql += "and gestor_3 ";
                        break;
                    case "GESTOR 4":
                        sql += "and gestor_4 ";
                        break;
                    case "GESTOR 5":
                        sql += "and gestor_5 ";
                        break;
                }

                //Tratando situação de falta de informações de gestores
                if (_lider == "SEM INFO") {
                    sql += " is null ";
                } else {
                    sql += " = " + objCon.valorSql(_lider) + " ";
                }

                sql += objCon.valorSql(_lider) + " ";
                sql += "order by des_nome";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - CAPTURAR REGISTROS POR COORDENADOR (DAL)");
                return null;
            }
        }

        private bool _liberarRegistros() {
            try {

                sql = "Update w_trilhasTreinamentos set " +
                                    "cat_status = 0, cat_id_analista = 0 " +
                                    "from w_trilhasTreinamentos where 1 = 1 " +
                                    "and cat_status = 1 " +
                                    "and cat_id_analista = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta);
                return objCon.executaQuery(sql, ref retorno);

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - LIBERAR REGISTROS (DAL)");
                return false;
            }
        }

        private DataTable _bloquearRegistros(DataTable dt) {
            try {

                //status:
                // 0 - disponível
                // 1 - trabalhando - locado
                // 2 - finalizado

                if (dt.Rows.Count > 0) {

                    foreach (DataRow item in dt.Rows) {

                        sql = "Update w_trilhasTreinamentos set " +
                                "cat_status = 1, " +
                                "cat_id_analista = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + " " +
                                "from w_trilhasTreinamentos where id = " + objCon.valorSql(int.Parse(item["id"].ToString())) + " " +
                                "and cat_status = 0";
                        objCon.executaQuery(sql, ref retorno);
                    }

                    //capturando os registros que foram bloqueados e ainda não foram trabalhados
                    //anexando histórico de envio de e-mails
                    sql = "select  ";
                    sql += "(select count(id) from w_trilhasTreinamentos_categorizacoes b where b.cpf = a.cpf) as qtde_emails_enviados, ";
                    sql += "(select top 1 b.des_trilha from w_trilhasTreinamentos_categorizacoes b where b.cpf = a.cpf order by b.data_envio_email desc) as ult_trilha_cobrada, ";
                    sql += "(select top 1 b.emails_enderecos from w_trilhasTreinamentos_categorizacoes b where b.cpf = a.cpf order by b.data_envio_email desc) as End_Ult_Email_Enviado, ";
                    sql += "(select top 1 b.data_envio_email from w_trilhasTreinamentos_categorizacoes b where b.cpf = a.cpf order by b.data_envio_email desc) as Data_Ult_Email_Enviado, ";
                    sql += "a.* ";
                    sql += "from w_trilhasTreinamentos a ";
                    sql += "where a.cat_status = 1 and a.cat_id_analista = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + " ";
                    return objCon.retornaDataTable(sql);
                }

                return null;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - REGISTRO EXCLUSIVO (DAL)");
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

        private bool _finalizarRegistro(trilhasSGI t) {
            try {
                sql = "Update w_trilhasTreinamentos set " +
                            "email_enviado = " + objCon.valorSql(t.email_enviado) + ", " +
                            "data_envio_email = " + objCon.valorSql(t.data_envio_email) + ", " +
                            "id_analista_seguranca = " + objCon.valorSql(t.id_analista_seguranca) + ", " +
                            "emails_enderecos = " + objCon.valorSql(t.emails_enderecos) + " " +
                            "from w_trilhasTreinamentos where id = " + objCon.valorSql(t.id) + " ";
                return objCon.executaQuery(sql, ref retorno);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - FINALIZAR REGISTROS (DAL)");
                return false;
            }
        }


        #endregion

        #region BLL

        /// <summary>
        /// Abertura de produção, ou seja, compara os registros armazenados no Sentinella e se existe novos para serem importados, com as seguintes premíssas:
        /// - Não ter sido importado anteriormente.
        /// - Ou já ter sido enviado e-mail ao gestor responsável.
        /// </summary>
        /// <returns></returns>
        public long abrirProducao() {
            try {

                DialogResult dialogResult = MessageBox.Show("Realmente deseja carregar novos registros e também registros que já foram enviados e-mails de cobrança e ainda não foram finalizados?", Constantes.Titulo_MSG, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes) {
                    Cursor cursor = Cursors.WaitCursor;

                    long totalImportado = 0;
                    totalImportado = _abrirProducao();
                    cursor = Cursors.Default;

                    return totalImportado;

                } else {
                    MessageBox.Show("Abertura de produção cancelada!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return 0;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - ABERTURA PRODUÇÃO (BLL)");
                return 0;
            }
        }

        public void preencherComboBoxLideres(Form frm, ComboBox cbx, string filtro) {
            try {
                hlp.carregaComboBox(_listarPendenciasPorLider(filtro), frm, cbx, false);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - PREENCHER COMBOBOX COORDENADORES (BLL)");
            }
        }

        public void preencherListViewAssociados(ListView lst, string _lider, string _hierarquia) {
            try {

                //garantindo que todo volume locado e não trabalhado esteja livre
                _liberarRegistros();

                DataTable dtCap, dt = new DataTable();
                dtCap = _listarRegistrosPorLider(_lider, _hierarquia);
                //bloqueando os registros antes de alimentar o listview
                dt = _bloquearRegistros(dtCap);

                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = true;
                lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("ID", 80, HorizontalAlignment.Center);
                lst.Columns.Add("TRILHA", 250, HorizontalAlignment.Left);
                lst.Columns.Add("ASSOCIADO", 250, HorizontalAlignment.Left);
                lst.Columns.Add("ANO DE VIGÊNCIA", 100, HorizontalAlignment.Left);
                lst.Columns.Add("INÍCIO DA VIGÊNCIA", 100, HorizontalAlignment.Left);
                lst.Columns.Add("FIM DA VIGÊNCIA", 100, HorizontalAlignment.Left);
                lst.Columns.Add("CPF", 80, HorizontalAlignment.Left);
                lst.Columns.Add("PERÍODO DE COBRANÇA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("AGING DE COBRANÇA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("% CONCLUÍDO", 100, HorizontalAlignment.Left);
                lst.Columns.Add("# E-MAILS JÁ ENVIADOS", 120, HorizontalAlignment.Left);
                lst.Columns.Add("ÚLT. TRILHA COBRADA", 250, HorizontalAlignment.Left);
                lst.Columns.Add("ÚLT. END. DE E-MAIL ENVIADO", 120, HorizontalAlignment.Left);
                lst.Columns.Add("DATA ÚLT E-MAIL", 120, HorizontalAlignment.Left);
                lst.Columns.Add("DATA ADMISSÃO", 100, HorizontalAlignment.Left);
                lst.Columns.Add("DATA FÉRIAS INICIO", 100, HorizontalAlignment.Left);
                lst.Columns.Add("DATA FÉRIAS FIM", 100, HorizontalAlignment.Left);
                lst.Columns.Add("DATA AFASTAMENTO INICIO", 100, HorizontalAlignment.Left);
                lst.Columns.Add("DATA AFASTAMENTO FIM", 100, HorizontalAlignment.Left);
                lst.Columns.Add("SUPERVISÃO", 250, HorizontalAlignment.Left);
                lst.Columns.Add("COORDENADOR", 250, HorizontalAlignment.Left);
                lst.Columns.Add("GERENTE", 250, HorizontalAlignment.Left);
                lst.Columns.Add("DIRETORIA", 250, HorizontalAlignment.Left);
                lst.Columns.Add("DIRETORIA", 250, HorizontalAlignment.Left);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["id"].ToString();
                        item.SubItems.Add(linha["des_trilha"].ToString().ToUpper());
                        item.SubItems.Add(linha["des_nome"].ToString());
                        item.SubItems.Add(linha["vigencia_ano"].ToString().ToUpper());
                        item.SubItems.Add(linha["vigencia_inicio_data"].ToString().ToUpper());
                        item.SubItems.Add(linha["vigencia_fim_data"].ToString().ToUpper());
                        item.SubItems.Add(linha["cpf"].ToString());

                        TimeSpan calculoAging = DateTime.Today - DateTime.Parse(linha["vigencia_fim_data"].ToString());

                        if (calculoAging.Days > 60) {
                            item.SubItems.Add(linha["FORA DO PERÍODO"].ToString());
                            item.SubItems.Add(calculoAging.Days.ToString());
                        } else {
                            if (calculoAging.Days < 0) {
                                item.SubItems.Add(linha["VENCIDO"].ToString());
                                item.SubItems.Add(calculoAging.Days.ToString());
                            } else {
                                item.SubItems.Add(linha["À VENCER"].ToString());
                                item.SubItems.Add(calculoAging.Days.ToString());
                            }
                        }
                        item.SubItems.Add(linha["percentual_concluido"].ToString() + "%");
                        item.SubItems.Add(linha["qtde_emails_enviados"].ToString());
                        item.SubItems.Add(linha["ult_trilha_cobrada"].ToString());
                        item.SubItems.Add(linha["End_Ult_Email_Enviado"].ToString());
                        item.SubItems.Add(linha["Data_Ult_Email_Enviado"].ToString());
                        item.SubItems.Add(linha["data_admissao"].ToString());
                        item.SubItems.Add(linha["data_ferias_inicio"].ToString());
                        item.SubItems.Add(linha["data_ferias_fim"].ToString());
                        item.SubItems.Add(linha["data_afastamento_inicio"].ToString());
                        item.SubItems.Add(linha["data_afastamento_fim"].ToString());
                        item.SubItems.Add(linha["gestor_1"].ToString());
                        item.SubItems.Add(linha["gestor_2"].ToString());
                        item.SubItems.Add(linha["gestor_3"].ToString());
                        item.SubItems.Add(linha["gestor_4"].ToString());
                        item.SubItems.Add(linha["gestor_5"].ToString());


                        //ANÁLISE DE STATUS DE CONCLUSÃO
                        if (calculoAging.Days <= 60 && int.Parse(linha["percentual_concluido"].ToString()) < 100) {
                            item.ImageKey = "3";
                        } else if (calculoAging.Days <= 60 && int.Parse(linha["percentual_concluido"].ToString()).Equals(100)) {
                            item.ImageKey = "1";
                        } else {
                            item.ImageKey = "4";
                        }


                        //EXCEÇÕES PARA O STATUS DE COBRANÇA QUE NÃO DEVERÃO SER ENVIADOS E-MAILS

                        //FÉRIAS
                        if (!linha["data_ferias_inicio"].ToString().Equals("") && !linha["data_ferias_fim"].ToString().Equals("")) {
                            if (DateTime.Parse(linha["data_ferias_inicio"].ToString()) < DateTime.Today && DateTime.Parse(linha["data_ferias_fim"].ToString()) > DateTime.Today) {
                                item.ImageKey = "2";
                            }
                        }

                        //AFASTAMENTO
                        if (!linha["data_afastamento_inicio"].ToString().Equals("") && !linha["data_afastamento_fim"].ToString().Equals("")) {
                            if (DateTime.Parse(linha["data_afastamento_inicio"].ToString()) < DateTime.Today && DateTime.Parse(linha["data_afastamento_fim"].ToString()) > DateTime.Today) {
                                item.ImageKey = "5";
                            }
                        }

                        //DEMITIDOS
                        if (!linha["data_demissao"].ToString().Equals("") && !linha["data_demissao"].ToString().Equals("1900-01-01")) {
                            item.ImageKey = "14";
                        }


                        lst.Items.Add(item);
                    }
                }
                dt.Clear();
                dtCap.Clear();
            }

            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - PREENCHER LISTVIEW ASSOCIADOS (BLL)");
            }
        }

        public bool liberarRegistros(bool enviarMsg = true) {
            try {

                bool validacao = _liberarRegistros();
                if (enviarMsg) {
                    if (validacao) {
                        MessageBox.Show("Registros liberados!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    } else {
                        MessageBox.Show("Não foi possível liberar os registros!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                return validacao;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - LIBERAR REGISTROS (BLL)");
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

        public bool finalizarRegistro(int id, string emails_enderecos) {
            try {
                trilhasSGI t = new trilhasSGI(id, true, emails_enderecos);
                return _finalizarRegistro(t);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - FINALIZAR REGISTROS (BLL)");
                return false;
            }

        }

        #endregion

    }
}

