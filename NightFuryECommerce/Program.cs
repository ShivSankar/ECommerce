var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
	context.Response.ContentType = "text/html";
	StreamReader str = new StreamReader(context.Request.Body);
	string body = await str.ReadToEndAsync();


    //Dictionary<string, Microsoft.Extensions.Primitives.StringValues> dict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
    //string firstNumber = dict["firstNumber"];
    //string secondNumber = dict["secondNumber"];
    //string operation = dict["operation"];

    string firstNumber = context.Request.Query["firstNumber"];
    string secondNumber = context.Request.Query["secondNumber"];
    string operation = context.Request.Query["operation"];

    int opOutput = 20;

    switch (operation)
    {
        case "add":
            opOutput = int.Parse(firstNumber ?? "0") + int.Parse(secondNumber ?? "0");
            break;
        case "subtract":
            opOutput = int.Parse(firstNumber ?? "0") - int.Parse(secondNumber ?? "0");
            break;
    }
	await context.Response.WriteAsync(opOutput.ToString());

});

app.Run();



