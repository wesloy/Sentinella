using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinella.Forms {
    public partial class frmTeste : Form {

        Algar.Utils.Conexao con = new Algar.Utils.Conexao(Algar.Utils.Conexao.FLAG_SGBD.SQL, Constantes.ALGAR_PWD, Constantes.ALGAR_BD, Constantes.ALGAR_SERVIDOR, Constantes.ALGAR_USER, "");
        Algar.Utils.Helpers hlp = new Algar.Utils.Helpers();

        public frmTeste() {
            InitializeComponent();
        }


        private void btnTesteConexao_Click(object sender, EventArgs e) {

            con.testaConexao();
        }

        private void btnEncypt_Click(object sender, EventArgs e) {
            txtSaida.Text = hlp.Encrypt(txtEntrada.Text);
        }

        private void btnDecriptar_Click(object sender, EventArgs e) {
            txtSaida.Text = hlp.Decrypt(txtEntrada.Text);
        }
    }
}
