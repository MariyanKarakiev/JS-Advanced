namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            // var id = int.Parse(Console.ReadLine());
            var result = ExportSongsAboveDuration(context, 4);

            Console.WriteLine(result);

            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var albums = context.Albums
                .ToArray()
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    AlbumSongs = a.Songs
                                .Select(s => new
                                {
                                    SongName = s.Name,
                                    Price = s.Price.ToString("f2"),
                                    Writer = s.Writer.Name
                                })
                                .OrderByDescending(s => s.SongName)
                                .ThenBy(s => s.Writer)
                                .ToArray(),
                    Price = a.Price.ToString("f2")

                })
                .ToList();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int id = 1;
                foreach (var song in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{id++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.Writer}");
                }
                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }
            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songsInfo = context.Songs
                   .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                    .Select(s => new
                    {
                        SongName = s.Name,
                        Writer = s.Writer.Name,
                        Performer = s.SongPerformers
                                         .ToArray()
                                         .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                                         .FirstOrDefault(),
                        AlbumProducer = s.Album.Producer.Name,
                        Duration = s.Duration.ToString("c", CultureInfo.InvariantCulture)
                    })
                    .OrderBy(s => s.SongName)
                    .ThenBy(s => s.Writer)
                    .ThenBy(s => s.Performer)
                      .ToArray();

            int id = 1;
            foreach (var song in songsInfo)
            {
                sb
                  .AppendLine($"-Song #{id++}")
                  .AppendLine($"---SongName: {song.SongName}")
                  .AppendLine($"---Writer: {song.Writer}")
                  .AppendLine($"---Performer: {song.Performer}")
                  .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                  .AppendLine($"---Duration: {song.Duration}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
