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
    public partial class TelaTurma : Form
    {
        public TelaTurma()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            TelaTurmaCadastro telaTurmaCadastro = new TelaTurmaCadastro();
            telaTurmaCadastro.ShowDialog(this);
        }

        private void TelaTurma_Load(object sender, EventArgs e)
        {
            TurmaDAL turmaDAL = new TurmaDAL();
            dgvTurma.DataSource = turmaDAL.Listar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var IdSelecionado = dgvTurma.CurrentRow.Cells[0].Value; 

            if(IdSelecionado != null) {
                TelaTurmaCadastro telaTurmaCadastro = new TelaTurmaCadastro(Convert.ToInt32(IdSelecionado));
                telaTurmaCadastro.Show(this);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var IdSelecionado = dgvTurma.CurrentRow.Cells[0].Value;

            if (IdSelecionado != null)
            {
                var pergunta = MessageBox.Show("Tem certeza que quer apagar esse registro, essa ação não pode ser revertida!", "ATENÇÃO!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(pergunta == DialogResult.Yes)
                {
                    TurmaDAL turmaDAL = new TurmaDAL();
                    turmaDAL.Deletar(Convert.ToInt32(IdSelecionado));
                    MessageBox.Show("Turma deletada com sucesso ");
                    dgvTurma.DataSource = turmaDAL.Listar();
                    dgvTurma.Update();
                    dgvTurma.Refresh();
                }

            }
        }

        private void btnListarTodos_Click(object sender, EventArgs e)
        {
            TurmaDAL turmaDAL = new TurmaDAL();
            dgvTurma.DataSource = turmaDAL.Listar();
            AtualizarGrid();
        }

        public void AtualizarGrid()
        {
            dgvTurma.Update();
            dgvTurma.Refresh();
        }

        private void btnListarInativos_Click(object sender, EventArgs e)
        {
            TurmaDAL turmaDAL = new TurmaDAL();
            dgvTurma.DataSource = turmaDAL.ListarInativos();
            AtualizarGrid();
        }

        private void btnListarAtivos_Click(object sender, EventArgs e)
        {
            TurmaDAL turmaDAL = new TurmaDAL();
            dgvTurma.DataSource = turmaDAL.ListarAtivos();
            AtualizarGrid();
        }
    }
}
