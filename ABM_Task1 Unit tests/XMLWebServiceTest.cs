using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using ABM_Task3.Service;

namespace ABM_Task1_Unit_tests
{
    public class XMLWebServiceTest
    {   
        [Test]
        public void Test1_CorrectXML()
        {
            //arrange
            string xml = "<InputDocument>	<DeclarationList>		<Declaration Command=\"DEFAULT\" Version=\"5.13\">			<DeclarationHeader>				<Jurisdiction>IE</Jurisdiction>				<CWProcedure>IMPORT</CWProcedure>							<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>				<DocumentRef>71Q0019681</DocumentRef>				<SiteID>DUB</SiteID>				<AccountCode>G0779837</AccountCode>			</DeclarationHeader>		</Declaration>	</DeclarationList></InputDocument>";

            //act
            var result = new XMLWebService().ParseXML(xml);

            //assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test2_IncorrectCOmmandArgument()
        {
            //arrange
            string xml = "<InputDocument>	<DeclarationList>		<Declaration Command=\"NON - DEFAULT\" Version=\"5.13\">			<DeclarationHeader>				<Jurisdiction>IE</Jurisdiction>				<CWProcedure>IMPORT</CWProcedure>							<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>				<DocumentRef>71Q0019681</DocumentRef>				<SiteID>DUB</SiteID>				<AccountCode>G0779837</AccountCode>			</DeclarationHeader>		</Declaration>	</DeclarationList></InputDocument>";

            //act
            var result = new XMLWebService().ParseXML(xml);

            //assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Test2_IncorrectCOmmandArgument2()
        {
            //arrange
            string xml = "<InputDocument>	<DeclarationList>		<Declaration Command=\"DEFAULT\" Version=\"5.13\">			<DeclarationHeader>				<Jurisdiction>IE</Jurisdiction>				<CWProcedure>IMPORT</CWProcedure>							<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>				<DocumentRef>71Q0019681</DocumentRef>				<SiteID>AAA</SiteID>				<AccountCode>G0779837</AccountCode>			</DeclarationHeader>		</Declaration>	</DeclarationList></InputDocument>";

            //act
            var result = new XMLWebService().ParseXML(xml);

            //assert
            Assert.AreEqual(-2, result);

        }
    }
}
