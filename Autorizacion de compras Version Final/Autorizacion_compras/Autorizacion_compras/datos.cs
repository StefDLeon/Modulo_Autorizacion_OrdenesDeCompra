using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Autorizacion_compras
{
    public class datos
    {
        string no_form = "5004";
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=hotelfase2; Uid=root; pwd=mar12345;");//Query de la conexion

            conectar.Open(); //abriendo la conexion
            return conectar; // regresa la conexion
        }

        public static DataTable ObtenerIdBanco(string Banco)
        {
            DataTable dt = new DataTable();

            string consulta = " select nombre from banco where idBanco =@Banco"; //consulta

            MySqlCommand comandoB = new MySqlCommand(consulta, ObtenerConexion()); //Comando en el que se pasa la consulta deseada y la conexion
            comandoB.Parameters.AddWithValue("@Banco", Banco); //Agrefa los parametros al Query
            MySqlDataAdapter adap = new MySqlDataAdapter(comandoB); // Adaptador
            adap.Fill(dt); //Llena la datatable con el adaptador del comando

            return dt;

        }

        public static DataTable idmoncu(string noCuenta) //Metodo para traer los datos de la base de datos
        {
            DataTable dt = new DataTable();

            string consulta = "Select idBanco from cuentabanco where cuentabanco.noCuenta = @noCuenta ;"; //consulta

            MySqlCommand comando = new MySqlCommand(consulta, ObtenerConexion()); //Comando en el que se pasa la consulta deseada y la conexion
            comando.Parameters.AddWithValue("@noCuenta", noCuenta); //Parametros que se agregan a la consulta
            MySqlDataAdapter adap = new MySqlDataAdapter(comando); //Adaptador 
            adap.Fill(dt); //Llena la datatable con el adaptador del comando

            return dt; //Regresa la tabla

        }

        public static DataTable ObtenerSaldo(string noCuenta)
        {
            DataTable dt = new DataTable(); //Constructor DataTable

            string consulta = "Select saldoDisponible from cuentabanco,banco where cuentabanco.noCuenta = @noCuenta and banco.idBanco=cuentabanco.idBanco;"; //consulta

            MySqlCommand comando = new MySqlCommand(consulta, ObtenerConexion());
            comando.Parameters.AddWithValue("@noCuenta", noCuenta);//Parametros que se agregan a ala consulta
           // comando.Parameters.AddWithValue("@idBanco", idBanco);//Parametros que se agregan a ala consulta
            MySqlDataAdapter adap = new MySqlDataAdapter(comando); //Adaptador
            adap.Fill(dt); //Llena la datatable con el adaptador del comando

            return dt; //Regresa la tabla

        }

        public static DataTable ObtenertMoneda(string noCuenta) //Metodo para traer los datos de la base de datos
        {
            DataTable dt = new DataTable();

            string consulta = "Select tipoMoneda from cuentabanco,banco where cuentabanco.noCuenta = @noCuenta and banco.idBanco=cuentabanco.idBanco;"; //consulta

            MySqlCommand comando = new MySqlCommand(consulta, ObtenerConexion()); //Comando en el que se pasa la consulta deseada y la conexion
            comando.Parameters.AddWithValue("@noCuenta", noCuenta); //Parametros que se agregan a la consulta
           // comando.Parameters.AddWithValue("@idBanco", idBanco); //Parametros que se agregan a la consulta
            MySqlDataAdapter adap = new MySqlDataAdapter(comando); //Adaptador 
            adap.Fill(dt); //Llena la datatable con el adaptador del comando

            return dt; //Regresa la tabla

        }

        public static DataTable ValorM(string moneda)
        {
            DataTable dt = new DataTable(); //Constructor DataTable

            string consulta = "Select valor from moneda where moneda.moneda = @nombre"; //consulta

            MySqlCommand comando = new MySqlCommand(consulta, ObtenerConexion());
            comando.Parameters.AddWithValue("@nombre", moneda);//Parametros que se agregan a ala consulta
            MySqlDataAdapter adap = new MySqlDataAdapter(comando); //Adaptador
            adap.Fill(dt); //Llena la datatable con el adaptador del comando

            return dt; //Regresa la tabla

        }

        public static void trasladoS(string noCuenta, double saldo) {
            string insert = "UPDATE cuentabanco set saldoDisponible = @saldo where cuentabanco.noCuenta = @noCuenta"; //consulta
            MySqlCommand comando = new MySqlCommand(insert, ObtenerConexion());//Comando del inset
            comando.Parameters.AddWithValue("@noCuenta", noCuenta); //Parametros que se agregan a la consulta
            comando.Parameters.AddWithValue("@saldo", saldo); //Parametros que se agregan a la consulta
            comando.ExecuteNonQuery();// Ejecucion del query para realizar el insert
           }

        public static void actualizacion_saldos()
        {
            string actu = "update cuentabanco set saldoActual = saldoDisponible;"; //consulta
            MySqlCommand comando = new MySqlCommand(actu, ObtenerConexion());//Comando del inset
            comando.ExecuteNonQuery();// Ejecucion del query para realizar el insert
        }

    }
}
