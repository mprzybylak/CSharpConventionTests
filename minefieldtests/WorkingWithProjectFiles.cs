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
        public void v() {
            var files = GetFiles("minefield")
                .Where(n => n.EndsWith("MainClass.cs"))
                .Select(n => File.Open(n, FileMode.Open))
                .ToList();
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
