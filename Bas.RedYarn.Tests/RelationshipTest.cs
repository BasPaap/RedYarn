using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public partial class RelationshipTest
    {
        private Relationship relationship;
        
        [TestInitialize]
        public void Initialize()
        {
            this.relationship = new Relationship();
        }

    }
}
