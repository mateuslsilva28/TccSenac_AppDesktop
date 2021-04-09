using ColegioImperio.DAL.Conexao;
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

namespace ColegioImperio.DESKTOP
{
    public partial class TelaProfessorCadastro : Form
    {
        int IdProfessor;
        int IdProfessorCadastrado;
        bool Verifica = true;
        public TelaProfessorCadastro()
        {
            InitializeComponent();
        }
        public TelaProfessorCadastro(int Id)
        {
            InitializeComponent();
            IdProfessor = Id;
        }

        private void TelaProfessorCadastro_Load(object sender, EventArgs e)
        {
            cboStatus.Text = "Ativo";
            cboStatus.Enabled = false;
            btnMaterias.Enabled = false;
            btnMaterias.Text = "Cadastrar Matérias";
            if(IdProfessor != 0)
            {
                ProfessorDAL professorDAL = new ProfessorDAL();
                Professor professor = professorDAL.Selecionar(IdProfessor);

                txtId.Text = Convert.ToString(professor.Id);
                txtNome.Text = professor.Nome;
                txtArea.Text = professor.Area;
                txtCpf.Text = professor.CPF;
                txtEmail.Text = professor.Email;
                txtCelular.Text = professor.Celular;
                cboStatus.SelectedIndex = professor.Status;
                cboStatus.Enabled = true;
                btnMaterias.Enabled = true;
                btnMaterias.Text = "Editar Matérias";
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            VerificarCampos();
            if(Verifica != false)
            {
                Professor professor = new Professor();
                professor.Nome = txtNome.Text;
                professor.Area = txtArea.Text;
                professor.CPF = txtCpf.Text;
                professor.Email = txtEmail.Text;
                professor.Celular = txtCelular.Text;

                ProfessorDAL professorDAL = new ProfessorDAL();
                if(txtId.Text == "")
                {
                    professor.FuncionarioCadastro = Convert.ToString(Sessao.Id);
                    IdProfessorCadastrado = professorDAL.Cadastrar(professor);
                    MessageBox.Show("Professor cadastrado com sucesso");
                    MessageBox.Show("Clique no botão 'Cadastrar Matérias' para cadastrar as matérias do professor");
                    btnMaterias.Enabled = true;
                }
                else
                {
                    professor.Id = Convert.ToInt32(txtId.Text);
                    professor.FuncionarioAlteracao = Convert.ToString(Sessao.Id);
                    professor.Status = Convert.ToInt32(cboStatus.SelectedIndex);
                    professorDAL.Editar(professor);
                    MessageBox.Show("Professor editado com sucesso");
                }
            }
            Verifica = true;
        }

        public void VerificarCampos()
        {
            if(txtNome.Text == "")
            {
                MessageBox.Show("Nome do professor é obrigatório");
                Verifica = false;
                return;
            }
            if (txtArea.Text == "")
            {
                MessageBox.Show("Área do professor é obrigatório");
                Verifica = false;
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("E-mail do professor é obrigatório");
                Verifica = false;
                return;
            }
            if (txtCpf.Text == "")
            {
                MessageBox.Show("CPF do professor é obrigatório");
                Verifica = false;
                return;
            }
            if (txtCelular.Text == "")
            {
                MessageBox.Show("Celular do professor é obrigatório");
                Verifica = false;
                return;
            }
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "") { 
                TelaProfessorMateriaTurma telaProfessorMateriaTurma = new TelaProfessorMateriaTurma(Convert.ToInt32(txtId.Text));
                telaProfessorMateriaTurma.ShowDialog();
            }
            else
            {
                TelaProfessorMateriaTurma telaProfessorMateriaTurma = new TelaProfessorMateriaTurma(IdProfessorCadastrado);
                telaProfessorMateriaTurma.ShowDialog();
            }
            ProfessorDAL professorDAL = new ProfessorDAL();
            DataGridView dgvProfessor = (DataGridView)this.Owner.Controls.Find("dgvProfessor", true)[0];
            dgvProfessor.DataSource = professorDAL.Listar();
            dgvProfessor.Update();
            dgvProfessor.Refresh();
            this.Close();
        }
    }
}
