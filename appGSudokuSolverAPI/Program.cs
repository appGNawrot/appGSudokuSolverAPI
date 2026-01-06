using appGSudokuSolverAPI.Models;
using appGSudokuSolverLib;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/solve", (SudokuInput request, string typeSolver="basic") =>
{
    return new SudokuOutput(SudokuSolver.Instance.Solve(request.board, typeSolver));
})
.WithName("Solve")
.WithOpenApi();


app.MapPost("/solve-human-friendly", (SudokuInput request, string typeSolver = "basic") =>
{
    var solvedBoard = SudokuSolver.Instance.Solve(request.board, typeSolver);
    var resultHumanFriendly = new StringBuilder();
    for (int i = 0; i < 9; i++)
        resultHumanFriendly.AppendLine(string.Join(",", solvedBoard.Skip(i * 9).Take(9)));
    return Results.Text(resultHumanFriendly.ToString(), "text/plain");
})
.WithName("SolveHumanFriendly")
.WithOpenApi();



app.UseExceptionHandler(errorAPI =>
{
    errorAPI.Run(async context =>
    {
        var exceptionHandlerFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        if (exceptionHandlerFeature != null)
        {
            var ex = exceptionHandlerFeature.Error;
            context.Response.StatusCode = ex switch
            {
                ArgumentOutOfRangeException => StatusCodes.Status400BadRequest,
                ArgumentException => StatusCodes.Status400BadRequest,
                InvalidOperationException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new 
            {
                error = ex.Message
            });
        }
    });
});

app.Run();
