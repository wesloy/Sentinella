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
    public partial class frmCategorizacao : Form
    {
        public frmCategorizacao()
        {
            InitializeComponent();
        }

        #region Variaveis        
        finalizacoes objFin = new finalizacoes();
        subFinalizacoes objSubFin = new subFinalizacoes();
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        public string filaNome { get; set; }
        public int filaId { get; set; }
        public DateTime dataAbertura { get; set; }
        public string idAbertura { get; set; }
        public bool finalizacaoMassa { get; set; }
        public int id { get; set; }
        public int idImp { get; set; }
        #endregion

        #region funcoes

        private void limparForm(bool limpezaParcial = false)
        {
            if (!limpezaParcial)
            {
                hlp.limparCampos(this);
            }
            else
            {
                cbFinalizacao.Text = "";
                cbSubFinalizacao.Text = "";
                txtObservacao.Text = "";
            }
        }

        private retornoOuvidoria carregarObjRetornoOuvidoria()
        {
            //Tratativas de variáveis
            int fin = 0;
            int sub = 0;
            if (cbFinalizacao.SelectedValue == null) { fin = 0; } else { fin = int.Parse(cbFinalizacao.SelectedValue.ToString()); }
            if (cbSubFinalizacao.SelectedValue == null) { sub = 0; } else { sub = int.Parse(cbSubFinalizacao.SelectedValue.ToString()); }
            double valor = 0;
            string obs;
            if (txtObservacao.Text == null) { obs = ""; } else { obs = txtObservacao.Text; }
            if (txtValorEnvolvido.Text == "") { valor = 0; } else { valor = float.Parse(txtValorEnvolvido.Text); }
            retornoOuvidoria cat = new retornoOuvidoria(
                id,
                fin,
                sub,
                valor,
                obs);

            return cat;

        }

        private categorizacoes carregarObjCategorizacoes()
        {
            //Tratativas de variáveis
            int fin = 0;
            int sub = 0;
            if (cbFinalizacao.SelectedValue == null) { fin = 0; } else { fin = int.Parse(cbFinalizacao.SelectedValue.ToString()); }
            if (cbSubFinalizacao.SelectedValue == null) { sub = 0; } else { sub = int.Parse(cbSubFinalizacao.SelectedValue.ToString()); }


            if (finalizacaoMassa)
            {
                categorizacoes cat = new categorizacoes(
                    filaId,
                    dataAbertura,
                    idAbertura,
                    fin,
                    sub,
                    txtObservacao.Text
                    );
                return cat;
            }
            else
            { //Categorização individual
                double valor = 0;
                string obs;
                if (txtObservacao.Text == null) { obs = ""; } else { obs = txtObservacao.Text; }
                if (txtValorEnvolvido.Text == "") { valor = 0; } else { valor = float.Parse(txtValorEnvolvido.Text); }
                categorizacoes cat = new categorizacoes(
                    id,
                    fin,
                    sub,
                    valor,
                    obs);
                return cat;
            }
        }




        private void fecharForm(bool finalizadoRegistro)
        {

            if (filaId == 6) { //transferindo informações para tabela DLP
                dlp dlp = new dlp();
                dlp.finalizarRegistrosTrabalho(id);
            }

            if (filaId == 12) { //transferindo informações para tabela TAMNUN
                tamnun t = new tamnun();
                t.finalizarRegistrosTrabalho(id);
            }

            Constantes.finalizacaoOkay = finalizadoRegistro;
            hlp.fecharForm(this);
        }

        #endregion

        private void frmCategorizacao_Load(object sender, EventArgs e)
        {

            lbNomeFila.Text = filaNome;
            //carregando combobox de finalização
            objFin.carregarComboboxFinalizacoes(this, cbFinalizacao, filaId, true);
            //Desabilitando componentes
            if (finalizacaoMassa) { txtValorEnvolvido.Enabled = false; }

        }

        private void cbFinalizacao_Leave(object sender, EventArgs e)
        {

            cbSubFinalizacao.Text = "";
            if (cbFinalizacao.Text != "")
            {
                objSubFin.carregarComboboxSubFinalizacoes(this, cbSubFinalizacao, int.Parse(cbFinalizacao.SelectedValue.ToString()), true);
            }
            else
            {
                cbSubFinalizacao.DataSource = null;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (filaId == 5) {
                retornoOuvidoria cat = new retornoOuvidoria();
                cat = carregarObjRetornoOuvidoria();
                fecharForm(cat.finalizarRegistro(cat)); //Finalizando e fechando o form, devolvendo a informação se a ação aconteceu com sucesso ou não
            }

            if (filaId != 5) //retorno da ouvidoria é igual a 5
            {
                categorizacoes cat = new categorizacoes();
                cat = carregarObjCategorizacoes();
                if (finalizacaoMassa)
                {
                    fecharForm(cat.finalizarMassa(cat, idImp)); //Finalizando e fechando o form, devolvendo a informação se a ação aconteceu com sucesso ou não
                }
                else
                {
                    fecharForm(cat.finalizarRegistro(cat)); //Finalizando e fechando o form, devolvendo a informação se a ação aconteceu com sucesso ou não
                }
            }
            

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            fecharForm(false);
        }

        private void txtValorEnvolvido_KeyPress(object sender, KeyPressEventArgs e)
        {
            hlp.somenteNumero(txtValorEnvolvido);
        }
    }
}
