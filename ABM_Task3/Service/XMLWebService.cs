using System;
using System.Linq;
using System.Xml.Linq;

namespace ABM_Task3.Service
{
    public class XMLWebService
    {
        public int ParseXML(string xml)
        {
            try
            {
                XDocument document = XDocument.Parse(xml);

                if (!document.Descendants("Declaration").Attributes().Any(x => x.Name == "Command" && x.Value == "DEFAULT"))
                {
                    return -1;
                }

                if(!document.Descendants("SiteID").Any(x => x.Value == "DUB"))
                {
                    return -2;
                }

                return 0;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
