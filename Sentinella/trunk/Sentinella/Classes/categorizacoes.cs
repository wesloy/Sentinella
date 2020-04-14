using System;
using System.Data;
using System.Windows.Forms;

namespace Sentinella
{
    class categorizacoes
    {

        //	CREATE TABLE [dbo].[w_base] (
        //	    [id]                      INT            IDENTITY (1, 1) NOT NULL,
        //	    [bin]                     NVARCHAR (6)   NULL,
        //	    [cpf]                     NVARCHAR (15)  NULL,
        //	    [data_Registro]           DATETIME       DEFAULT ('1900-01-01 00:00:00') NOT NULL,
        //	    [fila_id]                 INT            DEFAULT ((0)) NOT NULL,
        //	    [status_id]               INT            DEFAULT ((0)) NOT NULL,
        //	    [idCat]                   INT            DEFAULT ((0)) NOT NULL,
        //	    [finalizacao_id]          INT            DEFAULT ((0)) NOT NULL,
        //	    [subFinalizacao_id]       INT            DEFAULT ((0)) NOT NULL,
        //	    [observacao]              NVARCHAR (500) DEFAULT ((0)) NOT NULL,
        //	    [data_Trabalho]           DATE           DEFAULT ('1900-01-01') NOT NULL,
        //	    [hora_Inicial]            DATETIME       DEFAULT ('1900-01-01 00:00:00') NOT NULL,
        //	    [hora_Final]              DATETIME       DEFAULT ('1900-01-01 00:00:00') NOT NULL,
        //	    [tempo_Trabalho_Segundos] FLOAT (53)     DEFAULT ((0)) NOT NULL,
        //	    [valor_Envolvido]         MONEY          DEFAULT ((0)) NOT NULL,
        //	    [sla_cumprido]            BIT            DEFAULT ((0)) NOT NULL,
        //	    [sla_meta]            INT            DEFAULT ((0)) NOT NULL,
        //	    [gerado_fup]              BIT            DEFAULT ((0)) NOT NULL,
        //	    [id_Historico]            INT            DEFAULT ((0)) NOT NULL,
        //	    [data_Abertura]           DATETIME       DEFAULT (getdate()) NULL,
        //	    [id_Abertura]             NVARCHAR (10)  NULL,
        //	    CONSTRAINT [PK_w_base] PRIMARY KEY CLUSTERED ([id] ASC)
        //	);

        #region Variaveis 
        bool validacao = false;
        long retorno = 0;
        string sql = "";
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        #endregion

        #region Camada DTO - Entidades

        #region Atributos
        int _id;
        string _bin;
        string _cpf;
        DateTime _data_Registro;
        int _fila_id;
        int _status_id;
        int _idCat;
        int _finalizacao_id;
        int _subFinalizacao_id;
        string _observacao;
        DateTime _data_Trabalho;
        DateTime _hora_Inicial;
        DateTime _hora_Final;
        double _tempo_Trabalho_Segundos;
        double _valor_Envolvido;
        bool _sla_cumprido;
        int _sla_meta;
        bool _gerado_fup;
        int _id_Historico;
        DateTime _data_Abertura;
        string _id_Abertura;
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

