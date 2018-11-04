using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bas.RedYarn
{
    public sealed class Diagram : INameable
    {
        public string Name { get; set; }

        public Collection<Author> Authors { get; } = new Collection<Author>();
        public Collection<Character> Characters { get; } = new Collection<Character>();
        public Collection<PlotElement> PlotElements { get; } = new Collection<PlotElement>();
        public Collection<Storyline> Storylines { get; } = new Collection<Storyline>();
        public Collection<Tag> Tags { get; } = new Collection<Tag>();
        public Collection<Alias> Aliases { get; } = new Collection<Alias>();

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(Diagram) : Name;
    }
}
