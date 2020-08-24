using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmClassificacaoDocumentos : Form {

        #region VARIAVEIS
        Uteis.Helpers hlp = new Uteis.Helpers();
        #endregion


        #region FUNCOES

        private ListViewItem carregaritemListView(string enderecoArquivo) {
            try {

                //principais variáveis
                ListViewItem item = new ListViewItem();
                FileInfo info = new FileInfo(enderecoArquivo);

                //Arquivos permissionados para subir para análise
                List<string> listaExtensoesPermitidas = new List<string>();
                listaExtensoesPermitidas.Add(".doc"); //todas as variáveis... docx
                listaExtensoesPermitidas.Add(".ppt"); //pptx
                listaExtensoesPermitidas.Add(".xls"); //xlsx, xlsb, xlsm...
                listaExtensoesPermitidas.Add(".pdf");
                listaExtensoesPermitidas.Add(".jpeg");
                listaExtensoesPermitidas.Add(".jpg");
                listaExtensoesPermitidas.Add(".png");

                //verificando se o arquivo sendo lido é permitido ser listado
                foreach (string ext in listaExtensoesPermitidas) {
                    if (info.Extension.ToString().ToLower().Contains(ext)) {
                        item.Text = info.Directory.Parent.ToString();
                        item.SubItems.Add(info.Name);
                        item.SubItems.Add(info.Extension);
                        item.SubItems.Add(info.FullName);
                        item.SubItems.Add(hlp.formataHoraAbreviada(hlp.dataAbreviada()).ToShortDateString());
                        item.SubItems.Add("NÃO ANALISADO");
                        item.SubItems.Add(Constantes.nomeAssociadoLogado);
                        break;
                    }

                    item = null;
                }

                return item;

            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        private bool carregarListView(string diretorio, bool incluirSubpastas = true, bool limparListView = true) {

            try {

                ListView lst = lvDocumentos;
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
                    lst.Columns.Add("DIRETÓRIO PRINCIPAL", 150, HorizontalAlignment.Center);
                    lst.Columns.Add("NOME DO ARQUIVO", 150, HorizontalAlignment.Left);
                    lst.Columns.Add("EXTENSÃO", 80, HorizontalAlignment.Left);
                    lst.Columns.Add("ENDEREÇO COMPLETO", 300, HorizontalAlignment.Left);
                    lst.Columns.Add("DATA ANÁLISE", 100, HorizontalAlignment.Left);
                    lst.Columns.Add("CONFORMIDADE", 100, HorizontalAlignment.Left);
                    lst.Columns.Add("ANALISTA", 80, HorizontalAlignment.Left);
                }

                ListViewItem item = new ListViewItem();
                try {

                    frmProgressBar frmArq = new frmProgressBar(Directory.GetFiles(diretorio).Length);
                    frmArq.Show();
                    int qtdeLido = 0;

                    //Pasta principal
                    foreach (var arq in Directory.GetFiles(diretorio)) {

                        item = carregaritemListView(arq);
                        if (item != null) { //validando se foi possível carregar informações
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

                        foreach (var dir in Directory.GetDirectories(diretorio)) {
                            //chamando a própria função para carregar os itens do subdiretorio
                            //argumento verdadeiro para subpastas, para poder caputrar toda e qualquer subpasta existente 
                            //argumento falso para limpar o listview, caso contrário listará apenas a última pasta
                            carregarListView(dir, true, false);

                            //atualizacao da barra de progresso
                            qtdeDirLido += 1;
                            frmPastas.atualizarBarra(qtdeDirLido);
                        }

                        frmPastas.Close();
                    }

                }

                catch (Exception) {

                    MessageBox.Show("Existem pastas/documentos neste diretório que você não tem privilégios para acessar!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


                return true;
            }
            catch (Exception) {
                MessageBox.Show("Houve um erro para carregar os arquivos deste diretório!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }




        }

        #endregion


        public frmClassificacaoDocumentos() {
            InitializeComponent();
        }





        private void btBuscar_Click(object sender, EventArgs e) {


            //listar os arquivos de um diretório que o analista escolher
            //com ou sem as subpastas

            //validar se foi escolhido apenas diretório ou diretório + subpastas
            if (!rbDiretorio.Checked && !rbDiretorioSubpastas.Checked) {
                MessageBox.Show("Deve ser escolhido uma das formas de listagem dos arquivos: " + Environment.NewLine + "Apenas Diretório ou Diretório e Subpastas", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                lbEnderecoPesquisado.Text = folderBrowserDialog.SelectedPath;
                if (carregarListView(lbEnderecoPesquisado.Text, rbDiretorioSubpastas.Checked)) {
                    MessageBox.Show("Arquivos carregados com sucesso!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void frmClassificacaoDocumentos_Load(object sender, EventArgs e) {

        }
    }
}
