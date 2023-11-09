using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InfirmerieBO
{
    public class Utilisateur
    {
        private int id;
        private string nom;
        private string password;
        public Utilisateur(string nom, string password)
        {
            this.nom = nom;
            this.password = password;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Password { get => password; set => password = value; }

    }
}