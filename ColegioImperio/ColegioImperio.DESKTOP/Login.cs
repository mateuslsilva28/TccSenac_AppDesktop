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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            VerificarCampos();
            string login = txtLogin.Text;
            string senha = txtSenha.Text;

            FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
            Funcionario funcionario = funcionarioDAL.VerificarLogin(login, senha);

            if(funcionario != null)
            {
                Sessao.Id = funcionario.Id;
                Sessao.Nome = funcionario.Nome;
                Sessao.Tipo = funcionario.IdTipo;
                this.Close();
            }
            else
            {
                MessageBox.Show("Login e/ou senha inválidos");
                LimparCampos();
            }
        }
        public void LimparCampos()
        {
            txtLogin.Text = String.Empty;
            txtSenha.Text = String.Empty;
            txtLogin.Focus();
        }
        public void VerificarCampos()
        {
            if(txtLogin.Text == "")
            {
                MessageBox.Show("Campo de usuário obrigatório");
                return;
            }
            if(txtSenha.Text == "")
            {
                MessageBox.Show("Campo de senha obrigatório");
                return;
            }
        }

        private void linkNovaSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TelaNovaSenha novaSenha = new TelaNovaSenha();
            novaSenha.Show();
        }
    }
}
