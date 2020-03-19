namespace TibiaApi.Comum.Utils
{
    public enum Sex
    {
        Female= 20,
        Male= 25
    }

    public enum Profession
    {
        Undefined = 1,
        Knight=21,
        Druid=22,
        Paladin=23,
        Sorcerer=24,
        EliteKnight=100,
        ElderDruid=200,
        RoyalPaladin=300,
        MasterSorcerer=400
    }

    public enum PvpType
    {
        Undefined = 1,
        OpenPvp= 20,
        OptionalPvp,
        RetroOpenPvp,
        RetroHardCorePvp,
        HardCorePvp
    }

    public enum WorldTransferStatus
    {
        Open,
        Blocked
    }

    public enum StatusWorld
    {
        Unkow= 1,
        Online = 20,
        Offline,
        Maintenance,
    }

    public enum AccountStatus
    {
        FreeAccount,
        PremiumAccount
    }
}