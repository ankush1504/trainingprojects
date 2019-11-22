using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace AssessmentSelenium
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class UnitTest2
    {

        [TestMethod]
        public void TestMethod1()      
        {


            IWebDriver driver = new ChromeDriver("C:\\Selenium Jars");
            string requestedurl = "http://www.youcandealwithit.com/";
            driver.Url = requestedurl;
           IWebElement borrow= driver.FindElement(By.XPath("/html/body/div[1]/ul[2]/li[1]/a"));
            Actions act = new Actions(driver);
           
            string[] links = new string[] { "Calculators & Resources", "Calculators", "Budget Calculator" };
            act.MoveToElement(borrow).Build().Perform();
            driver.FindElement(By.LinkText(links[0])).Click();
            string title1 = driver.Title;
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText(links[1])).Click();
            string title2 = driver.Title;
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText(links[2])).Click();
            string title3 = driver.Title;
            string monthlypay = "33000";
            Thread.Sleep(3000);
            string[] titles = new string[] { title1, title2, title3 };
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.FindElement(By.Id ("food")).SendKeys("400");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("clothing")).SendKeys("3000");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("shelter")).SendKeys("2000");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("monthlyPay")).SendKeys(monthlypay);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("monthlyOther")).SendKeys("4000");
            Thread.Sleep(1000);
            string budget= driver.FindElement(By.Id("underOverBudget")).GetAttribute("value");
            Console.WriteLine("budget is:"+budget);
            for (int i = 0; i < 3; i++)
            {
                if(titles[i].Contains(links[i]))
                {
                    Console.WriteLine(links[i]+"link: PASS");
                }
                else
                {
                    Console.WriteLine(links[i] + "link: FAIL");
                }

            }
           string monthlyexpense=driver.FindElement(By.Id("totalMonthlyExpenses")).GetAttribute("value");
            string monthlyincome = driver.FindElement(By.Id("totalMonthlyIncome")).GetAttribute("value");
            Thread.Sleep(1000);

            if (Convert.ToDouble(monthlyexpense)<Convert.ToDouble(monthlyincome))
            {
                Console.WriteLine("you are warren buffet");
            }
            else
            {
                Console.WriteLine("you are vijay mallya");
            }



            driver.Close();



        }
    }
}
