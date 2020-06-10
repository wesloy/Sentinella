using System;
using System.Data;
using System.Windows.Forms;

namespace Sentinella {
    class planoDeAcao {

        //CREATE TABLE [dbo].[w_planosAcao_categorizacoes] (
        //    [id]                    INT            IDENTITY (1, 1) NOT NULL,
        //    [protocolo]             INT            DEFAULT ((0)) NOT NULL,
        //    [fila]                  NVARCHAR (MAX) DEFAULT ('SEM INFO') NULL,
        //	  [data_inicio_plano]     DATETIME       DEFAULT ('1900-01-01 00:00:00') NOT NULL,
        //    [data_fim_plano]        DATETIME       DEFAULT('1900-01-01 00:00:00') NOT NULL,
        //    [solicitante]           NVARCHAR (MAX) DEFAULT ('SEM INFO') NULL,
        //    [responsavel]           NVARCHAR (MAX) DEFAULT ('SEM INFO') NULL,
        //    [email_enviado]         BIT            DEFAULT ((0)) NOT NULL,
        //    [emails_enderecos]      NVARCHAR (MAX) DEFAULT ('SEM INFO') NULL,
        //    [data_envio_email]      DATETIME       DEFAULT ('1900-01-01 00:00:00') NOT NULL,
        //    [id_analista_seguranca] INT            DEFAULT ((0)) NOT NULL
        //);



        #region Variaveis 

        long retorno = 0;
        string sql = "";
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        #endregion

        #region Camada DTO - Entidades
        public int _id { get; set; }
        public int _protocolo { get; set; }
        public string _fila { get; set; }
        public DateTime _data_inicio_plano { get; set; }
        public DateTime _data_fim_plano { get; set; }
        public string _solicitante { get; set; }
        public string _responsavel { get; set; }
        public bool _email_enviado { get; set; }
        public string _emails_enderecos { get; set; }
        public DateTime _data_envio_email { get; set; }
        public int _id_analista_seguranca { get; set; }
        #endregion

        #region Contrutores
        public planoDeAcao() { }

        public planoDeAcao(int protocolo, string fila, DateTime data_inicio_plano, DateTime data_fim_plano, string solicitante, string responsavel, bool email_enviado, string emails_enderecos, DateTime data_envio_email, int id = 0) {

            _id = id;
            _protocolo = protocolo;
            _fila = fila;
            _data_inicio_plano = data_inicio_plano;
            _data_fim_plano = data_fim_plano;
            _solicitante = solicitante;
            _responsavel = responsavel;
            _email_enviado = email_enviado;
            _emails_enderecos = emails_enderecos;
            _data_envio_email = data_envio_email;
            _id_analista_seguranca = Constantes.id_BD_logadoFerramenta;
        }



