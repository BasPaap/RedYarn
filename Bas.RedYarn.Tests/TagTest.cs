using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public partial class TagTest
    {
        private Tag tag;

        [TestInitialize]
        public void Initialize()
        {
            this.tag = new Tag();
        }

        #region ToString
        [TestMethod]
        public void ToString_NameIsNotEmpty_ReturnsName()
        {
            ToStringHelper.ToString_NameIsNotEmpty_ReturnsName(this.tag);
        }

        [TestMethod]
        public void ToString_NameIsEmpty_ReturnsClassName()
        {
            ToStringHelper.ToString_NameIsEmpty_ReturnsClassName(this.tag);
        }
        #endregion        
    }
}
