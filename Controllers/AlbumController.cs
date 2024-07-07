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

    [HttpPost]
    public IActionResult Create(Album album)
    {
        AlbumService.Add(album);
        return CreatedAtAction(nameof(Get), new { id = album.Id}, album);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Album album)
    {
        if (id != album.Id)
            return BadRequest();

        var existingAlbum = AlbumService.Get(id);
        if(existingAlbum is null)
            return NotFound();

        AlbumService.Update(album);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var album = AlbumService.Get(id);

        if (album is null)
            return NotFound();

        AlbumService.Delete(id);

        return NoContent();
    }
}