using System;
namespace minefieldtests
{

    [Test]
    public void messingAround() {
        
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
