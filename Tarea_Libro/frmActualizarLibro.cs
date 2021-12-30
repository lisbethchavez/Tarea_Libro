using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea_Libro
{
    public partial class frmActualizarLibro : Form
    {
        SqlConnection conexion = new SqlConnection(@"server=DESKTOP-83B08MV\SQLEXPRESS; database=TI2021 ; integrated security = true");
        public frmActualizarLibro()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Buscar = txtBuscar.Text;
            string cadena = "select CodLibro,NombreLibro,FechaCompra,PrecioCompra from libros where NombreLibro=" + Buscar;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                txtCodigo.Text = registro["CodLibro"].ToString();
                txtNombre.Text = registro["NombreLibro"].ToString();
                txtPrecio.Text = registro["PrecioCompra"].ToString();
                dateTimePicker1.Text = registro["FechaCompra"].ToString();


            }
            else
                MessageBox.Show("Ese libro no se encuentra ingresado");
            conexion.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Buscar = txtBuscar.Text;
            string codigo = txtCodigo.Text;
            string fecha = dateTimePicker1.Text;
            string nombre = txtNombre.Text;

            string cadena = "update libros set PrecioCompra=@PrecioCompra,FechaCompra=@FechaCompra,NombreLibro=@NombreLibro where CodLibro=@CodLibro";
                
            SqlCommand comando = new SqlCommand(cadena, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                MessageBox.Show("Los datos se actualizaron correctamente");
                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtPrecio.Text = "";
                dateTimePicker1.Text = "";
            }
            else
                MessageBox.Show("Ese libro no se encuentra ingresado");
            conexion.Close();
        }
    }
}
