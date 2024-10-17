
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SourceController: Controller
{
    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("http://localhost:5011"),
        DefaultRequestHeaders = {{ "Authorization", "bearer 1234" }}
    };

    [HttpGet("[action]")]
    public async Task<IActionResult> ProxyGet() {
        var rslt = await sharedClient.GetStringAsync("/Dest/BackendGetAction");
        return Ok(rslt);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> ProxyPost() {
        var rslt = await sharedClient.PostAsync("/Dest/BackendPostAction", null);
        var jsonRslt = await rslt.Content.ReadFromJsonAsync<ExpandoObject>();
        return Json(jsonRslt);
    }
}