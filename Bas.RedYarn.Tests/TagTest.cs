﻿using Bas.RedYarn.Helpers;
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
    }
}
