using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmTrilhasSGI : Form {

        trilhasSGI trilhas = new trilhasSGI();
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();

        private void limpezaForm() {
            trilhas.preencherComboBoxAnoVigencia(this, cbxAnoVigencia);
            cbxLideranca.Enabled = true;
            lvAssociados.Clear();
            hlp.limparCampos(pnlFiltros);
            hlp.limparCampos(pnlConteudo);
            cbxHierarquia.Enabled = true;
            cbxAnoVigencia.Enabled = true;
            cbxLideranca.DataSource = null;
            cbxLideranca.Enabled = false;
            lbFiltroPorStatus.Text = "(Clique sobre o item da legenda para filtrar)";
            lbFiltroAplicado.Text = "TODOS";
            txtMensagem.Text = "Gestor," + Environment.NewLine +
            "Os associados abaixo apresentam pendências nos treinamentos anuais mandatórios da Algar Tech." + Environment.NewLine +
            "Solicitamos a gentileza de seu apoio para que os cursos sejam realizados, a fim de evitar o bloqueio nos usuários do(a) associado(a)." + Environment.NewLine + Environment.NewLine +
            "Dúvidas estamos à disposição!";

            btnEnviar.Enabled = true;

        }

        public frmTrilhasSGI() {
            InitializeComponent();
        }


        private void frmTrilhasSGI_Load(object sender, EventArgs e) {
            limpezaForm();
        }

        private void btnIniciar_Click(object sender, EventArgs e) {
            cbxLideranca.Enabled = false;

            Clipboard.Clear();

            if (hlp.validaCamposObrigatorios(pnlFiltros, "cbxHierarquia")) {

                if (lbFiltroAplicado.Text.ToUpper() != "TODOS") {
                    lbFiltroPorStatus.Text = "(Clique aqui para retirar o filtro aplicado)";
                } else {
                    lbFiltroPorStatus.Text = "(Clique sobre o item da legenda para filtrar)";
                }

                if (trilhas.preencherListViewAssociados(lvAssociados, cbxLideranca.Text, cbxHierarquia.Text, int.Parse(cbxAnoVigencia.Text), lbFiltroAplicado.Text)) {
                    cbxHierarquia.Enabled = false;
                    cbxLideranca.Enabled = false;
                }

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e) {

            if (trilhas.liberarRegistros()) {
                limpezaForm();
            }

        }

        private void btnImportar_Click(object sender, EventArgs e) {
            long registrosImportados = 0;
            registrosImportados = trilhas.abrirProducao();
            MessageBox.Show("O total de registros importados para trabalho são: " + registrosImportados + "!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void lkDesmarcarTodos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            foreach (ListViewItem item in lvAssociados.Items) {
                item.Checked = false;
            }
        }

        private void lkMarcarTodos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            foreach (ListViewItem item in lvAssociados.Items) {
                item.Checked = true;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e) {

            if (!hlp.validaCamposObrigatorios(pnlConteudo, "txtEmailDestinatario;txtMensagem")) {
                return;
            }

            bool validacao = false;
            foreach (ListViewItem item in lvAssociados.Items) {
                if (item.Checked) {
                    validacao = true;
                    break;
                }
            }

            if (!validacao) {
                MessageBox.Show("É necessário selecionar ao menos 1 associado da lista para enviar o e-mail ao coordenador!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //envio pelo Dynamics e baixa do registro
            email_dynamics.email_dynamics email = new email_dynamics.email_dynamics();

            email.Assunto = "TREINAMENTOS MANDATÓRIOS - TRILHA SGI";
            email.Mensagem = txtMensagem.Text.Replace("\r\n", "<br />") + " <br /><br />";
            email.Mensagem += "Lista de associados com pendência: <br /><br />";

            foreach (ListViewItem item in lvAssociados.Items) {
                if (item.Checked) {
                    email.Mensagem += item.SubItems[1].Text + "<br />";
                    email.Mensagem += item.SubItems[2].Text + "<br />";
                    email.Mensagem += "Percentual concluído: " + item.SubItems[5].Text + "% <br />";

                    if (int.Parse(item.SubItems[4].Text) < 0) {
                        email.Mensagem += "Período de conclusão vencido: " + int.Parse(item.SubItems[4].Text) * -1 + " dia(s). <br />";
                    } else {
                        email.Mensagem += "Período de conclusão irá vencer: " + item.SubItems[4].Text + " dia(s). <br />";
                    }

                    email.Mensagem += "Supervisão: " + item.SubItems[10].Text + "<br />";
                    email.Mensagem += "Coordenação: " + item.SubItems[11].Text + "<br /><br />";
                }
            }


            //Para
            List<string> para = new List<string>();
            string[] _para = txtEmailDestinatario.Text.Split(';');
            foreach (var item in _para) { para.Add(item); }
            email.Para = para;

            //CC
            string txtCC = "marianesg@algartech.com;deborahvhw@algartech.com;nataliadda@algartech.com;isabelladab@algartech.com;mayraneapl@algartech.com;wesleyel@algartech.com";
            List<string> cc = new List<string>();
            string[] _cc = txtCC.Split(';');
            foreach (var item in _cc) { cc.Add(item); }
            email.Cc = cc;

            //CCo
            string txtCCo = trilhas.capturarEmailAnalistaSeguranca().ToLower();
            List<string> ccO = new List<string>();
            string[] _ccO = txtCCo.Split(';');
            foreach (var item in _ccO) { ccO.Add(item); }
            email.CcO = ccO;

            //Carregando os anexos
            //List<string> listaAnexos = new List<string>();
            //foreach (string file in lbAnexos.Items) { listaAnexos.Add(file); }
            //email.Anexos = listaAnexos;

            //Assinatura
            email.Mensagem += "Coordenação de Segurança da Informação e Compliance Algar Tech! <br />";
            email.Mensagem += "Dúvidas contatar: " + txtCCo;


            if (email.envio(email.Assunto, email.Mensagem, email.Para, email.Cc, email.CcO, null)) {

                //Finalizar registros
                foreach (ListViewItem item in lvAssociados.Items) {
                    if (item.Checked) {
                        trilhas.finalizarRegistro(int.Parse(item.SubItems[0].Text), txtEmailDestinatario.Text);
                    }
                }

                //liberando registros que podem não ter sido selecionados para envio e limpando o formulário
                trilhas.liberarRegistros(false);
                limpezaForm();
                MessageBox.Show("E-mail enviado com sucesso!", "Envio de E-mail");
            } else {
                MessageBox.Show("Falha no envio de E-mail!", "Envio de E-mail");
            }



        }

        private void cbxHierarquia_SelectionChangeCommitted(object sender, EventArgs e) {

            if (cbxHierarquia.Text != "SELEÇÃO DE TODOS") {
                trilhas.preencherComboBoxLideres(this, cbxLideranca, cbxHierarquia.Text);
                cbxLideranca.Enabled = true;
                btnEnviar.Enabled = true;
            } else {
                btnEnviar.Enabled = false;
            }

            cbxAnoVigencia.Enabled = false;

        }

        private void pbVermelhoPendente_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "PENDENTES";
            btnIniciar_Click(sender, e);
        }

        private void Label11_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "PENDENTES";
            btnIniciar_Click(sender, e);
        }

        private void pbAmareloFerias_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "FERIAS";
            btnIniciar_Click(sender, e);
        }

        private void label6_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "FERIAS";
            btnIniciar_Click(sender, e);
        }

        private void pbPretoAfastado_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "AFASTADOS";
            btnIniciar_Click(sender, e);
        }

        private void Label9_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "AFASTADOS";
            btnIniciar_Click(sender, e);
        }

        private void pbAzulForaPeriodo_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "FORA DO PERIODO";
            btnIniciar_Click(sender, e);
        }

        private void label8_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "FORA DO PERIODO";
            btnIniciar_Click(sender, e);
        }

        private void pbVerdeConcluido_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "CONCLUIDOS";
            btnIniciar_Click(sender, e);
        }

        private void label12_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "CONCLUIDOS";
            btnIniciar_Click(sender, e);
        }

        private void lbFiltroPorStatus_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "TODOS";
            btnIniciar_Click(sender, e);
        }

        private void lvAssociados_ColumnClick(object sender, ColumnClickEventArgs e) {

            ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
            this.lvAssociados.ListViewItemSorter = lvwColumnSorter;

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
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvAssociados.Sort();
        }
    }
}
