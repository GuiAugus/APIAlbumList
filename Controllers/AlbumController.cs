using System.Security.Cryptography.X509Certificates;
using APIAlbumList.Models;
using APIAlbumList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAlbumList.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumController : ControllerBase
{
    private readonly AlbumDb _context;
    public AlbumController(AlbumDb context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Album>> PostAlbum(Album album)
    {
        _context.Albums.Add(album);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAlbum", new {id = album.Id}, album);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
    {
        return await _context.Albums.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Album>> GetAlbum(int id)
    {
        var album = await _context.Albums.FindAsync(id);

        if (album == null)
        {
            return NotFound();
        }        
        return album;
    }

    [HttpPut("id")]
    public async Task<IActionResult> PutAlbum(int id, Album album)
    {
        if (id != album.Id)
        {
            return BadRequest();
        }

        _context.Entry(album).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlbumExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();        
    }

    private bool AlbumExists(int id)
    {
        return _context.Albums.Any(e => e.Id == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlbum(int id)
    {
        var album = await _context.Albums.FindAsync(id);
        if (album == null)
        {
            return NotFound();
        }
        _context.Albums.Remove(album);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}