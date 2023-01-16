using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Final_Year_Project
{
    public static class connection
    {
        public static MySqlConnection con = new MySqlConnection("server=localhost;database=mr_biggs;uid=root;pwd=\"\";");
     
    }
}
