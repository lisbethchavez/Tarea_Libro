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
    public partial class frmAgregarLibro : Form
    {
        public frmAgregarLibro()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(@"server=DESKTOP-83B08MV\SQLEXPRESS; database=TI2021 ; integrated security = true");

            string sql = "insert into libros(CodLibro,NombreLibro,PrecioCompra,FechaCompra)";
            sql += "values(@CodLibro,@NombreLibro,@PrecioCompra,@FechaCompra)";

            SqlCommand comando = new SqlCommand(sql, conexion);

            comando.Parameters.Add(new SqlParameter("@CodLibro", this.txtCodigo.Text));
            comando.Parameters.Add(new SqlParameter("@NombreLibro", this.txtNombre.Text));
            comando.Parameters.Add(new SqlParameter("@PrecioCompra", this.txtPrecio.Text));
            comando.Parameters.Add(new SqlParameter("@FechaCompra", this.dateTimePicker1.Value));

            conexion.Open();
            int resultado = comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Libro Agregado: " + resultado.ToString());



        }
    }
}
