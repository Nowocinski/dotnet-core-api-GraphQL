namespace GraphQL.API.Repositories
{
    public class TechEventRepository : ITechEventRepository
    {
        private readonly TechEventDBContext _context;

        public TechEventRepository(TechEventDBContext context)
        {
            this._context = context;
        }

        public async Task<List<Participant>> GetParticipantInfoByEventId(int id)
        {
            return await (from ep in this._context.EventParticipants
                          join p in this._context.Participants on ep.ParticipantId equals p.ParticipantId
                          where ep.EventId == id
                          select p).ToListAsync();
        }

        public async Task<TechEventInfo> GetTechEventById(int id)
        {
            return await Task.FromResult(_context.TechEventInfos.FirstOrDefault(i => i.EventId == id));
        }

        public async Task<TechEventInfo[]> GetTechEvents()
        {
            return _context.TechEventInfos.ToArray();
        }
    }
}