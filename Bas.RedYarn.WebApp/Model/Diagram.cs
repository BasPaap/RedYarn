using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Model
{
    public class Diagram
    {
        public Collection<Character> Characters { get; } = new Collection<Character>();
        public Collection<Author> Authors { get; } = new Collection<Author>();
        public Collection<EssentialPlotElement> EssentialPlotElements { get; } = new Collection<EssentialPlotElement>();
        public Collection<Storyline> Storylines { get; } = new Collection<Storyline>();
        public Collection<Tag> Tags { get; } = new Collection<Tag>();
    }
}
