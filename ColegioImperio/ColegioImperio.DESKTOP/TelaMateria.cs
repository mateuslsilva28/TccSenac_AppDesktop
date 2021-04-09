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
    public partial class TelaMateria : Form
    {
        bool verifica = true;
        public TelaMateria()
        {
            InitializeComponent();
        }

        private void TelaMateria_Load(object sender, EventArgs e)
        {
            MaterialDAL materialDAL = new MaterialDAL();
            dgvMateria.DataSource = materialDAL.Listar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var IdSelecionado = dgvMateria.CurrentRow.Cells[0].Value;
            MaterialDAL materialDAL = new MaterialDAL();

            if(IdSelecionado != null)
            {
                Materia materia = materialDAL.Selecionar(Convert.ToInt32(IdSelecionado));
                txtId.Text = Convert.ToString(materia.Id);
                txtNome.Text = materia.Nome;
            }
            else
            {
                MessageBox.Show("Seleciona uma linha");
            }
        }

        public void AtualizarGrid()
        {
            MaterialDAL materialDAL = new MaterialDAL();
            dgvMateria.DataSource = materialDAL.Listar();
            dgvMateria.Update();
            dgvMateria.Refresh();
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            MaterialDAL materialDAL = new MaterialDAL();

            if (txtId.Text == "")
            {
                if(txtNome.Text == "")
                {
                    MessageBox.Show("O nome da matéria é obrigatório ");
                    verifica = false;
                    return;
                }

                if (verifica != false)
                {
                    Materia materia = new Materia();
                    materia.Nome = txtNome.Text;
                    materia.FuncionarioCadastro = Convert.ToString(Sessao.Id);
                    materialDAL.Cadastrar(materia);

                    MessageBox.Show("Matéria cadastrada com sucesso");
                    txtNome.Text = String.Empty;

                    AtualizarGrid();

                }

                verifica = true;
            }
            else
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show("O nome da matéria é obrigatório ");
                    verifica = false;
                    return;
                }

                if (verifica != false)
                {

                    Materia materia = new Materia();
                    materia.Id = Convert.ToInt32(txtId.Text);
                    materia.Nome = txtNome.Text;
                    materia.FuncionarioAlteracao = Convert.ToString(Sessao.Id);
                    materialDAL.Editar(materia);

                    MessageBox.Show("Matéria editada com sucesso");
                    txtNome.Text = String.Empty;

                    AtualizarGrid();
                }

                verifica = true;
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var IdSelecionado = dgvMateria.CurrentRow.Cells[0].Value;
            MaterialDAL materialDAL = new MaterialDAL();
            
            if (IdSelecionado != null)
            {
                var pergunta = MessageBox.Show("Tem certeza que quer apagar esse registro? ", "Atenção!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(pergunta == DialogResult.Yes)
                {
                    materialDAL.Deletar(Convert.ToInt32(IdSelecionado));
                    MessageBox.Show("Matéria deletada com sucesso");
                    AtualizarGrid();
                }
            }
            else
            {
                MessageBox.Show("Seleciona uma linha");
            }
        }
    }
}
