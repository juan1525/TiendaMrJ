using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entities;

namespace DataLayer
{
    public class ClienteData
    {
        public static bool ProbarConexion()
        {
            using (SqlConnection conex = new SqlConnection
            (ConfigurationManager.ConnectionStrings["Conex_Tienda_MrJ"].ConnectionString))
            {
                conex.Open();
                if (conex.State == ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool GuardarCliente(ClientesEntity cliente)
        {
            using (SqlConnection conex = new SqlConnection
            (ConfigurationManager.ConnectionStrings["Conex_Tienda_MrJ"].ConnectionString))
            {
                conex.Open();
                string sql = @"INSERT INTO Registro_Clientes
                            (TipoDocumentoCli, NumeroDocumentoCli,PrimerNombreCli,SegundoNombreCli,
                             PrimerApellidoCli,SegundoApellidoCli,DireccionCli,
                             EmailCli,Telefono,FechaNacimientoCli)
                             VALUES 
                             (@TipoDocumentoCli,@NumeroDocumentoCli,@PrimerNombreCli,@SegundoNombreCli,
                             @PrimerApellidoCli,@SegundoApellidoCli,@DireccionCli,@EmailCli,
                             @Telefono,@FechaNacimientoCli)";

                SqlCommand cmd = new SqlCommand(sql, conex);

                cmd.Parameters.AddWithValue("@TipoDocumentoCli", cliente.TipoDocumento);
                cmd.Parameters.AddWithValue("@NumeroDocumentoCli", cliente.NumeroDocumento);
                cmd.Parameters.AddWithValue("@PrimerNombreCli", cliente.Primerombre);
                cmd.Parameters.AddWithValue("@SegundoNombreCli", cliente.SegundoNombre);
                cmd.Parameters.AddWithValue("@PrimerApellidoCli", cliente.PrimerApellido);
                cmd.Parameters.AddWithValue("@SegundoApellidoCli", cliente.SegudoApellido);
                cmd.Parameters.AddWithValue("@DireccionCli", cliente.direccion);
                cmd.Parameters.AddWithValue("@EmailCli", cliente.Email);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@FechaNacimientoCli", cliente.FechaNacimiento);

                int NumeroFilas = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (NumeroFilas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
