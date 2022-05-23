namespace GraphQL.API.Infrastructure
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<TechEventInfo> GetTechEvent([Service] TechEventDBContext context) =>
            context.TechEventInfos;
    }
}
