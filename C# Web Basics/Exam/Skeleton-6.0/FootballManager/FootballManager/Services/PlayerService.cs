using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;

        public PlayerService(IRepository _repo)
        {
            repo = _repo;
        }

        public void AddPlayerToUser(string playerId, string userId)
        {
            var user = repo.All<User>()
                .FirstOrDefault(u => u.Id == userId);

            var player = repo.All<Player>()
               .FirstOrDefault(p => p.Id == playerId);

            if (user == null || player == null)
            {
                throw new ArgumentException("User or player not found");
            }

            user.UserPlayers.Add(new UserPlayer()
            {
                Player = player,
                PlayerId = playerId,
                User = user,
                UserId = userId
            });

            repo.SaveChanges();
        }

        public void CreatePlayer(PlayerViewModel model)
        {
            var playerExists = GetPlayerByName(model) != null;

            if (playerExists)
            {
                throw new ArgumentException("Creating player failed - Player already exists");
            }

            var player = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description
            };

            repo.Add<Player>(player);
            repo.SaveChanges();
        }

        public Player GetPlayerByName(PlayerViewModel model)
        {
            return repo.All<Player>().FirstOrDefault(p => p.FullName == model.FullName);
        }

        public IEnumerable<PlayersListViewModel> GetPlayers()
        {
            return repo.All<Player>()
                .Select(p => new PlayersListViewModel()
                {
                    
                    playerId = p.Id,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Description = p.Description                 
                });
        }

        public void RemovePlayerFromCollection(string playerId, string userId)
        {
            var player = repo.All<Player>()
                  .FirstOrDefault(p => p.Id == playerId);

            var user = repo.All<User>()
               .FirstOrDefault(u => u.Id == userId);

            if (user == null || player == null)
            {
                throw new ArgumentException("User or player not found");
            }

            var userPlayer = repo.All<UserPlayer>()
                .Where(p => p.User.Id == userId)
                .FirstOrDefault(p => p.PlayerId == playerId);


            if (userPlayer == null)
            {
                throw new ArgumentException("Error cant`t remove");
            }

            repo.Remove(userPlayer);
            repo.SaveChanges();
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(PlayerViewModel model)
        {
            var isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (model.FullName == null ||
                model.FullName.Length < 5 ||
                model.FullName.Length > 80)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("FullName is required and must be between 5 and 80 characters"));
            }

            if (model.ImageUrl == null ||
                 model.ImageUrl.Length > 2024)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("ImageUrl is required and must not be longer that 2024 characters"));
            }

            if (model.Position == null ||
                model.Position.Length < 5 ||
                model.Position.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Position is required and must be between 5 and 20 characters"));
            }

            if (model.Speed < 0 ||
                model.Speed > 10)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Speed value must be between 0 and 10"));
            }
            if (model.Endurance < 0 ||
             model.Endurance > 10)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Endurance value must between 0 and 10"));
            }

            if (model.Description == null || model.Description.Length > 200)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Description is required and must be up to 200 characters"));
            }

            return (isValid, errors);
        }
    }
}
