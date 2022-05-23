namespace GraphQL.API.Repositories
{
    public interface ITechEventRepository
    {
        Task<TechEventInfo[]> GetTechEvents();
        Task<TechEventInfo> GetTechEventById(int id);
        Task<List<Participant>> GetParticipantInfoByEventId(int id);
    }
}
