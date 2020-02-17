using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ABM_Task2.Service
{
    public class XMLReferenceReaderService
    {
        private string[] _refCodes = new string[3]
        {
            "MWB",
            "TRV",
            "CAR"
        };


        public List<String> ReadReferences(string xml)
        {
            try
            {
                XDocument document = XDocument.Parse(xml);

                return document
                    .Descendants("Reference")
                    .Where(
                        x => x.Attributes()
                            .Any(
                                y => y.Name == "RefCode"
                                && _refCodes.Contains(y.Value)))
                    .Select(x => x.Value)
                    .ToList();

            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
