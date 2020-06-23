using System;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmConfigTamnunFiltros : Form {
        public frmConfigTamnunFiltros() {
            InitializeComponent();
        }

        #region Variaveis
        tamnun obj = new tamnun();
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        #endregion

        #region funcoes
        private void carregarListView(string filtro = "%") {
            obj.carregarListViewConfigFiltros(lvLista, filtro);
        }

        private void limparForm(bool limpezaParcial = false) {

            obj.carregarComboboxCategorias(this, cbxCategorias);
            obj.carregarComboboxCategorias(this, cbxListaCategorias);
            obj.carregarComboboxFontes(this, cbxFonte);
            carregarListView();

            if (!limpezaParcial) {
                hlp.limparCampos(this);
            } else {
                cbxListaCategorias.Text = "";
                cbxCategorias.Text = "";
                ckboxAtivo.Checked = false;
                cbxFonte.Text = "";
                txtFiltro.Text = "";
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
            if (!hlp.validaCamposObrigatorios(pnlConteudo, "cbxCategorias;cbxFonte;txtFiltro")) {
                return null;
            }

            //utilizando um construtor
            if (string.IsNullOrEmpty(txtID.Text)) { _id = 0; } else { _id = int.Parse(txtID.Text); }
            tamnun obj2 = new tamnun(
                _id,
                cbxFonte.Text,
                cbxCategorias.Text,
                txtFiltro.Text,
                ckboxAtivo.Checked);
            return obj2;
        }

        private void carregarForm(tamnun _obj) {
            ckboxAtivo.Checked = _obj._filtros_ativo;
            cbxCategorias.Text = _obj._filtros_categoria;
            cbxFonte.Text = _obj._filtros_fonte;
            txtFiltro.Text = _obj._filtros_valorBusca;
            txtID.Text = _obj._filtros_id.ToString();
        }
        #endregion

        private void frmCadTamnunFiltros_Load(object sender, EventArgs e) {
            limparForm();
            carregarListView();
        }

        private void btnFiltrar_Click(object sender, EventArgs e) {
            carregarListView(cbxListaCategorias.Text);
        }

        private void btnRemoveFiltro_Click(object sender, EventArgs e) {
            txtFiltro.Text = "";
            carregarListView();
        }

        private void btnIncluir_Click(object sender, EventArgs e) {
            obj = carregarObjeto();
            if (obj != null) {
                if (obj.insertFiltro(obj)) {                    
                    limparForm();                    
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            string id = lvLista.SelectedItems[0].SubItems[0].Text;
            if ((string.IsNullOrEmpty(id)) || (id.ToString() == "0")) {
                MessageBox.Show("Nenhum registro foi selecionado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                obj.deletarFiltrorPorId(int.Parse(id));
                limparForm();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            obj = carregarObjeto();
            if (obj != null) {
                if (obj.updateFiltro(obj)) {
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
                obj = obj.capturarObjFiltroPorId(int.Parse(id));
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
