using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmAnalies : Form {
        public frmAnalies() {
            InitializeComponent();
        }

        #region Variaveis
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        categorizacoes cat = new categorizacoes(); //biblioteca para captura e finalização de casos        
        dadosCadastraisTH d_th = new dadosCadastraisTH(); //informações do funcionário segundo a planilha do TH 
        string enderecoImagem = "";
        string enderecoLaudo = "";
        #endregion

        private void limparForm() {
            hlp.limparCampos(pnlFiltros);
            hlp.limparCampos(pnlConteudo);
            hlp.limparCampos(pnlBotoes);
            hlp.limparCampos(tcDados);
            lvManutencoes.Clear();
            lvFaturas.Clear();
            lvHistoricoTH.Clear();
            lvInfoAdc.Clear();

            //criando colunas do listView de evidências            
            lvEvidenciasLaudo.Clear();
            lvEvidenciasLaudo.View = View.Details;
            lvEvidenciasLaudo.LabelEdit = false;
            lvEvidenciasLaudo.CheckBoxes = true;
            lvEvidenciasLaudo.GridLines = true;
            lvEvidenciasLaudo.FullRowSelect = true;
            lvEvidenciasLaudo.HideSelection = true;
            lvEvidenciasLaudo.MultiSelect = false;
            lvEvidenciasLaudo.Columns.Add("Descrição Evidência:", 200, HorizontalAlignment.Left);
            lvEvidenciasLaudo.Columns.Add("Possui Imagem?", 150, HorizontalAlignment.Center);
            lvEvidenciasLaudo.Columns.Add("Endereço da Imagem:", 300, HorizontalAlignment.Left);
        }

        private void frmAnalies_Load(object sender, System.EventArgs e) {
            limparForm();
            cat.carregarComboboxFilasComVolumeParaTrabalho(this, cbxFila);


        }

        private void btnIniciar_Click(object sender, System.EventArgs e) {

            if (cbxFila.Text == "NÃO SE APLICA") {
                return;
            }

            //Validando se o campos obrigatórios foram preenchidos
            if (hlp.validaCamposObrigatorios(pnlFiltros, "cbxFila")) {
                string ultMatricula = ""; // capturar a última matrícula do cpf do registro
                //Capturando registro para trabalho
                cat.bloquearRegistro(int.Parse(cbxFila.SelectedValue.ToString()), ref cat);
                //Tratando retorno nulo, que evidencia que não foi bloqueado nenhum registro
                if (cat != null) {

                    txt_id.Text = cat.Id.ToString();
                    txt_inicio.Text = cat.Hora_Inicial.ToString();
                    txt_dataRegistro.Text = cat.Data_Registro.ToString();
                    ultMatricula = d_th.ultimaMatriculaAtivaPorCpf(cat.Cpf.ToString());
                    //Carregando lista de matrícula e bloqueando componentes necessários
                    //d_th.carregarComboboxMatriculas(this, cbMatricula, cat.Cpf.ToString());
                    cbxFila.Enabled = false;
                    btnIniciar.Enabled = false;


                    #region "CARREGANDO INFORMAÇÕES"


                    //Carregando Histórico TH
                    dadosCadastraisTH th = new dadosCadastraisTH();
                    th.CarregaListView(lvHistoricoTH, cat.Cpf);

                    //Informações adicionais
                        dlp dlp = new dlp();
                        dlp.CarregaListView(lvInfoAdc, int.Parse(cat.Id.ToString()));



                    //Carregando os dados do Cartão, se BIM for diferente de 000000
                    if (cat.Bin != "000000") {

                        cartoes cards = new cartoes(); //dados de cartões e contas
                        cards = cards.getDadosCartaoPorCpfBin(cat.Cpf, cat.Bin);
                        if (cards != null) {
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
                        d_telaPreta = d_telaPreta.getDadosCadastraisPorCpfBin(cat.Cpf, cat.Bin);
                        if (cards != null) {
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
                        man.CarregaListView(lvManutencoes, cat.Cpf, cat.Bin);

                        //Carregando Faturas
                        faturas fat = new faturas();
                        fat.CarregaListView(lvFaturas, cat.Cpf, cat.Bin);
                    }


                    //Carregando Laudo
                    d_th = d_th.getDadosCadastraisPorMatricula(ultMatricula);

                    if (d_th.Id != 0) {
                        dtpDataOcorrencia.Text = hlp.retornaDataTextBox(txt_dataRegistro.Text).ToString();
                        txtNomeAnalistaLaudo.Text = d_th.Nome_associado.ToString().Trim();
                        txtCPFLaudo.Text = d_th.Cpf.ToString().Trim();
                        dtpDataAdmissaoLaudo.Text = hlp.retornaDataTextBox(d_th.Data_de_admissao.ToString());
                        txtIDFerramentaLaudo.Text = d_th.Ub.ToString().Replace("A", "UB");
                        txtAreaLaudo.Text = d_th.Descrcentro_de_custo.ToString();
                        txtOperacaoLaudo.Text = d_th.Descrcentro_de_custo.ToString();
                        txtProdutoLaudo.Text = txtProduto_tp.Text;
                        dtpDataCriacaoLaudo.Text = hlp.retornaDataTextBox(hlp.dataAbreviada());
                        txtCargoLaudo.Text = d_th.Cargo_do_associado.ToString().Trim();
                        txtSupervisaoLaudo.Text = d_th.gestor_1.ToString().Trim();
                        txtCoordenacaoLaudo.Text = d_th.gestor_2.ToString().Trim();
                        txtGerenciaLaudo.Text = d_th.gestor_3.ToString().Trim();
                        txtDiretoriaLaudo.Text = d_th.gestor_4.ToString().Trim();
                    }


                    #endregion
                }

            }
        }

        private void btnCancelar_Click(object sender, System.EventArgs e) {

            if (txt_id.Text != "") {
                DialogResult msg = MessageBox.Show("Deseja abandonar o caso que está trabalhando?", Constantes.Titulo_MSG, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes) {
                    cat.liberarRegistro(int.Parse(txt_id.Text));
                    limparForm();
                    cbxFila.Enabled = true;
                    btnIniciar.Enabled = true;
                }
            } else {
                limparForm();
                cbxFila.Enabled = true;
                btnIniciar.Enabled = true;
                btnEnviarLaudo.Enabled = false;
            }

        }


        private void lvFaturas_DoubleClick(object sender, System.EventArgs e) {
            frmAutorizacoes objForm = new frmAutorizacoes();
            objForm._dataCorte = DateTime.Parse(lvFaturas.SelectedItems[0].SubItems[1].Text);
            objForm._cpf = cat.Cpf.ToString();
            objForm._bin = cat.Bin.ToString();
            hlp.abrirForm(objForm, true, false);
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            frmCategorizacao objForm = new frmCategorizacao();
            objForm.id = int.Parse(txt_id.Text);
            objForm.filaId = int.Parse(cbxFila.SelectedValue.ToString());
            objForm.dataAbertura = DateTime.Parse(txt_inicio.Text);
            hlp.abrirForm(objForm, true, false);

            //Limpando form caso a finalzição aconteceu corretamente..
            if (Constantes.finalizacaoOkay) {

                limparForm();
                cbxFila.Enabled = true;
                btnIniciar.Enabled = true;
            }
        }

        private void btnLocalizarImagemLaudo_Click(object sender, EventArgs e) {
            enderecoImagem = hlp.EnderecoArqCapturar();
        }

        private void btnAdicionarEvidenciaLaudo_Click(object sender, EventArgs e) {
            ListViewItem item = new ListViewItem();
            string existeImagem = "NÃO";

            if (hlp.validaCamposObrigatorios(tbLaudo, "txtEvidenciaLaudo")) {

                if (enderecoImagem != "") { existeImagem = "SIM"; } else { existeImagem = "NÃO"; }

                //Carregando Item do listView
                item.Text = txtEvidenciaLaudo.Text.Replace(";", ",");
                item.SubItems.Add(existeImagem);
                item.SubItems.Add(enderecoImagem);

                //inserir item no listView
                lvEvidenciasLaudo.Items.Add(item);

                //Limpando variáveis
                enderecoImagem = "";
                txtEvidenciaLaudo.Text = "";
            }
        }

        /// <summary>
        /// Primeiro passo é criar lista de REPLACE dos marcadores pelo texto final
        /// Trabalhando com a subtituição do marcador @listaDeEvidencias para a qtde de evidencias e imagens do laudo atual (Itens do ListView)
        /// Em seguida fazer a montagem do DE/PARA
        /// Capturar o LAUDO Modelo do diretório de modelos do SENTINELLA
        /// Apontar cópia do Laudo Finalizado para diretório de LAUDOS CRIADOS PELO SENTINELLA
        /// Renomear arquivo com prefixo contendo o PROTOCOLO do Sentinella, facilitando a busca futura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGerarLaudo_Click(object sender, EventArgs e) {

            //validação se todos os campos para geração do laudo estão preenchidos
            string camposValidar;
            Boolean okay;
            camposValidar = "txtTemaLaudo;dtpDataOcorrencia;txtNomeAnalistaLaudo;txtCPFLaudo;dtpDataAdmissaoLaudo;txtCargoLaudo;txtMatriculaLaudo;txtIDFerramentaLaudo;txtAreaLaudo;txtOperacaoLaudo;txtSupervisaoLaudo;txtCoordenacaoLaudo;txtGerenciaLaudo;txtDiretoriaLaudo;txtProdutoLaudo;dtpDataCriacaoLaudo;txtSumarioExecutivoLaudo;txtResultadoAnaliseLaudo";

            if (lvEvidenciasLaudo.Items.Count <= 0) {
                MessageBox.Show("É necessário ter pelo menos 1 evidência cadastrada!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (hlp.validaCamposObrigatorios(tbLaudo, camposValidar)) {
                this.Cursor = Cursors.WaitCursor;

                int totalizador = 0;
                string listaEvidencias = "";
                List<string> listaReplace = new List<string>();
                MalaDiretaWord.AlterarTextosWord word = new MalaDiretaWord.AlterarTextosWord();

                //gerando marcadores de evidencias no Word (Substituindo o marcador @listaDeEvidencias)
                foreach (ListViewItem item in lvEvidenciasLaudo.Items) {
                    totalizador += 1; //Incremento a cada looping. Variavel usada para gerar marcadores de evidencias no documento Word.
                    listaEvidencias += "@evidencia" + totalizador + "\r\n"; //Texto da Evidência
                    if (item.SubItems[1].Text == "SIM") {
                        listaEvidencias += "@imagemEvidencia" + totalizador + "\r\n"; //Imagem da Evidência                        
                    }

                }

                //---------------------------CAPTURANDO REPLACES---------------------------//  
                listaReplace.Add("@listaDeEvidencias;" + listaEvidencias);
                listaReplace.Add("@temaDoLaudo;" + txtTemaLaudo.Text.Replace(";", ","));
                listaReplace.Add("@dataCriacao;" + dtpDataCriacaoLaudo.Text.Replace(";", ","));
                listaReplace.Add("@diretoria;" + txtDiretoriaLaudo.Text.Replace(";", ","));
                listaReplace.Add("@gerencia;" + txtGerenciaLaudo.Text.Replace(";", ","));
                listaReplace.Add("@coordenador;" + txtCoordenacaoLaudo.Text.Replace(";", ","));
                listaReplace.Add("@supervisor;" + txtSupervisaoLaudo.Text.Replace(";", ","));
                listaReplace.Add("@operacao;" + txtOperacaoLaudo.Text.Replace(";", ","));
                listaReplace.Add("@dataOcorrencia;" + dtpDataOcorrencia.Text.Replace(";", ","));
                listaReplace.Add("@usuarioBradesco;" + txtIDFerramentaLaudo.Text.Replace(";", ","));
                listaReplace.Add("@analistaAuditado;" + txtNomeAnalistaLaudo.Text.Replace(";", ","));
                listaReplace.Add("@produtoCartao;" + txtProdutoLaudo.Text.Replace(";", ","));
                listaReplace.Add("@sumarioExecutivoDescricao;" + txtSumarioExecutivoLaudo.Text.Replace(";", ","));
                listaReplace.Add("@cpf;" + txtCPFLaudo.Text.Replace(";", ","));
                listaReplace.Add("@matricula;" + txtMatriculaLaudo.Text.Replace(";", ","));
                listaReplace.Add("@dataAdmissao;" + dtpDataAdmissaoLaudo.Text.Replace(";", ","));
                listaReplace.Add("@area;" + txtAreaLaudo.Text.Replace(";", ","));
                listaReplace.Add("@cargo;" + txtCargoLaudo.Text.Replace(";", ","));
                listaReplace.Add("@resultadoAnalise;" + txtResultadoAnaliseLaudo.Text.Replace(";", ","));

                //---------------------------CAPTURANDO EVIDENCIAS---------------------------//      
                totalizador = 0;
                foreach (ListViewItem item in lvEvidenciasLaudo.Items) {

                    totalizador += 1; //Incremento a cada looping. Variavel usada para carregar marcadores de evidencias no documento Word.
                    listaReplace.Add("@evidencia" + totalizador + ";" + item.SubItems[0].Text);
                    if (item.SubItems[1].Text == "SIM") //Imagem da Evidência
                    {
                        listaReplace.Add("@imagemEvidencia" + totalizador + ";" + item.SubItems[2].Text);
                    }
                }

                //--------------CAPTURA DO MODELO E FORMATANDO SAIDA DO LAUDO------------------//
                string renomeandoArquivo = txt_id.Text;
                string enderecoModelo = @Constantes.PATH_MODELOS + "LAUDO.docx";
                string enderecoLog = @Constantes.PATH_LOG_IMPORT;


                //--------------GERAR O LAUDO-----------------//
                okay = word.AlterarTexto(ref enderecoModelo, listaReplace, false, true, renomeandoArquivo, enderecoLog);
                enderecoLaudo = enderecoModelo;

                if (okay) {

                    //Projeto de salvar as imagens no banco de dados interrompido devido necessidad e alteração na classe de conexão com o banco

                    //Bitmap imagem;
                    //List<Bitmap> imagens_evidencias = new List<Bitmap>();
                    //List<string> descricao_evidencias = new List<string>();

                    ////salvar laudo no SQL
                    //foreach (ListViewItem item in lvEvidenciasLaudo.Items)
                    //{
                    //    if (item.SubItems[1].Text == "SIM")
                    //    {
                    //        imagem = new Bitmap(item.SubItems[2].Text); //carregando lista de imagens para salvar o laudo em sql
                    //        imagens_evidencias.Add(imagem);
                    //    } else
                    //    {
                    //        imagem = new Bitmap(Constantes.PATH_MODELOS + "sem_imagem.jpg"); //carregando lista de imagens para salvar o laudo em sql
                    //        imagens_evidencias.Add(imagem);
                    //    }                  
                    //    descricao_evidencias.Add(item.SubItems[0].Text);
                    //}

                    //Habilitando possibilidade de envio por e-mail para a Ouvidoria
                    btnEnviarLaudo.Enabled = true;

                    string arquivo = System.IO.Path.GetFileName(enderecoModelo);
                    int protocolo;
                    //Tratando situação de abertura de laudos manuais
                    if (txt_id.Text == "") { protocolo = 0; } else { protocolo = int.Parse(txt_id.Text); }

                    laudo obj = new laudo(
                        protocolo,
                        System.IO.Path.GetFileName(enderecoModelo),
                        System.IO.Path.GetFullPath(enderecoModelo),
                        hlp.dataAbreviada(),
                        txtSumarioExecutivoLaudo.Text,
                        txtResultadoAnaliseLaudo.Text
                        );

                    obj.registrarLaudo(obj);


                    MessageBox.Show("Laudo Concluído com Sucesso!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("Laudo Concluído com Falha!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                this.Cursor = Cursors.Default;

            }
        }

        private void lvEvidenciasLaudo_DoubleClick(object sender, EventArgs e) {
            ListViewItem item;
            DialogResult dialogResult = MessageBox.Show("Deseja deletar a evidência?", Constantes.Titulo_MSG, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.OK) {
                for (int i = lvEvidenciasLaudo.SelectedItems.Count - 1; i >= 0; i--) {
                    item = lvEvidenciasLaudo.SelectedItems[i];
                    lvEvidenciasLaudo.Items[item.Index].Remove();
                }
            }
        }

        private void lbTeste_DoubleClick(object sender, EventArgs e) {
            //Carregando Laudo        
            txtTemaLaudo.Text = "Tema Laudo";
            txtNomeAnalistaLaudo.Text = "Nome Analista";
            txtCPFLaudo.Text = "052.052.052-09";
            txtIDFerramentaLaudo.Text = "A000000";
            txtAreaLaudo.Text = "ÁREA";
            txtOperacaoLaudo.Text = "OPERAÇÃO";
            txtProdutoLaudo.Text = "PRODUTO";
            txtMatriculaLaudo.Text = "007007";
            txtCargoLaudo.Text = "CARGO";
            txtSupervisaoLaudo.Text = "SUPERVISÃO";
            txtCoordenacaoLaudo.Text = "COORDENADOR";
            txtGerenciaLaudo.Text = "GERENTE";
            txtDiretoriaLaudo.Text = "DIRETOR";
            txtSumarioExecutivoLaudo.Text = "No dia 13/06/2018 foi identificado um registro no sistema do Bradesco Cartões – Service View, pelo usuário UB089527 pertencente ao atendente Wellysson de Arruda Magalhaes. O atendente Wellysson de Arruda Magalhaes possui permissão de acesso controlada pelo cliente Bradesco Cartões para efetivar manutenções/ registros, porém o cartão Elo Nacional não é atendido pela central da Algar Tech, onde possui seu vínculo empregatício. O registro consta no cartão da bandeira Elo Nacional, qual pertence ao atendente Wellysson de Arruda Magalhaes, onde o mesmo acessou o cartão e realizou o registro de tarefa.";
            txtResultadoAnaliseLaudo.Text = "Devido ao desacordo as Políticas de Segurança da Informação e por ferir o Código de Conduta da Algar Tech, o atendente Wellysson de Arruda Magalhaes infringiu as normas ao acessar seu cartão no sistema Bradesco Cartões – Service View. A evidência acima indicada leva a adoção das medidas disciplinares cabíveis, prevista em nossas políticas e procedimentos, a fim de garantir o cumprimento das normas bem como evitar reincidências.";
            txtEvidenciaLaudo.Text = "13/06/2018 – 11h51min - Tela do sistema cliente Bradesco Cartões - Service View, onde consta o registro do UB089527 pertencente ao atendente Wellysson de Arruda Magalhaes, onde consta que atendente acessou seu cartão e realizou o registro de tarefa.";
        }

        private void btnEnviarLaudo_Click(object sender, EventArgs e) {
            email_dynamics.email_dynamics email = new email_dynamics.email_dynamics();

            email.Assunto = "LAUDO - " + txtNomeAnalistaLaudo.Text;
            email.Mensagem = "Envio automático de laudo de não conformidade, com tema: " + txtTemaLaudo.Text + "." + Environment.NewLine;
            email.Mensagem += "Laudo produzido por: " + Constantes.nomeAssociadoLogado.ToUpper() + Environment.NewLine + Environment.NewLine;

            //Para
            List<string> para = new List<string>();
            string txtPara = "ouvidoria@algartech.com.br";
            string[] _para = txtPara.Split(';');
            foreach (var item in _para) { para.Add(item); }
            email.Para = para;

            //CC
            List<string> cc = new List<string>();
            string txtCC = "si@algartech.com";
            string[] _cc = txtCC.Split(';');
            foreach (var item in _cc) { cc.Add(item); }
            email.Cc = cc;

            //CCo
            List<string> ccO = new List<string>();
            string txtCCo = "";
            string[] _ccO = txtCCo.Split(';');
            foreach (var item in _ccO) { ccO.Add(item); }
            email.CcO = ccO;

            //Carregando os anexos
            List<string> listaAnexos = new List<string>();
            listaAnexos.Add(enderecoLaudo);
            //foreach (string file in lbAnexos.Items) { listaAnexos.Add(file); }
            email.Anexos = listaAnexos;

            if (email.envio(email.Assunto, email.Mensagem, email.Para, email.Cc, email.CcO, email.Anexos)) {
                MessageBox.Show("Envio com sucesso!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                MessageBox.Show("Falha no envio!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void lvInfoAdc_DoubleClick(object sender, EventArgs e) {
            if (cbxFila.Text.Contains("DLP")) {

                this.Cursor = Cursors.WaitCursor;

                try {
                    System.Diagnostics.Process.Start(@lvInfoAdc.SelectedItems[0].SubItems[6].Text);
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex) {

                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Acesso Negado \n" + ex.ToString(), Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
        }
    }
}
