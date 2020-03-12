using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataLayer;
using Entities;

namespace BusinessLayer
{
    public class ClientesBusiness
    {
        public static bool ProbarConexion()
        {
            return ClienteData.ProbarConexion();
        }

        public static bool GuardarCliente(ClientesEntity cliente)
        {
            return ClienteData.GuardarCliente(cliente);
        }
    }
    
}
