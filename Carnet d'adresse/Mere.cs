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
    public partial class CarnetAdresse : Form
    {
        public CarnetAdresse()
        {
            InitializeComponent();
        }

        Carnet carnet;
        /// <summary>
        /// Charge la fenêtre
        /// </summary>
        private void CarnetAdresse_Load(object sender, EventArgs e)
        {
            flpPersonnes.Controls.Clear();
            CarnetHelper ch = new CarnetHelper();
            carnet = ch.LoadCarnet();
            foreach (Personne personne in carnet.personnes)
            {
                generateGroupBox(personne);
            }
        }

        /// <summary>
        /// Génère une groupbox avec les informations de la personne à l'intérieur
        /// </summary>
        private void generateGroupBox(Personne personne)
        {
            GroupBox gp = new GroupBox();
            gp.Text = personne.Prenom + " " + personne.nom;
            Button btedit = new Button();
            btedit.Size = new Size(100, 25);
            btedit.Click += bt_edit_Click;
            btedit.Text = "Modifier";
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Fill;
            flp.FlowDirection = FlowDirection.TopDown;
            Label adresse = new Label();
            adresse.Text = personne.adresse;
            adresse.Size = new Size(150, 20);
            Label phone = new Label();
            phone.Text = personne.phone;
            phone.Size = new Size(150, 20);
            flp.Controls.Add(adresse);
            flp.Controls.Add(phone);
            flp.Controls.Add(btedit);
            gp.Controls.Add(flp);
            gp.Size = new Size(Properties.Settings.Default.Longueur, Properties.Settings.Default.Largeur);
            flpPersonnes.Controls.Add(gp);
        }

        /// <summary>
        /// Ouvre le formulaire de modification
        /// </summary>
        private void bt_edit_Click(object sender, EventArgs e)
        {
            Personne currentPersonne = new Personne();
            bool found = false;
            FlowLayoutPanel flp = ((Button)sender).Parent as FlowLayoutPanel;
            GroupBox gp = flp.Parent as GroupBox;
            foreach(Personne personne in carnet.personnes)
            {
                string PrenomNom = personne.Prenom + " " + personne.nom;
                if (PrenomNom == gp.Text)
                {
                    currentPersonne = personne;
                    found = true;
                }
            }

            if (found)
            {
                AjouterPersonne ap = new AjouterPersonne(carnet, currentPersonne);
                ap.ShowDialog();
                CarnetAdresse_Load(null, null);
            }
            else
            {
                MessageBox.Show("La personne n'a pas pu être trouvé",
                    "Modifier un personne",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Ouvre la fenêtre d'ajout
        /// </summary>
        private void bt_add_Click(object sender, EventArgs e)
        {
            AjouterPersonne ap = new AjouterPersonne(carnet);
            ap.ShowDialog();
            CarnetAdresse_Load(null, null);
        }

        /// <summary>
        /// Ouvre la fenêtre pour modifier la personne
        /// </summary>
        private void bt_del_Click(object sender, EventArgs e)
        {
            SupprimerPersonne sp = new SupprimerPersonne(carnet);
            sp.ShowDialog();
            CarnetAdresse_Load(null, null);
        }

        /// <summary>
        /// Ouvre la fenêtre de préférences
        /// </summary>
        private void bt_pref_Click(object sender, EventArgs e)
        {
            Preferences preferences = new Preferences();
            preferences.ShowDialog();
            CarnetAdresse_Load(null, null);
        }
    }
}
