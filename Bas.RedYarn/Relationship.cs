using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    public class Relationship : INameable
    {
        public Character FirstCharacter { get; set; }
        public Character SecondCharacter { get; set; }
        public string Name { get; set; }
        public bool IsDirectional { get; } = false;
        
        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(Relationship) : Name;

        public Relationship(Character firstCharacter, Character secondCharacter, string name, bool isDirectional = true)
        {
            this.FirstCharacter = firstCharacter;
            this.SecondCharacter = secondCharacter;
            this.Name = name;
            this.IsDirectional = isDirectional;
        }
    }
}
