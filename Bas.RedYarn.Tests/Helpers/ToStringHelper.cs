using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.Helpers
{
    class ToStringHelper
    {
        public static void ToString_NameIsNotEmpty_ReturnsName(INameable nameable)
        {
            // Arrange
            nameable.Name = "TestName";
            
            // Act
            var result = nameable.ToString();
            
            // Assert
            Assert.AreEqual(nameable.Name, result);
        }

        public static void ToString_NameIsEmpty_ReturnsClassName(INameable nameable)
        {
            // Arrange            
            // Act
            var result = nameable.ToString();
            // Assert
            Assert.AreEqual(nameable.GetType().Name, result);
            
        }
    }
}
