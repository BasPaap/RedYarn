using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bas.RedYarn
{
    /// <summary>
    /// Represents information owned by characters or required for characters to 'complete' a storyline.
    /// </summary>
    public sealed class EssentialPlotElement : INameable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Collection<Storyline> Storylines { get; }
        public Collection<Character> OwningCharacters { get; }
        public Collection<Character> NeedingCharacters { get; }

        public EssentialPlotElement()
        {
            Storylines = new CoupledCollection<Storyline, EssentialPlotElement>(this, nameof(Storyline.EssentialPlotElements));
            OwningCharacters = new CoupledCollection<Character, EssentialPlotElement>(this, nameof(Character.OwnedPlotElements));
            NeedingCharacters = new CoupledCollection<Character, EssentialPlotElement>(this, nameof(Character.NeededPlotElements));
        }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(EssentialPlotElement) : Name;
    }
}
