using System;
using System.Data;
using System.Windows.Forms;

namespace Sentinella {
    class planoDeAcao {

        //	CREATE TABLE [dbo].[w_basePlanoAcao] (
        //	    [id]              INT            IDENTITY (1, 1) NOT NULL,
        //	    [protocolo]       INT            DEFAULT ((0)) NOT NULL,
        //	    [solicitante]     NVARCHAR (750) NULL,
        //	    [coordenador]     NVARCHAR (750) NULL,
        //	    [gerente]         NVARCHAR (750) NULL,
        //	    [diretor]         NVARCHAR (750) NULL,
        //	    [observacao]         NVARCHAR (MAX) NULL,
        //	    [dataRegistro]    DATETIME       DEFAULT ('1900-01-01 00:00:00') NOT NULL,
        //	    [dataAtualizacao] DATETIME       DEFAULT (getdate()) NULL,
        //	    [idAtualizacao]   NVARCHAR (10)  NULL,
        //	    CONSTRAINT [PK_w_basePlanoAcao] PRIMARY KEY CLUSTERED ([id] ASC)
        //	);



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
        public string _solicitante { get; set; }
        public string _coordenador { get; set; }
        public string _gerente { get; set; }
        public string _diretor { get; set; }
        public string _observacao { get; set; }
        public DateTime _dataRegistro { get; set; }
        public DateTime _dataAtualizacao { get; set; }
        public string _idAtualizacao { get; set; }
        #endregion

        #region Contrutores
        public planoDeAcao() { }

        public planoDeAcao(int protocolo, string solicitante, string coordenador, string gerente, string diretor, DateTime dataRegistro, int id = 0, string observacao = "") {

            _id = id;
            _protocolo = protocolo;
            _solicitante = solicitante;
            _coordenador = coordenador;
            _gerente = gerente;
            _diretor = diretor;
            _observacao = observacao;
            _dataRegistro = dataRegistro;
            _dataAtualizacao = hlp.dataHoraAtual();
            _idAtualizacao = Constantes.id_REDE_logadoFerramenta;
        }

        private DataTable _listarPlanosAcoes(DateTime _dtInicial, DateTime _dtFinal) {
            try {
                sql = "EXECUTE [10.200.48.167].[db_TechOnline].[dbo].sp_clsRelatorioRegistroPlanoAcao_Detalhe  " +
                        objCon.valorSql(_dtInicial) + ',' + objCon.valorSql(_dtFinal) + " ";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "MANUTENCOES - LISTA DE PLANOS DE AÇÕES (DAL)");
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
                log.registrarLog(ex.ToString(), "MANUTENCOES - LISTA DE PLANOS DE AÇÕES TRABALHADAS (DAL)");
                return null;
            }
        }

        #endregion

        #region Camada DAL - Dados
        private planoDeAcao _capturarRegistroID(int id) {
            try {
                DataTable dt = new DataTable();
                planoDeAcao registro = new planoDeAcao();
                sql = "Select * from w_basePlanoAcao where id = " + objCon.valorSql(id) + " ";
                dt = objCon.retornaDataTable(sql);
                if (dt.Rows.Count > 0) {
                    foreach (DataRow ln in dt.Rows) {

                        registro._id = int.Parse(ln["id"].ToString());
                        registro._protocolo = int.Parse(ln["protocolo"].ToString());
                        registro._solicitante = ln["solicitante"].ToString();
                        registro._coordenador = ln["coordenador"].ToString();
                        registro._gerente = ln["gerente"].ToString();
                        registro._diretor = ln["diretor"].ToString();
                        registro._observacao = ln["observacao"].ToString();
                        registro._dataRegistro = DateTime.Parse(ln["dataRegistro"].ToString());
                        registro._dataAtualizacao = DateTime.Parse(ln["dataAtualizacao"].ToString());
                        registro._idAtualizacao = ln["idAtualizacao"].ToString();
                    }
                }
                return registro;
            }
            catch (Exception ex) {

                log.registrarLog(ex.ToString(), "PLANO DE AÇÃO - CAPTURAR REGISTRO POR ID (DAL)");
                return null;
            }
        }

