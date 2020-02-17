using System;
using System.Collections.Generic;
using System.IO;
using ABM_Task1.Abstraction;
using ABM_Task1.Models;

namespace ABM_Task1.Service
{
    public class EdifactLocExtractorService: IEdifactLocExtractor
    {
        readonly string Loc_Segment_Code = "LOC";
        readonly string Element_Delimiter = "+";
        readonly string Line_End_Sign = "'";
        public LocSegmentsModel[] ParseLocSegments(FileStream stream)
        {
            var result = new List<LocSegmentsModel>();

            using (var reader = new StreamReader(stream))
            {
                string line;

                while (!String.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    CheckLine(line, result);
                }
            }

            return result.ToArray();
        }

        private void CheckLine(string line, List<LocSegmentsModel> segmentsList)
        {
            if (line.Contains(Loc_Segment_Code))
            {
                var splitted = line.Split(Element_Delimiter);

                if (splitted.Length == 3)
                {
                    var entry = new LocSegmentsModel()
                    {
                        FirstSegment = splitted[1],
                        SecondSegment = splitted[2].Replace(Line_End_Sign, String.Empty)
                    };

                    segmentsList.Add(entry);
                }

            }
        }
    }
}
