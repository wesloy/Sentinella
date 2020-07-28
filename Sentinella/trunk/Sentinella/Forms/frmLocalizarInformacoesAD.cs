using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmLocalizarInformacoesAD : Form {
        public frmLocalizarInformacoesAD() {
            InitializeComponent();
        }

        #region Variaveis
        Uteis.Helpers hlp = new Uteis.Helpers();
        relatorios rel = new relatorios(); //informações dos funcionários segundo a banco de dados AD atualizado a cada dia 
        ad _ad = new ad(); //informações dos funcionários segundo o AD
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
            hlp.limparCampos(tb_selecaoFuncao);
            dgvInfoAD.DataSource = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e) {

            try {

                Cursor.Current = Cursors.WaitCursor;
                relatorios rel = new relatorios();


                if (tb_selecaoFuncao.SelectedIndex == 0) {

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

                    if (!rel.informacoesAD(dgvInfoAD, _OUs, txtCPF.Text, txtNomeUsuario.Text, txtMatricula.Text, cbxCampoPersonalizado.Text, txtValorPersonalizado.Text)) {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Não foi possível listar informações do AD com os dados de busca!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                } else {

                    if (cbxCampoFiltroGAP.Text == "" || cbxValorBuscaGAP.Text == "") {
                        MessageBox.Show("É necessário selecionar o campo a ser filtrado E preencher um valor de busca!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                                        
                    //Carregando informações
                    dgvInfoAD.DataSource = _ad.listarGruposAssociadosPastas(cbxPastas.Checked, cbxCampoFiltroGAP.Text, cbxValorBuscaGAP.Text);


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

        private void tb_selecaoFuncao_SelectedIndexChanged(object sender, EventArgs e) {
            hlp.limparCampos(tb_selecaoFuncao);
        }

        private void cbxCampoFiltroGAP_SelectionChangeCommitted(object sender, EventArgs e) {
            _ad.carregarComboboxInfoTabela(cbxCampoFiltroGAP.Text, this, cbxValorBuscaGAP);
            if (cbxCampoFiltroGAP.Text.Contains("DIRETORIO") || cbxCampoFiltroGAP.Text.Contains("DISCO") || cbxCampoFiltroGAP.Text.Contains("PASTA")) {
                cbxPastas.Checked = true;
                cbxPastas.Enabled = false;
            } else {
                cbxPastas.Checked = false;
                cbxPastas.Enabled = true;
            }
        }
    }
}
