using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Data
{
    public class ContactData
    {
        public List<ContactoModel> Listar()
        {

            var oLista = new List<ContactoModel>();
            var cn = new Connection();
            using (var connetion = new SqlConnection(cn.getCadenaSQL()))
            {
                connetion.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAR", connetion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),

                        });
                        };
                }
            }

            return oLista;

        }
        public ContactoModel Obtener(int IdContacto)
        {

            var oContacto = new ContactoModel();

            var cn = new Connection();
            using (var connetion = new SqlConnection(cn.getCadenaSQL()))
            {
                connetion.Open();
                SqlCommand cmd = new SqlCommand("SP_LOBTENER", connetion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())


                {

                    while (dr.Read())
                    {
                        {
                            oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                            oContacto.Nombre = dr["Nombre"].ToString();
                            oContacto.Telefono = dr["Telefono"].ToString();
                            oContacto.Correo = dr["Correo"].ToString();

                        };
                    }
                }
            }

            return oContacto;

        }


        public bool Guardar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Connection();

                using (var connetion = new SqlConnection(cn.getCadenaSQL()))
                {
                    connetion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GUARDAR", connetion);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery(); 

                }

                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Editar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Connection();
                using (var connetion = new SqlConnection(cn.getCadenaSQL()))
                {
                    connetion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EDITAR", connetion);
                    cmd.Parameters.AddWithValue("IdContacto", ocontacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery(); 


                }

                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int IdContacto)
        {
            bool rpta;

            try
            {
                var cn = new Connection();
                using (var connetion = new SqlConnection(cn.getCadenaSQL()))
                {
                    connetion.Open();
                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR", connetion);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery(); 
                }

                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
