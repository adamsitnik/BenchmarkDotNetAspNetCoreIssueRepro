using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BenchmarkDotNetAspNetCoreIssueRepro
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Tests>();

            Console.Read();
        }
    }

    public class Tests
    {
        HttpClient httpClient = null;

        [GlobalSetup]
        public void Setup()
        {
            httpClient = new WebApplicationFactory<AspNetCoreApi.Startup>()
                .CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });
        }

        [Benchmark]
        public async Task Execute()
        {
            await httpClient.GetAsync("/api/SampleApi");
        }
    }
}
