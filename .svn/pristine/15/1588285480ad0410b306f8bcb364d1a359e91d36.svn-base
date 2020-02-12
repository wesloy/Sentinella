using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Sentinella {

    //	CREATE TABLE [dbo].[w_base] (
    //	    [id]                      INT            IDENTITY (1, 1) NOT NULL,
    //      [id_info]                 INT            DEFAULT ((0)) NOT NULL,
    //	    [bin]                     NVARCHAR (6)   NULL,
    //	    [cpf]                     NVARCHAR (15)  NULL,
    //	    [data_Registro]           DATETIME       DEFAULT ('1900-01-01 00:00:00') NOT NULL,
    //	    [fila_id]                 INT            DEFAULT ((0)) NOT NULL,
    //	    [status_id]               INT            DEFAULT ((0)) NOT NULL,
    //	    [idCat]                   NVARCHAR (20)  NULL,
    //	    [finalizacao_id]          INT            DEFAULT ((0)) NOT NULL,
    //	    [subFinalizacao_id]       INT            DEFAULT ((0)) NOT NULL,
    //	    [observacao]              NVARCHAR (500) DEFAULT ((0)) NOT NULL,
    //	    [data_Trabalho]           DATE           DEFAULT ('1900-01-01') NOT NULL,
    //	    [hora_Inicial]            DATETIME       DEFAULT ('1900-01-01 00:00:00') NOT NULL,
    //	    [hora_Final]              DATETIME       DEFAULT ('1900-01-01 00:00:00') NOT NULL,
    //	    [tempo_Trabalho_Segundos] FLOAT (53)     DEFAULT ((0)) NOT NULL,
    //	    [valor_Envolvido]         MONEY          DEFAULT ((0)) NOT NULL,
    //	    [sla_cumprido]            BIT            DEFAULT ((0)) NOT NULL,
    //	    [gerado_fup]              BIT            DEFAULT ((0)) NOT NULL,
    //	    [id_Historico]            INT            DEFAULT ((0)) NOT NULL,
    //	    [data_Abertura]           DATETIME       DEFAULT (getdate()) NULL,
    //	    [id_Abertura]             NVARCHAR (10)  NULL,
    //	    CONSTRAINT [PK_w_base] PRIMARY KEY CLUSTERED ([id] ASC)
    //	);

    //Tabela principal, recebe os registros para serem trabalhados
    //Para alimentação (importações) será usado apenas os campos: BIN, CPF, FILA_ID, DATA_ABERTURA, ID_ABERTURA

    class importacoes {

        #region Variaveis 
        bool validacao = false;
        string sql = "";
        long retorno = 0;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        int volTotal = 0;
        usuariosVolParaTrabalho volPorUser = new usuariosVolParaTrabalho();
        #endregion

        #region Camada DTO - ENTIDADES

        #region Atributo
        string _bin;
        string _cpf;
        int _fila_id;
        DateTime _data_registro;
        DateTime _data_abertura;
        string _id_abertura;
        int _id_historico; //Para fup
        int _id_info; //carregar id de tabelas que possuem informações detalhadas dos registros para trabalho
        #endregion

        #region Propriedades
        public string Bin {
            get {
                return _bin;
            }

            set {
                _bin = value;
            }
        }

        public string Cpf {
            get {
                return _cpf;
            }

            set {
                _cpf = value;
            }
        }

        public int Fila_id {
            get {
                return _fila_id;
            }

            set {
                _fila_id = value;
            }
        }

        public DateTime Data_abertura {
            get {
                return _data_abertura;
            }

            set {
                _data_abertura = value;
            }
        }

        public string Id_abertura {
            get {
                return _id_abertura;
            }

            set {
                _id_abertura = value;
            }
        }

        public DateTime Data_registro {
            get {
                return _data_registro;
            }

            set {
                _data_registro = value;
            }
        }

        public int Id_historico {
            get {
                return _id_historico;
            }

            set {
                _id_historico = value;
            }
        }
        public int Id_Info {
            get {
                return _id_info;
            }

            set {
                _id_info = value;
            }
        }
        #endregion

        #endregion

        #region Construtores
        /// <summary>
        /// Objeto de preenchimento para inserção na tabela BASE do Sentinella
        /// </summary>
        /// <param name="_Bin"></param>
        /// <param name="_Cpf"></param>
        /// <param name="_Fila_id"></param>
        public importacoes(string _Bin, string _Cpf, DateTime dth_registro, int _Fila_id, DateTime dth_abertura, int idHistorico = 0, int idInfo = 0) {
            Bin = _Bin;
            Cpf = _Cpf;
            Data_registro = dth_registro;
            Fila_id = _Fila_id;
            Data_abertura = dth_abertura;
            Id_abertura = Constantes.id_REDE_logadoFerramenta;
            Id_historico = idHistorico;
            Id_Info = idInfo;

        }
        public importacoes(int _Fila_id, DateTime dth_abertura, string id_abertura) {
            Fila_id = _Fila_id;
            Data_abertura = dth_abertura;
            Id_abertura = id_abertura;
        }
        public importacoes() {
            //Construtor vazio
        }
        #endregion

        #region Camada DAL - DADOS

        /// <summary>
        /// Método genérico para validar se o registro já foi importado
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="validarDataRegistro"></param>
        /// <returns></returns>
        private bool _valorDuplicado(importacoes obj, bool validarDataRegistro = false, bool validarStausAberto = false, bool idInfo = false) {
            try {
                sql = "Select * from w_base ";
                sql += "where bin = " + objCon.valorSql(obj.Bin) + " ";
                sql += "and cpf = " + objCon.valorSql(obj.Cpf) + " ";
                sql += "and Fila_id = " + objCon.valorSql(obj.Fila_id) + " ";
                if (validarStausAberto) {
                    sql += "and status_id = 0 ";
                }
                if (idInfo) {
                    sql += "and id_info = " + objCon.valorSql(obj.Id_Info) + " ";
                }
                sql += "order by data_Registro desc ";

                if (validarDataRegistro) {
                    //se o registro que já está no sentinella for >= não necessita subir o registro atual, pois trata-se de um registro antigo
                    DataTable tb = new DataTable();
                    bool validacao = false;
                    tb = objCon.retornaDataTable(sql);
                    if (tb.Rows.Count > 0) {
                        foreach (DataRow ln in tb.Rows) {
                            if (DateTime.Parse(ln["data_Registro"].ToString()) >= obj.Data_registro) {
                                validacao = true;
                                break;
                            }
                        }
                    } else { validacao = false; }
                    return validacao;
                } else {//Validação direta pelo sql, já que não é necessário validar data do registro. Assim sendo, havendo retoro > 0 já caracteriza duplicidade.
                    objCon.executaQuery(sql, ref retorno);
                    if (retorno < 0) { return true; } else { return false; }
                }



            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - VALIDAR DUPLICADO");
                return false;
            }
        }

        /// <summary>
        /// Métedo para inserção na base, independente da fila a ser populada
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool _insertBase(importacoes obj) {
            try {
                sql = "Insert into w_base (";
                sql += "bin, cpf, data_registro, fila_id, data_abertura, id_abertura, id_historico, id_info ";
                sql += ") values (";
                sql += objCon.valorSql(obj.Bin) + ", ";
                sql += objCon.valorSql(obj.Cpf) + ",";
                sql += objCon.valorSql(obj.Data_registro) + ", ";
                sql += objCon.valorSql(obj.Fila_id) + ", ";
                sql += objCon.valorSql(obj.Data_abertura) + ", ";
                sql += objCon.valorSql(obj.Id_abertura) + ", ";
                sql += objCon.valorSql(obj.Id_historico) + ", ";
                sql += objCon.valorSql(obj.Id_Info) + ") ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando
                return validacao;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO(fila_id " + Fila_id + ") - INSERIR NA BASE(DAL)");
                return false;
            }
        }

        /// <summary>
        /// Este método irá exluir apenas registros ainda não trabalhados, porém estes registros poderão voltar para a base em uma nova importação,
        /// visto que não serão identificados como duplicados, já que foram deletados
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="volExcluido"></param>
        /// <returns></returns>
        private bool _excluirBase(importacoes obj, ref long volExcluido) {
            try {

                sql = "Delete from w_base ";
                sql += "Where id_abertura = " + objCon.valorSql(obj.Id_abertura) + " ";
                sql += "and data_abertura = " + objCon.valorSql(obj.Data_abertura) + " ";
                sql += "and fila_id = " + objCon.valorSql(obj.Fila_id) + " ";
                sql += "and status_id in (0) "; //Status: 0 aguardando, 1 trabalhando, 2 finalziado
                return objCon.executaQuery(sql, ref volExcluido);


            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - DELETAR DA BASE(DAL)");
                return false;
            }
        }

        //_dlpConexao(diretorio, dtHora, fila_id, fila_nome, ref volImportado)
        private bool _dlpConexao(string diretorio, DateTime dtHora, ref long volAtualizado) {

            int volImportado = 0;
            DateTime data = new DateTime();
            data = DateTime.Parse("1900-01-01 00:00:00", System.Globalization.CultureInfo.InvariantCulture);
            //criar conexao ACCESS para utilizar funções SQL
            int fila_id;
            string fila_nome;
            string provider = "Provider=Microsoft.ACE.OLEDB.12.0;";
            string dataSource = "Data Source=" + diretorio + ";";
            string adicional = "Extended Properties='Excel 12.0 Xml; HDR=YES';";
            OleDbConnection cnx = new OleDbConnection(provider + dataSource + adicional);


            cnx.Open();
            System.Data.DataTable dt = cnx.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //carregar form Barra de Progresso
            frmProgressBar frm = new frmProgressBar(200000);
            frm.Show();


            try {

                string sheet = "";
                DateTime dataHoraAtual = hlp.dataHoraAtual();
                filas filas = new filas();
                DataTable dtFilas = new DataTable();
                dtFilas = filas.listaFilasDataTable("DLP");
                Boolean importar = false;

                foreach (DataRow row in dt.Rows) {

                    sheet = row["TABLE_NAME"].ToString();


                    OleDbCommand comando = new OleDbCommand("Select * from [" + sheet + "]", cnx);
                    OleDbDataReader dr = comando.ExecuteReader(); //carregando informações do excel

                    //Validando se a planilha está correta
                    if (!dr.GetName(1).ToString().Equals("Generated") || !dr.GetName(28).ToString().Equals("Cloud Service Vendor")) {
                        MessageBox.Show("Esta planilha não pode ser importada devido o layout ser diferente!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }


                    while (dr.Read()) {


                        //VALIDAÇÃO DE REGRA PARA IMPORTAÇÃO
                        importar = false;
                        fila_id = 0;
                        fila_nome = "";

                        foreach (DataRow item in dtFilas.Rows) {
                            if (dr["Rule"].ToString().ToUpper().Replace("_", "").Replace(" ", "").Equals(item["regraImportacao"].ToString().ToUpper().Replace("_", "").Replace(" ", "")) && item["ATIVO"].ToString().ToUpper() == "TRUE") {

                                importar = true;
                                fila_id = int.Parse(item["id"].ToString());
                                fila_nome = item["descricao"].ToString().ToUpper();
                                break;
                            }
                        }

                        if (!importar
                                || dr["File"].ToString().Contains(".tmp")
                                || dr["File"].ToString().Contains(".ini")
                                || dr["File"].ToString().Contains(".contact")
                                || dr["File"].ToString().Contains("Clipboard")
                                || dr["Incident Source (AD Account)"].ToString().Contains("SISTEMA")) {
                            volTotal += 1;
                            frm.atualizarBarra(volTotal);
                            continue;
                        }

                        string dataMontada;
                        DateTime dateValue;
                        dataMontada = dr["Generated"].ToString().Replace("'", "").Substring(6, 4) + "-"; //ano
                        dataMontada += dr["Generated"].ToString().Replace("'", "").Substring(0, 2) + "-"; //mês
                        dataMontada += dr["Generated"].ToString().Replace("'", "").Substring(3, 2) + " "; //dia
                        dataMontada += dr["Generated"].ToString().Replace("'", "").Substring(11); //hora completa

                        if (DateTime.TryParse(dataMontada, out dateValue)) {
                            data = dateValue;
                        } else {
                            volTotal += 1;
                            frm.atualizarBarra(volTotal);
                            continue;
                        }

                        dataMontada = dr["Received"].ToString().Replace("'", "").Substring(6, 4) + "-"; //ano
                        dataMontada += dr["Received"].ToString().Replace("'", "").Substring(0, 2) + "-"; //mês
                        dataMontada += dr["Received"].ToString().Replace("'", "").Substring(3, 2) + " "; //dia
                        dataMontada += dr["Received"].ToString().Replace("'", "").Substring(11); //hora completa
                        if (DateTime.TryParse(dataMontada, out dateValue)) {
                            data = dateValue;
                        } else {
                            volTotal += 1;
                            frm.atualizarBarra(volTotal);
                            continue;
                        }

                        #region Insert
                        string[] dataFull = dr["Generated"].ToString().Split(' ');

                        string chaveDuplicidade = hlp.removerCharEspecial(dataFull[0] +
                                    dr["Product Entity/Endpoint"].ToString() +
                                    dr["Endpoint"].ToString() +
                                    dr["Incident Source (AD Account)"].ToString() +
                                    dr["Rule"].ToString() +
                                    dr["Template"].ToString() +
                                    dr["Destination"].ToString()).Replace(" ", "").ToUpper();

                        sql = "Insert into w_dlp (";
                        sql += "generated_, ";
                        sql += "received, ";
                        sql += "severity, ";
                        sql += "status_, ";
                        sql += "manager, ";
                        sql += "department, ";
                        sql += "policy_, ";
                        sql += "product_entity_endpoint, ";
                        sql += "product, ";
                        sql += "product_endpoint_ip, ";
                        sql += "product_endpoint_mac, ";
                        sql += "managing_server, ";
                        sql += "endpoint_, ";
                        sql += "incident_source_ad_account, ";
                        sql += "incident_source_sender, ";
                        sql += "website, ";
                        sql += "recipient, ";
                        sql += "subject_, ";
                        sql += "file_location, ";
                        sql += "file_, ";
                        sql += "file_data_size, ";
                        sql += "rule_, ";
                        sql += "template, ";
                        sql += "channel, ";
                        sql += "destination, ";
                        sql += "action_, ";
                        sql += "incidents, ";
                        sql += "cloud_service_vendor, ";
                        sql += "id_fila_trabalho, ";
                        sql += "chave_duplicidade, ";
                        sql += "data_importacao, ";
                        sql += "id_importacao ";
                        sql += ") Select ";
                        data = DateTime.Parse("1900-01-01", System.Globalization.CultureInfo.InvariantCulture);
                        data = DateTime.Parse(dr["Generated"].ToString().Replace("'", ""), System.Globalization.CultureInfo.InvariantCulture);
                        sql += objCon.valorSql(data) + ", ";
                        data = DateTime.Parse("1900-01-01", System.Globalization.CultureInfo.InvariantCulture);
                        data = DateTime.Parse(dr["Received"].ToString().Replace("'", ""), System.Globalization.CultureInfo.InvariantCulture);
                        sql += objCon.valorSql(data) + ", ";
                        sql += objCon.valorSql(dr["Severity"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Status"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Manager"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Department"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Policy"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Product Entity/Endpoint"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Product"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Product/Endpoint IP"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Product/Endpoint MAC"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Managing Server"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Endpoint"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Incident Source (AD Account)"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Incident Source (Sender)"].ToString().Replace("'", "").Replace(".", "").Replace(",", "")) + ",  ";
                        sql += objCon.valorSql(dr["WebSite"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(hlp.removerCharEspecial(dr["Recipient"].ToString().Replace("'", "").Replace(".", "").Replace(",", ""))) + ",  ";
                        sql += objCon.valorSql(dr["Subject"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["File Location"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["File"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["File/Data Size"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Rule"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Template"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Channel"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Destination"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Action"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Incidents"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(dr["Cloud Service Vendor"].ToString().Replace("'", "")) + ",  ";
                        sql += objCon.valorSql(fila_id) + ", ";
                        sql += objCon.valorSql(chaveDuplicidade) + ",  ";
                        sql += objCon.valorSql(dataHoraAtual) + ", ";
                        sql += objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + " ";
                        sql += "Where Not Exists (Select 1 from w_dlp where chave_duplicidade = " + objCon.valorSql(chaveDuplicidade) + ") ";
                        objCon.executaQuery(sql, ref retorno);


                        volTotal += 1;
                        frm.atualizarBarra(volTotal);
                        #endregion

                    }

                }
                //fechando conexão com o excel
                cnx.Close();

                //Atualizando cpfs dos casos importados com tabela AD
                //Chave: Usuário de rede
                sql = "Update dlp set ";
                sql += "cpf = ad.Cod_cpf, ";
                sql += "nome_completo = ad.Nom_Usuario, ";
                sql += "matricula = h.matricula ";
                sql += "from db_Sentinella.dbo.w_dlp dlp inner join db_ControleAD.dbo.Tbl_UsuariosAD ad ";
                sql += "on dlp.incident_source_ad_account = ad.Nom_login collate Latin1_General_CI_AS ";
                sql += "left join ";
                sql += "(select top 1 w.matricula, w.cpf ";
                sql += "from db_ControleAD.dbo.Tbl_UsuariosAD ad inner join db_Sentinella.dbo.w_funcionarios_historico w ";
                sql += "on w.cpf = ad.Cod_CPF collate Latin1_General_CI_AS ";
                sql += "order by w.dataAtualizacao Desc) as h "; //selecionando apenas a ultima importação do CPF na base funcionários histórico
                sql += "on h.cpf = ad.Cod_CPF collate Latin1_General_CI_AS ";
                objCon.executaQuery(sql, ref retorno);

                //fechando barra de carregamento para iniciar uma nova posteriormente
                frm.Close();

                //limpando casos que não foram encontrados o CPF/MATRICULA com o AD
                sql = "delete from w_dlp where cpf = '' or cpf is null";
                objCon.executaQuery(sql, ref retorno);

                //capturando todos os casos importados e atualizados acima
                sql = "Select * from w_dlp where id_tbl_trabalho = 0 " +
                        " and id_importacao = " + objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + " " +
                            " and incident_source_ad_account <> 'SISTEMA' ";
                dt = objCon.retornaDataTable(sql);

                //Importar para tabela de trabalho
                if (dt.Rows.Count > 0) {

                    //carregar form Barra de Progresso
                    frmProgressBar frm2 = new frmProgressBar(dt.Rows.Count);
                    volTotal = 0;
                    frm2.Show();

                    foreach (DataRow ln in dt.Rows) {

                        if (!ln["incident_source_ad_account"].ToString().ToUpper().Contains("SISTEMA")) {
                            importacoes imp = new importacoes(
                                                                "000000",
                                                                ln["CPF"].ToString(),
                                                                DateTime.Parse(ln["generated_"].ToString()),
                                                                int.Parse(ln["id_fila_trabalho"].ToString()),
                                                                dtHora,
                                                                0,
                                                                int.Parse(ln["id"].ToString()));

                            if (!_valorDuplicado(imp, false, true, false)) { //validação de status não é preciso, pq depende da data de corte, ciclos diferentes sobe para trabalho
                                _insertBase(imp);
                                volImportado += 1;
                            }

                            //salvar volume para registro do total importado, sendo feito a manutenção na camada de negócio
                            volAtualizado = volImportado;
                        }

                        volTotal += 1;
                        frm2.atualizarBarra(volTotal);
                    }

                    //atualizar id da tbl w_base na tbl w_dlp, para futura captura dos detalhes dos registros para trabalho do analista
                    sql = "Update d set ";
                    sql += "d.id_tbl_trabalho = b.id ";
                    sql += "from w_base b inner join w_dlp d on b.cpf = d.cpf left join w_sysFilas f on b.fila_id = f.id ";
                    sql += "where d.id_tbl_trabalho = 0 and f.grupo = 'DLP' ";
                    sql += "and b.status_id = 0 and id_Abertura = " + objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + " ";
                    objCon.executaQuery(sql, ref retorno);

                    frm2.Close();
                }



                return true;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - DLP (DAL)");
                return false;
            }
            finally {
                frm.Close();
                cnx.Close();
            }
        }

        private bool _cadastroGeralConexao(string diretorio, ref long volAtualizado) {

            //criar conexao ACCESS para utilizar funções SQL
            string provider = "Provider=Microsoft.ACE.OLEDB.12.0;";
            string dataSource = "Data Source=" + diretorio + ";";
            string adicional = "Extended Properties='Excel 12.0 Xml; HDR=YES';";
            OleDbConnection cnx = new OleDbConnection(provider + dataSource + adicional);

            //carregar form Barra de Progresso
            frmProgressBar frm = new frmProgressBar(50000);
            frm.Show();

            try {

                cnx.Open();
                OleDbCommand comando = new OleDbCommand("Select * from [Planilha1$]", cnx);
                OleDbDataReader dr = comando.ExecuteReader(); //carregando informações do excel

                //Validando se a planilha está correta
                if (!dr.GetName(0).ToString().Equals("COD# EMPRESA") || !dr.GetName(159).ToString().Equals("EMAIL_RESP_GH")) {
                    MessageBox.Show("Esta planilha não pode ser importada devido o layout ser diferente!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                while (dr.Read()) {

                    string matricula = dr["MATRICULA"].ToString();

                    #region Insert
                    sql = "Insert into w_funcionarios ";
                    sql += "(NOME_EMPRESA, ";
                    sql += "MATRICULA, ";
                    sql += "UB, ";
                    sql += "NOME_ASSOCIADO, ";
                    sql += "DATA_DE_ADMISSAO, ";
                    sql += "DATA_DEMISSAO, ";
                    sql += "CODCENTRO_DE_CUSTO, ";
                    sql += "DESCRCENTRO_DE_CUSTO, ";
                    sql += "CARGO_DO_ASSOCIADO, ";
                    sql += "SEXO, ";
                    sql += "RUA, ";
                    sql += "NUMERO, ";
                    sql += "COMPLEMENTO, ";
                    sql += "BAIRRO, ";
                    sql += "CIDADE, ";
                    sql += "ESTADO, ";
                    sql += "CEP, ";
                    sql += "PAIS, ";
                    sql += "CPF, ";
                    sql += "DATA_DE_NASCIMENTO, ";
                    sql += "NUM_FILHOS, ";
                    sql += "NOME_DO_PAI, ";
                    sql += "NOME_DA_MAE, ";
                    sql += "NOME_DO_CONJUGE, ";
                    sql += "NOME_DEPENDENTE_01, ";
                    sql += "CPF_DEPENDENTE_01, ";
                    sql += "RELACAO_DEPENDENTE_01, ";
                    sql += "NOME_DEPENDENTE_02, ";
                    sql += "CPF_DEPENDENTE_02, ";
                    sql += "RELACAO_DEPENDENTE_02, ";
                    sql += "NOME_DEPENDENTE_03, ";
                    sql += "CPF_DEPENDENTE_03, ";
                    sql += "RELACAO_DEPENDENTE_03, ";
                    sql += "NOME_DEPENDENTE_04, ";
                    sql += "CPF_DEPENDENTE_04, ";
                    sql += "RELACAO_DEPENDENTE_04, ";
                    sql += "NOME_DEPENDENTE_05, ";
                    sql += "CPF_DEPENDENTE_05, ";
                    sql += "RELACAO_DEPENDENTE_05, ";
                    sql += "NOME_DEPENDENTE_06, ";
                    sql += "CPF_DEPENDENTE_06, ";
                    sql += "RELACAO_DEPENDENTE_06, ";
                    sql += "NOME_DEPENDENTE_07, ";
                    sql += "CPF_DEPENDENTE_07, ";
                    sql += "RELACAO_DEPENDENTE_07, ";
                    sql += "NOME_DEPENDENTE_08, ";
                    sql += "CPF_DEPENDENTE_08, ";
                    sql += "RELACAO_DEPENDENTE_08, ";
                    sql += "NOME_DEPENDENTE_09, ";
                    sql += "CPF_DEPENDENTE_09, ";
                    sql += "RELACAO_DEPENDENTE_09, ";
                    sql += "NOME_DEPENDENTE_10, ";
                    sql += "CPF_DEPENDENTE_10, ";
                    sql += "RELACAO_DEPENDENTE_10, ";
                    sql += "DDD, ";
                    sql += "TELEFONE, ";
                    sql += "CELULAR, ";
                    sql += "EMAIL, ";
                    sql += "RESPONSAVEL_GH, ";
                    sql += "dataAtualizacao, ";
                    sql += "idAtualizacao ";
                    sql += ") Values (";
                    sql += objCon.valorSql(dr["NOME EMPRESA"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["MATRICULA"].ToString()) + ",  ";
                    sql += objCon.valorSql("UB" + matricula.PadLeft(6, '0').ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME ASSOCIADO"].ToString()) + ",  ";
                    if (dr["DATA DE ADMISSÃO"].ToString().Equals("") || dr["DATA DE ADMISSÃO"].ToString().Length < 8) {
                        sql += objCon.valorSql(DateTime.Parse("1900-01-01")) + ",  ";
                    } else {
                        sql += objCon.valorSql(DateTime.Parse(dr["DATA DE ADMISSÃO"].ToString().Insert(4, "-").Insert(7, "-"))) + ",  ";
                    }
                    if (dr["DATA DEMISSAO"].ToString().Equals("") || dr["DATA DEMISSAO"].ToString().Length < 8) {
                        sql += objCon.valorSql(DateTime.Parse("1900-01-01")) + ",  ";
                    } else {
                        sql += objCon.valorSql(DateTime.Parse(dr["DATA DEMISSAO"].ToString().Insert(4, "-").Insert(7, "-"))) + ",  ";
                    }
                    sql += objCon.valorSql(dr["COD#CENTRO DE CUSTO"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["DESCR#CENTRO DE CUSTO"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CARGO DO ASSOCIADO"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["SEXO"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["RUA"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["Nº"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["COMPLEMENTO"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["BAIRRO"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CIDADE"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["ESTADO"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CEP"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["PAÍS"].ToString().Trim()) + ",  ";
                    sql += objCon.valorSql(dr["CPF"].ToString()) + ",  ";
                    if (dr["DATA DE NASCIMENTO"].ToString().Equals("") || dr["DATA DE NASCIMENTO"].ToString().Length < 8) {
                        sql += objCon.valorSql(DateTime.Parse("1900-01-01")) + ",  ";
                    } else {
                        sql += objCon.valorSql(DateTime.Parse(dr["DATA DE NASCIMENTO"].ToString().Insert(4, "-").Insert(7, "-"))) + ",  ";
                    }
                    sql += objCon.valorSql(int.Parse(dr["NÚM# FILHOS"].ToString())) + ",  ";
                    sql += objCon.valorSql(dr["NOME DO PAI"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME DA MÃE"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME DO CÔNJUGE"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME DEPENDENTE 01"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CPF DEPENDENTE 01"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 01"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME DEPENDENTE 02"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CPF DEPENDENTE 02"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 02"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME DEPENDENTE 03"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CPF DEPENDENTE 03"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 03"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME DEPENDENTE 04"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CPF DEPENDENTE 04"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 04"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME DEPENDENTE 05"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CPF DEPENDENTE 05"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 05"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME DEPENDENTE 06"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CPF DEPENDENTE 06"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 06"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME DEPENDENTE 07"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CPF DEPENDENTE 07"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 07"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME DEPENDENTE 08"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CPF DEPENDENTE 09"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 08"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME DEPENDENTE 09"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CPF DEPENDENTE 09"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 09"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["NOME DEPENDENTE 10"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CPF DEPENDENTE 10"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 10"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["DDD"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["TELEFONE"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["CELULAR"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["EMAIL"].ToString()) + ",  ";
                    sql += objCon.valorSql(dr["RESPONSÁVEL_GH"].ToString()) + ",  ";
                    sql += objCon.valorSql(hlp.dataHoraAtual()) + ", ";
                    sql += objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + ") ";
                    objCon.executaQuery(sql, ref retorno);
                    #endregion

                    //DECOMISSIONADOS PARA IMPORTAR TODOS OS REGISTROS EM CADA IMPORTAÇÃO
                    #region "DESATIVADO"
                    ////Capturando matrícula
                    //string matricula = dr["MATRICULA"].ToString();
                    //DateTime dataDemissao;
                    //bool importar = true; //ALTERADO PARA TRUE
                    //DataTable dt = new DataTable();
                    //retorno = 0;

                    ////Filtrando matrícula que está a ser importada para definir se será uma atualização ou uma inclusão                          
                    //retorno = 0;
                    //sql = "Select * from w_funcionarios where matricula = '" + matricula + "'";
                    //dt = objCon.retornaDataTable(sql);

                    //if (dt.Rows.Count > 0) {
                    //    foreach (DataRow ln in dt.Rows) {
                    //        //Planilha
                    //        if (dr["DATA DEMISSAO"].ToString() == "") { dataDemissao = DateTime.Parse("1900-01-01"); } else { dataDemissao = DateTime.Parse(dr["DATA DEMISSAO"].ToString()); }
                    //        //Tabela SQL
                    //        if (DateTime.Parse(ln["DATA_DEMISSAO"].ToString()) == dataDemissao) {
                    //            importar = false;
                    //            break;
                    //        } else {
                    //            importar = true;
                    //        }
                    //    }
                    //    retorno = 1;
                    //} else {
                    //    retorno = 0;
                    //    importar = true;
                    //}

                    ////Insert
                    //if (retorno == 0 && importar) {
                    //    #region Insert
                    //    sql = "Insert into w_funcionarios ";
                    //    sql += "(NOME_EMPRESA, ";
                    //    sql += "MATRICULA, ";
                    //    sql += "UB, ";
                    //    sql += "NOME_ASSOCIADO, ";
                    //    sql += "DATA_DE_ADMISSAO, ";
                    //    sql += "DATA_DEMISSAO, ";
                    //    sql += "CODCENTRO_DE_CUSTO, ";
                    //    sql += "DESCRCENTRO_DE_CUSTO, ";
                    //    sql += "CARGO_DO_ASSOCIADO, ";
                    //    sql += "SEXO, ";
                    //    sql += "RUA, ";
                    //    sql += "NUMERO, ";
                    //    sql += "COMPLEMENTO, ";
                    //    sql += "BAIRRO, ";
                    //    sql += "CIDADE, ";
                    //    sql += "ESTADO, ";
                    //    sql += "CEP, ";
                    //    sql += "PAIS, ";
                    //    sql += "CPF, ";
                    //    sql += "DATA_DE_NASCIMENTO, ";
                    //    sql += "NUM_FILHOS, ";
                    //    sql += "NOME_DO_PAI, ";
                    //    sql += "NOME_DA_MAE, ";
                    //    sql += "NOME_DO_CONJUGE, ";
                    //    sql += "NOME_DEPENDENTE_01, ";
                    //    sql += "CPF_DEPENDENTE_01, ";
                    //    sql += "RELACAO_DEPENDENTE_01, ";
                    //    sql += "NOME_DEPENDENTE_02, ";
                    //    sql += "CPF_DEPENDENTE_02, ";
                    //    sql += "RELACAO_DEPENDENTE_02, ";
                    //    sql += "NOME_DEPENDENTE_03, ";
                    //    sql += "CPF_DEPENDENTE_03, ";
                    //    sql += "RELACAO_DEPENDENTE_03, ";
                    //    sql += "NOME_DEPENDENTE_04, ";
                    //    sql += "CPF_DEPENDENTE_04, ";
                    //    sql += "RELACAO_DEPENDENTE_04, ";
                    //    sql += "NOME_DEPENDENTE_05, ";
                    //    sql += "CPF_DEPENDENTE_05, ";
                    //    sql += "RELACAO_DEPENDENTE_05, ";
                    //    sql += "NOME_DEPENDENTE_06, ";
                    //    sql += "CPF_DEPENDENTE_06, ";
                    //    sql += "RELACAO_DEPENDENTE_06, ";
                    //    sql += "NOME_DEPENDENTE_07, ";
                    //    sql += "CPF_DEPENDENTE_07, ";
                    //    sql += "RELACAO_DEPENDENTE_07, ";
                    //    sql += "NOME_DEPENDENTE_08, ";
                    //    sql += "CPF_DEPENDENTE_08, ";
                    //    sql += "RELACAO_DEPENDENTE_08, ";
                    //    sql += "NOME_DEPENDENTE_09, ";
                    //    sql += "CPF_DEPENDENTE_09, ";
                    //    sql += "RELACAO_DEPENDENTE_09, ";
                    //    sql += "NOME_DEPENDENTE_10, ";
                    //    sql += "CPF_DEPENDENTE_10, ";
                    //    sql += "RELACAO_DEPENDENTE_10, ";
                    //    sql += "DDD, ";
                    //    sql += "TELEFONE, ";
                    //    sql += "CELULAR, ";
                    //    sql += "EMAIL, ";
                    //    sql += "RESPONSAVEL_GH, ";
                    //    sql += "dataAtualizacao, ";
                    //    sql += "idAtualizacao ";
                    //    sql += ") Values (";
                    //    sql += objCon.valorSql(dr["NOME EMPRESA"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["MATRICULA"].ToString()) + ",  ";
                    //    sql += objCon.valorSql("UB" + matricula.PadLeft(6, '0').ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME ASSOCIADO"].ToString()) + ",  ";
                    //    if (dr["DATA DE ADMISSÃO"].ToString().Equals("")) {
                    //        sql += objCon.valorSql(DateTime.Parse("1900-01-01")) + ",  ";
                    //    } else {
                    //        sql += objCon.valorSql(DateTime.Parse(dr["DATA DE ADMISSÃO"].ToString().Insert(4, "-").Insert(7, "-"))) + ",  ";
                    //    }
                    //    if (dr["DATA DEMISSAO"].ToString().Equals("")) {
                    //        sql += objCon.valorSql(DateTime.Parse("1900-01-01")) + ",  ";
                    //    } else {
                    //        sql += objCon.valorSql(DateTime.Parse(dr["DATA DEMISSAO"].ToString().Insert(4, "-").Insert(7, "-"))) + ",  ";
                    //    }
                    //    sql += objCon.valorSql(dr["COD#CENTRO DE CUSTO"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["DESCR#CENTRO DE CUSTO"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CARGO DO ASSOCIADO"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["SEXO"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["RUA"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["Nº"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["COMPLEMENTO"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["BAIRRO"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CIDADE"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["ESTADO"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CEP"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["PAÍS"].ToString().Trim()) + ",  ";
                    //    sql += objCon.valorSql(dr["CPF"].ToString()) + ",  ";
                    //    if (dr["DATA DE NASCIMENTO"].ToString().Equals("")) {
                    //        sql += objCon.valorSql(DateTime.Parse("1900-01-01")) + ",  ";
                    //    } else {
                    //        sql += objCon.valorSql(DateTime.Parse(dr["DATA DE NASCIMENTO"].ToString().Insert(4, "-").Insert(7, "-"))) + ",  ";
                    //    }
                    //    sql += objCon.valorSql(int.Parse(dr["NÚM# FILHOS"].ToString())) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DO PAI"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DA MÃE"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DO CÔNJUGE"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DEPENDENTE 01"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CPF DEPENDENTE 01"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 01"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DEPENDENTE 02"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CPF DEPENDENTE 02"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 02"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DEPENDENTE 03"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CPF DEPENDENTE 03"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 03"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DEPENDENTE 04"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CPF DEPENDENTE 04"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 04"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DEPENDENTE 05"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CPF DEPENDENTE 05"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 05"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DEPENDENTE 06"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CPF DEPENDENTE 06"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 06"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DEPENDENTE 07"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CPF DEPENDENTE 07"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 07"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DEPENDENTE 08"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CPF DEPENDENTE 09"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 08"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DEPENDENTE 09"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CPF DEPENDENTE 09"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 09"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["NOME DEPENDENTE 10"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CPF DEPENDENTE 10"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["RELACAO DEPENDENTE 10"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["DDD"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["TELEFONE"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["CELULAR"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["EMAIL"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(dr["RESPONSÁVEL_GH"].ToString()) + ",  ";
                    //    sql += objCon.valorSql(hlp.dataHoraAtual()) + ", ";
                    //    sql += objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + ") ";
                    //    objCon.executaQuery(sql, ref retorno);
                    //    #endregion
                    //}


                    ////Update
                    //if (retorno >= 1 && importar) {
                    //    DateTime capturarData = DateTime.Parse("1900-01-01");
                    //    #region Update
                    //    sql = "Update w_funcionarios set ";
                    //    sql += "NOME_EMPRESA = " + objCon.valorSql(dr["NOME EMPRESA"].ToString()) + ",  ";
                    //    sql += "MATRICULA = " + objCon.valorSql(dr["MATRICULA"].ToString()) + ",  ";
                    //    sql += "UB = " + objCon.valorSql("UB" + matricula.PadLeft(6, '0').ToString()) + ",  ";
                    //    sql += "NOME_ASSOCIADO = " + objCon.valorSql(dr["NOME ASSOCIADO"].ToString()) + ",  ";
                    //    if (dr["DATA DE ADMISSÃO"].ToString().Equals("")) { capturarData = DateTime.Parse("1900-01-01"); } else { capturarData = DateTime.Parse(dr["DATA DE ADMISSÃO"].ToString()); }
                    //    sql += "DATA_DE_ADMISSAO = " + objCon.valorSql(capturarData) + ",  ";
                    //    if (dr["DATA DEMISSAO"].ToString().Equals("")) { capturarData = DateTime.Parse("1900-01-01"); } else { capturarData = DateTime.Parse(dr["DATA DEMISSAO"].ToString()); }
                    //    sql += "DATA_DEMISSAO = " + objCon.valorSql(capturarData) + ",  ";
                    //    sql += "CODCENTRO_DE_CUSTO = " + objCon.valorSql(dr["COD#CENTRO DE CUSTO"].ToString()) + ",  ";
                    //    sql += "DESCRCENTRO_DE_CUSTO = " + objCon.valorSql(dr["DESCR#CENTRO DE CUSTO"].ToString()) + ",  ";
                    //    sql += "CARGO_DO_ASSOCIADO = " + objCon.valorSql(dr["CARGO DO ASSOCIADO"].ToString()) + ",  ";
                    //    sql += "SEXO = " + objCon.valorSql(dr["SEXO"].ToString()) + ",  ";
                    //    sql += "RUA = " + objCon.valorSql(dr["RUA"].ToString()) + ",  ";
                    //    sql += "NUMERO = " + objCon.valorSql(dr["Nº"].ToString()) + ",  ";
                    //    sql += "COMPLEMENTO = " + objCon.valorSql(dr["COMPLEMENTO"].ToString()) + ",  ";
                    //    sql += "BAIRRO = " + objCon.valorSql(dr["BAIRRO"].ToString()) + ",  ";
                    //    sql += "CIDADE = " + objCon.valorSql(dr["CIDADE"].ToString()) + ",  ";
                    //    sql += "ESTADO = " + objCon.valorSql(dr["ESTADO"].ToString()) + ",  ";
                    //    sql += "CEP = " + objCon.valorSql(dr["CEP"].ToString()) + ",  ";
                    //    sql += "PAIS = " + objCon.valorSql(dr["PAÍS"].ToString()) + ",  ";
                    //    sql += "CPF = " + objCon.valorSql(dr["CPF"].ToString()) + ",  ";
                    //    if (dr["DATA DE NASCIMENTO"].ToString().Equals("")) { capturarData = DateTime.Parse("1900-01-01"); } else { capturarData = DateTime.Parse(dr["DATA DE NASCIMENTO"].ToString()); }
                    //    sql += "DATA_DE_NASCIMENTO = " + objCon.valorSql(capturarData) + ",  ";
                    //    sql += "NUM_FILHOS = " + objCon.valorSql(dr["NÚM# FILHOS"].ToString()) + ",  ";
                    //    sql += "NOME_DO_PAI = " + objCon.valorSql(dr["NOME DO PAI"].ToString()) + ",  ";
                    //    sql += "NOME_DA_MAE = " + objCon.valorSql(dr["NOME DA MÃE"].ToString()) + ",  ";
                    //    sql += "NOME_DO_CONJUGE = " + objCon.valorSql(dr["NOME DO CÔNJUGE"].ToString()) + ",  ";
                    //    sql += "NOME_DEPENDENTE_01 = " + objCon.valorSql(dr["NOME DEPENDENTE 01"].ToString()) + ",  ";
                    //    sql += "CPF_DEPENDENTE_01 = " + objCon.valorSql(dr["CPF DEPENDENTE 01"].ToString()) + ",  ";
                    //    sql += "RELACAO_DEPENDENTE_01 = " + objCon.valorSql(dr["RELACAO DEPENDENTE 01"].ToString()) + ",  ";
                    //    sql += "NOME_DEPENDENTE_02 = " + objCon.valorSql(dr["NOME DEPENDENTE 02"].ToString()) + ",  ";
                    //    sql += "CPF_DEPENDENTE_02 = " + objCon.valorSql(dr["CPF DEPENDENTE 02"].ToString()) + ",  ";
                    //    sql += "RELACAO_DEPENDENTE_02 = " + objCon.valorSql(dr["RELACAO DEPENDENTE 02"].ToString()) + ",  ";
                    //    sql += "NOME_DEPENDENTE_03 = " + objCon.valorSql(dr["NOME DEPENDENTE 03"].ToString()) + ",  ";
                    //    sql += "CPF_DEPENDENTE_03 = " + objCon.valorSql(dr["CPF DEPENDENTE 03"].ToString()) + ",  ";
                    //    sql += "RELACAO_DEPENDENTE_03 = " + objCon.valorSql(dr["RELACAO DEPENDENTE 03"].ToString()) + ",  ";
                    //    sql += "NOME_DEPENDENTE_04 = " + objCon.valorSql(dr["NOME DEPENDENTE 04"].ToString()) + ",  ";
                    //    sql += "CPF_DEPENDENTE_04 = " + objCon.valorSql(dr["CPF DEPENDENTE 04"].ToString()) + ",  ";
                    //    sql += "RELACAO_DEPENDENTE_04 = " + objCon.valorSql(dr["RELACAO DEPENDENTE 04"].ToString()) + ",  ";
                    //    sql += "NOME_DEPENDENTE_05 = " + objCon.valorSql(dr["NOME DEPENDENTE 05"].ToString()) + ",  ";
                    //    sql += "CPF_DEPENDENTE_05 = " + objCon.valorSql(dr["CPF DEPENDENTE 05"].ToString()) + ",  ";
                    //    sql += "RELACAO_DEPENDENTE_05 = " + objCon.valorSql(dr["RELACAO DEPENDENTE 05"].ToString()) + ",  ";
                    //    sql += "NOME_DEPENDENTE_06 = " + objCon.valorSql(dr["NOME DEPENDENTE 06"].ToString()) + ",  ";
                    //    sql += "CPF_DEPENDENTE_06 = " + objCon.valorSql(dr["CPF DEPENDENTE 06"].ToString()) + ",  ";
                    //    sql += "RELACAO_DEPENDENTE_06 = " + objCon.valorSql(dr["RELACAO DEPENDENTE 06"].ToString()) + ",  ";
                    //    sql += "NOME_DEPENDENTE_07 = " + objCon.valorSql(dr["NOME DEPENDENTE 07"].ToString()) + ",  ";
                    //    sql += "CPF_DEPENDENTE_07 = " + objCon.valorSql(dr["CPF DEPENDENTE 07"].ToString()) + ",  ";
                    //    sql += "RELACAO_DEPENDENTE_07 = " + objCon.valorSql(dr["RELACAO DEPENDENTE 07"].ToString()) + ",  ";
                    //    sql += "NOME_DEPENDENTE_08 = " + objCon.valorSql(dr["NOME DEPENDENTE 08"].ToString()) + ",  ";
                    //    sql += "CPF_DEPENDENTE_08 = " + objCon.valorSql(dr["CPF DEPENDENTE 08"].ToString()) + ",  ";
                    //    sql += "RELACAO_DEPENDENTE_08 = " + objCon.valorSql(dr["RELACAO DEPENDENTE 08"].ToString()) + ",  ";
                    //    sql += "NOME_DEPENDENTE_09 = " + objCon.valorSql(dr["NOME DEPENDENTE 09"].ToString()) + ",  ";
                    //    sql += "CPF_DEPENDENTE_09 = " + objCon.valorSql(dr["CPF DEPENDENTE 09"].ToString()) + ",  ";
                    //    sql += "RELACAO_DEPENDENTE_09 = " + objCon.valorSql(dr["RELACAO DEPENDENTE 09"].ToString()) + ",  ";
                    //    sql += "NOME_DEPENDENTE_10 = " + objCon.valorSql(dr["NOME DEPENDENTE 10"].ToString()) + ",  ";
                    //    sql += "CPF_DEPENDENTE_10 = " + objCon.valorSql(dr["CPF DEPENDENTE 10"].ToString()) + ",  ";
                    //    sql += "RELACAO_DEPENDENTE_10 = " + objCon.valorSql(dr["RELACAO DEPENDENTE 10"].ToString()) + ",  ";
                    //    sql += "DDD = " + objCon.valorSql(dr["DDD"].ToString()) + ",  ";
                    //    sql += "TELEFONE = " + objCon.valorSql(dr["TELEFONE"].ToString()) + ",  ";
                    //    sql += "CELULAR = " + objCon.valorSql(dr["CELULAR"].ToString()) + ",  ";
                    //    sql += "EMAIL = " + objCon.valorSql(dr["EMAIL"].ToString()) + ",  ";
                    //    sql += "RESPONSAVEL_GH = " + objCon.valorSql(dr["RESPONSÁVEL_GH"].ToString()) + ",  ";
                    //    sql += "dataAtualizacao = " + objCon.valorSql(hlp.dataHoraAtual()) + ", ";
                    //    sql += "idAtualizacao = " + objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + " ";
                    //    sql += "Where MATRICULA = " + objCon.valorSql(matricula) + " ";
                    //    objCon.executaQuery(sql, ref retorno);
                    //    #endregion
                    //}
                    #endregion


                    frm.atualizarBarra(int.Parse(volAtualizado.ToString()));
                    volAtualizado += 1;
                }

                return true;

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - CADASTRO GERAL POR CONEXÃO (DAL)");
                return false;
            }
            finally {
                frm.Close();
                cnx.Close();
            }
        }

        private bool _cadastroGeralConexaoProcedure(ref long volAtualizado) {


            //Cursor
            Cursor.Current = Cursors.WaitCursor;
            bool importar = true;
            volAtualizado = 0;

            try {
                DataTable dt = new DataTable();
                DataTable dt_w = new DataTable();
                dt = objCon.retornaDataTable("EXECUTE IMP_CADASTRO_FUNCIONARIO N'" + Constantes.id_REDE_logadoFerramenta + "'");
                dt_w = objCon.retornaDataTable("select * from w_funcionarios_historico");


                frmProgressBar frm = new frmProgressBar(dt.Rows.Count);
                frm.Show();

                foreach (DataRow dr in dt.Rows) {
                    importar = true;
                    // Filtrar DataTable Histórico (DT_W) pelos dados da DataTable com informações atuais (DT)
                    // Validar se duplicidade é permitida ou não, dados para validação:
                    // - Cargo
                    // - Centro de Custo
                    // - Alteração de Gestão

                    //filtrando Datatable para registros de análises
                    DataRow[] duplicidade = dt_w.Select(
                        "cod_empresa = '" + dr["cod_empresa"].ToString() + "' AND " +
                        "matricula = '" + dr["cod_matricula"].ToString() + "' "
                        );

                    //validando se a duplicidade é permitida ou não                    
                    if (duplicidade.Length > 0) {
                        foreach (DataRow item in duplicidade) {
                            if (item["cargo_do_associado"].ToString().ToUpper() == dr["Nom_Cargo"].ToString().ToUpper()
                                && item["codcentro_de_custo"].ToString().ToUpper() == dr["num_Centro_Custo"].ToString().ToUpper()
                                && item["matricula_gestor_1"].ToString().ToUpper() == dr["Cod_Gestor_Hierarq_1"].ToString().ToUpper()
                                && item["matricula_gestor_2"].ToString().ToUpper() == dr["Cod_Gestor_Hierarq_2"].ToString().ToUpper()
                                && item["matricula_gestor_3"].ToString().ToUpper() == dr["Cod_Gestor_Hierarq_3"].ToString().ToUpper()
                                && item["matricula_gestor_4"].ToString().ToUpper() == dr["Cod_Gestor_Hierarq_4"].ToString().ToUpper()
                                && item["matricula_gestor_5"].ToString().ToUpper() == dr["Cod_Gestor_Hierarq_5"].ToString().ToUpper()
                                && item["data_demissao"].ToString().ToUpper() == dr["Dt_Demissao"].ToString().ToUpper()
                                ) {

                                importar = false;
                                break;
                            }
                        }
                    }

                    //Fazendo a importação
                    if (importar) {
                        #region Insert
                        sql = "Insert into w_funcionarios_historico ";
                        sql += "(NOME_EMPRESA, ";
                        sql += "COD_EMPRESA, ";
                        sql += "CPF, ";
                        sql += "MATRICULA, ";
                        sql += "UB, ";
                        sql += "NOME_ASSOCIADO, ";
                        sql += "DATA_DE_ADMISSAO, ";
                        sql += "DATA_DEMISSAO, ";
                        sql += "CODCENTRO_DE_CUSTO, ";
                        sql += "DESCRCENTRO_DE_CUSTO, ";
                        sql += "CARGO_DO_ASSOCIADO, ";
                        sql += "SEXO, ";
                        sql += "RUA, ";
                        sql += "NUMERO, ";
                        sql += "COMPLEMENTO, ";
                        sql += "BAIRRO, ";
                        sql += "CIDADE, ";
                        sql += "ESTADO, ";
                        sql += "CEP, ";
                        sql += "DATA_DE_NASCIMENTO, ";
                        sql += "TELEFONE, ";
                        sql += "CELULAR, ";
                        sql += "EMAIL, ";
                        sql += "GESTOR_1, ";
                        sql += "GESTOR_2, ";
                        sql += "GESTOR_3, ";
                        sql += "GESTOR_4, ";
                        sql += "GESTOR_5, ";
                        sql += "COD_EMP_GESTOR_1, ";
                        sql += "COD_EMP_GESTOR_2, ";
                        sql += "COD_EMP_GESTOR_3, ";
                        sql += "COD_EMP_GESTOR_4, ";
                        sql += "COD_EMP_GESTOR_5, ";
                        sql += "MATRICULA_GESTOR_1, ";
                        sql += "MATRICULA_GESTOR_2, ";
                        sql += "MATRICULA_GESTOR_3, ";
                        sql += "MATRICULA_GESTOR_4, ";
                        sql += "MATRICULA_GESTOR_5, ";
                        sql += "DATA_ESTABILIDADE_INICIO, ";
                        sql += "DATA_ESTABILIDADE_FIM, ";
                        sql += "dataAtualizacao, ";
                        sql += "idAtualizacao ";
                        sql += ") Values (";
                        sql += objCon.valorSql(dr["NOM_EMPRESA"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_EMPRESA"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_CPF"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_MATRICULA"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_UB"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["NOM_USUARIO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["DT_ADMISSAO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["DT_DEMISSAO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["NUM_CENTRO_CUSTO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["NOM_CENTRO_CUSTO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["NOM_CARGO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["TP_SEXO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["DES_ENDERECO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["NUM_ENDERECO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["DES_COMPLEMENTO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["NOM_BAIRRO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["NOM_LOCALIDADE"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["UF_LOCALIDADE"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["NUM_CEP"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["DT_NASCIMENTO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["IDT_TELEFONE_USUARIO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["IDT_CELULAR_USUARIO"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["DES_EMAIL"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["GESTOR1"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["GESTOR2"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["GESTOR3"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["GESTOR4"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["GESTOR5"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_EMPRESA_GESTOR_HIERARQ_1"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_EMPRESA_GESTOR_HIERARQ_2"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_EMPRESA_GESTOR_HIERARQ_3"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_EMPRESA_GESTOR_HIERARQ_4"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_EMPRESA_GESTOR_HIERARQ_5"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_GESTOR_HIERARQ_1"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_GESTOR_HIERARQ_2"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_GESTOR_HIERARQ_3"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_GESTOR_HIERARQ_4"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["COD_GESTOR_HIERARQ_5"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["DT_INICIO_ESTABILIDADE_CIPA"].ToString()) + ",  ";
                        sql += objCon.valorSql(dr["DT_FIM_ESTABILIDADE_CIPA"].ToString()) + ",  ";
                        sql += objCon.valorSql(hlp.dataHoraAtual()) + ", ";
                        sql += objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + ") ";
                        objCon.executaQuery(sql, ref retorno);
                        #endregion
                        volAtualizado += 1;
                    }

                    volTotal += 1;
                    frm.atualizarBarra(volTotal);

                }

                frm.Close();
                dt.Clear();
                dt_w.Clear();
                Cursor.Current = Cursors.Default;
                return true;

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - CADASTRO GERAL PROCEDURE (DAL)");
                Cursor.Current = Cursors.Default;
                return false;
            }

        }

        private bool _saquesCompulsivos(DateTime dtHora, int fila_id, string fila_nome, ref long volImportado) {
            try {
                DataTable dt = new DataTable();
                sql = "select a.bin, a.cpf, a.dataCorte, count(a.cartao) as qtde_saques ";
                sql += "from w_autorizacoes a inner join w_sysProdutos c on a.bin = c.bin ";
                sql += "where a.estabelecimento like '%saque bdn%' and c.produto <> 'CORPORATE' ";
                sql += "group by a.bin, a.cpf, a.dataCorte ";
                sql += "having count(a.cartao) > 1 ";
                sql += "order by qtde_saques desc ";
                dt = objCon.retornaDataTable(sql);

                //Importando registros caso tenha algum volume para isso (DT.ROWS.COUNT > 0)
                if (dt.Rows.Count > 0) {
                    frmProgressBar frm = new frmProgressBar(dt.Rows.Count);
                    int volTotal = 0;
                    frm.Show();
                    foreach (DataRow ln in dt.Rows) {
                        importacoes imp = new importacoes(
                            ln["bin"].ToString(),
                            ln["cpf"].ToString(),
                            DateTime.Parse(ln["dataCorte"].ToString()),
                            fila_id,
                            dtHora);

                        if (!_valorDuplicado(imp, true, false)) { //validação de status não é preciso, pq depende da data de corte, ciclos diferentes sobe para trabalho
                            _insertBase(imp);
                            volImportado += 1;
                        }

                        volTotal += 1;
                        frm.atualizarBarra(volTotal);
                    }

                    frm.Close();
                }

                return true;

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - SAQUES COMPULSIVOS (DAL)");
                return false;
            }
        }

        /// <summary>
        /// Manutenções realizadas pelo proprio funcionario em sua conta
        /// </summary>
        /// <param name="dtHora"></param>
        /// <param name="fila_id"></param>
        /// <param name="fila_nome"></param>
        /// <param name="volImportado"></param>
        /// <returns></returns>
        private bool _manutencaoPropria(DateTime dtHora, int fila_id, string fila_nome,  ref long volImportado) {
            try {

                DataTable dt = new DataTable();
                sql = "select m.bin, m.cpf, m.dataManutencao ";
                sql += "from w_funcionarios f ";
                sql += "inner join w_manutencoes m on f.CPF = m.cpf and f.UB = m.usuarioRealizouManutencao ";
                sql += "left join w_base b on m.bin = b.bin and m.cpf = b.cpf and m.dataManutencao = b.data_Registro "; //data de registro será correspondente a data de captura de cada processo
                sql += "where b.id is null "; //garantindo que o mesmo registro não suba outra vez para ser trabalhado
                sql += "group by m.bin, m.cpf, m.dataManutencao ";
                sql += "order by m.cpf, m.dataManutencao desc ";
                dt = objCon.retornaDataTable(sql);

                //Importando registros caso tenha algum volume para isso (DT.ROWS.COUNT > 0)
                if (dt.Rows.Count > 0) {
                    frmProgressBar frm = new frmProgressBar(dt.Rows.Count);
                    int volTotal = 0;
                    frm.Show();
                    foreach (DataRow ln in dt.Rows) {
                        importacoes imp = new importacoes(
                            ln["bin"].ToString(),
                            ln["cpf"].ToString(),
                            DateTime.Parse(ln["dataManutencao"].ToString()),
                            fila_id,
                            dtHora);

                        if (!_valorDuplicado(imp, true, true)) {
                            _insertBase(imp);
                            volImportado += 1;
                        }

                        volTotal += 1;
                        frm.atualizarBarra(volTotal);
                    }

                    frm.Close();
                }

                return true;

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - MANUTENCAO PROPRIA (DAL)");
                return false;
            }
        }

        /// <summary>
        /// Captura de alterações de limites dos últimos 6 meses
        /// Validando duplicidade de casos já disponibilizados para trabalho
        /// </summary>
        /// <returns></returns>
        private bool _alteracaoLimite(DateTime dtHora, int fila_id, string fila_nome, ref long volImportado) {
            try {

                DataTable dt = new DataTable();

                sql = "select c.bin, c.cpf, c.limite_Data_Alteracao ";
                sql += "from w_cartoes c left join w_manutencoes m on c.cartao = m.cartao and c.cpf = m.cpf and c.limite_Data_Alteracao = m.dataManutencao ";
                sql += "left join w_base b on c.bin = b.bin and c.cpf = b.cpf and c.limite_Data_Alteracao = b.data_Registro "; //data de registro será correspondente a data de captura de cada processo
                sql += "where b.id is null "; //garantindo que o mesmo registro não suba outra vez para ser trabalhado
                sql += "and m.usuarioRealizouManutencao not like '%system%' "; //usuário de sistema
                sql += "and m.usuarioRealizouManutencao not like '%SVCCRDGL%' "; //usuário de sistema
                sql += "and m.descricaoManutencao not like 'ADESAO AO LIMITE UNIFICADO%' "; // ação automática
                sql += "and c.limite_Data_Alteracao > DATEADD(DAY, -180, GETDATE()) "; //definido que a captura será dos ultimos 12 meses, mas disponibilizar para trabalho os últimos 6 meses
                sql += "and c.tipoCartao = 'CONTA' "; //alteração de limite só pode ser efetivado na CONTA
                sql += "group by c.bin, c.cpf, c.limite_Data_Alteracao ";
                dt = objCon.retornaDataTable(sql);

                //Importando registros caso tenha algum volume para isso (DT.ROWS.COUNT > 0)
                frmProgressBar frm = new frmProgressBar(dt.Rows.Count);
                frm.Show();

                if (dt.Rows.Count > 0) {
                    foreach (DataRow ln in dt.Rows) {
                        importacoes imp = new importacoes(
                            ln["bin"].ToString(),
                            ln["cpf"].ToString(),
                            DateTime.Parse(ln["limite_Data_Alteracao"].ToString()),
                            fila_id,
                            dtHora);
                        _insertBase(imp);
                        volImportado += 1;
                    }
                    volTotal += 1;
                    frm.atualizarBarra(volTotal);
                }

                frm.Close();
                return true;

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - ALTERACAO_LIMITE(DAL)");
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtHora"></param>
        /// <param name="fila_id"></param>
        /// <param name="fila_nome"></param>
        /// <param name="volImportado"></param>
        /// <returns></returns>
        private bool _alteracaoEndereco(DateTime dtHora, int fila_id, string fila_nome, ref long volImportado) {
            try {

                DataTable dt = new DataTable();

                sql = "select c.bin, c.cpf, c.data_alteracao_End ";
                sql += "from w_dadosCadastrais c ";
                sql += "left join w_base b on c.bin = b.bin and c.cpf = b.cpf and c.data_alteracao_End = b.data_Registro "; //data de registro será correspondente a data de captura de cada processo
                sql += "where b.id is null "; //garantindo que o mesmo registro não suba outra vez para ser trabalhado
                sql += "and c.data_alteracao_End > DATEADD(DAY, -180, GETDATE()) ";//definido que a captura será dos ultimos 12 meses, mas disponibilizar para trabalho os últimos 6 meses
                sql += "group by c.bin, c.cpf, c.data_alteracao_End ";
                dt = objCon.retornaDataTable(sql);

                //Importando registros caso tenha algum volume para isso (DT.ROWS.COUNT > 0)
                frmProgressBar frm = new frmProgressBar(dt.Rows.Count);
                frm.Show();

                if (dt.Rows.Count > 0) {
                    foreach (DataRow ln in dt.Rows) {
                        importacoes imp = new importacoes(
                            ln["bin"].ToString(),
                            ln["cpf"].ToString(),
                            DateTime.Parse(ln["data_alteracao_End"].ToString()),
                            fila_id,
                            dtHora);
                        _insertBase(imp);
                        volImportado += 1;
                    }
                    volTotal += 1;
                    frm.atualizarBarra(volTotal);
                }

                frm.Close();
                return true;

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - ALTERACAO_ENDERECO(DAL)");
                return false;
            }
        }
        
        private bool distribuicaoVolFilaporUsuario(DateTime dtHoraImp, int[] usuarios) {
            try {
                sql = "Select fila_id, data_abertura, count(id) as vol from w_base where ";
                sql += "data_Abertura = " + objCon.valorSql(dtHoraImp) + " ";
                sql += "and id_Abertura = " + objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + " ";
                sql += "and status_id = 0 ";
                sql += "group by fila_id, data_abertura";
                DataTable dt = new DataTable();
                dt = objCon.retornaDataTable(sql);

                //Passar por cada linha de volume, dividir o volume por usuários e registrar
                if (dt.Rows.Count > 0 && usuarios.Length > 0) {
                    foreach (DataRow item in dt.Rows) {
                        //tratando eventual erro de divisão de zero
                        int volTotal = int.Parse(item["vol"].ToString());
                        if (volTotal > 0) {

                            int volPorUsuario = (volTotal / usuarios.Length);
                            int volDistribuido = 0;

                            //registrando vol/por usuário
                            for (int i = 0; i < usuarios.Length; i++) {

                                volDistribuido += volPorUsuario;
                                usuariosVolParaTrabalho salvarVolPorUsuario = new usuariosVolParaTrabalho();
                                usuariosVolParaTrabalho volume = new usuariosVolParaTrabalho(
                                                            DateTime.Parse(item["data_abertura"].ToString()),
                                                            int.Parse(item["fila_id"].ToString()),
                                                            volPorUsuario,
                                                            usuarios[i]
                                                            );
                                
                                if (volDistribuido + 1 == volTotal) {
                                    // se o volume distribuido +1 for igual ao total significa que o vol por usuário
                                    //deve ser acréscido de 1 pq trata-se da última parte da divisão
                                    volume.qtde_registros += 1;

                                    //saindo da função se houver erro na distribuição
                                    if (!salvarVolPorUsuario.registrarVolume(volume)) { return false; }

                                } else if (volDistribuido + 1 < volTotal) {
                                    // se o volume distribuido +1 for menor que ao total significa que ainda não é o último
                                    // usuário a receber volume, por isso desconsidera-se a fração da divisão

                                    //saindo da função se houver erro na distribuição
                                    if (!salvarVolPorUsuario.registrarVolume(volume)) { return false; }

                                } else {
                                    // a divisão do volume por usuários foi equivalente e não gerou frações

                                    //saindo da função se houver erro na distribuição
                                    if (!salvarVolPorUsuario.registrarVolume(volume)) { return false; }
                                }

                            }
                        }
                    }
                }

                //retorno verdadeiro visto não ter ou vol para dividir ou usuarios para receber vol não é um erro
                return true;


            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - DISTRIBUICAO VOL POR USUARIO (DAL)");
                return false;
            }
        }

        #endregion

        #region Camada BLL - Negocio

        public bool dlp(string diretorio, int[] listaUsuarios) {
            try {
                long volAtualizado = 0;
                bool validacaoImportacao;
                DateTime dtHora = hlp.dataHoraAtual();
                validacaoImportacao = _dlpConexao(diretorio, dtHora, ref volAtualizado);


                //Registrar loGs de importações
                logsImportacoes logImp = new logsImportacoes("IMPORTACAO", hlp.dataHoraAtual(), 0, "DLP", volAtualizado);
                logImp.incluir(logImp);


                //Mensagem final sobre a importação..
                if (validacaoImportacao) {

                    //DISTRIBUIR VOLUME POR USUÁRIO
                    if (!distribuicaoVolFilaporUsuario(dtHora, listaUsuarios)) {
                        MessageBox.Show("Falha na distribuição de casos por analista!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Importação concluída com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                } else {
                    MessageBox.Show("Importação concluída com falha!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - DLP (BLL)");
                return false;
            }
        }

        public bool CadastroGeralProcedure() {
            try {
                long volAtualizado = 0;
                bool validacaoImportacao;
                validacaoImportacao = _cadastroGeralConexaoProcedure(ref volAtualizado);

                //Registrar loGs de importações
                logsImportacoes logImp = new logsImportacoes("IMPORTACAO", hlp.dataHoraAtual(), 0, "CADASTRO GERAL PROCEDURE", volAtualizado);
                logImp.incluir(logImp);

                //Mensagem final sobre a importação..
                if (validacaoImportacao) {
                    MessageBox.Show("Importação concluída com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                } else {
                    MessageBox.Show("Importação concluída com falha!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - CADASTRO GERAL POR PROCEDURE (BLL)");
                return false;
            }
        }

        public bool CadastroGeralConexao(string diretorio) {
            try {
                long volAtualizado = 0;
                bool validacaoImportacao;
                validacaoImportacao = _cadastroGeralConexao(diretorio, ref volAtualizado);

                //Registrar loGs de importações
                logsImportacoes logImp = new logsImportacoes("IMPORTACAO", hlp.dataHoraAtual(), 0, "CADASTRO GERAL", volAtualizado);
                logImp.incluir(logImp);

                //Mensagem final sobre a importação..
                if (validacaoImportacao) {
                    MessageBox.Show("Importação concluída com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                } else {
                    MessageBox.Show("Importação concluída com falha!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - CADASTRO GERAL POR CONEXÃO (BLL)");
                return false;
            }
        }

        public bool incluir(int fila_id, int[] listaUsuarios) {
            try {

                //Variáveis de controles e de logs
                bool validacaoImportacao = false;
                DateTime dtHora = hlp.dataHoraAtual();
                filas fila = new filas();
                fila = fila.capturarFilaPorID(fila_id);
                string fila_nome = fila.Descricao.ToString();
                long volImportado = 0;


                //Lista de importações
                switch (fila_id) {
                    case 1:
                        validacaoImportacao = _alteracaoLimite(dtHora, fila_id, fila_nome, ref volImportado);
                        break;
                    case 2:
                        validacaoImportacao = _alteracaoEndereco(dtHora, fila_id, fila_nome,  ref volImportado);
                        break;
                    case 3:
                        validacaoImportacao = _manutencaoPropria(dtHora, fila_id, fila_nome, ref volImportado);
                        break;
                    case 4:
                        validacaoImportacao = _saquesCompulsivos(dtHora, fila_id, fila_nome,  ref volImportado);
                        break;
                }


                //Registrar loGs de importações
                logsImportacoes logImp = new logsImportacoes("IMPORTACAO", dtHora, fila_id, fila_nome.ToString(), volImportado);
                logImp.incluir(logImp);

                //Mensagem final sobre a importação..
                if (validacaoImportacao) {


                    //DISTRIBUIR VOLUME POR USUÁRIO
                    if (!distribuicaoVolFilaporUsuario(dtHora, listaUsuarios)) {
                        MessageBox.Show("Falha na distribuição de casos por analista!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Importação concluída com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                } else {
                    MessageBox.Show("Importação concluída com falha!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO(fila_id " + fila_id + ") - INSERIR NA BASE(BLL)");
                return false;
            }
        }

        public bool excluir(importacoes obj, int id_logImp) {
            try {

                //Variáveis de controles e de logs
                bool validacaoImportacao = false;
                filas fila = new filas();
                fila = fila.capturarFilaPorID(obj.Fila_id);
                string fila_nome = fila.Descricao.ToString();
                long volExcluido = 0;

                //Deletar
                validacaoImportacao = _excluirBase(obj, ref volExcluido);

                //Registrar loGs de DELEÇÃO                
                logsImportacoes logImp = new logsImportacoes("DELECAO (ID = " + id_logImp + ")", hlp.dataHoraAtual(), obj.Fila_id, fila_nome.ToString(), volExcluido);
                logImp.incluir(logImp);

                //Mensagem final sobre a importação..
                if (validacaoImportacao) {
                    MessageBox.Show("Exclusão concluída com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                } else {
                    MessageBox.Show("Exclusão concluída com falha!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO(fila_id " + obj.Fila_id + ") - DELETAR DA BASE(BLL)");
                return false;
            }
        }

        public bool inserirFup(importacoes obj) {
            try {
                return _insertBase(obj);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO(fila_id " + obj.Fila_id + ") - GERAR FUP(BLL)");
                return false;
            }
        }

        #endregion

        #region DECOMISSIONADO


        //private string _textoCelulas(string _coluna, int _linha) {
        //    try {
        //        Excel.Application appExcel = new Excel.Application();
        //        Excel.Worksheet excelSheet = (Excel.Worksheet)appExcel.ActiveSheet;
        //        Excel.Range range = excelSheet.UsedRange;
        //        string texto = (range.Cells[_linha, _coluna] as Excel.Range).Value.ToString();
        //        texto.Trim();
        //        return texto;
        //    } catch (Exception ex) {
        //        log.registrarLog(ex.ToString(), "IMPORTACAO - LEITURA CELULAS EXCEL");
        //        return "";
        //    }
        //}



        //public bool CadastroGeral(string diretorio) {
        //    try {
        //        long volAtualizado = 0;
        //        bool validacaoImportacao;
        //        validacaoImportacao = _cadastroGeral(diretorio, ref volAtualizado);

        //        //Registrar loGs de importações
        //        logsImportacoes logImp = new logsImportacoes("IMPORTACAO", hlp.dataHoraAtual(), 0, "CADASTRO GERAL", volAtualizado);
        //        logImp.incluir(logImp);

        //        //Mensagem final sobre a importação..
        //        if (validacaoImportacao) {
        //            MessageBox.Show("Importação concluída com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return true;
        //        } else {
        //            MessageBox.Show("Importação concluída com falha!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }

        //    } catch (Exception ex) {
        //        log.registrarLog(ex.ToString(), "IMPORTACAO - CADASTRO GERAL (BLL)");
        //        return false;
        //    }
        //}




        //private bool _cadastroGeral(string diretorio, ref long volAtualizado) {

        //    try {
        //        #region Variaveis
        //        //Excel.Application appExcel = new Excel.Application();
        //        //Excel.Workbook excelBook = new Excel.Workbook();
        //        DataTable dt = new DataTable();
        //        //List<string> listaMatriculas = new List<string>();
        //        //string filtroMatricula;
        //        string matricula;
        //        int linha = 2; //Primeira linha a ser verificada                    
        //        #endregion

        //        ////Carregando base já importada para comparação e determinar duplicidades
        //        //sql = "Select matricula from w_funcionarios";
        //        //dt = objCon.retornaDataTable(sql);
        //        ////carregando dataTable para lista
        //        //foreach (DataRow item in dt.Rows) {                    
        //        //    listaMatriculas.Add(item.ToString());
        //        //}


        //        //Abrindo Excel                                   
        //        Excel.Application appExcel = new Excel.Application();
        //        Excel.Workbook excelBook = appExcel.Workbooks.Open(diretorio);
        //        Excel.Worksheet excelSheet = (Excel.Worksheet)appExcel.ActiveSheet;
        //        Excel.Range range = excelSheet.UsedRange;
        //        appExcel.Visible = true;

        //        //contar as linhas do excel
        //        while (_textoCelulas("A", linha) != "") {
        //            linha += 1;
        //        }

        //        //carregar form Barra de Progresso
        //        frmProgressBar frm = new frmProgressBar(linha);
        //        frm.Show();

        //        linha = 2; //resentando a linha
        //        while (_textoCelulas("A", linha) != "") {
        //            //Capturando matrícula
        //            matricula = _textoCelulas("C", linha);
        //            DateTime dataDemissao;
        //            bool importar = false;
        //            if (_textoCelulas("E", linha).Equals("")) { dataDemissao = DateTime.Parse("1900-01-01"); } else { dataDemissao = DateTime.Parse(_textoCelulas("E", linha)); }
        //            //Filtrando matrícula que está a ser importada para definir se será uma atualização ou uma inclusão                          
        //            retorno = 0;
        //            sql = "Select * from w_funcionarios where matricula = '" + matricula + "'";
        //            dt = objCon.retornaDataTable(sql);
        //            if (dt.Rows.Count > 0) {
        //                foreach (DataRow ln in dt.Rows) {
        //                    if (DateTime.Parse(ln["DATA_DEMISSAO"].ToString()) == dataDemissao) {
        //                        importar = false;
        //                        break;
        //                    } else {
        //                        importar = true;
        //                    }
        //                }
        //                retorno = 1;
        //            } else {
        //                retorno = 0;
        //                importar = true;
        //            }

        //            //melhorar implantando expressao linq
        //            //filtroMatricula = "";
        //            //filtroMatricula = listaMatriculas.Where(m => m.Equals(matricula)).First().ToString();

        //            //Insert
        //            if (retorno == 0 && importar) {
        //                #region Insert
        //                sql = "Insert into w_funcionarios ";
        //                sql += "(NOME_EMPRESA, ";
        //                sql += "MATRICULA, ";
        //                sql += "UB, ";
        //                sql += "NOME_ASSOCIADO, ";
        //                sql += "DATA_DE_ADMISSAO, ";
        //                sql += "DATA_DEMISSAO, ";
        //                sql += "CODCENTRO_DE_CUSTO, ";
        //                sql += "DESCRCENTRO_DE_CUSTO, ";
        //                sql += "CARGO_DO_ASSOCIADO, ";
        //                sql += "SEXO, ";
        //                sql += "RUA, ";
        //                sql += "NUMERO, ";
        //                sql += "COMPLEMENTO, ";
        //                sql += "BAIRRO, ";
        //                sql += "CIDADE, ";
        //                sql += "ESTADO, ";
        //                sql += "CEP, ";
        //                sql += "PAIS, ";
        //                sql += "CPF, ";
        //                sql += "DATA_DE_NASCIMENTO, ";
        //                sql += "NUM_FILHOS, ";
        //                sql += "NOME_DO_PAI, ";
        //                sql += "NOME_DA_MAE, ";
        //                sql += "NOME_DO_CONJUGE, ";
        //                sql += "NOME_DEPENDENTE_01, ";
        //                sql += "CPF_DEPENDENTE_01, ";
        //                sql += "RELACAO_DEPENDENTE_01, ";
        //                sql += "NOME_DEPENDENTE_02, ";
        //                sql += "CPF_DEPENDENTE_02, ";
        //                sql += "RELACAO_DEPENDENTE_02, ";
        //                sql += "NOME_DEPENDENTE_03, ";
        //                sql += "CPF_DEPENDENTE_03, ";
        //                sql += "RELACAO_DEPENDENTE_03, ";
        //                sql += "NOME_DEPENDENTE_04, ";
        //                sql += "CPF_DEPENDENTE_04, ";
        //                sql += "RELACAO_DEPENDENTE_04, ";
        //                sql += "NOME_DEPENDENTE_05, ";
        //                sql += "CPF_DEPENDENTE_05, ";
        //                sql += "RELACAO_DEPENDENTE_05, ";
        //                sql += "NOME_DEPENDENTE_06, ";
        //                sql += "CPF_DEPENDENTE_06, ";
        //                sql += "RELACAO_DEPENDENTE_06, ";
        //                sql += "NOME_DEPENDENTE_07, ";
        //                sql += "CPF_DEPENDENTE_07, ";
        //                sql += "RELACAO_DEPENDENTE_07, ";
        //                sql += "NOME_DEPENDENTE_08, ";
        //                sql += "CPF_DEPENDENTE_08, ";
        //                sql += "RELACAO_DEPENDENTE_08, ";
        //                sql += "NOME_DEPENDENTE_09, ";
        //                sql += "CPF_DEPENDENTE_09, ";
        //                sql += "RELACAO_DEPENDENTE_09, ";
        //                sql += "NOME_DEPENDENTE_10, ";
        //                sql += "CPF_DEPENDENTE_10, ";
        //                sql += "RELACAO_DEPENDENTE_10, ";
        //                sql += "DDD, ";
        //                sql += "TELEFONE, ";
        //                sql += "CELULAR, ";
        //                sql += "EMAIL, ";
        //                sql += "RESPONSAVEL_GH, ";
        //                sql += "dataAtualizacao, ";
        //                sql += "idAtualizacao ";
        //                sql += ") Values (";
        //                sql += objCon.valorSql(_textoCelulas("B", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("C", linha)) + ",  ";
        //                sql += objCon.valorSql("UB" + matricula.PadLeft(6, '0').ToString()) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("D", linha)) + ",  ";
        //                if (_textoCelulas("BQ", linha).Equals("")) {
        //                    sql += objCon.valorSql(DateTime.Parse("1900-01-01")) + ",  ";
        //                } else {
        //                    sql += objCon.valorSql(DateTime.Parse(_textoCelulas("BQ", linha))) + ",  ";
        //                }
        //                if (_textoCelulas("E", linha).Equals("")) {
        //                    sql += objCon.valorSql(DateTime.Parse("1900-01-01")) + ",  ";
        //                } else {
        //                    sql += objCon.valorSql(DateTime.Parse(_textoCelulas("E", linha))) + ",  ";
        //                }
        //                sql += objCon.valorSql(_textoCelulas("G", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("H", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("I", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("AF", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("AG", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("AH", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("AI", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("AJ", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("AK", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("AL", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("AM", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("AN", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("AY", linha)) + ",  ";
        //                if (_textoCelulas("BR", linha).Equals("")) {
        //                    sql += objCon.valorSql(DateTime.Parse("1900-01-01")) + ",  ";
        //                } else {
        //                    sql += objCon.valorSql(DateTime.Parse(_textoCelulas("BR", linha))) + ",  ";
        //                }
        //                sql += objCon.valorSql(int.Parse(_textoCelulas("BS", linha))) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("BT", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("BU", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("BV", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("BW", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("BX", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("BY", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("BZ", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CA", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CB", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CC", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CD", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CE", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CF", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CG", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CH", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CI", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CJ", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CK", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CL", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CM", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CN", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CO", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CP", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CQ", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CR", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CS", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CT", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CU", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CV", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CW", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CX", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CY", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("CZ", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("EV", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("EW", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("EX", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("EY", linha)) + ",  ";
        //                sql += objCon.valorSql(_textoCelulas("FC", linha)) + ",  ";
        //                sql += objCon.valorSql(hlp.dataHoraAtual()) + ", ";
        //                sql += objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + ") ";
        //                objCon.executaQuery(sql, ref retorno);
        //                #endregion
        //            }

        //            //Update
        //            if (retorno >= 1 && importar) {
        //                DateTime capturarData = DateTime.Parse("1900-01-01");
        //                #region Update
        //                sql = "Update w_funcionarios set ";
        //                sql += "NOME_EMPRESA = " + objCon.valorSql(_textoCelulas("B", linha)) + ",  ";
        //                sql += "MATRICULA = " + objCon.valorSql(_textoCelulas("C", linha)) + ",  ";
        //                sql += "UB = " + objCon.valorSql("UB" + matricula.PadLeft(6, '0').ToString()) + ",  ";
        //                sql += "NOME_ASSOCIADO = " + objCon.valorSql(_textoCelulas("D", linha)) + ",  ";
        //                if (_textoCelulas("BQ", linha).Equals("")) { capturarData = DateTime.Parse("1900-01-01"); } else { capturarData = DateTime.Parse(_textoCelulas("BQ", linha)); }
        //                sql += "DATA_DE_ADMISSAO = " + objCon.valorSql(capturarData) + ",  ";
        //                if (_textoCelulas("E", linha).Equals("")) { capturarData = DateTime.Parse("1900-01-01"); } else { capturarData = DateTime.Parse(_textoCelulas("E", linha)); }
        //                sql += "DATA_DEMISSAO = " + objCon.valorSql(capturarData) + ",  ";
        //                sql += "CODCENTRO_DE_CUSTO = " + objCon.valorSql(_textoCelulas("G", linha)) + ",  ";
        //                sql += "DESCRCENTRO_DE_CUSTO = " + objCon.valorSql(_textoCelulas("H", linha)) + ",  ";
        //                sql += "CARGO_DO_ASSOCIADO = " + objCon.valorSql(_textoCelulas("I", linha)) + ",  ";
        //                sql += "SEXO = " + objCon.valorSql(_textoCelulas("AF", linha)) + ",  ";
        //                sql += "RUA = " + objCon.valorSql(_textoCelulas("AG", linha)) + ",  ";
        //                sql += "NUMERO = " + objCon.valorSql(_textoCelulas("AH", linha)) + ",  ";
        //                sql += "COMPLEMENTO = " + objCon.valorSql(_textoCelulas("AI", linha)) + ",  ";
        //                sql += "BAIRRO = " + objCon.valorSql(_textoCelulas("AJ", linha)) + ",  ";
        //                sql += "CIDADE = " + objCon.valorSql(_textoCelulas("AK", linha)) + ",  ";
        //                sql += "ESTADO = " + objCon.valorSql(_textoCelulas("AL", linha)) + ",  ";
        //                sql += "CEP = " + objCon.valorSql(_textoCelulas("AM", linha)) + ",  ";
        //                sql += "PAIS = " + objCon.valorSql(_textoCelulas("AN", linha)) + ",  ";
        //                sql += "CPF = " + objCon.valorSql(_textoCelulas("AY", linha)) + ",  ";
        //                if (_textoCelulas("BR", linha).Equals("")) { capturarData = DateTime.Parse("1900-01-01"); } else { capturarData = DateTime.Parse(_textoCelulas("BR", linha)); }
        //                sql += "DATA_DE_NASCIMENTO = " + objCon.valorSql(capturarData) + ",  ";
        //                sql += "NUM_FILHOS = " + objCon.valorSql(_textoCelulas("BS", linha)) + ",  ";
        //                sql += "NOME_DO_PAI = " + objCon.valorSql(_textoCelulas("BT", linha)) + ",  ";
        //                sql += "NOME_DA_MAE = " + objCon.valorSql(_textoCelulas("BU", linha)) + ",  ";
        //                sql += "NOME_DO_CONJUGE = " + objCon.valorSql(_textoCelulas("BV", linha)) + ",  ";
        //                sql += "NOME_DEPENDENTE_01 = " + objCon.valorSql(_textoCelulas("BW", linha)) + ",  ";
        //                sql += "CPF_DEPENDENTE_01 = " + objCon.valorSql(_textoCelulas("BX", linha)) + ",  ";
        //                sql += "RELACAO_DEPENDENTE_01 = " + objCon.valorSql(_textoCelulas("BY", linha)) + ",  ";
        //                sql += "NOME_DEPENDENTE_02 = " + objCon.valorSql(_textoCelulas("BZ", linha)) + ",  ";
        //                sql += "CPF_DEPENDENTE_02 = " + objCon.valorSql(_textoCelulas("CA", linha)) + ",  ";
        //                sql += "RELACAO_DEPENDENTE_02 = " + objCon.valorSql(_textoCelulas("CB", linha)) + ",  ";
        //                sql += "NOME_DEPENDENTE_03 = " + objCon.valorSql(_textoCelulas("CC", linha)) + ",  ";
        //                sql += "CPF_DEPENDENTE_03 = " + objCon.valorSql(_textoCelulas("CD", linha)) + ",  ";
        //                sql += "RELACAO_DEPENDENTE_03 = " + objCon.valorSql(_textoCelulas("CE", linha)) + ",  ";
        //                sql += "NOME_DEPENDENTE_04 = " + objCon.valorSql(_textoCelulas("CF", linha)) + ",  ";
        //                sql += "CPF_DEPENDENTE_04 = " + objCon.valorSql(_textoCelulas("CG", linha)) + ",  ";
        //                sql += "RELACAO_DEPENDENTE_04 = " + objCon.valorSql(_textoCelulas("CH", linha)) + ",  ";
        //                sql += "NOME_DEPENDENTE_05 = " + objCon.valorSql(_textoCelulas("CI", linha)) + ",  ";
        //                sql += "CPF_DEPENDENTE_05 = " + objCon.valorSql(_textoCelulas("CJ", linha)) + ",  ";
        //                sql += "RELACAO_DEPENDENTE_05 = " + objCon.valorSql(_textoCelulas("CK", linha)) + ",  ";
        //                sql += "NOME_DEPENDENTE_06 = " + objCon.valorSql(_textoCelulas("CL", linha)) + ",  ";
        //                sql += "CPF_DEPENDENTE_06 = " + objCon.valorSql(_textoCelulas("CM", linha)) + ",  ";
        //                sql += "RELACAO_DEPENDENTE_06 = " + objCon.valorSql(_textoCelulas("CN", linha)) + ",  ";
        //                sql += "NOME_DEPENDENTE_07 = " + objCon.valorSql(_textoCelulas("CO", linha)) + ",  ";
        //                sql += "CPF_DEPENDENTE_07 = " + objCon.valorSql(_textoCelulas("CP", linha)) + ",  ";
        //                sql += "RELACAO_DEPENDENTE_07 = " + objCon.valorSql(_textoCelulas("CQ", linha)) + ",  ";
        //                sql += "NOME_DEPENDENTE_08 = " + objCon.valorSql(_textoCelulas("CR", linha)) + ",  ";
        //                sql += "CPF_DEPENDENTE_08 = " + objCon.valorSql(_textoCelulas("CS", linha)) + ",  ";
        //                sql += "RELACAO_DEPENDENTE_08 = " + objCon.valorSql(_textoCelulas("CT", linha)) + ",  ";
        //                sql += "NOME_DEPENDENTE_09 = " + objCon.valorSql(_textoCelulas("CU", linha)) + ",  ";
        //                sql += "CPF_DEPENDENTE_09 = " + objCon.valorSql(_textoCelulas("CV", linha)) + ",  ";
        //                sql += "RELACAO_DEPENDENTE_09 = " + objCon.valorSql(_textoCelulas("CW", linha)) + ",  ";
        //                sql += "NOME_DEPENDENTE_10 = " + objCon.valorSql(_textoCelulas("CX", linha)) + ",  ";
        //                sql += "CPF_DEPENDENTE_10 = " + objCon.valorSql(_textoCelulas("CY", linha)) + ",  ";
        //                sql += "RELACAO_DEPENDENTE_10 = " + objCon.valorSql(_textoCelulas("CZ", linha)) + ",  ";
        //                sql += "DDD = " + objCon.valorSql(_textoCelulas("EV", linha)) + ",  ";
        //                sql += "TELEFONE = " + objCon.valorSql(_textoCelulas("EW", linha)) + ",  ";
        //                sql += "CELULAR = " + objCon.valorSql(_textoCelulas("EX", linha)) + ",  ";
        //                sql += "EMAIL = " + objCon.valorSql(_textoCelulas("EY", linha)) + ",  ";
        //                sql += "RESPONSAVEL_GH = " + objCon.valorSql(_textoCelulas("FC", linha)) + ",  ";
        //                sql += "dataAtualizacao = " + objCon.valorSql(hlp.dataHoraAtual()) + ", ";
        //                sql += "idAtualizacao = " + objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + " ";
        //                sql += "Where MATRICULA = " + objCon.valorSql(matricula) + " ";
        //                objCon.executaQuery(sql, ref retorno);
        //                #endregion
        //            }

        //            frm.atualizarBarra(linha);
        //            linha += 1; //próxima linha a ser analisada                                        
        //            volAtualizado += 1;
        //        }

        //        frm.Close();
        //        appExcel.DisplayAlerts = false;
        //        appExcel.Quit();
        //        return true;

        //    } catch (Exception ex) {
        //        appExcel.DisplayAlerts = false;
        //        appExcel.Quit();
        //        log.registrarLog(ex.ToString(), "IMPORTACAO - CADASTRO GERAL (DAL)");
        //        return false;
        //    }

        //}


        #endregion

    }
}
