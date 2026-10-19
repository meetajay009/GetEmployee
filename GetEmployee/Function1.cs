using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace GetEmployee;

public class EmployeeDetail
{
    private readonly ILogger<EmployeeDetail> _logger;

    public EmployeeDetail(ILogger<EmployeeDetail> logger)
    {
        _logger = logger;
    }

    [Function("GetEmployee")]
    public IActionResult GetEmployee([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        var empDetail =  new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Position = "Software Engineer" },
            new Employee { Id = 2, Name = "Jane Smith", Position = "Project Manager" },
            new Employee { Id = 3, Name = "Mike Johnson", Position = "QA Analyst" }
        };
        return new OkObjectResult(empDetail);
    }

    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
    }
}