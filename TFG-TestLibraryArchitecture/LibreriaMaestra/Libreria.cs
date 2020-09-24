using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace LibreriaMaestra
{
    public class Libreria
    {
          [TestMethod,]
 
        public void AbrirPaginaPrincipal(IWebDriver wdriver)
        {
            // Abrimos la página web 
            wdriver.Navigate().GoToUrl("http://25.76.110.243:8010/");
            //Maximizamos la ventana
            wdriver.Manage().Window.Maximize();
        }

        public void CrearDepartamento(IWebDriver wdriver, string codigo, string nombre) {

            BuscarMenu(wdriver, "Department", "Save Department");
            wdriver.FindElement(By.Id("Code")).Click();
            wdriver.FindElement(By.Id("Code")).SendKeys(codigo);
            wdriver.FindElement(By.Id("Name")).Click();
            wdriver.FindElement(By.Id("Name")).SendKeys(nombre);
            wdriver.FindElement(By.CssSelector(".btn")).Click();
            NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("form > p")).Text, Is.EqualTo("Saved Successfully"));
        }
        public void BuscarMenu(IWebDriver wdriver, string opcion1, string opcion2)
        {
            wdriver.FindElement(By.LinkText(opcion1)).Click();
            wdriver.FindElement(By.LinkText(opcion2)).Click();
            
        }

    }
}
