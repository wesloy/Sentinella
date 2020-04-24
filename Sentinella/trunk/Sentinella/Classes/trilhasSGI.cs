using System;
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

        private DataTable _listarCoordenadoresPendencias() {
            try {
                sql = "select 1, iif(gestor_2 is null,'SEM INFO',gestor_2) as g2 from w_trilhasTreinamentos " +
                            "where email_enviado = 0 " +
                            "group by gestor_2 " +
                            "order by gestor_2 ";
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

                //carregar form Barra de Progresso de preparação dos dados
                frmProgressBar frm = new frmProgressBar(1);
                frm.atualizarBarra(0);
                frm.Show();


                //Selecionando informações do banco de dados com filtro de usuários que ainda não finalizaram a trilha SGI
                sql = "Select c.des_turma, c.des_nome, " +
                            "replace(replace(c.cod_cpf, '.', ''), '-', '') as cpf, " +
                            "count(c.des_conteudo) as total_cursos, " +
                            "sum(iif(c.num_conclusao = '0', 1, 0)) as vol_nao_concluido, " +
                            "sum(iif(c.num_conclusao = '100', 1, 0)) as vol_concluido, " +
                            "sum(iif(c.num_conclusao = '100', 1, 0)) * 100 / count(c.des_conteudo) as percentual_concluido, " +
                            "(select top 1 gestor_1 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_1, " +
                            "(select top 1 gestor_2 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_2, " +
                            "(select top 1 gestor_3 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_3, " +
                            "(select top 1 gestor_4 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_4, " +
                            "(select top 1 gestor_5 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_5, " +
                            "(select top 1 data_de_admissao from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_admissao, " +
                            "(select top 1 data_demissao from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as data_demissao, " +
                            "GETDATE() as data_importacao, " +
                            Constantes.id_BD_logadoFerramenta + " as id_importacao " +
                            "from db_TreinamentoSinergyRH.dbo.TB_TRILHAS c left join w_trilhasTreinamentos t on c.des_nome = t.des_nome and c.des_turma = t.des_turma and t.cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') " +
                            "where c.des_turma like '%TRILHA SGI%' and c.des_status = 'Ativo' and(t.id is null or t.email_enviado = 1) " +
                            "group by c.des_turma, c.des_nome, c.cod_cpf " +
                            "having sum(iif(c.num_conclusao = '100', 1, 0)) * 100 / count(c.des_conteudo) < 100 ";
                DataTable dt_Trilhas = new DataTable();
                dt_Trilhas = objCon.retornaDataTable(sql);
                frm.atualizarBarra(1);
                frm.Close();

                //Validando se tem vol para trabalhar
                if (dt_Trilhas.Rows.Count == 0) {
                    return 0;
                }


                //carregar form Barra de Progresso de preparação dos dados
                frmProgressBar frm2 = new frmProgressBar(dt_Trilhas.Rows.Count);
                frm2.atualizarBarra(0);
                frm2.Show();

                //Passando por cada linha das trilhas para importar ou não
                int totalRegistros = 0;
                foreach (DataRow item in dt_Trilhas.Rows) {

                    string filaImp = "NÃO IMPORTAR";

                    //sem data de admissião
                    if (item["data_admissao"] is null) {
                        totalRegistros += 1;
                        frm2.atualizarBarra(totalRegistros);
                        continue;
                    }

                    //demitido
                    if (!item["data_demissao"].ToString().Contains("1900-01-01")) {
                        totalRegistros += 1;
                        frm2.atualizarBarra(totalRegistros);
                        continue;
                    }

                    //calculando o hoje para o anivesário do associado no ano atual
                    TimeSpan intervalo = Convert.ToDateTime((DateTime.Today.Year + "- " + DateTime.Parse(item["data_admissao"].ToString()).Month + "- " + DateTime.Parse(item["data_admissao"].ToString()).Day))- DateTime.Today;

                    if (intervalo.Days > 90) {
                        filaImp = "NÃO IMPORTAR";
                        frm2.atualizarBarra(totalRegistros);
                        continue;
                    } else if (intervalo.Days < 0) {
                        filaImp = "PRAZO VENCIDO";
                    } else {
                        filaImp = "DENTRO PRAZO";
                    }

                    if (filaImp != "NÃO IMPORTAR") {

                        sql = "insert into w_trilhasTreinamentos (" +
                                      "fila, " +
                                      "periodoCobranca, " +
                                      "des_turma, " +
                                      "des_nome, " +
                                      "cpf, " +
                                      "total_cursos, " +
                                      "vol_nao_concluido, " +
                                      "vol_concluido, " +
                                      "percentual_concluido, " +
                                      "gestor_1, " +
                                      "gestor_2, " +
                                      "gestor_3, " +
                                      "gestor_4, " +
                                      "gestor_5, " +
                                      "data_admissao, " +
                                      "data_demissao, " +
                                      "data_importacao, " +
                                      "id_importacao " +
                                      ") values (";
                        sql += objCon.valorSql(filaImp) + ", ";
                        sql += objCon.valorSql(intervalo.Days) + ", ";
                        sql += objCon.valorSql(item["des_turma"].ToString()) + ", ";
                        sql += objCon.valorSql(item["des_nome"].ToString()) + ", ";
                        sql += objCon.valorSql(item["cpf"].ToString()) + ", ";
                        sql += objCon.valorSql(int.Parse(item["total_cursos"].ToString())) + ", ";
                        sql += objCon.valorSql(int.Parse(item["vol_nao_concluido"].ToString())) + ", ";
                        sql += objCon.valorSql(int.Parse(item["vol_concluido"].ToString())) + ", ";
                        sql += objCon.valorSql(int.Parse(item["percentual_concluido"].ToString())) + ", ";
                        sql += objCon.valorSql(item["gestor_1"].ToString()) + ", ";
                        sql += objCon.valorSql(item["gestor_2"].ToString()) + ", ";
                        sql += objCon.valorSql(item["gestor_3"].ToString()) + ", ";
                        sql += objCon.valorSql(item["gestor_4"].ToString()) + ", ";
                        sql += objCon.valorSql(item["gestor_5"].ToString()) + ", ";
                        sql += objCon.valorSql(DateTime.Parse(item["data_admissao"].ToString())) + ", ";
                        sql += objCon.valorSql(DateTime.Parse(item["data_demissao"].ToString())) + ", ";
                        sql += objCon.valorSql(DateTime.Parse(item["data_importacao"].ToString())) + ", ";
                        sql += objCon.valorSql(int.Parse(item["id_importacao"].ToString())) + " ";
                        sql += ")";

                        objCon.executaQuery(sql, ref retorno);
                        volAtualizado += 1;
                    }


                    totalRegistros += 1;
                    frm2.atualizarBarra(totalRegistros);                    

                }
                               
                //Atualização de campos para facilitar a visualização das auditoras
                sql = "update w_trilhasTreinamentos set " +
                        "data_demissao = iif(data_demissao = '1900-01-01 00:00:00.000', null, data_demissao), " +
                        "data_admissao = iif(data_admissao = '1900-01-01 00:00:00.000', null, data_admissao) ";
                objCon.executaQuery(sql, ref retorno);

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

        private DataTable _listarRegistrosPorCoordenador(string _coordenador) {
            try {
                sql = "Select a.*, " +
                            "(select count(id) qtde_cobrancas from w_trilhasTreinamentos H where H.des_nome = A.des_nome And h.data_importacao < a.data_importacao) as qtde_emails_enviados, " +
                            "(select top 1 H.emails_enderecos from w_trilhasTreinamentos H where H.des_nome = A.des_nome And h.data_importacao < a.data_importacao order by id desc) as End_Ult_Email_Enviado, " +
                            "(select top 1 H.data_envio_email from w_trilhasTreinamentos H where H.des_nome = A.des_nome And h.data_importacao < a.data_importacao order by id desc) as Data_Ult_Email_Enviado " +
                            "from w_trilhasTreinamentos A where A.gestor_2 ";
                if (_coordenador == "SEM INFO") {
                    sql += " is null ";
                } else {
                    sql += " = " + objCon.valorSql(_coordenador) + " ";
                }
                sql += "and A.id_analista_seguranca = 0 ";
                sql += "and A.data_demissao is null";
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
                                    "id_analista_seguranca = 0, " +
                                    "data_envio_email = '1900-01-01 00:00:00' " +
                                    "from w_trilhasTreinamentos where 1 = 1 " +
                                    "and id_importacao = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) +
                                    "and email_enviado = 0";

                return objCon.executaQuery(sql, ref retorno);

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - LIBERAR REGISTROS (DAL)");
                return false;
            }
        }

        private DataTable _bloquearRegistros(DataTable dt) {
            try {
                if (dt.Rows.Count > 0) {

                    foreach (DataRow item in dt.Rows) {

                        sql = "Update w_trilhasTreinamentos set " +
                                "id_analista_seguranca = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + " " +
                                "from w_trilhasTreinamentos where id = " + objCon.valorSql(int.Parse(item["id"].ToString())) + " " +
                                "and id_analista_seguranca = 0";
                        objCon.executaQuery(sql, ref retorno);
                    }

                    //capturando os registros que foram bloqueados e ainda não foram trabalhados
                    sql = "Select A.*, " +
                            "(select count(id) qtde_cobrancas from w_trilhasTreinamentos H where H.des_nome = A.des_nome And h.data_importacao < a.data_importacao) as qtde_emails_enviados, " +
                            "(select top 1 H.emails_enderecos from w_trilhasTreinamentos H where H.des_nome = A.des_nome And h.data_importacao < a.data_importacao order by id desc) as End_Ult_Email_Enviado, " +
                            "(select top 1 H.data_envio_email from w_trilhasTreinamentos H where H.des_nome = A.des_nome And h.data_importacao < a.data_importacao order by id desc) as Data_Ult_Email_Enviado " +
                            "from w_trilhasTreinamentos A where 1 = 1 " +
                            "and A.id_analista_seguranca = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + " " +
                            "and A.data_envio_email = '1900-01-01 00:00:00' " +
                            "and A.email_enviado = 0 " +
                            "order by gestor_1, des_nome";
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

        public void preencherComboBoxCoordenadores(Form frm, ComboBox cbx) {
            try {
                hlp.carregaComboBox(_listarCoordenadoresPendencias(), frm, cbx, false);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - PREENCHER COMBOBOX COORDENADORES (BLL)");
            }
        }

        public void preencherListViewAssociados(ListView lst, string _coordenador) {
            try {

                //garantindo que todo volume locado e não trabalhado esteja livre
                _liberarRegistros();

                DataTable dtCap, dt = new DataTable();
                dtCap = _listarRegistrosPorCoordenador(_coordenador);
                //bloqueando os registros antes de alimentar o listview
                dt = _bloquearRegistros(dtCap);

                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = true;
                //lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("ID", 50, HorizontalAlignment.Center);
                lst.Columns.Add("TRILHA", 250, HorizontalAlignment.Center);
                lst.Columns.Add("ASSOCIADO", 250, HorizontalAlignment.Left);
                lst.Columns.Add("CPF", 100, HorizontalAlignment.Left);
                lst.Columns.Add("PERÍODO DE COBRANÇA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("% CONCLUÍDO", 100, HorizontalAlignment.Left);
                lst.Columns.Add("# E-MAILS JÁ ENVIADOS", 120, HorizontalAlignment.Left);
                lst.Columns.Add("ÚLT. END. DE E-MAIL ENVIADO", 120, HorizontalAlignment.Left);
                lst.Columns.Add("DATA ÚLT E-MAIL", 120, HorizontalAlignment.Left);
                lst.Columns.Add("DATA ADMISSÃO", 100, HorizontalAlignment.Left);                
                lst.Columns.Add("SUPERVISÃO", 250, HorizontalAlignment.Left);
                lst.Columns.Add("COORDENADOR", 250, HorizontalAlignment.Left);
                lst.Columns.Add("GERENTE", 250, HorizontalAlignment.Left);
                lst.Columns.Add("DIRETORIA", 250, HorizontalAlignment.Left);
                lst.Columns.Add("DIRETORIA", 250, HorizontalAlignment.Left);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["id"].ToString();
                        item.SubItems.Add(linha["des_turma"].ToString());
                        item.SubItems.Add(linha["des_nome"].ToString());
                        item.SubItems.Add(linha["cpf"].ToString());
                        item.SubItems.Add(linha["periodoCobranca"].ToString());
                        item.SubItems.Add(linha["percentual_concluido"].ToString());
                        item.SubItems.Add(linha["qtde_emails_enviados"].ToString());
                        item.SubItems.Add(linha["End_Ult_Email_Enviado"].ToString());
                        item.SubItems.Add(linha["Data_Ult_Email_Enviado"].ToString());
                        item.SubItems.Add(linha["data_admissao"].ToString());
                        item.SubItems.Add(linha["gestor_1"].ToString());
                        item.SubItems.Add(linha["gestor_2"].ToString());
                        item.SubItems.Add(linha["gestor_3"].ToString());
                        item.SubItems.Add(linha["gestor_4"].ToString());
                        item.SubItems.Add(linha["gestor_5"].ToString());
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

