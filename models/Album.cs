namespace APIAlbumList.Models;

public class Album
{
    public int Id { get; set;}

    public string? ArtistName { get; set;}
    public string? Name { get; set;}

    public DateOnly Release { get; set;}

}