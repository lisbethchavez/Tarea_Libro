using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tarea_Libro
{
    public partial class frmBuscarLibro : Form
    {
        public frmBuscarLibro()
        {
            InitializeComponent();
        }

        private void frmBuscarLibro_Load(object sender, EventArgs e)
        {
            
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(@"server=DESKTOP-83B08MV\SQLEXPRESS; database=TI2021 ; integrated security = true");

            conexion.Open();
            string cod = txtBuscar.Text;
            string cadena = "select CodLibro,PrecioCompra,FechaCompra from libros where NombreLibro=" + cod;
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
    }
}


