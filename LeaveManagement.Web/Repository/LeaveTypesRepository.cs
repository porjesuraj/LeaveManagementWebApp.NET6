using LeaveManagement.Web.Data;
using LeaveManagement.Web.IRepository;

namespace LeaveManagement.Web.Repository
{
    public class LeaveTypesRepository : GenericRepository<LeaveType>, ILeaveTypesRepository
    {
        private readonly ApplicationDbContext _context;
        public LeaveTypesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool LeaveTableExist()
        {
            return _context.LeaveTypes != null;


        }
    }
}