using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bas.RedYarn
{
    /// <summary>
    /// Represents a storyline containing a name, description, characters, authors, etc.
    /// </summary>
    public sealed class Storyline : INameable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Collection<Character> Characters { get; }
        public Collection<Author> Authors { get; }
        public Collection<EssentialPlotElement> EssentialPlotElements { get; }

        public Storyline()
        {
            Characters = new CoupledCollection<Character, Storyline>(this, nameof(Character.Storylines));
            Authors = new CoupledCollection<Author, Storyline>(this, nameof(Author.Storylines));
            EssentialPlotElements = new CoupledCollection<EssentialPlotElement, Storyline>(this, nameof(EssentialPlotElement.Storylines));
        }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(Storyline) : Name;
    }
}
