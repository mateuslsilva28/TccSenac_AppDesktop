using ColegioImperio.DAL.Modelos;
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

namespace ColegioImperio.DESKTOP
{
    public partial class TelaAluno : Form
    {
        public TelaAluno()
        {
            InitializeComponent();
        }

        private void TelaAluno_Load(object sender, EventArgs e)
        {
            AlunoDAL alunoDAL = new AlunoDAL();
            dgvAluno.DataSource = alunoDAL.Listar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            TelaAlunoCadastro telaAlunoCadastro = new TelaAlunoCadastro();
            telaAlunoCadastro.Show(this);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var IdSelecionado = dgvAluno.CurrentRow.Cells[0].Value;

            if (IdSelecionado != null)
            {
                TelaAlunoCadastro telaAlunoCadastro = new TelaAlunoCadastro(Convert.ToInt32(IdSelecionado));
                telaAlunoCadastro.Show(this);
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var IdSelecionado = dgvAluno.CurrentRow.Cells[0].Value;

            if(IdSelecionado != null)
            {
                var pergunta = MessageBox.Show("Você tem certeza que quer apagar esse registro? Essa ação não poderá ser alterada ", "ATENÇÃO!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(pergunta == DialogResult.Yes)
                {
                    AlunoDAL alunoDAL = new AlunoDAL();
                    alunoDAL.Deletar(Convert.ToInt32(IdSelecionado));
                    MessageBox.Show("Aluno deletado com sucesso");
                    dgvAluno.DataSource = alunoDAL.Listar();
                    AtualizarGrid();
                }
            }
        }

        public void AtualizarGrid()
        {
            dgvAluno.Update();
            dgvAluno.Refresh();
        }
        private void btnListarInativos_Click(object sender, EventArgs e)
        {
            AlunoDAL alunoDAL = new AlunoDAL();
            dgvAluno.DataSource = alunoDAL.ListarInativos();
            AtualizarGrid();
        }

        private void btnListarAtivos_Click(object sender, EventArgs e)
        {
            AlunoDAL alunoDAL = new AlunoDAL();
            dgvAluno.DataSource = alunoDAL.ListarAtivos();
            AtualizarGrid();
        }

        private void btnListarTodos_Click(object sender, EventArgs e)
        {
            AlunoDAL alunoDAL = new AlunoDAL();
            dgvAluno.DataSource = alunoDAL.Listar();
            AtualizarGrid();
        }
    }
}
