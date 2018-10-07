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
        
    }
}
