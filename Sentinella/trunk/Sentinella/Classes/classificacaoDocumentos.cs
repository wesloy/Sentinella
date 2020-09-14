using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sentinella {
    class classificacaoDocumentos {
        #region TABELAS

        //CREATE TABLE[dbo].[w_classificacaoDocumentos](
        //    [id] INT IDENTITY(1, 1) NOT NULL,
        //    [protocoloAnalise]   NVARCHAR (100)  DEFAULT (('yyyymmddhhmmssnomeanalista')) NULL,
        //    [diretorioPrincipal] NVARCHAR(MAX) DEFAULT('SEM INFO') NOT NULL,
        //    [nomeArquivo] NVARCHAR(MAX) DEFAULT('SEM INFO') NOT NULL,
        //    [extensao] NVARCHAR(10)  DEFAULT('SEM INFO') NOT NULL,
        //    [enderecoCompleto] NVARCHAR(MAX) DEFAULT('SEM INFO') NOT NULL,
        //    [dataCriacao] DATETIME DEFAULT('1900-01-01 00:00:00') NOT NULL,
        //    [dataModificacao] DATETIME DEFAULT('1900-01-01 00:00:00') NOT NULL,
        //    [dataUltimoAcesso] DATETIME DEFAULT('1900-01-01 00:00:00') NOT NULL,
        //    [analista] NVARCHAR(100) DEFAULT('NAO ANALISADO') NOT NULL,
        //    [analise] NVARCHAR(100) DEFAULT('NAO ANALISADO') NOT NULL,
        //    [observacoes]        NVARCHAR (MAX) DEFAULT ('SEM INFO') NOT NULL,
        //    [dataAnalise] DATETIME DEFAULT('1900-01-01 00:00:00') NOT NULL,
        //    CONSTRAINT[PK_w_classificacaoDocumentos] PRIMARY KEY CLUSTERED([id] ASC)
        //);


        #endregion

        #region VARIAVEIS 
        string sql = "";
        long retorno = 0;
        Uteis.Conexao objCon = new Uteis.Conexao(Uteis.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Uteis.Helpers hlp = new Uteis.Helpers();
        logs log = new logs();
        #endregion


        #region DTO
        public int id { get; set; }
        public string protocoloAnalise { get; set; } //formado por yyyymmddhhmmss + nome analista
        public string diretorioPrincipal { get; set; }
        public string nomeArquivo { get; set; }
        public string extensao { get; set; }
        public string enderecoCompleto { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataModificacao { get; set; }
        public DateTime dataUltimoAcesso { get; set; }
        public string analista { get; set; }
        public string analise { get; set; }
        public string observacoes { get; set; }
        public DateTime dataAnalise { get; set; }
        #endregion

        #region CONSTRUTORES
        public classificacaoDocumentos() { }

        public classificacaoDocumentos(string _protocoloAnalise, string _diretorioPrincipal, string _nomeArquivo,
                                            string _extensao, string _enderecoCompleto, DateTime _dataCriacao,
                                                DateTime _dataModificacao, DateTime _dataUltimoAcesso, string _analise, string _observacoes, 
                                                    string _analista, DateTime _dataAnalise, int _id = 0) {

            id = _id;
            protocoloAnalise = _protocoloAnalise;
            diretorioPrincipal = _diretorioPrincipal;
            nomeArquivo = _nomeArquivo;
            extensao = _extensao;
            enderecoCompleto = _enderecoCompleto;
            dataCriacao = _dataCriacao;
            dataModificacao = _dataModificacao;
            dataUltimoAcesso = _dataUltimoAcesso;
            analista = _analista;
            analise = _analise;
            dataAnalise = _dataAnalise;
            observacoes = _observacoes;

        }
        #endregion

        #region DAL

        private bool _insertRegistro(classificacaoDocumentos obj) {
            try {

                sql = "INSERT INTO w_classificacaoDocumentos (" +
                            "protocoloAnalise, " +
                            "diretorioPrincipal, " +
                            "nomeArquivo, " +
                            "extensao, " +
                            "enderecoCompleto, " +
                            "dataCriacao, " +
                            "dataModificacao, " +
                            "dataUltimoAcesso, " +
                            "analista, " +
                            "analise, " +
                            "dataAnalise) values (" +
                                objCon.valorSql(obj.protocoloAnalise) + ", " +
                                objCon.valorSql(obj.diretorioPrincipal) + ", " +
                                objCon.valorSql(obj.nomeArquivo) + ", " +
                                objCon.valorSql(obj.extensao) + ", " +
                                objCon.valorSql(obj.enderecoCompleto) + ", " +
                                objCon.valorSql(obj.dataCriacao) + ", " +
                                objCon.valorSql(obj.dataModificacao) + ", " +
                                objCon.valorSql(obj.dataUltimoAcesso) + ", " +
                                objCon.valorSql(obj.analista) + ", " +
                                objCon.valorSql(obj.analise) + ", " +
                                objCon.valorSql(obj.dataAnalise) + ") ";

                return objCon.executaQuery(sql, ref retorno);

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "CLASSIFICACAO DOCUMENTOS - INSERIR REGISTRO (DAL)");
                return false;
            }
        }


        private DataTable _arqAnalisados() {
            try {

                sql = "select * from w_classificacaoDocumentos where analise like '%conforme%'";
                return objCon.retornaDataTable(sql);

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "CLASSIFICACAO DOCUMENTOS - ARQUIVOS TRABLHADOS (DAL)");
                return null;
            }
        }

        private DataTable _consultaBaseHistorica(string _endCompleto) {
            try {

                sql = "select * from w_classificacaoDocumentos where enderecoCompleto = " + objCon.valorSql(_endCompleto) + " ";
                return objCon.retornaDataTable(sql);

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "CLASSIFICACAO DOCUMENTOS - CONSULTA BASE HISTORICA DOCS (DAL)");
                return null;
            }
        }

        #endregion

        #region BLL

        public bool carregarListview(ListView lst, string diretorio, bool incluirSubpastas = true, bool limparListView = true) {
            try {



                //Arquivos permissionados para subir para análise
                List<string> listaExtensoesPermitidas = new List<string>();
                listaExtensoesPermitidas.Add(".doc"); //todas as variáveis... docx
                listaExtensoesPermitidas.Add(".ppt"); //pptx
                listaExtensoesPermitidas.Add(".xls"); //xlsx, xlsb, xlsm...
                listaExtensoesPermitidas.Add(".pdf");
                listaExtensoesPermitidas.Add(".jpeg");
                listaExtensoesPermitidas.Add(".jpg");
                listaExtensoesPermitidas.Add(".png");


                if (limparListView) {
                    lst.Clear();

                    lst.View = View.Details;
                    lst.LabelEdit = false;
                    lst.CheckBoxes = true;
                    lst.SmallImageList = Constantes.imglist();
                    lst.Sorting = SortOrder.Ascending;
                    lst.GridLines = true;
                    lst.FullRowSelect = true;
                    lst.HideSelection = false;
                    lst.MultiSelect = false;
                    lst.Columns.Add("REFERÊNCIA", 80, HorizontalAlignment.Center);
                    lst.Columns.Add("DIRETÓRIO PRINCIPAL", 120, HorizontalAlignment.Center);
                    lst.Columns.Add("NOME DO ARQUIVO", 200, HorizontalAlignment.Left);
                    lst.Columns.Add("EXTENSÃO", 70, HorizontalAlignment.Left);
                    lst.Columns.Add("ENDEREÇO COMPLETO", 300, HorizontalAlignment.Left);
                    lst.Columns.Add("DATA CRIAÇÃO", 200, HorizontalAlignment.Left);
                    lst.Columns.Add("DATA MODIFICAÇÃO", 200, HorizontalAlignment.Left);
                    lst.Columns.Add("DATA ÚLTIMO ACESSO", 200, HorizontalAlignment.Left);
                    lst.Columns.Add("CONFORMIDADE", 100, HorizontalAlignment.Left);                    
                    lst.Columns.Add("OBSERVAÇÕES", 250, HorizontalAlignment.Left);

                    lst.Columns.Add("ANÁLISE ANTERIOR?", 100, HorizontalAlignment.Left);
                    lst.Columns.Add("ANALISTA", 120, HorizontalAlignment.Left);
                    lst.Columns.Add("DATA ÚLT ANÁLISE", 150, HorizontalAlignment.Left);
                }


                try {

                    frmProgressBar frmArq = new frmProgressBar(Directory.GetFiles(diretorio).Length);
                    frmArq.Show();
                    int qtdeLido = 0;


                    //base já importada e trabalhada
                    DataTable dt_arq_trabalhados = new DataTable();
                    dt_arq_trabalhados = _arqAnalisados();

                    //Pasta principal
                    foreach (var arq in Directory.GetFiles(diretorio)) {

                        FileInfo info = new FileInfo(arq);
                        ListViewItem item = new ListViewItem();
                        


                        //verificando se o arquivo sendo lido é permitido ser listado
                        foreach (string ext in listaExtensoesPermitidas) {

                            //filtrando DataTable com arquivos trabalhados para informar analises anteriores
                            string expressao = "enderecoCompleto = '" + info.FullName + "'";
                            DataRow[] arqLocalizados;
                            arqLocalizados = dt_arq_trabalhados.Select(expressao);

                            if (info.Extension.ToString().ToLower().Contains(ext)) {                                
                                item.Text = "0";
                                item.SubItems.Add(info.Directory.Root.ToString());
                                item.SubItems.Add(info.Name);
                                item.SubItems.Add(info.Extension);
                                item.SubItems.Add(info.FullName);
                                item.SubItems.Add(info.CreationTime.Date.ToLongDateString());
                                item.SubItems.Add(info.LastWriteTime.Date.ToLongDateString());
                                item.SubItems.Add(info.LastAccessTime.Date.ToLongDateString());
                                item.SubItems.Add("NÃO ANALISADO");
                                item.SubItems.Add("SEM INFO");

                                if (arqLocalizados.Length > 0) {
                                    item.SubItems.Add("SIM");

                                        foreach (DataRow row in arqLocalizados) {
                                            item.SubItems.Add(row["analista"].ToString());
                                            item.SubItems.Add(DateTime.Parse(row["dataAnalise"].ToString()).ToShortDateString());
                                            break;
                                        }
                                    
                                    item.ForeColor = Color.Green;
                                } else {
                                    item.SubItems.Add("NÃO");
                                    item.SubItems.Add("PRIMEIRA ANÁLISE"); //cada busca é uma nova análise, por isso sempre o usuário atual...
                                    item.SubItems.Add("1900-01-01");
                                }
                                

                                //Tratando os ícones
                                string _imageKey = "13";

                                switch (info.Extension.ToLower().Substring(0, 4).Replace(".", "")) {
                                    case "doc":
                                        _imageKey = "4";
                                        break;
                                    case "xls":
                                        _imageKey = "1";
                                        break;
                                    case "ppt":
                                        _imageKey = "3";
                                        break;
                                    case "jpg":
                                    case "png":
                                    case "jpe":
                                        _imageKey = "2";
                                        break;
                                    case "pdf":
                                        _imageKey = "5";
                                        break;
                                    default:
                                        _imageKey = "13";
                                        break;
                                }

                                item.ImageKey = _imageKey;
                                break;
                            }
                        }


                        if (item.Text.ToString() != "") { //validando se tem informação para exibir
                            lst.Items.Add(item);
                        }

                        //atualizacao da barra de progresso
                        qtdeLido += 1;
                        frmArq.atualizarBarra(qtdeLido);
                    }
                    frmArq.Close();

                    //se for para incluir subpastas, permitir o looping até o fim, ou sair do looping caso não deseje incluir subpastas
                    if (incluirSubpastas) {

                        int qtdeDirLido = 0;
                        frmProgressBar frmPastas = new frmProgressBar(Directory.GetDirectories(diretorio).Length);
                        frmPastas.Show();

                        foreach (var dir in Directory.GetDirectories(diretorio)) {
                            //chamando a própria função para carregar os itens do subdiretorio
                            //argumento verdadeiro para subpastas, para poder caputrar toda e qualquer subpasta existente 
                            //argumento falso para limpar o listview, caso contrário listará apenas a última pasta
                            carregarListview(lst, dir, true, false);

                            //atualizacao da barra de progresso
                            qtdeDirLido += 1;
                            frmPastas.atualizarBarra(qtdeDirLido);
                        }

                        frmPastas.Close();
                    }

                }

                catch (Exception ex) {

                    log.registrarLog(ex.ToString(), "CLASSIFICACAO DOCUMENTOS - PREENCHER LISTVIEW PRINCIPAL (BLL)");
                }

                return true;
            }
            catch (Exception) {
                MessageBox.Show("Houve um erro para carregar os arquivos deste diretório!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        public bool salvarRegistro(classificacaoDocumentos obj) {
            try {
                return _insertRegistro(obj);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "CLASSIFICACAO DOCUMENTOS - INSERIR REGISTRO (BLL)");
                return false;
            }
            
        }

        public DataTable consultaHistoricoAnaliseDoc(string _enderecoCompleto) {
            try {
                return _consultaBaseHistorica(_enderecoCompleto);
            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "CLASSIFICACAO DOCUMENTOS - CONSULTA BASE HISTORICA DOCS (BLL)");
                return null;
            }
        }

        #endregion

    }
}
