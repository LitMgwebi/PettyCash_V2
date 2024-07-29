namespace PettyCashPrototype.Services.MotivationService.GetMotivations
{
    public class GetAllMotivationsState : IMotivationsState
    {
        public async Task<IEnumerable<Motivation>> GetMotivations(PettyCashPrototypeContext db, int requisitionId)
        {
            IEnumerable<Motivation> motivations = await db.Motivations
                .Where(x => x.IsActive == true)
                .AsNoTracking()
                .ToListAsync();

            if (motivations == null)
                throw new Exception("System could not find any motivations.");

            return motivations;
        }
    }
}
