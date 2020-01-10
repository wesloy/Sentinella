using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sentinella {
    public partial class frmProgressBar : Form {

        //Chamada
        //frmProgressBar frm = new frmProgressBar(total de itens que serão validados formato INT);
        //frm.Show(); --> apresentar em tela
        //Atualiar---> frm.atualizarBarra(variável de contagem);
        //frm.Close(); fechar

        public double percentual;

        public frmProgressBar(int max) {
            InitializeComponent();
            pb.Value = 0;
            pb.Minimum = 0;
            pb.Maximum = max;
            pb.Step = 1;
        }

        public void atualizarBarra(int value) {
            //Thread.Sleep(2);
            percentual = double.Parse(value.ToString()) / double.Parse(pb.Maximum.ToString()) * 100;
            string valorPercentual = string.Format("{0:F2}", percentual);
            this.Text = "Processo... " + string.Format("{0:F2}", percentual) + "%";
            pb.PerformStep();
            Application.DoEvents();
        }

    }
}
