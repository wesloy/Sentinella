using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmConfigInterrupcoesProgramadas : Form {
        public frmConfigInterrupcoesProgramadas() {
            InitializeComponent();
        }


        #region Variaveis
        sys_interrupcoesProgramadas obj = new sys_interrupcoesProgramadas();
        Uteis.Helpers hlp = new Uteis.Helpers();
        ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        #endregion

        #region funcoes
        private void carregarListView() {
            obj.CarregaListView(lvLista);
        }
        private void limparForm(bool limpezaParcial = false) {
            if (!limpezaParcial) {
                hlp.limparCampos(this);
                carregarListView();
            } else {                
                ckboxAtivo.Checked = false;
                dtInicial.Text = "";
                cbxHora.Text = "";
                cbxMinuto.Text = "";
                txtMensagem.Text = "";
                cbxTempoInterrupcao.Text = "";
                txtID.Text = "";
            }

            //Liberação de botões
            btnIncluir.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
        }
        private sys_interrupcoesProgramadas carregarObjeto() {

            int _id = 0;

            //Validações
            if (!hlp.validaCamposObrigatorios(pnlConteudo, "dtInicial;cbxHora;cbxMinuto;cbxTempoInterrupcao;cbxClassificacao;txtMensagem")) {
                return null;
            }


            DateTime dtHoraInicial = new DateTime(dtInicial.Value.Year, dtInicial.Value.Month, dtInicial.Value.Day, int.Parse(cbxHora.Text),int.Parse(cbxMinuto.Text),0);
            DateTime dtHoraFinal = new DateTime();
            dtHoraFinal =  dtHoraInicial.AddMinutes(int.Parse(cbxTempoInterrupcao.Text.Substring(0, 2)));

            //utilizando um construtor
            if (string.IsNullOrEmpty(txtID.Text)) { _id = 0; } else { _id = int.Parse(txtID.Text); }
            sys_interrupcoesProgramadas obj2 = new sys_interrupcoesProgramadas(
               _id,
               ckboxAtivo.Checked,
               cbxClassificacao.Text + " >>> " + txtMensagem.Text,
               cbxTempoInterrupcao.Text,
               dtHoraInicial,
               dtHoraFinal
             );
            return obj2;
        }

        private void carregarForm(sys_interrupcoesProgramadas _obj) {
            ckboxAtivo.Checked = _obj._ativo;
            dtInicial.Text = _obj._dataHoraInicial.ToString();
            cbxHora.Text = _obj._dataHoraInicial.Hour.ToString();
            cbxMinuto.Text = _obj._dataHoraInicial.Minute.ToString();
            cbxTempoInterrupcao.Text = _obj._tempoInterrupcao.ToString();
            txtMensagem.Text = _obj._mensagem.ToString();            
            txtID.Text = _obj._id.ToString();
        }
        #endregion

        private void frmConfigInterrupcoesProgramadas_Load(object sender, EventArgs e) {
            limparForm();
            carregarListView();
        }

        private void btnIncluir_Click(object sender, EventArgs e) {
            obj = carregarObjeto();
            if (obj != null) {
                if (obj.insert(obj)) {                    
                    limparForm(true);
                    carregarListView();
                }
            }
        }

        private void lvLista_DoubleClick(object sender, EventArgs e) {
            string id = lvLista.SelectedItems[0].SubItems[0].Text;
            if ((string.IsNullOrEmpty(id)) || (id.ToString() == "0")) {
                MessageBox.Show("Nenhum registro foi selecionado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                obj = obj.capturarObjPorId(int.Parse(id));
                carregarForm(obj);

                //Liberação de botões
                btnIncluir.Enabled = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            string id = lvLista.SelectedItems[0].SubItems[0].Text;
            if ((string.IsNullOrEmpty(id)) || (id.ToString() == "0")) {
                MessageBox.Show("Nenhum registro foi selecionado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                obj.deletarPorId(int.Parse(id));
                limparForm();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            obj = carregarObjeto();
            if (obj != null) {
                if (obj.update(obj)) {
                    limparForm(true);
                    carregarListView();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            limparForm();
        }

        private void lvLista_ColumnClick(object sender, ColumnClickEventArgs e) {
            //ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter(); <<<<<<<<<<<< declarado no escopo principal do form
            this.lvLista.ListViewItemSorter = lvwColumnSorter;

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
            this.lvLista.Sort();
        }
    }
}
