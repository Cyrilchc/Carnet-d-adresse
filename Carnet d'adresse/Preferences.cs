using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carnet_d_adresse
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ferme la fenêtre
        /// </summary>
        private void bt_annuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// chargement de la fenêtre
        /// </summary>
        private void Preferences_Load(object sender, EventArgs e)
        {
            textBoxLargeur.Text = Properties.Settings.Default.Largeur.ToString();
            textBoxLongueur.Text = Properties.Settings.Default.Longueur.ToString();
        }

        /// <summary>
        /// Remet la taille de la groupbox par défaut
        /// </summary>
        private void bt_defaut_Click(object sender, EventArgs e)
        {
            textBoxLargeur.Text = "120";
            textBoxLongueur.Text = "200";
            Properties.Settings.Default.Largeur = 120;
            Properties.Settings.Default.Longueur = 200;
            Properties.Settings.Default.Save();
            MessageBox.Show("La taille a été remise par défaut",
                "Modifier la taille",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Enregistre la taille
        /// </summary>
        private void bt_Enregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Largeur = Convert.ToInt32(textBoxLargeur.Text);
                Properties.Settings.Default.Longueur = Convert.ToInt32(textBoxLongueur.Text);
                Properties.Settings.Default.Save();
                MessageBox.Show("La taille a été modifiée",
                    "Modifier la taille",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Veuillez entrer des nombres",
                  "Modifier la taille",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
            }
        }
    }
}
