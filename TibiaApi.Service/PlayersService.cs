using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hangfire;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database.Sql;
using TibiaApi.Repository;
using static TibiaApi.Comum.Constantes;

namespace TibiaApi.Service
{
    [Queue(FilasHangfire.PLAYER_SERVICE)]
    public class PlayerService : BasicService, IPlayerService
    {
        private readonly IPlayerRepository _repository;
        private readonly IMapper _mapper;
        private IWorldRepository _worldRepository;
        public PlayerService(IPlayerRepository repository
            , IMapper mapper
            , IWorldRepository worldRepository
            )
        {
            _repository = repository;
            _mapper = mapper;
            _worldRepository = worldRepository;
        }

        [Queue(FilasHangfire.PLAYER_SERVICE)]
        public ModelBaseReturn SaveFromScrapy(IList<PlayerScrapy> models)
        {
            ModelBaseReturn retornoErro = null;

            if (models != null && models.Any())
            {
                var playerNames = models.Where(v => v is PlayerScrapy).Select(p => p.Name).ToArray();

                var playersInDb = _repository.FindAllByNames(playerNames);

                foreach (var item in models)
                {
                    var playerDb = playersInDb.FirstOrDefault(p => p.Name == item.Name);
                    this.SaveFromScrapy(item, playerDb);
                }
                _repository.Save();
            }

            return retornoErro ?? CreateReturnCreated();
        }

        [Queue(FilasHangfire.PLAYER_SERVICE)]
        public ModelBaseReturn SaveFromScrapy(PlayerScrapy scrapyModel)
        {
            var playerInDb = _repository.FindByName((scrapyModel as PlayerScrapy).Name);
            var retorno =  SaveFromScrapy(scrapyModel as PlayerScrapy, playerInDb);
            _repository.Save();

            return retorno;
        }

        [Queue(FilasHangfire.PLAYER_SERVICE)]
        public ModelBaseReturn SaveFromScrapy(PlayerScrapy model, Player player)
        {
            try
            {
                bool isCreated = true;

                isCreated = player == null;

                var world = player?.World ?? _worldRepository.FindByName(model.WorldName);

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