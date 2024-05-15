using Academy.Services;
using Newtonsoft.Json;
using Polly;
using Serilog;
using Serilog.Core;
using Shared.Models;


using var log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs\\log.txt", rollingInterval: RollingInterval.Minute)
    .CreateLogger();

log.Information("aplication start");

IReaderService service = new JsonReaderService();

var studenti = await service.ReadStudents();

log.Debug(studenti.Count().ToString());

#region standardno povikuvanje
//while (true)
//{
//    PecatiStudentWithMaxGrade(studenti);
//}
#endregion

#region povikuvanje so Polly
var retryPolicy = Policy
    .Handle<Exception>()
    .RetryForever(exception =>
    {
        // Log each retry attempt
        log.Error(exception, "An error occurred. Retrying...");
    });
//.Retry(3, (exception, retryCount) =>
// {
//     Console.WriteLine($"Retry {retryCount} due to: {exception.Message}");
//     log.Error(exception.Message);
// });
#endregion

retryPolicy.Execute(() =>
{
    while (true)
        PecatiStudentWithMaxGrade(studenti);
});



static void PecatiStudentWithMaxGrade(List<Student> students)
{
    var studentWithMaxGrade = students.OrderByDescending(x => x.Subjects.Max(a => a.Grade)).FirstOrDefault();
    Console.WriteLine(studentWithMaxGrade.Name);

    #region error
    Random random = new Random();
    int randomBroj = random.Next(1, 10);
    if (randomBroj > 5)
    {
        Console.WriteLine("Operation failed");
        throw new Exception("Simulated error");

    }
    else
    {
        Console.WriteLine("Operation susseeded");
    }
    #endregion

    Thread.Sleep(1000);
}