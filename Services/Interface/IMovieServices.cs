using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Services.Interface
{
    public interface IMovieServices
    {
        Task<CreateMovieRequestmodel> CreateMovie(CreateMovieRequestmodel movie);
        public UpdateMovieResponceModel UpdateMovie(UpdateMovieResponceModel movie);
        bool DeleteMovie(int id);
         public MovieResponceModel BookMovie(int id, decimal amountToDeduct, ref decimal balance);

    //    Task<BasesRespones<MovieDto>> BookMovie( int id);
        public MovieResponceModel SearchMovieByName(string MovieName);
        public MovieResponceModel GetMoviesById(int id);
        IList<Movie> ViewAllMovie();
        MoviesResponceModels ViewAllMovies();
        // Task<BasesRespones<MovieDto>> BuyTicket(int id);



    }
}