using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmAnalies : Form {
        public frmAnalies() {
            InitializeComponent();
        }

        #region Variaveis
        Uteis.Helpers hlp = new Uteis.Helpers();
        categorizacoes cat = new categorizacoes(); //biblioteca para captura e finalização de casos        
        dadosCadastraisTH d_th = new dadosCadastraisTH(); //informações do funcionário segundo a planilha do TH 
        string enderecoImagem = "";
        private string cpfAssociado = "";
        #endregion

        private void limparForm() {
            cpfAssociado = "";
            txtPARA.Clear();
            hlp.limparCampos(pnlFiltros);
            hlp.limparCampos(pnlConteudo);
            hlp.limparCampos(pnlBotoes);
            hlp.limparCampos(tcDados);
            lvHistoricoSentinella.Clear();
            lvManutencoes.Clear();
            lvFaturas.Clear();
            lvHistoricoTH.Clear();
            lvHierarquiaSupImediato.Clear();
            lvHierarquiaCadastroGeral.Clear();
            lvInfoAdc.Clear();
            ltvAD.Clear();

            //criando colunas do listView de evidências            
            lvEvidenciasLaudo.Clear();
            lvEvidenciasLaudo.View = View.Details;
            lvEvidenciasLaudo.LabelEdit = false;
            lvEvidenciasLaudo.CheckBoxes = true;
            lvEvidenciasLaudo.GridLines = true;
            lvEvidenciasLaudo.FullRowSelect = true;
            lvEvidenciasLaudo.HideSelection = true;
            lvEvidenciasLaudo.MultiSelect = false;
            lvEvidenciasLaudo.Columns.Add("", 50, HorizontalAlignment.Center);
            lvEvidenciasLaudo.Columns.Add("Nome da Imagem", 250, HorizontalAlignment.Left);
            lvEvidenciasLaudo.Columns.Add("Endereço da Imagem:", 300, HorizontalAlignment.Left);

        }

        private void frmAnalies_Load(object sender, System.EventArgs e) {
            limparForm();
            cat.liberarRegistrosGeralDoUsuarioAtual();
            cat.carregarComboboxFilasComVolumeParaTrabalho(this, cbxFila);


        }

        private void lvInfoAdc_DoubleClick(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            string caminho = "";

            if (cbxFila.Text.Contains("DLP")) {
                caminho = @lvInfoAdc.SelectedItems[0].SubItems[7].Text;
            } else if (cbxFila.Text.Contains("TAMNUN")) {
                caminho = @lvInfoAdc.SelectedItems[0].SubItems[3].Text;
            }

            Clipboard.Clear();
            Clipboard.SetText(caminho);

            this.Cursor = Cursors.Default;
            MessageBox.Show("Endereço: " + Environment.NewLine + caminho + Environment.NewLine + "--COPIADO--", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnIniciar_Click(object sender, System.EventArgs e) {

            if (cbxFila.Text == "NÃO SE APLICA") {
                return;
            }

            //Validando se o campos obrigatórios foram preenchidos
            if (hlp.validaCamposObrigatorios(pnlFiltros, "cbxFila")) {
                string ultMatricula = ""; // capturar a última matrícula do cpf do registro

                Cursor c = Cursors.WaitCursor;

                //Capturando registro para trabalho
                categorizacoes cat = new categorizacoes(); //biblioteca para captura e finalização de casos        
                cat.bloquearRegistro(int.Parse(cbxFila.SelectedValue.ToString()), ref cat);
                //Tratando retorno nulo, que evidencia que não foi bloqueado nenhum registro
                if (cat != null) {

                    cpfAssociado = cat.Cpf;

                    impAssociado imp = new impAssociado();
                    imp = imp.getPorCPFSupImediado(cat.Cpf);

                    txt_id.Text = cat.Id.ToString();
                    txt_inicio.Text = cat.Hora_Inicial.ToString();
                    txt_dataRegistro.Text = cat.Data_Registro.ToString();
                    ultMatricula = d_th.ultimaMatriculaAtivaPorCpf(cat.Cpf.ToString());
                    //Carregando lista de matrícula e bloqueando componentes necessários
                    //d_th.carregarComboboxMatriculas(this, cbMatricula, cat.Cpf.ToString());
                    cbxFila.Enabled = false;
                    btnIniciar.Enabled = false;


                    #region "CARREGANDO INFORMAÇÕES"

                    //carregamento Histórico Sentinella
                    categorizacoes hist = new categorizacoes();
                    hist.CarregaListView(lvHistoricoSentinella, cat.Cpf);

                    //Carregando Histórico TH
                    dadosCadastraisTH th = new dadosCadastraisTH();
                    th.CarregaListView(lvHistoricoTH, cat.Cpf);

                    //Carregando Hierarquia Superior Imediato
                    impAssociado ia = new impAssociado();
                    ia.CarregarListViewGestores(lvHierarquiaSupImediato, cat.Cpf, true);

                    //Carregando Hierarquia Cadastro Geral
                    ia.CarregarListViewGestores(lvHierarquiaCadastroGeral, cat.Cpf, false);



                    if (cbxFila.Text.Contains("DLP")) {
                        //Informações adicionais
                        dlp dlp = new dlp();
                        dlp.CarregaListView(lvInfoAdc, int.Parse(cat.Id.ToString()));
                        lbInfAdicionais.Text = "Informações Adicionais - DPL: ";
                    } else if (cbxFila.Text.Contains("TAMNUN")) {
                        //Informações adicionais
                        tamnun tamnun = new tamnun();
                        tamnun.carregarListViewListaTrabalho(lvInfoAdc, int.Parse(cat.Id.ToString()));
                        lbInfAdicionais.Text = "Informações Adicionais - TAMNUN: ";
                    }


                    //Carregando os dados do Cartão, se BIN for diferente de 000000
                    filas fila = new filas();
                    fila = fila.capturarFilaPorID(int.Parse(cbxFila.SelectedValue.ToString()));

                    if (fila.Grupo.ToString().ToUpper().Equals("BRADESCO")) {
                        tbDadosCartao.Enabled = true;
                        tbManutencoes.Enabled = true;
                        tbFaturas.Enabled = true;
                    } else {
                        tbDadosCartao.Enabled = false;
                        tbManutencoes.Enabled = false;
                        tbFaturas.Enabled = false;
                    }
                    tcDados.Refresh();

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



                    //carregando grupos AD se o mesmo tiver...
                    ad AD = new ad();
                    AD.CarregaListView(ltvAD, imp.Nom_Usuario);


                    #endregion
                }

                c = Cursors.Default;

            }
        }

        private void btnCancelar_Click(object sender, System.EventArgs e) {


            if (!string.IsNullOrEmpty(txt_id.Text)) {
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

        private void btnSalvar_Click(object sender, EventArgs e) {
            frmCategorizacao objForm = new frmCategorizacao();
            if (string.IsNullOrEmpty(txt_id.Text)) {
                MessageBox.Show("Não há nenhum registro sendo trabalhado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
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

        private void lvFaturas_DoubleClick(object sender, System.EventArgs e) {
            frmAutorizacoes objForm = new frmAutorizacoes();
            objForm._dataCorte = DateTime.Parse(lvFaturas.SelectedItems[0].SubItems[1].Text);
            cat = cat.getRegistroPorID(int.Parse(txt_id.Text));

            objForm._cpf = cat.Cpf.ToString();
            objForm._bin = cat.Bin.ToString();
            hlp.abrirForm(objForm, true, false);
        }

        private void btnAdicionarEvidenciaLaudo_Click(object sender, EventArgs e) {

            ListViewItem item = new ListViewItem();
            enderecoImagem = hlp.EnderecoArqCapturar();



            if (enderecoImagem != "") {

                FileInfo fInfo = new FileInfo(enderecoImagem);

                //Carregando Item do listView                
                item.SubItems.Add(fInfo.Name);
                item.SubItems.Add(fInfo.FullName);

                //inserir item no listView
                lvEvidenciasLaudo.Items.Add(item);

            }

            //Limpando variáveis
            enderecoImagem = "";
        }




        #region DECOMISSIADO 01/07/2020 NÃO SERÁ MAIS USADO UM ANEXO COM O LAUDO, MAS SIM NO CORPO DO E-MAIL

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
        //private void btnGerarLaudo_Click(object sender, EventArgs e) {

        ////validação se todos os campos para geração do laudo estão preenchidos
        //string camposValidar;
        //Boolean okay;
        //camposValidar = "";

        //if (lvEvidenciasLaudo.Items.Count <= 0) {
        //    MessageBox.Show("É necessário ter pelo menos 1 evidência cadastrada!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    return;
        //}

        //if (hlp.validaCamposObrigatorios(tbLaudo, camposValidar)) {
        //    this.Cursor = Cursors.WaitCursor;

        //    int totalizador = 0;
        //    string listaEvidencias = "";
        //    List<string> listaReplace = new List<string>();
        //    MalaDiretaWord.AlterarTextosWord word = new MalaDiretaWord.AlterarTextosWord();

        //    //gerando marcadores de evidencias no Word (Substituindo o marcador @listaDeEvidencias)
        //    foreach (ListViewItem item in lvEvidenciasLaudo.Items) {
        //        totalizador += 1; //Incremento a cada looping. Variavel usada para gerar marcadores de evidencias no documento Word.
        //        listaEvidencias += "@evidencia" + totalizador + "\r\n"; //Texto da Evidência
        //        if (item.SubItems[1].Text == "SIM") {
        //            listaEvidencias += "@imagemEvidencia" + totalizador + "\r\n"; //Imagem da Evidência                        
        //        }

        //    }

        //    //---------------------------CAPTURANDO REPLACES---------------------------//  
        //    listaReplace.Add("@listaDeEvidencias;" + listaEvidencias);
        //    listaReplace.Add("@temaDoLaudo;" + txtTemaLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@dataCriacao;" + dtpDataCriacaoLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@diretoria;" + txtDiretoriaLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@gerencia;" + txtGerenciaLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@coordenador;" + txtCoordenacaoLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@supervisor;" + txtSupervisaoLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@operacao;" + txtOperacaoLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@dataOcorrencia;" + dtpDataOcorrencia.Text.Replace(";", ","));
        //    listaReplace.Add("@usuarioBradesco;" + txtIDFerramentaLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@analistaAuditado;" + txtNomeAnalistaLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@produtoCartao;" + txtProdutoLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@sumarioExecutivoDescricao;" + txtSumarioExecutivoLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@cpf;" + txtCPFLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@matricula;" + txtMatriculaLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@dataAdmissao;" + dtpDataAdmissaoLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@area;" + txtAreaLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@cargo;" + txtCargoLaudo.Text.Replace(";", ","));
        //    listaReplace.Add("@resultadoAnalise;" + txtResultadoAnaliseLaudo.Text.Replace(";", ","));

        //    //---------------------------CAPTURANDO EVIDENCIAS---------------------------//      
        //    totalizador = 0;
        //    foreach (ListViewItem item in lvEvidenciasLaudo.Items) {

        //        totalizador += 1; //Incremento a cada looping. Variavel usada para carregar marcadores de evidencias no documento Word.
        //        listaReplace.Add("@evidencia" + totalizador + ";" + item.SubItems[0].Text);
        //        if (item.SubItems[1].Text == "SIM") //Imagem da Evidência
        //        {
        //            listaReplace.Add("@imagemEvidencia" + totalizador + ";" + item.SubItems[2].Text);
        //        }
        //    }

        //    //--------------CAPTURA DO MODELO E FORMATANDO SAIDA DO LAUDO------------------//
        //    string renomeandoArquivo = txt_id.Text;
        //    string enderecoModelo = @Constantes.PATH_MODELOS + "LAUDO.docx";
        //    string enderecoLog = @Constantes.PATH_LOG_IMPORT;


        //    //--------------GERAR O LAUDO-----------------//
        //    okay = word.AlterarTexto(ref enderecoModelo, listaReplace, false, true, renomeandoArquivo, enderecoLog);
        //    enderecoLaudo = enderecoModelo;

        //    if (okay) {

        //        //Habilitando possibilidade de envio por e-mail para a Ouvidoria
        //        btnEnviarLaudo.Enabled = true;

        //        string arquivo = System.IO.Path.GetFileName(enderecoModelo);
        //        int protocolo;
        //        //Tratando situação de abertura de laudos manuais
        //        if (txt_id.Text == "") { protocolo = 0; } else { protocolo = int.Parse(txt_id.Text); }

        //        laudo obj = new laudo(
        //            protocolo,
        //            System.IO.Path.GetFileName(enderecoModelo),
        //            System.IO.Path.GetFullPath(enderecoModelo),
        //            hlp.dataAbreviada(),
        //            txtSumarioExecutivoLaudo.Text,
        //            txtResultadoAnaliseLaudo.Text
        //            );

        //        obj.registrarLaudo(obj);


        //        MessageBox.Show("Laudo Concluído com Sucesso!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    } else {
        //        MessageBox.Show("Laudo Concluído com Falha!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }

        //    this.Cursor = Cursors.Default;

        //}
        //}

        #endregion

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

        private void cbxModeloEmail_SelectedValueChanged(object sender, EventArgs e) {
            laudo modeloEmail = new laudo();

            string[] email = new string[3];

            if (txt_id.Text == "" || txt_id.Text == "0") {
                MessageBox.Show("Não existe um registro sendo trabalhado, não é possivel carregar o modelo de laudo sem um registro sendo analisado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (cbxModeloEmail.Text) {

                case "BRADESCO BÁSICO":
                    email = modeloEmail.bradescoSimples(int.Parse(txt_id.Text));
                    txtTituloEmail.Text = email[0];
                    txtCorpoEmail.Text = email[1] + email[2];
                    break;

                case "BRADESCO DETALHADO":
                    MessageBox.Show("Em desenvolvimento!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "DLP":
                    email = modeloEmail.dlp(int.Parse(txt_id.Text));
                    txtTituloEmail.Text = email[0];
                    txtCorpoEmail.Text = email[1] + email[2];
                    break;

                case "TAMNUN":
                    email = modeloEmail.tamnun(int.Parse(txt_id.Text));
                    txtTituloEmail.Text = email[0];
                    txtCorpoEmail.Text = email[1] + email[2];
                    break;

            }

            if (cbxModeloEmail.Text != "") {
                txtPARA.Text = "ouvidoria@algar.com.br";               

            }

        }

        private void btnAbrir_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in lvEvidenciasLaudo.Items) {

                if (item.Checked) {
                    hlp.abrirArquivo(item.SubItems[2].Text);
                    break;
                }
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in lvEvidenciasLaudo.Items) {

                if (item.Checked) {
                    item.Remove();
                }
            }
        }

        private void btnEnviarLaudo_Click_1(object sender, EventArgs e) {

            //Validações
            if (lvEvidenciasLaudo.Items.Count == 0) {
                MessageBox.Show("Para que um e-mail/laudo seja enviado é necessário ao menos 1 evidência!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (txtTituloEmail.Text == "" || txtCorpoEmail.Text == "" || txtPARA.Text == "") {
                MessageBox.Show("Para enviar um e-mail é necessário o endereço PARA quem será enviado, Título e Corpo!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            //Criando o e-mail
            email_dynamics.email_dynamics email = new email_dynamics.email_dynamics();

            email.Assunto = txtTituloEmail.Text;
            email.Mensagem = txtCorpoEmail.Text + "." + Environment.NewLine;

            //Para
            List<string> para = new List<string>();
            string txtPara = txtPARA.Text;
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
            foreach (ListViewItem item in lvEvidenciasLaudo.Items) { listaAnexos.Add(item.SubItems[2].Text); }
            email.Anexos = listaAnexos;

            if (email.envio(email.Assunto, email.Mensagem, email.Para, email.Cc, email.CcO, email.Anexos)) {
                MessageBox.Show("Envio com sucesso!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Registrando o envio do e-mail laudo na base
                cat.registrarEmailLaudoEnviado(int.Parse(txt_id.Text), txtTituloEmail.Text);
                //limpando dados do form de envio
                cbxModeloEmail.Text = "";
                txtTituloEmail.Text = "";
                txtCorpoEmail.Text = "";
                foreach (ListViewItem item in lvEvidenciasLaudo.Items) { item.Remove(); }
            } else {
                MessageBox.Show("Falha no envio!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
