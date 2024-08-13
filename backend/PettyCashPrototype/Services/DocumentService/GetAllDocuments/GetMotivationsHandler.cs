namespace PettyCashPrototype.Services.MotivationService.GetMotivations
{
    public class GetMotivationsHandler
    {
        private IMotivationsState state = null!;

        public void setState(IMotivationsState state) => this.state = state;

        public async Task<IEnumerable<Motivation>> request(PettyCashPrototypeContext db, int requisitionId = 0)
        {
            IEnumerable<Motivation> motivations = await state.GetMotivations(db, requisitionId);
            return motivations;
        }
    }
}
