using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColegioImperio.DAL.Conexao;
using ColegioImperio.DAL.Modelos;

namespace ColegioImperio.DESKTOP
{
    public partial class TelaProfessorMateriaTurma : Form
    {
        int IdProfessor;
        int IdSelecionado = 0;
        public TelaProfessorMateriaTurma()
        {
            InitializeComponent();
        }

        public TelaProfessorMateriaTurma(int Id)
        {
            InitializeComponent();
            IdProfessor = Id;
        }
        private void TelaProfessorMateriaTurma_Load(object sender, EventArgs e)
        {
            ProfessorMateriaTurmaDAL professorMateriaTurmaDAL = new ProfessorMateriaTurmaDAL();
            dgvProfessorMateriaTurma.DataSource = professorMateriaTurmaDAL.ListarMateriasDoProfessor(IdProfessor);

            TurmaDAL turmaDAL = new TurmaDAL();
            cboTurma.DataSource = turmaDAL.Listar();
            cboTurma.ValueMember = "Id";
            cboTurma.DisplayMember = "Cod";
        }

        private void cboMateria_Click(object sender, EventArgs e)
        {
            ProfessorMateriaTurmaDAL professorMateriaTurmaDAL = new ProfessorMateriaTurmaDAL();
            int IdTurma = (int)cboTurma.SelectedValue;
            cboMateria.DataSource = professorMateriaTurmaDAL.ListarMateriasDaTurma(IdTurma);
            cboMateria.ValueMember = "Id";
            cboMateria.DisplayMember = "Materia";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            ProfessorMateriaTurmaDAL professorMateriaTurmaDAL = new ProfessorMateriaTurmaDAL();

            ProfessorMateriaTurma professorMateriaTurma = new ProfessorMateriaTurma();

            professorMateriaTurma.Professor = IdProfessor.ToString();
            professorMateriaTurma.Id = Convert.ToInt32(cboMateria.SelectedValue);

            ProfessorMateriaTurma verificarMateria = professorMateriaTurmaDAL.VerificarMateriaProfessor(Convert.ToInt32(cboMateria.SelectedValue));

            if (verificarMateria != null)
            {
                if (IdSelecionado == 0) {
                    professorMateriaTurmaDAL.CadastrarMateriaProfessor(professorMateriaTurma);
                }
                else
                {
                    professorMateriaTurmaDAL.EditarMateriaProfessor(professorMateriaTurma, IdSelecionado);
                    MessageBox.Show("Matéria do professor editada com sucesso ");
                }
            }
            else
            {
                MessageBox.Show("Essa matéria já foi cadastrada para outro professor");
            }

            dgvProfessorMateriaTurma.DataSource = professorMateriaTurmaDAL.ListarMateriasDoProfessor(IdProfessor);
            dgvProfessorMateriaTurma.Update();
            dgvProfessorMateriaTurma.Refresh();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            IdSelecionado = Convert.ToInt32(dgvProfessorMateriaTurma.CurrentRow.Cells[0].Value);
            ProfessorMateriaTurmaDAL professorMateriaTurmaDAL = new ProfessorMateriaTurmaDAL();

            if(IdSelecionado != 0)
            {
                ProfessorMateriaTurma professorMateriaTurma = professorMateriaTurmaDAL.SelecionarMateriaProfessor(IdSelecionado);

                cboTurma.SelectedValue = Convert.ToInt32(professorMateriaTurma.Turma);

                int IdTurma = (int)cboTurma.SelectedValue;
                cboMateria.DataSource = professorMateriaTurmaDAL.ListarMateriasDaTurma(IdTurma);
                cboMateria.ValueMember = "Id";
                cboMateria.DisplayMember = "Materia";

                cboMateria.SelectedValue = Convert.ToInt32(professorMateriaTurma.Id);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            IdSelecionado = 0;

            IdSelecionado = Convert.ToInt32(dgvProfessorMateriaTurma.CurrentRow.Cells[0].Value);
            ProfessorMateriaTurmaDAL professorMateriaTurmaDAL = new ProfessorMateriaTurmaDAL();
            
            if(IdSelecionado != 0)
            {
                var pergunta = MessageBox.Show("Têm certeza que quer apagar esse registro?", "ATENÇÃO !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(pergunta == DialogResult.Yes)
                {
                    professorMateriaTurmaDAL.DeletarMateriaProfessor(IdSelecionado);
                    MessageBox.Show("Matéria do professor deletada com sucesso");

                    dgvProfessorMateriaTurma.DataSource = professorMateriaTurmaDAL.ListarMateriasDoProfessor(IdProfessor);
                    dgvProfessorMateriaTurma.Update();
                    dgvProfessorMateriaTurma.Refresh();
                }
            }
        
        }
    }
}
