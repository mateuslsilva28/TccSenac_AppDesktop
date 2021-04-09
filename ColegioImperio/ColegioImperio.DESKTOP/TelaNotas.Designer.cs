namespace ColegioImperio.DESKTOP
{
    partial class TelaNotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaNotas));
            this.cboTurma = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMateria = new System.Windows.Forms.ComboBox();
            this.cboAluno = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.txtFaltas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNovaNota = new System.Windows.Forms.Button();
            this.btnEditarNota = new System.Windows.Forms.Button();
            this.dgvNotasAluno = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.btnAlterar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnListarAtivos = new System.Windows.Forms.ToolStripButton();
            this.btnAtualizar = new System.Windows.Forms.ToolStripButton();
            this.btnNotasAluno = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasAluno)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTurma
            // 
            this.cboTurma.FormattingEnabled = true;
            this.cboTurma.Location = new System.Drawing.Point(22, 92);
            this.cboTurma.Name = "cboTurma";
            this.cboTurma.Size = new System.Drawing.Size(146, 22);
            this.cboTurma.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label1.Location = new System.Drawing.Point(66, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turma";
            // 
            // cboMateria
            // 
            this.cboMateria.FormattingEnabled = true;
            this.cboMateria.Location = new System.Drawing.Point(347, 92);
            this.cboMateria.Name = "cboMateria";
            this.cboMateria.Size = new System.Drawing.Size(127, 22);
            this.cboMateria.TabIndex = 4;
            this.cboMateria.Click += new System.EventHandler(this.cboMateria_Click);
            // 
            // cboAluno
            // 
            this.cboAluno.FormattingEnabled = true;
            this.cboAluno.Location = new System.Drawing.Point(195, 92);
            this.cboAluno.Name = "cboAluno";
            this.cboAluno.Size = new System.Drawing.Size(127, 22);
            this.cboAluno.TabIndex = 3;
            this.cboAluno.Click += new System.EventHandler(this.cboAluno_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label2.Location = new System.Drawing.Point(375, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Matéria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label3.Location = new System.Drawing.Point(229, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Aluno";
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(92, 194);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(114, 20);
            this.txtNota.TabIndex = 4;
            // 
            // txtFaltas
            // 
            this.txtFaltas.Location = new System.Drawing.Point(255, 194);
            this.txtFaltas.Name = "txtFaltas";
            this.txtFaltas.Size = new System.Drawing.Size(114, 20);
            this.txtFaltas.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label4.Location = new System.Drawing.Point(120, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nota";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label5.Location = new System.Drawing.Point(283, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Falta";
            // 
            // btnNovaNota
            // 
            this.btnNovaNota.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnNovaNota.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaNota.ForeColor = System.Drawing.SystemColors.Info;
            this.btnNovaNota.Location = new System.Drawing.Point(12, 3);
            this.btnNovaNota.Name = "btnNovaNota";
            this.btnNovaNota.Size = new System.Drawing.Size(94, 34);
            this.btnNovaNota.TabIndex = 19;
            this.btnNovaNota.Text = "Nova Nota";
            this.btnNovaNota.UseVisualStyleBackColor = false;
            // 
            // btnEditarNota
            // 
            this.btnEditarNota.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEditarNota.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarNota.ForeColor = System.Drawing.SystemColors.Info;
            this.btnEditarNota.Location = new System.Drawing.Point(130, 3);
            this.btnEditarNota.Name = "btnEditarNota";
            this.btnEditarNota.Size = new System.Drawing.Size(94, 34);
            this.btnEditarNota.TabIndex = 20;
            this.btnEditarNota.Text = "Editar Nota";
            this.btnEditarNota.UseVisualStyleBackColor = false;
            // 
            // dgvNotasAluno
            // 
            this.dgvNotasAluno.AllowUserToAddRows = false;
            this.dgvNotasAluno.AllowUserToDeleteRows = false;
            this.dgvNotasAluno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotasAluno.Location = new System.Drawing.Point(-3, 287);
            this.dgvNotasAluno.Name = "dgvNotasAluno";
            this.dgvNotasAluno.ReadOnly = true;
            this.dgvNotasAluno.Size = new System.Drawing.Size(407, 165);
            this.dgvNotasAluno.TabIndex = 21;
            this.dgvNotasAluno.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotasAluno_CellContentDoubleClick);
            this.dgvNotasAluno.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotasAluno_CellContentDoubleClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCancelar.Location = new System.Drawing.Point(107, 230);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 34);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCadastrar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCadastrar.Location = new System.Drawing.Point(268, 230);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(84, 34);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNovo,
            this.btnAlterar,
            this.toolStripSeparator1,
            this.btnListarAtivos,
            this.btnAtualizar});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(489, 39);
            this.toolStrip2.TabIndex = 1;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnListarAtivos
            // 
            this.btnListarAtivos.Image = ((System.Drawing.Image)(resources.GetObject("btnListarAtivos.Image")));
            this.btnListarAtivos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListarAtivos.Name = "btnListarAtivos";
            this.btnListarAtivos.Size = new System.Drawing.Size(130, 36);
            this.btnListarAtivos.Text = "Listar Todos";
            this.btnListarAtivos.Click += new System.EventHandler(this.btnListarAtivos_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(107, 36);
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnNotasAluno
            // 
            this.btnNotasAluno.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnNotasAluno.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotasAluno.ForeColor = System.Drawing.SystemColors.Info;
            this.btnNotasAluno.Location = new System.Drawing.Point(180, 120);
            this.btnNotasAluno.Name = "btnNotasAluno";
            this.btnNotasAluno.Size = new System.Drawing.Size(162, 24);
            this.btnNotasAluno.TabIndex = 3;
            this.btnNotasAluno.Text = "Ver notas do Aluno";
            this.btnNotasAluno.UseVisualStyleBackColor = false;
            this.btnNotasAluno.Click += new System.EventHandler(this.btnNotasAluno_Click);
            // 
            // TelaNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 284);
            this.Controls.Add(this.btnNotasAluno);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvNotasAluno);
            this.Controls.Add(this.btnEditarNota);
            this.Controls.Add(this.btnNovaNota);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFaltas);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboAluno);
            this.Controls.Add(this.cboMateria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTurma);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Name = "TelaNotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notas";
            this.Load += new System.EventHandler(this.TelaNotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasAluno)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTurma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMateria;
        private System.Windows.Forms.ComboBox cboAluno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.TextBox txtFaltas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNovaNota;
        private System.Windows.Forms.Button btnEditarNota;
        private System.Windows.Forms.DataGridView dgvNotasAluno;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnNovo;
        private System.Windows.Forms.ToolStripButton btnAlterar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnListarAtivos;
        private System.Windows.Forms.ToolStripButton btnAtualizar;
        private System.Windows.Forms.Button btnNotasAluno;
    }
}