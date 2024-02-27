using BE_U2_W1_D1_D2_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BE_U2_W1_D1_D2_MVC.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["EdiliziaDB"].ConnectionString.ToString();

        public ActionResult Index()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            List<Dipendente> listaDipendenti = new List<Dipendente>();
            try
            {
                conn.Open();

                string query = "SELECT * FROM Dipendenti";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dipendente dipendente = new Dipendente(
                        reader["Nome"].ToString(),
                        reader["Cognome"].ToString(),
                        reader["Indirizzo"].ToString(),
                        reader["CF"].ToString(),
                        Convert.ToBoolean(reader["Sposato"]),
                        Convert.ToInt32(reader["Numero_Figli"]),
                        reader["Mansione"].ToString());
                    listaDipendenti.Add(dipendente);
                }
            }
            catch (Exception ex)
            {

                Response.Write($"Si è verificato un errore: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            List<Pagamento> listaPagamenti = new List<Pagamento>();

            try
            {
                conn.Open();

                string query = "SELECT * FROM Pagamenti";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pagamento pagamento = new Pagamento()
                    {
                        IDDipendente = Convert.ToInt32(reader["IDDipendente"]),
                        Data_Pagamento = Convert.ToDateTime(reader["Data_Pagamento"]),
                        Ammontare = Convert.ToDecimal(reader["Ammontare"]),
                        Tipo_Pagamento = reader["Tipo_Pagamento"].ToString()
                    };

                    listaPagamenti.Add(pagamento);
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Si è verificato un errore: {ex.Message}");
            }

            finally
            {
                conn.Close();
            }

            ViewBag.ListaDipendenti = listaDipendenti;
            ViewBag.ListaPagamenti = listaPagamenti;


            return View();
        }

    }
}