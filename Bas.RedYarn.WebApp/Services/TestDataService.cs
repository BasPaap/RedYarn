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

            edmond.RelateTo(louis, "son", "father");
            edmond.RelateTo(mercedes, "engaged");
            edmond.RelateTo(albert, "is challenged to a duel by", "challenges to a duel");

            mercedes.RelateTo(fernand, "married");

            albert.RelateTo(mercedes, "son", "mother");
            albert.RelateTo(fernand, "son", "father");

            var diagram = new Diagram();
            diagram.Characters.Add(edmond);
            diagram.Characters.Add(louis);
            diagram.Characters.Add(mercedes);
            diagram.Characters.Add(fernand);
            diagram.Characters.Add(albert);
            diagram.Authors.Add(dumas);

            return diagram;
        }
    }
}
