using System.Collections.Generic;
using System.IO;

using NUnit.Framework;

using ABM_Task1.Service;
using ABM_Task1.Models;


namespace ABM_Task1_Unit_tests
{
    public class EdifactLocExtractorServiceTest
    {
        private readonly string _filledFilename = "TestFile.txt";
        private readonly string _emptyFileName = "EmptyFile.txt";
        private readonly string _badFileName = "BadFile.txt";

        [Test]
        public void Test1_TestFileWithRecords_Should_ReturnAllElements()
        {
            //arrange
            LocSegmentsModel[] result;

            //act
            using (var fs = File.OpenRead(_filledFilename))
            {
                result = new EdifactLocExtractorService().ParseLocSegments(fs);
            }

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Length);
            Assert.AreEqual("17", result[0].FirstSegment);
            Assert.AreEqual("IT044100", result[0].SecondSegment);
        }

        [Test]
        public void Test2_EmptyFile_Shoudl_ReturnEmptyArray()
        {
            //arrange
            LocSegmentsModel[] result;

            //act
            using (var fs = File.OpenRead(_emptyFileName))
            {
                result = new EdifactLocExtractorService().ParseLocSegments(fs);
            }

            //assert
            Assert.AreEqual(0, result.Length);
        }

        [Test]
        public void Test2_BadFile_Shoudl_ReturnOnlyCorrectSegments()
        {
            //arrange
            LocSegmentsModel[] result;

            //act
            using (var fs = File.OpenRead(_badFileName))
            {
                result = new EdifactLocExtractorService().ParseLocSegments(fs);
            }

            //assert
            Assert.AreEqual(4, result.Length);
        }

    }
}