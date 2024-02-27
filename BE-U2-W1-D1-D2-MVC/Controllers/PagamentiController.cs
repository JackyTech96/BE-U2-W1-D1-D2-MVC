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
    public class PagamentiController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["EdiliziaDB"].ConnectionString.ToString();
        // GET: Pagamenti
        public ActionResult Index()
        {
            SqlConnection conn = new SqlConnection(connectionString);
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

            return View(listaPagamenti);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pagamento nuovoPagamento)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = "INSERT INTO Pagamenti (IDDipendente, Data_Pagamento, Ammontare, Tipo_Pagamento) " + "VALUES (@IDDipendente, @Data_Pagamento, @Ammontare, @Tipo_Pagamento)";
                SqlCommand cmd = new SqlCommand(@query, conn);
                cmd.Parameters.AddWithValue("@IDDipendente", nuovoPagamento.IDDipendente);
                cmd.Parameters.AddWithValue("@Data_Pagamento", nuovoPagamento.Data_Pagamento);
                cmd.Parameters.AddWithValue("@Ammontare", nuovoPagamento.Ammontare);
                cmd.Parameters.AddWithValue("@Tipo_Pagamento", nuovoPagamento.Tipo_Pagamento);

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