using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.IRepository
{
    public interface ILeaveTypesRepository : IGenericRepository<LeaveType>
    {
        bool LeaveTableExist();
    }
}
