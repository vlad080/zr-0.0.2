namespace Code.Infrastructure.Factory
{
    public interface IFactory
    {
        ICharacterFactory CharacterFactory { get;  }
    }
}