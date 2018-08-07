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
            String browserName = "chrome";

            // initailize WebDriver  - create object instance
            Executor executor = new Executor(browserName);


            executor.NavigateTo(url);
            executor.InputText(textToSearch, "q","name");


            executor.ClickOnElement("btnK","name");
            executor.CountResults(textToSearch.ToLower());
            executor.FindElementsByXPath(".//*[contains(text(),'" + textToSearch.ToLower() + "')]");
            Thread.Sleep(5000); //delay of 5000 milliseconds or 1 second.

            executor.Close();
        }
    }
}
