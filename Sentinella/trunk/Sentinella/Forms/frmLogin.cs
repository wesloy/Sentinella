using System;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmLogin : Form {

        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
               
        public frmLogin() {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e) {
            this.txtUsuario.Text = hlp.capturaIdRede();
        }

        /// <summary>
        /// Função para:
        ///  - autenticar no AD o usuário
        ///  - autenticar e liberar privilégios no Sentinella
        ///  - Alterar status para ONLINE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntrar_Click(object sender, EventArgs e) {
            string msgErro = "";
            Constantes.idlogadoFerramenta = txtUsuario.Text.ToUpper().Trim();

            if (hlp.autenticacaoActiveDirectory(this.txtUsuario.Text, this.txtSenha.Text, false, "", ref msgErro)) {
                
                usuarios user = new usuarios(true);
                Constantes.nivelAcesso = user.auttenticacoUsuario(user);
                user =  user.capturarUsuariosPorIDRede(Constantes.idlogadoFerramenta);
                Constantes.nomeAssociadoLogado = user.Nome;

                if (Constantes.nivelAcesso > 0) {
                    user.setStatusUsuario(user);
                    Constantes.autenticacao = true;                    
                    log.registrarLog("Ok", "Login");
                } else {
                    Constantes.autenticacao = false;
                    log.registrarLog("Usuário SEM privilégio de acesso ao Senttinela", "Login");
                }


            } else {
                log.registrarLog(msgErro, "Login");
                Constantes.autenticacao = false;
            }

            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            Close();
        }

        private void pbSenha_Click(object sender, EventArgs e) {
            if (txtSenha.UseSystemPasswordChar) {
                txtSenha.UseSystemPasswordChar = false;
            } else {
                txtSenha.UseSystemPasswordChar = true;
            } 
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                    btnEntrar_Click(sender, e);
                    break;

                case Keys.F4:
                    btnCancelar_Click(sender, e);
                    break;
                                        

            }
        }

        private void pbLock_Click(object sender, EventArgs e) {
            Algar.Utils.Conexao con = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
            con.testaConexao();
        }
    }
}
