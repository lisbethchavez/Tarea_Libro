﻿using System;
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
    public partial class frmBorrarLibro : Form
    {
        private SqlConnection conexion = new SqlConnection(@"server=DESKTOP-83B08MV\SQLEXPRESS ; database=TI2021 ; integrated security = true");

        public frmBorrarLibro()
        {
            InitializeComponent();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string cod = txtNLibro.Text;
            string cadena = "delete from libros where CodLibro=@CodLibro";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                txtCodigo.Text = "";
                txtPrecio.Text = "";
                txtNombre.Text = "";
                dateTimePicker1.Text = "";
                
                MessageBox.Show("Libro eliminado correctamente");
            }
            else
                MessageBox.Show("No se encuentra ingresado ese libro");
            conexion.Close();
            
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string cod = txtNLibro.Text;
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
                MessageBox.Show("No existe el libro ingresado");
            conexion.Close();
        }
    }
}
