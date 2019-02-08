using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FilmLibrairy
{
    public static class DataAccess
    {
        private const String connectionString = "SERVER=localhost;DATABASE=FilmDatabase;PORT=3306;UID=root;PASSWORD=";

        public static void AddFilm(Film film)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand query = connection.CreateCommand();

                    query.CommandText = "INSERT INTO films (titre, realisateur, date_sortie, resume, genre, duree) VALUES (@titre, @realisateur, @dtesortie, @resume, @genre, @duree)";

                    query.Parameters.AddWithValue("@titre", film.Titre);
                    query.Parameters.AddWithValue("@realisateur", film.Realisateur);
                    query.Parameters.AddWithValue("@dtesortie", film.DateDeSortie);
                    query.Parameters.AddWithValue("@resume", film.Resume);
                    query.Parameters.AddWithValue("@genre", film.Genre);
                    query.Parameters.AddWithValue("@duree", film.Duree);

                    query.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static void AddPersonne(Personnes personne)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand query = connection.CreateCommand();

                    query.CommandText = "INSERT INTO personnes (nom, prenom, dte_naissance, adresse, ville, cp, taille, poids) VALUES (@nom, @prenom, @dte_naissance, @adresse, @ville, @cp, @taille, @poids)";

                    query.Parameters.AddWithValue("@nom", personne.Nom);
                    query.Parameters.AddWithValue("@prenom", personne.Prenom);
                    query.Parameters.AddWithValue("@dte_naissance", personne.DateNaissance);
                    query.Parameters.AddWithValue("@adresse", personne.Adresse);
                    query.Parameters.AddWithValue("@ville", personne.Ville);
                    query.Parameters.AddWithValue("@cp", personne.CodePostal);
                    query.Parameters.AddWithValue("@taille", personne.Taille);
                    query.Parameters.AddWithValue("@poids", personne.Poids);

                    query.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static List<Film> GetAllFilms()
        {
            List<Film> films = new List<Film>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand query = connection.CreateCommand();

                    query.CommandText = "SELECT id, titre, realisateur, date_sortie, resume, genre, duree FROM films";

                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            do
                            {
                                //reader[0] : id
                                //reader[1] : titre
                                //reader[2] : realisateur
                                //reader[3] : date_sortie
                                //reader[4] : resume
                                //reader[5] : genre
                                //reader[6] : duree

                                films.Add(new Film(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToDateTime(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToInt32(reader[6])));
                            } while (reader.Read());
                        }
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return films;
        }

        public static List<Personnes> GetAllPersonnes()
        {
            List<Personnes> personnes = new List<Personnes>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand query = connection.CreateCommand();

                    query.CommandText = "SELECT id, nom, prenom, dte_naissance, adresse, ville, cp, taille, poids FROM personnes";

                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            do
                            {
                                try
                                {
                                    //reader[0] : id
                                    //reader[1] : nom
                                    //reader[2] : prenom
                                    //reader[3] : dte_naissance
                                    //reader[4] : adresse
                                    //reader[5] : ville
                                    //reader[6] : cp
                                    //reader[7] : taille
                                    //reader[8] : poids

                                    personnes.Add(new Personnes(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToDateTime(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToString(reader[6]), Convert.ToInt32(reader[7]), Convert.ToInt32(reader[8])));
                                }
                                catch (ArgumentException e)
                                {
                                    throw e;
                                }
                            } while (reader.Read());
                        }
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return personnes;
        }

        public static Film GetFilmById(int id)
        {
            Film film = new Film();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand query = connection.CreateCommand();

                    query.CommandText = "SELECT id, titre, realisateur, date_sortie, resume, genre, duree FROM films WHERE id = @id";

                    query.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //reader[0] : id
                                //reader[1] : titre
                                //reader[2] : realisateur
                                //reader[3] : date_sortie
                                //reader[4] : resume
                                //reader[5] : genre
                                //reader[6] : duree
                                film = new Film(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToDateTime(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToInt32(reader[6]));
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return film;
        }

        public static Personnes GetPersonneById(int id)
        {
            Personnes personne = new Personnes();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand query = connection.CreateCommand();

                    query.CommandText = "SELECT id, nom, prenom, dte_naissance, adresse, ville, cp, taille, poids FROM personnes WHERE id = @id";

                    query.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    //reader[0] : id
                                    //reader[1] : nom
                                    //reader[2] : prenom
                                    //reader[3] : dte_naissance
                                    //reader[4] : adresse
                                    //reader[5] : ville
                                    //reader[6] : cp
                                    //reader[7] : taille
                                    //reader[8] : poids

                                    personne = new Personnes(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToDateTime(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToString(reader[6]), Convert.ToInt32(reader[7]), Convert.ToInt32(reader[8]));
                                }
                                catch (ArgumentException e)
                                {
                                    throw e;
                                }
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return personne;
        }

        public static List<Film> GetFilmsByGenre(String genre)
        {
            List<Film> films = new List<Film>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand query = connection.CreateCommand();

                    query.CommandText = "SELECT id, titre, realisateur, date_sortie, resume, genre, duree FROM films WHERE genre = @genre";

                    query.Parameters.AddWithValue("@genre", genre);

                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            do
                            {
                                //reader[0] : id
                                //reader[1] : titre
                                //reader[2] : realisateur
                                //reader[3] : date_sortie
                                //reader[4] : resume
                                //reader[5] : genre
                                //reader[6] : duree

                                films.Add(new Film(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToDateTime(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToInt32(reader[6])));
                            } while (reader.Read());
                        }
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return films;
        }

        public static List<Film> GetFilmsByYear(int annee)
        {
            List<Film> films = new List<Film>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand query = connection.CreateCommand();

                    query.CommandText = "SELECT id, titre, realisateur, date_sortie, resume, genre, duree FROM films WHERE YEAR(date_sortie) = @year";

                    query.Parameters.AddWithValue("@year", annee);

                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            do
                            {
                                //reader[0] : id
                                //reader[1] : titre
                                //reader[2] : realisateur
                                //reader[3] : date_sortie
                                //reader[4] : resume
                                //reader[5] : genre
                                //reader[6] : duree

                                films.Add(new Film(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToDateTime(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToInt32(reader[6])));
                            } while (reader.Read());
                        }
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return films;
        }
    }
}
