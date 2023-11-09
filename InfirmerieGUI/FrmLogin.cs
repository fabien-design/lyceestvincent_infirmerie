using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfirmerieBO;
using InfirmerieBLL;
using System.Configuration;

namespace InfirmerieGUI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            GestionInfirmeries.SetchaineConnexion(ConfigurationManager.ConnectionStrings["Infirmerie"]);

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            Utilisateur unUser = new Utilisateur(txtUsername.Text, textPassword.Text);
            GestionInfirmeries.CreerUtilisateur(unUser);
            List<Utilisateur> listUtilisateurs = new List<Utilisateur>();
            listUtilisateurs = GestionInfirmeries.GetUtilisateurs();

            bool userFind = false;

            for (int i = 0; i < listUtilisateurs.Count; i++)
            {
                if (unUser.Nom == listUtilisateurs[i].Nom && unUser.Password == listUtilisateurs[i].Password)
                {
                    userFind = true;
                    break;
                }
            }

            if (userFind)
            {
                MessageBox.Show("Bonjour," + unUser.Nom + " vous êtes bien connecté.");
            }
            else
            {
                MessageBox.Show("Le nom d'utilisateur ou le Mot de passe est incorrect, veuillez réessayer");
                txtUsername.Clear();
                textPassword.Clear();
                textPassword.Focus();
            }

        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            textPassword.Clear();
            txtUsername.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void picLSV_Click(object sender, EventArgs e)
        {

        }

        private void pnl2_Paint(object sender, PaintEventArgs e)
        {
            // Obtenir l'objet Graphics pour dessiner sur le panneau
            Graphics g = e.Graphics;

            // Dessiner un rectangle avec des coins arrondis
            int cornerRadius = 20;
            Rectangle rect = new Rectangle(0, 0, pnl2.Width, pnl2.Height);
            g.SmoothingMode = SmoothingMode.AntiAlias; // Activer l'anti-crénelage pour des bords lisses
            using (GraphicsPath path = RoundedRectangle(rect, cornerRadius))
            {
                g.FillPath(Brushes.LightGray, path);
                g.DrawPath(Pens.LightGray, path);
            }
        }

        private GraphicsPath RoundedRectangle(Rectangle rect, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = cornerRadius * 2;
            Rectangle arc = new Rectangle(rect.Location, new Size(diameter, diameter));

            path.AddArc(arc, 180, 90); // Coin supérieur gauche
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90); // Coin supérieur droit
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90); // Coin inférieur droit
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90); // Coin inférieur gauche
            path.CloseFigure();

            return path;
        }

        private void lblNom_Click(object sender, EventArgs e)
        {

        }

        private void picPassword_Click(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
        }

        private void lblInfirmerie_Click(object sender, EventArgs e)
        {

        }
    }
}
