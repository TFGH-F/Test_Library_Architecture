using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using LibreriaMaestra;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace PruebaSelenium
{
    [TestClass]
    public class TC08Registrarestudiante
    {
        [TestMethod,]
        public void TC08Principal()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                Libreria test = new Libreria();
                //Iniciar Página Principal
                test.AbrirPaginaPrincipal(wdriver);
                //Se ingresa al menu de estudiante en Enroll Student In A Course
                test.BuscarMenu(wdriver, "Student", "Enroll Student In A Course");
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                //Se valida los campos de texto Vacíos
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("StudentId-error")).Text, Is.EqualTo("Please select student Registration No"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("CourseId-error")).Text, Is.EqualTo("Please select Course"));
                wdriver.FindElement(By.Id("StudentId")).Click();
                //Se ingresan los datos del Estudiante
                {
                    var dropdown = wdriver.FindElement(By.Id("StudentId"));
                    dropdown.FindElement(By.XPath("//option[. = '19-2020-001']")).Click();
                }
                wdriver.FindElement(By.Id("StudentId")).Click();
                {
                    string value = wdriver.FindElement(By.Id("Name")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("Fabiana Salas"));
                }
                {
                    string value = wdriver.FindElement(By.Id("Email")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("fab20@gmail.com"));
                }
                {
                    string value = wdriver.FindElement(By.Id("DepartmentId")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("Artes Plasticas"));
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
                    var element = wdriver.FindElement(By.Id("DepartmentId"));
                    Boolean isEditable = element.Enabled && element.GetAttribute("readonly") == null;
                    NUnit.Framework.Assert.False(isEditable);
                }
                //Se valida que los datos se registraron correctamente
                wdriver.FindElement(By.Id("CourseId")).Click();
                wdriver.FindElement(By.Id("CourseId")).Click();
                wdriver.FindElement(By.Id("EnrollDate")).Click();
                wdriver.FindElement(By.LinkText("8")).Click();
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("p:nth-child(4)")).Text, Is.EqualTo("Saved Successfully!"));
                wdriver.Close();
            }
        }
    }
}