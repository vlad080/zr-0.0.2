namespace Code.Infrastructure.Factory
{
    public class Factory : IFactory
    {
        public ICharacterFactory CharacterFactory { get; }

        public Factory(ICharacterFactory characterFactory)
        {
            CharacterFactory = characterFactory;
        }
    }
}