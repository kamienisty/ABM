using System.IO;

using NUnit.Framework;

using ABM_Task2.Service;
using System.Linq;

namespace ABM_Task1_Unit_tests
{
    public class XMLReferenceReaderServiceTest
    {

        private string xml;

        [SetUp]
        public void SetUp()
        {
            xml = File.ReadAllText("XMLFile.txt");
        }

        [Test]
        public void Test1()
        {
            //arrange
            //act
            var result = new XMLReferenceReaderService().ReadReferences(xml);
            
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(result.Any( x => x == "586133622"));
            Assert.IsTrue(result.Any(x => x == "1"));
            Assert.IsTrue(result.Any(x => x == "71Q0019681"));
        }
    }
}
