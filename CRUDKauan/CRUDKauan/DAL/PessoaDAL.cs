using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CRUDKauan.model;
using System.Data;

namespace CRUDKauan.DAL
{
    public class PessoaDAL : Conexao
    {
        MySqlCommand comando = null;

        //metodo pra excluir
        public void Excluir(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("DELETE FROM pessoa WHERE id = @id", conexao);
                comando.Parameters.AddWithValue("@id", pessoa.Id);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }
        //metodo pra editar
        public void Editar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("UPDATE pessoa SET nome = @nome, nascimento = @nascimento, " +
                    "sexo = @sexo, cpf = @cpf, celular = @celular, endereco = @endereco, bairro = @bairro, " +
                    "cidade = @cidade, estado = @estado, cep = @cep WHERE id = @id", conexao);
                comando.Parameters.AddWithValue("@nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@nascimento", DateTime.Parse(pessoa.Nascimento).ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                comando.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                comando.Parameters.AddWithValue("@celular", pessoa.Celular);
                comando.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                comando.Parameters.AddWithValue("@bairro", pessoa.Bairro);
                comando.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                comando.Parameters.AddWithValue("@estado", pessoa.Estado);
                comando.Parameters.AddWithValue("@cep", pessoa.Cep);
                comando.Parameters.AddWithValue("@id", pessoa.Id);

                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }


        //metodo para Listar

        public DataTable Listar()
        {
            try
            {
                AbrirConexao();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("SELECT * FROM pessoa ORDER BY nome", conexao);
                da.SelectCommand = comando;
                da.Fill(dt);
                return dt;
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
           
        }
        //metodo pra salvar
        public void Salvar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();
                    comando = new MySqlCommand("INSERT INTO pessoa (nome, nascimento, sexo,"+
                        "cpf, celular, endereco, bairro, cidade, estado, cep) VALUES (@nome,"+
                        "@nascimento, @sexo, @cpf, @celular, @endereco, @bairro, @cidade, @estado, @cep)", conexao);
                comando.Parameters.AddWithValue("@nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@nascimento", DateTime.Parse(pessoa.Nascimento).ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                comando.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                comando.Parameters.AddWithValue("@celular", pessoa.Celular);
                comando.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                comando.Parameters.AddWithValue("@bairro", pessoa.Bairro);
                comando.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                comando.Parameters.AddWithValue("@estado", pessoa.Estado);
                comando.Parameters.AddWithValue("@cep", pessoa.Cep);

                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
