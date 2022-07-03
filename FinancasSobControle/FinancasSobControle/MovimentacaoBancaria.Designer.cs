namespace FinancasSobControle
{
    partial class MovimentacaoBancaria
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
            this.tabFinancas = new System.Windows.Forms.TabControl();
            this.tabLancamentos = new System.Windows.Forms.TabPage();
            this.panelLancamentos = new System.Windows.Forms.Panel();
            this.cbFormaPag = new System.Windows.Forms.ComboBox();
            this.txtVencimento = new System.Windows.Forms.TextBox();
            this.lblVencimento = new System.Windows.Forms.Label();
            this.btnRemover = new System.Windows.Forms.Button();
            this.cbEspecificacao = new System.Windows.Forms.ComboBox();
            this.lblEspecificacao = new System.Windows.Forms.Label();
            this.cbClassificacao = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.txtParcela = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.txtDataCompra = new System.Windows.Forms.TextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.lblClassificacao = new System.Windows.Forms.Label();
            this.lblParcela = new System.Windows.Forms.Label();
            this.lblFormaPag = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblLocal = new System.Windows.Forms.Label();
            this.lblDataCompra = new System.Windows.Forms.Label();
            this.tabExtratos = new System.Windows.Forms.TabPage();
            this.lblExtrato_descricao = new System.Windows.Forms.Label();
            this.dgvExtrato = new System.Windows.Forms.DataGridView();
            this.cdata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFormPag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cClassificacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEspecificacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cComentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIndice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sm_Exibir = new System.Windows.Forms.ToolStripMenuItem();
            this.sm_Exibir_Geral = new System.Windows.Forms.ToolStripMenuItem();
            this.sm_Exibir_Geral_todasDespesas = new System.Windows.Forms.ToolStripMenuItem();
            this.sm_Exibir_Geral_todasReceitas = new System.Windows.Forms.ToolStripMenuItem();
            this.balançoGeralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sm_Exibir_cartaoDeCredito = new System.Windows.Forms.ToolStripMenuItem();
            this.changesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.corrigirIndicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabFinancas.SuspendLayout();
            this.tabLancamentos.SuspendLayout();
            this.panelLancamentos.SuspendLayout();
            this.tabExtratos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtrato)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFinancas
            // 
            this.tabFinancas.Controls.Add(this.tabLancamentos);
            this.tabFinancas.Controls.Add(this.tabExtratos);
            this.tabFinancas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabFinancas.Location = new System.Drawing.Point(2, 18);
            this.tabFinancas.Name = "tabFinancas";
            this.tabFinancas.SelectedIndex = 0;
            this.tabFinancas.Size = new System.Drawing.Size(1060, 414);
            this.tabFinancas.TabIndex = 1;
            // 
            // tabLancamentos
            // 
            this.tabLancamentos.Controls.Add(this.panelLancamentos);
            this.tabLancamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLancamentos.Location = new System.Drawing.Point(4, 29);
            this.tabLancamentos.Name = "tabLancamentos";
            this.tabLancamentos.Padding = new System.Windows.Forms.Padding(3);
            this.tabLancamentos.Size = new System.Drawing.Size(1052, 381);
            this.tabLancamentos.TabIndex = 0;
            this.tabLancamentos.Text = "Lançamentos";
            this.tabLancamentos.UseVisualStyleBackColor = true;
            // 
            // panelLancamentos
            // 
            this.panelLancamentos.AutoScroll = true;
            this.panelLancamentos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLancamentos.Controls.Add(this.cbFormaPag);
            this.panelLancamentos.Controls.Add(this.txtVencimento);
            this.panelLancamentos.Controls.Add(this.lblVencimento);
            this.panelLancamentos.Controls.Add(this.btnRemover);
            this.panelLancamentos.Controls.Add(this.cbEspecificacao);
            this.panelLancamentos.Controls.Add(this.lblEspecificacao);
            this.panelLancamentos.Controls.Add(this.cbClassificacao);
            this.panelLancamentos.Controls.Add(this.btnAdd);
            this.panelLancamentos.Controls.Add(this.txtComentario);
            this.panelLancamentos.Controls.Add(this.txtParcela);
            this.panelLancamentos.Controls.Add(this.txtValor);
            this.panelLancamentos.Controls.Add(this.txtLocal);
            this.panelLancamentos.Controls.Add(this.txtDataCompra);
            this.panelLancamentos.Controls.Add(this.lblComentario);
            this.panelLancamentos.Controls.Add(this.lblClassificacao);
            this.panelLancamentos.Controls.Add(this.lblParcela);
            this.panelLancamentos.Controls.Add(this.lblFormaPag);
            this.panelLancamentos.Controls.Add(this.lblValor);
            this.panelLancamentos.Controls.Add(this.lblLocal);
            this.panelLancamentos.Controls.Add(this.lblDataCompra);
            this.panelLancamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelLancamentos.Location = new System.Drawing.Point(0, 3);
            this.panelLancamentos.Name = "panelLancamentos";
            this.panelLancamentos.Size = new System.Drawing.Size(1056, 375);
            this.panelLancamentos.TabIndex = 0;
            // 
            // cbFormaPag
            // 
            this.cbFormaPag.FormattingEnabled = true;
            this.cbFormaPag.Location = new System.Drawing.Point(313, 33);
            this.cbFormaPag.Margin = new System.Windows.Forms.Padding(2);
            this.cbFormaPag.Name = "cbFormaPag";
            this.cbFormaPag.Size = new System.Drawing.Size(92, 25);
            this.cbFormaPag.TabIndex = 19;
            this.cbFormaPag.SelectedIndexChanged += new System.EventHandler(this.CbFormaPag_SelectedIndexChanged);
            // 
            // txtVencimento
            // 
            this.txtVencimento.Location = new System.Drawing.Point(502, 33);
            this.txtVencimento.Margin = new System.Windows.Forms.Padding(2);
            this.txtVencimento.Name = "txtVencimento";
            this.txtVencimento.Size = new System.Drawing.Size(76, 23);
            this.txtVencimento.TabIndex = 18;
            // 
            // lblVencimento
            // 
            this.lblVencimento.AutoSize = true;
            this.lblVencimento.Location = new System.Drawing.Point(499, 4);
            this.lblVencimento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVencimento.Name = "lblVencimento";
            this.lblVencimento.Size = new System.Drawing.Size(82, 17);
            this.lblVencimento.TabIndex = 17;
            this.lblVencimento.Text = "Vencimento";
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(1008, 106);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(38, 23);
            this.btnRemover.TabIndex = 9;
            this.btnRemover.Text = "-";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // cbEspecificacao
            // 
            this.cbEspecificacao.FormattingEnabled = true;
            this.cbEspecificacao.Location = new System.Drawing.Point(714, 31);
            this.cbEspecificacao.Name = "cbEspecificacao";
            this.cbEspecificacao.Size = new System.Drawing.Size(98, 25);
            this.cbEspecificacao.TabIndex = 6;
            // 
            // lblEspecificacao
            // 
            this.lblEspecificacao.AutoSize = true;
            this.lblEspecificacao.Location = new System.Drawing.Point(718, 4);
            this.lblEspecificacao.Name = "lblEspecificacao";
            this.lblEspecificacao.Size = new System.Drawing.Size(95, 17);
            this.lblEspecificacao.TabIndex = 16;
            this.lblEspecificacao.Text = "Especificação";
            // 
            // cbClassificacao
            // 
            this.cbClassificacao.FormattingEnabled = true;
            this.cbClassificacao.Location = new System.Drawing.Point(597, 31);
            this.cbClassificacao.Name = "cbClassificacao";
            this.cbClassificacao.Size = new System.Drawing.Size(101, 25);
            this.cbClassificacao.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(960, 106);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(38, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(819, 33);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(226, 23);
            this.txtComentario.TabIndex = 7;
            // 
            // txtParcela
            // 
            this.txtParcela.Location = new System.Drawing.Point(419, 33);
            this.txtParcela.Name = "txtParcela";
            this.txtParcela.Size = new System.Drawing.Size(65, 23);
            this.txtParcela.TabIndex = 4;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(233, 33);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(68, 23);
            this.txtValor.TabIndex = 2;
            // 
            // txtLocal
            // 
            this.txtLocal.Location = new System.Drawing.Point(119, 32);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(68, 23);
            this.txtLocal.TabIndex = 1;
            // 
            // txtDataCompra
            // 
            this.txtDataCompra.Location = new System.Drawing.Point(6, 32);
            this.txtDataCompra.Name = "txtDataCompra";
            this.txtDataCompra.Size = new System.Drawing.Size(100, 23);
            this.txtDataCompra.TabIndex = 0;
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(817, 4);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(80, 17);
            this.lblComentario.TabIndex = 6;
            this.lblComentario.Text = "Comentário";
            // 
            // lblClassificacao
            // 
            this.lblClassificacao.AutoSize = true;
            this.lblClassificacao.Location = new System.Drawing.Point(594, 4);
            this.lblClassificacao.Name = "lblClassificacao";
            this.lblClassificacao.Size = new System.Drawing.Size(90, 17);
            this.lblClassificacao.TabIndex = 5;
            this.lblClassificacao.Text = "Classificação";
            // 
            // lblParcela
            // 
            this.lblParcela.AutoSize = true;
            this.lblParcela.Location = new System.Drawing.Point(416, 4);
            this.lblParcela.Name = "lblParcela";
            this.lblParcela.Size = new System.Drawing.Size(56, 17);
            this.lblParcela.TabIndex = 4;
            this.lblParcela.Text = "Parcela";
            // 
            // lblFormaPag
            // 
            this.lblFormaPag.AutoSize = true;
            this.lblFormaPag.Location = new System.Drawing.Point(310, 4);
            this.lblFormaPag.Name = "lblFormaPag";
            this.lblFormaPag.Size = new System.Drawing.Size(77, 17);
            this.lblFormaPag.TabIndex = 3;
            this.lblFormaPag.Text = "Forma Pag";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(230, 4);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(41, 17);
            this.lblValor.TabIndex = 2;
            this.lblValor.Text = "Valor";
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocal.Location = new System.Drawing.Point(116, 3);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(41, 16);
            this.lblLocal.TabIndex = 1;
            this.lblLocal.Text = "Local";
            // 
            // lblDataCompra
            // 
            this.lblDataCompra.AutoSize = true;
            this.lblDataCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataCompra.Location = new System.Drawing.Point(3, 3);
            this.lblDataCompra.Name = "lblDataCompra";
            this.lblDataCompra.Size = new System.Drawing.Size(37, 16);
            this.lblDataCompra.TabIndex = 0;
            this.lblDataCompra.Text = "Data";
            // 
            // tabExtratos
            // 
            this.tabExtratos.Controls.Add(this.lblExtrato_descricao);
            this.tabExtratos.Controls.Add(this.dgvExtrato);
            this.tabExtratos.Controls.Add(this.menuStrip1);
            this.tabExtratos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabExtratos.Location = new System.Drawing.Point(4, 29);
            this.tabExtratos.Name = "tabExtratos";
            this.tabExtratos.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtratos.Size = new System.Drawing.Size(1052, 381);
            this.tabExtratos.TabIndex = 1;
            this.tabExtratos.Text = "Extratos";
            this.tabExtratos.UseVisualStyleBackColor = true;
            // 
            // lblExtrato_descricao
            // 
            this.lblExtrato_descricao.AutoSize = true;
            this.lblExtrato_descricao.Location = new System.Drawing.Point(6, 44);
            this.lblExtrato_descricao.Name = "lblExtrato_descricao";
            this.lblExtrato_descricao.Size = new System.Drawing.Size(112, 18);
            this.lblExtrato_descricao.TabIndex = 2;
            this.lblExtrato_descricao.Text = "Texto descritivo";
            // 
            // dgvExtrato
            // 
            this.dgvExtrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtrato.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdata,
            this.cLocal,
            this.cValor,
            this.cFormPag,
            this.cParcela,
            this.cVencimento,
            this.cClassificacao,
            this.cEspecificacao,
            this.cComentario,
            this.cIndice});
            this.dgvExtrato.Location = new System.Drawing.Point(6, 92);
            this.dgvExtrato.Name = "dgvExtrato";
            this.dgvExtrato.Size = new System.Drawing.Size(1021, 280);
            this.dgvExtrato.TabIndex = 0;
            this.dgvExtrato.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExtrato_CellEndEdit);
            this.dgvExtrato.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvExtrato_ColumnHeaderMouseClick);
            this.dgvExtrato.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvExtrato_EditingControlShowing);
            // 
            // cdata
            // 
            this.cdata.HeaderText = "Data";
            this.cdata.Name = "cdata";
            // 
            // cLocal
            // 
            this.cLocal.HeaderText = "Local";
            this.cLocal.Name = "cLocal";
            this.cLocal.ToolTipText = "Nome do estabelecimento";
            this.cLocal.Width = 300;
            // 
            // cValor
            // 
            this.cValor.HeaderText = "Valor";
            this.cValor.Name = "cValor";
            // 
            // cFormPag
            // 
            this.cFormPag.HeaderText = "Form. Pag.";
            this.cFormPag.Name = "cFormPag";
            // 
            // cParcela
            // 
            this.cParcela.HeaderText = "Parcela";
            this.cParcela.Name = "cParcela";
            this.cParcela.Width = 50;
            // 
            // cVencimento
            // 
            this.cVencimento.HeaderText = "Vencimento";
            this.cVencimento.Name = "cVencimento";
            // 
            // cClassificacao
            // 
            this.cClassificacao.HeaderText = "Classificação";
            this.cClassificacao.Name = "cClassificacao";
            // 
            // cEspecificacao
            // 
            this.cEspecificacao.HeaderText = "Especificação";
            this.cEspecificacao.Name = "cEspecificacao";
            // 
            // cComentario
            // 
            this.cComentario.HeaderText = "Comentário";
            this.cComentario.Name = "cComentario";
            // 
            // cIndice
            // 
            this.cIndice.HeaderText = "#";
            this.cIndice.Name = "cIndice";
            this.cIndice.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sm_Exibir,
            this.changesToolStripMenuItem,
            this.ferramentasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1046, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sm_Exibir
            // 
            this.sm_Exibir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sm_Exibir_Geral,
            this.sm_Exibir_cartaoDeCredito});
            this.sm_Exibir.Name = "sm_Exibir";
            this.sm_Exibir.Size = new System.Drawing.Size(48, 20);
            this.sm_Exibir.Text = "Exibir";
            // 
            // sm_Exibir_Geral
            // 
            this.sm_Exibir_Geral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sm_Exibir_Geral_todasDespesas,
            this.sm_Exibir_Geral_todasReceitas,
            this.balançoGeralToolStripMenuItem});
            this.sm_Exibir_Geral.Name = "sm_Exibir_Geral";
            this.sm_Exibir_Geral.Size = new System.Drawing.Size(180, 22);
            this.sm_Exibir_Geral.Text = "Geral";
            // 
            // sm_Exibir_Geral_todasDespesas
            // 
            this.sm_Exibir_Geral_todasDespesas.Name = "sm_Exibir_Geral_todasDespesas";
            this.sm_Exibir_Geral_todasDespesas.Size = new System.Drawing.Size(180, 22);
            this.sm_Exibir_Geral_todasDespesas.Text = "Todas despesas";
            this.sm_Exibir_Geral_todasDespesas.Click += new System.EventHandler(this.sm_Exibir_Geral_todasDespesas_Click);
            // 
            // sm_Exibir_Geral_todasReceitas
            // 
            this.sm_Exibir_Geral_todasReceitas.Name = "sm_Exibir_Geral_todasReceitas";
            this.sm_Exibir_Geral_todasReceitas.Size = new System.Drawing.Size(180, 22);
            this.sm_Exibir_Geral_todasReceitas.Text = "Todas receitas";
            this.sm_Exibir_Geral_todasReceitas.Click += new System.EventHandler(this.sm_Exibir_Geral_todasReceitas_Click);
            // 
            // balançoGeralToolStripMenuItem
            // 
            this.balançoGeralToolStripMenuItem.Name = "balançoGeralToolStripMenuItem";
            this.balançoGeralToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.balançoGeralToolStripMenuItem.Text = "Balanço Geral";
            this.balançoGeralToolStripMenuItem.Click += new System.EventHandler(this.balançoGeralToolStripMenuItem_Click);
            // 
            // sm_Exibir_cartaoDeCredito
            // 
            this.sm_Exibir_cartaoDeCredito.Name = "sm_Exibir_cartaoDeCredito";
            this.sm_Exibir_cartaoDeCredito.Size = new System.Drawing.Size(180, 22);
            this.sm_Exibir_cartaoDeCredito.Text = "Cartão de crédito";
            this.sm_Exibir_cartaoDeCredito.Click += new System.EventHandler(this.sm_Exibir_cartaoDeCredito_Click);
            // 
            // changesToolStripMenuItem
            // 
            this.changesToolStripMenuItem.Name = "changesToolStripMenuItem";
            this.changesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.changesToolStripMenuItem.Text = "Changes";
            this.changesToolStripMenuItem.Click += new System.EventHandler(this.ChangesToolStripMenuItem_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(976, 579);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(9, 579);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.corrigirIndicesToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // corrigirIndicesToolStripMenuItem
            // 
            this.corrigirIndicesToolStripMenuItem.Name = "corrigirIndicesToolStripMenuItem";
            this.corrigirIndicesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.corrigirIndicesToolStripMenuItem.Text = "Corrigir índices";
            this.corrigirIndicesToolStripMenuItem.Click += new System.EventHandler(this.corrigirIndicesToolStripMenuItem_Click);
            // 
            // MovimentacaoBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 628);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.tabFinancas);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MovimentacaoBancaria";
            this.Text = "Finanças Sob Controle v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabFinancas.ResumeLayout(false);
            this.tabLancamentos.ResumeLayout(false);
            this.panelLancamentos.ResumeLayout(false);
            this.panelLancamentos.PerformLayout();
            this.tabExtratos.ResumeLayout(false);
            this.tabExtratos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtrato)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLancamentos;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.Label lblDataCompra;
        private System.Windows.Forms.TabControl tabFinancas;
        private System.Windows.Forms.TabPage tabLancamentos;
        private System.Windows.Forms.TabPage tabExtratos;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.TextBox txtDataCompra;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.Label lblClassificacao;
        private System.Windows.Forms.Label lblParcela;
        private System.Windows.Forms.Label lblFormaPag;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtParcela;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbClassificacao;
        private System.Windows.Forms.ComboBox cbEspecificacao;
        private System.Windows.Forms.Label lblEspecificacao;
        private System.Windows.Forms.DataGridView dgvExtrato;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.TextBox txtVencimento;
        private System.Windows.Forms.Label lblVencimento;
        private System.Windows.Forms.ComboBox cbFormaPag;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sm_Exibir;
        private System.Windows.Forms.ToolStripMenuItem sm_Exibir_Geral;
        private System.Windows.Forms.Label lblExtrato_descricao;
        private System.Windows.Forms.ToolStripMenuItem sm_Exibir_Geral_todasDespesas;
        private System.Windows.Forms.ToolStripMenuItem sm_Exibir_Geral_todasReceitas;
        private System.Windows.Forms.ToolStripMenuItem sm_Exibir_cartaoDeCredito;
        private System.Windows.Forms.ToolStripMenuItem balançoGeralToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFormPag;
        private System.Windows.Forms.DataGridViewTextBoxColumn cParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cClassificacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEspecificacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cComentario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIndice;
        private System.Windows.Forms.ToolStripMenuItem changesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem corrigirIndicesToolStripMenuItem;
    }
}

