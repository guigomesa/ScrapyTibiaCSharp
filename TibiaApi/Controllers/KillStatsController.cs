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
    public class KillStatsController : BaseController
    {
        private readonly IKillStatsService _killStatsService;

        public KillStatsController(IKillStatsService killStatsService)
        {
            _killStatsService = killStatsService;
        }

        [HttpPost]
        public ActionResult Post(KillStatScrapy model)
        {
            //ModelBaseReturn retorno = null;
            try
            {
                //retorno = _killStatsService.SaveScrapyPlayer(player);

                // if (retorno.Status == System.Net.HttpStatusCode.Created)
                // {
                //     retorno.UrlCreated = Url.Action("Get", "KillStats", new { name = player.Name });
                // }

                // return ReturnBasedServiceLayer(retorno);
                return null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}