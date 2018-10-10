namespace Bas.RedYarn
{
    public interface IRelationship : INameable
    {
        Character FirstCharacter { get; }
        Character SecondCharacter { get; }        
        bool IsDirectional { get; }
    }
}