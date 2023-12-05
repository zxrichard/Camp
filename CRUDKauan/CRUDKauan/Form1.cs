using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDKauan.BLL;
using CRUDKauan.model;

namespace CRUDKauan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        //Metodo para Excluir
        private void Excluir(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                if (txtCodigo.Text == string.Empty)
                {
                    MessageBox.Show("Selecione um cadastro para ser excluido!\n", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(MessageBox.Show("Deseja excluir o cadastro selecionado?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    pessoa.Id = Convert.ToInt32(txtCodigo.Text);
                    pessoaBLL.Excluir(pessoa);
                    MessageBox.Show("Cadastro excluido com sucesso!\n", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Selecione!\n" + e, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Metodo pra Editar
        public void Editar (Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                if (txtNome.Text.Trim() == string.Empty || txtNome.Text.Trim().Length < 3)
                {
                    MessageBox.Show("O campo NOME NÃO pode ser vazio!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error); // exibe uma caixa de alerta ao usuario
                    txtNome.BackColor = Color.LightSlateGray; //muda cor do campo
                    cbSexo.BackColor = Color.White;
                    mtbCpf.BackColor = Color.White;
                }
                else if (!mtbCpf.MaskCompleted)
                {
                    MessageBox.Show("O campo CPF NÃO pode ser vazio!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error); // exibe uma caixa de alerta ao usuario
                    txtNome.BackColor = Color.White; //muda cor do campo
                    cbSexo.BackColor = Color.White;
                    mtbCpf.BackColor = Color.LightSlateGray;
                }
                else if (cbSexo.Text == string.Empty)
                {
                    MessageBox.Show("O campo SEXO NÃO pode ser vazio!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error); // exibe uma caixa de alerta ao usuario
                    txtNome.BackColor = Color.White; //muda cor do campo
                    cbSexo.BackColor = Color.LightSlateGray;
                    mtbCpf.BackColor = Color.White;
                }
                else
                {
                    pessoa.Id = Convert.ToInt32(txtCodigo.Text);
                    pessoa.Nome = txtNome.Text;
                    pessoa.Nascimento = dtNascimento.Text;
                    pessoa.Sexo = cbSexo.Text;
                    mtbCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira mascara do campo cpf
                    pessoa.Cpf = mtbCpf.Text;
                    mtbCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    pessoa.Celular = mtbCelular.Text;
                    pessoa.Endereco = txtEndereco.Text;
                    pessoa.Bairro = txtBairro.Text;
                    pessoa.Cidade = txtCidade.Text;
                    pessoa.Estado = cbEstados.Text;
                    mtbCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    pessoa.Cep = mtbCep.Text;

                    pessoaBLL.Editar(pessoa);
                    MessageBox.Show("Cadastro alterado com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
            }
            catch (Exception e)
            {

                pessoaBLL.Editar(pessoa);
                MessageBox.Show("Cadastro realizado com sucesso!\n" + e, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //Metodo pra Limpar
        public void Limpar()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            mtbCpf.Clear();
            mtbCelular.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            mtbCep.Clear();
            cbSexo.SelectedIndex = -1;
            cbEstados.SelectedIndex = -1;
            txtNome.BackColor = Color.White; //muda cor do campo
            cbSexo.BackColor = Color.White;
            mtbCpf.BackColor = Color.White;
            dtNascimento.ResetText();
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false ;
        }
        //Metodo para Salvar
        private void Salvar (Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                if (txtNome.Text.Trim() == string.Empty || txtNome.Text.Trim().Length < 3)
                {
                    MessageBox.Show("O campo NOME NÃO pode ser vazio!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error); // exibe uma caixa de alerta ao usuario
                    txtNome.BackColor = Color.LightSlateGray; //muda cor do campo
                    cbSexo.BackColor = Color.White;
                    mtbCpf.BackColor = Color.White;
                }
                else if (!mtbCpf.MaskCompleted)
                {
                    MessageBox.Show("O campo CPF NÃO pode ser vazio!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error); // exibe uma caixa de alerta ao usuario
                    txtNome.BackColor = Color.White; //muda cor do campo
                    cbSexo.BackColor = Color.White;
                    mtbCpf.BackColor = Color.LightSlateGray;
                }
                else if (cbSexo.Text == string.Empty)
                {
                    MessageBox.Show("O campo SEXO NÃO pode ser vazio!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error); // exibe uma caixa de alerta ao usuario
                    txtNome.BackColor = Color.White; //muda cor do campo
                    cbSexo.BackColor = Color.LightSlateGray;
                    mtbCpf.BackColor = Color.White;
                }
                else
                {
                    pessoa.Nome = txtNome.Text;
                    pessoa.Nascimento = dtNascimento.Text;
                    pessoa.Sexo = cbSexo.Text;
                    mtbCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira mascara do campo cpf
                    pessoa.Cpf = mtbCpf.Text;
                    mtbCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    pessoa.Celular = mtbCelular.Text;
                    pessoa.Endereco = txtEndereco.Text;
                    pessoa.Bairro = txtBairro.Text;
                    pessoa.Cidade = txtCidade.Text;
                    pessoa.Estado = cbEstados.Text;
                    mtbCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    pessoa.Cep = mtbCep.Text;

                    pessoaBLL.Salvar(pessoa);
                    MessageBox.Show("Cadastro realizado com sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                    
                }
            }
            catch (Exception erro)
            {
                pessoaBLL.Salvar(pessoa);
                MessageBox.Show("Cadastro realizado com sucesso!\n" + erro, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        //Metodo para listar os dados no grid
        private void Listar()
        {
            PessoaBLL pessoaBll = new PessoaBLL();
            try
            {
                dataGridView.DataSource = pessoaBll.Listar();
            }
            catch (Exception e)
            {

                MessageBox.Show( "Erro ao exibir os dados.\n"+ e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnExibir_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Salvar(pessoa);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        
        //evento duplo click
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            dtNascimento.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            cbSexo.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            mtbCpf.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            mtbCelular.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            txtEndereco.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            txtBairro.Text = dataGridView.CurrentRow.Cells[7].Value.ToString();
            txtCidade.Text = dataGridView.CurrentRow.Cells[8].Value.ToString();
            cbEstados.Text = dataGridView.CurrentRow.Cells[9].Value.ToString();
            mtbCep.Text = dataGridView.CurrentRow.Cells[10].Value.ToString();
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Editar(pessoa);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Excluir(pessoa);
        }
    }
}
