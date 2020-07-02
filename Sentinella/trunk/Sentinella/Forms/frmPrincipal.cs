using Sentinella.Forms;
using System;
using System.Windows.Forms;

namespace Sentinella {
    public partial class frmPrincipal : Form {

        #region Variaveis Uteis
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        private Form _objForm { get; set; }
        sys_interrupcoesProgramadas interrupcoes = new sys_interrupcoesProgramadas();
        #endregion


        private void interrupcaoProgramada() {
            if (interrupcoes.interromperSistema(false)) {
                this.Close();
            }
        }

        public bool atualizarStatus(string texto) {
            try {
                lbStatus.Text = texto;
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public frmPrincipal(string textoStatus = "") {
            InitializeComponent();
            if (!textoStatus.Equals("")) {
                atualizarStatus(textoStatus);
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e) {
            //interrupção programada
            interrupcaoProgramada();

            //Versão do sistema
            lbVersao.Text = "| Versão: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + " |";
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmHome();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);

            Form frm = new frmLogin();
            frm.ShowDialog();

            if (!Constantes.autenticacao) {
                Close();
            } else {
                // Liberar MENUs apropriados ao nível de acesso na ferramenta
                switch (Constantes.nivelAcesso) {
                    case 2:
                        mmOpenConsultasForm.Enabled = true;
                        mmOpenExportacoesForm.Enabled = true;
                        break;
                    case 3:
                        mmOpenConsultasForm.Enabled = true;
                        mmOpenExportacoesForm.Enabled = true;
                        mmOpenImportacoesForm.Enabled = true;
                        break;
                    case 4:
                        mmOpenConsultasForm.Enabled = true;
                        mmOpenExportacoesForm.Enabled = true;
                        mmOpenImportacoesForm.Enabled = true;
                        mmOpenConfiguracoesForm.Enabled = true;
                        break;
                }
            }
        }
        private void mmFechar_Click(object sender, EventArgs e) {
            hlp.fecharAplicativo();
        }
        private void mmOpenImportacoesForm_Click(object sender, EventArgs e) {
            atualizarStatus("Página de Importações");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmImportacoes();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }


        private void mmOpenTelaInicial_Click(object sender, EventArgs e) {
            atualizarStatus("Página Principal");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmHome();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void mmOpenConfigFinalizacoes_Click(object sender, EventArgs e) {
            atualizarStatus("Página de Configuração de Finalizações");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmConfigFinalizacoes();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void mmOpenConfigSubFinalizacoes_Click(object sender, EventArgs e) {
            atualizarStatus("Página de Configuração de SubFinalizações");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmConfigSubFinalizacoes();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void mmOpenConfigUsuarios_Click(object sender, EventArgs e) {
            atualizarStatus("Página de Configuração de Usuários");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmConfigUsuarios();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }
        private void interrupçãoProgramadaToolStripMenuItem_Click(object sender, EventArgs e) {
            atualizarStatus("Página de Configuração de Interrupções Programadas");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmConfigInterrupcoesProgramadas();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e) {
            usuarios Onlinhe = new usuarios(false);
            Onlinhe.setStatusUsuario(Onlinhe);
        }

        private void mmOpenConfigFilas_Click(object sender, EventArgs e) {
            atualizarStatus("Página de Configuração de Filas");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmConfigFilas();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void filtrosToolStripMenuItem_Click(object sender, EventArgs e) {
            atualizarStatus("Página de Configuração de Filtros - Tamnun");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmConfigTamnunFiltros();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void filasDeTrabalhoToolStripMenuItem_Click(object sender, EventArgs e) {
            atualizarStatus("Página de Análises");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmAnalies();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void whiteListToolStripMenuItem_Click(object sender, EventArgs e) {
            atualizarStatus("Página de Configuração de White List - Tamnun");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmConfigTamnunWhiteList();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void devoluçõesOuvidoriaToolStripMenuItem_Click(object sender, EventArgs e) {
            atualizarStatus("Página de registro de devolução de Ouvidorias");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmOuvidoria();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void planosDeAçãoToolStripMenuItem_Click(object sender, EventArgs e) {
            atualizarStatus("Página de Planos de Ação");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmPlanoAcao();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }
        private void envioEmailCobrançaTrilhasSGIToolStripMenuItem_Click(object sender, EventArgs e) {
            atualizarStatus("Página de Envio de e-mail cobrança Trilhas SGI");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmTrilhasSGI();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void dadosCadastraisDeAssociadosToolStripMenuItem_Click(object sender, EventArgs e) {
            _objForm = new frmLocalizarDadosAssociados();
            hlp.abrirForm(_objForm, false, true);

            //atualizarStatus("Página de Pesquisa de Dados Cadastrais de Associados");
            //_objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache            
            //hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void dadosADToolStripMenuItem_Click(object sender, EventArgs e) {
            _objForm = new frmLocalizarInformacoesAD();
            hlp.abrirForm(_objForm, false, true);

            //_objForm = new frmLocalizarInformacoesAD();
            //hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void mmOpenConsultasForm_Click(object sender, EventArgs e) {

        }

        private void mmOpenExportacoesForm_Click(object sender, EventArgs e) {
            atualizarStatus("Bases para Exportações");
            _objForm?.Close(); // Validar se já está carregado com outra informações e fechar, limpando o cache
            _objForm = new frmRelatorios();
            hlp.abrirFormInPanelMDI(_objForm, this, pnlPrincipal, FormBorderStyle.None);
        }

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e) {

            if (Constantes.nivelAcesso >= 2) {
                switch (e.KeyCode) {
                    case Keys.F4:
                        mmOpenConsultasForm_Click(sender, e);
                        break;
                    case Keys.F5:
                        mmOpenExportacoesForm_Click(sender, e);
                        break;
                }

            }

            if (Constantes.nivelAcesso >= 3) {
                switch (e.KeyCode) {
                    case Keys.F6:
                        mmOpenImportacoesForm_Click(sender, e);
                        break;
                }
            }

            if (Constantes.nivelAcesso >= 4) {
                switch (e.KeyCode) {
                    case Keys.F7:
                        mmOpenConfigFilas_Click(sender, e);
                        break;
                    case Keys.F8:
                        mmOpenConfigFinalizacoes_Click(sender, e);
                        break;
                    case Keys.F9:
                        mmOpenConfigSubFinalizacoes_Click(sender, e);
                        break;
                    case Keys.F10:
                        mmOpenConfigUsuarios_Click(sender, e);
                        break;
                }

            }

        }

        private void timer1_Tick(object sender, EventArgs e) {
            interrupcaoProgramada();
        }


    }
}
