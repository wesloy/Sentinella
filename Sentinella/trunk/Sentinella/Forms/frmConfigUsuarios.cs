﻿using System;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmConfigUsuarios : Form {
        public frmConfigUsuarios() {
            InitializeComponent();
        }

        #region Variaveis
        usuarios obj = new usuarios();
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        #endregion

        #region funcoes
        private void carregarListView(string filtro = "") {
            obj.CarregaListView(lvLista, filtro);
        }

        private void carregarCombobox() {
            obj.carregarComboBoxPerfilAcesso(this, cbPerfilAcesso);
        }

        private void limparForm(bool limpezaParcial = false) {
            if (!limpezaParcial) {
                hlp.limparCampos(this);
            } else {
                txtFiltro.Text = "";
                ckboxAtivo.Checked = false;
                txtNome.Text = "";
                txtIdRede.Text = "";
                cbPerfilAcesso.Text = "";
                txtID.Text = "";
            }

            //Liberação de botões
            btnIncluir.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
        }
        private usuarios carregarObjeto() {

            int _id = 0;

            //Validações
            if (!hlp.validaCamposObrigatorios(pnlConteudo, "txtNome;txtIdRede;cbPerfilAcesso")) {
                return null;
            }

            //utilizando um construtor
            if (string.IsNullOrEmpty(txtID.Text)) { _id = 0; } else { _id = int.Parse(txtID.Text); }
            usuarios obj2 = new usuarios(
                _id,
                txtIdRede.Text,
                ckboxAtivo.Checked,
                txtNome.Text,
                int.Parse(cbPerfilAcesso.SelectedValue.ToString()));
            return obj2;
        }

        private void carregarForm(usuarios _obj) {
            ckboxAtivo.Checked = _obj.Ativo;
            txtIdRede.Text = _obj.IdRede;
            txtNome.Text = _obj.Nome;
            cbPerfilAcesso.SelectedValue = _obj.PerfilAcesso;
            txtID.Text = _obj.Id.ToString();
        }
        #endregion

        #region Botões
        private void btnIncluir_Click(object sender, EventArgs e) {
            obj = carregarObjeto();
            if (obj != null) {
                if (obj.incluir(obj)) {
                    string inclusao = txtNome.Text;
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
                    string alteracao = txtNome.Text;
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

        private void frmConfigUsuarios_Load(object sender, EventArgs e) {
            limparForm();
            carregarListView();
            carregarCombobox();
        }

        private void lvLista_DoubleClick(object sender, EventArgs e) {
            string id = lvLista.SelectedItems[0].SubItems[0].Text;
            if ((string.IsNullOrEmpty(id)) || (id.ToString() == "0")) {
                MessageBox.Show("Nenhum registro foi selecionado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                obj = obj.capturarUsuariosPorID(int.Parse(id));
                carregarForm(obj);

                //Liberação de botões
                btnIncluir.Enabled = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }


    }
}
