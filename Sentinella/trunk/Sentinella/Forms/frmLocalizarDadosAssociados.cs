using System;
using System.Windows.Forms;

namespace Sentinella.Forms {



    public partial class frmLocalizarDadosAssociados : Form {

        #region Variaveis
        Uteis.Helpers hlp = new Uteis.Helpers();
        dadosCadastraisTH d_th = new dadosCadastraisTH(); //informações do funcionário segundo a planilha do TH
        #endregion


        public frmLocalizarDadosAssociados() {
            InitializeComponent();
        }


        private void frmLocalizarDadosAssociados_Load(object sender, EventArgs e) {
            hlp.limparCampos(this);
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            if (!hlp.validaCamposObrigatorios(this, "cbxTipoBusca;txtValorBusca")) {
                return;
            }
            switch (cbxTipoBusca.Text) {
                case "CPF":
                    d_th.carregarDataGridView_CPF(txtValorBusca.Text, dgvInfoAssociados);
                    break;
                case "MATRÍCULA":
                    d_th.carregarDataGridView_Matricula(txtValorBusca.Text, dgvInfoAssociados);
                    break;
                case "NOME ASSOCIADO":
                    d_th.carregarDataGridView_NomeAssociado(txtValorBusca.Text, dgvInfoAssociados);
                    break;

            }
        }


        private void btnCancelar_Click(object sender, EventArgs e) {
            hlp.limparCampos(this);
        }
    }
}
