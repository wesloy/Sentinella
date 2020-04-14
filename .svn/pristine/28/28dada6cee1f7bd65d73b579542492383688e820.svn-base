using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmImportacoes : Form {
        public frmImportacoes() {
            InitializeComponent();
        }

        #region Variaveis        
        filas objFilas = new filas();
        logsImportacoes objLog = new logsImportacoes();
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        importacoes imp = new importacoes();
        importacoesRetornoOuvidoria impOuv = new importacoesRetornoOuvidoria();
        usuarios user = new usuarios();
        #endregion

        #region funcoes
        private void carregarListView(string filtro = "") {
            objLog.CarregaListView(lvLista, filtro);
            user.CarregarListViewParaConfiguracoes(lvUsuarios, "");
        }

        private void limparForm(bool limpezaParcial = false) {
            if (!limpezaParcial) {
                hlp.limparCampos(this);
            } else {
                txtFilaID.Text = "";
                txtEnderecoArquivo.Text = "";
                cbxSeletorFilaImportacao.Text = "";
                btnProcurar.Enabled = false;
                txtEnderecoArquivo.Enabled = false;
                cbxSeletorFilaImportacao.Enabled = true;
                rbArquivos.Checked = false;
                rbRobos.Checked = false;
            }
            //Liberação de botões
            btnIncluir.Enabled = true;
            btnFinalizar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
        }
        #endregion


        private void frmImportacoes_Load(object sender, EventArgs e) {
            limparForm();
            carregarListView();

        }

        #region Botoes
        private void btnProcurar_Click(object sender, EventArgs e) {
            txtEnderecoArquivo.Text = hlp.EnderecoArqCapturar();
        }

        private void btnIncluir_Click(object sender, EventArgs e) {
            try {
                List<int> listaUsuarios = new List<int>();

                if (!hlp.validaCamposObrigatorios(pnlConteudo, "cbxSeletorFilaImportacao")) {
                    return;
                }


                if ((rbRobos.Checked) || (rbArquivos.Checked && cbxSeletorFilaImportacao.Text == "DLP" || rbArquivos.Checked && cbxSeletorFilaImportacao.Text == "TAMNUN")) {

                    //validando se algum analista foi selecionado para receber o volume da fila

                    for (int i = 0; i < lvUsuarios.Items.Count; i++) {

                        if (lvUsuarios.Items[i].Checked) {
                            listaUsuarios.Add(int.Parse(lvUsuarios.Items[i].SubItems[0].Text));
                        }
                    }

                    //validando campo obrigatorio
                    if (listaUsuarios.Count == 0) {
                        MessageBox.Show("É necessário selecionar ao menos 1 analista para receber o volume de trabalho!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }



                if (rbRobos.Checked && !cbxSeletorFilaImportacao.Text.Contains("DLP")) {

                    if (cbxSeletorFilaImportacao.Text.Contains("OUVIDORIA")) {
                        impOuv.incluir(int.Parse(cbxSeletorFilaImportacao.SelectedValue.ToString()));
                    } else {
                        imp.incluir(int.Parse(cbxSeletorFilaImportacao.SelectedValue.ToString()), listaUsuarios.ToArray());
                    }


                }

                if (cbxSeletorFilaImportacao.Text.Contains("DLP")) {
                    imp.dlp(txtEnderecoArquivo.Text.ToString(), listaUsuarios.ToArray());
                }


                if (cbxSeletorFilaImportacao.Text.Contains("CADASTRO GERAL")) {
                    imp.CadastroGeralProcedure();
                }

                if (cbxSeletorFilaImportacao.Text.Contains("TRILHAS SGI")) {
                    imp.TrilhasSGI();
                }

                if (cbxSeletorFilaImportacao.Text.Contains("TAMNUN")) {
                    imp.tamnun(listaUsuarios.ToArray());
                }

                carregarListView();
            }

            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - INCLUIR(FORM)");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            try {

                DialogResult resp = MessageBox.Show("Excluir registros terá duas consequências: " + Environment.NewLine +
                                                    " - Em uma nova importação os registros poderão ser disponbilizados outra vez." + Environment.NewLine +
                                                    " - Serão excluídos apenas os registros ainda não trabalhados." + Environment.NewLine + Environment.NewLine +
                                                    "Deseja continuar com a exclusão?", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (resp == DialogResult.Yes) {
                    //Função para excluir
                    importacoes del = new importacoes(int.Parse(txtFilaID.Text), DateTime.Parse(txtDthAbertura.Text), txtIdAbertura.Text);
                    del.excluir(del, int.Parse(txtID.Text));
                    limparForm();
                    carregarListView();

                }

            }
            catch (Exception ex) {
                log.registrarLog(ex.ToString(), "IMPORTACAO - EXCLUIR(FORM)");
            }
        }

        #endregion

        private void lvLista_DoubleClick(object sender, EventArgs e) {
            string id = lvLista.SelectedItems[0].SubItems[0].Text;
            if ((string.IsNullOrEmpty(id)) || (id.ToString() == "0")) {
                MessageBox.Show("Nenhum registro foi selecionado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {

                // Validando se o registro que deseja ser exluído ou finalizado é uma IMPORTAÇÃO
                // se for exclusão ou finalização não se pode permitir esta ação, visto que não terá referencias de registros ligados a estas ações
                // outra validação é se a importação teve volume válido, ou seja, maior que ZERO registros.
                if (lvLista.SelectedItems[0].SubItems[1].Text == "IMPORTACAO" && long.Parse(lvLista.SelectedItems[0].SubItems[5].Text) > 0) {

                    //Carregando campos
                    txtID.Text = lvLista.SelectedItems[0].SubItems[0].Text;
                    txtFilaID.Text = lvLista.SelectedItems[0].SubItems[3].Text;
                    txtFilaNome.Text = lvLista.SelectedItems[0].SubItems[4].Text;
                    txtDthAbertura.Text = lvLista.SelectedItems[0].SubItems[2].Text;
                    txtIdAbertura.Text = lvLista.SelectedItems[0].SubItems[6].Text;

                    //Liberação de botões
                    btnIncluir.Enabled = false;
                    btnFinalizar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnCancelar.Enabled = true;

                    MessageBox.Show("Item selecionado, tome uma das ações dos botões disponíveis abaixo!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);

                } else {
                    MessageBox.Show("AÇÃO de EXLCUÍR ou FINALIZAR necessita dos seguintes critérios: " + Environment.NewLine +
                                                    " - Ter volume válido, ou seja, maior que ZERO registros. " + Environment.NewLine +
                                                    " - Ser ação de IMPORTAÇÃO. " + Environment.NewLine,
                                                    Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //Liberação de botões
                    btnIncluir.Enabled = true;
                    btnFinalizar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnCancelar.Enabled = true;
                }
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e) {
            //Constantes.catEmMassa = true;
            //Constantes.catFilaID = int.Parse(txtFilaID.Text);

            frmCategorizacao objForm = new frmCategorizacao();
            objForm.filaNome = txtFilaNome.Text;
            objForm.filaId = int.Parse(txtFilaID.Text);
            objForm.dataAbertura = DateTime.Parse(txtDthAbertura.Text);
            objForm.idAbertura = txtIdAbertura.Text;
            objForm.finalizacaoMassa = true;
            objForm.id = 0;
            objForm.idImp = int.Parse(txtID.Text);
            hlp.abrirForm(objForm, true, false);

            if (Constantes.finalizacaoOkay) {
                carregarListView();
            }
        }


        private void rbRobos_CheckedChanged(object sender, EventArgs e) {
            if (rbRobos.Checked) {
                cbxSeletorFilaImportacao.Enabled = true;
                txtEnderecoArquivo.Enabled = false;
                btnProcurar.Enabled = false;
                //Carregando combobox
                objFilas.carregarComboboxFilas(this, cbxSeletorFilaImportacao, true);
                txtEnderecoArquivo.Text = "";
            } else {
                cbxSeletorFilaImportacao.Enabled = false;
                txtEnderecoArquivo.Enabled = false;
            }
        }

        private void rbArquivos_CheckedChanged(object sender, EventArgs e) {
            if (rbArquivos.Checked) {
                cbxSeletorFilaImportacao.Enabled = true;
                txtEnderecoArquivo.Enabled = true;
                btnProcurar.Enabled = true;
                //Carregando Combobox
                cbxSeletorFilaImportacao.DataSource = null;
                hlp.carregaComboBoxManualmente("CADASTRO GERAL;DLP;TAMNUN;TRILHAS SGI", this, cbxSeletorFilaImportacao);
                txtEnderecoArquivo.Text = "";
            } else {
                cbxSeletorFilaImportacao.Enabled = false;
                txtEnderecoArquivo.Enabled = false;
            }
        }
        private void cbxSeletorFilaImportacao_SelectionChangeCommitted(object sender, EventArgs e) {
            if (cbxSeletorFilaImportacao.Text.ToString().Contains("DLP")) {
                txtEnderecoArquivo.Enabled = true;
                btnProcurar.Enabled = true;
            } else {
                txtEnderecoArquivo.Enabled = false;
                btnProcurar.Enabled = false;
            }
        }
        private void btnProcurar_Click_1(object sender, EventArgs e) {
            txtEnderecoArquivo.Text = hlp.EnderecoArqCapturar();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            limparForm();
        }
               
    }
}
