

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hangfire;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database;
using TibiaApi.Repository;
using static TibiaApi.Comum.Constantes;
using Microsoft.Extensions.DependencyInjection;

namespace TibiaApi.Service
{
    [Queue(FilasConstantes.PLAYER_SERVICE)]
    public class PlayerService<IPlayerRepository> : BasicService<IPlayerRepository<Player>, Player>, IPlayerService<IPlayerRepository>
    {
        private readonly IMapper _mapper;
        private IWorldRepository<World> _worldRepository;
        public PlayerService(IPlayerRepository<Player> repository
            , IMapper mapper
            , IServiceProvider serviceProvider
            , IWorldRepository<World> worldRepository
            ) : base(repository)
        {
            _mapper = mapper;
            _worldRepository = worldRepository;
        }

        [Queue(FilasConstantes.PLAYER_SERVICE)]
        public ModelBaseReturn SaveFromScrapy<TScrapy>(IList<TScrapy> models)
        {
            ModelBaseReturn retornoErro = null;
            if (models != null && models.Any())
                foreach (var item in models)
                {
                    var r = this.SaveFromScrapy(item);
                    if (r.Status == System.Net.HttpStatusCode.InternalServerError)
                        retornoErro = r;
                }

            return retornoErro ?? CreateReturnCreated();
        }

        [Queue(FilasConstantes.PLAYER_SERVICE)]
        public override ModelBaseReturn SaveFromScrapy<TScrapy>(TScrapy scrapyModel)
        {
            var model = scrapyModel as PlayerScrapy;
            var isCreated = true;

            try
            {
                var player = _repository.FindByName(model.Name);
                isCreated = player == null;

                var world = _worldRepository.FindByName(model.WorldName);

                if (player == null)
                {
                    player = new Player();
                    var novoPlayer = _mapper.Map<Player>(model);

                    player.UpdatePlayer(novoPlayer)
                        .UpdateWorld(world)
                        .AddNewHistoryScrapy(novoPlayer, world);

                }
                else
                {
                    var updatePlayer = _mapper.Map<Player>(model);
                    player
                        .UpdatePlayer(updatePlayer)
                        .UpdateWorld(world)
                        .AddNewHistoryScrapy(updatePlayer, world);
                }


                _repository.AddOrUpdate(player);
                _repository.Save();


                if (isCreated)
                {
                    return CreateReturnCreated(player.Id);
                }
                else
                {
                    var retorno = _mapper.Map<PlayerScrapy>(player);
                    return CreateReturnOk(retorno);
                }

            }
            catch (Exception ex)
            {
                return CreateReturnErrorInternal(ex.Message);
            }


        }
    }

}