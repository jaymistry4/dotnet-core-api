using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotNetCore.API.Controllers.V3
{
    /// <summary>
    /// Controller to demonstrate multi-threading examples.
    /// </summary>
    [ApiVersion("3.0")]
    [ApiExplorerSettings(GroupName = "v3")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class MultiThreadingExampleController : ControllerBase
    {
        /// <summary>
        /// Executes multiple asynchronous operations in parallel and returns the result.
        /// </summary>
        /// <returns>An IActionResult indicating the operation result.</returns>
        [HttpGet("TestThreeThreadingTasks")]
        public async Task<IActionResult> TestThreeThreadingTasksAsync()
        {
            Console.WriteLine("Starting parallel async operations...");

            try
            {
                // Start all async operations

                Random random = new Random();
                int randomNumber = random.Next(1, 100); // Simulate some random operation

                Task<string> task1 = FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{randomNumber}");
                Task<string> task2 = ProcessFileAsync("data.txt");
                Task<int> task3 = CalculateComplexValueAsync();

                // Wait for all tasks to complete
                await Task.WhenAll(task1, task2, task3);

                // Get results (they're already complete at this point)
                string apiData = task1.Result;
                string fileContent = task2.Result;
                int calculatedValue = task3.Result;

                Console.WriteLine($"API Data: {apiData.Substring(0, Math.Min(apiData.Length, 50))}...");
                Console.WriteLine($"File Content: {fileContent.Substring(0, Math.Min(fileContent.Length, 50))}...");
                Console.WriteLine($"Calculated Value: {calculatedValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("All operations completed.");

            return Ok();
        }

        [HttpGet("UseListForTenTasks")]
        public async Task<IActionResult> UseListForTenTasksAsync()
        {
            Console.WriteLine("Starting parallel async operations...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                // Start all async operations



                Random random = new Random();

                // Create a list of tasks
                List<Task> tasks = new List<Task>
                {
                    Task.Run(() => FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}")),
                    Task.Run(() => FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}")),
                    Task.Run(() => FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}")),
                    Task.Run(() => FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}")),
                    Task.Run(() => FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}")),
                    Task.Run(() => FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}")),
                    Task.Run(() => FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}")),
                    Task.Run(() => FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}")),
                    Task.Run(() => FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}")),
                    Task.Run(() => FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}")),
                    Task.Run(() => FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}")),
                    Task.Run(() => ProcessFileAsync("data.txt")),
                    Task.Run(() => CalculateComplexValueAsync())
                };

                // Run all tasks concurrently and wait for all to complete
                await Task.WhenAll(tasks);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("All operations completed.");

            stopwatch.Stop();
            Console.WriteLine($"Time taken to complete all tasks: {stopwatch.Elapsed.TotalMilliseconds} ms");
            return Ok("Time taken to complete all tasks: " + stopwatch.Elapsed.TotalMilliseconds);
        }

        [HttpGet("WithoutListForTenTasks")]
        public async Task<IActionResult> WithoutListForTenTasksAsync()
        {
            Console.WriteLine("Starting parallel async operations...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                // Start all async operations
                Random random = new Random();

                // Create a list of tasks

                await FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}");
                await FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}");
                await FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}");
                await FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}");
                await FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}");
                await FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}");
                await FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}");
                await FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}");
                await FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}");
                await FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}");
                await FetchDataFromApi($"https://jsonplaceholder.typicode.com/todos/{random.Next(1, 100)}");
                await ProcessFileAsync("data.txt");
                await CalculateComplexValueAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("All operations completed.");

            stopwatch.Stop();
            Console.WriteLine($"Time taken to complete all tasks: {stopwatch.Elapsed.TotalMilliseconds} ms");
            return Ok("Time taken to complete all tasks: " + stopwatch.Elapsed.TotalMilliseconds);
        }

        /// <summary>
        /// Fetches data from the specified API URL.
        /// </summary>
        /// <param name="url">The API URL to fetch data from.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response as a string.</returns>
        static async Task<string> FetchDataFromApi(string url)
        {
            Console.WriteLine($"Starting API call to {url}");
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Simulates processing a file asynchronously.
        /// </summary>
        /// <param name="filePath">The path of the file to process.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the processed file content as a string.</returns>
        static async Task<string> ProcessFileAsync(string filePath)
        {
            Console.WriteLine($"Starting file processing for {filePath}");
            await Task.Delay(1000); // Simulate file processing
            return $"Processed content of {filePath}";
        }

        /// <summary>
        /// Simulates a complex calculation asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the calculated value as an integer.</returns>
        static async Task<int> CalculateComplexValueAsync()
        {
            Console.WriteLine("Starting complex calculation");
            await Task.Delay(1500); // Simulate calculation
            return new Random().Next(1, 100);
        }
    }
}