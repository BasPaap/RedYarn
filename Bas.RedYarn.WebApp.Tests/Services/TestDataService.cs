using Bas.RedYarn.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Tests.Services
{
    sealed class TestDataService : IDataService
    {
        public Diagram GetDiagram(int id)
        {
            var firstAuthor = new Author() { Name = "FirstAuthor" };
            var secondAuthor = new Author() { Name = "SecondAuthor" };

            var firstCharacter = new Character() { Name = "FirstCharacter" };
            firstCharacter.Aliases.Add("FirstAlias");
            firstCharacter.Aliases.Add("SecondAlias");
            firstCharacter.Authors.Add(firstAuthor);

            var secondCharacter = new Character() { Name = "SecondCharacter" };
            secondCharacter.Authors.Add(firstAuthor);
            secondCharacter.Authors.Add(secondAuthor);

            firstCharacter.RelateTo(secondCharacter, "RelationshipFromFirstToSecond", "RelationshipFromSecondToFirst");

            var diagram = new Diagram() { Name = "Diagram" };
            diagram.Authors.Add(firstAuthor);
            diagram.Authors.Add(secondAuthor);
            diagram.Characters.Add(firstCharacter);
            diagram.Characters.Add(secondCharacter);

            return diagram;
        }
    }
}
