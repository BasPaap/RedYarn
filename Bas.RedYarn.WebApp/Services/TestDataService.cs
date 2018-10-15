using Bas.RedYarn.WebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Services
{
    sealed class TestDataService : IDataService
    {
        public DiagramViewModel GetDiagramViewModel(Guid id)
        {
            var dumas = new Author() { Name = "Alexandre Dumas" };

            var edmond = new Character() { Name = "Edmond Dantés" };
            edmond.Aliases.Add("Count of Monte Christo");
            edmond.Aliases.Add("Sinbad the Sailor");
            edmond.Aliases.Add("Abbé Busoni");
            edmond.Aliases.Add("Lord Wilmore");
            edmond.Authors.Add(dumas);

            var louis = new Character() { Name = "Louis Dantés" };
            louis.Authors.Add(dumas);

            var mercedes = new Character() { Name = "Mercédès" };
            mercedes.Aliases.Add("Countess Mercédès Mondego");
            mercedes.Aliases.Add("Mlle de Morcerf");
            mercedes.Authors.Add(dumas);

            var fernand = new Character { Name = "Fernand Mondego" };
            fernand.Aliases.Add("Count de Morcerf");
            fernand.Authors.Add(dumas);

            var albert = new Character { Name = "Albert de Morcerf" };
            albert.Authors.Add(dumas);

            var haydee = new Character { Name = "Haydée" };
            haydee.Authors.Add(dumas);

            edmond.RelateTo(louis, "son of", true);
            edmond.RelateTo(mercedes, "engaged");
            edmond.RelateTo(haydee, "owns", true);
            edmond.RelateTo(haydee, "loves");

            mercedes.RelateTo(fernand, "married");

            mercedes.RelateTo(albert, "mother of", true);
            fernand.RelateTo(albert, "father of", true);
            albert.RelateTo(edmond, "challenges to a duel", true);

            haydee.RelateTo(fernand, "exposes", true);

            var betrayal = new Storyline()
            {
                Name = "The Betrayal of Ali Pasha",
                Description = "Lorem Ipsum etc.",
            };

            betrayal.Authors.Add(dumas);
            betrayal.Characters.Add(fernand);
            betrayal.Characters.Add(haydee);

            var haydeesIdentity = new PlotElement()
            {
                Name = "Haydée is Ali Pasha's daughter",
                Description = "Ali Pasha's daughter was sold into slavery and, after the death of her mother, the only surviving person to know of Ali's betrayer."
            };
            haydeesIdentity.OwningCharacters.Add(haydee);

            var alisBetrayer = new PlotElement()
            {
                Name = "Fernand betrayed and murdered Ali Pasha.",
                Description = "Fernand was the officer who betrayed and murdered Ali Pasha. If this became public, it would cause a scandal."
            };
            alisBetrayer.OwningCharacters.Add(fernand);
            alisBetrayer.NeedingCharacters.Add(haydee);
            
            betrayal.PlotElements.Add(haydeesIdentity);
            betrayal.PlotElements.Add(alisBetrayer);

            var diagram = new Diagram()
            {
                Name = "The Count of Monte Cristo"
            };

            diagram.Characters.Add(edmond);
            diagram.Characters.Add(louis);
            diagram.Characters.Add(mercedes);
            diagram.Characters.Add(fernand);
            diagram.Characters.Add(albert);
            diagram.Characters.Add(haydee);
            diagram.Authors.Add(dumas);
            diagram.Storylines.Add(betrayal);
            diagram.PlotElements.Add(alisBetrayer);
            diagram.PlotElements.Add(haydeesIdentity);

            return new DiagramViewModel(diagram);
        }
    }
}
