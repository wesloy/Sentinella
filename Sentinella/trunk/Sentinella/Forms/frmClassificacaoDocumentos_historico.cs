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
    public partial class frmClassificacaoDocumentos_historico : Form {
        public frmClassificacaoDocumentos_historico() {
            InitializeComponent();
        }


        #region VARIAVEIS
        public DataTable _historicoDocumentos;
        #endregion

        private void frmClassificacaoDocumentos_historico_Load(object sender, EventArgs e) {
            this.dtgvHistoricoClassificacaoDocumentos.DataSource = _historicoDocumentos;
        }
    }
}
