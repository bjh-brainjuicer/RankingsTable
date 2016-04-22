namespace RankingsTable.UI.Mapping
{
    using AutoMapper;

    using RankingsTable.EF.Entities;
    using RankingsTable.UI.Models;

    internal class DTOMapper : IDTOMapper
    {
        private readonly IMapper mapper;

        public DTOMapper()
        {
            this.mapper = new MapperConfiguration(
                c =>
                    {
                        c.CreateMap<Season, BasicSeasonDTO>();
                    }).CreateMapper();

        }

        public TOut Map<TIn, TOut>(TIn source)
        {
            return this.mapper.Map<TIn, TOut>(source);
        }
    }
}
