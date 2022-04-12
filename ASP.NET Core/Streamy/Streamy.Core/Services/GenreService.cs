﻿using Streamy.Core.Models;
using Streamy.Infrastructure.Data.Repositories;
using Streamy.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamy.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IApplicationDbRepository _repo;

        public GenreService(IApplicationDbRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateGenre(GenreViewModel genreModel)
        {
            if (genreModel == null)
            {
                throw new ArgumentNullException("There is no genre to create.");
            }

            await _repo.AddAsync(new Genre
            {
                Name = genreModel.Name,
            });

            _repo.SaveChanges();
        }

        public async Task DeleteGenre(short id)
        {
            var genreToDelete = await GetGenreByIdAsync(id);

            if (genreToDelete == null)
            {
                throw new ArgumentNullException("Genre not found", nameof(genreToDelete));
            }

            await _repo.DeleteAsync<Genre>(genreToDelete.Id);

            _repo.SaveChanges();
        }

        public GenreListViewModel GetAllGenres()
        {
            var genres = _repo.All<Genre>().ToList();

            if (genres == null)
            {
                throw new ArgumentNullException("There are no genres", nameof(genres));
            }

            var genreListModel = new GenreListViewModel();

            genres.ForEach(g => genreListModel.Genres
            .Add(new GenreViewModel
            {
                Id = g.Id,
                Name = g.Name
            }));

            return genreListModel;
        }

        public async Task<GenreViewModel> GetByIdAsync(short id)
        {
            var genre = await GetGenreByIdAsync(id);

            var mappedGenre = new GenreViewModel()
            {
                Id = genre.Id,
                Name = genre.Name
            };

            return mappedGenre;
        }

        private async Task<Genre> GetGenreByIdAsync(short id)
        {
            var genre = await _repo.GetByIdAsync<Genre>(id);

            if (genre == null)
            {
                throw new ArgumentNullException("Genre not found", nameof(genre));
            }

            return genre;
        }

        public async Task<GenreViewModel> GetGenreWithDetails(short id)
        {
            var genre = await GetGenreByIdAsync(id);

            var mappedGenre = new GenreViewModel()
            {
                Id= genre.Id,
                Name = genre.Name,
                Albums = genre.Albums.Count,
                Songs = genre.Songs.Count,
            };

            return mappedGenre;
        }

        public void UpdateGenre(GenreViewModel genreModel)
        {
            if (genreModel == null)
            {
                throw new ArgumentNullException("Genre not found", nameof(genreModel));
            }

            var updatedGenre = new Genre
            {
                Id = genreModel.Id,
                Name = genreModel.Name
            };

            _repo.Update(updatedGenre);
            _repo.SaveChanges();
        }
    }
}
