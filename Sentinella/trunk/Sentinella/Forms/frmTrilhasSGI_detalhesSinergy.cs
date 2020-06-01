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
    public partial class frmTrilhasSGI_detalhesSinergy : Form {
        public frmTrilhasSGI_detalhesSinergy() {
            InitializeComponent();
        }

        #region VARIAVEIS
        public DataTable _infoSinergy;
        #endregion

        private void frmTrilhasSGI_detalhesSinergy_Load(object sender, EventArgs e) {
            this.dtgvDetalhesSinergy.DataSource = _infoSinergy;
        }
    }
}
