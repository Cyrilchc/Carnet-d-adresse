using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carnet_d_adresse
{
    public class CarnetHelper
    {

        private string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\carnet.json";

        /// <summary>
        /// Sauvegarde le carnet
        /// </summary>
        public void SaveCarnet(Carnet CurrentCarnet)
        {
            if (File.Exists(path))
            {
                string contents = JsonConvert.SerializeObject(CurrentCarnet);
                File.WriteAllText(path, contents);
            }
            else
            {
                File.Create(path);
                Carnet carnet = new Carnet();
                List<Personne> personnes = new List<Personne>();
                carnet.personnes = personnes;
                string contents = JsonConvert.SerializeObject(carnet);
                File.WriteAllText(path, contents);
            }
        }

        /// <summary>
        /// Charge et renvoie le carnet
        /// </summary>
        public Carnet LoadCarnet()
        {
            if (File.Exists(path))
            {
                string contents = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<Carnet>(contents);
            }
            else
            {
                using (FileStream fs = File.Create(path))
                {
                }
                Carnet carnet = new Carnet();
                List<Personne> personnes = new List<Personne>();
                carnet.personnes = personnes;
                string contents = JsonConvert.SerializeObject(carnet);
                File.WriteAllText(path, contents);
                return carnet;
            }
        }

        public void addInCarnet(Personne personne, Carnet carnet)
        {
            carnet.personnes.Add(personne);
            SaveCarnet(carnet);
        }

        public void delInCarnet(Personne personne, Carnet carnet)
        {
            foreach (Personne p in carnet.personnes)
            {
                if (p.Equals(personne))
                {
                    carnet.personnes.Remove(p);
                    SaveCarnet(carnet);
                    break;
                }
            }
        }

        /// <summary>
        /// Modifie une personne
        /// </summary>
        public void updateInCarnet(Personne personne, Personne oldPersonne, Carnet carnet)
        {
            carnet.personnes.Remove(oldPersonne);
            carnet.personnes.Add(personne);
            SaveCarnet(carnet);
        }
    }
}
