using FootballManager.Data.Models;
using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public interface IPlayerService
    {
        IEnumerable<PlayersListViewModel> GetPlayers();
        void CreatePlayer(PlayerViewModel model);
        Player GetPlayerByName(PlayerViewModel model);
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(PlayerViewModel model);
        void AddPlayerToUser(string playerId, string id);
        void RemovePlayerFromCollection(string playerId, string userId);
    }
}
