using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CRUDKauan.DAL
{
    public class Conexao
    {
        //Propriedades pra conectar no banco de dados  
        string conecta = "SERVER=localhost; DATABASE=pessoas; UID=root; PWD=Suporte99";
        protected MySqlConnection conexao = null;

        //Metodo pra conexao do banco de dados

        public void AbrirConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Open();
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //Fechar conexao

        public void FecharConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
