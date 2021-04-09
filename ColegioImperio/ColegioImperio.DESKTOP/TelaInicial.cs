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
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            lblUsuarioLogado.Text = Sessao.Nome;
        }

        private void picFuncionario_Click(object sender, EventArgs e)
        {
            AbrirTelaFuncionario();
        }
        public void AbrirTelaFuncionario()
        {
            if (Sessao.Tipo == 1)
            {
                TelaFuncionario telaFuncionario = new TelaFuncionario();
                telaFuncionario.Show();
            }
        }
        private void picMateria_Click(object sender, EventArgs e)
        {
            TelaMateria telaMateria = new TelaMateria();
            telaMateria.Show();
        }

        private void btnTrocarUsuario_Click(object sender, EventArgs e)
        {
            Sessao.Id = 0;
            Sessao.Nome = "";
            Login login = new Login();
            login.ShowDialog();
            lblUsuarioLogado.Text = Sessao.Nome;
        }

        private void picSala_Click(object sender, EventArgs e)
        {
            TelaSala telaSala = new TelaSala();
            telaSala.Show();
        }

        private void picTurma_Click(object sender, EventArgs e)
        {
            TelaTurma telaTurma = new TelaTurma();
            telaTurma.Show();
        }

        private void picAluno_Click(object sender, EventArgs e)
        {
            TelaAluno telaAluno = new TelaAluno();
            telaAluno.Show();
        }

        private void picProfessor_Click(object sender, EventArgs e)
        {
            TelaProfessor telaProfessor = new TelaProfessor();
            telaProfessor.Show();
        }

        private void picNotas_Click(object sender, EventArgs e)
        {
            TelaNotas telaNotas = new TelaNotas();;
            telaNotas.Show();
        }
    }
}
