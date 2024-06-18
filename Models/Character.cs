using Dtos;

// Define the Character class
public class Character
{
    public string Name { get; set; }
    public string Species { get; set; }
    public string Residence { get; set; }
    public string Color { get; set; }
    public string Occupation { get; set; }

    public Character(string name, string species, string residence, string color, string occupation)
    {
        Name = name;
        Species = species;
        Residence = residence;
        Color = color;
        Occupation = occupation;
    }

    public override string ToString()
    {
        return $"{Name} - Species: {Species}, Residence: {Residence}, Color: {Color}, Occupation: {Occupation}";
    }
}