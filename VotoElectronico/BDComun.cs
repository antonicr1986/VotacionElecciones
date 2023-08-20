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
            SqlConnection Conn = new SqlConnection("workstation id=BDPruebasAntonicr1986.mssql.somee.com;packet size=4096;user id=antonicr1986_SQLLogin_2;pwd=3wptkt5v4v;data source=BDPruebasAntonicr1986.mssql.somee.com;persist security info=False;initial catalog=BDPruebasAntonicr1986");
            Conn.Open();

            return Conn;
        }
    }
}
