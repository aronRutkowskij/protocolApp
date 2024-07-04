using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProtocolApp.Controllers;

[Route("protocolapp/[controller]/[action]")]
[ApiController]

public class ProtocolController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProtocolController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [ActionName("getall")]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }
}