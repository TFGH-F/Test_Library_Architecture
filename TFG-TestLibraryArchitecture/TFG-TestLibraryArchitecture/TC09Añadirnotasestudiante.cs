using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using LibreriaMaestra;
using NUnit;
using NUnit.Framework;

namespace PruebaSelenium
{
    [TestClass]
    public class TC09AñadirNotas
    {
        [TestMethod,]
        public void TC09Principal()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                Libreria test = new Libreria();
                //Iniciar Página Principal
                test.AbrirPaginaPrincipal(wdriver);
                // Abrimos la página web de inicio se sesión
                //Se Ingresa al menu de estudiante
                test.BuscarMenu(wdriver, "Student", "Save Student Result");
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("StudentId-error")).Text, Is.EqualTo("Please select the student reg no"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("CourseId-error")).Text, Is.EqualTo("Please select a course"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Grade-error")).Text, Is.EqualTo("Please select grade"));
                wdriver.FindElement(By.Id("StudentId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("StudentId"));
                    dropdown.FindElement(By.XPath("//option[. = '16-1997-001']")).Click();
                }
                wdriver.FindElement(By.Id("StudentId")).Click();
                wdriver.FindElement(By.Id("CourseId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("CourseId"));
                    dropdown.FindElement(By.XPath("//option[. = 'Natación']")).Click();
                }
                wdriver.FindElement(By.Id("CourseId")).Click();
                wdriver.FindElement(By.Id("Grade")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("Grade"));
                    dropdown.FindElement(By.XPath("//option[. = 'A+']")).Click();
                }
                wdriver.FindElement(By.Id("Grade")).Click();
                {
                    string value = wdriver.FindElement(By.Id("Name")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("Martha Rodriguez"));
                }
                {
                    string value = wdriver.FindElement(By.Id("Email")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("maro@gmail.com"));
                }
                {
                    string value = wdriver.FindElement(By.Id("Department")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("Deporte"));
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
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("#saveStudentResult > p")).Text, Is.EqualTo("Saved sucessfull!"));
                wdriver.Close();
            }
        }
    }
}