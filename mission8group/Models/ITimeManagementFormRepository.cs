namespace mission8group.Models
{
    public interface ITimeManagementFormRepository : IRepository<TimeManagementForm>
    {
        IEnumerable<TimeManagementForm> GetIncompleteTasks();
        IEnumerable<TimeManagementForm> GetTasksByQuadrant(int quadrant);
    }
}