using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using ABM_Task1.Models;

namespace ABM_Task1.Service
{
    public class EdifactLocExtractor
    {
        public LocSegments[] PareseLocSegments(FileStream stream)
        {
            var result = new List<LocSegments>();

            using (var reader = new StreamReader(stream))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("LOC"))
                    {
                        var splitted = line.Split('+');
                        var entry = new LocSegments()
                        {
                            FirstSegment = splitted[1],
                            SecondSegment = splitted[2].Replace("'", String.Empty)
                        };

                        result.Add(entry);
                    }
                }
            }

            return result.ToArray();
        }
    }
}
