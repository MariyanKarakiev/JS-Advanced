using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Services;
using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private IPlayerService playerService;
        public PlayersController(
            Request request
           , IPlayerService _playerService)
            : base(request)
        {
            playerService = _playerService;
        }


        [Authorize]
        public Response Add() => View();
       
        [Authorize]
        public Response All()
        {
            var players = playerService.GetPlayers().ToList();
            return View(players);
        }

        [Authorize] 
        public Response Collection()
        {
            var players = playerService.GetPlayers().ToList();

            return View(new { IsAuthenticated = true });
        }



        [HttpPost]
        public Response Add(PlayerViewModel model)
        {
            (bool isValidPlayer, IEnumerable<ErrorViewModel> errors) = playerService.ValidateModel(model);

            if (!isValidPlayer)
            {
                return Redirect("/Players/Add");
            }

            try
            {
                playerService.CreatePlayer(model);
            }
            catch (ArgumentException aex)
            {
                return View(new List<ErrorViewModel> { new ErrorViewModel(aex.Message) }, "/Error");
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("/Players/All");
        }


        [HttpPost]
        public Response AddToCollection(string playerId)
        {
            try
            {
                playerService.AddPlayerToUser(playerId, User.Id);
            }
            catch (ArgumentException aex)
            {
                return Redirect("Players/All");
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("Players/All");
        }

  
        [HttpPost]
        public Response RemoveFromCollection(string playerId)
        {
            try
            {
                playerService.RemovePlayerFromCollection(playerId, User.Id);
            }
            catch (ArgumentException)
            {
                return Redirect("Players/Collection");
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("Players/Collection");
        }
    }
}

