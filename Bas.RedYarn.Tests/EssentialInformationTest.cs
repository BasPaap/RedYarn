using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public partial class EssentialInformationTest
    {
        private EssentialInformation essentialInformation;

        [TestInitialize]
        public void Initialize()
        {
            this.essentialInformation = new EssentialInformation();
        }

        #region ToString
        [TestMethod]
        public void ToString_NameIsNotEmpty_ReturnsName()
        {
            ToStringHelper.ToString_NameIsNotEmpty_ReturnsName(this.essentialInformation);
        }

        [TestMethod]
        public void ToString_NameIsEmpty_ReturnsClassName()
        {
            ToStringHelper.ToString_NameIsEmpty_ReturnsClassName(this.essentialInformation);
        }
        #endregion
    }
}
