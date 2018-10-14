using System;
using System.Collections.ObjectModel;
namespace Bas.RedYarn.WebApp.ViewModel
{
    public sealed class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Collection<string> Aliases { get; } = new Collection<string>();

        public Character()
        {
        }

        public Character(RedYarn.Character character)
        {
            Id = Guid.NewGuid();
            Name = character.Name;
            Description = character.Description;

            foreach (var alias in character.Aliases)
            {
                Aliases.Add(alias);
            }
        }
    }
}