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

        #region ToString
        [TestMethod]
        public void ToString_NameIsNotEmpty_ReturnsName()
        {
            ToStringHelper.ToString_NameIsNotEmpty_ReturnsName(this.essentialPlotElement);
        }

        [TestMethod]
        public void ToString_NameIsEmpty_ReturnsClassName()
        {
            ToStringHelper.ToString_NameIsEmpty_ReturnsClassName(this.essentialPlotElement);
        }
        #endregion
    }
}
