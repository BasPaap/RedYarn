using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Services
{
    sealed class TestDataService : IDataService
    {
        public Diagram GetDiagram(int id)
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

            edmond.RelateTo(louis, "son", "father");
            edmond.RelateTo(mercedes, "engaged");
            edmond.RelateTo(albert, "is challenged to a duel by", "challenges to a duel");
            edmond.RelateTo(haydee, "owns", true);
            edmond.RelateTo(haydee, "loves");

            mercedes.RelateTo(fernand, "married");

            albert.RelateTo(mercedes, "son", "mother");
            albert.RelateTo(fernand, "son", "father");

            haydee.RelateTo(fernand, "exposes", true);

            var betrayal = new Storyline()
            {
                Name = "The Betrayal of Ali Pasha",
                Description = "Lorem Ipsum etc.",
            };

            betrayal.Authors.Add(dumas);
            betrayal.Characters.Add(fernand);
            betrayal.Characters.Add(haydee);

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

            return diagram;
        }
    }
}
