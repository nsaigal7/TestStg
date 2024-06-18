namespace Dtos;
public class InMemoryCharacterDto: ICharacterDto
{
    private readonly ICache _cache;
    private readonly IAuthenticationFactory _authServiceFactory;

    public InMemoryCharacterDto(ICache cache, IAuthenticationFactory authServicesFactory)
    {
        _cache = cache;
        _authServiceFactory = authServicesFactory;
    }

    public Dictionary<Guid, Character> database = new();
    public Character? GetRecordById(Guid id)
    { 
        Console.WriteLine(_authServiceFactory.GetAuthService(id).GetAuthToken());
        if (_cache.GetData(id.ToString()) != null) { return (Character)_cache.GetData(id.ToString()); }
        if (!database.ContainsKey(id)) { return null; }
        _cache.AddData(id.ToString(), database[id]);
        return database[id];
    }

    public Dictionary<Guid, Character> SearchCharacters(CharacterSearchRequest csr)
    {
        Guid id = Guid.NewGuid();
        Console.WriteLine(_authServiceFactory.GetAuthService(id).GetAuthToken());
        return database;
        /*
        List<Character> ret= new();
        foreach(Guid key in database.Keys)
        {
            ret.Add()
        }
        var x = database.Values;
        var y = database.Keys;
        return new List<Character>(database.Values);
        */
    }

    public Guid AddCharacter(Character ch)
    {
        Guid id = Guid.NewGuid();
        Console.WriteLine(_authServiceFactory.GetAuthService(id).GetAuthToken());
        Guid newGuid = Guid.NewGuid();
        database.Add(newGuid, ch);
        return newGuid; 
    }

    public bool Delete(Guid id)
    {
        Console.WriteLine(_authServiceFactory.GetAuthService(id).GetAuthToken());
        if (!database.ContainsKey(id)) { return false; }
        database.Remove(id);
        return true;
    }

    public bool Update(Guid id, Character newChar)
    {
        Console.WriteLine(_authServiceFactory.GetAuthService(id).GetAuthToken());
        if (!database.ContainsKey(id)) { return false; }
        database[id] = newChar;
        return true;
    }

    public void AddRecords()
    {
        Guid id = Guid.NewGuid();
        Console.WriteLine(_authServiceFactory.GetAuthService(id).GetAuthToken());
        // Create objects for each character
        Character spongeBob = new Character("SpongeBob SquarePants", "Sea sponge", "A pineapple under the sea, Bikini Bottom", "Yellow", "Fry cook");
        AddCharacter(spongeBob);
        Character patrick = new Character("Patrick Star", "Starfish", "Under a rock, Bikini Bottom", "Pink", "Unemployed");
        AddCharacter(patrick);        
        Character squidward = new Character("Squidward Tentacles", "Octopus", "Easter Island Head house, Bikini Bottom", "Cyan", "Cashier");
        AddCharacter(squidward);
        Character mrKrabs = new Character("Mr. Eugene H. Krabs", "Crab", "Anchor House, Bikini Bottom", "Red", "Owner and manager");
        AddCharacter(mrKrabs);
        Character sandy = new Character("Sandy Cheeks", "Squirrel", "Treedome, Bikini Bottom", "Brown", "Scientist");
        AddCharacter(sandy);
        Character plankton = new Character("Plankton", "Plankton", "Chum Bucket, Bikini Bottom", "Green", "Owner and operator");
        AddCharacter(plankton);
        Character gary = new Character("Gary the Snail", "Snail", "Pineapple, Bikini Bottom", "Blue", "Household pet");
        AddCharacter(gary);
        // Display each character
        /*Console.WriteLine(spongeBob);
        Console.WriteLine(patrick);
        Console.WriteLine(squidward);
        Console.WriteLine(mrKrabs);
        Console.WriteLine(sandy);
        Console.WriteLine(plankton);
        Console.WriteLine(gary);*/
    }
}

public class CharacterSearchRequest {}