using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using InfirmerieBO;
using InfirmerieDAL;

namespace InfirmerieDAL
{
    public class UtilisateurDAO
    {
        private static UtilisateurDAO unUtilisateurDAO;
        // Accesseur en lecture, renvoi une instance
        public static UtilisateurDAO GetunUtilisateurDAO()
        {
            if (unUtilisateurDAO == null)
            {
                unUtilisateurDAO = new UtilisateurDAO();
            }
            return unUtilisateurDAO;
        }

        // Cette méthode retourne une List contenant les objets Utilisateurs
        //contenus dans la table Identification
        public static List<Utilisateur> GetUtilisateurs()
        {
            int id;
            string nom;
            string password;
            Utilisateur unUtilisateur;
            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            // Création d'une liste vide d'objets Utilisateurs
            List<Utilisateur> lesUtilisateurs = new List<Utilisateur>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = " SELECT * FROM Utilisateur";
            SqlDataReader monReader = cmd.ExecuteReader();
            // Remplissage de la liste
            while (monReader.Read())
            {
                id = Int32.Parse(monReader["id_utilisateur"].ToString());
                if (monReader["nom_utilisateur"] == DBNull.Value)
                {
                    nom = default(string);
                }
                else
                {
                    nom = monReader["Nom_Utilisateur"].ToString();
                }
                if (monReader["mot_de_passe_utilisateur"] == DBNull.Value)
                {
                    password = default(string);
                }
                else
                {
                    password = monReader["mot_de_passe_utilisateur"].ToString();
                }

                unUtilisateur = new Utilisateur(nom, password);
                lesUtilisateurs.Add(unUtilisateur);
            }
            // Fermeture de la connexion
            maConnexion.Close();
            return lesUtilisateurs;
        }

        // Cette méthode insert un nouvel Utilisateur passé en paramètre dans la BD
        public static int AjoutUtilisateur(Utilisateur unUtilisateur)
        {
            int nbEnr;
            // Connexion à la BD
            SqlConnection maConnexion =
           ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "INSERT INTO Utilisateur (nom_utilisateur, mot_de_passe_utilisateur) values( @nom, @password) ";
            SqlParameter paramNom = new SqlParameter("@nom", SqlDbType.VarChar, 255);
            paramNom.Value = unUtilisateur.Nom;
            cmd.Parameters.Add(paramNom);
            // Paramètre password
            SqlParameter paramPassword = new SqlParameter("@password", SqlDbType.VarChar, 255);
            paramPassword.Value = unUtilisateur.Password;
            cmd.Parameters.Add(paramPassword);
            nbEnr = cmd.ExecuteNonQuery();
            // Fermeture de la connexion
            maConnexion.Close();
            return nbEnr;
        }
        // Cette méthode modifie un Utilisateur passé en paramètre dans la BD
        public static int UpdateUtilisateur(Utilisateur unUtilisateur)
        {
            int nbEnr;
            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "UPDATE Utilisateur SET nom_utilisateur = @nom, mot_de_passe_utilisateur = @password WHERE id_utilisateur = " + unUtilisateur.Id;
            SqlParameter paramNom = new SqlParameter("@nom", SqlDbType.VarChar, 255);
            paramNom.Value = unUtilisateur.Nom;
            cmd.Parameters.Add(paramNom);
            // Paramètre password
            SqlParameter paramPassword = new SqlParameter("@password", SqlDbType.VarChar, 255);
            paramPassword.Value = unUtilisateur.Password;
            cmd.Parameters.Add(paramPassword);
            nbEnr = cmd.ExecuteNonQuery();
            // Fermeture de la connexion
            maConnexion.Close();
            return nbEnr;
        }
        // Cette méthode supprime de la BD un Utilisateur dont l'id est passé
        //en paramètre
        //public static int DeleteUtilisateur(int id)
        //{
            //int nbEnr;
            // Connexion à la BD
            //SqlConnection maConnexion =
          // ConnexionBD.GetConnexionBD().GetSqlConnexion();
           // SqlCommand cmd = new SqlCommand();
           // cmd.Connection = maConnexion;
           // cmd.CommandText = "DELETE FROM T_Identification WHERE Id_Utilisateur = " + id;
           // nbEnr = cmd.ExecuteNonQuery();
            // Fermeture de la connexion
           // maConnexion.Close();
           // return nbEnr;
       // }
    }
}
