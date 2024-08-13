namespace PettyCashPrototype.Services.MotivationService.GetMotivations
{
    public interface IMotivationsState
    {
        Task<IEnumerable<Motivation>> GetMotivations(PettyCashPrototypeContext db, int requisitionId);
    }
}
