using IO.Swagger.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Model;

namespace EveClientStandard.Extensions
{
    public static class ApiExtension
    {
        public static async Task<List<TResponse>> GetAll<TResponse>(Func<int, Task<ApiResponse<List<TResponse>>>> func)
        {
            var pageHeader = "X-Pages";
            var result = await func(1);

            if (!result.Headers.ContainsKey(pageHeader) || !int.TryParse(result.Headers[pageHeader], out var pages))
            {
                return result.Data;
            }

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

        public static Dictionary<int, double> ApplyOrdersMapping(this IEnumerable<GetMarketsStructuresStructureId200Ok> filteredOrders, Func<IEnumerable<GetMarketsStructuresStructureId200Ok>, double> func)
        {
            return filteredOrders
                .GroupBy(
                    x => x.TypeId.Value,
                    (key, g) => new { TypeId = key, Prices = g.ToList() })
                .ToDictionary(x => x.TypeId, x => func(x.Prices));
        }

        public static Dictionary<int, List<Order>> GetOrdersAndApplyMapping2(this IEnumerable<GetMarketsStructuresStructureId200Ok> filteredOrders, Func<IEnumerable<Order>, List<Order>> func)
        {
            return filteredOrders.GroupBy(x => x.TypeId.Value,
                    (key, g) => 
                        new {
                            TypeId = key,
                            Prices = g
                                .ToList()
                                .Select(x => new Order()
                                {
                                    Amount = x.VolumeRemain.Value,
                                    Price = x.Price.Value
                                })
                                .ToList()
                        })
                .ToDictionary(x => x.TypeId, x => func(x.Prices));
        }
    }

    public class Order
    {
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}