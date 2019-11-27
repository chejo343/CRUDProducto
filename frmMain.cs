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
    public partial class btnBorrar : Form
    {
        public btnBorrar()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            getProductos();
        }

        private void getProductos ()
        {
            try
            {
                dgvProductos.Rows.Clear();
                var dt = ProductosController.getProductos();
                foreach (DataRow dr in dt.Rows)
                {
                    var id = dr[0].ToString();
                    var nombre = dr[1].ToString();
                    var precio = dr[2].ToString();
                    var existencia = dr[3].ToString();
                    var codigo = dr[4].ToString();
                    var descripcion = dr[6].ToString();
                    dgvProductos.Rows.Add(id, nombre, precio, existencia, codigo, descripcion);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var agregarForm = new frmEditarProducto();
            var result = agregarForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    var nuevo = agregarForm.nuevo;
                    ProductosController.addProducto(nuevo);
                    this.getProductos();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var indexSelected = dgvProductos.CurrentCell.RowIndex;
            var rowSelected = dgvProductos.Rows[indexSelected];
            var id = rowSelected.Cells[0].Value.ToString();
            var nombre = rowSelected.Cells[1].Value.ToString();
            var result = MessageBox.Show($"Estas seguro de eliminar: \n {nombre}?", "Borrar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                try
                {
                    ProductosController.deleteProducto(Convert.ToInt32(id));
                    this.getProductos();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var indexSelected = dgvProductos.CurrentCell.RowIndex;
            var rowSelected = dgvProductos.Rows[indexSelected];
            var id = Convert.ToInt32(rowSelected.Cells[0].Value);
            var nombre = rowSelected.Cells[1].Value.ToString();
            var precio = Convert.ToDouble(rowSelected.Cells[2].Value.ToString());
            var existencia = Convert.ToDouble(rowSelected.Cells[3].Value.ToString());
            var codigo = rowSelected.Cells[4].Value.ToString();
            var descripcion = rowSelected.Cells[5].Value.ToString();
            var editar = new Producto(id, nombre, precio, existencia, codigo, descripcion);
            var frmEditar = new frmEditarProducto(editar);
            var result = frmEditar.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    var update = frmEditar.nuevo;
                    ProductosController.updateProducto(update);
                    this.getProductos();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
    }
}
