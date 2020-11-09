namespace Gamification.Platform.Common.Extensions
{
    public static class CoinExtensions
    {
        public static CoinDisplay ToDisplay(this Coin item)
        {
            return new CoinDisplay()
            {
                SimpleName = item.SimpleName,
                NameTranslations = item.NameTranslations
            };
        }
    }

    //public static class ActionExtensions
    //{
    //    public static ActionEvent Map(this ActionRequest item)
    //    {
    //        return new ActionEvent()
    //        {
    //            A
    //        };
    //    }
    //}
}
