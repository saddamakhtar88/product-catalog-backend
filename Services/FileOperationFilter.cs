using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;  
using Swashbuckle.AspNetCore.SwaggerGen;  
using System.Collections.Generic;  
  
namespace Catalog.Services  
{
    public class FileOperationFilter:IOperationFilter
    {
        public void Apply(Microsoft.OpenApi.Models.OpenApiOperation operation, 
        OperationFilterContext context)
        {
            if(operation.OperationId == "Post")
            {
               // operation.
                // operation.Parameters = new List<OpenApiParameter>
                // {
                //     new OpenApiParameter
                //     {
                //         Name = "myFile",  
                //         Required = true, 
                //         Schema = new OpenApiSchema
                //         {
                //             Type = "file"
                //         } ,
                //         In = ParameterLocation.Path,
                //     }
                // };
            }
        }
    } 
} 