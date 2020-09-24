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
    public class TC05AsigCursoProfesor
    {
        [TestMethod,]
        public void TC05Principal()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                Libreria test = new Libreria();
                //Iniciar Página Principal
                test.AbrirPaginaPrincipal(wdriver);
               //Se ingresa al menu de asignación de profesor
                test.BuscarMenu(wdriver, "Teacher", "Assign Course To Teacher");
                //Se asigna al profesor a un curso
                wdriver.FindElement(By.Id("submitButton")).Click();
                {
                    var element = wdriver.FindElement(By.Id("submitButton"));
                    Actions builder = new Actions(wdriver);
                    builder.MoveToElement(element).Perform();
                }
                {
                    var element = wdriver.FindElement(By.TagName("body"));
                    Actions builder = new Actions(wdriver);
                    builder.MoveToElement(element, 0, 0).Perform();
                }
                //Se valida los campos de texto vacíos
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("DepartmentId-error")).Text, Is.EqualTo("Please select department!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("TeacherId-error")).Text, Is.EqualTo("Please select the teacher Name!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("CourseId-error")).Text, Is.EqualTo("Please select semester!"));
                //Se llenan los datos 
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("DepartmentId"));
                    dropdown.FindElement(By.XPath("//option[. = 'Patologia']")).Click();
                }
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                wdriver.FindElement(By.Id("TeacherId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("TeacherId"));
                    dropdown.FindElement(By.XPath("//option[. = 'Karla Guevara']")).Click();
                }
                wdriver.FindElement(By.Id("TeacherId")).Click();
                {
                    string value = wdriver.FindElement(By.Id("CreditTobeTaken")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("4"));
                }
                {
                    string value = wdriver.FindElement(By.Id("CreditTaken")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("4"));
                }
                wdriver.FindElement(By.Id("CourseId")).Click();
                {
                    var element = wdriver.FindElement(By.Id("CreditTobeTaken"));
                    Boolean isEditable = element.Enabled && element.GetAttribute("readonly") == null;
                    NUnit.Framework.Assert.False(isEditable);
                }
                {
                    var element = wdriver.FindElement(By.Id("CreditTaken"));
                    Boolean isEditable = element.Enabled && element.GetAttribute("readonly") == null;
                    NUnit.Framework.Assert.False(isEditable);
                }
                wdriver.FindElement(By.Id("CourseId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("CourseId"));
                    dropdown.FindElement(By.XPath("//option[. = '567890']")).Click();
                }
                wdriver.FindElement(By.Id("CourseId")).Click();
                {
                    string value = wdriver.FindElement(By.Id("Name")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("Patologia 1"));
                }
                {
                    var element = wdriver.FindElement(By.Id("Name"));
                    Boolean isEditable = element.Enabled && element.GetAttribute("readonly") == null;
                    NUnit.Framework.Assert.False(isEditable);
                }
                {
                    string value = wdriver.FindElement(By.Id("Credit")).GetAttribute("value");
                    NUnit.Framework.Assert.That(value, Is.EqualTo("4"));
                }
                {
                    var element = wdriver.FindElement(By.Id("Credit"));
                    Boolean isEditable = element.Enabled && element.GetAttribute("readonly") == null;
                    NUnit.Framework.Assert.False(isEditable);
                }
                //Se valida que la asignación fue correcta
                wdriver.FindElement(By.Id("submitButton")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("p:nth-child(4)")).Text, Is.EqualTo("Assigned successfully"));
                wdriver.Close();

            }
        }
    }
}