namespace ColegioImperio.DESKTOP
{
    partial class TelaAluno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaAluno));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.btnAlterar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.btnListarInativos = new System.Windows.Forms.ToolStripButton();
            this.btnListarAtivos = new System.Windows.Forms.ToolStripButton();
            this.dgvAluno = new System.Windows.Forms.DataGridView();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAluno)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNovo,
            this.btnAlterar,
            this.btnExcluir,
            this.toolStripSeparator1,
            this.btnListarTodos,
            this.btnListarInativos,
            this.btnListarAtivos});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(800, 39);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(84, 36);
            this.btnNovo.Text = "Novo";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(93, 36);
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(91, 36);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnListarTodos
            // 
            this.btnListarTodos.Image = ((System.Drawing.Image)(resources.GetObject("btnListarTodos.Image")));
            this.btnListarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListarTodos.Name = "btnListarTodos";
            this.btnListarTodos.Size = new System.Drawing.Size(130, 36);
            this.btnListarTodos.Text = "Listar Todos";
            this.btnListarTodos.Click += new System.EventHandler(this.btnListarTodos_Click);
            // 
            // btnListarInativos
            // 
            this.btnListarInativos.Image = ((System.Drawing.Image)(resources.GetObject("btnListarInativos.Image")));
            this.btnListarInativos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListarInativos.Name = "btnListarInativos";
            this.btnListarInativos.Size = new System.Drawing.Size(142, 36);
            this.btnListarInativos.Text = "Listar Inativos";
            this.btnListarInativos.Click += new System.EventHandler(this.btnListarInativos_Click);
            // 
            // btnListarAtivos
            // 
            this.btnListarAtivos.Image = ((System.Drawing.Image)(resources.GetObject("btnListarAtivos.Image")));
            this.btnListarAtivos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListarAtivos.Name = "btnListarAtivos";
            this.btnListarAtivos.Size = new System.Drawing.Size(131, 36);
            this.btnListarAtivos.Text = "Listar Ativos";
            this.btnListarAtivos.Click += new System.EventHandler(this.btnListarAtivos_Click);
            // 
            // dgvAluno
            // 
            this.dgvAluno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAluno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAluno.Location = new System.Drawing.Point(0, 39);
            this.dgvAluno.Name = "dgvAluno";
            this.dgvAluno.Size = new System.Drawing.Size(800, 411);
            this.dgvAluno.TabIndex = 6;
            // 
            // TelaAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAluno);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TelaAluno";
            this.Text = "Aluno";
            this.Load += new System.EventHandler(this.TelaAluno_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAluno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnNovo;
        private System.Windows.Forms.ToolStripButton btnAlterar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnListarTodos;
        private System.Windows.Forms.ToolStripButton btnListarInativos;
        private System.Windows.Forms.ToolStripButton btnListarAtivos;
        private System.Windows.Forms.DataGridView dgvAluno;
    }
}