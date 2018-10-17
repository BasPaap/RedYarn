using Bas.RedYarn.WebApp.Tests.Extensions;
using Bas.RedYarn.WebApp.Tests.Helpers;
using Bas.RedYarn.WebApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Bas.RedYarn.WebApp.Tests
{
    [TestClass]
    public partial class DiagramControllerTest
    {
        
        // UpdateDiagram
        // arg null -> 400 bad request
        // id bestaat niet -> 404 not found
        // vm is okee -> 204 no content (https://stackoverflow.com/questions/797834/should-a-restful-put-operation-return-something)

        // DeleteDiagram
        // id bestaat niet -> 404 not found
        // id bestaat -> 204 no content

        // GetDiagram
        // id bestaat => 200
        // id bestaat niet => 404 not found

        public void AssertCreatedDiagram(DiagramViewModel diagram)
        {           
            
        }
    }
}
