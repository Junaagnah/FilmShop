using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrairy
{
    public class Personnes
    {
        private int id;
        private String nom;
        private String prenom;
        private DateTime dateNaissance;
        private String adresse;
        private String ville;
        private String codePostal;
        private int taille;
        private int poids;

        public int Id { get => id; set => id = value; }
        public String Nom { get => nom;
            set
            {
                int test = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    if (int.TryParse(Char.ToString(value[i]), out test))
                    {
                        throw new ArgumentException("Le nom ne peut pas contenir de chiffres.");
                    }
                }

                nom = value.ToUpper();
            }
        }
        public String Prenom { get => prenom;
            set
            {
                int test = 0;
                var builder = new StringBuilder();
                for (int i = 0; i < value.Length; i++)
                {
                    if (int.TryParse(Char.ToString(value[i]), out test))
                    {
                        throw new ArgumentException("Le prénom ne peut pas contenir de chiffres.");
                    }

                    if (i == 0)
                    {
                        builder.Append(Char.ToUpper(value[i]));
                    }
                    else
                    {
                        builder.Append(Char.ToLower(value[i]));
                    }
                }

                prenom = builder.ToString();
            }
        }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public String Adresse { get => adresse; set => adresse = value; }
        public String Ville { get => ville; set => ville = value; }
        public String CodePostal { get => codePostal; set => codePostal = value; }
        public int Taille { get => taille; set => taille = value; }
        public int Poids { get => poids; set => poids = value; }
        public int Age { get
            {
                int age = DateTime.Now.Year - DateNaissance.Year;
                DateTime dateAnniversaire = new DateTime(
                DateTime.Now.Year,
                DateNaissance.Month,
                DateNaissance.Day);

                if (dateAnniversaire >= DateTime.Now)
                {
                    age--;
                }

                return age;
            }
        }
        public String NomComplet { get => nom + " " + prenom; }

        public Personnes() { }

        public Personnes(String nom, String prenom, DateTime dateNaissance, String adresse, String ville, String codePostal, int taille, int poids)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            Ville = ville;
            CodePostal = codePostal;
            Taille = taille;
            Poids = poids;
        }

        public Personnes(int id, String nom, String prenom, DateTime dateNaissance, String adresse, String ville, String codePostal, int taille, int poids) : this(nom, prenom, dateNaissance, adresse, ville, codePostal, taille, poids)
        {
            Id = id;
        }

        public void SePresenter()
        {
            String presentation = "Bonjour, je m'appelle " + NomComplet + ". J'ai " + Age + " ans. J'habite à " + Ville;
        }
    }
}
