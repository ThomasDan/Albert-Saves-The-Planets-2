using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Albert_Saves_The_Planets_2.Models;

namespace Albert_Saves_The_Planets_2.DAL
{
    internal class LanguageDBManager
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        internal LanguageDBManager(IConfiguration _configuration)
        {
            this.configuration = _configuration;
            this.connectionString = configuration.GetConnectionString("DBContext");
        }

        internal List<LanguageModel> GetAllLanguages()
        {
            List<LanguageModel> languages = new List<LanguageModel>();


            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(@"SELECT name, code FROM Language");
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                languages.Add(new LanguageModel(
                    reader["name"].ToString(),
                    reader["code"].ToString()
                    ));
            }
            con.Close();

            return languages;
        }
    }
}
