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

        internal List<ContentTextModel> GetAllTranslations(string langCode, string pageName)
        {
            List<ContentTextModel> contents = new List<ContentTextModel>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(@"SELECT Content.name AS cName, Translation.text AS tText FROM Translation
	                                            JOIN Language ON Language.code = Translation.languageCode
	                                            JOIN Content ON Content.id = Translation.contentID
	                                            JOIN Page ON Page.id = Content.pageID
	                                            WHERE Translation.languageCode = @langCode
	                                            AND Page.name = @pageName");
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@langCode", langCode);
            cmd.Parameters.AddWithValue("@pageName", pageName);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                contents.Add(new ContentTextModel(
                    reader["cName"].ToString(),
                    reader["tText"].ToString()
                    ));
            }
            con.Close();

            return contents;
        }
    }
}
