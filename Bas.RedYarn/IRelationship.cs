namespace Bas.RedYarn
{
    internal interface IRelationship : INameable
    {
        Character FirstCharacter { get; set; }
        Character SecondCharacter { get; set; }
    }
}