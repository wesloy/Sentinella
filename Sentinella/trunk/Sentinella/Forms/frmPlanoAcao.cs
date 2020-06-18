using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmPlanoAcao : Form {
        public frmPlanoAcao() {
            InitializeComponent();
        }

        #region Variaveis
        planoDeAcao obj = new planoDeAcao();
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        #endregion


        private void limparForm(bool parcial = true) {
            if (parcial) {
                txtEmailDestinatario.Text = "";
                txtEmailTitulo.Text = "";
                txtMensagem.Text = "";
            } else {
                hlp.limparCampos(pnlConteudo);
            }

        }


        private void btBuscar_Click(object sender, EventArgs e) {
            //Validando datas usadas para pesquisa
            if (DateTime.Parse(dtpInicial.Text) > DateTime.Parse(dtpFinal.Text)) {
                MessageBox.Show("Data inicial é maior que a data final. Corrija e tente outra vez!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Cursor = Cursors.WaitCursor;
            limparForm();

            //Resetando informações de filtro
            if (lbFiltroAplicado.Text.ToUpper() != "TODOS") {
                lbFiltroPorStatus.Text = "(Clique aqui para retirar o filtro aplicado)";
            } else {
                lbFiltroPorStatus.Text = "(Clique sobre o item da legenda para filtrar)";
            }

            //Tratando os filtros
            string filtro = "";
            switch (lbFiltroAplicado.Text.ToUpper()) {

                case "FINALIZADOS":
                    filtro = "FINALIZADOS";
                    break;

                case "DENTRO DO PRAZO":
                    filtro = "DENTRO DO PRAZO";
                    break;

                case "CANCELADO / REPROVADO":
                    filtro = "CANCELADO / REPROVADO";
                    break;

                case "PLANO VENCIDO - D<7":
                    filtro = "D<7";
                    break;

                case "PLANO VENCIDO - D7+ || PLANO VENCIDO - D14+ || PLANO VENCIDO - D21+":
                    filtro = "D>7";
                    break;

                case "PLANO VENCIDO - D28+":
                    filtro = "D>28";
                    break;

                case "NÃO CLASSIFICADO":
                    filtro = "NÃO CLASSIFICADO";
                    break;

                case "TODOS":
                    filtro = "TODOS";
                    break;

                default:
                    filtro = "";
                    break;
            }


            planoDeAcao plan = new planoDeAcao();
            plan.CarregaListView(lvPlanoAcao, DateTime.Parse(dtpInicial.Text), DateTime.Parse(dtpFinal.Text), filtro);

            Cursor = Cursors.Default;

        }

        private planoDeAcao carregarObj() {
            try {

                planoDeAcao obj2 = new planoDeAcao(
                    int.Parse(lvPlanoAcao.SelectedItems[0].SubItems[1].Text),
                    lvPlanoAcao.SelectedItems[0].SubItems[0].Text,
                    DateTime.Parse(lvPlanoAcao.SelectedItems[0].SubItems[20].Text),
                    DateTime.Parse(lvPlanoAcao.SelectedItems[0].SubItems[21].Text),
                    lvPlanoAcao.SelectedItems[0].SubItems[6].Text,
                    lvPlanoAcao.SelectedItems[0].SubItems[7].Text,
                    true,
                    txtEmailDestinatario.Text,
                    hlp.dataHoraAtual()
                    );

                return obj2;

            }
            catch (Exception ex) {
                MessageBox.Show("Erro: " + ex.ToString(), Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e) {

            if (!hlp.validaCamposObrigatorios(pnlConteudo, "txtEmailDestinatario;txtMensagem;txtEmailTitulo")) {
                return;
            }


            //envio pelo Dynamics e baixa do registro
            email_dynamics.email_dynamics email = new email_dynamics.email_dynamics();

            email.Assunto = txtEmailTitulo.Text;
            email.Mensagem = txtMensagem.Text.Replace("\r\n", "<br />") + " <br /><br />";


            //Para
            List<string> para = new List<string>();
            string[] _para = txtEmailDestinatario.Text.Split(';');
            foreach (var item in _para) { para.Add(item); }
            email.Para = para;

            //CC
            string txtCC = "marianesg@algartech.com;deborahvhw@algartech.com;nataliadda@algartech.com;isabelladab@algartech.com;mayraneapl@algartech.com;talienelv@algartech.com;wesleyel@algartech.com";
            //string txtCC = "wesleyel@algartech.com";
            List<string> cc = new List<string>();
            string[] _cc = txtCC.Split(';');
            foreach (var item in _cc) { cc.Add(item); }
            email.Cc = cc;

            //CCo
            usuarios user = new usuarios();
            string txtCCo = user.capturarEmailAnalistaSeguranca().ToLower();
            List<string> ccO = new List<string>();
            string[] _ccO = txtCCo.Split(';');
            foreach (var item in _ccO) { ccO.Add(item); }
            email.CcO = ccO;

            //Carregando os anexos
            //List<string> listaAnexos = new List<string>();
            //foreach (string file in lbAnexos.Items) { listaAnexos.Add(file); }
            //email.Anexos = listaAnexos;


            if (email.envio(email.Assunto, email.Mensagem, email.Para, email.Cc, email.CcO, null)) {                
                //Finalizar registros
                obj.finalizarRegistro(carregarObj());
                MessageBox.Show("E-mail enviado com sucesso!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btBuscar_Click(sender, e);

            } else {
                MessageBox.Show("Falha no envio de E-mail!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
        private void btnCancelar_Click(object sender, EventArgs e) {
            hlp.limparCampos(this);
        }

        private void lvPlanoAcao_ColumnClick(object sender, ColumnClickEventArgs e) {
            //ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter(); <<<<<<<<<<<< declarado no escopo principal do form
            this.lvPlanoAcao.ListViewItemSorter = lvwColumnSorter;

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
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending) {
                    lvwColumnSorter.Order = SortOrder.Descending;
                } else {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }


                //lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvPlanoAcao.Sort();
        }

        private void lvPlanoAcao_DoubleClick(object sender, EventArgs e) {


            limparForm();

            if (lvPlanoAcao.SelectedItems[0].SubItems[5].Text.ToUpper().Contains("FINALIZADO") ||
                    lvPlanoAcao.SelectedItems[0].SubItems[5].Text.ToUpper().Contains("REPROVADO") ||
                        lvPlanoAcao.SelectedItems[0].SubItems[5].Text.ToUpper().Contains("CANCELADO") ||
                            DateTime.Parse(lvPlanoAcao.SelectedItems[0].SubItems[21].Text) > DateTime.Today) {
                MessageBox.Show("Não é possível enviar e-mail para Planos de Ação com Status da Solicitação diferente de 'EM ABERTO' e/ou data do fim do Plano seja maior que hoje!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtEmailTitulo.Text = "PLANO DE AÇÃO " + lvPlanoAcao.SelectedItems[0].SubItems[1].Text;

            txtMensagem.Text = "Olá," + Environment.NewLine + Environment.NewLine;

            txtMensagem.Text += "Em relação ao Plano de Ação número " + lvPlanoAcao.SelectedItems[0].SubItems[1].Text + ", o prazo para conclusão era " + lvPlanoAcao.SelectedItems[0].SubItems[21].Text + " ";
            txtMensagem.Text += "e não identificamos evidências anexadas, no TechOnline." + Environment.NewLine;
            txtMensagem.Text += "Por gentileza, solicitamos que responda esse e-mail para marianesg@algartech.com com as evidências anexadas até ";
            txtMensagem.Text += "o próximo dia útil, a fim de que possamos encerrá-lo.  " + Environment.NewLine + Environment.NewLine;


            txtMensagem.Text += "Atenciosamente, " + Environment.NewLine;
            txtMensagem.Text += "SGI - Sistema de Gestão Integrada";


        }

        private void frmPlanoAcao_Load(object sender, EventArgs e) {
            limparForm(false);
        }

        private void finalizado_1_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = finalizado_1_texto.Text;
            btBuscar_Click(sender, e);
        }

        private void finalizado_1_texto_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = finalizado_1_texto.Text;
            btBuscar_Click(sender, e);
        }

        private void dentro_prazo_4_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = dentro_prazo_4_texto.Text;
            btBuscar_Click(sender, e);
        }

        private void dentro_prazo_4_texto_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = dentro_prazo_4_texto.Text;
            btBuscar_Click(sender, e);
        }

        private void plano_vencido_2_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = plano_vencido_2_texto.Text;
            btBuscar_Click(sender, e);
        }

        private void plano_vencido_2_texto_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = plano_vencido_2_texto.Text;
            btBuscar_Click(sender, e);
        }

        private void plano_vencido_maior7_3_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = plano_vencido_maior7_3_texto.Text;
            btBuscar_Click(sender, e);
        }

        private void plano_vencido_maior7_3_texto_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = plano_vencido_maior7_3_texto.Text;
            btBuscar_Click(sender, e);
        }

        private void plano_vencido_maior28_5_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = plano_vencido_maior28_5_texto.Text;
            btBuscar_Click(sender, e);
        }

        private void plano_vencido_maior28_5_texto_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = plano_vencido_maior28_5_texto.Text;
            btBuscar_Click(sender, e);
        }

        private void nao_classificado_14_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = nao_classificado_14_texto.Text;
            btBuscar_Click(sender, e);
        }

        private void nao_classificado_14_texto_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = nao_classificado_14_texto.Text;
            btBuscar_Click(sender, e);
        }

        private void lbFiltroPorStatus_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "TODOS";
            btBuscar_Click(sender, e);
        }

        private void cancelado_reprovado_5_texto_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "CANCELADO / REPROVADO";
            btBuscar_Click(sender, e);
        }

        private void cancelado_reprovado_5_Click(object sender, EventArgs e) {
            lbFiltroAplicado.Text = "CANCELADO / REPROVADO";
            btBuscar_Click(sender, e);
        }


    }
}
