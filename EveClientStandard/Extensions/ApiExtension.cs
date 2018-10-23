using IO.Swagger.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EveClientStandard.Extensions
{
    public static class ApiExtension
    {
        public static async Task<List<TResponse>> GetAll<TResponse>(Func<int, Task<ApiResponse<List<TResponse>>>> func)
        {
            var result = await func(1);
            var pages = int.Parse(result.Headers["X-Pages"]);
            var response = new List<TResponse>(result.Data);
            var taskList = new List<Task<ApiResponse<List<TResponse>>>>();

            for (var i = 2; i <= pages; i++)
            {
                taskList.Add(func(i));
            }

            await Task.WhenAll(taskList);

            foreach (var task in taskList)
            {
                response.AddRange(task.Result.Data);
            }

            return response;
        }
    }
}