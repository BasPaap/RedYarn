using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Model
{
    public sealed class Diagram
    {
        public string Name { get; set; }
        public Collection<Character> Characters { get; } = new Collection<Character>();
        public Collection<Storyline> Storylines { get; } = new Collection<Storyline>();
        public Collection<Relationship> Relationships { get; } = new Collection<Relationship>();
        public Collection<StorylineConnection> StorylineConnections { get; } = new Collection<StorylineConnection>();

        public Diagram()
        {
        }

        public Diagram(RedYarn.Diagram diagram)
        {
            Name = diagram.Name;
        }
    }
}
