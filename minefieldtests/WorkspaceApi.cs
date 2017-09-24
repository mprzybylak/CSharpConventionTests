using System;
using Microsoft.CodeAnalysis.MSBuild;

namespace minefieldtests
{

    [Test]
    public void messingAround() {

        // open solution
        MSBuildWorkspace w;

    }

	private string GetSolution()
	{
		var d = new DirectoryInfo(Directory.GetCurrentDirectory());
		while (d.EnumerateFiles("*.sln").Any() == false)
		{
			d = d.Parent;
		}
		return d.FullName;
	}
}
