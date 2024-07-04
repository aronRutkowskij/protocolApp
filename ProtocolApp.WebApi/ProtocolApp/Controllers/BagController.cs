using Domain.Entities;
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
        var bags = _unitOfWork.Bag.GetAll();
        return Ok(bags);
    }

    [HttpPost]
    [ActionName("add")]
    public async Task<IActionResult> Add()
    {
        string data = Request.Form["jsondata"].ToString();
        var bag = new Bag
        {
            BagData = data
        };
        _unitOfWork.Bag.Add(bag);
        await _unitOfWork.Complete();
        
        return Ok(bag);
    }

    [HttpPost]
    [ActionName("delete")]
    public async Task<IActionResult> Delete()
    {
        long bagid = long.Parse(Request.Form["id"]);
        var bag = _unitOfWork.Bag.GetById(bagid);
        _unitOfWork.Bag.Remove(bag);
        await _unitOfWork.Complete();
        return Ok();
    }
}