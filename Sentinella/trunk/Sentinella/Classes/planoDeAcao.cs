﻿using System;
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
        bool validacao = false;
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
            _idAtualizacao = Constantes.idlogadoFerramenta;
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
        private DataTable _listarPlanosAcoesTrabalhados(DateTime _dtInicial, DateTime _dtFinal) {
            try {
                sql = "Select * from w_basePlanoAcao where dataRegistro between  " +
                        objCon.valorSql(_dtInicial) + " and " + objCon.valorSql(_dtFinal) + " ";
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

                string solicitante = "";
                string coordenador = "";
                string gerente = "";
                string diretor = "";
                string observacao = "";
                string idSentinella = "";

                DataTable dt = new DataTable();
                DataTable dt_w = new DataTable();
                dt = _listarPlanosAcoes(_dtInicial, _dtFinal);
                dt_w = _listarPlanosAcoesTrabalhados(_dtInicial, _dtFinal);
                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = false;
                lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("PROTOCOLO", 100, HorizontalAlignment.Left);
                lst.Columns.Add("STATUS DA SOLICITAÇÃO", 140, HorizontalAlignment.Left);
                lst.Columns.Add("SOLICITANTE", 140, HorizontalAlignment.Left);
                lst.Columns.Add("COORDENADOR", 140, HorizontalAlignment.Left);
                lst.Columns.Add("GERENTE", 140, HorizontalAlignment.Left);
                lst.Columns.Add("DIRETOR", 140, HorizontalAlignment.Left);
                lst.Columns.Add("OBSERVAÇÃO", 140, HorizontalAlignment.Left);
                lst.Columns.Add("ETAPA DO FLUXO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("TIPO DOCUMENTO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("TÍTULO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("ORIGEM", 150, HorizontalAlignment.Left);
                lst.Columns.Add("RESPONSÁVEL", 150, HorizontalAlignment.Left);
                lst.Columns.Add("CR", 150, HorizontalAlignment.Left);
                lst.Columns.Add("NORMA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("REQUISITO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("RNC", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DATA INÍCIO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DATA FIM", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DATA DE MEDIÇÃO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DATA RENOGOCIADA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DATA DE CONCLUSÃO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DIAS EM ATRASO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("CATEGORIA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("FALHA_PROCESSO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("FALHA_ASSOCIADO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("INCIDENTE", 150, HorizontalAlignment.Left);
                lst.Columns.Add("CLASSIFICAÇÃO", 150, HorizontalAlignment.Left);
                lst.Columns.Add("PRIORIDADE", 150, HorizontalAlignment.Left);
                lst.Columns.Add("ID_SENTINELLA", 100, HorizontalAlignment.Left);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();

                        DataRow[] w_Plan = dt_w.Select("protocolo = " + int.Parse(linha["PROTOCOLO"].ToString()));

                        if (w_Plan.Length > 0) {
                            solicitante = w_Plan[0][2].ToString();
                            coordenador = w_Plan[0][3].ToString();
                            gerente = w_Plan[0][4].ToString();
                            diretor = w_Plan[0][5].ToString();
                            observacao = w_Plan[0][6].ToString();
                            idSentinella = w_Plan[0][0].ToString();
                        } else {
                            solicitante = "";
                            coordenador = "";
                            gerente = "";
                            diretor = "";
                            observacao = "";
                            idSentinella = "";
                        }

                        item.Text = linha["PROTOCOLO"].ToString();
                        item.SubItems.Add(linha["STATUS DA SOLICITAÇÃO"].ToString());
                        item.SubItems.Add(solicitante);
                        item.SubItems.Add(coordenador);
                        item.SubItems.Add(gerente);
                        item.SubItems.Add(diretor);
                        item.SubItems.Add(observacao);
                        item.SubItems.Add(linha["ETAPA NO FLUXO"].ToString());
                        item.SubItems.Add(linha["TIPO DOCUMENTO"].ToString());
                        item.SubItems.Add(linha["TÍTULO"].ToString());
                        item.SubItems.Add(linha["ORIGEM"].ToString());
                        item.SubItems.Add(linha["RESPONSÁVEL"].ToString());
                        item.SubItems.Add(linha["CR"].ToString());
                        item.SubItems.Add(linha["NORMA"].ToString());
                        item.SubItems.Add(linha["REQUISITO"].ToString());
                        item.SubItems.Add(linha["RNC"].ToString());
                        item.SubItems.Add(linha["DATA INÍCIO"].ToString());
                        item.SubItems.Add(linha["DATA FIM"].ToString());
                        item.SubItems.Add(linha["DATA DE MEDIÇÃO"].ToString());
                        item.SubItems.Add(linha["DATA RENEGOCIADA"].ToString());
                        item.SubItems.Add(linha["DATA DE CONCLUSÃO"].ToString());
                        item.SubItems.Add(linha["DIAS EM ATRASO"].ToString());
                        item.SubItems.Add(linha["CATEGORIA"].ToString());
                        item.SubItems.Add(linha["FALHA_PROCESSO"].ToString());
                        item.SubItems.Add(linha["FALHA_ASSOCIADO"].ToString());
                        item.SubItems.Add(linha["INCIDENTE"].ToString());
                        item.SubItems.Add(linha["CLASSIFICAÇÃO"].ToString());
                        item.SubItems.Add(linha["PRIORIDADE"].ToString());
                        item.SubItems.Add(idSentinella);

                        if (solicitante == "") {
                            item.ImageKey = "3";
                        } else {
                            item.ImageKey = "7";
                        }

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

        public bool salvarRegistro (planoDeAcao obj) {
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
