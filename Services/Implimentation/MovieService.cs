using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Services.Implimentation
{
    public class MovieService : IMovieServices
    {
        private readonly IAdminRepositries _adminRepositries;
        private readonly IMovieRepositries _repo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserRepositries _UserRepository;
        private readonly ICustomerRepositries _customerRepositries;
        private readonly IBookingRepositries _bookingRepositries;
        
        public MovieService(IMovieRepositries repo, IWebHostEnvironment webHostEnvironment,
         IUserRepositries UserRepository, ICustomerRepositries customerRepositries,
          IBookingRepositries bookingRepositries ,  IAdminRepositries adminRepositries)
        {
            _repo = repo;
            _UserRepository = UserRepository;
            _webHostEnvironment = webHostEnvironment;
            _customerRepositries = customerRepositries;
            _bookingRepositries = bookingRepositries;
             _adminRepositries = adminRepositries;
        }

        public async Task<CreateMovieRequestmodel> CreateMovie(CreateMovieRequestmodel movie)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Videos");
            bool basePathExists = Directory.Exists(basePath);
            if (!basePathExists) Directory.CreateDirectory(basePath);
            var fileName = Path.GetFileNameWithoutExtension(movie.incomingFiles.FileName);
            var filePath = Path.Combine(basePath, movie.incomingFiles.FileName);
            var extension = Path.GetExtension(movie.incomingFiles.FileName);
            string cobineprog =  $"{fileName}{extension}";
            if (!System.IO.File.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    movie.incomingFiles.CopyToAsync(stream);
                }

                var movies = new Movie
                {
                    MovieName = movie.MovieName,
                    Director = movie.Director,
                    Year = movie.Year,
                    MoviePrice = movie.MoviePrice,
                    TimeCreted = DateTime.UtcNow,
                    MovieFliePath = cobineprog,
                    Moviedate = DateTime.Now.AddDays(2),
                };
                _repo.CreateMovie(movies);
            }

            return null;
        }

        // public MovieResponceModel CreateMovie(CreateMovieRequestmodel movie)
        // {
        //     var MovieFlieName = "";
        //     if (movie.MovieFlieType != null)

        //     {
        //         var path = _webHostEnvironment.WebRootPath;
        //         var videoeparth = Path.Combine(path, "MovieFlieType");
        //         Directory.CreateDirectory(videoeparth);
        //         string wordVideoType = movie.MovieFlieType.ContentType.Split('/')[1];
        //         // MovieFlieType = $"{movie.MovieFlieType}/{Guid.NewGuid().ToString().Substring(0,9)}.{wordVideoType}";
        //         if (wordVideoType.ToLower() != "MP4" || wordVideoType.ToLower() != "MOV" || wordVideoType.ToLower() != "WEBM")
        //         {
        //             return new MovieResponceModel
        //             {
        //                 Message = "Fail to create product because file type is not image",
        //                 Status = false
        //             };
        //         }
        //         MovieFlieName = $"{movie.MovieFlieType}/{Guid.NewGuid().ToString().Substring(0, 9)}.{wordVideoType}";
        //         var fullPath = Path.Combine(videoeparth, MovieFlieName);
        //         using (var stream = new FileStream(fullPath, FileMode.Create))
        //             {
        //                 movie.MovieFlieType.CopyTo(stream);
        //             }
        //     }

        //      var movies = new Movie
        //         {
        //             MovieName = movie.MovieName,
        //             Director = movie.Director,
        //             Year = movie.Year,
        //             MoviePrice = movie.MoviePrice,
        //             TimeCreted = DateTime.UtcNow.AddDays(-1),
        //             MovieFlieType = MovieFlieName,
        //             Moviedate = DateTime.Now.AddDays(2),
        //         };
        //         var creamo = _repo.CreateMovie(movies);
        //         if (creamo == null)
        //         {
        //             return new MovieResponceModel
        //             {
        //                 Message = "fail to create",
        //                  Status = false,
        //             };
        //         }
        //           return new MovieResponceModel
        //         {
        //               Data = new MovieDto
        //            {
        //                 MovieName = movie.MovieName,
        //                 Director = movie.Director,
        //                 Year = movie.Year,
        //                 MoviePrice = movie.MoviePrice,
        //                 TimeCreted = DateTime.UtcNow.AddDays(-1),
        //                 MovieFlieType = MovieFlieName,
        //                 Moviedate = DateTime.Now.AddDays(2),
        //            },
        //            Message = "successfully create",
        //             Status = true,
        //         };


        // }

        public bool DeleteMovie(int id)
        {
              var  delm  = _repo.GetMoviesbyid(id);
            if (delm != null )
            {
                delm.IsdDleted = true;
                return true;
            }
                return false;
            // var DelMovie = _repo.GetMoviesbyid(id);
            // _repo.DeleteMovie(DelMovie);
           
        }

        public MovieResponceModel GetMoviesById(int id)
        {
            var mid = _repo.GetMoviesbyid(id);
            if (mid == null)
            {
                return new MovieResponceModel
                {
                    Message = "Failed to get id",
                    Status = false,
                };
            }
            return new MovieResponceModel
            {
                Message = "successfully fetched",
                Status = true,
                Data = new MovieDto
                {
                    Id = mid.Id,
                    MovieName = mid.MovieName,
                    Director = mid.Director,
                    Year = mid.Year,
                    MoviePrice = mid.MoviePrice,
                    TimeCreted = DateTime.UtcNow,
                    MovieFliePath = mid.MovieFliePath,
                    //  MovieFliePath = cobineprog,
                    Moviedate = DateTime.Now.AddDays(+2),
                }
            };

        }


        public IList<Movie> ViewAllMovie()
        {
            return _repo.ViewAllMovie();
        }

        public UpdateMovieResponceModel UpdateMovie(UpdateMovieResponceModel movie)
        {
            var updateMovie = _repo.GetMoviesbyid(movie.Id);
            if (updateMovie == null)
            {
                return null;
            }
            updateMovie.Director = updateMovie.Director ?? updateMovie.Director;
            updateMovie.MovieName = updateMovie.MovieName ?? updateMovie.MovieName;
            updateMovie.Year = movie.Year != null ? movie.Year : updateMovie.Year;
            // updateMovie.MoviePrice = updateMovie.MoviePrice < 0 ? updateMovie.MoviePrice : updateMovie.MoviePrice;
            _repo.UpdateMovie(updateMovie);
            return movie;
        }

        // public MovieResponceModel UpdateMovie(UpdateMovieResponceModel movie)
        // {
        //     var updateMovie = _repo.GetMoviesbyid(movie.Id);
        //     if (updateMovie == null) return new MovieResponceModel
        //     {
        //         Message = "Movie Not Found",
        //         Status = false,
        //     };
        //     updateMovie.Director = updateMovie.Director ?? updateMovie.Director;
        //     updateMovie.MovieName = updateMovie.MovieName ?? updateMovie.MovieName;
        //     updateMovie.MovieFliePath = updateMovie.MovieFliePath ?? updateMovie.MovieFliePath;
        //     updateMovie.MoviePrice = updateMovie.MoviePrice < 0 ? updateMovie.MoviePrice : updateMovie.MoviePrice;
        //     updateMovie.TimeCreted = DateTime.UtcNow;
        //     updateMovie.Moviedate = DateTime.Now.AddDays(+2);
        //     _repo.UpdateMovie(updateMovie);
        //     return new MovieResponceModel
        //     {
        //         Message = " Movie  found",
        //         Status = true
        //     };
        // }

        public MovieResponceModel SearchMovieByName(string MovieName)
        {
            throw new NotImplementedException();
        }

        public MoviesResponceModels ViewAllMovies()
        {
            var gatall = _repo.ViewAllMovie();
            if (gatall == null)
            {
                return new MoviesResponceModels
                {
                    Message = "failed to fetch",
                    Status = false,
                };
            }
            return new MoviesResponceModels
            {
                Message = "successfully fetched",
                Status = true,
                Data = gatall.Select(x => new MovieDto
                {
                    Id = x.Id,
                    MovieName = x.MovieName,
                    Director = x.Director,
                    MoviePrice = x.MoviePrice,
                    MovieFliePath = x.MovieFliePath,
                    TimeCreted = x.TimeCreted,
                    Moviedate = x.Moviedate,

                }
                ).ToList()
            };

        }

        // public async Task<BasesRespones<MovieDto>> BookMovie(int id)
        // {
        //     // var by = _repo.GetMoviesbyid(id);
        //     var pick =   _repo.GetMoviesbyid(id);//.Get(m => m.IsAvailable == true);
        //     var by =  _customerRepositries.Get(a => a.IsAvailable == true);
        //     if (by. >= pick.MoviePrice)
        //     {
        //         by.MoviePrice = by.
        //     }
        // }

        public MovieResponceModel BookMovie(int id, decimal amountToDeduct, ref decimal balance)
        {
            // Check if the user has enough balance to book the movie
            var user = _customerRepositries.GetCustomerById(id);
            if (balance < amountToDeduct)
            {
                return new MovieResponceModel
                {
                    Message = "Not enough balance in your wallet to book this movie",
                    Status = false,
                    // Data  = new
                };
            }
            var us = _customerRepositries.UpdateCustomer(user);
            // Deduct the amount from the user's wallet
            balance -= amountToDeduct;
            var get = _adminRepositries.GetAdminId(2);
             _customerRepositries.UpdateCustomer(us);
             return new MovieResponceModel
             {
                  Message = "Not enough balance in your wallet to book this movie",
                    Status = false,
                    Data  = new MovieDto
                    {
                        Id = id,
                        // MoviePrice = mo
                    }
             };
            // // Return the response with the booked movie details
            // var bookedMovie = new MovieResponceModel
            // {
            //     // StatusCode = 200, 
            //     Message = "Movie booked successfully",

            //     // MovieId = id 
            // };

            // return bookedMovie;
        }
    }
}





