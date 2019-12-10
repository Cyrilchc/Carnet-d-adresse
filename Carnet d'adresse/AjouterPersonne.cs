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
    public partial class AjouterPersonne : Form
    {
        Personne personne;
        Carnet carnet;
        public AjouterPersonne(Carnet carnet, Personne Currentpersonne = null)
        {
            InitializeComponent();
            this.carnet = carnet;
            if(Currentpersonne != null)
            {
                personne = Currentpersonne;
            }
        }

        /// <summary>
        /// Ferme la fenêtre
        /// </summary>
        private void bt_add_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Ajoute une personne
        /// </summary>
        private void bt_add_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPrenom.Text) &&
                !string.IsNullOrEmpty(textboxNom.Text) &&
                !string.IsNullOrEmpty(textBoxAdresse.Text) &&
                !string.IsNullOrEmpty(textBoxPhone.Text))
            {
                if (personne == null)
                {
                    ajout();
                }
                else
                {
                    modifie();
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs",
                    "Remplir le formulaire",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Ajoute une personne
        /// </summary>
        private void ajout()
        {
            CarnetHelper ch = new CarnetHelper();
            Personne personne = new Personne();
            personne.Prenom = textBoxPrenom.Text;
            personne.nom = textboxNom.Text;
            personne.adresse = textBoxAdresse.Text;
            personne.phone = textBoxPhone.Text;
            ch.addInCarnet(personne, carnet);
            MessageBox.Show("La personne a été ajoutée avec succès",
                "Ajouter une personne",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Close();
        }

        /// <summary>
        /// Modifie une personne
        /// </summary>
        private void modifie()
        {
            CarnetHelper ch = new CarnetHelper();
            Personne personne = new Personne();
            personne.Prenom = textBoxPrenom.Text;
            personne.nom = textboxNom.Text;
            personne.adresse = textBoxAdresse.Text;
            personne.phone = textBoxPhone.Text;
            ch.updateInCarnet(personne, this.personne, carnet);
            MessageBox.Show("La personne a été modifiée avec succès",
                "Modifier une personne",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Close();
        }

        /// <summary>
        /// Charge la fenêtre
        /// </summary>
        private void AjouterPersonne_Load(object sender, EventArgs e)
        {
            if(personne != null)
            {
                Text = "Modifier " + personne.Prenom + " " + personne.nom;
                bt_add.Text = "Modifier la personne";
                textBoxPrenom.Text = personne.Prenom;
                textboxNom.Text = personne.nom;
                textBoxAdresse.Text = personne.adresse;
                textBoxPhone.Text = personne.phone;
            }
        }
    }
}
