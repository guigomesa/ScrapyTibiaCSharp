﻿using Hangfire;
using System;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database.Sql;
using TibiaApi.Repository;
using static TibiaApi.Comum.Constantes;

namespace TibiaApi.Service
{
    [Queue(FilasHangfire.WORLD_SERVICE)]
    public class WorldService : BasicService, IWorldService

    {
        private IWorldRepository _repository;

        public WorldService(IWorldRepository repository)
        {
            _repository = repository;
        }

        [Queue(FilasHangfire.WORLD_SERVICE)]
        public ModelBaseReturn SaveFromScrapy(WorldScrapy scrapy)
        {
            var isCreated = true;

            try
            {
                var world = this.FindByName(scrapy.Name);

                isCreated = world == null;

                if (world == null)
                {
                    world = new World
                    {
                        Name = scrapy.Name,
                        CreationDate = DateTime.Now,
                        Location = scrapy.Location,
                        PvpType = scrapy.PvpStyle,
                        ScrapyData = DateTime.Now
                    };
                }
                else
                {
                    world.PvpType = scrapy.PvpStyle;
                    world.ScrapyData = scrapy.ScrapyData;
                }

                this.SaveOrUpdate(world);

                world.Statistics.Add(new Stats
                {
                    WorldId = world.Id,
                    RegisterDate = scrapy.ScrapyData,
                    Status = scrapy.StatusWorld,
                    TotalPlayerOnline = scrapy.NumberPlayersOnline,
                });

                _repository.Save();

                scrapy.Id = Convert.ToInt32(world.Id);
                scrapy.ScrapyData = world.ScrapyData;
            }
            catch (Exception ex)
            {
                return CreateReturnErrorInternal(ex.Message);
            }

            if (isCreated)
            {
                return CreateReturnCreated();
            }
            else
            {
                return CreateReturnOk(scrapy);
            }
        }

        public World FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public ModelBaseReturn GetAllWorldsNames()
        {
            try
            {
                return CreateReturnOk(_repository.GetAllWorldsNames());
            }
            catch (Exception ex)
            {
                return CreateReturnErrorInternal(ex.Message);
            }
        }
    }
}
