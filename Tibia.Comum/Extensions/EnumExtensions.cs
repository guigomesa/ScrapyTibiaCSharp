using TibiaApi.Comum.Utils;

namespace TibiaApi.Comum.Extensions
{
    public static class EnumExtensions
    {
        public static PvpType PvpSite(string pvp)
        {
            switch (pvp.ToLower())
            {
                case ("open pvp"):
                    return PvpType.OpenPvp;
                case "optional pvp":
                    return PvpType.OptionalPvp;
                case "retro open pvp":
                    return PvpType.RetroOpenPvp;
                case "retro hardcore pvp":
                    return PvpType.RetroHardCorePvp;
                case "hardcore pvp":
                    return PvpType.HardCorePvp; ;
                default:
                    return PvpType.Undefined;
            }
        }
        public static Profession ProfessionSite(string profession)
        {
            switch (profession.ToLower())
            {
                case "knight":
                    return Profession.Knight;
                case "druid":
                    return Profession.Druid;
                case "paladin":
                    return Profession.Paladin;
                case "sorcerer":
                    return Profession.Sorcerer;
                case "elite knight":
                    return Profession.EliteKnight;
                case "elder druid":
                    return Profession.ElderDruid;
                case "royal paladin":
                    return Profession.RoyalPaladin;
                case "master sorcerer":
                    return Profession.MasterSorcerer;
                default:
                    return Profession.Undefined;
            }
        }
    }
}
