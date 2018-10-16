﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModel
{
    public sealed class PlotElementViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PlotElementViewModel(RedYarn.PlotElement plotElement)
        {
            Id = Guid.NewGuid();
            Name = plotElement.Name;
            Description = plotElement.Description;
        }
    }
}