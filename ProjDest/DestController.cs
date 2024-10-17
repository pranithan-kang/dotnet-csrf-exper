using Microsoft.AspNetCore.Mvc;

[AutoValidateAntiforgeryToken]
[ApiController]
[Route("[controller]")]
public class DestController: Controller
{
    [HttpGet("[action]")]
    public async Task<IActionResult> BackendGetAction()
    {
        return Ok("testing");
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> BackendPostAction()
    {
        return Ok(new { foo = "bar" });
    }
}