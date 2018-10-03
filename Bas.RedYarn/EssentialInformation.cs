using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bas.RedYarn
{
    /// <summary>
    /// Represents information owned by characters or required for characters to 'complete' a storyline.
    /// </summary>
    public sealed class EssentialInformation : INameable
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get; set; }
        public Collection<Storyline> Storylines { get; }
        public Collection<Character> OwningCharacters { get; }
        public Collection<Character> NeedingCharacters { get; }
    }
}
