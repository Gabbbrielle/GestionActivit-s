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
        /// <summary>
        /// Accède à [dbo].[Activities] et utilise la procédure stockée GetListActvities 
        /// <code>select * from Activities order by Vote desc</code>
        /// </summary>
        /// <returns>Liste des activités en ordre décroissant de vote</returns>
        public List<Activite> GetListActivites()
        {
            ConnNProc c = new ConnNProc();
            List<Activite> listeActivite = new List<Activite>();
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;

            string connectionString = "Data Source={secrets.Unicorn1};Initial Catalog=Activities;Integrated Security=True;Pooling=False";
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
        /// <summary>
        /// Accède à [dbo].[Participants] et utilise la procédure stockée GetParticipants 
        /// <code>select * from Participants order by Activite</code>
        /// </summary>
        /// <returns>Liste des participant.es en ordre de l'activité choisie</returns>
        public List<Participant> GetParticipants()
        {
            List<Participant> listeParticipants = new List<Participant>();
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            string connectionString = "Data Source={secrets.Unicorn1};Initial Catalog=Activities;Integrated Security=True;Pooling=False";
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
        /// <summary>
        /// Accède la [dbo].[Participants] et utilise la procédure stockée CountVotes
        /// <code>select count(*) from Participants</code>
        /// Utilisé dans la view Participant.Index.cshtml
        /// </summary>
        /// <returns>Int du nombre d'enregistrement (personnes ayant votées) dans la table </returns>
        public int CountVotes()
        {
            Int32 count = 0;
            SqlConnection conn;
            SqlCommand cmd;
            string connectionString = "Data Source={secrets.Unicorn1};Initial Catalog=Activities;Integrated Security=True;Pooling=False";
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
        /// <summary>
        /// Insère un nouveau participant dans [dbo].[Participants] et incrémente le nombre de vote dans [dbo].[Activities]
        /// en utilisant la procédure stockée CreateParticipant
        /// <code>
        /// insert into Participants(Nom, Activite) 
        /// values(@Param1, @Param2); 
        /// update Activities set Vote = Vote + 1
        /// where NomActivite = @Param2;</code>
        /// </code>
        /// </summary>
        /// 
        /// <param name="p">new participant crée à partir de GET: ParticipantController/Create
        /// et passé en paramètre dans POST: ParticipantController/Create</param>
        public static void CreateParticipant(Participant p)
        {
            SqlConnection conn;
            SqlCommand cmd;
            string connectionString = "Data Source={secrets.Unicorn1};Initial Catalog=Activities;Integrated Security=True;Pooling=False";
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

