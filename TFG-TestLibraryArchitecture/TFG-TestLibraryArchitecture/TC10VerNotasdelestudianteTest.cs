using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using LibreriaMaestra;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;


namespace PruebaSelenium
{
    [TestClass]
    public class TC10VerNotasEst
    {
        [TestMethod,]
        public void TC10Principal()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                Libreria test = new Libreria();
                //Iniciar Página Principal
                test.AbrirPaginaPrincipal(wdriver);
                //Se ingresa al menu de estudiantes
                test.BuscarMenu(wdriver, "Student", "View Result");
               //Se visualizan los datos del estudiante
                wdriver.FindElement(By.Id("StudentId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("StudentId"));
                    dropdown.FindElement(By.XPath("//option[. = '22-2020-001']")).Click();
                }
                wdriver.FindElement(By.Id("StudentId")).Click();
                {
                    string value = wdriver.FindElement(By.Id("Name")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("Hugo Jimenez"));
                }
                {
                    string value = wdriver.FindElement(By.Id("Email")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("jim22@gmail.com"));
                }
                {
                    string value = wdriver.FindElement(By.Id("Department")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("Salud"));
                }
                {
                    string value = wdriver.FindElement(By.Id("Department")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("Salud"));
                }
                {
                    var element = wdriver.FindElement(By.Id("Name"));
                    Boolean isEditable = element.Enabled && element.GetAttribute("readonly") == null;
                    NUnit.Framework.Assert.False(isEditable);
                }
                {
                    var element = wdriver.FindElement(By.Id("Email"));
                    Boolean isEditable = element.Enabled && element.GetAttribute("readonly") == null;
                    NUnit.Framework.Assert.False(isEditable);
                }
                {
                    var element = wdriver.FindElement(By.Id("Department"));
                    Boolean isEditable = element.Enabled && element.GetAttribute("readonly") == null;
                    NUnit.Framework.Assert.False(isEditable);
                }
                //Se valida que la información sea correcta
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("#myData td:nth-child(1)")).Text, Is.EqualTo("1166995"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("#myData td:nth-child(2)")).Text, Is.EqualTo("Enfermeria"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("#myData td:nth-child(3)")).Text, Is.EqualTo("A+"));
                wdriver.Close();
            }
        }
    }
}