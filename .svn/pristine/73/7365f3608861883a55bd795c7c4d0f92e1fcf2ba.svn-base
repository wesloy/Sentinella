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
    public partial class frmAutorizacoes : Form {
        public frmAutorizacoes() {
            InitializeComponent();
        }

        #region Variareis
        public DateTime _dataCorte { get; set; }
        public string _bin { get; set; }
        public string _cpf { get; set; }
        #endregion

        private void frmAutorizacoes_Load(object sender, EventArgs e) {
            if (_dataCorte != null) {
                autorizacoes aut = new autorizacoes();
                aut.CarregaListView(lvAutorizacoes, _bin, _cpf, _dataCorte);
            }
        }
    }
}
