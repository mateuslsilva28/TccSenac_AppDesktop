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
    public partial class TelaFuncionarioCadastro : Form
    {
        int IdFuncionario;
        bool verifica = true;
        public TelaFuncionarioCadastro()
        {
            InitializeComponent();
        }

        public TelaFuncionarioCadastro(int Id)
        {
            InitializeComponent();
            IdFuncionario = Id;
        }

        private void TelaFuncionarioCadastro_Load(object sender, EventArgs e)
        {
            TipoFuncionarioDAL tipoFuncionarioDAL = new TipoFuncionarioDAL();
            cboTipo.DataSource = tipoFuncionarioDAL.Listar();
            cboTipo.ValueMember = "Id";
            cboTipo.DisplayMember = "Tipo";
            cboStatus.Text = "Ativo";

            if(IdFuncionario != 0)
            {
                FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
                Funcionario funcionario = funcionarioDAL.Selecionar(IdFuncionario);

                txtId.Text = Convert.ToString(funcionario.Id);
                txtNome.Text = funcionario.Nome;
                txtEmail.Text = funcionario.Email;
                txtSenha.Text = funcionario.Senha;
                cboTipo.SelectedValue = funcionario.IdTipo;
                cboStatus.SelectedIndex = funcionario.Status;
                cboStatus.Enabled = true;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Verificar();

            if(verifica != false) { 

                Funcionario funcionario = new Funcionario();
                funcionario.Nome = txtNome.Text;
                funcionario.Email = txtEmail.Text;
                funcionario.Senha = txtEmail.Text;
                funcionario.IdTipo = Convert.ToInt32(cboTipo.SelectedValue);

                FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
                if(txtId.Text == "")
                {
                    funcionarioDAL.Cadastrar(funcionario);
                    MessageBox.Show("Funcionário cadastrado com sucesso ");
                }
                else
                {
                    funcionario.Id = Convert.ToInt32(txtId.Text);
                    funcionario.Status = Convert.ToInt32(cboStatus.SelectedIndex);
                    funcionarioDAL.Editar(funcionario);
                    MessageBox.Show("Funcionário editado com sucesso");
                }
            

                var dgvFuncionario = (DataGridView)this.Owner.Controls.Find("dgvFuncionario", true)[0];
                dgvFuncionario.DataSource = funcionarioDAL.ListarAtivos();
                dgvFuncionario.Update();
                dgvFuncionario.Refresh();

                this.Close();
            }
            verifica = true;
        }

        public void Verificar()
        {
            if(txtNome.Text == "")
            {
                MessageBox.Show("Nome do funcionário obrigatório ");
                verifica = false;
                return;
            }
            if(txtEmail.Text == "")
            {
                MessageBox.Show("E-mail do funcionário obrigatório ");
                verifica = false;
                return;
            }
            if(txtSenha.Text == "")
            {
                MessageBox.Show("Senha do funcionário obrigatório ");
                verifica = false;
                return;
            }
        }
    }
}
