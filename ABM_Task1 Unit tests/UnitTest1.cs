using NUnit.Framework;

using ABM_Task1.Service;
using System.IO;

namespace ABM_Task1_Unit_tests
{
    public class Tests
    {
        private readonly string filename = "TestFile.txt";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            using(var fs = File.OpenRead(filename))
            {
                var w = new EdifactLocExtractor().PareseLocSegments(fs);

                var i = 1;
            } 

            Assert.Pass();
        }
    }
}