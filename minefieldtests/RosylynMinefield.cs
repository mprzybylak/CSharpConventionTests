using System;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace minefieldtests
{
    public class RosylynMinefield
    {
        [Test]
        public void MethodShouldHaveOnlyOneExitPoint()
        {
            // get file name
            string fileName = GetFiles("minefield/ECommerce/Pricing").Where(n => n.EndsWith("NormalPricingStrategy.cs")).First();

            // read syntax tree
            SyntaxTree tree = CSharpSyntaxTree.ParseText(File.ReadAllText(fileName));

            // compile assembly
            var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
            var compilation = CSharpCompilation.Create("TestAssembly", new[] { tree }, new[] { mscorlib });

            // build semantic model
            SemanticModel model = compilation.GetSemanticModel(tree, true);

            // find all methods where there are more than 1 return statement
            tree.GetRoot()
                .DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .Where(mds => model.AnalyzeControlFlow(mds.Body).ReturnStatements.Count() > 1)
                .ToList()
                .ForEach(m => Assert.Fail(string.Format("method {0} in {1} has more than 1 exit point", m.Identifier, fileName)));
        }

        [Test]
        public void SyntaxTree() {

            string fileName = GetFiles("minefield/ECommerce/Pricing").Where(n => n.EndsWith("NormalPricingStrategy.cs")).First();

            SyntaxTree tree = CSharpSyntaxTree.ParseText(File.ReadAllText(fileName));
            SyntaxNode root = tree.GetRoot();

            var classes = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
            var className = classes.First().Identifier;
            var classModifiers = classes.First().Modifiers;

            var interfaces = root.DescendantNodes().OfType<InterfaceDeclarationSyntax>();
            var interfaceName = interfaces.First().Identifier;
            var interfaceName = interfaces.First().Modifiers;


            var fields = root.DescendantNodes().OfType<FieldDeclarationSyntax>();
            var properties = root.DescendantNodes().OfType<PropertyDeclarationSyntax>();
			var methods = root.DescendantNodes().OfType<MethodDeclarationSyntax>();
            var ctors = root.DescendantNodes().OfType<ConstructorConstraintSyntax>();
            var namespaces = root.DescendantNodes().OfType<NamespaceDeclarationSyntax>();

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
