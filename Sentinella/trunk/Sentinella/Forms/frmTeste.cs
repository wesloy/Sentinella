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
        string sql = "";
        long retorno = 0;

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

        private void button1_Click(object sender, EventArgs e) {

            DataTable dt_filtro = new DataTable();
            dt_filtro = con.retornaDataTable("Select * from w_tamnun_filtros");

            foreach (DataRow item in dt_filtro.Rows) {

                sql = "Update a set ";
                sql += "a.filtro = '" + item["valorBusca"].ToString() + "' ";
                sql += "from w_tamnun_base a ";
                sql += "where a.caminho like '%" + item["valorBusca"].ToString() + "%' and a.categoria = '" + item["categoria"].ToString() + "' and a.fonte = '" + item["fonte"].ToString() + "'";
                con.executaQuery(sql, ref retorno);

            }

            MessageBox.Show("Acabou!");



        }
    }
}
