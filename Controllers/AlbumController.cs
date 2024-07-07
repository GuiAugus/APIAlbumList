using System.Security.Cryptography.X509Certificates;
using APIAlbumList.Models;
using APIAlbumList.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIAlbumList.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumController : ControllerBase
{
    public AlbumController()
    {
    }

    [HttpGet]
    public ActionResult<List<Album>> GetAll() =>
        AlbumService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Album> Get(int id)
    {
        var album = AlbumService.Get(id);

        if(album == null)
            return NotFound();
        
        return album;
    }
}