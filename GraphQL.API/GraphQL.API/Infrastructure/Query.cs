namespace GraphQL.API.Infrastructure
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<TechEventInfo>> GetTechEvents([Service] ITechEventRepository techEventRepository) =>
            await techEventRepository.GetTechEvents();

        public async Task<TechEventInfo> GetTechEvent([Service] ITechEventRepository techEventRepository, int id) =>
            await techEventRepository.GetTechEventById(id);
    }
}
