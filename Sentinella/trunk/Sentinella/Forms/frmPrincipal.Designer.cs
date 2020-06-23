namespace Sentinella
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.pnlMenusLeft = new System.Windows.Forms.Panel();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mmOpenTelaInicial = new System.Windows.Forms.ToolStripMenuItem();
            this.mmOpenAnalisesForm = new System.Windows.Forms.ToolStripMenuItem();
            this.filasDeTrabalhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devoluçõesOuvidoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planosDeAçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envioEmailCobrançaTrilhasSGIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mmOpenConsultasForm = new System.Windows.Forms.ToolStripMenuItem();
            this.dadosCadastraisDeAssociadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dadosADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mmOpenExportacoesForm = new System.Windows.Forms.ToolStripMenuItem();
            this.mmOpenImportacoesForm = new System.Windows.Forms.ToolStripMenuItem();
            this.mmOpenConfiguracoesForm = new System.Windows.Forms.ToolStripMenuItem();
            this.mmOpenConfigFilas = new System.Windows.Forms.ToolStripMenuItem();
            this.mmOpenConfigFinalizacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.mmOpenConfigSubFinalizacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mmOpenConfigUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.interrupçãoProgramadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mmFechar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip_Geral = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.barraStatus = new System.Windows.Forms.StatusStrip();
            this.lbVersao = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tamnunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlMenusLeft.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.barraStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pnlPrincipal.Location = new System.Drawing.Point(52, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1079, 497);
            this.pnlPrincipal.TabIndex = 1;
            // 
            // pnlMenusLeft
            // 
            this.pnlMenusLeft.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlMenusLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMenusLeft.Controls.Add(this.menuPrincipal);
            this.pnlMenusLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenusLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenusLeft.ForeColor = System.Drawing.Color.Black;
            this.pnlMenusLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlMenusLeft.Name = "pnlMenusLeft";
            this.pnlMenusLeft.Padding = new System.Windows.Forms.Padding(10, 30, 0, 0);
            this.pnlMenusLeft.Size = new System.Drawing.Size(52, 497);
            this.pnlMenusLeft.TabIndex = 3;
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.menuPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPrincipal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmOpenTelaInicial,
            this.mmOpenAnalisesForm,
            this.mmOpenConsultasForm,
            this.mmOpenExportacoesForm,
            this.mmOpenImportacoesForm,
            this.mmOpenConfiguracoesForm,
            this.mmFechar});
            this.menuPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.menuPrincipal.Location = new System.Drawing.Point(10, 30);
            this.menuPrincipal.MdiWindowListItem = this.mmOpenConsultasForm;
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Padding = new System.Windows.Forms.Padding(3, 2, 2, 2);
            this.menuPrincipal.ShowItemToolTips = true;
            this.menuPrincipal.Size = new System.Drawing.Size(125, 467);
            this.menuPrincipal.TabIndex = 2;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // mmOpenTelaInicial
            // 
            this.mmOpenTelaInicial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mmOpenTelaInicial.Image = ((System.Drawing.Image)(resources.GetObject("mmOpenTelaInicial.Image")));
            this.mmOpenTelaInicial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mmOpenTelaInicial.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mmOpenTelaInicial.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.mmOpenTelaInicial.Name = "mmOpenTelaInicial";
            this.mmOpenTelaInicial.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F2)));
            this.mmOpenTelaInicial.Size = new System.Drawing.Size(37, 28);
            this.mmOpenTelaInicial.Text = "Página Inicial (ALT + F2)";
            this.mmOpenTelaInicial.ToolTipText = "Página Inicial (ALT + F2)";
            this.mmOpenTelaInicial.Click += new System.EventHandler(this.mmOpenTelaInicial_Click);
            // 
            // mmOpenAnalisesForm
            // 
            this.mmOpenAnalisesForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mmOpenAnalisesForm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filasDeTrabalhoToolStripMenuItem,
            this.devoluçõesOuvidoriaToolStripMenuItem,
            this.planosDeAçãoToolStripMenuItem,
            this.envioEmailCobrançaTrilhasSGIToolStripMenuItem});
            this.mmOpenAnalisesForm.Image = ((System.Drawing.Image)(resources.GetObject("mmOpenAnalisesForm.Image")));
            this.mmOpenAnalisesForm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mmOpenAnalisesForm.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.mmOpenAnalisesForm.Name = "mmOpenAnalisesForm";
            this.mmOpenAnalisesForm.Size = new System.Drawing.Size(32, 27);
            this.mmOpenAnalisesForm.Text = "Análises (F3)";
            this.mmOpenAnalisesForm.ToolTipText = "Análises";
            // 
            // filasDeTrabalhoToolStripMenuItem
            // 
            this.filasDeTrabalhoToolStripMenuItem.Name = "filasDeTrabalhoToolStripMenuItem";
            this.filasDeTrabalhoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.filasDeTrabalhoToolStripMenuItem.ShowShortcutKeys = false;
            this.filasDeTrabalhoToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.filasDeTrabalhoToolStripMenuItem.Text = "Filas de Trabalho (F2)";
            this.filasDeTrabalhoToolStripMenuItem.ToolTipText = "Click F2";
            this.filasDeTrabalhoToolStripMenuItem.Click += new System.EventHandler(this.filasDeTrabalhoToolStripMenuItem_Click);
            // 
            // devoluçõesOuvidoriaToolStripMenuItem
            // 
            this.devoluçõesOuvidoriaToolStripMenuItem.Name = "devoluçõesOuvidoriaToolStripMenuItem";
            this.devoluçõesOuvidoriaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.devoluçõesOuvidoriaToolStripMenuItem.ShowShortcutKeys = false;
            this.devoluçõesOuvidoriaToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.devoluçõesOuvidoriaToolStripMenuItem.Text = "Devoluções Ouvidoria (F3)";
            this.devoluçõesOuvidoriaToolStripMenuItem.ToolTipText = "Click F3";
            this.devoluçõesOuvidoriaToolStripMenuItem.Click += new System.EventHandler(this.devoluçõesOuvidoriaToolStripMenuItem_Click);
            // 
            // planosDeAçãoToolStripMenuItem
            // 
            this.planosDeAçãoToolStripMenuItem.Name = "planosDeAçãoToolStripMenuItem";
            this.planosDeAçãoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.planosDeAçãoToolStripMenuItem.ShowShortcutKeys = false;
            this.planosDeAçãoToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.planosDeAçãoToolStripMenuItem.Text = "Planos de Ação (F11)";
            this.planosDeAçãoToolStripMenuItem.Click += new System.EventHandler(this.planosDeAçãoToolStripMenuItem_Click);
            // 
            // envioEmailCobrançaTrilhasSGIToolStripMenuItem
            // 
            this.envioEmailCobrançaTrilhasSGIToolStripMenuItem.Name = "envioEmailCobrançaTrilhasSGIToolStripMenuItem";
            this.envioEmailCobrançaTrilhasSGIToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.envioEmailCobrançaTrilhasSGIToolStripMenuItem.Text = "Envio e-mail Cobrança Trilhas SGI";
            this.envioEmailCobrançaTrilhasSGIToolStripMenuItem.Click += new System.EventHandler(this.envioEmailCobrançaTrilhasSGIToolStripMenuItem_Click);
            // 
            // mmOpenConsultasForm
            // 
            this.mmOpenConsultasForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mmOpenConsultasForm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dadosCadastraisDeAssociadosToolStripMenuItem,
            this.dadosADToolStripMenuItem});
            this.mmOpenConsultasForm.Enabled = false;
            this.mmOpenConsultasForm.Image = ((System.Drawing.Image)(resources.GetObject("mmOpenConsultasForm.Image")));
            this.mmOpenConsultasForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mmOpenConsultasForm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mmOpenConsultasForm.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.mmOpenConsultasForm.Name = "mmOpenConsultasForm";
            this.mmOpenConsultasForm.Size = new System.Drawing.Size(36, 28);
            this.mmOpenConsultasForm.Text = "Consultas (F4)";
            this.mmOpenConsultasForm.ToolTipText = "Consultas (F4)";
            this.mmOpenConsultasForm.Click += new System.EventHandler(this.mmOpenConsultasForm_Click);
            // 
            // dadosCadastraisDeAssociadosToolStripMenuItem
            // 
            this.dadosCadastraisDeAssociadosToolStripMenuItem.Name = "dadosCadastraisDeAssociadosToolStripMenuItem";
            this.dadosCadastraisDeAssociadosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.dadosCadastraisDeAssociadosToolStripMenuItem.ShowShortcutKeys = false;
            this.dadosCadastraisDeAssociadosToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.dadosCadastraisDeAssociadosToolStripMenuItem.Text = "Dados Cadastrais de Associados (F12)";
            this.dadosCadastraisDeAssociadosToolStripMenuItem.Click += new System.EventHandler(this.dadosCadastraisDeAssociadosToolStripMenuItem_Click);
            // 
            // dadosADToolStripMenuItem
            // 
            this.dadosADToolStripMenuItem.Name = "dadosADToolStripMenuItem";
            this.dadosADToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.dadosADToolStripMenuItem.Text = "Dados AD";
            this.dadosADToolStripMenuItem.Click += new System.EventHandler(this.dadosADToolStripMenuItem_Click);
            // 
            // mmOpenExportacoesForm
            // 
            this.mmOpenExportacoesForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mmOpenExportacoesForm.Enabled = false;
            this.mmOpenExportacoesForm.Image = ((System.Drawing.Image)(resources.GetObject("mmOpenExportacoesForm.Image")));
            this.mmOpenExportacoesForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mmOpenExportacoesForm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mmOpenExportacoesForm.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.mmOpenExportacoesForm.Name = "mmOpenExportacoesForm";
            this.mmOpenExportacoesForm.Size = new System.Drawing.Size(36, 26);
            this.mmOpenExportacoesForm.Text = "Exportações (F5)";
            this.mmOpenExportacoesForm.ToolTipText = "Exportações (F5)";
            this.mmOpenExportacoesForm.Click += new System.EventHandler(this.mmOpenExportacoesForm_Click);
            // 
            // mmOpenImportacoesForm
            // 
            this.mmOpenImportacoesForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mmOpenImportacoesForm.Enabled = false;
            this.mmOpenImportacoesForm.Image = ((System.Drawing.Image)(resources.GetObject("mmOpenImportacoesForm.Image")));
            this.mmOpenImportacoesForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mmOpenImportacoesForm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mmOpenImportacoesForm.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.mmOpenImportacoesForm.Name = "mmOpenImportacoesForm";
            this.mmOpenImportacoesForm.Size = new System.Drawing.Size(36, 27);
            this.mmOpenImportacoesForm.Text = "Importações (F6)";
            this.mmOpenImportacoesForm.ToolTipText = "Importações (F6)";
            this.mmOpenImportacoesForm.Click += new System.EventHandler(this.mmOpenImportacoesForm_Click);
            // 
            // mmOpenConfiguracoesForm
            // 
            this.mmOpenConfiguracoesForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mmOpenConfiguracoesForm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tamnunToolStripMenuItem,
            this.toolStripSeparator2,
            this.mmOpenConfigFilas,
            this.mmOpenConfigFinalizacoes,
            this.mmOpenConfigSubFinalizacoes,
            this.toolStripSeparator1,
            this.mmOpenConfigUsuarios,
            this.interrupçãoProgramadaToolStripMenuItem});
            this.mmOpenConfiguracoesForm.Enabled = false;
            this.mmOpenConfiguracoesForm.Image = ((System.Drawing.Image)(resources.GetObject("mmOpenConfiguracoesForm.Image")));
            this.mmOpenConfiguracoesForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mmOpenConfiguracoesForm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mmOpenConfiguracoesForm.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.mmOpenConfiguracoesForm.Name = "mmOpenConfiguracoesForm";
            this.mmOpenConfiguracoesForm.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mmOpenConfiguracoesForm.Size = new System.Drawing.Size(35, 28);
            this.mmOpenConfiguracoesForm.Text = "Configurações";
            this.mmOpenConfiguracoesForm.ToolTipText = "Configurações";
            // 
            // mmOpenConfigFilas
            // 
            this.mmOpenConfigFilas.Name = "mmOpenConfigFilas";
            this.mmOpenConfigFilas.Size = new System.Drawing.Size(210, 22);
            this.mmOpenConfigFilas.Text = "Filas (F7)";
            this.mmOpenConfigFilas.ToolTipText = "Click F7";
            this.mmOpenConfigFilas.Click += new System.EventHandler(this.mmOpenConfigFilas_Click);
            // 
            // mmOpenConfigFinalizacoes
            // 
            this.mmOpenConfigFinalizacoes.Name = "mmOpenConfigFinalizacoes";
            this.mmOpenConfigFinalizacoes.Size = new System.Drawing.Size(210, 22);
            this.mmOpenConfigFinalizacoes.Text = "Finalizações (F8)";
            this.mmOpenConfigFinalizacoes.ToolTipText = "Click F8";
            this.mmOpenConfigFinalizacoes.Click += new System.EventHandler(this.mmOpenConfigFinalizacoes_Click);
            // 
            // mmOpenConfigSubFinalizacoes
            // 
            this.mmOpenConfigSubFinalizacoes.Name = "mmOpenConfigSubFinalizacoes";
            this.mmOpenConfigSubFinalizacoes.Size = new System.Drawing.Size(210, 22);
            this.mmOpenConfigSubFinalizacoes.Text = "SubFinalizações (F9)";
            this.mmOpenConfigSubFinalizacoes.ToolTipText = "Click F9";
            this.mmOpenConfigSubFinalizacoes.Click += new System.EventHandler(this.mmOpenConfigSubFinalizacoes_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // mmOpenConfigUsuarios
            // 
            this.mmOpenConfigUsuarios.Name = "mmOpenConfigUsuarios";
            this.mmOpenConfigUsuarios.Size = new System.Drawing.Size(210, 22);
            this.mmOpenConfigUsuarios.Text = "Usuários (F10)";
            this.mmOpenConfigUsuarios.ToolTipText = "Click F10";
            this.mmOpenConfigUsuarios.Click += new System.EventHandler(this.mmOpenConfigUsuarios_Click);
            // 
            // interrupçãoProgramadaToolStripMenuItem
            // 
            this.interrupçãoProgramadaToolStripMenuItem.Name = "interrupçãoProgramadaToolStripMenuItem";
            this.interrupçãoProgramadaToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.interrupçãoProgramadaToolStripMenuItem.Text = "Interrupção Programada";
            this.interrupçãoProgramadaToolStripMenuItem.Click += new System.EventHandler(this.interrupçãoProgramadaToolStripMenuItem_Click);
            // 
            // mmFechar
            // 
            this.mmFechar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mmFechar.Image = ((System.Drawing.Image)(resources.GetObject("mmFechar.Image")));
            this.mmFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mmFechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mmFechar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.mmFechar.Name = "mmFechar";
            this.mmFechar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mmFechar.Size = new System.Drawing.Size(33, 22);
            this.mmFechar.Text = "Sair (ALT+F4)";
            this.mmFechar.ToolTipText = "Fechar o Senttinela (ALT + F4)";
            this.mmFechar.Click += new System.EventHandler(this.mmFechar_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.barraStatus);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pnlPrincipal);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pnlMenusLeft);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1131, 497);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1131, 519);
            this.toolStripContainer1.TabIndex = 5;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // barraStatus
            // 
            this.barraStatus.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.barraStatus.Dock = System.Windows.Forms.DockStyle.None;
            this.barraStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbVersao,
            this.lbStatus});
            this.barraStatus.Location = new System.Drawing.Point(0, 0);
            this.barraStatus.Name = "barraStatus";
            this.barraStatus.Size = new System.Drawing.Size(1131, 22);
            this.barraStatus.TabIndex = 1;
            this.barraStatus.Text = "statusStrip1";
            // 
            // lbVersao
            // 
            this.lbVersao.Name = "lbVersao";
            this.lbVersao.Size = new System.Drawing.Size(56, 17);
            this.lbVersao.Text = "| Versão: |";
            // 
            // lbStatus
            // 
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbStatus.ForeColor = System.Drawing.Color.Black;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(178, 17);
            this.lbStatus.Tag = "Status";
            this.lbStatus.Text = "Senttinela pronto para a ação...";
            this.lbStatus.ToolTipText = "Status de Processos";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tamnunToolStripMenuItem
            // 
            this.tamnunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtrosToolStripMenuItem});
            this.tamnunToolStripMenuItem.Name = "tamnunToolStripMenuItem";
            this.tamnunToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.tamnunToolStripMenuItem.Text = "Tamnun";
            // 
            // filtrosToolStripMenuItem
            // 
            this.filtrosToolStripMenuItem.Name = "filtrosToolStripMenuItem";
            this.filtrosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.filtrosToolStripMenuItem.Text = "Filtros";
            this.filtrosToolStripMenuItem.Click += new System.EventHandler(this.filtrosToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1131, 519);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Senttinela :.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrincipal_KeyDown);
            this.pnlMenusLeft.ResumeLayout(false);
            this.pnlMenusLeft.PerformLayout();
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.barraStatus.ResumeLayout(false);
            this.barraStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlMenusLeft;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mmOpenTelaInicial;
        private System.Windows.Forms.ToolStripMenuItem mmOpenAnalisesForm;
        private System.Windows.Forms.ToolStripMenuItem mmOpenImportacoesForm;
        private System.Windows.Forms.ToolStripMenuItem mmOpenExportacoesForm;
        private System.Windows.Forms.ToolStripMenuItem mmOpenConfiguracoesForm;
        private System.Windows.Forms.ToolStripMenuItem mmFechar;
        private System.Windows.Forms.ToolStripMenuItem mmOpenConsultasForm;
        private System.Windows.Forms.ToolTip toolTip_Geral;
        private System.Windows.Forms.ToolStripMenuItem mmOpenConfigUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mmOpenConfigFilas;
        private System.Windows.Forms.ToolStripMenuItem mmOpenConfigFinalizacoes;
        private System.Windows.Forms.ToolStripMenuItem mmOpenConfigSubFinalizacoes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip barraStatus;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.ToolStripStatusLabel lbVersao;
        private System.Windows.Forms.ToolStripMenuItem filasDeTrabalhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devoluçõesOuvidoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planosDeAçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dadosCadastraisDeAssociadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dadosADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem envioEmailCobrançaTrilhasSGIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interrupçãoProgramadaToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem tamnunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

