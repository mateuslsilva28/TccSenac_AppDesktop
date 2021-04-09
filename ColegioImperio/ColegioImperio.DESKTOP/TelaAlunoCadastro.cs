using ColegioImperio.DAL.Conexao;
using ColegioImperio.DAL.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColegioImperio.DESKTOP
{
    public partial class TelaAlunoCadastro : Form
    {
        public int IdAluno;
        public bool verifica = true;
        public TelaAlunoCadastro()
        {
            InitializeComponent();
        }

        public TelaAlunoCadastro(int Id)
        {
            InitializeComponent();
            IdAluno = Id;
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string numeros = "0123456789";
            VerificarCampos();

            if(verifica != false)
            {
                AlunoDAL alunoDAL = new AlunoDAL();
                Aluno aluno = new Aluno();
                aluno.Nome = txtNome.Text;
                aluno.Rg = txtRg.Text;
                aluno.Cpf = txtCpf.Text;
                aluno.Celular = txtCelularAluno.Text;
                aluno.Escolaridade = cboEscolaridade.Text;
                aluno.Pai = txtPai.Text;
                aluno.Mae = txtMae.Text;
                aluno.CelularResponsavel = txtCelularResponsavel.Text;
                aluno.Rua = txtRua.Text;
                aluno.Numero = ((txtNumero.Text.Contains(numeros))) ? Convert.ToInt32(txtNumero.Text) : 0;
                aluno.Complemento = txtComplemento.Text;
                aluno.Bairro = txtBairro.Text;
                aluno.Cep = txtCep.Text;

                List<int> TurmasSelecionadas = new List<int>();
                foreach (var item in checkTurma.CheckedItems)
                {
                    TurmasSelecionadas.Add(((Turma)item).Id);
                }
                aluno.Turmas = TurmasSelecionadas;

                if (txtId.Text == "")
                {
                    aluno.FuncionarioCadastro = Convert.ToString(Sessao.Id);
                    alunoDAL.Inserir(aluno);
                    MessageBox.Show("Aluno cadastrado com sucesso ");
                }
                else
                {
                    aluno.Id = Convert.ToInt32(IdAluno);
                    aluno.Status = cboStatus.SelectedIndex;
                    aluno.FuncionarioAlteracao = Convert.ToString(Sessao.Id);
                    alunoDAL.Editar(aluno);
                    MessageBox.Show("Aluno editado com sucesso ");
                }

                DataGridView dgvAluno = (DataGridView)this.Owner.Controls.Find("dgvAluno", true)[0];
                dgvAluno.DataSource = alunoDAL.Listar();
                dgvAluno.Update();
                dgvAluno.Refresh();
                this.Close();
            }
            verifica = true;
        }
        public void VerificarCampos()
        {
            
            if (txtNome.Text == "")
            {
                MessageBox.Show("Nome do aluno é obrigatório");
                verifica = false;
                return;
            }
            if (txtCpf.Text == "")
            {
                MessageBox.Show("CPF do aluno é obrigatório");
                verifica = false;
                return;
            }
            if (txtRg.Text == "")
            {
                MessageBox.Show("RG do aluno é obrigatório");
                verifica = false;
                return;
            }
            if (txtCelularAluno.Text == "")
            {
                MessageBox.Show("Celular do aluno é obrigatório");
                verifica = false;
                return;
            }
            if (txtMae.Text == "")
            {
                MessageBox.Show("Nome da mãe do aluno é obrigatório");
                verifica = false;
                return;
            }
            if (txtCelularResponsavel.Text == "")
            {
                MessageBox.Show("Celular do responsável é obrigatório");
                verifica = false;
                return;
            }
            if (txtRua.Text == "")
            {
                MessageBox.Show("Rua do aluno é obrigatório");
                verifica = false;
                return;
            }
            if (txtNumero.Text == "")
            {
                MessageBox.Show("Número da rua é obrigatório");
                verifica = false;
                return;
            }
            if(txtBairro.Text == "")
            {
                MessageBox.Show("Bairro é obrigatório");
                verifica = false;
                return;
            }
            if(txtCep.Text == "")
            {
                MessageBox.Show("Bairro da rua é obrigatório");
                verifica = false;
                return;
            }
        }

        public void CarregarTurmas()
        {
            TurmaDAL turmaDAL = new TurmaDAL();

            ((ListBox)checkTurma).DataSource = turmaDAL.ListarAtivos();
            ((ListBox)checkTurma).ValueMember = "Id";
            ((ListBox)checkTurma).DisplayMember = "Cod";
        }

        private void TelaAlunoCadastro_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
            CarregarTurmas();
            cboStatus.Text = "Ativo";
            cboEscolaridade.Text = "Jardim de Infância";
            if(IdAluno != 0)
            {
                AlunoDAL alunoDAL = new AlunoDAL();
                Aluno aluno = alunoDAL.Selecionar(IdAluno);
                txtId.Text = Convert.ToString(IdAluno);
                txtNome.Text = aluno.Nome;
                txtCpf.Text = aluno.Cpf;
                txtRg.Text = aluno.Rg;
                cboEscolaridade.SelectedItem = aluno.Escolaridade;
                txtCelularAluno.Text = aluno.Celular;
                cboStatus.SelectedIndex = aluno.Status;
                cboStatus.Enabled = true;
                txtMae.Text = aluno.Mae;
                txtPai.Text = aluno.Pai;
                txtCelularResponsavel.Text = aluno.CelularResponsavel;
                txtRua.Text = aluno.Rua;
                txtNumero.Text = Convert.ToString(aluno.Numero);
                txtComplemento.Text = aluno.Complemento;
                txtBairro.Text = aluno.Bairro;
                txtCep.Text = aluno.Cep;

                for (int i = 0; i < checkTurma.Items.Count; i++)
                {
                    if (aluno.Turmas.Contains(((Turma)checkTurma.Items[i]).Id))
                    {
                        checkTurma.SetItemChecked(i, true);
                    }
                }
            }
        }
    }
}
