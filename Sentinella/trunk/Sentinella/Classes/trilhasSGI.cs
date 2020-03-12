using System;
using System.Data;
using System.Windows.Forms;

namespace Sentinella {

    //	CREATE TABLE [dbo].[w_trilhasTreinamentos] (
    //	    [id]                    INT            IDENTITY (1, 1) NOT NULL,
    //	    [des_turma]             NVARCHAR (MAX) NULL DEFAULT 'SEM INFO',
    //	    [des_nome]              NVARCHAR (MAX) NULL DEFAULT 'SEM INFO',
    //	    [cpf]                   NVARCHAR (15)  NULL DEFAULT 'SEM INFO',
    //	    [total_cursos]          INT            NULL DEFAULT 0,
    //	    [vol_nao_concluido]     INT            NULL DEFAULT 0,
    //	    [vol_concluido]         INT            NULL DEFAULT 0,
    //	    [percentual_concluido]  INT            NULL DEFAULT 0,
    //	    [gestor_1]              NVARCHAR (MAX) NULL DEFAULT 'SEM INFO',
    //	    [gestor_2]              NVARCHAR (MAX) NULL DEFAULT 'SEM INFO',
    //	    [gestor_3]              NVARCHAR (MAX) NULL DEFAULT 'SEM INFO',
    //	    [gestor_4]              NVARCHAR (MAX) NULL DEFAULT 'SEM INFO',
    //	    [gestor_5]              NVARCHAR (MAX) NULL DEFAULT 'SEM INFO',
    //	    [data_importacao]       DATETIME       NULL DEFAULT '1900-01-01 00:00:00',
    //	    [id_importacao]         INT            NULL DEFAULT 0,
    //	    [email_enviado]         BIT            DEFAULT ((0)) NULL,
    //	    [data_envio_email]      DATETIME       NULL DEFAULT '1900-01-01 00:00:00',
    //	    [id_analista_seguranca] INT            NULL DEFAULT 0
    //	);



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
        public DateTime data_importacao { get; set; }
        public int id_importacao { get; set; }
        public bool email_enviado { get; set; }
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
        public trilhasSGI(int _id, bool _email_enviado) {
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
                    email_enviado = _email_enviado;
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
                sql = "insert into w_trilhasTreinamentos (" +
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
                            "data_importacao, " +
                            "id_importacao " +
                            ") select c.des_turma, c.des_nome, replace(replace(c.cod_cpf, '.', ''), '-', '') as cpf, " +
                            "count(c.des_conteudo) as total_cursos, " +
                            "sum(iif(c.num_conclusao = '0', 1, 0)) as vol_nao_concluido, " +
                            "sum(iif(c.num_conclusao = '100', 1, 0)) as vol_concluido, " +
                            "sum(iif(c.num_conclusao = '100', 1, 0)) * 100 / count(c.des_conteudo) as percentual_concluido, " +
                            "(select top 1 gestor_1 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_1, " +
                            "(select top 1 gestor_2 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_2, " +
                            "(select top 1 gestor_3 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_3, " +
                            "(select top 1 gestor_4 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_4, " +
                            "(select top 1 gestor_5 from w_funcionarios_historico where cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') order by dataAtualizacao desc) as gestor_5, " +
                            "GETDATE(), " +
                            Constantes.id_BD_logadoFerramenta + " " +
                            "from db_TreinamentoSinergyRH.dbo.TB_TRILHAS c left join w_trilhasTreinamentos t on c.des_nome = t.des_nome and c.des_turma = t.des_turma and t.cpf = replace(replace(c.cod_cpf, '.', ''), '-', '') " +
                            "where c.des_turma like '%TRILHA SGI%' " +
                            "and c.des_status = 'Ativo' " +
                            "and(t.id is null or t.email_enviado = 1) " +
                            "group by c.des_turma, c.des_nome, c.cod_cpf " +
                            "having sum(iif(c.num_conclusao = '100', 1, 0)) * 100 / count(c.des_conteudo) < 100 " +
                            "order by c.des_nome ";
                objCon.executaQuery(sql, ref retorno);
                return retorno;
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
                sql = "Select * from w_trilhasTreinamentos where gestor_2";
                if (_coordenador == "SEM INFO") {
                    sql += " is null ";
                } else {
                    sql += " = " + objCon.valorSql(_coordenador) + " ";
                }
                sql += "and id_analista_seguranca = 0";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - CAPTURAR REGISTROS POR COORDENADOR (DAL)");
                return null;
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
                DataTable dt = new DataTable();
                dt = _listarRegistrosPorCoordenador(_coordenador);
                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = true;
                //lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("TRILHA", 250, HorizontalAlignment.Center);
                lst.Columns.Add("ASSOCIADO", 250, HorizontalAlignment.Left);
                lst.Columns.Add("CPF", 150, HorizontalAlignment.Left);
                lst.Columns.Add("% CONCLUÍDO", 100, HorizontalAlignment.Left);
                lst.Columns.Add("SUPERVISÃO", 300, HorizontalAlignment.Left);
                lst.Columns.Add("COORDENADOR", 300, HorizontalAlignment.Left);
                lst.Columns.Add("GERENTE", 300, HorizontalAlignment.Left);
                lst.Columns.Add("DIRETORIA", 300, HorizontalAlignment.Left);
                lst.Columns.Add("DIRETORIA", 300, HorizontalAlignment.Left);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["des_turma"].ToString();
                        item.SubItems.Add(linha["des_nome"].ToString());
                        item.SubItems.Add(linha["cpf"].ToString());
                        item.SubItems.Add(linha["percentual_concluido"].ToString());
                        item.SubItems.Add(linha["gestor_1"].ToString());
                        item.SubItems.Add(linha["gestor_2"].ToString());
                        item.SubItems.Add(linha["gestor_3"].ToString());
                        item.SubItems.Add(linha["gestor_4"].ToString());
                        item.SubItems.Add(linha["gestor_5"].ToString());                        
                        lst.Items.Add(item);
                    }
                }                
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "TRILHAS SGI - PREENCHER LISTVIEW ASSOCIADOS (BLL)");
            }
        }

        #endregion

    }
}
