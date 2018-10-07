using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Services
{
    public interface IDataService
    {
        Diagram GetDiagram(int id);
    }
}
