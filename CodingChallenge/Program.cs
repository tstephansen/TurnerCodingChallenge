using System;
using System.Linq;
using System.Threading.Tasks;
using CodingChallenge.Entities;

namespace CodingChallenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (!args.Any())
            {
                PrintHelpText();
                return;
            }
            if (!ValidateArgs(args))
                return;
            Process(args);
        }

        /// <summary>
        ///     Validates the arguments that were passed into the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns><c>true</c> if it succeeds, <c>false</c> if it fails.</returns>
        private static bool ValidateArgs(string[] args)
        {
            var cl = Environment.CommandLine;
            var cls = cl.Split('\"');
            if (cls.Length != 3 && cls.Length != 5)
            {
                PrintHelpText();
                Console.WriteLine("Please be sure to enclose the name of the film in quotation marks.");
                return false;
            }

            var secondArg = args[1].ToLowerInvariant();
            var thirdArg = args[2].ToLowerInvariant();

            if (!secondArg.Equals("characters") && !secondArg.Equals("planets") && !secondArg.Equals("starships"))
            {
                PrintHelpText();
                Console.WriteLine($"The specified entity {secondArg} is not valid.");
                return false;
            }

            if (IsPropertyValid(thirdArg, secondArg))
                return true;

            PrintHelpText();
            Console.WriteLine($"The specified property ({thirdArg}) is not valid.");
            return false;
        }

        /// <summary>
        ///     Prints the help text to the console.
        /// </summary>
        private static void PrintHelpText()
        {
            Console.WriteLine(
                "Gets the film and prints the specified property for any either characters, planets, or starships.\n");
            Console.WriteLine("CODINGCHALLENGE.EXE [film] [entity] [property]\n");
            Console.WriteLine("Valid Entities:");
            Console.WriteLine("characters");
            Console.WriteLine("planets");
            Console.WriteLine("starships");

            Console.WriteLine("\nValid Character Properties:");
            foreach (var o in PeopleProperties)
            {
                Console.WriteLine($"{o}");
            }
            Console.WriteLine("\nValid Planet Properties:");
            foreach (var o in PlanetProperties)
            {
                Console.WriteLine($"{o}");
            }
            Console.WriteLine("\nValid Starship Properties:");
            foreach (var o in StarshipProperties)
            {
                Console.WriteLine($"{o}");
            }
            Console.WriteLine("\n");
        }

        private static readonly string[] PeopleProperties =
        {
            "name",
            "height",
            "mass",
            "hair_color",
            "skin_color",
            "eye_color",
            "birth_year",
            "gender",
            "homeworld",
            "url"
        };

        private static readonly string[] PlanetProperties =
        {
            "name",
            "rotation_period",
            "orbital_period",
            "diameter",
            "climate",
            "gravity",
            "terrain",
            "surface_water",
            "population",
            "url"
        };

        private static readonly string[] StarshipProperties =
        {
            "name",
            "model",
            "manufacturer",
            "cost_in_credits",
            "length",
            "max_atmosphering_speed",
            "crew",
            "passengers",
            "cargo_capacity",
            "consumables",
            "hyperdrive_rating",
            "MGLT",
            "starship_class",
            "url"
        };

        /// <summary>
        ///     Determines if the property the user specified is valid.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if the property is valid, <c>false</c> if not.</returns>
        private static bool IsPropertyValid(string property, string entity)
        {
            switch (entity)
            {
                default:
                    return false;
                case "characters":
                    return PeopleProperties.Contains(property);
                case "planets":
                    return PlanetProperties.Contains(property);
                case "starships":
                    return StarshipProperties.Contains(property);
            }
        }

        /// <summary>
        ///     Processes the user's request.
        /// </summary>
        /// <param name="args"> The arguments. </param>
        private static void Process(string[] args)
        {
            var title = args[0];
            var resp = SwapiOperations.Get<SwapiResponse>($"https://swapi.co/api/films/?search={title}");
            if (resp == null || resp.count == 0)
            {
                Console.WriteLine("The film you entered was not found.");
                return;
            }
            var films = resp.results;
            Parallel.ForEach(films, film => { GetResults(film, args[1].ToLowerInvariant(), args[2].ToLowerInvariant()); });
        }

        /// <summary>
        ///     Gets the characters, planets, or starships from the specified film and prints the
        ///     specified property to the console.
        /// </summary>
        /// <param name="film">The film.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="property">The property.</param>
        private static void GetResults(Film film, string entity, string property)
        {
            switch (entity)
            {
                case "characters":
                    Parallel.ForEach(film.characters, c =>
                    {
                        var result = SwapiOperations.Get<People>(c);
                        PrintProperty(result, property);
                    });
                    break;
                case "planets":
                    Parallel.ForEach(film.planets, c =>
                    {
                        var result = SwapiOperations.Get<Planet>(c);
                        PrintProperty(result, property);
                    });
                    break;
                case "starships":
                    Parallel.ForEach(film.starships, c =>
                    {
                        var result = SwapiOperations.Get<Starship>(c);
                        PrintProperty(result, property);
                    });
                    break;
            }
        }

        /// <summary>
        ///     Prints result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="property">The property.</param>
        private static void PrintProperty(object result, string property)
        {
            var value = result?.GetType().GetProperty(property)?.GetValue(result, null);
            if (value != null)
                Console.WriteLine(value);
        }
    }
}