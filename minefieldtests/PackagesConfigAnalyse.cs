using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using System.Linq;
using System.Text.RegularExpressions;

namespace minefieldtests
{
    public class PackagesConfigAnalyse
    {

        [Test]
        public void AllowedVersionConstraintsIsNotViolated() {

            var count = GetFiles("minefieldtests")
                .Where(n => n.EndsWith("packages.config"))
                .Select(n => File.ReadAllText(n))
                .Where(f => Regex.IsMatch(f, "id=\"NUnit\".*allowedVersions=\"\\[2,3\\)\""))
                .Count();

            // this time we would like to check that there is one occurence
            Assert.AreEqual(1, count);
        }

        private IEnumerable<string> GetFiles(string path)
		{
			var d = new DirectoryInfo(Directory.GetCurrentDirectory());
			while (d.EnumerateFiles("*.sln").Any() == false)
			{
				d = d.Parent;
			}
			var fullPath = Path.Combine(d.FullName, path);

			return Directory.EnumerateFiles(fullPath);
		}
    }
}
