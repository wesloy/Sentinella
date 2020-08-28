using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmClassificacaoDocumentos : Form {

        #region VARIAVEIS
        Uteis.Helpers hlp = new Uteis.Helpers();
        ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        #endregion


        #region FUNCOES
        private void limparform(bool parcial = false) {
            if (!parcial) {
                hlp.limparCampos(this);
                lvDocumentos.Clear();
                lbEnderecoPesquisado.Text = "Não Informado";
                lbReferencia.Text = "00";
            } else {
                lbReferencia.Text = "00";
                txtDiretorioPrincipal.Clear();
                txtNomeArquivo.Clear();
                txtExtensao.Clear();
                txtEnderecoCompleto.Clear();
                txtDataCriacao.Clear();
                txtDataModificacao.Clear();
                txtDataUltimoAcesso.Clear();
                cbxConformidade.Text = "";
                txtObservacoes.Clear();
            }

        }
        #endregion


        public frmClassificacaoDocumentos() {
            InitializeComponent();
        }


        private void btBuscar_Click(object sender, EventArgs e) {


            //listar os arquivos de um diretório que o analista escolher
            //com ou sem as subpastas

            //validar se foi escolhido apenas diretório ou diretório + subpastas
            if (!rbDiretorio.Checked && !rbDiretorioSubpastas.Checked) {
                MessageBox.Show("Deve ser escolhido uma das formas de listagem dos arquivos: " + Environment.NewLine + "Apenas Diretório ou Diretório e Subpastas", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                lbEnderecoPesquisado.Text = folderBrowserDialog.SelectedPath;
                classificacaoDocumentos cd = new classificacaoDocumentos();

                if (cd.carregarListview(lvDocumentos, lbEnderecoPesquisado.Text, rbDiretorioSubpastas.Checked)) {

                    //criando referência para facilitar a localização do registro qdo for fazer a categorização
                    //não é possível fazer na bll já que a própria função se referencia criando um looping que zera os valores
                    int referencia = 0;
                    foreach (ListViewItem itemRow in lvDocumentos.Items) {
                        referencia += 1;
                        itemRow.SubItems[0].Text = referencia.ToString();
                    }

                    MessageBox.Show("Arquivos carregados com sucesso!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void frmClassificacaoDocumentos_Load(object sender, EventArgs e) {
            limparform();
        }

        private void lvDocumentos_ColumnClick(object sender, ColumnClickEventArgs e) {

            //ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter(); <<<<<<<<<<<< declarado no escopo principal do form
            this.lvDocumentos.ListViewItemSorter = lvwColumnSorter;

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
            this.lvDocumentos.Sort();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            limparform();
        }

        private void lvDocumentos_DoubleClick(object sender, EventArgs e) {

            string id = lvDocumentos.SelectedItems[0].SubItems[0].Text;
            if ((string.IsNullOrEmpty(id)) || (id.ToString() == "0")) {
                MessageBox.Show("Nenhum registro foi selecionado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                lbReferencia.Text = lvDocumentos.SelectedItems[0].SubItems[0].Text;
                txtDiretorioPrincipal.Text = lvDocumentos.SelectedItems[0].SubItems[1].Text;
                txtNomeArquivo.Text = lvDocumentos.SelectedItems[0].SubItems[2].Text;
                txtExtensao.Text = lvDocumentos.SelectedItems[0].SubItems[3].Text;
                txtEnderecoCompleto.Text = lvDocumentos.SelectedItems[0].SubItems[4].Text;
                txtDataCriacao.Text = lvDocumentos.SelectedItems[0].SubItems[5].Text;
                txtDataModificacao.Text = lvDocumentos.SelectedItems[0].SubItems[6].Text;
                txtDataUltimoAcesso.Text = lvDocumentos.SelectedItems[0].SubItems[7].Text;
                cbxConformidade.Text = lvDocumentos.SelectedItems[0].SubItems[8].Text;
                txtObservacoes.Text = lvDocumentos.SelectedItems[0].SubItems[9].Text;

                //abrindo o arquivo
                //hlp.abrirArquivo(lvDocumentos.SelectedItems[0].SubItems[4].Text);

            }

        }

        private void btnExcluirRegistros_Click(object sender, EventArgs e) {

            int contador = 0;

            //excluir registros que não são pertinentes a análise
            DialogResult result = MessageBox.Show("Tem certeza que deseja excluir da lista de análise, todos os itens marcados? " + Environment.NewLine + Environment.NewLine,
                                                    Constantes.Titulo_MSG, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK) {

                int barraContagem = 0;
                frmProgressBar barra = new frmProgressBar(lvDocumentos.Items.Count);
                barra.Show();

                foreach (ListViewItem item in lvDocumentos.Items) {
                    if (item.Checked) {
                        item.Remove();
                        contador += 1;
                    }
                    barraContagem += 1;
                    barra.atualizarBarra(barraContagem);
                }
                barra.Close();
            }

            if (contador == 0) {
                MessageBox.Show("Não havia registros selecionados para serem deletados!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else if (contador == 1) {
                MessageBox.Show("Foi deletado " + contador + " registro", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                MessageBox.Show("Foram deletados " + contador + " registros", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnIncluirAnalise_Click(object sender, EventArgs e) {
            if (lbReferencia.Text == "00") {
                MessageBox.Show("Não há registro para ser categorizado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {

                if (cbxConformidade.Text == "NÃO ANALISADO") {
                    MessageBox.Show("Para salvar o registro é necessário informar se é CONFORME ou NÃO CONFORME.", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (ListViewItem item in lvDocumentos.Items) {
                    // Identificando o registro a ser atualizado
                    if (lvDocumentos.SelectedItems[0].SubItems[0].Text.Equals(lbReferencia.Text)) {
                        lvDocumentos.SelectedItems[0].SubItems[8].Text = cbxConformidade.Text;
                        lvDocumentos.SelectedItems[0].SubItems[9].Text = txtObservacoes.Text;
                        lvDocumentos.SelectedItems[0].SubItems[10].Text = Constantes.nomeAssociadoLogado;
                        lvDocumentos.SelectedItems[0].SubItems[11].Text = hlp.dataAbreviada().ToShortDateString();

                        lvDocumentos.SelectedItems[0].ForeColor = Color.Red;

                        limparform(true);
                        MessageBox.Show("Registro Salvo", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void linkLabel_abrirArquivo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (txtEnderecoCompleto.Text != "") {
                hlp.abrirArquivo(txtEnderecoCompleto.Text);
            } else {
                MessageBox.Show("Não há um arquivo indicado para ser aberto!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e) {

            //PROTOCOLO = formado por yyyymmddhhmmss + nome analista
            string protocolo = hlp.dataHoraAtual().ToString("yyyyMMddHHmmss") + Constantes.nomeAssociadoLogado.Replace(" ", "");

            foreach (ListViewItem item in lvDocumentos.Items) {
                classificacaoDocumentos cd = new classificacaoDocumentos(
                        _protocoloAnalise: protocolo,
                        _diretorioPrincipal: item.SubItems[1].Text,
                        _nomeArquivo: item.SubItems[2].Text,
                        _extensao: item.SubItems[3].Text,
                        _enderecoCompleto: item.SubItems[4].Text,
                        _dataCriacao: DateTime.Parse(item.SubItems[5].Text),
                        _dataModificacao: DateTime.Parse(item.SubItems[6].Text),
                        _dataUltimoAcesso: DateTime.Parse(item.SubItems[7].Text),
                        _analise: item.SubItems[8].Text,
                        _observacoes: item.SubItems[9].Text,
                        _analista: item.SubItems[10].Text,                        
                        _dataAnalise: DateTime.Parse(item.SubItems[11].Text)
                    );
                cd.salvarRegistro(cd);
            }

            limparform();
            MessageBox.Show("Registros salvos!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelarAnalise_Click(object sender, EventArgs e) {
            limparform(true);
        }
    }
}