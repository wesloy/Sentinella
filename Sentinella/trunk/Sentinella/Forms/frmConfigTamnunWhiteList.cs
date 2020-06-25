﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmConfigTamnunWhiteList : Form {

        #region Variaveis
        tamnun obj = new tamnun();
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        #endregion

        #region funcoes
        private void carregarListView() {
            obj.carregarListViewConfigWhiteList(lvLista);
        }

        private void limparForm(bool limpezaParcial = false) {

            carregarListView();

            if (!limpezaParcial) {
                hlp.limparCampos(this);
            } else {
                txtNome.Text = "";
                txtMatricula.Text = "";
                txtCPF.Text = "";
                txtIDRede.Text = "";
                txtCodCentroCusto.Text = "";
                txtCentroCusto.Text = "";
                txtCargoAssociado.Text = "";
                txtID.Text = "";
            }

            //Liberação de botões
            btnIncluir.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private tamnun carregarObjeto() {

            int _id = 0;

            //Validações
            if (!hlp.validaCamposObrigatorios(pnlConteudo, "txtNome;txtMatricula;txtCPF;txtIDRede;txtCodCentroCusto;txtCentroCusto;txtCargoAssociado")) {
                return null;
            }

            //utilizando um construtor
            if (string.IsNullOrEmpty(txtID.Text)) { _id = 0; } else { _id = int.Parse(txtID.Text); }
            tamnun obj2 = new tamnun(
                _id,
                txtNome.Text,
                txtMatricula.Text,
                txtCPF.Text,
                txtIDRede.Text,
                txtCodCentroCusto.Text,
                txtCentroCusto.Text,
                txtCargoAssociado.Text
                );
            return obj2;
        }

        private void carregarForm(tamnun _obj) {
            txtNome.Text = _obj._wl_nome;
            txtMatricula.Text = _obj._wl_matricula;
            txtCPF.Text = _obj._wl_cpf;
            txtIDRede.Text = _obj._wl_idRede;
            txtCodCentroCusto.Text = _obj._wl_codCentroCusto;
            txtCentroCusto.Text = _obj._wl_centroCusto;
            txtCargoAssociado.Text = _obj._wl_cargoAssociado;
            txtID.Text = _obj._wl_id.ToString();
        }
        #endregion

        public frmConfigTamnunWhiteList() {
            InitializeComponent();
        }

        private void frmConfigTamnunWhiteList_Load(object sender, EventArgs e) {
            limparForm();
            carregarListView();
        }

        private void btnIncluir_Click(object sender, EventArgs e) {
            obj = carregarObjeto();
            if (obj != null) {
                if (obj.insertWhiteList(obj)) {
                    limparForm();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            string id = lvLista.SelectedItems[0].SubItems[0].Text;
            if ((string.IsNullOrEmpty(id)) || (id.ToString() == "0")) {
                MessageBox.Show("Nenhum registro foi selecionado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                obj.deletarWhiteListrPorId(int.Parse(id));
                limparForm();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            obj = carregarObjeto();
            if (obj != null) {
                if (obj.updateWhiteList(obj)) {
                    limparForm();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            limparForm();
        }

        private void lvLista_DoubleClick(object sender, EventArgs e) {
            string id = lvLista.SelectedItems[0].SubItems[0].Text;
            if ((string.IsNullOrEmpty(id)) || (id.ToString() == "0")) {
                MessageBox.Show("Nenhum registro foi selecionado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                obj = obj.capturarObjWhiteListPorId(int.Parse(id));
                carregarForm(obj);

                //Liberação de botões
                btnIncluir.Enabled = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = true;
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
}