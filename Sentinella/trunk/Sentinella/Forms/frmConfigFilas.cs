﻿using System;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmConfigFilas : Form {
        public frmConfigFilas() {
            InitializeComponent();
        }

        #region Variaveis
        filas obj = new filas();
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        #endregion

        #region funcoes
        private void carregarListView(string filtro = "") {
            obj.CarregaListView(lvLista, filtro);
        }
        private void limparForm(bool limpezaParcial = false) {
            if (!limpezaParcial) {
                hlp.limparCampos(this);
            } else {
                txtFiltro.Text = "";
                ckboxAtivo.Checked = false;
                ckboxArqExt.Checked = false;
                txtFila.Text = "";
                txtGrupoMIS.Text = "";
                txtSla.Text = "";
                txtRegraNegocio.Text = "";
                txtRegraImport.Text = "";
                txtID.Text = "";
            }

            //Liberação de botões
            btnIncluir.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
        }
        private filas carregarObjeto() {

            int _id = 0;

            //Validações
            if (!hlp.validaCamposObrigatorios(pnlConteudo, "txtFila;txtGrupoMIS;txtRegraNegocio;txtSla")) {
                return null;
            }
            
            //utilizando um construtor
            if (string.IsNullOrEmpty(txtID.Text)) { _id = 0; } else { _id = int.Parse(txtID.Text); }
            filas obj2 = new filas(
                txtFila.Text,
                txtGrupoMIS.Text,
                txtRegraNegocio.Text,
                txtRegraImport.Text,
                ckboxAtivo.Checked,
                ckboxArqExt.Checked,
                int.Parse(txtSla.Text),
                _id);
            return obj2;
        }

        private void carregarForm(filas _obj) {
            ckboxAtivo.Checked = _obj.Ativo;
            ckboxArqExt.Checked = _obj.ArqExterno;
            txtFila.Text = _obj.Descricao;
            txtGrupoMIS.Text = _obj.Grupo;
            txtSla.Text = _obj.Sla.ToString();
            txtRegraNegocio.Text = _obj.RegraNegocio;
            txtRegraImport.Text = _obj.RegraImportacao;
            txtID.Text = _obj.Id.ToString();
        }
        #endregion

        private void frmConfigFilas_Load(object sender, EventArgs e) {
            limparForm();
            carregarListView();
        }


        private void txtSla_KeyPress(object sender, KeyPressEventArgs e) {
            hlp.somenteNumero(txtSla);
        }

        private void lvLista_DoubleClick(object sender, EventArgs e) {
            string id = lvLista.SelectedItems[0].SubItems[0].Text;
            if ((string.IsNullOrEmpty(id)) || (id.ToString() == "0")) {
                MessageBox.Show("Nenhum registro foi selecionado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                obj = obj.capturarFilaPorID(int.Parse(id));
                carregarForm(obj);

                //Liberação de botões
                btnIncluir.Enabled = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }


        #region Botões
        private void btnIncluir_Click(object sender, EventArgs e) {
            obj = carregarObjeto();
            if (obj != null) {
                if (obj.incluir(obj)) {
                    string inclusao = txtFila.Text;
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
                    string alteracao = txtFila.Text;
                    limparForm(true);
                    carregarListView(alteracao);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            limparForm();
        }

        private void btnFiltrar_Click(object sender, EventArgs e) {
            carregarListView(txtFiltro.Text);
        }

        private void btnRemoveFiltro_Click(object sender, EventArgs e) {
            txtFiltro.Text = "";
            carregarListView();
        }

        #endregion

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
