using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using InfirmerieDAL;
using InfirmerieBO;

namespace InfirmerieBLL
{
    public class GestionInfirmeries
    {
        private static GestionInfirmeries uneGestionInfirmerie; // objet BLL

        // Accesseur en lecture
        public static GestionInfirmeries GetGestionInfirmerie()
        {
            if (uneGestionInfirmerie == null)
            {
                uneGestionInfirmerie = new GestionInfirmeries();
            }
            return uneGestionInfirmerie;
        }

        // Définit la chaîne de connexion grâce à la méthode SetchaineConnexion
        //de la DAL
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }
        // Méthode qui renvoit une List d'objets Infirmerie en faisant appel à la méthode GetInfirmeries() de la DAL
        public static List<Utilisateur> GetUtilisateurs()
        {
            return UtilisateurDAO.GetUtilisateurs();
        }
        // Méthode qui renvoi l’objet utilisateur en l'ajoutant à la
        // BD avec la méthode AjoutInfirmerie de la DAL
        public static int CreerUtilisateur(Utilisateur ut)
        {
            return UtilisateurDAO.AjoutUtilisateur(ut);
        }
        // Méthode qui modifie un nouvel utilisateur avec la méthode
        //UpdateInfirmerie de la DAL
        public static int ModifierUtilisateur(Utilisateur ut)
        {
            return UtilisateurDAO.UpdateUtilisateur(ut);
        }

        // Méthode qui supprime un utilisateur avec la méthode
        //DeleteInfirmerie de la DAL
        //public static int SupprimerInfirmerie(int id)
        //{
        //    return UtilisateurDAO.DeleteUtilisateur(id);
        //}
    }
}