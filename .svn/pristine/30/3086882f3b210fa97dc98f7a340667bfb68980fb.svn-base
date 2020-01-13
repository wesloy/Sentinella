using System;
using System.Windows.Forms;

namespace Sentinella.Forms
{
    public partial class frmLogin : Form
    {

        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();
        logs log = new logs();
        

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.txtUsuario.Text = hlp.capturaIdRede();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (hlp.autenticacaoActiveDirectory(this.txtUsuario.Text, this.txtSenha.Text, true))
            {
                log.registrarLog("Ok", "Login");
                Constantes.autenticacao = true;
                this.Close();
            }
            else
            {
                log.registrarLog("Falha", "Login");
                MessageBox.Show("Senha digitada está incorreta. O Sentinella, será fechado!");
                Constantes.autenticacao = false;
                this.Close();
                
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
