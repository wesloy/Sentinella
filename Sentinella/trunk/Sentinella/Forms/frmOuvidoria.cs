using System;
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
    public partial class frmOuvidoria : Form
    {

        #region Variaveis
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        retornoOuvidoria cat = new retornoOuvidoria(); //biblioteca para captura e finalização de casos        
        dadosCadastraisTH d_th = new dadosCadastraisTH(); //informações do funcionário segundo a planilha do TH 
        //string enderecoImagem = "";
        #endregion

        #region funcoes
        private void limparForm()
        {
            hlp.limparCampos(pnlFiltros);
            hlp.limparCampos(pnlConteudo);
            hlp.limparCampos(pnlBotoes);
            hlp.limparCampos(tcDados);            
            dtAdmissao.Text = hlp.retornaDataTextBox("1900-01-01").ToString();
            dtDemissao.Text = hlp.retornaDataTextBox("1900-01-01").ToString();
            dtNascimento.Text = hlp.retornaDataTextBox("1900-01-01").ToString();
            lvManutencoes.Clear();
            lvFaturas.Clear();   
        }
        #endregion


        public frmOuvidoria()
        {
            InitializeComponent();
        }


        private void cbxFiltro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cbxFiltro.Text)
            {
                case "CPF":
                case "PROTOCOLO":
                case "NOME DO ANALISTA":
                    txtInfoBuscado.Enabled = true;
                    break;

            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            bool validacao = false;
            if (cbxFiltro.Text == "" )
            {
                return;
            }

            //Validacoes de segurança
            switch (cbxFiltro.Text)
            {
                case "PROTOCOLO":
                    if (!hlp.validaCamposObrigatorios(pnlFiltros, "txtInfoBuscado"))
                    {
                        return;
                    }
                    else
                    {
                        //Capturando registro para trabalho
                        validacao = cat.bloquearRegistro("", "", ref cat, int.Parse(txtInfoBuscado.Text));
                    }
                    break;

                case "CPF":
                case "NOME DO ANALISTA":
                    if (!hlp.validaCamposObrigatorios(pnlFiltros, "txtInfoBuscado"))
                    {
                        return;
                    }
                    else
                    {
                        //Capturando registro para trabalho
                        validacao = cat.bloquearRegistro(txtInfoBuscado.Text, cbxFiltro.Text, ref cat, 0);
                    }
                    break;

                case "FILA":
                    //Capturando registro para trabalho
                    validacao = cat.bloquearRegistro(txtInfoBuscado.Text, cbxFiltro.Text, ref cat, 5); //5 visto a fila de retorno ter o código 5
                    break;
            }


            //Tratando retorno nulo, que evidencia que não foi bloqueado nenhum registro
            if (cat != null)
            {
                txt_id.Text = cat._id.ToString();
                txt_inicio.Text = cat._hora_Inicial.ToString();
                txt_dataRegistro.Text = cat._data_Registro.ToString();
                cbxFiltro.Enabled = false;
                btnIniciar.Enabled = false;
                //Carregando lista de matrícula e bloqueando componentes necessários
                d_th.carregarComboboxMatriculas(this, cbMatricula, cat._cpf.ToString());
            }

            if (validacao)
            {
                MessageBox.Show("Registro carregado com sucesso!",Constantes.Titulo_MSG,MessageBoxButtons.OK);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txt_id.Text != "")
            {
                DialogResult msg = MessageBox.Show("Deseja abandonar o caso que está trabalhando?", Constantes.Titulo_MSG, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    cat.liberarRegistro(int.Parse(txt_id.Text));
                    limparForm();
                    cbxFiltro.Enabled = true;
                    btnIniciar.Enabled = true;
                }
            }
            else
            {
                limparForm();
                cbxFiltro.Enabled = true;
                btnIniciar.Enabled = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            frmCategorizacao objForm = new frmCategorizacao();
            objForm.id = int.Parse(txt_id.Text);
            objForm.filaId = 5; //Única fila de Retorno da Ouvidoria
            objForm.dataAbertura = DateTime.Parse(txt_inicio.Text);
            hlp.abrirForm(objForm, true, false);

            //Limpando form caso a finalzição aconteceu corretamente..
            if (Constantes.finalizacaoOkay)
            {
                limparForm();
                cbxFiltro.Enabled = true;
                btnIniciar.Enabled = true;
            }
        }

        private void cbMatricula_Leave(object sender, EventArgs e)
        {
            //Carregando os dados do TH
            if (cbMatricula.Text != "" && cbMatricula.Text != "System.Data.DataRowView")
            {
                d_th = d_th.getDadosCadastraisPorMatricula(cbMatricula.Text);
                if (d_th != null)
                {
                    txtNomeAssociado.Text = d_th.Nome_associado.ToString().Trim();
                    //txtSexo.Text = d_th.Sexo.ToString().Trim();
                    txtCpf.Text = d_th.Cpf.ToString().Trim();
                    dtNascimento.Text = hlp.FormataDataAbreviada(hlp.retornaDataTextBox(d_th.Data_de_nascimento).ToString()).ToString();
                    txtNomeEmpresa.Text = d_th.Nome_empresa.ToString().Trim();
                    dtAdmissao.Text = hlp.retornaDataTextBox(d_th.Data_de_admissao.ToString());
                    dtDemissao.Text = hlp.retornaDataTextBox(d_th.Data_demissao.ToString());
                    txtCargoAssociado.Text = d_th.Cargo_do_associado.ToString().Trim();
                    txtResponsavelGH.Text = "G1: " + d_th.gestor_1.ToString().Trim() + " | " +
                                                "G2: " + d_th.gestor_2.ToString().Trim() + " | " +
                                                "G3: " + d_th.gestor_3.ToString().Trim() + " | " +
                                                "G4: " + d_th.gestor_4.ToString().Trim() + " | " +
                                                "G5: " + d_th.gestor_5.ToString().Trim();
                    txtCelular_th.Text = d_th.Celular.ToString().Trim();
                    txtTelefone_th.Text = d_th.Telefone.ToString().Trim();
                    txtEmail.Text = d_th.Email.ToString().Trim();
                    txtCentroCusto.Text = d_th.Codcentro_de_custo.ToString().Trim();
                    txtCentroCustoDescricao.Text = d_th.Descrcentro_de_custo.ToString().Trim();
                    txtEndereco_th.Text = d_th.Rua.ToString().Trim() + " | Nº " + d_th.Numero.ToString().Trim() +
                                            " | BAIRRO: " + d_th.Bairro.ToString().Trim() + " | CIDADE: " + d_th.Cidade.ToString().Trim() +
                                               " | CEP: " + d_th.Cep.ToString().Trim();
                }

                //Carregando os dados do Cartão
                cartoes cards = new cartoes(); //dados de cartões e contas
                cards = cards.getDadosCartaoPorCpfBin(cat._cpf, cat._bin);
                if (cards != null)
                {
                    txtCpf_cb.Text = cards.Cpf.ToString();
                    txtCartao_cb.Text = cards.Cartao.ToString();
                    txtProduto_tp.Text = cards.Produto.ToString();
                    txtBin_cb.Text = cards.Bin.ToString();
                    txtTipoCartao_cb.Text = cards.TipoCartao.ToString();
                    txtBloqueio_cb.Text = cards.Bloqueio.ToString();
                    txtAtivo_cb.Text = cards.Ativo.ToString();
                    txtDesbloqueioInicial_cb.Text = hlp.retornaDataTextBox(cards.Data_Desbloqueio.ToString());
                    txtDataAbertura_cb.Text = hlp.retornaDataTextBox(cards.Data_Abertura_Conta.ToString());
                    txtDataEmissao_cb.Text = hlp.retornaDataTextBox(cards.Data_Desbloqueio.ToString());
                    txtLimiteAtual_cb.Text = cards.Limite_Credito.ToString();
                    txtLimiteAnterior_cb.Text = cards.Limite_Credito_Anterior.ToString();
                    txtLimiteDisponivel_cb.Text = cards.Limite_Credito_Disponivel.ToString();
                    txtLimiteSaque_cb.Text = cards.Limite_Saque.ToString();
                    txtLimiteSaqueDisponivel_cb.Text = cards.Limite_Saque_Disponivel.ToString();
                    txtDataAlteracaoLimite_cb.Text = hlp.retornaDataTextBox(cards.Limite_Data_Alteracao.ToString());
                    txtFonteAlteracaoLimite_cb.Text = cards.Limite_Fonte_Alteracao.ToString();
                    txtEndereco_cb.Text = cards.Endereco.ToString() + " | Nº " + cards.NumResidencial.ToString() + " | CIDADE: " + cards.Cidade.ToString() + " | ESTADO: " + cards.Estado.ToString() + " | CEP: " + cards.Cep.ToString();
                    txtDataAtualizacao_cb.Text = hlp.retornaDataTextBox(cards.DataAtualizacao.ToString());
                }

                dadosCadastraisTelaPreta d_telaPreta = new dadosCadastraisTelaPreta(); //informações do funcionário na tela preta do banco
                d_telaPreta = d_telaPreta.getDadosCadastraisPorCpfBin(cat._cpf, cat._bin);
                if (cards != null)
                {
                    //txtProduto_tp.Text = d_telaPreta.Produto.ToString();
                    txtEnderecoAnterior_tp.Text = d_telaPreta.End_anterior.ToString() + " | CIDADE: " + d_telaPreta.Cidade_anterior.ToString() + " | ESTADO: " + d_telaPreta.Estado_anterior.ToString() + " | CEP: " + d_telaPreta.Cep_anterior.ToString();
                    txtEnderecoCobranca_tp.Text = d_telaPreta.End_cobranca.ToString() + " | CIDADE: " + d_telaPreta.Cidade_cobranca.ToString() + " | ESTADO: " + d_telaPreta.Estado_cobranca.ToString() + " | CEP: " + d_telaPreta.Cep_cobranca.ToString();
                    txtEnderecoCorrespondencia_tp.Text = d_telaPreta.End_correspondencia.ToString() + " | CIDADE: " + d_telaPreta.Cidade_correspondencia.ToString() + " | ESTADO: " + d_telaPreta.Estado_correspondencia.ToString() + " | CEP: " + d_telaPreta.Cep_correspondencia.ToString();
                    txtDataUltAltEnd_tp.Text = hlp.retornaDataTextBox(d_telaPreta.Data_alteracao_End.ToString());
                    txtTelResidencial_tp.Text = d_telaPreta.Tel_residencial.ToString();
                    txtTelEmpresarial_tp.Text = d_telaPreta.Tel_empresa.ToString();
                    txtCelular_tp.Text = d_telaPreta.Tel_celular.ToString();
                    txtDataUltAltTel_tp.Text = d_telaPreta.Data_alteracao_telefones.ToString();

                    txtNomes_tp.Text = "(01) - " + d_telaPreta.Nome.ToString() + " - (02) - " + d_telaPreta.Nome_2.ToString() + " - (03) - " + d_telaPreta.Nome_3.ToString() + " - (04) - " + d_telaPreta.Nome_4.ToString();
                }

                //Carregando Manutenções
                manutencoes man = new manutencoes();
                man.CarregaListView(lvManutencoes, cat._cpf, cat._bin);

                //Carregando Faturas
                faturas fat = new faturas();
                fat.CarregaListView(lvFaturas, cat._cpf, cat._bin);              


            }
        }

        private void cbMatricula_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbMatricula_Leave(sender, e);
        }
    }
}
