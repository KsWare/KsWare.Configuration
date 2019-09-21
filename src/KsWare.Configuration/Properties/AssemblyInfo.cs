using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;


[assembly: AssemblyTitle("KsWare.Configuration")]
[assembly: AssemblyDescription("KsWare.Configuration")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("KsWare")]
[assembly: AssemblyProduct("KsWare.Configuration")]
[assembly: AssemblyCopyright("Copyright © 2019 by KsWare. All rights reserved.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]


[assembly: ComVisible(false)]

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]
//[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]

[assembly: AssemblyVersion("0.0.0.0")]
[assembly: AssemblyFileVersion("0.0.0.0")]
[assembly: AssemblyInformationalVersion("0.0.0.0")]

[assembly: XmlnsDefinition(KsWare.Configuration.AssemblyInfo.XmlNamespace, "KsWare.Configuration")]
[assembly: XmlnsPrefix(KsWare.Configuration.AssemblyInfo.XmlNamespace, "ksv")]

//[assembly: InternalsVisibleTo("KsWare.Configuration.Tests, PublicKey=$PublicKey$")]

// namespace must equal to assembly name
// ReSharper disable once CheckNamespace
namespace KsWare.Configuration
{
	public static class AssemblyInfo
	{

		public static Assembly Assembly => Assembly.GetExecutingAssembly();

		public const string XmlNamespace = "http://ksware.de/Presentation/ViewFramework";

		public const string RootNamespace = "KsWare.Configuration";

	}
}