using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabcorpAuto
{
    public class LabcorpTest : TestBase
    {
        [Test]
        public void LabcorpCareers()
        {
            HomePage().ClickCareersLink();
            CareersPage().SwitchToCareersWindow();
            CareersPage().EnterPositionName("QA Test Automation Developer");
            CareersPage().ClickSearchPosition();
            CareersPage().SelectPosition("Sr Reporting Analyst", "Tampa, Florida", "06/23/2021");
            CareersPage().AssertTitleName("Sr Reporting Analyst");
            CareersPage().AssertJobLocation("Tampa, Florida");
            CareersPage().AssertJobId("21-83044");
        }
    }
}
