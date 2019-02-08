using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrairy
{
    public class Film
    {
        private int id;
        private String titre;
        private String realisateur;
        private DateTime dateDeSortie;
        private String resume;
        private String genre;
        private int duree;
        private List<String> acteurs;

        public int Id { get => id; set => id = value; }
        public String Titre { get => titre; set => titre = value; }
        public String Realisateur { get => realisateur; set => realisateur = value; }
        public DateTime DateDeSortie { get => dateDeSortie; set => dateDeSortie = value; }
        public String Resume { get => resume; set => resume = value; }
        public String Genre { get => genre; set => genre = value; }
        public int Duree { get => duree; set => duree = value; }
        public List<String> Acteurs { get => acteurs; set => acteurs = value; }

        public Film() { }

        public Film(String titre, String realisateur, DateTime dateDeSortie, String resume, String genre, int duree)
        {
            Titre = titre;
            Realisateur = realisateur;
            DateDeSortie = dateDeSortie;
            Resume = resume;
            Duree = duree;
            Genre = genre;
        }

        public Film(int id, String titre, String realisateur, DateTime dateDeSortie, String resume, String genre, int duree) : this(titre, realisateur, dateDeSortie, resume, genre, duree)
        {
            Id = id;
        }

        public void AfficherFilm()
        {
            Console.WriteLine("Titre : " + Titre);
            Console.WriteLine("Réalisateur : " + Realisateur);
            Console.WriteLine("Date de sortie : " + DateDeSortie);
            Console.WriteLine("Résumé : " + Resume);
            Console.WriteLine("Genre : " + Genre);
            Console.WriteLine("Durée : " + Duree + " minutes");
        }
    }
}
