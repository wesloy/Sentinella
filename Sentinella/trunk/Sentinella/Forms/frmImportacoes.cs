﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella.Forms
{
    public partial class frmImportacoes : Form
    {
        public frmImportacoes()
        {
            InitializeComponent();
        }

        #region Variaveis        
        filas objFilas = new filas();
        logsImportacoes objLog = new logsImportacoes();
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        importacoes imp = new importacoes();
        importacoesRetornoOuvidoria impOuv = new importacoesRetornoOuvidoria();
        #endregion

        #region funcoes
        private void carregarListView(string filtro = "")
        {
            objLog.CarregaListView(lvLista, filtro);
        }

        private void limparForm(bool limpezaParcial = false)
        {
            if (!limpezaParcial)
            {
                hlp.limparCampos(this);
            }
            else
            {
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


        private void frmImportacoes_Load(object sender, EventArgs e)
        {
            limparForm();
            carregarListView();
        }

        #region Botoes
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            txtEnderecoArquivo.Text = hlp.EnderecoArqCapturar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (hlp.validaCamposObrigatorios(pnlConteudo, "cbxSeletorFilaImportacao"))
                { //validando campo obrigatorio
                    if (rbRobos.Checked)
                    {

                        switch (cbxSeletorFilaImportacao.SelectedValue.ToString())
                        {
                            case "5":
                                impOuv.incluir(int.Parse(cbxSeletorFilaImportacao.SelectedValue.ToString()));
                                break;
                            case "6":
                                imp.incluir(int.Parse(cbxSeletorFilaImportacao.SelectedValue.ToString()), txtEnderecoArquivo.Text.ToString());
                                break;
                            default:
                                imp.incluir(int.Parse(cbxSeletorFilaImportacao.SelectedValue.ToString()));
                                break;
                        }


                    }
                    else
                    {

                        switch (cbxSeletorFilaImportacao.Text.ToString())
                        {

                            case "PLANILHA CADASTRO GERAL":
                                                                
                                if (hlp.validaCamposObrigatorios(pnlConteudo, "txtEnderecoArquivo"))
                                {
                                    //imp.CadastroGeral(txtEnderecoArquivo.Text.ToString());
                                    imp.CadastroGeralConexao(txtEnderecoArquivo.Text.ToString());                                    
                                }
                                break;
                            case "BANCO DE DADOS CADASTRO GERAL":
                                //imp.CadastroGeral(txtEnderecoArquivo.Text.ToString());
                                imp.CadastroGeralProcedure();
                                break;
                        }
                    }


                    carregarListView();
                }
            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "IMPORTACAO - INCLUIR(FORM)");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult resp = MessageBox.Show("Excluir registros terá duas consequências: " + Environment.NewLine +
                                                    " - Em uma nova importação os registros poderão ser disponbilizados outra vez." + Environment.NewLine +
                                                    " - Serão excluídos apenas os registros ainda não trabalhados." + Environment.NewLine + Environment.NewLine +
                                                    "Deseja continuar com a exclusão?", Constantes.Titulo_MSG.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (resp == DialogResult.Yes)
                {
                    //Função para excluir
                    importacoes del = new importacoes(int.Parse(txtFilaID.Text), DateTime.Parse(txtDthAbertura.Text), txtIdAbertura.Text);
                    del.excluir(del, int.Parse(txtID.Text));
                    limparForm();
                    carregarListView();

                }

            }
            catch (Exception ex)
            {
                log.registrarLog(ex.ToString(), "IMPORTACAO - EXCLUIR(FORM)");
            }
        }

        #endregion

        private void lvLista_DoubleClick(object sender, EventArgs e)
        {
            string id = lvLista.SelectedItems[0].SubItems[0].Text;
            if ((string.IsNullOrEmpty(id)) || (id.ToString() == "0"))
            {
                MessageBox.Show("Nenhum registro foi selecionado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                // Validando se o registro que deseja ser exluído ou finalizado é uma IMPORTAÇÃO
                // se for exclusão ou finalização não se pode permitir esta ação, visto que não terá referencias de registros ligados a estas ações
                // outra validação é se a importação teve volume válido, ou seja, maior que ZERO registros.
                if (lvLista.SelectedItems[0].SubItems[1].Text == "IMPORTACAO" && long.Parse(lvLista.SelectedItems[0].SubItems[5].Text) > 0)
                {

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

                }
                else
                {
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

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
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

            if (Constantes.finalizacaoOkay)
            {
                carregarListView();
            }
        }


        private void rbRobos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRobos.Checked)
            {
                cbxSeletorFilaImportacao.Enabled = true;
                txtEnderecoArquivo.Enabled = false;
                btnProcurar.Enabled = false;
                //Carregando combobox
                objFilas.carregarComboboxFilas(this, cbxSeletorFilaImportacao, true);
                txtEnderecoArquivo.Text = "";
            }
            else
            {
                cbxSeletorFilaImportacao.Enabled = false;
                txtEnderecoArquivo.Enabled = false;
            }
        }

        private void rbArquivos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArquivos.Checked)
            {
                cbxSeletorFilaImportacao.Enabled = true;
                txtEnderecoArquivo.Enabled = true;
                btnProcurar.Enabled = true;
                //Carregando Combobox
                cbxSeletorFilaImportacao.DataSource = null;
                hlp.carregaComboBoxManualmente("BANCO DE DADOS CADASTRO GERAL;PLANILHA CADASTRO GERAL", this, cbxSeletorFilaImportacao);
                txtEnderecoArquivo.Text = "";
            }
            else
            {
                cbxSeletorFilaImportacao.Enabled = false;
                txtEnderecoArquivo.Enabled = false;
            }
        }
        private void cbxSeletorFilaImportacao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxSeletorFilaImportacao.Text.ToString() == "DLP")
            {
                txtEnderecoArquivo.Enabled = true;
                btnProcurar.Enabled = true;
            }
            else
            {
                txtEnderecoArquivo.Enabled = false;
                btnProcurar.Enabled = false;
            }
        }
        private void btnProcurar_Click_1(object sender, EventArgs e)
        {
            txtEnderecoArquivo.Text = hlp.EnderecoArqCapturar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparForm();
        }


    }
}
