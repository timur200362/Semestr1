using System;
using RazorLight;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace INF2course
{
    public class RazorGenerator<T>
    {
        static async Task<string> generate(string key, string template, T model)
        {
            var engine = new RazorLightEngineBuilder()
                .UseMemoryCachingProvider()
                .Build();

            return await engine.CompileRenderStringAsync<T>(key, template, model);
        }
        static public string Run(string key, string template, T model)
        {
            string result = null;


            Task.Run(async () =>
            {
                result = await RazorGenerator<T>.generate(key, template, model);
            }).Wait();
            return result;
        }
    }
}
