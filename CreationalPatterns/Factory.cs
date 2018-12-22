namespace CreationalPatterns
{
    public enum PeopleType
    {
        RURAL,
        URBAN
    }

    public interface IPeople
    {
        string GetName();
    }

    public class Factory
    {
        public IPeople GetPeople(PeopleType peopleType)
        {
            IPeople people = null;
            switch (peopleType)
            {
                case PeopleType.RURAL:
                    people = new Villager();
                    break;
                case PeopleType.URBAN:
                    people = new UrbanPeople();
                    break;
                default:
                    break;
            }
            return people;
        }
    }

    internal class UrbanPeople : IPeople
    {
        public string GetName()
        {
            return "Urban Guy";
        }
    }

    internal class Villager : IPeople
    {
        public string GetName()
        {
            return "Village Guy";
        }
    }
}
