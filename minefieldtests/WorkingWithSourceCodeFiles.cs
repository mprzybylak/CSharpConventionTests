using System;
using System.IO;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace minefieldtests
{
    public class WorkingWithProjectFiles
    {
        [Test]
        public void ServiceLayerShouldNotHaveDependenciesToView() {
            var count = GetFiles("minefield/ECommerce/App/Domain")
                .Select(n => File.ReadAllText(n))
                .Where(t => t.Contains("using minefield.ECommerce.App.View"))
                .Count();

            Assert.AreEqual(0, count);
        }


        public List<string> GetFiles(string path)
        {
            var d = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (d.EnumerateFiles("*.sln").Any() == false)
            {
                d = d.Parent;
            }
            var fullPath = Path.Combine(d.FullName, path);

            return Directory.EnumerateFiles(fullPath)
                            .ToList();

        }
    }
}
