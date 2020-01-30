using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api
{
    public class BinaryInputFormater : InputFormatter
    {
        public BinaryInputFormater() => SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
        public override bool CanRead(InputFormatterContext context)
            => string.Equals(context.HttpContext.Request.ContentType, "application/octet-stream", StringComparison.OrdinalIgnoreCase);

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;
            int contentLength = Convert.ToInt32(request.ContentLength);

            if (contentLength < 1)
                return await InputFormatterResult.SuccessAsync(null);

            byte[] result = new byte[contentLength];
            int count = 0;

            while (count < contentLength)
            {
                int tempCount = await request.Body.ReadAsync(result, count, contentLength - count);
                count += tempCount;
            }

            return await InputFormatterResult.SuccessAsync(result);
        }
    }
}
