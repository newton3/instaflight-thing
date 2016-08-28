using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebActivatorEx;
using Instaflight_thing;
using Swashbuckle.Application;
using Swashbuckle.Swagger;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Instaflight_thing
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "RealROI.CIS.Websites.Api");
                c.UseFullTypeNameInSchemaIds();
                c.DescribeAllEnumsAsStrings();
                c.OperationFilter<IncludeParameterNamesInOperationIdFilter>();
            })
              .EnableSwaggerUi(c =>
              {
              });
        }
    }

    internal class IncludeParameterNamesInOperationIdFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters != null)
            {
                // Select the capitalized parameter names
                var parameters = operation.parameters.Select(
                                                             p => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(p.name));

                // Set the operation id to match the format "OperationByParam1AndParam2"
                operation.operationId = string.Format(
                                                      "{0}By{1}",
                                                      operation.operationId,
                                                      string.Join("And", parameters));
            }
        }
    }
}
