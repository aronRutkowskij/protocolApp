using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProtocolApp.Controllers;

[Route("protocolapp/[controller]/[action]")]
[ApiController]

public class TechnikerController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public TechnikerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [ActionName("getall")]
    public async Task<IActionResult> GetAll()
    {
        var techniker = _unitOfWork.Techniker.GetAll();
        return Ok(techniker);
    }

    [HttpPost]
    [ActionName("add")]
    public async Task<IActionResult> Add()
    {
        string name = Request.Form["name"].ToString();
        var techniker = new Techniker
        {
            Name = name
        };
        _unitOfWork.Techniker.Add(techniker);
        await _unitOfWork.Complete();
        return Ok();
    }
    
    [HttpPost]
    [ActionName("delete")]
    public async Task<IActionResult> Delete()
    {
        long tid = long.Parse(Request.Form["id"]);
        var techniker = _unitOfWork.Techniker.GetById(tid);
        _unitOfWork.Techniker.Remove(techniker);
        await _unitOfWork.Complete();
        return Ok();
    }
}