using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Sentinella {
    class ad {

        #region TABELAS

        //CREATE TABLE [dbo].[w_AD_grupos_lista_associados] (
        //    [id]              INT            IDENTITY (1, 1) NOT NULL,
        //    [nome_associado]  NVARCHAR (100) NULL,
        //    [grupo]           NVARCHAR (100) NULL,
        //    [ativo]           BIT            DEFAULT ((0)) NOT NULL,
        //    [dataAtualizacao] DATETIME       DEFAULT (getdate()) NULL,
        //    [idAtualizacao]   NCHAR (10)     NULL,
        //    CONSTRAINT [PK_w_AD_grupos] PRIMARY KEY CLUSTERED ([id] ASC)
        //);

        //CREATE TABLE [dbo].[w_AD_grupos_descricoes] (
        //    [id]              INT            IDENTITY (1, 1) NOT NULL,
        //    [grupo]           NVARCHAR (100) NULL,
        //    [descricoes]      NVARCHAR (500) NULL,
        //    [ativo]           BIT            DEFAULT ((0)) NOT NULL,
        //    [dataAtualizacao] DATETIME       DEFAULT (getdate()) NULL,
        //    [idAtualizacao]   NCHAR (10)     NULL,
        //    CONSTRAINT [PK_w_AD_grupos_descricoes] PRIMARY KEY CLUSTERED ([id] ASC)
        //);
        #endregion

        #region Variaveis 
        string sql = "";
        long retorno = 0;
        Algar.Utils.Conexao objCon = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        #endregion


        #region Camada DAL - Dados

        public bool _importarGruposAD() {
            try {


                string diretorio = "H:\\TI CORPORATIVA\\07 - SGSI\\51 - SENTINELLA\\AD\\";
                string[] arquivos = Directory.GetFiles(@diretorio, "*.csv", SearchOption.AllDirectories);
                long volAtualizado = 0;

                foreach (string arq in arquivos) {

                    //lendo cada um dos arquivos
                    string linha = "";
                    string delimitador = ",";
                    FileInfo file = new FileInfo(arq);
                    string nomeArquivo = file.Name;
                    nomeArquivo = nomeArquivo.Replace("Relatorio_", "").Replace(".csv", "");
                    StreamReader rd = new StreamReader(arq);

                    //carregar a lista atual dos associados para validar se deve permanecer ativo ou cadastrar um novo associado
                    DataTable dt_lista_atual = new DataTable();
                    sql = "Select * from w_AD_grupos_lista_associados";
                    dt_lista_atual = objCon.retornaDataTable(sql);

                    while ((linha = rd.ReadLine()) != null) {

                        String[] infos = linha.Split(delimitador.ToCharArray());
                        if (!infos[0].ToString().ToUpper().Contains("#TYPE") || !infos[0].ToString().ToUpper().Contains("NAME")) {

                            DataRow[] resultado = null;
                            string expressao = "nome_associado = '" + infos[0] + "' and grupo = '" + nomeArquivo + "'";
                            resultado = dt_lista_atual.Select(expressao);

                            if (resultado.Length > 0) {
                                //atualizando a data do bd
                                foreach (var item in resultado) {
                                    sql = "Update AD set " +
                                            "ativo = " + objCon.valorSql(true) + ", " +
                                            "dataAtualizacao = " + objCon.valorSql(hlp.dataHoraAtual()) + ", " +
                                            "idAtualizacao = " + objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + " " +
                                            "from w_AD_grupos_lista_associados AD where 1 = 1 " +
                                            "and nome_associado = " + objCon.valorSql(item["nome_associado"]) + " " +
                                            "and grupo = " + objCon.valorSql(nomeArquivo) + " ";
                                    objCon.executaQuery(sql, ref volAtualizado);
                                } 

                            } else {
                                //inserindo novo registro
                                sql = "Insert into (" +
                                        "nome_associado, " +
                                        "grupo, " +
                                        "ativo, " +
                                        "dataAtualizacao, " +
                                        "idAtualizacao) " +
                                        "select " +
                                        objCon.valorSql(infos[0].ToUpper()) + " " +
                                        objCon.valorSql(nomeArquivo) + " " +
                                        objCon.valorSql(true) + " " +
                                        objCon.valorSql(hlp.dataHoraAtual()) + " " +
                                        objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + " ";
                                objCon.executaQuery(sql, ref volAtualizado);
                            }

                        }

                    }

                }

                return true;
            }

            catch (Exception ex) {

                log.registrarLog(ex.ToString(), "IMPORTACAO - GRUPOS AD (DAL)");
                return false;
            }
        }

        private DataTable _listarTodosRegistrosPorIDBase(int _id) {

            //DESATUALIZADO

            try {
                sql = "Select * from w_dlp Where 1 = 1 ";
                sql += "and id_tbl_trabalho = " + objCon.valorSql(_id) + " ";
                sql += "and flag_trabalho = 0 ";
                sql += "Order by generated_ ";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DLP - LISTA DE REGISTROS POR ID TRABALHO (DAL)");
                return null;
            }
        }


        #endregion

        #region Camada BLL - Negócio


        public ListView CarregaListView(ListView lst, int _id) {

            //DESATUALIZADO

            try {
                DataTable dt = new DataTable();
                dt = _listarTodosRegistrosPorIDBase(_id);
                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = false;
                lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("DATA EVENTO", 150, HorizontalAlignment.Center);
                lst.Columns.Add("REGRA", 150, HorizontalAlignment.Left);
                lst.Columns.Add("TEMPLATE", 150, HorizontalAlignment.Left);
                lst.Columns.Add("DEPARTAMENTO", 300, HorizontalAlignment.Left);
                lst.Columns.Add("USUÁRIO REDE", 200, HorizontalAlignment.Left);
                lst.Columns.Add("NOME", 300, HorizontalAlignment.Left);
                lst.Columns.Add("CHANNEL", 300, HorizontalAlignment.Left);
                lst.Columns.Add("ARQUIVO/SITE", 1000, HorizontalAlignment.Left);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = hlp.retornaDataTextBox(linha["generated_"].ToString());
                        item.SubItems.Add(linha["rule_"].ToString());
                        item.SubItems.Add(linha["template"].ToString());
                        if (string.IsNullOrEmpty(linha["department"].ToString())) {
                            item.SubItems.Add("");
                        } else {
                            item.SubItems.Add(linha["department"].ToString());
                        }
                        item.SubItems.Add(linha["incident_source_ad_account"].ToString());
                        item.SubItems.Add(linha["nome_completo"].ToString());
                        item.SubItems.Add(linha["channel"].ToString());
                        item.SubItems.Add(linha["destination"].ToString());
                        item.ImageKey = "9";
                        lst.Items.Add(item);

                    }
                }
                return lst;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "DLP - LISTVIEW (BLL)");
                return null;
            }
        }

        #endregion
    }
}
