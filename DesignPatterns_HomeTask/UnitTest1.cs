using DesignPatterns_HomeTask_PageObject.PageObjects;

namespace DesignPatterns_HomeTask_PageObject
{
    public class UnitTests1
    {
        //Base _base = new Base();
        HomePage homePage = new HomePage();

        [Test]
        public void Test1()
        {
            WebDriver.GetInstance().Navigate().GoToUrl("https://demo.guru99.com/test/guru99home/");
            Assert.That(WebDriver.GetInstance().Title, Is.EqualTo("Demo Guru99 Page"));
        }

        [Test]
        public void Test2()
        {
            homePage.SubmitEmail();
        }

        [Test]
        public void Test3()
        {
            homePage.SelectProject();
            Assert.That(WebDriver.GetInstance().Title, Is.EqualTo("Insurance Broker System - Login"));
        }

        [Test]
        public void Test4()
        {
            homePage.SelectCourse();
            Assert.That(WebDriver.GetInstance().Title, Is.EqualTo("Selenium Tutorial"));
        }

    }
}