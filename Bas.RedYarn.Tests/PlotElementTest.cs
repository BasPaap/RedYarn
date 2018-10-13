using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public partial class PlotElementTest
    {
        private PlotElement plotElement;

        [TestInitialize]
        public void Initialize()
        {
            this.plotElement = new PlotElement();
        }
                
    }
}
