using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmLibrairy;

namespace FilmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            InitProgramme();
        }

        static void InitProgramme()
        {

        }

        static void AddFilm()
        {
            String titre;
            String realisateur;
            String dte;
            DateTime dateDeSortie = new DateTime();
            String resume;
            String genre;
            String dureeTemp;
            int duree = 0;

            bool isDate = false;
            bool isDuree = false;

            Console.Write("Titre : ");
            titre = Console.ReadLine();
            Console.Write("Réalisateur : ");
            realisateur = Console.ReadLine();
            Console.Write("Date de sortie (Y/m/d) : ");
            dte = Console.ReadLine();
            while (!isDate)
            {
                if (!DateTime.TryParse(dte, out dateDeSortie))
                {
                    Console.WriteLine("Merci d'entrer une date valide");
                    Console.Write("Date de sortie : ");
                    dte = Console.ReadLine();
                }
                else
                {
                    isDate = true;
                }
            }
            Console.Write("Résumé : ");
            resume = Console.ReadLine();
            Console.Write("Genre : ");
            genre = Console.ReadLine();
            Console.Write("Durée (en minutes) : ");
            dureeTemp = Console.ReadLine();

            while (!isDuree)
            {
                if (!int.TryParse(dureeTemp, out duree))
                {
                    Console.WriteLine("Merci d'entrer une durée valide.");
                    Console.Write("Durée (en minutes) : ");
                    dureeTemp = Console.ReadLine();
                }
                else
                {
                    isDuree = true;
                }
            }

            Film film = new Film(titre, realisateur, dateDeSortie, resume, genre, duree);

            try
            {
                DataAccess.AddFilm(film);
                Console.WriteLine("Le film a bien été ajouté !");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void AddPersonne()
        {
            String nom;
            String prenom;
            DateTime dateNaissance = new DateTime();
            String adresse;
            String ville;
            String codePostal;
            String dte;
            String tailleTemp;
            String poidsTemp;
            int taille = 0;
            int poids = 0;

            bool isDate = false;
            bool isTaille = false;
            bool isPoids = false;

            Console.Write("Nom : ");
            nom = Console.ReadLine();
            Console.Write("Prénom : ");
            prenom = Console.ReadLine();
            Console.Write("Date de naissance (Y/m/d) : ");
            dte = Console.ReadLine();
            while (!isDate)
            {
                if (!DateTime.TryParse(dte, out dateNaissance))
                {
                    Console.WriteLine("Merci d'entrer une date valide");
                    Console.Write("Date de sortie : ");
                    dte = Console.ReadLine();
                }
                else
                {
                    isDate = true;
                }
            }
            Console.Write("Adresse : ");
            adresse = Console.ReadLine();
            Console.Write("Ville : ");
            ville = Console.ReadLine();
            Console.Write("Code postal : ");
            codePostal = Console.ReadLine();

            Console.Write("Taille (en cm) : ");
            tailleTemp = Console.ReadLine();

            while (!isTaille)
            {
                if (!int.TryParse(tailleTemp, out taille))
                {
                    Console.WriteLine("Merci d'entrer une taille valide.");
                    Console.Write("Taille (en cm) : ");
                    tailleTemp = Console.ReadLine();
                }
                else
                {
                    isTaille = true;
                }
            }

            Console.Write("Poids (en kg) : ");
            poidsTemp = Console.ReadLine();

            while (!isPoids)
            {
                if (!int.TryParse(poidsTemp, out poids))
                {
                    Console.WriteLine("Merci d'entrer une durée valide.");
                    Console.Write("Durée : ");
                    poidsTemp = Console.ReadLine();
                }
                else
                {
                    isPoids = true;
                }
            }

            try
            {
                Personnes personne = new Personnes(nom, prenom, dateNaissance, adresse, ville, codePostal, taille, poids);
                DataAccess.AddPersonne(personne);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void GetAllFilms()
        {
            List<Film> films = new List<Film>();

            try
            {
                films = DataAccess.GetAllFilms();

                foreach (Film film in films)
                {
                    film.AfficherFilm();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void GetAllPersonnes()
        {
            List<Personnes> personnes = new List<Personnes>();

            try
            {
                personnes = DataAccess.GetAllPersonnes();

                foreach (Personnes personne in personnes)
                {
                    personne.AfficherPersonne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void GetFilmById()
        {
            String idTemp;
            bool isId = false;

            int id = 0;

            Console.Write("ID : ");
            idTemp = Console.ReadLine();

            while (!isId)
            {
                if (int.TryParse(idTemp, out id))
                {
                    Console.WriteLine("Merci d'entrer un ID correct.");
                    Console.Write("ID : ");
                    idTemp = Console.ReadLine();
                }
                else
                {
                    isId = true;
                }
            }

            try
            {
                Film film = DataAccess.GetFilmById(id);
                film.AfficherFilm();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void GetPersonneById()
        {
            String idTemp;
            bool isId = false;

            int id = 0;

            Console.Write("ID : ");
            idTemp = Console.ReadLine();

            while (!isId)
            {
                if (int.TryParse(idTemp, out id))
                {
                    Console.WriteLine("Merci d'entrer un ID correct.");
                    Console.Write("ID : ");
                    idTemp = Console.ReadLine();
                }
                else
                {
                    isId = true;
                }
            }

            try
            {
                Personnes personne = DataAccess.GetPersonneById(id);
                personne.AfficherPersonne();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void GetFilmByGenre()
        {
            String genre;
            List<Film> films = new List<Film>();

            Console.Write("Genre : ");
            genre = Console.ReadLine();

            try
            {
                films = DataAccess.GetFilmsByGenre(genre);
                if (!films.Any())
                {
                    Console.WriteLine("Aucun film n'a été trouvé.");
                }
                else
                {
                    foreach(Film film in films)
                    {
                        film.AfficherFilm();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void GetFilmByYear()
        {
            List<Film> films = new List<Film>();
            String yearTemp;

            int year = 0;
            bool isYear = false;

            Console.Write("Année : ");
            yearTemp = Console.ReadLine();

            while(!isYear)
            {
                if (!int.TryParse(yearTemp, out year) || yearTemp.Length > 4 || yearTemp.Length < 4)
                {
                    Console.WriteLine("Merci d'entrer une année valide.");
                    Console.Write("Année : ");
                    yearTemp = Console.ReadLine();
                }
                else
                {
                    isYear = true;
                }
            }

            try
            {
                films = DataAccess.GetFilmsByYear(year);
                if (!films.Any())
                {
                    Console.WriteLine("Aucun film n'a été trouvé.");
                }
                else
                {
                    foreach(Film film in films)
                    {
                        film.AfficherFilm();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
