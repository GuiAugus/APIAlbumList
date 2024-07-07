using APIAlbumList.Models;

namespace APIAlbumList.Services;

public static class AlbumService
{
    static List<Album> Albums{ get; }
    static int nextId = 3;
    static AlbumService()
    {
        Albums = new List<Album>
        {
            new Album { Id = 1, ArtistName = "Racionais MC", Name = "Sobrevivendo no Inferno", Release = new DateOnly(1997, 12, 20)},
            new Album { Id = 2, ArtistName = "BK", Name = "Castelos e Ruinas", Release = new DateOnly(2016, 03, 21)}
        };
    }

    public static List<Album> GetAll() => Albums;

    public static Album? Get(int id) => Albums.FirstOrDefault(p => p.Id == id);

    public static void Add(Album album)
    {
        album.Id = nextId++;
        Albums.Add(album);
    }

    public static void Delete(int id)
    {
        var album = Get(id);
        if(album is null)
            return;

        Albums.Remove(album);
    }

    public static void Update(Album album)
    {
        var index = Albums.FindIndex(p => p.Id == album.Id);
        if (index == -1)
            return;

        Albums[index] = album;
    }
}


