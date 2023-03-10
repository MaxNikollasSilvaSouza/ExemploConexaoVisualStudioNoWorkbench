using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MySql.Data;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace Mercadinho.Classes
{
    internal class Cadastro 
    {
        string prod_nome = "";
        double prod_preco = 0;
        string validade = "0/00/0000";
        int codigo = 0;

        private string queryString = "";

        //objetos MySQL
        MySqlCommand command;        
        Connection con;
        //Objeto usado para pegar a conexao na outra classe, para eu poder fazer o cadastro nessa
        //consequentemente, se precisar mudar a conexao, eu so mexo em 1 classe inves de todas
        MySqlConnection conexao = null;

        public Cadastro() {
            
            con = new Connection();
            

        }

        public void set_nome_prod(string prodd_nome) { this.prod_nome= prodd_nome; }
        public void set_preco_prod(double prodd_preco) { this.prod_preco= prodd_preco; }
        public void set_validade_prod(string prodd_validade) { this.validade= prodd_validade;}
        public void set_codigo_prod(int prodd_codigo) { this.codigo = prodd_codigo; }


        public string cadastrar()
        {            
            string resp = "No";
            try
            {
                queryString = con.get_insert();

                conexao = con.get_connection();                 
                con.open_conection();      
                command = new MySqlCommand(queryString, conexao) ;
                command.Parameters.AddWithValue("@codigo", this.codigo);
                command.Parameters.AddWithValue("@nome", this.prod_nome);
                command.Parameters.AddWithValue("@preco", this.prod_preco);
                command.Parameters.AddWithValue("@validade", this.validade);
                command.ExecuteNonQuery();
                con.close_conection();
                resp = "Ok";
            }
            catch (Exception e) { resp = e.ToString(); con.close_conection(); }
            return resp;
            
        }       

    }
}
