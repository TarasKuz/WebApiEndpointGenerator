namespace WebApiEndpointGenerator
{
	class Program
	{
		static async System.Threading.Tasks.Task Main(string[] args)
		{
			await Generator.GenerateCSharpCode(
				"https://SwaggerSpecificationURL.json",
				"MyClass",
				"MyNamespace"
				);
		}
	}
}
