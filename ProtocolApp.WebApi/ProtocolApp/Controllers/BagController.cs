using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProtocolApp.Controllers;

[Route("protocolapp/[controller]/[action]")]
[ApiController]

public class BagController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public BagController(IUnitOfWork unitOfWork)
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