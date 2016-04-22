namespace RankingsTable.UI.Mapping
{
    internal interface IDTOMapper
    {
        TOut Map<TIn, TOut>(TIn source);
    }
}
