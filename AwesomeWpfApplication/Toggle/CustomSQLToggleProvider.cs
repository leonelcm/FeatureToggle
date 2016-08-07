using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeatureToggle.Core;
using FeatureToggle.Providers;
using System.Configuration;

namespace AwesomeWpfApplication.Toggle
{
    public class CustomSQLToggleProvider : IBooleanToggleValueProvider
    {
        public bool EvaluateBooleanToggleValue(IFeatureToggle toggle)
        {
            string textFromAppConfig = this.GetCommandTextFromAppConfig(toggle);
            using (SqlConnection connection = new SqlConnection(this.GetConnectionStringFromConfig(toggle)))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(textFromAppConfig, connection))
                    return (bool)sqlCommand.ExecuteScalar();
            }
        }

        private string GetConnectionStringFromConfig(IFeatureToggle toggle)
        {
            string index = ToggleConfigurationSettings.Prefix + toggle.GetType().Name + ".ConnectionString";
            if (!Enumerable.Contains<string>((IEnumerable<string>)ConfigurationManager.AppSettings.AllKeys, index))
                throw new ToggleConfigurationError(string.Format("The key '{0}' was not found in AppSettings",
                    (object)index));
            return ConfigurationManager.AppSettings[index];
        }

        private string GetCommandTextFromAppConfig(IFeatureToggle toggle)
        {
            string index = ToggleConfigurationSettings.Prefix + toggle.GetType().Name + ".Table";
            if (!Enumerable.Contains<string>((IEnumerable<string>) ConfigurationManager.AppSettings.AllKeys, index))
                throw new ToggleConfigurationError(string.Format("The key '{0}' was not found in AppSettings",
                    (object) index));

            return string.Format("SELECT ToggleValue FROM {0} WHERE ToggleName = '{1}'", ConfigurationManager.AppSettings[index],
                toggle.GetType().Name);
 
        }
    }
}
