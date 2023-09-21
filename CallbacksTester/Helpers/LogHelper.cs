using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbacksTester.Helpers
{
    public class LogHelper
    {
        public static async Task LogRequest(HttpRequest Request, ILogger Logger)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"\n==========\n{Request.Method} {Request.Scheme}://{Request.Host}:{Request.Path}\n");
            if (Request.QueryString.HasValue)
            {
                builder.Append($"{Request.QueryString}\n");
            }
            foreach(var HeaderKey in Request.Headers.Keys)
            {
                builder.Append($"{HeaderKey}:{Request.Headers[HeaderKey]}\n");
            }
            if(Request.Body!=null)
            {
                ReadResult result= await Request.BodyReader.ReadAsync();
                byte[] resultByteArray = result.Buffer.ToArray();
                builder.Append($"\n{Encoding.UTF8.GetString(resultByteArray)}\n");

                while (!result.IsCompleted)
                {
                    result = await Request.BodyReader.ReadAsync();
                    resultByteArray = result.Buffer.ToArray();
                    builder.Append($"\n{Encoding.UTF8.GetString(resultByteArray)}\n");
                }
                Request.BodyReader.AdvanceTo(result.Buffer.End);
                
            }
            Logger.LogInformation(builder.ToString());
        }      
        
    }
}
