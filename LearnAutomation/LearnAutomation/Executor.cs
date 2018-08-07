using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace LearnAutomation
{
    public class Executor
    {
        public IWebDriver driver;

        public Executor()
        {
        }

        public Executor(String browser)
        {

            switch (browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    Console.WriteLine(browser + " browser instance started.");
                    break;
                case "firefox":
                    Console.WriteLine("Not implemented for " + browser);
                    break;
                case "ie":
                    Console.WriteLine("Not implemented for " + browser);
                    break;
                default:
                    Console.WriteLine("Not implemented for " + browser);
                    break;
            }

        }

        public void NavigateTo(String url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void InputText(String textValue, String findInputBy, String elementType)
        {
            switch(elementType.ToLower())
            {
                case "name":
                    driver.FindElement(By.Name(findInputBy)).SendKeys(textValue);
                    break;
                case "id":
                    driver.FindElement(By.Id(findInputBy)).SendKeys(textValue);
                    break;
                case "xpath":
                    driver.FindElement(By.XPath(findInputBy)).SendKeys(textValue);
                    break;
                default:
                    Console.WriteLine("Input Not implemented for "+elementType+" elemnt type.");
                    break;
            }
     }

        public void ClickOnElement(String clickElementBy, String elementType)
        {

            switch (elementType.ToLower())
            {
                case "name":
                    driver.FindElement(By.Name(clickElementBy)).Click();
                    break;
                case "id":
                    driver.FindElement(By.Id(clickElementBy)).Click();
                    break;
                case "xpath":
                    driver.FindElement(By.XPath(clickElementBy)).Click();
                    break;
                default:
                    Console.WriteLine("Click Not implemented for " + elementType + " elemnt type.");
                    break;
            }        }

        public void FindElementsByXPath(String xPath)
        {
            ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.XPath(xPath));
            int index = 1;

            foreach (IWebElement item in webElements)
            {
                Console.WriteLine(index + ": "+" : "+item.GetAttribute("name")+" :: "+item.Text);
                index++;
            }

            //return webElements;
        }

        public IWebElement FindElementByName(String name)
        {
            IWebElement webElement = driver.FindElement(By.Name(name));
            return webElement;
        }

        public void CountResults(String textValue)
        {
            ReadOnlyCollection<IWebElement> resultsList = driver.FindElements(By.PartialLinkText(textValue));
             int index = 1;              foreach (IWebElement item in resultsList)             {                 Console.WriteLine(index + ": " + item.Text);                 index++;             }
            Console.WriteLine($"On page {resultsList.Count} search mathing keyword results.");
        }

        public void Close()
        {
            driver.Close();
        }
    }

}