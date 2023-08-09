using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VotoElectronico
{
    class BDComun
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Conn = new SqlConnection("Data source=ACER-NITRO5; Initial Catalog=VotosElectronicos; User Id=sa; Password=12345678");
            Conn.Open();

            return Conn;
        }
    }
}
