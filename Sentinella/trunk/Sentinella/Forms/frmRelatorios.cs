using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella.Forms
{
    public partial class frmRelatorios : Form
    {
        public frmRelatorios()
        {
            InitializeComponent();
        }

        #region VARIAVEIS
        relatorios mis = new relatorios();
        Uteis.Helpers hlp = new Uteis.Helpers();
        ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        #endregion

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            bool pesquisaOkay;
            switch (cbxListaRelatorios.Text)
            {
                case "# RESOLUÇÃO DIÁRIA EVOLUTIVA POR FILA":
                    pesquisaOkay = mis.resolucaoDiariaEvolutiva(dtpInicial.Value, dtpFinal.Value, lvRelatorios);
                    break;

                case "# PRODUTIVIDADE POR FILA/DATA":
                    pesquisaOkay = mis.produtividadeFilaData(dtpInicial.Value, dtpFinal.Value, lvRelatorios);
                    break;

                case "% RESOLUÇÃO POR ANALISTA/PERIODO":
                    pesquisaOkay = mis.percentualResolucaoPorAnalistaPeriodo(dtpInicial.Value, dtpFinal.Value, lvRelatorios);
                    break;

                case "# RESOLUÇÃO DIÁRIA EVOLUTIVA POR ANALISTA/FILA":
                    pesquisaOkay = mis.resolucaoDiariaEvolutivaPorAnalistaFila(dtpInicial.Value, dtpFinal.Value, lvRelatorios);
                    break;

                case "# DEVOLUTIVA OUVIDORIA":
                    pesquisaOkay = mis.devolutivaOuvidoria(dtpInicial.Value, dtpFinal.Value, lvRelatorios);
                    break;

                case "% TARGET LAUDOS DENTRO DO SLA":
                    pesquisaOkay = mis.targetSlaLaudos(dtpInicial.Value, dtpFinal.Value, lvRelatorios);                    
                    break;

                case "# BASE GERAL":
                    int protocolo = 0;
                    if (txtInfBusca.Text != "")
                    {
                        protocolo = int.Parse(hlp.retornaSoNumeroDeString(txtInfBusca.Text));
                    }
                    pesquisaOkay = mis.baseGeral(dtpInicial.Value, dtpFinal.Value, lvRelatorios, protocolo);
                    break;
            }
        }

        private void btnRemoveFiltro_Click(object sender, EventArgs e)
        {
            cbxListaRelatorios.Text = "";
            txtInfBusca.Text = "";
            lvRelatorios.Clear();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            hlp.exportarListViewParaExcel(lvRelatorios);
            this.Cursor = Cursors.Default;
        }

        private void lvRelatorios_ColumnClick(object sender, ColumnClickEventArgs e) {
            //ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter(); <<<<<<<<<<<< declarado no escopo principal do form
            this.lvRelatorios.ListViewItemSorter = lvwColumnSorter;

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
            this.lvRelatorios.Sort();
        }
    }
}
