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
    public partial class TelaNovaSenha : Form
    {
        public TelaNovaSenha()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void VerificarCampos()
        {
            if (txtLogin.Text == "")
            {
                MessageBox.Show("Campo de usuário obrigatório");
                return;
            }
            if (txtNovaSenha.Text == "")
            {
                MessageBox.Show("Campo de senha obrigatório");
                return;
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            VerificarCampos();
            string login = txtLogin.Text;
            string novaSenha = txtNovaSenha.Text;
            string novaSenhaConfirmada = txtNovaSenhaConfirmada.Text;

            if(novaSenha == novaSenhaConfirmada)
            {
                FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
                funcionarioDAL.TrocarSenha(login, novaSenha);
                MessageBox.Show("Senha alterada com sucesso");
                this.Close();
            }
            else
            {
                MessageBox.Show("As senhas digitadas não são iguais");
            }
        }
    }
}
