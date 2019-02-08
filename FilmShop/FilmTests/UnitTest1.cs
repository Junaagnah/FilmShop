using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmLibrairy;

namespace FilmTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPersonnePrenomOK()
        {
            Personnes personne = new Personnes("JeAn", "PieRre", new DateTime(1999, 07, 02), "23 rue des pommes", "Paris", "75000", 175, 85);

            Assert.AreEqual("Pierre", personne.Prenom);
        }

        [TestMethod]
        public void testPersonneNomOK()
        {
            Personnes personne = new Personnes("JeAn", "PieRre", new DateTime(1999, 07, 02), "23 rue des pommes", "Paris", "75000", 175, 85);

            Assert.AreEqual("JEAN", personne.Nom);
        }

        [TestMethod]
        public void TestPersonnePrenomPASOK()
        {
            Personnes personne = new Personnes();

            Assert.ThrowsException<ArgumentException>(
                () => personne = new Personnes("JeAn", "PieRre78", new DateTime(1999, 07, 02), "23 rue des pommes", "Paris", "75000", 175, 85)
                );
        }

        [TestMethod]
        public void TestPersonneNomPASOK()
        {
            Personnes personne = new Personnes();

            Assert.ThrowsException<ArgumentException>(
                () => personne = new Personnes("JeAn84", "PieRre", new DateTime(1999, 07, 02), "23 rue des pommes", "Paris", "75000", 175, 85)
                );
        }

        [TestMethod]
        public void testAgeOK()
        {
            Personnes personne = new Personnes("JeAn", "PieRre", new DateTime(1999, 07, 02), "23 rue des pommes", "Paris", "75000", 175, 85);

            Assert.AreEqual(19, personne.Age);
        }

        [TestMethod]
        public void testFilmTitreOK()
        {
            Film film = new Film("coucou", "coucou2", new DateTime(2005), "lol coucou", "test", 160);

            Assert.AreEqual("coucou", film.Titre);
        }

        [TestMethod]
        public void testFilmAnneeOK()
        {
            Film film = new Film("coucou", "coucou2", new DateTime(2005), "lol coucou", "test", 160);

            Assert.AreEqual(new DateTime(2005).Year, film.DateDeSortie.Year);
        }

        [TestMethod]
        public void testFilmRealOK()
        {
            Film film = new Film("coucou", "coucou2", new DateTime(2005), "lol coucou", "test", 160);

            Assert.AreEqual("coucou2", film.Realisateur);
        }

        [TestMethod]
        public void testFilmResumeOK()
        {
            Film film = new Film("coucou", "coucou2", new DateTime(2005), "lol coucou", "test", 160);

            Assert.AreEqual("lol coucou", film.Resume);
        }

        [TestMethod]
        public void testFilmGenreOK()
        {
            Film film = new Film("coucou", "coucou2", new DateTime(2005), "lol coucou", "test", 160);

            Assert.AreEqual("test", film.Genre);
        }
    }
}
