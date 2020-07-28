using System;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmConfigSubFinalizacoes : Form {
        public frmConfigSubFinalizacoes() {
            InitializeComponent();
        }

        #region Variaveis
        subFinalizacoes obj = new subFinalizacoes();
        Uteis.Helpers hlp = new Uteis.Helpers();
        ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        #endregion

        #region funcoes

        private void carregarListView(string filtro = "") {
            obj.CarregaListView(lvLista, filtro);
        }

        private void carregarCombobox() {
            obj.carregarComboboxFilas(this, cbxFilasAtivas, true);
            obj.carregarComboboxFilas(this, cbxRetornoFilaFup, true);
        }

        private void limparForm(bool limpezaParcial = false) {
            if (!limpezaParcial) {
                hlp.limparCampos(this);
            } else {
                txtFiltro.Text = "";
                ckboxAtivo.Checked = false;
                txtID.Text = "";
                txtSubFinalizacao.Text = "";
                cbxFilasAtivas.Text = "";
                cbxFinalizacaoAtivas.Text = "";
                ckboxFup.Checked = false;
                txtDiasRetornoFup.Text = "";
                cbxRetornoFilaFup.Text = "";
            }

            //Liberação de botões
            btnIncluir.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
        }
        private subFinalizacoes carregarObjeto() {

            int _id, _diasFup, _idFilaFup;
            //Validações
            if (!hlp.validaCamposObrigatorios(pnlConteudo, "txtSubFinalizacao;cbxFilasAtivas;cbxFinalizacaoAtivas")) {
                return null;
            }
            if (ckboxFup.Checked) {
                if (!hlp.validaCamposObrigatorios(pnlConteudo, "txtDiasRetornoFup;cbxRetornoFilaFup")) {
                    return null;
                }
            }

            //utilizando um construtor
            if (string.IsNullOrEmpty(txtID.Text)) { _id = 0; } else { _id = int.Parse(txtID.Text); }
            if (string.IsNullOrEmpty(txtDiasRetornoFup.Text)) { _diasFup = 0; } else { _diasFup = int.Parse(txtDiasRetornoFup.Text); }
            if (string.IsNullOrEmpty(cbxRetornoFilaFup.Text)) { _idFilaFup = 0; } else { _idFilaFup = int.Parse(cbxRetornoFilaFup.SelectedValue.ToString()); }
            subFinalizacoes obj2 = new subFinalizacoes(
                ckboxAtivo.Checked,
                txtSubFinalizacao.Text,
                int.Parse(cbxFilasAtivas.SelectedValue.ToString()),
                int.Parse(cbxFinalizacaoAtivas.SelectedValue.ToString()),
                ckboxFup.Checked,
                _diasFup,
                _idFilaFup,
                _id
                );
            return obj2;
        }

        private void carregarForm(subFinalizacoes _obj) {
            limparForm();
            ckboxAtivo.Checked = _obj.Ativo;
            txtID.Text = _obj.Id.ToString();
            txtSubFinalizacao.Text = _obj.Descricao;
            cbxFilasAtivas.SelectedValue = _obj.Fila_id;
            cbxFilasAtivas_Leave(null, null);
            cbxFinalizacaoAtivas.SelectedValue = _obj.Finalizacao_id;
            ckboxFup.Checked = _obj.GeraNovoCaso;
            txtDiasRetornoFup.Text = _obj.AgingNovoCaso.ToString();
            cbxRetornoFilaFup.SelectedValue = _obj.FilaNovoCaso;
        }

        #endregion

        private void frmConfigSubFinalizacoes_Load(object sender, EventArgs e) {
            limparForm();
            carregarListView();
            carregarCombobox();
        }

        private void lvLista_DoubleClick(object sender, EventArgs e) {
            string id = lvLista.SelectedItems[0].SubItems[0].Text;
            if ((string.IsNullOrEmpty(id)) || (id.ToString() == "0")) {
                MessageBox.Show("Nenhum registro foi selecionado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                obj = obj.capturarSubFinalizacaoPorID(int.Parse(id));
                carregarForm(obj);

                //Liberação de botões
                btnIncluir.Enabled = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }
        private void txtDiasRetornoFup_KeyPress(object sender, KeyPressEventArgs e) {
            hlp.somenteNumero(txtDiasRetornoFup);
        }

        private void cbxFilasAtivas_Leave(object sender, EventArgs e) {

            cbxFinalizacaoAtivas.Text = "";
            if (cbxFilasAtivas.Text != "") {
                obj.carregarComboboxFinalizacoes(this, cbxFinalizacaoAtivas, int.Parse(cbxFilasAtivas.SelectedValue.ToString()), true);
            } else {
                cbxFinalizacaoAtivas.DataSource = null;
            }
        }

        #region Botões

        private void btnFiltrar_Click(object sender, EventArgs e) {
            carregarListView(txtFiltro.Text);
        }

        private void btnRemoveFiltro_Click(object sender, EventArgs e) {
            txtFiltro.Text = "";
            carregarListView();
        }

        private void btnIncluir_Click(object sender, EventArgs e) {
            obj = carregarObjeto();
            if (obj != null) {
                if (obj.incluir(obj)) {
                    string inclusao = txtSubFinalizacao.Text;
                    limparForm(true);
                    carregarListView(inclusao);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            obj = carregarObjeto();
            if (obj != null) {
                if (obj.excluir(obj)) {
                    limparForm(true);
                    carregarListView();
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            obj = carregarObjeto();
            if (obj != null) {
                if (obj.atualizar(obj)) {
                    string alteracao = txtSubFinalizacao.Text;
                    limparForm(true);
                    carregarListView(alteracao);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            limparForm();
        }

        private void cbxFilasAtivas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Fila RETORNO OUVIDORIA (ID = 5) NÃO DEVE GERAR FUPS
            if (cbxFilasAtivas.SelectedValue.ToString() == "5")
            {
                cbxRetornoFilaFup.Enabled = false;
                ckboxFup.Enabled = false;
                txtDiasRetornoFup.Enabled = false;
            }
            else
            {
                cbxRetornoFilaFup.Enabled = true;
                ckboxFup.Enabled = true;
                txtDiasRetornoFup.Enabled = true;
            }
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
    #endregion

}
