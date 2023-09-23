
//filepaths
using Microsoft.VisualBasic.FileIO;

string projectRootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
string pokemonFilePath = $"{projectRootFolder}{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}AllPokemon.csv";
string bannedGamesFilePath = $"{projectRootFolder}{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}BannedGames.csv";
string dbFilePath = $"{projectRootFolder}{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}data.db";

//lists for holding objects of pokemon/banned games
List<Pokemon> pokemonList = new List<Pokemon>();
List<BannedGame> bannedGameList = new List<BannedGame>();
//creating lists of game objects

//filling list of pokemon from CSV
//------------------------------------------------------------------------
using (StreamReader sr = new StreamReader(pokemonFilePath))
{
    int i = 0;
    while (!sr.EndOfStream)
    {
        var row = sr.ReadLine().Split(',');

        pokemonList.Add
        (
            new Pokemon
            {
                Id = i++,
                DexNumber = Convert.ToInt32(row[0]),
                Name = Convert.ToString(row[1]),
                Form = Convert.ToString(row[2]),
                Type1 = Convert.ToString(row[3]),
                Type2 = Convert.ToString(row[4]),
                Total = Convert.ToInt32(row[5]),
                HP = Convert.ToInt32(row[6]),
                Attack = Convert.ToInt32(row[7]),
                Defense = Convert.ToInt32(row[8]),
                SpecialAttack = Convert.ToInt32(row[9]),
                SpecialDefense = Convert.ToInt32(row[10]),
                Speed = Convert.ToInt32(row[11]),
                Generation = Convert.ToInt32(row[12])
            }
        ); 
    }
}


//filling list of pokemon from CSV
//------------------------------------------------------------------------
using (StreamReader sr = new StreamReader(bannedGamesFilePath))
{
    int i = 0;
    while (!sr.EndOfStream)
    {
        var row = sr.ReadLine().Split(',');

        bannedGameList.Add
        (
            new BannedGame
            {
                Id = i++,
                Title = Convert.ToString(row[0]),
                Series = Convert.ToString(row[1]),
                Country = Convert.ToString(row[2]),
                Details = Convert.ToString(row[3])
            }
        );
    }
}
//------------------------------------------------------------------------

//starting up the querybuilder & performing necessary operations
//------------------------------------------------------------------------
using (QueryBuilder qb = new QueryBuilder(dbFilePath))
{
    //deleting all pokemon (and banned games) from database
    //------------------------------------------------------------------------
    Console.WriteLine("Deleting all pokemon from database...");
    //------------------------------------------------------------------------
    
    qb.DeleteAll<Pokemon>();
    qb.DeleteAll<BannedGame>();

    Console.ForegroundColor = ConsoleColor.Green;
    if(qb.ReadAll<Pokemon>().Count == 0)
        Console.WriteLine("Deletion successful!");
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Deletion unsuccessful. Try again.");
    }
    Console.ResetColor();
    Console.WriteLine("\n\nPress enter to continue.");
    Console.ReadLine();
    Console.Clear();
    //------------------------------------------------------------------------

    //creating a lot of pokemon from the pokemon list
    //------------------------------------------------------------------------
    Console.WriteLine("Populating database...");
    for(int i = 0; i < 200; i++)
    {
        qb.Create<Pokemon>(pokemonList[i]);
    }
    if (qb.ReadAll<Pokemon>().Count != 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Population successful!");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Population unsuccessful. Try again.");
    }

    Console.ResetColor();
    Console.WriteLine("\n\nPress enter to continue.");
    Console.ReadLine();
    Console.Clear();

    //creating a single row in the database from pokemon object
    //------------------------------------------------------------------------
    Console.WriteLine("Creating a single pokemon...");
    qb.Create<Pokemon>(pokemonList[200]);
    if(qb.Read<Pokemon>(200) != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Creation successful!");
        Console.WriteLine($"Pokemon Added:\n{qb.Read<Pokemon>(200).ToString()}");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Creation unsuccessful. Please try again.");
    }

    Console.ResetColor();
    Console.WriteLine("\n\nPress enter to continue.");
    Console.ReadLine();
    Console.Clear();
    //------------------------------------------------------------------------


    //creating a single row in the database from bannedgame object
    //------------------------------------------------------------------------
    Console.WriteLine("Creating a single banned game...");
    qb.Create<BannedGame>(bannedGameList[0]);
    qb.Create<BannedGame>(bannedGameList[1]);
    if (!qb.Read<BannedGame>(0).Equals(new BannedGame()))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Creation successful!");
        Console.WriteLine($"Game Added:\n{qb.Read<BannedGame>(0).ToString()}");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Creation unsuccessful. Please try again.");
    }

    Console.ResetColor();
    Console.WriteLine("\n\nPress enter to continue.");
    Console.ReadLine();
    Console.Clear();
    //------------------------------------------------------------------------

    Console.WriteLine("Thanks for trying out this demo!");
    Console.WriteLine("\n\nPress enter to exit.");
    Console.ReadLine();
    //end
}

