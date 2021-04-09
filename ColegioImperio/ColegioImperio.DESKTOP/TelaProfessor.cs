using ColegioImperio.DAL.Conexao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColegioImperio.DESKTOP
{
    public partial class TelaProfessor : Form
    {
        public TelaProfessor()
        {
            InitializeComponent();
        }

        private void TelaProfessor_Load(object sender, EventArgs e)
        {
            ProfessorDAL professorDAL = new ProfessorDAL();
            dgvProfessor.DataSource = professorDAL.Listar();
        }

        public void AtualizarGrid()
        {
            dgvProfessor.Update();
            dgvProfessor.Refresh();
        }

        private void btnListarTodos_Click(object sender, EventArgs e)
        {
            ProfessorDAL professorDAL = new ProfessorDAL();
            dgvProfessor.DataSource = professorDAL.Listar();
        }

        private void btnListarInativos_Click(object sender, EventArgs e)
        {
            ProfessorDAL professorDAL = new ProfessorDAL();
            dgvProfessor.DataSource = professorDAL.ListarInativos();
            AtualizarGrid();
        }

        private void btnListarAtivos_Click(object sender, EventArgs e)
        {
            ProfessorDAL professorDAL = new ProfessorDAL();
            dgvProfessor.DataSource = professorDAL.ListarAtivos();
            AtualizarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ProfessorDAL professorDAL = new ProfessorDAL();

            var IdSelecionado = dgvProfessor.CurrentRow.Cells[0].Value;

            if(IdSelecionado != null)
            {
                var pergunta = MessageBox.Show("Tem certeza que quer apagar esse registro? ", "ATENÇÃO!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(pergunta == DialogResult.Yes)
                {
                    professorDAL.Deletar(Convert.ToInt32(IdSelecionado));
                    MessageBox.Show("Profesor deletado com sucesso");
                    dgvProfessor.DataSource = professorDAL.Listar();
                    AtualizarGrid();
                }
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            TelaProfessorCadastro telaProfessorCadastro = new TelaProfessorCadastro();
            telaProfessorCadastro.Show(this);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var IdSelecionado = dgvProfessor.CurrentRow.Cells[0].Value;

            if(IdSelecionado != null)
            {
                TelaProfessorCadastro telaProfessorCadastro = new TelaProfessorCadastro(Convert.ToInt32(IdSelecionado));
                telaProfessorCadastro.Show(this);
            }
        }
    }
}