        private DataTable _listarPlanosAcoes(DateTime _dtInicial, DateTime _dtFinal) {
            try {
                sql = "EXECUTE [10.200.48.167].[db_TechOnline].[dbo].sp_clsRelatorioRegistroPlanoAcao_Detalhe  " +
                        objCon.valorSql(_dtInicial) + ',' + objCon.valorSql(_dtFinal) + " ";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "PLANOS DE AÇÃO - LISTA DE PLANOS DE AÇÕES (DAL)");
                return null;
            }
        }
        private DataTable _listarPlanosAcoesTrabalhados() {
            try {
                sql = "select " +
                            "(select count(id) from w_planosAcao_categorizacoes where protocolo = p1.protocolo) qte_emails_enviados, " +
                            "p1.*, u.nome nome_analista_seguranca from w_planosAcao_categorizacoes p1 " +
                            "inner join w_sysUsuarios u on p1.id_analista_seguranca = u.id " +
                            "left join w_planosAcao_categorizacoes p2 on p1.protocolo = p2.protocolo and p1.id < p2.id " +
                            "where p2.id is null";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "PLANOS DE AÇÃO - LISTA DE PLANOS DE AÇÕES TRABALHADAS (DAL)");
                return null;
            }
        }

        #endregion

        #region Camada DAL - Dados

        private bool _finalizarRegistro(planoDeAcao obj) {
            try {
                bool validacao = false;
                sql = "Insert into w_PlanosAcao_categorizacoes ";
                sql += "(protocolo,";
                sql += "fila,";
                sql += "data_inicio_plano,";
                sql += "data_fim_plano,";
                sql += "solicitante,";
                sql += "responsavel,";
                sql += "email_enviado,";
                sql += "emails_enderecos,";
                sql += "data_envio_email, ";
                sql += "id_analista_seguranca) ";
                sql += "values( ";
                sql += objCon.valorSql(obj._protocolo) + ",";
                sql += objCon.valorSql(obj._fila) + ",";
                sql += objCon.valorSql(obj._data_inicio_plano) + ",";
                sql += objCon.valorSql(obj._data_fim_plano) + ",";
                sql += objCon.valorSql(obj._solicitante) + ",";
                sql += objCon.valorSql(obj._responsavel) + ",";
                sql += objCon.valorSql(obj._email_enviado) + ",";
                sql += objCon.valorSql(obj._emails_enderecos) + ",";
                sql += objCon.valorSql(obj._data_envio_email) + ", ";
                sql += objCon.valorSql(obj._id_analista_seguranca) + ") ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando

                return validacao; //retorno

            }
            catch (Exception ex) {

                log.registrarLog(ex.ToString(), "PLANO DE AÇÃO - SALVAR REGISTRO (DAL)");
                return false;
            }

        }

        #endregion

        #region Camada BLL - Negócios
        public ListView CarregaListView(ListView lst, DateTime _dtInicial, DateTime _dtFinal, string _filtroPorStatus = "") {
            try {


                dadosCadastraisTH th = new dadosCadastraisTH();

                string gestor_1 = "";
                string gestor_2 = "";
                string gestor_3 = "";
                string gestor_4 = "";

                int qtde_emails = 0;
                DateTime data_ultimo_envio_email = DateTime.Parse("1900-01-01");
                string ult_end_email_enviado = "";


                DataTable dt = new DataTable();
                dt = _listarPlanosAcoes(_dtInicial, _dtFinal);

                DataTable dt_w = new DataTable();
                dt_w = _listarPlanosAcoesTrabalhados();

                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = false;
                lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("FILA", 100, HorizontalAlignment.Left);
                lst.Columns.Add("PROTOCOLO", 100, HorizontalAlignment.Left);
                lst.Columns.Add("QTDE E-MAILS ENVIADOS", 140, HorizontalAlignment.Left);
                lst.Columns.Add("ÚLT END. E-MAIL ENVIADO", 140, HorizontalAlignment.Left);
                lst.Columns.Add("DATA ÚLT ENVIO DE E-MAIL", 140, HorizontalAlignment.Left);
                lst.Columns.Add("STATUS DA SOLICITAÇÃO", 140, HorizontalAlignment.Left);
                lst.Columns.Add("SOLICITANTE", 140, HorizontalAlignment.Left);
                lst.Columns.Add("RESPONSÁVEL", 150, HorizontalAlignment.Left);
                lst.Columns.Add("GESTOR 1", 140, HorizontalAlignment.Left);
                lst.Columns.Add("GESTOR 2", 140, HorizontalAlignment.Left);
                lst.Columns.Add("GESTOR 3", 140, HorizontalAlignment.Left);
                lst.Columns.Add("GESTOR 4", 140, HorizontalAlignment.Left);
                lst.Columns.Add("ETAPA NO FLUXO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("TIPO DOCUMENTO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("TÍTULO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("ORIGEM", 150, HorizontalAlignment.Left);
                lst.Columns.Add("CR", 150, HorizontalAlignment.Left);
                lst.Columns.Add("NORMA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("REQUISITO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DATA ABERTURA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("INICIO PLANO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("FIM PLANO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DATA DE MEDIÇÃO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DATA CONCLUSAO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("RNC", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DIAS EM ATRASO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("CATEGORIA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("FALHA_PROCESSO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("FALHA_ASSOCIADO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("INCIDENTE", 150, HorizontalAlignment.Left);
                lst.Columns.Add("CLASSIFICAÇÃO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("PRIORIDADE", 150, HorizontalAlignment.Left);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {

                        ListViewItem item = new ListViewItem();

                        #region ENRIQUECIMENTO_DADOS
                        DataRow[] w_Plan = dt_w.Select("protocolo = " + int.Parse(linha["PROTOCOLO"].ToString()));

                        if (w_Plan.Length > 0) {
                            qtde_emails = int.Parse(w_Plan[0][0].ToString());
                            ult_end_email_enviado = w_Plan[0][9].ToString();
                            data_ultimo_envio_email = DateTime.Parse(w_Plan[0][10].ToString());
                        } else {
                            qtde_emails = 0;
                            ult_end_email_enviado = "N/D";
                            data_ultimo_envio_email = DateTime.Parse("1900-01-01");
                        }

                        if (linha["RESPONSÁVEL"].ToString() != "") {
                            dadosCadastraisTH infoTh = new dadosCadastraisTH();
                            infoTh = th.infoMaisRecentePorNomeEspecifico(linha["RESPONSÁVEL"].ToString());

                            gestor_1 = infoTh.gestor_1;
                            gestor_2 = infoTh.gestor_2;
                            gestor_3 = infoTh.gestor_3;
                            gestor_4 = infoTh.gestor_4;


                        } else {
                            gestor_1 = "";
                            gestor_2 = "";
                            gestor_3 = "";
                            gestor_4 = "";
                        }

                        string fila_trabalho = "";
                        if (linha["STATUS DA SOLICITAÇÃO"].ToString().ToUpper() == "FINALIZADO") {

                            fila_trabalho = "PLANO FINALIZADO";
                            item.ImageKey = "1";

                        } else {
                            fila_trabalho = "PLANO DENTRO DO PRAZO";
                            if (int.Parse(linha["DIAS EM ATRASO"].ToString()) < 0) {
                                fila_trabalho = "PLANO DENTRO DO PRAZO";
                                item.ImageKey = "4";

                            } else if (int.Parse(linha["DIAS EM ATRASO"].ToString()) >= 0 && int.Parse(linha["DIAS EM ATRASO"].ToString()) <= 7) {
                                fila_trabalho = "PLANO VENCIDO - D<7";
                                item.ImageKey = "2";

                            } else if (int.Parse(linha["DIAS EM ATRASO"].ToString()) > 7 && int.Parse(linha["DIAS EM ATRASO"].ToString()) <= 14) {
                                fila_trabalho = "PLANO VENCIDO - D7+";
                                item.ImageKey = "3";

                            } else if (int.Parse(linha["DIAS EM ATRASO"].ToString()) > 14 && int.Parse(linha["DIAS EM ATRASO"].ToString()) <= 21) {
                                fila_trabalho = "PLANO VENCIDO - D14+";
                                item.ImageKey = "3";

                            } else if (int.Parse(linha["DIAS EM ATRASO"].ToString()) > 21 && int.Parse(linha["DIAS EM ATRASO"].ToString()) <= 28) {
                                fila_trabalho = "PLANO VENCIDO - D21+";
                                item.ImageKey = "3";

                            } else if (int.Parse(linha["DIAS EM ATRASO"].ToString()) > 28) {
                                fila_trabalho = "PLANO VENCIDO - D28+";
                                item.ImageKey = "5";

                            } else {
                                fila_trabalho = "NÃO CLASSIFICADO";
                                item.ImageKey = "14";
                            }
                        }



                        #endregion


                        item.Text = fila_trabalho.ToString();
                        item.SubItems.Add(linha["PROTOCOLO"].ToString());
                        item.SubItems.Add(qtde_emails.ToString());
                        item.SubItems.Add(ult_end_email_enviado);
                        item.SubItems.Add(data_ultimo_envio_email.ToString());
                        item.SubItems.Add(linha["STATUS DA SOLICITAÇÃO"].ToString());
                        item.SubItems.Add(linha["SOLICITANTE"].ToString());
                        item.SubItems.Add(linha["RESPONSÁVEL"].ToString());
                        item.SubItems.Add(gestor_1);
                        item.SubItems.Add(gestor_2);
                        item.SubItems.Add(gestor_3);
                        item.SubItems.Add(gestor_4);
                        item.SubItems.Add(linha["ETAPA NO FLUXO"].ToString());
                        item.SubItems.Add(linha["TIPO DOCUMENTO"].ToString());
                        item.SubItems.Add(linha["TÍTULO"].ToString());
                        item.SubItems.Add(linha["ORIGEM"].ToString());
                        item.SubItems.Add(linha["CR"].ToString());
                        item.SubItems.Add(linha["NORMA"].ToString());
                        item.SubItems.Add(linha["REQUISITO"].ToString());
                        item.SubItems.Add(linha["DATA ABERTURA"].ToString());
                        item.SubItems.Add(linha["INICIO PLANO"].ToString());
                        item.SubItems.Add(linha["FIM PLANO"].ToString());
                        item.SubItems.Add(linha["DATA DE MEDIÇÃO"].ToString());
                        item.SubItems.Add(linha["DATA CONCLUSAO"].ToString());
                        item.SubItems.Add(linha["RNC"].ToString());
                        item.SubItems.Add(linha["DIAS EM ATRASO"].ToString());
                        item.SubItems.Add(linha["CATEGORIA"].ToString());
                        item.SubItems.Add(linha["FALHA_PROCESSO"].ToString());
                        item.SubItems.Add(linha["FALHA_ASSOCIADO"].ToString());
                        item.SubItems.Add(linha["INCIDENTE"].ToString());
                        item.SubItems.Add(linha["CLASSIFICAÇÃO"].ToString());
                        item.SubItems.Add(linha["PRIORIDADE"].ToString());


                        if (_filtroPorStatus != "") {

                            switch (_filtroPorStatus.ToUpper()) {
                                case "FINALIZADOS":
                                    if (item.ImageKey == "1") {
                                        lst.Items.Add(item);
                                    }
                                    break;

                                case "DENTRO DO PRAZO":
                                    if (item.ImageKey == "4") {
                                        lst.Items.Add(item);
                                    }
                                    break;

                                case "D<7":
                                    if (item.ImageKey == "2") {
                                        lst.Items.Add(item);
                                    }
                                    break;

                                case "D>7":
                                    if (item.ImageKey == "3") {
                                        lst.Items.Add(item);
                                    }
                                    break;

                                case "D>28":
                                    if (item.ImageKey == "5") {
                                        lst.Items.Add(item);
                                    }
                                    break;

                                case "NÃO CLASSIFICADO":
                                    if (item.ImageKey == "14") {
                                        lst.Items.Add(item);
                                    }
                                    break;

                                case "TODOS":
                                    lst.Items.Add(item);
                                    break;

                                default:
                                    //ERRO SUBIR TODOS COM ALERTA VISUAL
                                    item.ImageKey = "13";
                                    lst.Items.Add(item);
                                    break;
                            }
                        } else {

                            lst.Items.Add(item);
                        }

                    }

                }

                return lst;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "PLANO DE AÇÃO - LISTVIEW (BLL)");
                return null;
            }
        }

        public bool finalizarRegistro(planoDeAcao _obj) {
            try {
                return _finalizarRegistro(_obj);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "PLANO DE AÇÃO - SALVAR REGISTROS (BLL)");
                return false;
            }

        }

        #endregion
    }
}
