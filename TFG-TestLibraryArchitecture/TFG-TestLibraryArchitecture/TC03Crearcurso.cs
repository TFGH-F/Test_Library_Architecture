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
    public class TC03CrearCurso
    {
        [TestMethod,]
        public void TC03Principal()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                Libreria test = new Libreria();
                //Iniciar Página Principal
                test.AbrirPaginaPrincipal(wdriver);
                //Crear Departamento            
                test.CrearDepartamento(wdriver, "31", "Química");
                test.BuscarMenu(wdriver, "Course", "Save Course");
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                //Validación de campos vacíos
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Code-error")).Text, Is.EqualTo("Please enter a valid Course Code!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Name-error")).Text, Is.EqualTo("Please enter the valid Course Name!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Credit-error")).Text, Is.EqualTo("Credit is required!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("Description-error")).Text, Is.EqualTo("Write something about course!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("DepartmentId-error")).Text, Is.EqualTo("Please select related department!"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.Id("SemesterId-error")).Text, Is.EqualTo("Please select related semester!"));
                //Se ingresan los campos del curso
                wdriver.FindElement(By.Id("Code")).Click();
                wdriver.FindElement(By.Id("Code")).SendKeys("564378");
                wdriver.FindElement(By.Id("Name")).Click();
                wdriver.FindElement(By.Id("Name")).SendKeys("Quimica avanzado");
                wdriver.FindElement(By.Id("Credit")).Click();
                wdriver.FindElement(By.Id("Credit")).SendKeys("4");
                wdriver.FindElement(By.Id("Description")).Click();
                wdriver.FindElement(By.Id("Description")).SendKeys("Este curso pertenece a quimica");
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("DepartmentId"));
                    dropdown.FindElement(By.XPath("//option[. = 'Química']")).Click();
                }
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                wdriver.FindElement(By.Id("SemesterId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("SemesterId"));
                    dropdown.FindElement(By.XPath("//option[. = '1st']")).Click();
                }
                wdriver.FindElement(By.Id("SemesterId")).Click();
                wdriver.FindElement(By.CssSelector(".btn")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("p:nth-child(4)")).Text, Is.EqualTo("Saved Successfully"));
                //Se valida que este el curso fue creado
                test.BuscarMenu(wdriver, "Course", "View Course Statics");
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                {
                    var dropdown = wdriver.FindElement(By.Id("DepartmentId"));
                    dropdown.FindElement(By.XPath("//option[. = 'Química']")).Click();
                }
                wdriver.FindElement(By.Id("DepartmentId")).Click();
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("td:nth-child(1)")).Text, Is.EqualTo("564378"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("td:nth-child(2)")).Text, Is.EqualTo("Quimica avanzado"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("td:nth-child(3)")).Text, Is.EqualTo("1st"));
                NUnit.Framework.Assert.That(wdriver.FindElement(By.CssSelector("td:nth-child(4)")).Text, Is.EqualTo("Not Assigned yet"));
                wdriver.Close();
            

            }
        }
    }
}