        public string Bin {
            get {
                return objCon.retornaVazioParaValorNulo(_bin).ToString().Replace("  ", " ").Trim();
            }

            set {
                _bin = value;
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

        public DateTime Data_Registro {
            get {
                DateTime dt;
                if (_data_Registro == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _data_Registro; }
                return dt;
            }

            set {
                _data_Registro = value;
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

        public int Status_id {
            get {
                return _status_id;
            }

            set {
                _status_id = value;
            }
        }

        public int IdCat {
            get {
                return _idCat;
            }

            set {
                _idCat = value;
            }
        }

        public int Finalizacao_id {
            get {
                return _finalizacao_id;
            }

            set {
                _finalizacao_id = value;
            }
        }

        public int SubFinalizacao_id {
            get {
                return _subFinalizacao_id;
            }

            set {
                _subFinalizacao_id = value;
            }
        }

        public DateTime Data_Trabalho {
            get {
                DateTime dt;
                if (_data_Trabalho == null) { dt = DateTime.Parse("1900-01-01"); } else { dt = _data_Trabalho; }
                return dt;
            }

            set {
                _data_Trabalho = value;
            }
        }

        public DateTime Hora_Inicial {
            get {
                DateTime dt;
                if (_hora_Inicial == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _hora_Inicial; }
                return dt;
            }

            set {
                _hora_Inicial = value;
            }
        }

        public DateTime Hora_Final {
            get {
                DateTime dt;
                if (_hora_Final == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _hora_Final; }
                return dt;
            }

            set {
                _hora_Final = value;
            }
        }

        public double Tempo_Trabalho_Segundos {
            get {
                return _tempo_Trabalho_Segundos;
            }

            set {
                _tempo_Trabalho_Segundos = value;
            }
        }

        public bool Sla_cumprido {
            get {
                return _sla_cumprido;
            }

            set {
                _sla_cumprido = value;
            }
        }

        public bool Gerado_fup {
            get {
                return _gerado_fup;
            }

            set {
                _gerado_fup = value;
            }
        }

        public int Id_Historico {
            get {
                return _id_Historico;
            }

            set {
                _id_Historico = value;
            }
        }

        public DateTime Data_Abertura {
            get {
                DateTime dt;
                if (_data_Abertura == null) { dt = DateTime.Parse("1900-01-01 00:00:00"); } else { dt = _data_Abertura; }
                return dt;
            }

            set {
                _data_Abertura = value;
            }
        }

        public string Id_Abertura {
            get {
                return objCon.retornaVazioParaValorNulo(_id_Abertura).ToString().Replace("  ", " ").Trim();
            }

            set {
                _id_Abertura = value;
            }
        }

        public string Observacao {
            get {
                return objCon.retornaVazioParaValorNulo(_observacao).ToString().Replace("  ", " ").Trim();
            }

            set {
                _observacao = value;
            }
        }

        public double Valor_Envolvido {
            get {
                return _valor_Envolvido;
            }

            set {
                _valor_Envolvido = value;
            }
        }

        public int Sla_meta {
            get {
                return _sla_meta;
            }

            set {
                _sla_meta = value;
            }
        }

        #endregion

        #endregion

        #region Contrutores        

        public categorizacoes() { }
        /// <summary>
        /// Utilizado para finalizar registro a registro
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="dth_inicial"></param>
        /// <param name="_finalizacao_id"></param>
        /// <param name="_subFinalizacao_id"></param>
        /// <param name="_valorEnvolvido"></param>
        /// <param name="_observacao"></param>
        public categorizacoes(int _id, int _finalizacao_id = 0, int _subFinalizacao_id = 0, double _valorEnvolvido = 0, string _observacao = "")
        {
            //DateTime dth_inicial, int _fila_id
            categorizacoes cat = new categorizacoes();
            cat = _capturarRegistroPorID(_id);

            Id = _id;
            Status_id = 3;
            IdCat = Constantes.id_BD_logadoFerramenta;
            Fila_id = cat.Fila_id;
            Finalizacao_id = _finalizacao_id;
            SubFinalizacao_id = _subFinalizacao_id;
            Observacao = _observacao;
            Valor_Envolvido = _valorEnvolvido;
            //Datas
            DateTime dth_final = hlp.dataHoraAtual();
            TimeSpan tempoTrabalho = hlp.dataHoraAtual() - cat.Hora_Inicial;
            Data_Trabalho = hlp.dataAbreviada();
            Hora_Inicial = cat.Hora_Inicial;
            Hora_Final = dth_final;
            Tempo_Trabalho_Segundos = tempoTrabalho.TotalSeconds;
            //Validação de cumprimento de SLA
            TimeSpan diasSla = hlp.dataHoraAtual() - cat.Data_Abertura;
            filas fl = new filas();
            fl = fl.capturarFilaPorID(cat.Fila_id);
            Sla_meta = fl.Sla;
            if (diasSla.TotalDays > fl.Sla)
            {
                Sla_cumprido = false;
            }
            else
            {
                Sla_cumprido = true;
            }

        }

        /// <summary>
        /// Utilizado para pesquisas e finalização em massa
        /// </summary>
        /// <param name="_Fila_id"></param>
        /// <param name="_dth_abertura"></param>
        /// <param name="_id_abertura"></param>
        /// <param name="_finalizacao_id"></param>
        /// <param name="_subFinalizacao_id"></param>
        /// <param name="_observacao"></param>
        public categorizacoes(int _Fila_id, DateTime _dth_abertura, string _id_abertura, int _finalizacao_id = 0, int _subFinalizacao_id = 0, string _observacao = "")
        {
            Fila_id = _Fila_id;
            Data_Abertura = _dth_abertura;
            Id_Abertura = _id_abertura;
            Finalizacao_id = _finalizacao_id;
            SubFinalizacao_id = _subFinalizacao_id;
            Observacao = _observacao;
        }
        #endregion

        #region Camada DAL - Dados
        private categorizacoes _capturarRegistroPorID(int _id)
        {
            try
            {
                DataTable dt = new DataTable();
                categorizacoes registro = new categorizacoes();
                sql = "Select * from w_base where id = " + objCon.valorSql(_id) + " ";
                dt = objCon.retornaDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow ln in dt.Rows)
                    {
                        registro.Id = int.Parse(ln["Id"].ToString());
                        registro.Bin = ln["Bin"].ToString();
                        registro.Cpf = ln["Cpf"].ToString();
                        registro.Data_Registro = DateTime.Parse(ln["Data_Registro"].ToString());
                        registro.Fila_id = int.Parse(ln["Fila_id"].ToString());
                        registro.Status_id = int.Parse(ln["Status_id"].ToString());
                        registro.IdCat = int.Parse(ln["IdCat"].ToString());
                        registro.Finalizacao_id = int.Parse(ln["Finalizacao_id"].ToString());
                        registro.SubFinalizacao_id = int.Parse(ln["SubFinalizacao_id"].ToString());
                        registro.Observacao = ln["Observacao"].ToString();
                        registro.Data_Trabalho = DateTime.Parse(ln["Data_Trabalho"].ToString());
                        registro.Hora_Inicial = DateTime.Parse(ln["Hora_Inicial"].ToString());
                        registro.Hora_Final = DateTime.Parse(ln["Hora_Final"].ToString());
                        registro.Tempo_Trabalho_Segundos = double.Parse(ln["Tempo_Trabalho_Segundos"].ToString());
                        registro.Valor_Envolvido = double.Parse(ln["Valor_Envolvido"].ToString());
                        registro.Sla_cumprido = bool.Parse(ln["Sla_cumprido"].ToString());
                        registro.Sla_meta = int.Parse(ln["Sla_meta"].ToString());
                        registro.Gerado_fup = bool.Parse(ln["Gerado_fup"].ToString());
                        registro.Id_Historico = int.Parse(ln["Id_Historico"].ToString());
                        registro.Data_Abertura = DateTime.Parse(ln["Data_Abertura"].ToString());
                        registro.Id_Abertura = ln["Id_Abertura"].ToString();
                    }
                }
                return registro;
            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "CATEGORIZACOES - CAPTURAR REGISTRO POR ID (DAL)");
                return null;
            }
        }

        private bool _finalizarRegistro(categorizacoes obj, ref long volFinalizado)
        {
            try
            {
                //Validando se a finalização ou sub possui FUP
                //Validar do detalhe (subfinalização) para o macro (finalização)
                subFinalizacoes subs = new subFinalizacoes();
                subs = subs.validarFups(obj.SubFinalizacao_id);
                finalizacoes fin = new finalizacoes();
                fin = fin.validarFups(obj.Finalizacao_id);
                bool fups = false;
                if (subs != null || fin != null) { fups = true; } else { fups = false; }

                // Registrando finalização
                sql = "Update w_base set ";
                sql += "status_id = " + objCon.valorSql(obj.Status_id) + ", ";
                sql += "idCat = " + objCon.valorSql(obj.IdCat) + ", ";
                sql += "finalizacao_id = " + objCon.valorSql(obj.Finalizacao_id) + ", ";
                sql += "subFinalizacao_id = " + objCon.valorSql(obj.SubFinalizacao_id) + ", ";
                sql += "observacao = '" + obj.Observacao + "', ";
                sql += "data_Trabalho = " + objCon.valorSql(obj.Data_Trabalho) + ", ";
                sql += "hora_Inicial = " + objCon.valorSql(obj.Hora_Inicial) + ", ";
                sql += "hora_Final = " + objCon.valorSql(obj.Hora_Final) + ", ";
                sql += "tempo_Trabalho_Segundos = " + objCon.valorSql(obj.Tempo_Trabalho_Segundos) + ", ";
                sql += "sla_cumprido = " + objCon.valorSql(obj.Sla_cumprido) + ", ";
                sql += "Sla_meta = " + objCon.valorSql(obj.Sla_meta) + ", ";
                sql += "gerado_fup = " + objCon.valorSql(fups) + " ";
                sql += "Where id = " + objCon.valorSql(obj.Id) + " ";
                validacao = objCon.executaQuery(sql, ref volFinalizado);


                //Criar fups caso a finalização ou subfinalização solicite
                if (fups && validacao)
                {

                    categorizacoes objFup = new categorizacoes();
                    objFup = _capturarRegistroPorID(obj.Id);

                    int fila_id_roteamento = 0;
                    int diasFup = 0;

                    if (subs != null)
                    {
                        fila_id_roteamento = subs.FilaNovoCaso;
                        diasFup = subs.AgingNovoCaso;
                    }
                    else
                    {
                        fila_id_roteamento = fin.FilaNovoCaso;
                        diasFup = fin.AgingNovoCaso;
                    }


                    //Carregando obj
                    importacoes imp = new importacoes(
                        objFup.Bin,
                        objFup.Cpf,
                        objFup.Data_Registro,
                        fila_id_roteamento,
                        hlp.dataHoraAtual().AddDays(diasFup), //Adicionando dias para o fup, conforme configurado pelos administradores do sistema
                        objFup.Id); //Alimentando o id histórico

                    //inserindo o fup
                    imp.inserirFup(imp);

                }

                //retorno 
                if (validacao) { return true; } else { return false; }

            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "CATEGORIZACOES - FINALIZACAO DE REGISTRO (DAL)");
                return false;
            }
        }

