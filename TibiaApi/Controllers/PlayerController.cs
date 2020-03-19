using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database;
using TibiaApi.Repository;
using TibiaApi.Service;

namespace TibiaApi.Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class PlayerController : BaseController
    {
        private readonly IPlayerService<PlayerRepository> _playerService;

        public PlayerController(IPlayerService<PlayerRepository> playerService)
        {
            _playerService = playerService;
        }


        [HttpPost]
        public ActionResult Post(PlayerScrapy player)
        {
            ModelBaseReturn retorno = null;
            try
            {
                retorno = _playerService.SaveFromScrapy<PlayerScrapy>(player);
                
                if (retorno.Status == System.Net.HttpStatusCode.Created)
                    retorno.UrlCreated = Url.Action("Get", "Player", new { name = player.Name });

                return ReturnBasedServiceLayer(retorno);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}