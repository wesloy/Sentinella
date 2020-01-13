﻿using System;
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

            planoDeAcao plan = new planoDeAcao();
            plan.CarregaListView(lvPlanoAcao, DateTime.Parse(dtpInicial.Text), DateTime.Parse(dtpFinal.Text));

        }

        private planoDeAcao carregarObj() {
            try {
                int id = 0;

                //Validações
                if (!hlp.validaCamposObrigatorios(pnlConteudo, "txtSolicitante;txtCoordenacao;txtGerencia;txtDiretoria")) {
                    return null;
                }

                //utilizando um construtor
                if (string.IsNullOrEmpty(txtID.Text) || txtID.Text == "") {
                    id = 0;
                } else {
                    id = int.Parse(txtID.Text);
                }

                planoDeAcao obj2 = new planoDeAcao(
                    int.Parse(txt_protocolo.Text),
                    txtSolicitante.Text.Trim(),
                    txtCoordenacao.Text.Trim(),
                    txtGerencia.Text.Trim(),
                    txtDiretoria.Text.Trim(),
                    DateTime.Parse(txt_dataRegistro.Text),
                    id,
                    txtObservacao.Text.Trim()
                    );

                return obj2;

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
                    btBuscar_Click(sender, e); //recarregar o form
                    hlp.limparCampos(this);
                }
            }
        }

        private void lvPlanoAcao_DoubleClick(object sender, EventArgs e) {

            Cursor.Current = Cursors.WaitCursor;


            string id = lvPlanoAcao.SelectedItems[0].SubItems[0].Text;
            if ((string.IsNullOrEmpty(id)) || (id.ToString() == "0")) {
                MessageBox.Show("Nenhum registro foi selecionado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {

                if (lvPlanoAcao.SelectedItems[0].SubItems[3].Text == "") {
                    //buscar dados da hieraquia através do registro mais recente do cadastro geral
                    dadosCadastraisTH d_th = new dadosCadastraisTH();
                    d_th = d_th.infoMaisRecentePorNomeEspecifico(lvPlanoAcao.SelectedItems[0].SubItems[11].Text);

                    if (d_th.gestor_1 != null) {
                        txtCoordenacao.Text = d_th.gestor_1.ToString().ToUpper();
                    }

                    if (d_th.gestor_2 != null) {
                        txtGerencia.Text = d_th.gestor_2.ToString().ToUpper();
                    }

                    if (d_th.gestor_3 != null) {
                        txtDiretoria.Text = d_th.gestor_3.ToString().ToUpper();
                    }

                    d_th.CarregarListviewSimplificado(lvCadastroGeralSimplificado, d_th.Cpf);


                } else {
                    //carregando dados já confirmados de uma vez anterior
                    txtCoordenacao.Text = lvPlanoAcao.SelectedItems[0].SubItems[3].Text;
                    txtGerencia.Text = lvPlanoAcao.SelectedItems[0].SubItems[4].Text;
                    txtDiretoria.Text = lvPlanoAcao.SelectedItems[0].SubItems[5].Text;
                }

                txtID.Text = lvPlanoAcao.SelectedItems[0].SubItems[28].Text;
                txt_protocolo.Text = lvPlanoAcao.SelectedItems[0].SubItems[0].Text;
                txt_dataRegistro.Text = lvPlanoAcao.SelectedItems[0].SubItems[16].Text;
                txtSolicitante.Text = lvPlanoAcao.SelectedItems[0].SubItems[2].Text;
                txtObservacao.Text = lvPlanoAcao.SelectedItems[0].SubItems[6].Text;

            }

            Cursor.Current = Cursors.Default;
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            hlp.limparCampos(this);
        }
    }
}
