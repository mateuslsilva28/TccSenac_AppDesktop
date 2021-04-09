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
    public partial class TelaFuncionario : Form
    {
        public TelaFuncionario()
        {
            InitializeComponent();
        }

        private void TelaFuncionario_Load(object sender, EventArgs e)
        {
            FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
            dgvFuncionario.DataSource = funcionarioDAL.ListarTodos();
        }

        private void btnListarTodos_Click(object sender, EventArgs e)
        {
            FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
            dgvFuncionario.DataSource = funcionarioDAL.ListarTodos();
            AtualizarDataGrid();
        }

        private void btnListarInativos_Click(object sender, EventArgs e)
        {
            FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
            dgvFuncionario.DataSource = funcionarioDAL.ListarInativos();
            AtualizarDataGrid();
        }
        public void AtualizarDataGrid()
        {
            dgvFuncionario.Update();
            dgvFuncionario.Refresh();
        }

        private void btnListarAtivos_Click(object sender, EventArgs e)
        {
            FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
            dgvFuncionario.DataSource = funcionarioDAL.ListarAtivos();
            AtualizarDataGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            TelaFuncionarioCadastro telaFuncionarioCadastro = new TelaFuncionarioCadastro();
            telaFuncionarioCadastro.ShowDialog(this);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var IdSelecionado = dgvFuncionario.CurrentRow.Cells[0].Value;
            TelaFuncionarioCadastro telaFuncionarioCadastro = new TelaFuncionarioCadastro(Convert.ToInt32(IdSelecionado));
            telaFuncionarioCadastro.ShowDialog(this);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var IdSelecionado = dgvFuncionario.CurrentRow.Cells[0].Value;
            
            var pergunta = MessageBox.Show("Tem certeza que deseja excluir?", "Atenção!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (pergunta == DialogResult.Yes)
            {
                FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
                funcionarioDAL.Deletar(Convert.ToInt32(IdSelecionado));
                dgvFuncionario.DataSource = funcionarioDAL.ListarTodos();
                AtualizarDataGrid();
                MessageBox.Show("Funcionário excluído com sucesso");
            }

        }
    }
}
