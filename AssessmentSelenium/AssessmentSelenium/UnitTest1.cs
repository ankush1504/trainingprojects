using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AssessmentSelenium
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver;
            driver = new ChromeDriver("C:\\Selenium Jars");
            string requestedurl = "https://www.google.com/";
            driver.Url = requestedurl;
            string SearchText = "Dxc Technology";
           
            driver.FindElement(By.Name("q")).SendKeys(SearchText);
            Thread.Sleep(4000);
            driver.FindElement(By.Name("btnK")).Click();
            string title = driver.Title;
            Console.WriteLine(title);
            string statistic= driver.FindElement(By.Id("resultStats")).Text;
            Console.WriteLine(statistic);
            Thread.Sleep(4000);
            driver.Close();
            if(title.Contains(SearchText))
            {
                Console.WriteLine("PASS");
            }
            else
            {
                Console.WriteLine("FAIL");
            }

        }
    }
}
