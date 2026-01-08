using System;
using System.Linq;
using Model;
using Microsoft.EntityFrameworkCore;

using var db = new efeksamen.AppContext();
//oprettning af data
//oprettning af data
//oprettning af data
if (!db.Movies.Any())
{
    //studios
    var warner = new Studio { Navn = "Warner Bros", Movies = new List<Movie>() };
    var universal = new Studio { Navn = "Universal Pictures", Movies = new List<Movie>() };

    
    //actors
    var mikkel = new Actor { Navn = "Mikkel", Kon = "Mand"};
    var anna = new Actor { Navn = "Anna", Kon = "Kvinde" };
    var sofie = new Actor { Navn = "Sofie", Kon = "Kvinde" };

    //movies
    var inception = new Movie { Title = "Inception", Year = 2010, Studio = warner };
    inception.Actors.Add(mikkel);
    inception.Actors.Add(anna);

    var matrix = new Movie { Title = "The Matrix", Year = 1999, Studio = universal };
    matrix.Actors.Add(sofie);
    matrix.Actors.Add(anna);
    //tilføj movies til studios
    warner.Movies.Add(inception);
    universal.Movies.Add(matrix);
    //tilføj data til db

    db.AddRange(inception, matrix); // EF finder selv actors/studios via relationerne
    //kræver kun add range på movies da det er det midterste objekt i relationerne og både actors og studios bliver tilføjet automatisk
    //addrange Fortæller altså at der er nogen relation mellem movies der skal holdes øje med
    db.SaveChanges();
}

//ændring af data
//ændring af data
//ændring af data
var actorToUpdate = db.Actors.FirstOrDefault(a => a.Navn == "Mikkel");
if (actorToUpdate != null)
{
    actorToUpdate.Navn = "Mikkel Hansen";
    db.SaveChanges();
}
var AddToMovie = db.Movies
    .Include(m => m.Actors)
    .FirstOrDefault(m => m.Title == "The Matrix");

var PlukActor = db.Actors.FirstOrDefault(a => a.Navn == "Mikkel Hansen");
if (AddToMovie != null && PlukActor != null)
{
    AddToMovie.Actors.Add(PlukActor);
    db.SaveChanges();
}

//visning af data
//visning af data
//visning af data
Console.WriteLine("Hos cinimaxx databasen er der følgende kunder");
foreach (var Actor in db.Actors.OrderBy(x => x.Id))
    Console.WriteLine($"id: {Actor.Id}: Er til actor: {Actor.Navn}");

var studios = db.Studios
    .Include(s => s.Movies)
    .OrderBy(s => s.Id)
    .ToList();

foreach (var studio in studios)
{
    Console.WriteLine($"Studio: {studio.Navn}");

    if (studio.Movies.Any())
    {
        foreach (var movie in studio.Movies)
        {
            Console.WriteLine($"  - {movie.Title} ({movie.Year})");
        }
    }
}
