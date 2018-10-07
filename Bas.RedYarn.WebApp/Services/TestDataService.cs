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
            return new Diagram();
        }
    }
}
