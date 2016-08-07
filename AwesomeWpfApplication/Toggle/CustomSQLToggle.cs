using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeatureToggle.Core;
using FeatureToggle.Toggles;

namespace AwesomeWpfApplication.Toggle
{
    public class CustomSQLToggle: SqlFeatureToggle
    {
        public CustomSQLToggle()
        {
            this.ToggleValueProvider = new CustomSQLToggleProvider();
        }
    }
}
