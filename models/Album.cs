using Microsoft.EntityFrameworkCore;

namespace APIAlbumList.Models;

public class Album
{
    public int Id { get; set;}
    public string? ArtistName { get; set;}
    public string? Name { get; set;}
    public int YearRelease { get; set;}
}

public class AlbumDb : DbContext
{
    public AlbumDb(DbContextOptions<AlbumDb> options) : base(options) { }
    public DbSet<Album> Albums { get; set;}
}