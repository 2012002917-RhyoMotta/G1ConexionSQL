using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//LIBRERIA
using System.Data.SqlClient;

namespace G1ConexionSQL
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = LAB-C-PC-17\SQLEXPRESS; Initial Catalog = Producto; Integrated Security = True");
        public Form1()
        {
            InitializeComponent();
            ObtenerRegistros();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = LAB-C-PC-17\SQLEXPRESS; Initial Catalog = Producto; Integrated Security = True");
            con.Open();
            MessageBox.Show("Conexion Exitosa");
            con.Close();
            MessageBox.Show("Conexion Cerrada");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == null || textBox2.Text == null || textBox3 == null)
                    MessageBox.Show("Llene los comapos necesarios");
                else
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Insert Into Postres(nombre, precio, stock) values ('"+textBox1.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"')",conn);
                    adapter.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Datos Almacenados Correctamente");
                    ObtenerRegistros();
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR de SQL Verificar en" + ex.ToString());
            }
        }

        //Metodo
        private void ObtenerRegistros()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Postres", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "nombre");
            dataGridView1.DataSource = ds.Tables["nombre"].DefaultView;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
