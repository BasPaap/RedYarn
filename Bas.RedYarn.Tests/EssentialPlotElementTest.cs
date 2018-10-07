using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public partial class EssentialPlotElementTest
    {
        private EssentialPlotElement essentialPlotElement;

        [TestInitialize]
        public void Initialize()
        {
            this.essentialPlotElement = new EssentialPlotElement();
        }
                
    }
}