        private bool _incluir(planoDeAcao obj) {
            try {
                bool validacao = false;
                sql = "Insert into w_basePlanoAcao ";
                sql += "(protocolo,";
                sql += "solicitante,";
                sql += "coordenador,";
                sql += "gerente,";
                sql += "diretor,";
                sql += "observacao, ";
                sql += "dataRegistro, ";
                sql += "dataAtualizacao, ";
                sql += "idAtualizacao) ";
                sql += "values( ";
                sql += objCon.valorSql(obj._protocolo) + ",";
                sql += objCon.valorSql(obj._solicitante) + ",";
                sql += objCon.valorSql(obj._coordenador) + ",";
                sql += objCon.valorSql(obj._gerente) + ",";
                sql += objCon.valorSql(obj._diretor) + ",";
                sql += objCon.valorSql(obj._observacao) + ", ";
                sql += objCon.valorSql(obj._dataRegistro) + ", ";
                sql += objCon.valorSql(obj._dataAtualizacao) + ",";
                sql += objCon.valorSql(obj._idAtualizacao) + ") ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando

                return validacao; //retorno

            }
            catch (Exception ex) {

                log.registrarLog(ex.ToString(), "PLANO DE AÇÃO - INCLUIR(DAL)");
                return false;
            }

        }

        private bool _alterar(planoDeAcao obj) {
            try {
                bool validacao = false;
                sql = "Update w_basePlanoAcao set ";
                sql += "protocolo = " + objCon.valorSql(obj._protocolo) + ", ";
                sql += "solicitante = " + objCon.valorSql(obj._solicitante) + ", ";
                sql += "coordenador = " + objCon.valorSql(obj._coordenador) + ", ";
                sql += "gerente = " + objCon.valorSql(obj._gerente) + ", ";
                sql += "diretor = " + objCon.valorSql(obj._diretor) + ", ";
                sql += "observacao = " + objCon.valorSql(obj._observacao) + ", ";
                sql += "dataRegistro = " + objCon.valorSql(obj._dataRegistro) + ", ";
                sql += "dataAtualizacao = " + objCon.valorSql(obj._dataAtualizacao) + ", ";
                sql += "idAtualizacao = " + objCon.valorSql(obj._idAtualizacao) + " ";
                sql += "where id = " + objCon.valorSql(obj._id);
                validacao = objCon.executaQuery(sql, ref retorno); //executando

                return validacao; //retorno

            }
            catch (Exception ex) {

                log.registrarLog(ex.ToString(), "PLANO DE AÇÃO - ALTERAR(DAL)");
                return false;
            }

        }

        #endregion

        #region Camada BLL - Negócios
        public ListView CarregaListView(ListView lst, DateTime _dtInicial, DateTime _dtFinal) {
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
                            ult_end_email_enviado = w_Plan[0][6].ToString();
                            data_ultimo_envio_email = DateTime.Parse(w_Plan[0][7].ToString());
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

                        } else {fila_trabalho = "PLANO DENTRO DO PRAZO";
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


                        //item.ImageKey = "3";


                        lst.Items.Add(item);

                    }
                }
                return lst;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "PLANO DE AÇÃO - LISTVIEW (BLL)");
                return null;
            }
        }

        public bool salvarRegistro(planoDeAcao obj) {
            try {
                bool validacao = false;
                if (obj._id > 0) {
                    validacao = _alterar(obj);
                } else {
                    validacao = _incluir(obj);
                }
                if (validacao) {
                    MessageBox.Show("Registro salvo com sucesso!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                } else {
                    MessageBox.Show("Não foi possível salvar o registro!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao salvar: " + ex.ToString(), Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion
    }
}
