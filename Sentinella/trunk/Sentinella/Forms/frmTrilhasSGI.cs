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



        }
    }
}