using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.UI.Components
{
    public partial class FilterComponent : Component
    {
        public FilterComponent()
        {
            InitializeComponent();
        }

        public FilterComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
