using System.IO;
using System.Net;
using System.Threading.Tasks;
using NSwag;
using NSwag.CodeGeneration.CSharp;

namespace WebApiEndpointGenerator
{
	static class Generator
	{
		public static async Task GenerateCSharpCode(string url, string className, string namespaceName)
		{
			using WebClient wclient = new WebClient();

			var document = await OpenApiDocument.FromJsonAsync(wclient.DownloadString(url));

			var settings = new CSharpClientGeneratorSettings
			{
				ClassName = className,
				CSharpGeneratorSettings =
				{
						Namespace = namespaceName
				}
			};

			var generator = new CSharpClientGenerator(document, settings);
			var code = generator.GenerateFile();

			File.WriteAllText(className + ".cs", code);
		}
	}
}