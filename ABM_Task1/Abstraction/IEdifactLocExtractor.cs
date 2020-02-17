using ABM_Task1.Models;
using System.IO;

namespace ABM_Task1.Abstraction
{
    public interface IEdifactLocExtractor
    {
        LocSegmentsModel[] ParseLocSegments(FileStream stream);
    }
}