        private bool _finalizarBaseMassa(categorizacoes obj, ref long volFinalizado)
        {

            try
            {
                //Validando se a finalização ou sub possui FUP
                //Validar do detalhe (subfinalização) para o macro (finalização)
                subFinalizacoes subs = new subFinalizacoes();
                subs = subs.validarFups(obj.SubFinalizacao_id);
                finalizacoes fin = new finalizacoes();
                fin = fin.validarFups(obj.Finalizacao_id);
                bool fups = false;
                if (subs != null || fin != null) { fups = true; } else { fups = false; }

                // Registrando finalização
                sql = "Update w_base set ";
                sql += "status_id = 3, ";
                sql += "idCat = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + ", ";
                sql += "finalizacao_id = " + objCon.valorSql(obj.Finalizacao_id) + ", ";
                sql += "subFinalizacao_id = " + objCon.valorSql(obj.SubFinalizacao_id) + ", ";
                sql += "observacao = " + objCon.valorSql(obj.Observacao) + ", ";
                sql += "data_Trabalho = " + objCon.valorSql(hlp.dataAbreviada()) + ", ";
                sql += "hora_Inicial = " + objCon.valorSql(hlp.dataHoraAtual()) + ", ";
                sql += "hora_Final = " + objCon.valorSql(hlp.dataHoraAtual()) + ", ";
                sql += "tempo_Trabalho_Segundos = " + objCon.valorSql(0) + ", ";
                sql += "sla_cumprido = " + objCon.valorSql(true) + ", ";
                sql += "gerado_fup = " + objCon.valorSql(fups) + " ";
                sql += "Where id_abertura = " + objCon.valorSql(obj.Id_Abertura) + " ";
                sql += "and data_abertura = " + objCon.valorSql(obj.Data_Abertura) + " ";
                sql += "and fila_id = " + objCon.valorSql(obj.Fila_id) + " ";
                sql += "and status_id in (0) "; //Status: 0 aguardando, 1 trabalhando, 2 finalziado
                validacao = objCon.executaQuery(sql, ref volFinalizado);

                //Criar fups caso a finalização ou subfinalização solicite
                if (fups)
                {

                    int fila_id_roteamento = 0;
                    int diasFup = 0;

                    if (subs != null)
                    {
                        fila_id_roteamento = subs.FilaNovoCaso;
                        diasFup = subs.AgingNovoCaso;
                    }
                    else
                    {
                        fila_id_roteamento = fin.FilaNovoCaso;
                        diasFup = fin.AgingNovoCaso;
                    }

                    //Looping com todos os registros para roteaá-los
                    sql = "Select * from w_base ";
                    sql += "Where id_abertura = " + objCon.valorSql(obj.Id_Abertura) + " ";
                    sql += "and data_abertura = " + objCon.valorSql(obj.Data_Abertura) + " ";
                    sql += "and fila_id = " + objCon.valorSql(obj.Fila_id) + " ";
                    sql += "and finalizacao_id = " + objCon.valorSql(obj.Finalizacao_id) + " ";
                    sql += "and subFinalizacao_id = " + objCon.valorSql(obj.SubFinalizacao_id) + " ";
                    sql += "and idCat = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + " ";
                    sql += "and status_id in (3) "; //Status: 0 aguardando, 1 trabalhando, 2 finalziado
                    DataTable dt = new DataTable();
                    dt = objCon.retornaDataTable(sql);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow ln in dt.Rows)
                        {
                            //Carregando obj
                            importacoes imp = new importacoes(
                                ln["Bin"].ToString(),
                                ln["Cpf"].ToString(),
                                DateTime.Parse(ln["data_Registro"].ToString()),
                                fila_id_roteamento,
                                hlp.dataHoraAtual().AddDays(diasFup), //Adicionando dias para o fup, conforme configurado pelos administradores do sistema
                                int.Parse(ln["id"].ToString())); //Alimentando o id histórico

                            //inserindo o fup
                            imp.inserirFup(imp);
                        }
                    }
                }

