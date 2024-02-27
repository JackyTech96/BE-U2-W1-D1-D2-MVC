using BE_U2_W1_D1_D2_MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BE_U2_W1_D1_D2_MVC.Controllers
{
    public class DipendentiController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["EdiliziaDB"].ConnectionString.ToString();
        // GET: Dipendenti
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
                while(reader.Read())
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
            return View(listaDipendenti);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Dipendente nuovoDipendente)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = "INSERT INTO Dipendenti (Nome, Cognome, Indirizzo, CF, Sposato, Numero_Figli, Mansione) " + "VALUES (@Nome, @Cognome, @Indirizzo, @CF, @Sposato, @Numero_Figli, @Mansione)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", nuovoDipendente.Nome);
                cmd.Parameters.AddWithValue("@Cognome", nuovoDipendente.Cognome);
                cmd.Parameters.AddWithValue("@Indirizzo", nuovoDipendente.Indirizzo);
                cmd.Parameters.AddWithValue("@CF", nuovoDipendente.CF);
                cmd.Parameters.AddWithValue("@Sposato", nuovoDipendente.Sposato);
                cmd.Parameters.AddWithValue("@Numero_Figli", nuovoDipendente.Numero_Figli);
                cmd.Parameters.AddWithValue("@Mansione", nuovoDipendente.Mansione);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Response.Write($"Si è verificato un errore: {ex.Message}");
            }
            finally 
            {
                conn.Close(); 
            }

            return View();
           
        }
    }
}