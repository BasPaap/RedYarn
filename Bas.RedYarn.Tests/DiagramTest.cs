using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public partial class DiagramTest
    {
        private Diagram diagram;

        [TestInitialize]
        public void Initialize()
        {
            this.diagram = new Diagram();
        }
    }
}
