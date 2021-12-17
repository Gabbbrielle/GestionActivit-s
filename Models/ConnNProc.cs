using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GestionActivités.Models.Activites;
using GestionActivités.Models.Participants;

namespace GestionActivites.Models
{
    public class ConnNProc
    {
        public ConnNProc()
        {

        }

        public List<Activite> GetListActivites()
        {
            ConnNProc c = new ConnNProc();
            List<Activite> listeActivite = new List<Activite>();
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;

            string connectionString = "Data Source=DESKTOP-5BJVM3V;Initial Catalog=Activities;Integrated Security=True;Pooling=False";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetListActivities";
            cmd.Connection = conn;
            conn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Activite a = new Activite();
                a.id = reader.GetInt32("ActivityId");
                a.nomActivite = reader.GetString("NomActivite");
                a.emplacement = reader.GetString("Emplacement");
                a.dateActivite = reader.GetDateTime("DateActivite");
                a.debut = reader.GetDateTime("Debut");
                a.fin = reader.GetDateTime("Fin");
                a.prix = (double)reader.GetDecimal("Prix");
                a.vote = reader.GetInt32("vote");
                listeActivite.Add(a);
            }
            return listeActivite;
        }

        public List<Participant> GetParticipants()
        {
            List<Participant> listeParticipants = new List<Participant>();
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            string connectionString = "Data Source=DESKTOP-5BJVM3V;Initial Catalog=Activities;Integrated Security=True;Pooling=False";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetParticipants";
            cmd.Connection = conn;
            conn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Participant p = new Participant();
                p.id = reader.GetInt32("Id");
                p.nom = reader.GetString("Nom");
                p.activite = reader.GetString("Activite");

                listeParticipants.Add(p);
            }
            
            return listeParticipants;
        }
        public int CountVotes()
        {
            Int32 count = 0;
            SqlConnection conn;
            SqlCommand cmd;
            string connectionString = "Data Source=DESKTOP-5BJVM3V;Initial Catalog=Activities;Integrated Security=True;Pooling=False";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CountVotes";
            cmd.Connection = conn;
            conn.Open();
            count = (Int32) cmd.ExecuteScalar();
            conn.Close();
            return count;
        }
        public static void CreateParticipant(Participant p)
        {
            SqlConnection conn;
            SqlCommand cmd;
            string connectionString = "Data Source=DESKTOP-5BJVM3V;Initial Catalog=Activities;Integrated Security=True;Pooling=False";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CreateParticipant";
            cmd.Parameters.Add(new SqlParameter("@Param1", p.nom));
            cmd.Parameters.Add(new SqlParameter("@Param2", p.activite));
            cmd.Connection = conn;
            conn.Open();
            int rowCount = cmd.ExecuteNonQuery();
        }

    }
}

