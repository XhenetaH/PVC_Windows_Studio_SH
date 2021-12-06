using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PVCWindowsStudio.BO
{
    public class ChangeLanguage
    {
        public void UpdateConfig(string key, string value)
        {
            var xmlDoc = new XmlDocument();

            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);


            foreach (XmlElement item in xmlDoc.DocumentElement)
            {
                if (item.Name.Equals("appSettings"))
                {
                    foreach (XmlNode xmlNode in item.ChildNodes)
                    {
                        if (xmlNode.Attributes[0].Value.Equals(key))
                        {
                            xmlNode.Attributes[1].Value = value;
                        }
                    }
                }
            }


            ConfigurationManager.RefreshSection("appSettings");

            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }
    }
}
