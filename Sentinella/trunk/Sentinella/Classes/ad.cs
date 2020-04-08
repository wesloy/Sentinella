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

        private bool _importarGruposAD() {
            try {


                string diretorio = "H:\\TI CORPORATIVA\\07 - SGSI\\51 - SENTINELLA\\AD\\";
                string[] arquivos = Directory.GetFiles(@diretorio, "*.csv", SearchOption.AllDirectories);
                int volAtualizado = 0;

                //carregar form Barra de Progresso de preparação dos dados
                frmProgressBar frm = new frmProgressBar(arquivos.Length);
                frm.atualizarBarra(0);
                frm.Show();

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

                        String[] infos = linha.Replace("\"", "").Split(delimitador.ToCharArray());
                        if (!infos[0].ToString().ToUpper().Contains("#TYPE") && !infos[0].ToString().ToUpper().Contains("NAME")) {

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
                                    objCon.executaQuery(sql, ref retorno);
                                }

                            } else {
                                //inserindo novo registro
                                sql = "Insert into w_AD_grupos_lista_associados (" +
                                        "nome_associado, " +
                                        "grupo, " +
                                        "ativo, " +
                                        "dataAtualizacao, " +
                                        "idAtualizacao) " +
                                        "select " +
                                        objCon.valorSql(infos[0].ToUpper()) + ", " +
                                        objCon.valorSql(nomeArquivo) + ", " +
                                        objCon.valorSql(true) + ", " +
                                        objCon.valorSql(hlp.dataHoraAtual()) + ", " +
                                        objCon.valorSql(Constantes.id_REDE_logadoFerramenta) + " ";
                                objCon.executaQuery(sql, ref retorno);
                            }


                        }

                    }

                    volAtualizado += 1;
                    frm.atualizarBarra(volAtualizado);
                    rd.Close();
                }

                //Desativando todos os que tem data de atualização > que hoje
                sql = "update l set " +
                        "l.ativo = 0 " +
                        "from w_AD_grupos_lista_associados l where l.dataAtualizacao < DATEADD(day, -1, getdate()) ";
                objCon.valorSql(sql);

                frm.Close();
                return true;
            }

            catch (Exception ex) {

                log.registrarLog(ex.ToString(), "IMPORTACAO - GRUPOS AD (DAL)");
                return false;
            }
        }


        private DataTable _listarTodosRegistrosPorIDBase(string _nomeAssociado) {

            try {
                //buscar todos com o primeiro nome igual
                string[] nomes = _nomeAssociado.Split(' ');
                sql = "select l.nome_associado, l.grupo, d.descricoes from w_AD_grupos_lista_associados l inner join w_AD_grupos_descricoes d on l.grupo = d.grupo " +
                        "where l.nome_associado like '" + nomes[0] + "%' and l.ativo = 1 " +
                        "group by l.grupo, l.nome_associado, d.descricoes, l.nome_associado";
                return objCon.retornaDataTable(sql);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "AD - LISTA DE REGISTROS POR NOME ASSOCIADO (DAL)");
                return null;
            }
        }



        #endregion

        #region Camada BLL - Negócio

        public bool importarGruposAD() {
            try {
                return _importarGruposAD();
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - GRUPOS AD (BLL)");
                return false;
            }
        }


        public ListView CarregaListView(ListView lst, string _nomeAssociado) {

            try {
                DataTable dt = new DataTable();
                dt = _listarTodosRegistrosPorIDBase(_nomeAssociado);
                lst.Clear();
                lst.View = View.Details;
                lst.LabelEdit = false;
                lst.CheckBoxes = false;
                lst.SmallImageList = Constantes.imglist();
                lst.GridLines = true;
                lst.FullRowSelect = true;
                lst.HideSelection = false;
                lst.MultiSelect = false;
                lst.Columns.Add("NOME ASSOCIADO", 300, HorizontalAlignment.Center);
                lst.Columns.Add("GRUPO", 300, HorizontalAlignment.Left);
                lst.Columns.Add("DESCRIÇÃO", 600, HorizontalAlignment.Left);

                if (dt.Rows.Count > 0) {
                    foreach (DataRow linha in dt.Rows) {
                        ListViewItem item = new ListViewItem();
                        item.Text = linha["nome_associado"].ToString();
                        item.SubItems.Add(linha["grupo"].ToString());
                        item.SubItems.Add(linha["descricoes"].ToString());
                        item.ImageKey = "11";
                        lst.Items.Add(item);

                    }
                }
                return lst;
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "AD - LISTVIEW (BLL)");
                return null;
            }
        }

        #endregion
    }
}
