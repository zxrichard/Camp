using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDKauan.DAL;
using System.Data;
using CRUDKauan.model;

namespace CRUDKauan.BLL
{
    public class PessoaBLL
    {
        
        PessoaDAL pessoaDal = new PessoaDAL();

        //metodo pra excluir
        public void Excluir(Pessoa pessoa)
        {
            try
            {
                pessoaDal.Excluir(pessoa);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        
        //metodo pra editar
        public void Editar(Pessoa pessoa)
        {
            try
            {
                pessoaDal.Editar(pessoa);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //metodo pra salvar
        public void Salvar(Pessoa pessoa)
        {
            try
            {
                pessoaDal.Salvar(pessoa);
            }
            catch (Exception erro)
            {

                throw erro;
            }
            
        }
        //Metodo para listar

        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = pessoaDal.Listar();
                return dt;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

    }
}
