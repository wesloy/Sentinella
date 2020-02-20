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
    public partial class frmLocalizarInformacoesAD : Form {
        public frmLocalizarInformacoesAD() {
            InitializeComponent();
        }

        #region Variaveis
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        relatorios rel = new relatorios(); //informações do funcionário segundo a planilha do TH
        #endregion

        private void frmLocalizarInformacoesAD_Load(object sender, EventArgs e) {
            hlp.limparCampos(pnlFiltros);
            dgvInfoAD.DataSource = "";

            List<string> camposPersonalizados = new List<string>();
            camposPersonalizados = rel.colunasTabelaBD("db_ControleAD.dbo.Tbl_UsuariosAD");
            string preencherComboManual = "";

            foreach (string item in camposPersonalizados) {
                preencherComboManual += ";" + item;
            }
            preencherComboManual = preencherComboManual.Substring(1); // retirando ponto vírgula inicial
            hlp.carregaComboBoxManualmente(preencherComboManual, this, cbxCampoPersonalizado);
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            hlp.limparCampos(pnlFiltros);
            dgvInfoAD.DataSource = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e) {

            try {
                Cursor.Current = Cursors.WaitCursor;
                relatorios rel = new relatorios();
                if (string.IsNullOrEmpty(txtInfoOU.Text) && string.IsNullOrEmpty(txtCPF.Text)
                        && string.IsNullOrEmpty(txtMatricula.Text) && string.IsNullOrEmpty(txtNomeUsuario.Text)
                        && string.IsNullOrEmpty(cbxCampoPersonalizado.Text) && string.IsNullOrEmpty(txtValorPersonalizado.Text)) {
                    MessageBox.Show("Pelo menos um valor de busca deve ser digitado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!string.IsNullOrEmpty(cbxCampoPersonalizado.Text) && string.IsNullOrEmpty(txtValorPersonalizado.Text)) {
                    MessageBox.Show("Se foi selecionado algum valor do campo personalizado, deve-se informar um valor para o mesmo!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                List<string> _OUs = new List<string>();
                string[] entradaOUs = txtInfoOU.Text.Split(',');

                for (int i = 0; i < entradaOUs.Length; i++) {
                    _OUs.Add(entradaOUs[i]);
                }

                if (!rel.informacoesAD(dgvInfoAD, _OUs, txtCPF.Text, txtNomeUsuario.Text, txtMatricula.Text,cbxCampoPersonalizado.Text,txtValorPersonalizado.Text)) {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Não foi possível listar informações do AD com os dados de busca!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally {

                Cursor.Current = Cursors.Default;
            }

        }

        private void frmLocalizarInformacoesAD_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                    btnBuscar_Click(sender, e);
                    break;
                case Keys.Escape:
                    btnCancelar_Click(sender, e);
                    break;
            }

        }
    }
}
