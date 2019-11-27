using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CRUDProducto
{
    class ProductosController
    {
        public static DataTable getProductos()
        {
            try
            {
                var connection = Conexion.getConexion();
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM productos", connection);
                var adapter = new MySqlDataAdapter(command);
                var dt = new DataTable();
                adapter.Fill(dt);
                connection.Close();
                return dt;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public static void addProducto(Producto nuevo)
        {
            try
            {
                var connection = Conexion.getConexion();
                connection.Open();
                var commad = new MySqlCommand("INSERT INTO productos(nombre, precio, existencia, codigo, descripcion) VALUES (@nombre, @precio, @existencia, @codigo, @descripcion)", connection);
                commad.Parameters.AddWithValue("@nombre", nuevo.nombre);
                commad.Parameters.AddWithValue("@precio", nuevo.precio);
                commad.Parameters.AddWithValue("@existencia", nuevo.existencia);
                commad.Parameters.AddWithValue("@codigo", nuevo.codigo);
                commad.Parameters.AddWithValue("@descripcion", nuevo.descripcion);
                commad.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public static void deleteProducto (int id)
        {
            try
            {
                var connection = Conexion.getConexion();
                connection.Open();
                var commad = new MySqlCommand("DELETE FROM productos WHERE id = @id", connection);
                commad.Parameters.AddWithValue("@id", id);
                commad.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public static void updateProducto(Producto editar)
        {
            try
            {
                var connection = Conexion.getConexion();
                connection.Open();
                var commad = new MySqlCommand("UPDATE productos SET nombre = @nombre, precio = @precio, existencia = @existencia, codigo = @codigo, descripcion = @descripcion WHERE id = @id", connection);
                commad.Parameters.AddWithValue("@id", editar.id);
                commad.Parameters.AddWithValue("@nombre", editar.nombre);
                commad.Parameters.AddWithValue("@precio", editar.precio);
                commad.Parameters.AddWithValue("@existencia", editar.existencia);
                commad.Parameters.AddWithValue("@codigo", editar.codigo);
                commad.Parameters.AddWithValue("@descripcion", editar.descripcion);
                commad.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
