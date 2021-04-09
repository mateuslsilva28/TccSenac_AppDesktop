using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColegioImperio.DAL.Modelos;
using ColegioImperio.DAL.Conexao;
using System.Security;

namespace ColegioImperio.DESKTOP
{
    public partial class TelaNotas : Form
    {
        bool verifica;
        bool EditarCadastrar;
        public TelaNotas()
        {
            InitializeComponent();
        }
        private void TelaNotas_Load(object sender, EventArgs e)
        {
            this.Height = 320;
            dgvNotasAluno.Dock = DockStyle.None;
            TurmaDAL turmaDAL = new TurmaDAL();
            cboTurma.DataSource = turmaDAL.ListarAtivos();
            cboTurma.ValueMember = "Id";
            cboTurma.DisplayMember = "Cod";
            btnAtualizar.Visible = btnListarAtivos.Visible = false;
        }

        private void cboMateria_Click(object sender, EventArgs e)
        {
            ListarMateriasTurma();
        }

        private void cboAluno_Click(object sender, EventArgs e)
        {
            ListarAlunosTurma();
        }

        private void ListarMateriasTurma()
        {
            NotasDAL notasDAL = new NotasDAL();
            int IdTurma = (int)cboTurma.SelectedValue;
            cboMateria.DataSource = notasDAL.ListarMateriasTurma(IdTurma);
            cboMateria.ValueMember = "Id";
            cboMateria.DisplayMember = "Materia";
        }
        private void ListarAlunosTurma()
        {
            NotasDAL notasDAL = new NotasDAL();
            int IdTurma = (int)cboTurma.SelectedValue;
            cboAluno.DataSource = notasDAL.ListarAlunosTurma(IdTurma);
            cboAluno.ValueMember = "Id";
            cboAluno.DisplayMember = "Nome";
        }
        private void dgvNotasAluno_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int IdNota = (int)dgvNotasAluno.CurrentRow.Cells[0].Value;

            if (IdNota != 0)
            {
                NotasDAL notasDAL = new NotasDAL();
                Notas notas = notasDAL.SelecionarNota(IdNota);

                cboTurma.SelectedValue = Convert.ToInt32(notas.Turma);
                ListarAlunosTurma();
                cboAluno.SelectedValue = Convert.ToInt32(notas.Aluno);
                ListarMateriasTurma();
                cboMateria.SelectedValue = Convert.ToInt32(notas.Materia);

                txtNota.Text = Convert.ToString(notas.Nota);
                txtFaltas.Text = Convert.ToString(notas.Faltas);

                btnCadastrar.Enabled = txtNota.Enabled = txtFaltas.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Verifica();
            if (verifica != true)
            {
                NotasDAL notasDAL = new NotasDAL();
                Notas notas = new Notas();

                notas.Aluno = Convert.ToString(cboAluno.SelectedValue);
                notas.Materia = Convert.ToString(cboMateria.SelectedValue);
                notas.Nota = Convert.ToDecimal(txtNota.Text.Replace(".", ","));
                notas.Faltas = Convert.ToInt32(txtFaltas.Text);

                if (EditarCadastrar == false)
                {
                    notasDAL.CadastrarNota(notas);
                    MessageBox.Show("Nota cadastrada com sucesso");
                }
                else
                {
                    notas.Id = Convert.ToInt32(dgvNotasAluno.CurrentRow.Cells[0].Value);
                    notasDAL.EditarNota(notas);
                    MessageBox.Show("Nota editada com sucesso");
                }
            }
        }
        private void Verifica()
        {
            if (txtNota.Text.Trim() == "")
            {
                verifica = true;
                MessageBox.Show("Nota do aluno é obrigatória ");
                return;
            }
            if (txtFaltas.Text.Trim() == "")
            {
                verifica = true;
                MessageBox.Show("Nota do aluno é obrigatória ");
                return;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int IdTurma = (int)cboTurma.SelectedValue;
            int IdAluno = 0;
            int IdMateria = 0;
            if (cboAluno.SelectedValue != null) IdAluno = (int)cboAluno.SelectedValue;
            if (cboMateria.SelectedValue != null) IdMateria = (int)cboMateria.SelectedValue;

            NotasDAL notasDAL = new NotasDAL();
            if (IdAluno == 0) dgvNotasAluno.DataSource = notasDAL.ListarAlunosNotasGrid(IdTurma);
            else if (IdMateria == 0) dgvNotasAluno.DataSource = notasDAL.ListarMateriaNotasTurma(IdTurma, IdAluno);
            else if ((IdAluno != 0) && (IdMateria != 0)) dgvNotasAluno.DataSource = notasDAL.ListarAlunoMateriaNotasTurma(IdTurma, IdAluno, IdMateria);

            dgvNotasAluno.Update();
            dgvNotasAluno.Refresh();
        }

        private void btnListarAtivos_Click(object sender, EventArgs e)
        {
            NotasDAL notasDAL = new NotasDAL();
            dgvNotasAluno.DataSource = notasDAL.ListarAlunosNotasGrid();
            dgvNotasAluno.Update();
            dgvNotasAluno.Refresh();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            EditarCadastrar = true;
            NotasDAL notasDAL = new NotasDAL();
            this.Height = 488;
            dgvNotasAluno.Dock = DockStyle.Bottom;
            dgvNotasAluno.DataSource = notasDAL.ListarAlunosNotasGrid();
            btnAtualizar.Visible = btnListarAtivos.Visible = true;
            txtNota.Text = txtFaltas.Text = "0";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            EditarCadastrar = false;
            this.Height = 320;
            dgvNotasAluno.Dock = DockStyle.None;
            btnAtualizar.Visible = btnListarAtivos.Visible = false;
            txtNota.Enabled = txtFaltas.Enabled = true;
        }
        private void btnNotasAluno_Click(object sender, EventArgs e)
        {
            if(cboAluno.SelectedValue != null) {
                int IdAluno = (int)cboAluno.SelectedValue;
                NotasDAL notasDAL = new NotasDAL();
                this.Height = 488;
                dgvNotasAluno.Dock = DockStyle.Bottom;
                dgvNotasAluno.DataSource = notasDAL.ListarNotasAluno(IdAluno);
                dgvNotasAluno.Update();
                dgvNotasAluno.Refresh();
            }
            else
            {
                MessageBox.Show("Selecione um aluno");
            }
        }
    }
}
