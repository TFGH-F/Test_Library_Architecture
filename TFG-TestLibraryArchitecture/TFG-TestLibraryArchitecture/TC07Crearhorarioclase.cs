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
    public class TC07CrearHorararioClase
    {
        [TestMethod,]
        public void TC07Principal()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                Libreria test = new Libreria();
                //Iniciar Página Principal
                test.AbrirPaginaPrincipal(wdriver);
                // Abrimos la página web de inicio se sesión
                //Se ingresa al menu de asociar clase
                test.BuscarMenu(wdriver, "Class Room Allocation", "Allocate Classroom");
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                //Se valida los Campos de texto Vacíos
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("DepartmentId-error")).Text, Is.EqualTo("Please select department!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("CourseId-error")).Text, Is.EqualTo("Please Select Course!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("RoomId-error")).Text, Is.EqualTo("Please Select room!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("DayId-error")).Text, Is.EqualTo("Please Select day!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("StartTime-error")).Text, Is.EqualTo("Select Start time!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Endtime-error")).Text, Is.EqualTo("Please select End time!"));
                wdriver.FindElement(By.CssSelector(".body-content")).Click();
                //Se registra los datos
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("DepartmentId"));
                    dropdown.FindElement(By.XPath("//option[. = 'Artesanía']")).Click();
                }
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                wdriver.FindElement(By.Id("CourseId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("CourseId"));
                    dropdown.FindElement(By.XPath("//option[. = '453214']")).Click();
                }
                wdriver.FindElement(By.Id("CourseId")).Click();
                wdriver.FindElement(By.Id("RoomId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("RoomId"));
                    dropdown.FindElement(By.XPath("//option[. = 'Room No:101']")).Click();
                }
                wdriver.FindElement(By.Id("RoomId")).Click();
                wdriver.FindElement(By.Id("DayId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("DayId"));
                    dropdown.FindElement(By.XPath("//option[. = 'Monday']")).Click();
                }
                wdriver.FindElement(By.Id("DayId")).Click();
                wdriver.FindElement(By.CssSelector(".form-group:nth-child(5) > .control-label")).Click();
                wdriver.FindElement(By.CssSelector(".dwwl1 > .dwwbm > span")).Click();
                wdriver.FindElement(By.CssSelector(".dwwl1 > .dwwbm > span")).Click();
                {
                    var element = wdriver.FindElement(By.CssSelector(".dwwl1 > .dwwbm > span"));
                    Actions builder = new Actions(wdriver);
                    builder.DoubleClick(element).Perform();
                }
                wdriver.FindElement(By.CssSelector(".dwwl1 > .dwwbm > span")).Click();
                wdriver.FindElement(By.CssSelector(".dwwl2 > .dwwbm > span")).Click();
                wdriver.FindElement(By.LinkText("Set")).Click();
                wdriver.FindElement(By.CssSelector(".form-group:nth-child(6) > .control-label")).Click();
                wdriver.FindElement(By.CssSelector(".dwwl0 > .dwwbp > span")).Click();
                wdriver.FindElement(By.CssSelector(".dwwl0 > .dwwbp > span")).Click();
                {
                    var element = wdriver.FindElement(By.CssSelector(".dwwl0 > .dwwbp > span"));
                    Actions builder = new Actions(wdriver);
                    builder.DoubleClick(element).Perform();
                }
                wdriver.FindElement(By.CssSelector(".dwwl1 > .dwwbp > span")).Click();
                wdriver.FindElement(By.CssSelector(".dwwl1 > .dwwbp > span")).Click();
                {
                    var element = wdriver.FindElement(By.CssSelector(".dwwl1 > .dwwbp > span"));
                    Actions builder = new Actions(wdriver);
                    builder.DoubleClick(element).Perform();
                }
                //Se valida que la clase fue registrada correctamente
                wdriver.FindElement(By.LinkText("Set")).Click();
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("p:nth-child(5)")).Text, Is.EqualTo("Saved Successfully !"));
                //Se valida que la clase esta registrada
                test.BuscarMenu(wdriver, "Class Room Allocation", "View Class Schedule");
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("DepartmentId"));
                    dropdown.FindElement(By.XPath("//option[. = 'Artesanía']")).Click();
                }
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("tbody:nth-child(2) td:nth-child(1)")).Text, Is.EqualTo("453214"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("tbody:nth-child(2) td:nth-child(2)")).Text, Is.EqualTo("Moldaje"));
                wdriver.Close();
            }
        }
    }
}