                return validacao;

            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "CATEGORIZACOES - FINALIZACAO EM MASSA (DAL)");
                return false;
            }
        }

        /// <summary>
        /// A função deste método é garantir que se por algum motivo a aplicação foi fechada e um registro ficou "preso" para um usuário.
        /// O usuário possa receber um alerta para finalizar a registro já iniciado.
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        private bool _validacaoRegistroLocado(ref categorizacoes registro)
        {
            try
            {
                DataTable dt = new DataTable();
                categorizacoes reg = new categorizacoes();

                sql = "Select top 1 id from w_base where idCat = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + " ";
                sql += "and status_id <> 3 ";
                sql += "order by id";
                dt = objCon.retornaDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow ln in dt.Rows)
                    {
                        reg = _capturarRegistroPorID(int.Parse(ln["id"].ToString()));
                    }
                }
                //retorno
                registro = reg;
                if (registro.Id == 0) { return false; } else { return true; }

            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "CATEGORIZACOES - VALIDACAO REGISTROS LOCADOS (DAL)");
                return false;
            }
        }

        /// <summary>
        /// Função criada após divisão de volume por operador
        /// Objetivo de transformar os FUPs em pessoais, visto que é um volume não controlado pela importação
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        private bool _validacaoFollowUp(ref categorizacoes registro)
        {
            try
            {
                DataTable dt = new DataTable();
                categorizacoes reg = new categorizacoes();

                sql = "Select top 1 id from w_base where id_Abertura = " + objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + " ";
                sql += "and status_id <> 3 ";
                sql += "and format(data_Abertura,'yyyy-MM-dd HH:mm:ss') >= " + objCon.valorSql(hlp.dataAbreviada()) + " ";
                sql += "and id_historico > 0 ";
                sql += "order by id";
                dt = objCon.retornaDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow ln in dt.Rows)
                    {
                        reg = _capturarRegistroPorID(int.Parse(ln["id"].ToString()));
                    }
                }
                //retorno
                registro = reg;
                if (registro.Id == 0) { return false; } else { return true; }

            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "CATEGORIZACOES - VALIDACAO FOLLOW UPS (DAL)");
                return false;
            }
        }

        /// <summary>
        /// Se bloqueia o registro para que não gere competição de trabalho entre dois ou mais usuários trabalhando simultaneamente
        /// qdo não se informa o id é pq deverá capturar o primeiro registro pela ordem natural da fila de trabalho
        /// </summary>
        /// <param name="fila_id"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool _bloquearRegistro(int fila_id, ref categorizacoes registro, int id = 0)
        {
            try
            {
                if (id > 0)
                {


                    //bloqueando registro específico
                    sql = "Update w_base set ";
                    sql += "status_id = 1, ";
                    sql += "idCat =  " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + ", ";
                    sql += "horaInicial =  " + objCon.valorSql(hlp.dataHoraAtual()) + " ";
                    sql += "where 1 = 1 ";
                    sql += "and status_id = 0 ";
                    sql += "and id = " + objCon.valorSql(id) + " ";
                    validacao = objCon.executaQuery(sql, ref retorno);

                    if (retorno > 0)
                    {
                        registro = _capturarRegistroPorID(id);
                    }
                    else
                    {
                        registro = null;
                    }


                }
                else
                {

                    //percorrendo uma lista de registros para conseguir bloquear 1 para trabalho
                    DataTable dt = new DataTable();
                    int id_bloqueado;
                     

                    sql = "Select * from w_base where fila_id = " + objCon.valorSql(fila_id) + " and status_id = 0";
                    dt = objCon.retornaDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow ln in dt.Rows)
                        {


                            //Usando o ID atual para bloquear o registro para trabalho
                            id_bloqueado = int.Parse(ln["id"].ToString());
                            sql = "Update w_base set ";
                            sql += "status_id = 1, ";
                            sql += "idCat =  " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + ", ";
                            sql += "hora_Inicial =  " + objCon.valorSql(hlp.dataHoraAtual()) + " ";
                            sql += "where 1 = 1 ";
                            sql += "and status_id = 0 ";
                            sql += "and id = " + objCon.valorSql(id_bloqueado) + " ";                            
                            validacao = objCon.executaQuery(sql, ref retorno);

                            //se o bloqueio do registro foi possível, validar se a qtde de registros trabalhado pelo analista já atingiu a proporção distribuiada para o mesmo
                            //caso não tenha atingido, retornar com o registro
                            //caso tenha atingido, testar outros registros, pois pode haver uma outra importação, na qual o analista tenha cota de registros para trabalhar
                            if (retorno > 0)
                            {
                                
                                registro = _capturarRegistroPorID(id_bloqueado);

                                if (registro != null) {

                                    //verificando se existe volume disponível para trabalhar
                                    sql = "Select z.id,z.data_Hora,z.fila_id,z.qtde_registros,z.id_usuario, iif(z.vol_trabalhado is null,0,z.vol_trabalhado) as VolTrab from ( ";
                                    sql += "select * from w_sysUsuariosVolParaTrabalho vt left join ";
                                    sql += "(Select fila_id as fila, idCat, count(status_id) as vol_trabalhado, data_Abertura from w_base ";
                                    sql += "where status_id = 3 and data_Abertura = " + objCon.valorSql(registro.Data_Abertura) + " and idCat = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + " ";
                                    sql += "group by fila_id, idCat, data_Abertura) b ";
                                    sql += "on vt.data_Hora = b.data_Abertura and vt.fila_id = b.fila ) as z ";
                                    sql += "where z.id_usuario = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + " ";
                                    sql += "and fila_id = " + objCon.valorSql(registro.Fila_id) + " ";
                                    sql += "and data_Hora = " + objCon.valorSql(registro.Data_Abertura) + " ";
                                    DataTable dt_loc = new DataTable();
                                    dt_loc = objCon.retornaDataTable(sql);
                                    if (dt_loc.Rows.Count > 0) {
                                        foreach (DataRow item in dt_loc.Rows) {
                                            if (int.Parse(item["qtde_registros"].ToString()) == int.Parse(item["VolTrab"].ToString())) {

                                                //Liberar o registro para outro analista
                                                liberarRegistro(registro.Id);
                                                registro = null;
                                                
                                            } else {
                                                //Retorno com registro locado
                                                return true;
                                            }

                                        }
                                    } else {
                                        //Liberar o registro para outro analista
                                        liberarRegistro(registro.Id);
                                        registro = null;                                        
                                    }

                                }
                            }

                        }

                    }
                    else
                    {
                        id_bloqueado = 0;
                        registro = null;
                        return false;
                    }
                }

                //retorno
                if (registro == null) { return false; }
                else
                {

                    //verificando se existe volume disponível para trabalhar
                    sql = "Select z.id,z.data_Hora,z.fila_id,z.qtde_registros,z.id_usuario, iif(z.vol_trabalhado is null,0,z.vol_trabalhado) as VolTrab from ( ";
                    sql += "select * from w_sysUsuariosVolParaTrabalho vt left join ";
                    sql += "(Select fila_id as fila, idCat, count(status_id) as vol_trabalhado, data_Abertura from w_base ";
                    sql += "where status_id = 3 and data_Abertura = " + objCon.valorSql(registro.Data_Abertura) + " and idCat = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + " ";
                    sql += "group by fila_id, idCat, data_Abertura) b ";
                    sql += "on vt.data_Hora = b.data_Abertura and vt.fila_id = b.fila ) as z ";
                    sql += "where z.id_usuario = " + objCon.valorSql(Constantes.id_BD_logadoFerramenta) + " ";
                    sql += "and fila_id = " + objCon.valorSql(registro.Fila_id) + " ";
                    sql += "and data_Hora = " + objCon.valorSql(registro.Data_Abertura) + " ";
                    DataTable dt = new DataTable();
                    dt = objCon.retornaDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            if (int.Parse(item["qtde_registros"].ToString()) == int.Parse(item["VolTrab"].ToString()))
                            {

                                //Liberar o registro para outro analista
                                liberarRegistro(registro.Id);
                                registro = null;
                                return false;

                            }
                            else
                            {
                                return true;
                            }

                        }
                    }
                    else
                    {
                        //Liberar o registro para outro analista
                        liberarRegistro(registro.Id);
                        registro = null;
                        return false;
                    }

                }

                return false;

            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "CATEGORIZACOES - BLOQUEAR REGISTROS(DAL)");
                return false;
            }
        }
        /// <summary>
        /// Utlizado para retornar um registro para a fila de trabalho
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool _liberarRegistro(int id)
        {
            try
            {
                sql = "Update w_base set ";
                sql += "status_id = 0, ";
                sql += "idCat = 0, ";
                sql += "hora_Inicial = '1900-01-01 00:00:00' ";
                sql += "where 1 = 1 ";
                sql += "and status_id = 1 ";
                sql += "and id = " + objCon.valorSql(id) + " ";
                validacao = objCon.executaQuery(sql, ref retorno);
                if (retorno > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "CATEGORIZACOES - LIBERAR REGISTROS(DAL)");
                return false;
            }
        }
        #endregion

        #region Camada BLL - Negócio

        public bool finalizarRegistro(categorizacoes obj)
        {
            try
            {
                bool validacao = false;
                long volFinalizado = 0;
                validacao = _finalizarRegistro(obj, ref volFinalizado);

                //Mensagem final sobre a finalização..
                if (validacao)
                {
                    MessageBox.Show("Registro finalizado com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Registro finalizado com falha!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "CATEGORIZACAO INDIVIDUAL (fila_id " + obj.Fila_id + ") - FINALIZAR NA BASE (BLL)");
                return false;
            }
        }

        public bool finalizarMassa(categorizacoes obj, int id_logImp)
        {

            try
            {
                //Variáveis de controles e de logs
                bool validacao = false;
                filas fila = new filas();
                fila = fila.capturarFilaPorID(obj.Fila_id);
                string fila_nome = fila.Descricao.ToString();
                long volFinalizado = 0;

                //Finalizar
                validacao = _finalizarBaseMassa(obj, ref volFinalizado);

                //Registrar loGs de finalização em massa                
                logsImportacoes logImp = new logsImportacoes("FINALIZACAO (ID = " + id_logImp + ")", hlp.dataHoraAtual(), obj.Fila_id, fila_nome.ToString(), volFinalizado);
                logImp.incluir(logImp);

                //Mensagem final sobre a finalização em massa..
                if (validacao)
                {
                    MessageBox.Show("Registros finalizados com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Registros finalizados com falha!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "CATEGORIZACAO EM MASSA (fila_id " + obj.Fila_id + ") - FINALIZAR NA BASE(BLL)");
                return false;
            }
        }

        public bool bloquearRegistro(int fila_id, ref categorizacoes registro, int id = 0)
        {
            try
            {
                bool validacao = false;
                //Verificando se existe registro locado (preso) no id do solicitante..
                //Se o usuário deseja continuar a análise neste momento
                //disponibilizar para trabalho
                validacao = _validacaoRegistroLocado(ref registro);
                if (validacao)
                {
                    DialogResult msg = MessageBox.Show("Existe um registro aguardando sua finalização desde: " + Environment.NewLine +
                                                         registro.Hora_Inicial.ToString() + Environment.NewLine + Environment.NewLine +
                                                         "Deseja finalizar agora?", Constantes.Titulo_MSG, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        validacao = false;
                        registro = null;
                    }
                }


                //verificando se exite FUP criado pelo usuário
                //Se o usuário deseja continuar a análise neste momento
                //disponibilizar para trabalho
                validacao = _validacaoFollowUp(ref registro);
                if (validacao)
                {
                    DialogResult msg = MessageBox.Show("Existe Follow Up aguardando sua finalização desde: " + Environment.NewLine +
                                                         DateTime.Parse(registro.Data_Abertura.ToString()).ToShortDateString() + Environment.NewLine + Environment.NewLine +
                                                         "Deseja finalizar agora?", Constantes.Titulo_MSG, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        validacao = false;
                        registro = null;
                    }
                }



                //Buscando um novo registro da fila de trabalho
                validacao = _bloquearRegistro(fila_id, ref registro, id);
                if (!validacao)
                {
                    MessageBox.Show("Não foi possível selecionar nenhum registro para trabalho, possível motivo: " + Environment.NewLine +
                                        " - Não há mais registros disponíveis para a fila selecionada ou você atingiu sua cota para esta fila. Parabéns!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                return validacao;
            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "CATEGORIZACOES - BLOQUEAR REGISTROS(BLL)");
                return false;
            }
        }

        public bool liberarRegistro(int id)
        {
            try
            {
                return _liberarRegistro(id);
            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "CATEGORIZACOES - LIBERAR REGISTROS(BLL)");
                return false;
            }
        }

        public void carregarComboboxFilasComVolumeParaTrabalho(Form frm, ComboBox cbx)
        {
            try
            {
                DataTable dt = new DataTable();
                sql = "select f.id, f.descricao ";
                sql += "from w_base b inner join w_sysfilas f on b.fila_id = f.id ";
                sql += "where b.status_id = 0 ";
                sql += "group by f.id, f.descricao ";
                dt = objCon.retornaDataTable(sql);
                hlp.carregaComboBox(dt, frm, cbx, false, "", "", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi carregar a lista de filas para trabalho, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "CATEGORIZACOES - CARREGAR COMBOBOX FILAS P/ TRABALHO (BLL)");
            }
        }

        #endregion

    }
}
