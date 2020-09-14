using System;
using System.Collections.Generic;
using System.Data;
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
        DataTable dt_publico = new DataTable();
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
            lbTotalRegistros.Text = "Total de registros: 000";
        }

        private void btnBuscar_Click(object sender, EventArgs e) {

            try {

                Cursor.Current = Cursors.WaitCursor;
                relatorios rel = new relatorios();


                if (tb_selecaoFuncao.SelectedIndex == 0) {

                    dt_publico = null;

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

                    dt_publico = null;

                    if (cbxCampoFiltroGAP.Text == "" || cbxValorBuscaGAP.Text == "") {
                        MessageBox.Show("É necessário selecionar o campo a ser filtrado E preencher um valor de busca!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    //Carregando informações
                    dt_publico = _ad.listarGruposAssociadosPastas(cbxPastas.Checked, cbxCampoFiltroGAP.Text, cbxValorBuscaGAP.Text);
                    dgvInfoAD.DataSource = dt_publico;

                    List<string> colunas = new List<string>();
                    foreach (DataGridViewTextBoxColumn item in dgvInfoAD.Columns) {
                        colunas.Add(item.Name.ToString());
                    }


                    cbxCamposFiltros.DataSource = colunas;

                }



                lbTotalRegistros.Text = "Total de registros: " + dgvInfoAD.RowCount;


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

        private void btnLimparFiltros_Click(object sender, EventArgs e) {
            dgvInfoAD.DataSource = null;
            dgvInfoAD.DataSource = dt_publico;
            txtValorFiltro.Clear();
            cbxTipoFiltro.Text = "";
            cbxCamposFiltros.Text = "";
            lbTotalRegistros.Text = "Total de registros: " + dgvInfoAD.RowCount;
        }

        private void btnFiltrar_Click(object sender, EventArgs e) {

            DataRow[] resultado = null;

            string expressaoFiltro = "";

            if (cbxTipoFiltro.Text.ToUpper().Equals("IDENTICO A")) {
                expressaoFiltro = cbxCamposFiltros.Text + " = '" + txtValorFiltro.Text + "'";
            } else if (cbxTipoFiltro.Text.ToUpper().Equals("NAO CONTEM")) {
                expressaoFiltro = cbxCamposFiltros.Text + " not like '*" + txtValorFiltro.Text + "*'";
            } else if (cbxTipoFiltro.Text.ToUpper().Equals("CONTEM")) {
                expressaoFiltro = cbxCamposFiltros.Text + " like '*" + txtValorFiltro.Text + "*'";
            } else {
                MessageBox.Show("Não foi selecionado uma forma de filtragem!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            resultado = dt_publico.Select(expressaoFiltro);

            //saindo da função caso não tenha filtrado nada
            if (resultado.Length == 0) {
                MessageBox.Show("Não foi encontrado o filtro pesquisado!", Constantes.Titulo_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //limpando o dagridview 
            dgvInfoAD.DataSource = null;

            //criando novo datatable para popular o datagridview
            DataTable novoDT = new DataTable();
            DataColumn coluna;
            DataRow linha;

            //populando as colunas
            foreach (DataColumn col in dt_publico.Columns) { //usando o dt_publico para capturar as colunas originais
                coluna = new DataColumn();
                coluna.DataType = System.Type.GetType("System.String");
                coluna.ColumnName = col.ColumnName.ToString();
                novoDT.Columns.Add(coluna);
            }

            //populando as linhas filtradas
            foreach (DataRow ln in resultado) { //passando por todas as linhas resultados da busca  
                linha = novoDT.NewRow(); //criando a nova linha para receber a info do resultado
                for (int c = 0; c < novoDT.Columns.Count; c++) { // passando por todas as colunas para popular as informações
                    linha[c] = ln[c].ToString(); //como são correspondentes as colunas pode-se usar o mesmo índice
                }
                novoDT.Rows.Add(linha);
            }

            dgvInfoAD.DataSource = novoDT;
            lbTotalRegistros.Text = "Total de registros: " + dgvInfoAD.RowCount;

        }
    }
}
