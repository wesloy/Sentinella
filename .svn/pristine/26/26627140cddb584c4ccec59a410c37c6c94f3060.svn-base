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
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            hlp.limparCampos(pnlFiltros);
            dgvInfoAD.DataSource = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            relatorios rel = new relatorios();
            Cursor.Current = Cursors.WaitCursor;

            if (string.IsNullOrEmpty(txtInfoOU.Text)  && string.IsNullOrEmpty(txtCPF.Text)
                    && string.IsNullOrEmpty(txtMatricula.Text) && string.IsNullOrEmpty(txtNomeUsuario.Text)) {
                MessageBox.Show("Pelo menos um valor de busca deve ser digitado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!rel.informacoesAD(dgvInfoAD, txtInfoOU.Text, txtCPF.Text, txtNomeUsuario.Text, txtMatricula.Text)) {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Não foi possível listar informações do AD com os dados de busca!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Cursor.Current = Cursors.Default;

        }
    }
}
