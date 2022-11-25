using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_HomeTask_PageObject.PageObjects
{
    internal class HomePage
    {
        protected Base baseClass;

        public HomePage(Base _baseClass)
        {
            this.baseClass = _baseClass;
        }

        public static IWebElement Email => WebDriver.GetInstance().FindElement(By.XPath("//*[@id='philadelphia-field-email']"));
        public static IWebElement SubmitBtn => WebDriver.GetInstance().FindElement(By.XPath("//*[@id='philadelphia-field-submit']"));
        public static IWebElement InsProjectTab => WebDriver.GetInstance().FindElement(By.XPath("//a[text()='Insurance Project']"));
        public static IWebElement Category => WebDriver.GetInstance().FindElement(By.XPath("//li[@class='item118 parent']"));
        public static IWebElement Course => WebDriver.GetInstance().FindElement(By.XPath("//li[@class='item121']"));


        public void SubmitEmail()
        {
            baseClass.openBrowser();
            Email.Clear();
            Email.SendKeys("abc123@gmail.com");

            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

            SubmitBtn.Click(); 
            
            IAlert AlertBox = WebDriver.GetInstance().SwitchTo().Alert();
            string AlertText = AlertBox.Text;
            Console.WriteLine(AlertText);
            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            AlertBox.Accept();
            baseClass.closeBrowser();
        }

        public void SelectProject()
        {
            baseClass.openBrowser();
            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            InsProjectTab.Click();
            WebDriver.GetInstance().Navigate().Back();
            baseClass.closeBrowser();

        }

        public void SelectCourse()
        {
            baseClass.openBrowser();
            WebDriver.GetInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            Actions action = new Actions(WebDriver.GetInstance());
            action.MoveToElement(Category).Perform();
            action.MoveToElement(Course).Click().Perform();
            baseClass.closeBrowser();
        }
    }
}
