using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProtocolApp.Controllers;

[Route("protocolapp/[controller]/[action]")]
[ApiController]

public class DocumentController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public DocumentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [ActionName("getall")]
    public async Task<IActionResult> GetAll()
    {
        var documents = _unitOfWork.Document.GetAll();
        return Ok(documents);
    }
    
    [HttpPost]
    [ActionName("getbyid")]
    public async Task<IActionResult> GetById()
    {
        long id = long.Parse(Request.Form["id"]);
        var doc = _unitOfWork.Document.GetById(id);
        return Ok(doc);
    }

    [HttpPost]
    [ActionName("add")]
    public async Task<IActionResult> Add()
    {
        var form = await Request.ReadFormAsync();
        
        foreach (var atmnt in form.Files)
        {
            using (var ms = new MemoryStream())
            {
                await atmnt.CopyToAsync(ms);
                byte[] fileBytes = ms.ToArray();
                var doc = new Document
                {   
                    Name = "Protokoll_" + DateTime.Now.ToString(),
                    Data = fileBytes,
                    Created_At = DateTime.Now.ToUniversalTime()
                };
                _unitOfWork.Document.Add(doc);
                await _unitOfWork.Complete();
            }
        }
        return Ok();
    }
}






