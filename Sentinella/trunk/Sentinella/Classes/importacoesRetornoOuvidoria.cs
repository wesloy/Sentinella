﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella
{

    //	CREATE TABLE [dbo].[w_baseRetornoOuvidoria] (
    //	    [id]                      INT            IDENTITY (1, 1) NOT NULL,
    //	    [id_base_principal]       INT            DEFAULT ((0)) NOT NULL,
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

    //Tabela recebe os casos que geraram Laudos
    //Para alimentação (importações) será usado apenas os campos: BIN, CPF, FILA_ID, DATA_ABERTURA, ID_ABERTURA, ID_BASE_PRINCIPAL

    class importacoesRetornoOuvidoria
    {

        #region Variaveis 
        bool validacao = false;
        string sql = "";
        long retorno = 0;
        Uteis.Conexao objCon = new Uteis.Conexao(Uteis.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Uteis.Helpers hlp = new Uteis.Helpers();
        logs log = new logs();
        int volTotal = 0;
        #endregion

        #region Camada DTO - Entidades

        int _id_base_principal { get; set; }
        string _bin { get; set; }
        string _cpf { get; set; }
        int _fila_id { get; set; }
        DateTime _data_registro { get; set; }
        DateTime _data_abertura { get; set; }
        string _id_abertura { get; set; }


        #endregion

        #region Construtores
        public importacoesRetornoOuvidoria() { }

        public importacoesRetornoOuvidoria(int id_base_principal, string bin, string cpf, DateTime dth_registro, int fila_id, DateTime dth_abertura)
        {
            _id_base_principal = id_base_principal;
            _bin = bin;
            _cpf = cpf;
            _data_registro = dth_registro;
            _fila_id = fila_id;
            _data_abertura = dth_abertura;
            _id_abertura = Constantes.id_REDE_logadoFerramenta;

        }
        #endregion

        #region Camada DAL - Acesso aos Dados

        /// <summary>
        /// Método genérico para validar se o registro já foi importado
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="validarDataRegistro"></param>
        /// <returns></returns>
        private bool _valorDuplicado(importacoesRetornoOuvidoria obj, bool validarDataRegistro = false, bool validarStausAberto = false)
        {
            try
            {
                sql = "Select * from w_baseRetornoOuvidoria ";
                sql += "where bin = " + objCon.valorSql(obj._bin) + " ";
                sql += "and cpf = " + objCon.valorSql(obj._cpf) + " ";
                sql += "and Fila_id = " + objCon.valorSql(obj._fila_id) + " ";
                if (validarStausAberto)
                {
                    sql += "and status_id = 0 ";
                }
                sql += "order by data_Registro desc ";

                if (validarDataRegistro)
                {
                    //se o registro que já está no sentinella for >= não necessita subir o registro atual, pois trata-se de um registro antigo
                    DataTable tb = new DataTable();
                    bool validacao = false;
                    tb = objCon.retornaDataTable(sql);
                    if (tb.Rows.Count > 0)
                    {
                        foreach (DataRow ln in tb.Rows)
                        {
                            if (DateTime.Parse(ln["data_Registro"].ToString()) >= obj._data_registro)
                            {
                                validacao = true;
                                break;
                            }
                        }
                    }
                    else { validacao = false; }
                    return validacao;
                }
                else
                {//Validação direta pelo sql, já que não é necessário validar data do registro. Assim sendo, havendo retoro > 0 já caracteriza duplicidade.
                    objCon.executaQuery(sql, ref retorno);
                    if (retorno > 0) { return true; } else { return false; }
                }
            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "IMPORTACAO RETORNO OUVIDORIA - VALIDAR DUPLICADO");
                return false;
            }
        }

        /// <summary>
        /// Captura todos os casos de retorno
        /// Validando duplicidade de casos já disponibilizados para trabalho
        /// </summary>
        /// <returns></returns>
        private bool _filaRetornoOuvidoria(DateTime dtHora, int fila_id, string fila_nome, ref long volImportado)
        {
            try
            {

                DataTable dt = new DataTable();

                sql = "select b.* from w_base b inner ";
                sql += "join w_sysFinalizacoes f on b.finalizacao_id = f.id left join w_baseRetornoOuvidoria o on b.id = o.id_base_principal ";
                sql += "where f.descricao like 'NAO CONFORME' and o.id is null "; //eliminando duplicidade pelo id
                sql += "order by b.cpf asc";
                dt = objCon.retornaDataTable(sql);

                //Importando registros caso tenha algum volume para isso (DT.ROWS.COUNT > 0)
                frmProgressBar frm = new frmProgressBar(dt.Rows.Count);
                frm.Show();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow ln in dt.Rows)
                    {
                        importacoesRetornoOuvidoria imp = new importacoesRetornoOuvidoria(
                            int.Parse(ln["id"].ToString()),
                            ln["bin"].ToString(),
                            ln["cpf"].ToString(),
                            DateTime.Parse(ln["data_registro"].ToString()),
                            fila_id,
                            dtHora);

                        _insertBase(imp);
                        volImportado += 1;

                        ////Valdação de duplicado já realizada na qry de captura
                        //if (!_valorDuplicado(imp, true, false))
                        //{ //validação de status não é preciso, pq depende da data de corte, ciclos diferentes sobe para trabalho
                        //    _insertBase(imp);
                        //    volImportado += 1;
                        //}
                    }
                    volTotal += 1;
                    frm.atualizarBarra(volTotal);
                }

                frm.Close();
                return true;

            }
            catch (Exception ex)
            {
                
                log.registrarLog(ex.ToString(), "IMPORTACAO RETORNO OUVIDORIA - OUVIDORIA (DAL)");
                return false;
            }
        }


        /// <summary>
        /// Métedo para inserção na base, independente da fila a ser populada
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool _insertBase(importacoesRetornoOuvidoria obj)
        {
            try
            {
                sql = "Insert into w_baseRetornoOuvidoria (";
                sql += "id_base_principal, bin, cpf, data_registro, fila_id, data_abertura, id_abertura ";
                sql += ") values (";
                sql += objCon.valorSql(obj._id_base_principal) + ", ";
                sql += objCon.valorSql(obj._bin) + ", ";
                sql += objCon.valorSql(obj._cpf) + ",";
                sql += objCon.valorSql(obj._data_registro) + ",";
                sql += objCon.valorSql(obj._fila_id) + ", ";
                sql += objCon.valorSql(obj._data_abertura) + ", ";
                sql += objCon.valorSql(obj._id_abertura) + ") ";
                validacao = objCon.executaQuery(sql, ref retorno); //executando
                return validacao;
            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "IMPORTACAO RETORNO OUVIDORIA (fila_id " + _fila_id + ") - INSERIR NA BASE(DAL)");
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
        private bool _excluirBase(importacoesRetornoOuvidoria obj, ref long volExcluido)
        {
            try
            {

                sql = "Delete from w_baseRetornoOuvidoria ";
                sql += "Where id_abertura = " + objCon.valorSql(obj._id_abertura) + " ";
                sql += "and data_abertura = " + objCon.valorSql(obj._data_abertura) + " ";
                sql += "and fila_id = " + objCon.valorSql(obj._fila_id) + " ";
                sql += "and status_id in (0) "; //Status: 0 aguardando, 1 trabalhando, 2 finalziado
                return objCon.executaQuery(sql, ref volExcluido);


            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "IMPORTACAO RETORNO OUVIDORIA - DELETAR DA BASE(DAL)");
                return false;
            }
        }


        #endregion

        #region Camada BLL - Regras de Negócio

        public bool incluir(int fila_id)
        {
            try
            {

                //Variáveis de controles e de logs
                bool validacaoImportacao = false;
                DateTime dtHora = hlp.dataHoraAtual();
                filas fila = new filas();
                fila = fila.capturarFilaPorID(fila_id);
                string fila_nome = fila.Descricao.ToString();
                long volImportado = 0;

                //Lista de importações
                switch (fila_id)
                {
                    case 5:
                        validacaoImportacao = _filaRetornoOuvidoria(dtHora, fila_id, fila_nome, ref volImportado);
                        break;
                }

                //Registrar loGs de importações
                logsImportacoes logImp = new logsImportacoes("IMPORTACAO RETORNO OUVIDORIA", dtHora, fila_id, fila_nome.ToString(), volImportado);
                logImp.incluir(logImp);

                //Mensagem final sobre a importação..
                if (validacaoImportacao)
                {
                    MessageBox.Show("Importação concluída com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Importação concluída com falha!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "IMPORTACAO RETORNO OUVIDORIA (fila_id " + fila_id + ") - INSERIR NA BASE(BLL)");
                return false;
            }
        }

        public bool excluir(importacoesRetornoOuvidoria obj, int id_logImp)
        {
            try
            {

                //Variáveis de controles e de logs
                bool validacaoImportacao = false;
                filas fila = new filas();
                fila = fila.capturarFilaPorID(obj._fila_id);
                string fila_nome = fila.Descricao.ToString();
                long volExcluido = 0;

                //Deletar
                validacaoImportacao = _excluirBase(obj, ref volExcluido);

                //Registrar loGs de DELEÇÃO                
                logsImportacoes logImp = new logsImportacoes("DELECAO (ID = " + id_logImp + ")", hlp.dataHoraAtual(), obj._fila_id, fila_nome.ToString(), volExcluido);
                logImp.incluir(logImp);

                //Mensagem final sobre a importação..
                if (validacaoImportacao)
                {
                    MessageBox.Show("Exclusão concluída com sucesso!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Exclusão concluída com falha!", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "IMPORTACAO RETORNO OUVIDORIA (fila_id " + obj._fila_id + ") - DELETAR DA BASE(BLL)");
                return false;
            }
        }

        #endregion
    }
}
