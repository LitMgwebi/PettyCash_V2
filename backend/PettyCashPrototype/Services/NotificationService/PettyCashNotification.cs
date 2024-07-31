namespace PettyCashPrototype.Services.NotificationService
{
    public class PettyCashNotification: BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        //private readonly IMailService _email;

        public PettyCashNotification(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (IsWeekday() && IsWithinWorkingHours())
                {
                    using (var scope = serviceScopeFactory.CreateScope())
                    {
                        IRequisition _requisition = scope.ServiceProvider.GetRequiredService<IRequisition>();

                        var requisitions = await _requisition.GetAll("tracking");

                        foreach(var requisition in requisitions)
                        {
                            TimeSpan? dayAfterIssue = requisition.IssueDate!.Value.AddDays(1) - requisition.IssueDate;
                            await Task.Delay(dayAfterIssue!.Value, cancellationToken);
                            // ***** emaill sending code goes here *****


                        }
                    }
                }
                else
                {
                    await Task.Delay(TimeSpan.FromMinutes(15), cancellationToken);
                }
            }
        }

        bool IsWeekday()
        {
            var today = DateTime.Today.DayOfWeek;
            return today != DayOfWeek.Saturday && today != DayOfWeek.Sunday;
        }
        // Helper method to check if it's within working hours (8:00 AM to 4:30 PM)
        bool IsWithinWorkingHours()
        {
            var now = DateTime.Now;
            var startOfWorkingHours = now.Date.AddHours(8).AddMinutes(0);
            var endOfWorkingHours = now.Date.AddHours(16).AddMinutes(30);
            return now >= startOfWorkingHours && now <= endOfWorkingHours;
        }
    }
}
