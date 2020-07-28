﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella
{
    class retornoOuvidoria
    {
        //	CREATE TABLE [dbo].[w_baseRetornoOuvidoria] (
        //	    [id]                      INT            IDENTITY (1, 1) NOT NULL,
        //	    [id_base_principal]       INT            NULL,
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
        //	    CONSTRAINT [PK_w_baseRetornoOuvidoria] PRIMARY KEY CLUSTERED ([id] ASC)
        //	);

        #region Variaveis 
        bool validacao = false;
        long retorno = 0;
        string sql = "";
        Uteis.Conexao objCon = new Uteis.Conexao(Uteis.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Uteis.Helpers hlp = new Uteis.Helpers();
        logs log = new logs();
        #endregion

        #region Camada DTO - Entidades
        public int _id { get; set; }
        public int _id_base_principal { get; set; }
        public string _bin { get; set; }
        public string _cpf { get; set; }
        public DateTime _data_Registro { get; set; }
        public int _fila_id { get; set; }
        public int _status_id { get; set; }
        public string _idCat { get; set; }
        public int _finalizacao_id { get; set; }
        public int _subFinalizacao_id { get; set; }
        public string _observacao { get; set; }
        public DateTime _data_Trabalho { get; set; }
        public DateTime _hora_Inicial { get; set; }
        public DateTime _hora_Final { get; set; }
        public double _tempo_Trabalho_Segundos { get; set; }
        public double _valor_Envolvido { get; set; }
        public bool _sla_cumprido { get; set; }
        public bool _gerado_fup { get; set; }
        public int _id_Historico { get; set; }
        public DateTime _data_Abertura { get; set; }
        public string _id_Abertura { get; set; }

        #endregion

        #region Construtores
        public retornoOuvidoria() { }

        /// <summary>
        /// Utilizado para finalizar registro a registro
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="dth_inicial"></param>
        /// <param name="_finalizacao_id"></param>
        /// <param name="_subFinalizacao_id"></param>
        /// <param name="_valorEnvolvido"></param>
        /// <param name="_observacao"></param>
        public retornoOuvidoria(int id, int finalizacao_id = 0, int subFinalizacao_id = 0, double valorEnvolvido = 0, string observacao = "")
        {
            //DateTime dth_inicial, int _fila_id
            retornoOuvidoria cat = new retornoOuvidoria();
            cat = _capturarRegistroPorID(id);

            _id = id;
            _status_id = 3;
            _idCat = Constantes.id_REDE_logadoFerramenta;
            _fila_id = cat._fila_id;
            _finalizacao_id = finalizacao_id;
            _subFinalizacao_id = subFinalizacao_id;
            _observacao = observacao;
            _valor_Envolvido = valorEnvolvido;
            //Datas
            DateTime dth_final = hlp.dataHoraAtual();
            TimeSpan tempoTrabalho = hlp.dataHoraAtual() - cat._hora_Inicial;
            _data_Trabalho = hlp.dataAbreviada();
            _hora_Inicial = cat._hora_Inicial;
            _hora_Final = dth_final;
            _tempo_Trabalho_Segundos = tempoTrabalho.TotalSeconds;
            //Validação de cumprimento de SLA
            TimeSpan diasSla = hlp.dataHoraAtual() - cat._data_Abertura;
            filas fl = new filas();
            fl = fl.capturarFilaPorID(_fila_id);
            if (diasSla.TotalDays > fl.Sla)
            {
                _sla_cumprido = false;
            }
            else
            {
                _sla_cumprido = true;
            }

        }
        #endregion

        #region Camada DAL - Dados

        private retornoOuvidoria _capturarRegistroPorID(int _id)
        {
            try
            {
                DataTable dt = new DataTable();
                retornoOuvidoria registro = new retornoOuvidoria();
                sql = "Select * from w_baseRetornoOuvidoria where id = " + objCon.valorSql(_id) + " ";
                dt = objCon.retornaDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow ln in dt.Rows)
                    {
                        registro._id = int.Parse(ln["Id"].ToString());
                        registro._id_base_principal = int.Parse(ln["Id_base_principal"].ToString());
                        registro._bin = ln["Bin"].ToString();
                        registro._cpf = ln["Cpf"].ToString();
                        registro._data_Registro = DateTime.Parse(ln["Data_Registro"].ToString());
                        registro._fila_id = int.Parse(ln["Fila_id"].ToString());
                        registro._status_id = int.Parse(ln["Status_id"].ToString());
                        registro._idCat = ln["IdCat"].ToString();
                        registro._finalizacao_id = int.Parse(ln["Finalizacao_id"].ToString());
                        registro._subFinalizacao_id = int.Parse(ln["SubFinalizacao_id"].ToString());
                        registro._observacao = ln["Observacao"].ToString();
                        registro._data_Trabalho = DateTime.Parse(ln["Data_Trabalho"].ToString());
                        registro._hora_Inicial = DateTime.Parse(ln["Hora_Inicial"].ToString());
                        registro._hora_Final = DateTime.Parse(ln["Hora_Final"].ToString());
                        registro._tempo_Trabalho_Segundos = double.Parse(ln["Tempo_Trabalho_Segundos"].ToString());
                        registro._valor_Envolvido = double.Parse(ln["Valor_Envolvido"].ToString());
                        registro._sla_cumprido = bool.Parse(ln["Sla_cumprido"].ToString());
                        registro._gerado_fup = bool.Parse(ln["Gerado_fup"].ToString());
                        registro._id_Historico = int.Parse(ln["Id_Historico"].ToString());
                        registro._data_Abertura = DateTime.Parse(ln["Data_Abertura"].ToString());
                        registro._id_Abertura = ln["Id_Abertura"].ToString();
                    }
                }
                return registro;
            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "RETORNO OUVIDORIA - CAPTURAR REGISTRO POR ID (DAL)");
                return null;
            }
        }

        /// <summary>
        /// Se bloqueia o registro para que não gere competição de trabalho entre dois ou mais usuários trabalhando simultaneamente
        /// qdo não se informa o id é pq deverá capturar o primeiro registro pela ordem natural da fila de trabalho
        /// </summary>
        /// <param name="fila_id"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool _bloquearRegistro(string valorBusca, string referenciaBusca, ref retornoOuvidoria registro, int id = 0)
        {
            try
            {
                if (id > 0 && referenciaBusca != "FILA")
                {
                    //bloqueando registro específico
                    sql = "Update w_baseRetornoOuvidoria set ";
                    sql += "status_id = 1, ";
                    sql += "idCat =  " + objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + ", ";
                    sql += "hora_Inicial =  " + objCon.valorSql(hlp.dataHoraAtual()) + " ";
                    sql += "where 1 = 1 ";
                    sql += "and status_id = 0 ";
                    sql += "and id_base_principal = " + objCon.valorSql(id) + " ";
                    validacao = objCon.executaQuery(sql, ref retorno);
                    if (retorno > 0)
                    {
                        registro = _capturarRegistroPorID(id);
                        return true;
                    }
                    else
                    {
                        registro = null;
                        return false;
                    }
                }
                else
                {
                    //buscando por valor de busca e referncia
                    //percorrendo uma lista de registros para conseguir bloquear 1 para trabalho
                    DataTable dt = new DataTable();
                    int id_bloqueado;

                    switch (referenciaBusca)
                    {
                        case "CPF":
                            sql = "Select * from w_baseRetornoOuvidoria where cpf = " + objCon.valorSql(valorBusca) + " and status_id = 0 order by data_Abertura desc";
                            break;
                        case "NOME DO ANALISTA":
                            sql = "select * from w_baseRetornoOuvidoria b inner join w_funcionarios f on b.cpf = f.CPF where b.status_id = 0 and f.NOME_ASSOCIADO like '%" + valorBusca + "%'";
                            break;
                        case "FILA":
                            sql = "Select * from w_baseRetornoOuvidoria where fila_id = " + objCon.valorSql(id) + " and status_id = 0";
                            break;
                    }

                    dt = objCon.retornaDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow ln in dt.Rows)
                        {
                            id_bloqueado = int.Parse(ln["id"].ToString());
                            sql = "Update w_baseRetornoOuvidoria set ";
                            sql += "status_id = 1, ";
                            sql += "idCat =  " + objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + ", ";
                            sql += "hora_Inicial =  " + objCon.valorSql(hlp.dataHoraAtual()) + " ";
                            sql += "where 1 = 1 ";
                            sql += "and status_id = 0 ";
                            sql += "and id = " + objCon.valorSql(id_bloqueado) + " ";
                            validacao = objCon.executaQuery(sql, ref retorno);
                            if (retorno > 0)
                            {
                                registro = _capturarRegistroPorID(id_bloqueado);
                                return true;
                            }
                        }
                    }
                    else
                    {
                        id_bloqueado = 0;
                        registro = null;
                    }
                }

                //retorno
                if (registro == null) { return false; } else { return true; }

            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "RETORNO OUVIDORIA - BLOQUEAR REGISTROS(DAL)");
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
                sql = "Update w_baseRetornoOuvidoria set ";
                sql += "status_id = 0, ";
                sql += "idCat = Null, ";
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
                log.registrarLog(ex.ToString(), "RETORNO OUVIDORIA - LIBERAR REGISTROS(DAL)");
                return false;
            }
        }

        private bool _finalizarRegistro(retornoOuvidoria obj, ref long volFinalizado)
        {
            try
            {
                //Validando se a finalização ou sub possui FUP
                //Validar do detalhe (subfinalização) para o macro (finalização)
                subFinalizacoes subs = new subFinalizacoes();
                subs = subs.validarFups(obj._subFinalizacao_id);
                finalizacoes fin = new finalizacoes();
                fin = fin.validarFups(obj._finalizacao_id);
                bool fups = false;
                if (subs != null || fin != null) { fups = true; } else { fups = false; }

                // Registrando finalização
                sql = "Update w_baseRetornoOuvidoria set ";
                sql += "status_id = " + objCon.valorSql(obj._status_id) + ", ";
                sql += "idCat = " + objCon.valorSql(obj._idCat) + ", ";
                sql += "finalizacao_id = " + objCon.valorSql(obj._finalizacao_id) + ", ";
                sql += "subFinalizacao_id = " + objCon.valorSql(obj._subFinalizacao_id) + ", ";
                sql += "observacao = '" + obj._observacao + "', ";
                sql += "data_Trabalho = " + objCon.valorSql(obj._data_Trabalho) + ", ";
                sql += "hora_Inicial = " + objCon.valorSql(obj._hora_Inicial) + ", ";
                sql += "hora_Final = " + objCon.valorSql(obj._hora_Final) + ", ";
                sql += "tempo_Trabalho_Segundos = " + objCon.valorSql(obj._tempo_Trabalho_Segundos) + ", ";
                sql += "sla_cumprido = " + objCon.valorSql(obj._sla_cumprido) + ", ";
                sql += "gerado_fup = " + objCon.valorSql(fups) + " ";
                sql += "Where id = " + objCon.valorSql(obj._id) + " ";
                validacao = objCon.executaQuery(sql, ref volFinalizado);


                //retorno 
                if (validacao) { return true; } else { return false; }

            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "RETORNO OUVIDORIA - FINALIZACAO DE REGISTRO (DAL)");
                return false;
            }
        }

        /// <summary>
        /// A função deste método é garantir que se por algum motivo a aplicação foi fechada e um registro ficou "preso" para um usuário.
        /// O usuário possa receber um alerta para finalizar a registro já iniciado.
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        private bool _validacaoRegistroLocado(ref retornoOuvidoria registro)
        {
            try
            {
                DataTable dt = new DataTable();
                retornoOuvidoria reg = new retornoOuvidoria();

                sql = "Select top 1 id from w_baseRetornoOuvidoria where idCat = " + objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + " ";
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
                if (registro._id == 0) { return false; } else { return true; }

            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "RETORNO OUVIDORIA - VALIDACAO REGISTROS LOCADOS (DAL)");
                return false;
            }
        }

        #endregion

        #region Camada BLL - Negócio
        public bool finalizarRegistro(retornoOuvidoria obj)
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
                log.registrarLog(ex.ToString(), "RETORNO OUVIDORIA (fila_id " + obj._fila_id + ") - FINALIZAR NA BASE (BLL)");
                return false;
            }
        }

        public bool bloquearRegistro(string valorBusca, string referenciaBusca, ref retornoOuvidoria registro, int id = 0)
        {
            try
            {
                bool validacao = false;
                //Verificando se existe registro locado (preso) no id do solicitante..
                //Se o usuário deseja continuar a análise neste momento
                //disponibilizando para trabalho
                validacao = _validacaoRegistroLocado(ref registro);
                if (validacao)
                {
                    DialogResult msg = MessageBox.Show("Existe um registro aguardando sua finalização desde: " + Environment.NewLine +
                                                         registro._hora_Inicial.ToString() + Environment.NewLine + Environment.NewLine +
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
                validacao = _bloquearRegistro(valorBusca, referenciaBusca, ref registro, id);
                if (!validacao)
                {
                    MessageBox.Show("Não foi possível selecionar nenhum registro para trabalho, possível motivo: " + Environment.NewLine +
                                        " - Valor de busca do registro informado não está disponível para trabalho." + Environment.NewLine +
                                        " - A fila não possui mais volume para trabalho.", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                return validacao;
            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "RETORNO OUVIDORIA - BLOQUEAR REGISTROS(BLL)");
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
                log.registrarLog(ex.ToString(), "RETORNO OUVIDORIA - LIBERAR REGISTROS(BLL)");
                return false;
            }
        }

        public void carregarComboboxFilasComVolumeParaTrabalho(Form frm, ComboBox cbx)
        {
            try
            {
                DataTable dt = new DataTable();
                sql = "select f.id, f.descricao ";
                sql += "from w_baseRetornoOuvidoria b inner join w_sysfilas f on b.fila_id = f.id ";
                sql += "where b.status_id = 0 ";
                sql += "group by f.id, f.descricao ";
                dt = objCon.retornaDataTable(sql);
                hlp.carregaComboBox(dt, frm, cbx, false, "", "", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi carregar a lista de filas para trabalho, tente novamente mais tarde!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.registrarLog(ex.ToString(), "RETORNO OUVIDORIA - CARREGAR COMBOBOX FILAS P/ TRABALHO (BLL)");
            }
        }

        #endregion

    }
}
