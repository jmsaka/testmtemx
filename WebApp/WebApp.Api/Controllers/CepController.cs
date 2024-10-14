namespace WebApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CepController : ControllerBase
{
    private readonly IMediator _mediator;

    public CepController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCep([FromBody] UpsertCepCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("uf/{uf}")]
    public async Task<IActionResult> GetCepByUf(string uf)
    {
        var result = await _mediator.Send(new GetCepByUfQuery(uf));
        return Ok(result);
    }
}