//using CleanArchitecture.Data;
//using CleanArchitecture.Domain;
//using Microsoft.EntityFrameworkCore;

//StreamerDbContext dbContext = new();

////await AddNewRecords();
////QueryStreaming();
////await QueryFilter();
////await QueryMethod();
////await QueryLinq();
////await TrackingAndNotTracking();
////await AddNewStreamerWithVideo();
////await AddNewStreamerWithVideoId();
////await AddNewActorWithVideo();
////await AddNewDirectorWithVideo();
//await MultipleEntitiesQuery();


//Console.WriteLine("Presione cualquier tecla para terminar el programa");
//Console.ReadKey();


//async Task MultipleEntitiesQuery()
//{
//    //var videoWithActors = await dbContext!.Videos!.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id.Equals(1));

//    //var actor = await dbContext.Actores.Select(q => q.Nombre).ToListAsync();

//    var videoWithDirector = await dbContext!.Videos!
//                                    .Where(q => q.Director != null)
//                                    .Include(x => x.Director)
//                                    .Select( q =>
//                                        new
//                                        {
//                                            Director_Nombre_Completo = $"{q.Director.Nombre} {q.Director.Apellido}" ,
//                                            Movie = q.Nombre
//                                        }
//                                    ).ToListAsync();
//    foreach (var pelicula in videoWithDirector)
//    {
//        Console.WriteLine($"{pelicula.Movie}  -  {pelicula.Director_Nombre_Completo}");
//    }
//}

//async Task AddNewDirectorWithVideo() 
//{
//    var director = new Director()
//    {
//        Nombre = "Lorenzo",
//        Apellido = "Basteri",
//        VideoId = 1
//    };

//    await dbContext.AddAsync(director);
//    await dbContext.SaveChangesAsync();
//}

//async Task AddNewActorWithVideo()
//{
//    var actor = new Actor() 
//    {
//        Nombre = "Brad",
//        Apellido = "Pitt"
//    };

//    await dbContext.AddAsync(actor);
//    await dbContext.SaveChangesAsync();

//    var videoActor = new VideoActor()
//    {
//        ActorId = actor.Id,
//        VideoId = 1
//    };

//    await dbContext.AddAsync(videoActor);
//    await dbContext.SaveChangesAsync();
//}

//async Task AddNewStreamerWithVideoId()
//{

//    var batmanForever = new Video
//    {
//        Nombre = "Hunger Games",
//        StreamerId = 4
//    };

//    await dbContext.AddRangeAsync(batmanForever);
//    await dbContext.SaveChangesAsync();
//}

//async Task AddNewStreamerWithVideo()
//{
//    var pantalla = new Streamer
//    {
//        Nombre = "Pantalla"
//    };

//    var hungerGames = new Video
//    {
//        Nombre = "Hunger Games",
//        Streamer = pantalla,
//    };

//    await dbContext.AddRangeAsync(hungerGames);
//    await dbContext.SaveChangesAsync();
//}

//async Task TrackingAndNotTracking()
//{
//    //La busqueda con tracking mantiene el objeto en memoria
//    var streamerWithTracking = await dbContext!.Streamers!.SingleOrDefaultAsync(x => x.Id.Equals(1));
//    //La busqueda sin tracking elimina el objeto después de obtener el resultado
//    var streamerWithNoTracking = await dbContext!.Streamers!.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(2));

//    streamerWithTracking.Nombre = "Netflix Super";
//    streamerWithNoTracking.Nombre = "Amazon Plus";

//    await dbContext.SaveChangesAsync();
//}

//async Task QueryLinq()
//{
//    Console.WriteLine($"Ingrese el servicio de streaming: ");
//    var streamerNombre = Console.ReadLine();

//    var streamers = await (from i in dbContext.Streamers
//                           where EF.Functions.Like(i.Nombre, $"{streamerNombre}")
//                           select i).ToListAsync();

//    foreach (var streamer in streamers)
//    {
//        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
//    }
//}

//async Task QueryMethod()
//{
//    var streamer = dbContext!.Streamers!;

//    var firstAsync = await streamer.Where(y => y.Nombre.Contains("a")).FirstAsync();
//    var firstorDefaultAsync = await streamer!.Where(y => y.Nombre.Contains("a")).FirstOrDefaultAsync();
//    var firstOrDefualt_v2 = await streamer.FirstOrDefaultAsync(y => y.Nombre.Contains("a"));

//    var singleAsync = await streamer.Where(y => y.Id == 1).SingleAsync();
//    var singleOrDefaultAsync = await streamer.Where(y => y.Id == 1).SingleOrDefaultAsync();

//    var resultado = await streamer.FindAsync(1);
//}


//async Task QueryFilter()
//{
//    Console.WriteLine($"Ingrese una compania de streaming: ");
//    var streamingNombre = Console.ReadLine();

//    var streamers = await dbContext.Streamers.Where(x => x.Nombre.Equals(streamingNombre)).ToListAsync();

//    foreach (var streamer in streamers)
//    {
//        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
//    }

//    //var streamerPartialResults = await dbContext.Streamers.Where(x => x.Nombre.Contains(streamingNombre)).ToListAsync();
//    var streamerPartialResults = await dbContext.Streamers.Where(x => EF.Functions.Like(x.Nombre, $"%{streamingNombre}%")).ToListAsync();

//    foreach (var streamer in streamerPartialResults)
//    {
//        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
//    }
//}

//void QueryStreaming()
//{
//    var streamers = dbContext.Streamers!.ToList();

//    foreach (var streamer in streamers)
//    {
//        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
//    }
//}

//async Task AddNewRecords()
//{
//    Streamer streamer = new Streamer()
//    {
//        Nombre = "Disney",
//        Url = "https://www.disney.com"
//    };

//    dbContext!.Streamers!.Add(streamer);

//    await dbContext!.SaveChangesAsync();

//    var movies = new List<Video>() {
//    new Video
//    {
//        Nombre = "La Cenicienta",
//        StreamerId = streamer.Id,
//    },
//    new Video
//    {
//        Nombre = "1001 Dalmatas",
//        StreamerId = streamer.Id,
//    },
//    new Video
//    {
//        Nombre = "El jorobado de Notredame",
//        StreamerId = streamer.Id,
//    },
//    new Video
//    {
//        Nombre = "Star wars",
//        StreamerId = streamer.Id,
//    },
//};

//    await dbContext.AddRangeAsync(movies);
//    await dbContext!.SaveChangesAsync();

//}