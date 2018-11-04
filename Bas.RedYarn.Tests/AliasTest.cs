using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public partial class AliasTest
    {
        private Alias alias;

        [TestInitialize]
        public void Initialize()
        {
            this.alias = new Alias();
        }

    }
}
