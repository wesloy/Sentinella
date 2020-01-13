using Sentinella.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella {
    public partial class frmPrincipal : Form {

        #region Variaveis Uteis
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        private Form _objForm { get; set; }
        #endregion

        public frmPrincipal() {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e) {
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmHome();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
            Form frm = new frmLogin();
            frm.ShowDialog();
            if (!Constantes.autenticacao) {
                Close();
            }
        }
        private void mmFechar_Click(object sender, EventArgs e) {
            hlp.fecharAplicativo();
        }
        private void mmOpenImportacoesForm_Click(object sender, EventArgs e) {
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmImportacoes();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void mmOpenAnalisesForm_Click(object sender, EventArgs e) {
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmAnalies();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void mmOpenTelaInicial_Click(object sender, EventArgs e) {
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmHome();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void mmOpenConfigFilasFinalizacoesSubs_Click(object sender, EventArgs e) {
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmConfigFilasFinalizacaoSubFinalizacao();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

    }
}
