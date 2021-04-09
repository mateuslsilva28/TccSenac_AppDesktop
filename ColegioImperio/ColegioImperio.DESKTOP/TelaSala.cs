using ColegioImperio.DAL.Conexao;
using ColegioImperio.DAL.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColegioImperio.DESKTOP
{
    public partial class TelaSala : Form
    {
        bool verifica = true;
        public TelaSala()
        {
            InitializeComponent();
        }

        private void TelaSala_Load(object sender, EventArgs e)
        {
            SalaDAL salaDAL = new SalaDAL();
            dgvSala.DataSource = salaDAL.Listar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            SalaDAL salaDAL = new SalaDAL();

            if (txtId.Text == "")
            {
                if (txtNumero.Text == "")
                {
                    MessageBox.Show("O número da sala é obrigatório ");
                    verifica = false;
                    return;
                }

                if(verifica != false) { 
                    Sala sala = new Sala();
                    sala.Codigo = txtNumero.Text;
                    sala.Andar = txtAndar.Text;
                    salaDAL.Cadastrar(sala);

                    MessageBox.Show("Sala cadastrada com sucesso");

                    LimparCampos();
                    AtualizarGrid();
                }

                verifica = true;
            }
            else
            {
                if (txtNumero.Text == "")
                {
                    MessageBox.Show("O nome da matéria é obrigatório ");
                    verifica = false;
                    return;
                }

                if (verifica != false)
                {


                    Sala sala = new Sala();
                    sala.Id = Convert.ToInt32(txtId.Text);
                    sala.Codigo = txtNumero.Text;
                    sala.Andar = txtAndar.Text;
                    salaDAL.Editar(sala);

                    MessageBox.Show("Sala editada com sucesso");

                    LimparCampos();
                    AtualizarGrid();
                }

                verifica = true;
            }
        }
        public void LimparCampos()
        {
            txtId.Text =
            txtNumero.Text =
            txtAndar.Text = String.Empty;

        }
        public void AtualizarGrid()
        {
            SalaDAL salaDAL = new SalaDAL();
            dgvSala.DataSource = salaDAL.Listar();
            dgvSala.Update();
            dgvSala.Refresh();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var IdSelecionado = dgvSala.CurrentRow.Cells[0].Value;

            if(IdSelecionado != null)
            {
                SalaDAL salaDAL = new SalaDAL();
                Sala sala = salaDAL.Selecionar(Convert.ToInt32(IdSelecionado));

                txtId.Text = Convert.ToString(sala.Id);
                txtNumero.Text = sala.Codigo;
                txtAndar.Text = sala.Andar;
            }
            else
            {
                MessageBox.Show("Selecione uma linha ");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var IdSelecionado = dgvSala.CurrentRow.Cells[0].Value;
            if (IdSelecionado != null)
            {
                var pergunta = MessageBox.Show("Tem certeza que quer excluir esse registro? ", "ATENÇÃO !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(pergunta == DialogResult.Yes)
                {
                    SalaDAL salaDAL = new SalaDAL();
                    salaDAL.Deletar(Convert.ToInt32(IdSelecionado));
                    MessageBox.Show("Sala deletada com sucesso");
                    AtualizarGrid();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha ");
            }
        }
    }
}
