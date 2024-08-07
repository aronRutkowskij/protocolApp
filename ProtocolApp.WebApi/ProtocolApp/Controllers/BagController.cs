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
    [ActionName("getdefault")]
    public async Task<IActionResult> GetDefault()
    {
        var bag = _unitOfWork.Bag.GetById(1);
        return Ok(bag);
    }
    
    [HttpPost]
    [ActionName("add")]
    public async Task<IActionResult> Add()
    {
        string data = Request.Form["jsondata"].ToString();
        Console.WriteLine("data = {0}", data);
        var bag = new Bag
        {
            BagData = data
        };
        Console.WriteLine("bag = {0}", bag.BagData);
        _unitOfWork.Bag.Add(bag);
        await _unitOfWork.Complete();
        
        return Ok(bag);
    }

    [HttpPost]
    [ActionName("update")]
    public async Task<IActionResult> Update()
    {
        string data = Request.Form["jsondata"].ToString();
        var bag = _unitOfWork.Bag.GetById(1);
        bag.BagData = data;
        await _unitOfWork.Complete();
        
        return Ok(bag);
    }
    
    [HttpPost]
    [ActionName("getbyid")]
    public async Task<IActionResult> GetById()
    {
        long bagid = long.Parse(Request.Form["id"]);
        var bag = _unitOfWork.Bag.GetById(bagid);
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