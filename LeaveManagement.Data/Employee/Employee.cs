namespace LeaveManagement.Web.Data.Employee
{
    public class Employee: Microsoft.AspNetCore.Identity.IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? TaxId { get; set; }

        public DateTime JoiningDate { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
