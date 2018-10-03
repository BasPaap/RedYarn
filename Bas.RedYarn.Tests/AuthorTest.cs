using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public partial class AuthorTest
    {
        private Author author;

        [TestInitialize]
        public void Initialize()
        {
            this.author = new Author();
        }

        #region ToString
        [TestMethod]
        public void ToString_NameIsNotEmpty_ReturnsName()
        {
            ToStringHelper.ToString_NameIsNotEmpty_ReturnsName(this.author);
        }

        [TestMethod]
        public void ToString_NameIsEmpty_ReturnsClassName()
        {
            ToStringHelper.ToString_NameIsEmpty_ReturnsClassName(this.author);
        }
        #endregion
        
    }
}
