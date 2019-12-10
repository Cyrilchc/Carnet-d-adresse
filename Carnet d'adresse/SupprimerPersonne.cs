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
    public partial class SupprimerPersonne : Form
    {
        Carnet carnet;
        public SupprimerPersonne(Carnet carnet)
        {
            InitializeComponent();
            this.carnet = carnet;
        }

        /// <summary>
        /// Chargement de la fenêtre
        /// </summary>
        private void SupprimerPersonne_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Prénom", typeof(string));
            dt.Columns.Add("Nom", typeof(string));
            dt.Columns.Add("Adresse", typeof(string));
            dt.Columns.Add("Téléphone", typeof(string));

            foreach(Personne personne in carnet.personnes)
            {
                object[] row = new object[] { personne.Prenom, personne.nom, personne.adresse, personne.phone };
                dt.Rows.Add(row);
            }

            dgvPersonnes.DataSource = dt;
        }

        private void bt_annuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Supprime une personne
        /// </summary>
        private void bt_Supprimer_Click(object sender, EventArgs e)
        {
            CarnetHelper ch = new CarnetHelper();
            if(dgvPersonnes.SelectedRows.Count == 1)
            {
                string prenom = dgvPersonnes.SelectedRows[0].Cells[0].Value.ToString();
                string nom = dgvPersonnes.SelectedRows[0].Cells[1].Value.ToString();
                string prenomNom = prenom + nom;
                foreach (Personne personne in carnet.personnes)
                {
                    string prenomNomJson = personne.Prenom + personne.nom;
                    if (prenomNom == prenomNomJson)
                    {
                        ch.delInCarnet(personne, carnet);
                        MessageBox.Show("La personne a été supprimée avec succès",
                            "Supprmier une personne",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Close();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une personne à supprimer",
                    "Supprimer une personne du carnet d'adresse",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
    }
}
