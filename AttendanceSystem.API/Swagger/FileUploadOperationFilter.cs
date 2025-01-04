using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace AttendanceSystem.API.Swagger
{
    /// <summary>
    /// This class customizes Swagger to support file uploads.
    /// </summary>
    public class FileUploadOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Check if the endpoint contains parameters of type IFormFile
            var fileParams = context.MethodInfo.GetParameters()
                .Where(p => p.ParameterType == typeof(IFormFile));

            if (fileParams.Any())
            {
                operation.RequestBody = new OpenApiRequestBody
                {
                    Content =
                    {
                        ["multipart/form-data"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Type = "object",
                                Properties =
                                {
                                    ["userId"] = new OpenApiSchema { Type = "integer" }, // Add the userId input
                                    ["uploadedFile"] = new OpenApiSchema
                                    {
                                        Type = "string",
                                        Format = "binary" // Mark uploadedFile as binary for file upload
                                    }
                                },
                                Required = new HashSet<string> { "userId", "uploadedFile" }
                            }
                        }
                    }
                };
            }
        }
    }
}