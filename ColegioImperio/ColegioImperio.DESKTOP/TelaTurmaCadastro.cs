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
    public partial class TelaTurmaCadastro : Form
    {
        private int IdTurma;
        bool verifica = true;
        public TelaTurmaCadastro()
        {
            InitializeComponent();
        }

        public TelaTurmaCadastro(int Id)
        {
            InitializeComponent();
            IdTurma = Id;
        }

        private void TelaTurmaCadastro_Load(object sender, EventArgs e)
        {
            CarregarSala();
            CarregarMaterias();
            cboStatus.Text = "Ativo";
            cboTurno.SelectedIndex = 0;
            if(IdTurma != 0)
            {
                TurmaDAL turmaDAL = new TurmaDAL();
                Turma turma = turmaDAL.Selecionar(IdTurma);
                txtId.Text = turma.Id.ToString();
                txtCodigo.Text = turma.Cod;
                cboSala.SelectedValue = turma.Sala;
                cboStatus.Enabled = true;
                cboStatus.SelectedIndex = turma.Status;
                cboTurno.Text = turma.Turno;

                for(int i = 0; i<checkMaterias.Items.Count; i++)
                {
                    if (turma.Materias.Contains(((Materia)checkMaterias.Items[i]).Id))
                    {
                        checkMaterias.SetItemChecked(i, true);
                    }
                }
            }
        }

        public void CarregarMaterias()
        {
            MaterialDAL materialDAL = new MaterialDAL();
            ((ListBox)checkMaterias).DataSource = materialDAL.Listar();
            ((ListBox)checkMaterias).ValueMember = "Id";
            ((ListBox)checkMaterias).DisplayMember = "Nome";
        }
        public void CarregarSala()
        {
            SalaDAL salaDAL = new SalaDAL();
            cboSala.DataSource = salaDAL.Listar();
            cboSala.ValueMember = "Id";
            cboSala.DisplayMember = "Codigo";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            VerificarCampos();
            if(verifica != false) { 
                Turma turma = new Turma();
                turma.Cod = txtCodigo.Text;
                turma.Sala = Convert.ToInt32(cboSala.SelectedValue);
                turma.Turno = cboTurno.Text;

                List<int> MateriasSelecionadas = new List<int>();
                foreach(var item in checkMaterias.CheckedItems)
                {
                    MateriasSelecionadas.Add(((Materia)item).Id);
                }
                turma.Materias = MateriasSelecionadas;

                TurmaDAL turmaDAL = new TurmaDAL();
                if(txtId.Text == "")
                {
                    turma.FuncionarioCadastro = Convert.ToString(Sessao.Id);
                    turmaDAL.Cadastrar(turma);
                    MessageBox.Show("Turma cadastrada com sucesso ");
                }
                else
                {
                    turma.FuncionarioAlteracao = Convert.ToString(Sessao.Id);
                    turma.Status = Convert.ToInt32(cboStatus.SelectedIndex);
                    turma.Id = Convert.ToInt32(txtId.Text);
                    turmaDAL.Editar(turma);
                    MessageBox.Show("Turma editada com sucesso");
                }
                DataGridView dgvTurma = (DataGridView)this.Owner.Controls.Find("dgvTurma", true)[0];
                dgvTurma.DataSource = turmaDAL.Listar();
                dgvTurma.Update();
                dgvTurma.Refresh();
                this.Close();
            }
            verifica = true;
        }
        public void VerificarCampos()
        {
            if(txtCodigo.Text == "")
            {
                MessageBox.Show("Código da turma é obrigatório.");
                verifica = false;
                return;
            }
            if(checkMaterias.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleciona ao menos uma matéria");
                verifica = false;
                return;
            }
        }
    }
}
