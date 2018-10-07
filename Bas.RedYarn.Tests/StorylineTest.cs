using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public partial class StorylineTest
    {
        private Storyline storyline;

        [TestInitialize]
        public void Initialize()
        {
            this.storyline = new Storyline();
        }
        
    }
}
