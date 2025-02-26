using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    [HttpGet]
    public IActionResult GetData()
    {
        return Ok(new { Message = "Hello from API Controller" });
    }
}