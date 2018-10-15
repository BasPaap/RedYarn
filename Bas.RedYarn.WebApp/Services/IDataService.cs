using Bas.RedYarn.WebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Services
{
    public interface IDataService
    {
        DiagramViewModel GetDiagramViewModel(int id);
    }
}
