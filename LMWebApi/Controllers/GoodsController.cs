using Microsoft.AspNetCore.Mvc;

[ApiController]
public class GoodsController : ControllerBase
{
    [Route("api/goods")]
    public string Get()
    {
        return "Hello World";
    }
}