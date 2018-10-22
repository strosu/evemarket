using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace EveClientStandard.Extensions
{
    public static class ApiExtension
    {
        public static async Task<List<TResponse>> GetAll<TResponse>(Func<int, Task<ApiResponse<List<TResponse>>>> func)
        {
            var result = await func(1);
            var pages = int.Parse(result.Headers["X-Pages"]);
            var list = result.Data;

            var index = 1;
            while (index < pages)
            {
                index++;
                var currentPageResults = await func(index);
                list.AddRange(currentPageResults.Data);
            }

            return list;
        }
    }
}