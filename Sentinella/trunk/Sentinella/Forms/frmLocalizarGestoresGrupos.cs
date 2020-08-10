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
    public partial class frmLocalizarGestoresGrupos : Form {

        #region Variaveis
        Uteis.Helpers hlp = new Uteis.Helpers();
        dadosCadastraisTH d_th = new dadosCadastraisTH(); //informações do funcionário segundo a planilha do TH
        #endregion

        public frmLocalizarGestoresGrupos() {
            InitializeComponent();
        }

        private void frmLocalizarGestoresGrupos_Load(object sender, EventArgs e) {
            hlp.limparCampos(this);
        }
    }
}
