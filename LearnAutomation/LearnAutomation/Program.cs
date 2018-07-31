using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LearnAutomation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            String url = "http://www.google.com";
            String textToSearch = "Grawe Carat";
            Executor executor = new Executor("Chrome");
            executor.NavigateTo(url);
            executor.InputText(textToSearch, "q");
            IWebElement btn = executor.FindElementByName("btnK");
            executor.ClickOnElement(btn);
            //executor.CountResults(textToSearch);
            executor.FindElementByXPath(".//*[contains(text(),'" + textToSearch + "')]");
            Thread.Sleep(5000); //delay of 5000 milliseconds or 1 second.
            executor.Close();
        }
    }
}
