using System;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmPlanoAcao : Form {
        public frmPlanoAcao() {
            InitializeComponent();
        }

        #region Variaveis
        planoDeAcao obj = new planoDeAcao();
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        #endregion


        private void btBuscar_Click(object sender, EventArgs e) {
            //Validando datas usadas para pesquisa
            if (DateTime.Parse(dtpInicial.Text) > DateTime.Parse(dtpFinal.Text)) {
                MessageBox.Show("Data inicial é maior que a data final. Corrija e tente outra vez!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cursor = Cursors.WaitCursor;

            planoDeAcao plan = new planoDeAcao();            
            plan.CarregaListView(lvPlanoAcao, DateTime.Parse(dtpInicial.Text), DateTime.Parse(dtpFinal.Text));

            Cursor = Cursors.Default;

        }

        private planoDeAcao carregarObj() {
            try {
                int id = 0;

                //Validações
                if (!hlp.validaCamposObrigatorios(pnlConteudo, "txtSolicitante;txtCoordenacao;txtGerencia;txtDiretoria")) {
                    return null;
                }

                //planoDeAcao obj2 = new planoDeAcao(
                //    int.Parse(txt_protocolo.Text),
                //    txtSolicitante.Text.Trim(),
                //    txtCoordenacao.Text.Trim(),
                //    txtGerencia.Text.Trim(),
                //    txtDiretoria.Text.Trim(),
                //    DateTime.Parse(txt_dataRegistro.Text),
                //    id,
                //    txtObservacao.Text.Trim()
                //    );

                //return obj2;

                return null;

            }
            catch (Exception ex) {
                MessageBox.Show("Erro: " + ex.ToString(), Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            obj = carregarObj();
            if (obj != null) {
                if (obj.salvarRegistro(obj)) {

                    Cursor = Cursors.WaitCursor;
                    planoDeAcao plan = new planoDeAcao();
                    plan.CarregaListView(lvPlanoAcao, DateTime.Parse(dtpInicial.Text), DateTime.Parse(dtpFinal.Text));
                    Cursor = Cursors.Default;

                    hlp.limparCampos(this);
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e) {
            hlp.limparCampos(this);
        }

        private void pnlConteudo_Paint(object sender, PaintEventArgs e) {

        }
    }
}
