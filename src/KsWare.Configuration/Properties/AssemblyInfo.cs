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
[assembly: AssemblyProduct("KsWare Framework")]
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

[assembly: InternalsVisibleTo("KsWare.Configuration.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100918270208D0BCD8E0A7738B802EAAF86C03C0530B25CD44893CD4DCD1AB942BBC2516AA261104CD8A037E3B4247FDF325675CE1E2EAF81BCA5997651E638E03B24460A050ED2A2B1930F8A1134BD1140615922DC5907B92839D1B485A6C65D06CF0AA239C00FDA5FC7E23644FD154DBAE972C416CF7FB6BA0CA965412B88949F")]

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