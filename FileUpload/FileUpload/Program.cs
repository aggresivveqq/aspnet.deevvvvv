var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    response.ContentType = "text/html; charset=utf-8";

    if (request.Path == "/upload" && request.Method=="POST")
    {
        IFormFileCollection files = request.Form.Files;
        //creating a path where files will be saved.
        var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";
        Directory.CreateDirectory(uploadPath); 
        foreach(var file in files)
        {
            //path to uploads folder
            string fullPath =$"{uploadPath}/{file.Name}";
            //saving file in folder
            using(var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream); 
            }
        }
        await response.WriteAsync("File downloaded succesfully");


    }
    else
    {
        await response.SendFileAsync("html/index.html");
    }

});
app.Run();
