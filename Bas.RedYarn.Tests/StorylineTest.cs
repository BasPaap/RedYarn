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

        #region ToString
        [TestMethod]
        public void ToString_NameIsNotEmpty_ReturnsName()
        {
            ToStringHelper.ToString_NameIsNotEmpty_ReturnsName(this.storyline);
        }

        [TestMethod]
        public void ToString_NameIsEmpty_ReturnsClassName()
        {
            ToStringHelper.ToString_NameIsEmpty_ReturnsClassName(this.storyline);
        }
        #endregion
        
    }
}
