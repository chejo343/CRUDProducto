using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDProducto
{
    public partial class frmEditarProducto : Form
    {
        public Producto nuevo { get; set; }
        private bool edit = false;
        private int id;
        public frmEditarProducto()
        {
            InitializeComponent();
        }

        public frmEditarProducto(Producto editar)
        {
            InitializeComponent();
            txtNombre.Text = editar.nombre;
            txtCodigo.Text = editar.codigo;
            txtPrecio.Value = Convert.ToDecimal(editar.precio);
            txtExistencia.Value = Convert.ToDecimal(editar.existencia);
            txtDescripcion.Text = editar.descripcion;
            this.id = editar.id;
            this.edit = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text;
            var codigo = txtCodigo.Text;
            var precio = Convert.ToDouble(txtPrecio.Value);
            var existencia = Convert.ToDouble(txtExistencia.Value);
            var descripcion = txtDescripcion.Text;
            if (this.edit)
            {
                this.nuevo = new Producto(this.id, nombre, precio, existencia, codigo, descripcion);
            } else
            {
                this.nuevo = new Producto(nombre, precio, existencia, codigo, descripcion);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
