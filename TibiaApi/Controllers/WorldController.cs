using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Repository;
using TibiaApi.Service;

namespace TibiaApi.Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class WorldController : BaseController
    {
        private readonly IWorldService<WorldRepository> _worldService;
        private readonly IMapper _mapper;

        public WorldController(IWorldService<WorldRepository> worldService, IMapper mapper)
        {
            _worldService = worldService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Post([FromBody] WorldScrapy model)
        {
            Comum.WebReturns.ModelBaseReturn retorno = null;
            try
            {
                retorno = _worldService.SaveFromScrapy<WorldScrapy>(model);

                if (retorno.Status == System.Net.HttpStatusCode.Created)
                {
                    retorno.UrlCreated = Url.Action("Get", "World", new { name = model.Name });
                }

                return ReturnBasedServiceLayer(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/[controller]/GetWorldNames")]
        public ActionResult<IList<string>> GetAllWorlds()
        {
            return ReturnBasedServiceLayer(_worldService.GetAllWorldsNames());
        }

        [HttpGet]
        public ActionResult<WorldScrapy> Get(string name)
        {
            var world = _worldService.FindByName(name);

            if (world == null)
            {
                return NotFound();
            }

            var retorno = _mapper.Map<WorldScrapy>(world);

            if (world.Statistics.Count() > 0)
            {
                var lastStat = world.Statistics.OrderByDescending(v => v.RegisterDate).FirstOrDefault();

                retorno.MaxPlayerOnline = lastStat.TotalPlayerOnline;
                retorno.StatusWorld = lastStat.Status;
            }

            return retorno;
        }

    }
}