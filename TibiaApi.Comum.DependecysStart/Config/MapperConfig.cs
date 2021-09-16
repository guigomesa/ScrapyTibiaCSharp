
using AutoMapper;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Database.Sql;

namespace TibiaApi.Web.Config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //CreateMap<DomainUser, UserViewModel>();
            CreateMap<World, WorldScrapy>();
            CreateMap<WorldScrapy, World>();


            CreateMap<PlayerScrapy, Player>()
                .ForMember(src => src.ResidenceCity, opt => opt.MapFrom(dst => dst.CityResidence));

            CreateMap<Player, PlayerScrapy>()
                .ForMember(src => src.CityResidence, opt => opt.MapFrom(dst => dst.ResidenceCity));

            CreateMap<KillStat, KillStatScrapy>();
            CreateMap<KillStatScrapy, KillStat>();
        }
    }
}