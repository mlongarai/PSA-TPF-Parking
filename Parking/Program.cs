using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Parking.Models;
using Parking.business;

namespace Parking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new ParkingContext())
            {
                #region seeding
                if (db.Tickets.Count() == 0)
                {
                    Seed(db);
                }
                #endregion
            }
            BuildWebHost(args).Run();
            Console.ReadKey();
            // BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        static void Seed(ParkingContext db)
        {
            var tickets = new List<Ticket> {
                //ReleaseDate = new DateTime(2017, 03, 24),
                new Ticket { valorCobrado = 15,  especial = false, dataHoraEmissao = DateTime.Now.AddMinutes(-18), dataHoraValidade = DateTime.Now.AddMinutes(-3)},
                new Ticket { valorCobrado = 20, especial = false, dataHoraEmissao = DateTime.Now.AddDays(-1), dataHoraValidade = DateTime.Now.AddMinutes(15).AddDays(-1)},
                new Ticket { valorCobrado = 10, especial = false, dataHoraEmissao = DateTime.Now.AddHours(-3), dataHoraValidade = DateTime.Now.AddMinutes(15).AddHours(-3)},
                new Ticket { valorCobrado = 5, especial = false, dataHoraEmissao = DateTime.Now, dataHoraValidade = DateTime.Now.AddMinutes(15)},
                new Ticket { valorCobrado = 30, especial = true, dataHoraEmissao = DateTime.Now, dataHoraValidade = DateTime.Now.AddMinutes(15)},
                new Ticket { valorCobrado = 30, especial = true, dataHoraEmissao = DateTime.Now, dataHoraValidade = DateTime.Now.AddMinutes(15)}
            };

            db.Tickets.AddRange(tickets);
            var cont = db.SaveChanges();
            Console.WriteLine("{0} registros Genre armazenados no BD", cont);

        }

        /* static void Seed(ParkingContext db)
         {

             var tickets = new List<Ticket>

             var genres = new List<Genre>
      {
      new Genre { Name = "Action", Description = "An action story is similar to adventure, and the protagonist usually takes a risky turn, which leads to desperate situations (including explosions, fight scenes, daring escapes, etc.)." },
      new Genre { Name = "Adventure", Description = "An adventure story is about a protagonist who journeys to epic or distant places to accomplish something. It can have many other genre elements included within it, because it is a very open genre." },
      new Genre { Name = "Animation", Description = "Technically speaking, animation is more of a medium than a film genre in and of itself; as a result, animated movies can run the gamut of traditional genres with the only common factor being that they don’t rely predominantly on live action footage." },

         new Genre
      {
          Name = "Comedy",
          Description = "Comedy is a story that tells about a series of funny or comical events, intended to make the audience laugh.It is a very open genre, and thus crosses over with many other genres on a frequent basis." },
      new Genre
      {
          Name = "Romantic Comedy",
          Description = "A subgenre which combines the romance genre with comedy, focusing on two or more individuals as they discover and attempt to deal with their romantic love, attractions to each other.The stereotypical plot line follows the boy - gets - girl, boy - loses - girl, boy gets girl back again sequence. " },
      new Genre
      {
          Name = "Crime",
          Description = "A subgenre which combines the romance genre with comedy, focusing on two or more individuals as they discover and attempt to deal with their romantic love, attractions to each other. " },
      new Genre
      {
          Name = "Drama",
          Description = "Within film, television and radio (but not theatre), drama is a genre of narrative fiction(or semi - fiction) intended to be more serious than humorous in tone, " },
      new Genre
      {
          Name = "Sci-Fi",
          Description = "Science fiction is similar to fantasy, except stories in this genre use scientific understanding to explain the universe that it takes place in. It generally includes or is centered on the presumed effects or ramifications of computers or machines; travel through space, time or alternate universes; alien life-forms; genetic engineering; or other such things. " },
         new Genre
      {
          Name = "Romance",
          Description = "Romance novels are emotion-driven stories that are primarily focused on the relationship between the main characters of the story." },
      new Genre
      {
          Name = "Fantasy",
          Description = "A fantasy story is about magic or supernatural forces, rather than technology, though it often is made to include elements of other genres, such as science fiction elements, for instance computers or DNA, if it happens to take place in a modern or future era. " },
         new Genre
      {
          Name = "Sport",
          Description = "The coverage of sports as a television program, on radio and other broadcasting media.It usually involves one or more sports commentators describing the events as they happen, which is called colour commentary." },
      new Genre
      {
          Name = "Western",
          Description = "tories in the Western genre are set in the American West, between the time of the Civil war and the early nineteenth century." },
      new Genre
      {
          Name = "Thriller",
          Description = "A Thriller is a story that is usually a mix of fear and excitement.It has traits from the suspense genre and often from the action, adventure or mystery genres, but the level of terror makes it borderline horror fiction at times as well. " },
      new Genre
      {
          Name = "Family",
          Description = "The family saga is a genre of literature which chronicles the lives and doings of a family or a number of related or interconnected families over a period of time. " }
      };
             db.Genres.AddRange(genres);
             var cont = db.SaveChanges();
             Console.WriteLine("{0} registros Genre armazenados no BD", cont);
             var movies = new List<Movie> {
      new Movie
      {

      Title = "Rio Bravo",
      ReleaseDate = DateTime.Parse("4/15/1959",new CultureInfo("en-US")),
      Director = "Howard Hawks",
      //Genre = genres.Single( g => g.Name == "Western"),
      GenreID = genres.Single( g => g.Name == "Western").GenreID,
      Rating = 8.1,
      Gross = 5750000
      },
      new Movie {
      Title = "The Shawshank Redemption",
      ReleaseDate = DateTime.Parse("10/14/1994",new CultureInfo("en-US")),
      Director = "Frank Darabont" ,
      GenreID = genres.Single( g => g.Name == "Drama").GenreID,
      Gross = 28341469,
      Rating = 9.3
      },
      new Movie { Title = "The Godfather", Director = "Francis Ford Coppola", ReleaseDate =
     DateTime.Parse("3/24/1972",new CultureInfo("en-US")), GenreID = genres.Single( g => g.Name ==
     "Drama").GenreID,Gross = 134821952 , Rating = 9.2},
      new Movie { Title = "Pulp Fiction", Director = "Quentin Tarantino", ReleaseDate =
     DateTime.Parse("10/14/1994",new CultureInfo("en-US")), GenreID = genres.Single( g => g.Name ==
     "Thriller").GenreID,Gross = 107930000, Rating = 8.9},
      new Movie { Title = "Schindlers List", Director = "Steven Spielberg", ReleaseDate =
     DateTime.Parse("2/4/1994",new CultureInfo("en-US")), GenreID = genres.Single( g => g.Name ==
     "Drama").GenreID,Gross = 96067179, Rating = 8.9 },
      new Movie { Title = "The Dark Knight", Director = "Christopher Nolan", ReleaseDate =
     DateTime.Parse("7/18/2008",new CultureInfo("en-US")), GenreID = genres.Single( g => g.Name ==
     "Action").GenreID,Gross = 533316061, Rating = 9.0 },
      new Movie { Title = "The Lord of the Rings: The Return of the King", Director = "Peter Jackson",
     ReleaseDate = DateTime.Parse("12/17/2003",new CultureInfo("en-US")), GenreID = genres.Single( g
     => g.Name == "Action").GenreID,Gross = 377019252, Rating = 8.9 },
      new Movie { Title = "Star Wars", Director = "George Lucas", ReleaseDate =
     DateTime.Parse("5/25/1977",new CultureInfo("en-US")), GenreID = genres.Single( g => g.Name ==
     "Action").GenreID,Gross = 460935665, Rating = 8.7 },
      new Movie { Title = "The Matrix", Director = "The Wachowski Brothers", ReleaseDate =
     DateTime.Parse("3/31/1999",new CultureInfo("en-US")), GenreID = genres.Single( g => g.Name ==
     "Sci-Fi").GenreID,Gross = 171383253, Rating = 8.7},
      new Movie { Title = "Forrest Gump", Director = "Robert Zemeckis", ReleaseDate =
     DateTime.Parse("7/6/1994",new CultureInfo("en-US")), GenreID = genres.Single( g => g.Name ==
     "Comedy").GenreID,Gross = 329691196, Rating = 8.8 },
      new Movie { Title = "Monty Python and the Holy Grail", Director = " Terry Gilliam & Terry Jones",
     ReleaseDate = DateTime.Parse("5/23/1975",new CultureInfo("en-US")), GenreID = genres.Single( g =>
     g.Name == "Comedy").GenreID,Gross=1229197, Rating = 8.3 },
      new Movie { Title = "2001: A Space Odyssey", Director = "Stanley Kubrick", ReleaseDate =
     DateTime.Parse("4/29/1968",new CultureInfo("en-US")), GenreID = genres.Single( g => g.Name ==
     "Sci-Fi").GenreID,Gross = 56715371, Rating = 8.3 },
      new Movie { Title = "Back to the Future", Director = "Robert Zemeckis", ReleaseDate =
     DateTime.Parse("1/22/1989",new CultureInfo("en-US")), GenreID = genres.Single( g => g.Name ==
     "Family").GenreID,Gross = 210609762, Rating = 8.5},
      new Movie { Title = "Monsters Inc", Director = "Pete Docter & David Silverman", ReleaseDate =
     DateTime.Parse("11/2/2001",new CultureInfo("en-US")), GenreID = genres.Single( g => g.Name ==
     "Family").GenreID,Gross = 289907418, Rating = 8.1}
      };
             db.Movies.AddRange(movies);
             cont = db.SaveChanges();
             Console.WriteLine("{0} registros Movie armazenados no BD", cont);
         }*/
    }
}
