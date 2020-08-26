using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmClassificacaoDocumentos : Form {

        #region VARIAVEIS
        Uteis.Helpers hlp = new Uteis.Helpers();
        ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        #endregion


        #region FUNCOES
        private void limparform() {
            hlp.limparCampos(this);
            lvDocumentos.Clear();
            lbEnderecoPesquisado.Text = "Não Informado";        }
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
                classificacaoDocumentos cd = new classificacaoDocumentos();
                
                if (cd.carregarListview(lvDocumentos, lbEnderecoPesquisado.Text, rbDiretorioSubpastas.Checked)) {
                    MessageBox.Show("Arquivos carregados com sucesso!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void frmClassificacaoDocumentos_Load(object sender, EventArgs e) {
            limparform();
        }

        private void lvDocumentos_ColumnClick(object sender, ColumnClickEventArgs e) {

            //ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter(); <<<<<<<<<<<< declarado no escopo principal do form
            this.lvDocumentos.ListViewItemSorter = lvwColumnSorter;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn) {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending) {
                    lvwColumnSorter.Order = SortOrder.Descending;
                } else {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            } else {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending) {
                    lvwColumnSorter.Order = SortOrder.Descending;
                } else {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }


                //lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvDocumentos.Sort();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            limparform();
        }
    }
}
