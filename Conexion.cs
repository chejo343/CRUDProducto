using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CRUDProducto
{
    class Conexion
    {
        private static string str = "datasource=localhost;port=3306;username=root;password=pass123;database=crud_producto;";

        public static MySqlConnection getConexion()
        {
            return new MySqlConnection(str);
        }
    }
}
