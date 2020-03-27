﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmTrilhasSGI : Form {

        trilhasSGI trilhas = new trilhasSGI();
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();

        public frmTrilhasSGI() {
            InitializeComponent();
        }


        private void frmTrilhasSGI_Load(object sender, EventArgs e) {
            trilhas.preencherComboBoxCoordenadores(this, cbxCoordenador);

        }

        private void btnIniciar_Click(object sender, EventArgs e) {
            cbxCoordenador.Enabled = false;

            if (hlp.validaCamposObrigatorios(pnlFiltros,"cbxCoordenador")) {
                trilhas.preencherListViewAssociados(lvAssociados, cbxCoordenador.Text);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            
            if (trilhas.liberarRegistros()) {
                cbxCoordenador.Enabled = true;
                lvAssociados.Clear();
                trilhas.preencherComboBoxCoordenadores(this, cbxCoordenador);
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

            email.Assunto = "Ref. aos treinamentos mandatórios obrigatórios - TRILHA SGI";
            email.Mensagem = txtMensagem.Text.Replace("\r\n", "<br />") + " <br /><br />";
            email.Mensagem += "Lista de associados com pendência: <br /><br />";

            foreach (ListViewItem item in lvAssociados.Items) {
                if (item.Checked) {
                    email.Mensagem += item.SubItems[1].Text + "<br />";
                    email.Mensagem += item.SubItems[2].Text + "<br />";
                    email.Mensagem += "Percentual concluíddo: " + item.SubItems[4].Text + "% <br />";
                    email.Mensagem += "Supervisão: " + item.SubItems[5].Text + "<br />";
                    email.Mensagem += "Coordenação: " + item.SubItems[6].Text + "<br /><br />";
                }
            }


            //Para
            List<string> para = new List<string>();
            string[] _para = txtEmailDestinatario.Text.Split(';');
            foreach (var item in _para) { para.Add(item); }
            email.Para = para;

            //CC
            string txtCC = "si@algartech.com";
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
            email.Mensagem += "Coordenação de Segurança da Informação e Complince Algar Tech! <br />";
            email.Mensagem += "Dúvidas contatar: " + txtCCo;


            if (email.envio(email.Assunto, email.Mensagem, email.Para, email.Cc, email.CcO, null)) {

                //Finalizar registros
                foreach (ListViewItem item in lvAssociados.Items) {
                    if (item.Checked) {
                        trilhas.finalizarRegistro(int.Parse(item.SubItems[0].Text));
                    }
                }

                //liberando registros que podem não ter sido selecionados para envio e limpando o formulário
                trilhas.liberarRegistros(false);
                cbxCoordenador.Enabled = true;
                lvAssociados.Clear();
                trilhas.preencherComboBoxCoordenadores(this, cbxCoordenador);

                MessageBox.Show("E-mail enviado com sucesso!", "Envio de E-mail");
            } else {
                MessageBox.Show("Falha no envio de E-mail!", "Envio de E-mail");
            }



        }
    }
}
