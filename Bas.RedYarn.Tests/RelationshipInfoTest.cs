using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public partial class RelationshipInfoTest
    {
        private RelationshipInfo relationshipInfo;

        [TestInitialize]
        public void Initialize()
        {
            relationshipInfo = new RelationshipInfo();
        }
    }
}