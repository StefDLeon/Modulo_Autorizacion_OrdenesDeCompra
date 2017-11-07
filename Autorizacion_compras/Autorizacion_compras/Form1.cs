using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autorizacion_compras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string no_form = "5004";
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void button3_Click(object sender, EventArgs e)
        {

            string noCuenta = textBox1.Text;
            negocios.ObtenerSaldo(noCuenta);
            MessageBox.Show("El saldo de la cuenta " + noCuenta + " es " + negocios.SCuenta);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string nCuenta = textBox1.Text;
            negocios.ObtenertMoneda(nCuenta);


        }

        private void button4_Click(object sender, EventArgs e)
        {
             
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           // string nBancoO;
            string noCuentaO = textBox1.Text;
            //nBancoO = Convert.ToString(oBancoCB.SelectedItem.ToString());
            //negocios.ObtenerID(nBancoO);

            negocios.ObtenerSaldo(noCuentaO);
            negocios.ObtenertMoneda(noCuentaO);
            negocios.ObtenerIdBanco(noCuentaO);
            negocios.ObtenerID(negocios.nomBanco);

            lbl_saldo.Text = Convert.ToString(negocios.saldo);
            lbl_Tmoneda.Text = negocios.tMoneda;
            lbl_nBancoO.Text = negocios.bancoN;
            string noCuentaD = textBox4.Text;
            //string nBancoD;

            //nBancoD = Convert.ToString(dBancoCB.SelectedItem.ToString());
            //negocios.ObtenerID(nBancoD);
            negocios.ObtenerSaldo(noCuentaD);
            negocios.ObtenertMoneda(noCuentaD);
            negocios.ObtenerIdBanco(noCuentaD);
            negocios.ObtenerID(negocios.nomBanco);

            lbl_SaldoD.Text = Convert.ToString(negocios.saldo);
            lbl_tMonedaD.Text = negocios.tMoneda;
            lbl_nBancoD.Text = negocios.bancoN;



        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //Datos de origen/////////////////////////////////////////////////
           
            string noCuentaO = textBox1.Text;
            negocios.ObtenerSaldo(noCuentaO);
            negocios.ObtenertMoneda(noCuentaO);
            double saldoO = negocios.saldo;

            //Datos del destino////////////////////////////////////////////////
            string noCuentaD = textBox4.Text;
            negocios.ObtenerSaldo(noCuentaD);
            negocios.ObtenertMoneda(noCuentaD);
            double saldoD = negocios.saldo;

            //Monto del traslado///////////////////////////////////////
            double tras = Convert.ToDouble(txt_traslado.Text);

            // LLamada a negocios ////////////////////////////////////
            negocios.TraspasoSaldo(noCuentaO,noCuentaD,saldoO,saldoD,tras);
            //Carga de labels;

            negocios.ObtenerSaldo(noCuentaO);
            negocios.ObtenertMoneda(noCuentaO);

            lbl_saldo.Text = Convert.ToString(negocios.saldo);
            lbl_Tmoneda.Text = negocios.tMoneda;

           // string noCuentaD = textBox4.Text;
            //string nBancoD;

            //nBancoD = Convert.ToString(dBancoCB.SelectedItem.ToString());
            //negocios.ObtenerID(nBancoD);
            negocios.ObtenerSaldo(noCuentaD);
            negocios.ObtenertMoneda(noCuentaD);
            lbl_SaldoD.Text = Convert.ToString(negocios.saldo);
            lbl_tMonedaD.Text = negocios.tMoneda;
        }

        public void Habilitador_timer()
        {
            timer1.Interval = 50400000;
            timer1.Enabled = true;
            // Hook up timer's tick event handler.
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            datos.actualizacion_saldos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            negocios.ObtenerValorM("Dolares"); //Prueba de funcion Obtener ValorM   AUN NO FUNCIONAL
            MessageBox.Show("Valor: "+negocios.VMoneda ); //Muestra valor moneda AUN NO FUNCIONAL

        }
    }
}
