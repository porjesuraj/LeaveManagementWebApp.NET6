namespace LeaveManagement.Web.Constants
{
    public static class StringConstants
    {
        public const string USER_ROLE = "User";
        public const string ADMIN_ROLE = "Administrator";
        public const string GENERIC_ERROR_MESSAGE = "An Error Has Occurred. Please Try Again Later";
        public const string INVALID_LEAVE_REQUEST_ERROR_MESSAGE = "You  have exceeded your allocation with this request";
        public const string START_DATE_GREATER_ERROR = "The Start Date Must be Before End Date";

        //Email
        public const string EMAIL_SUBJECT_FOR_LEAVE_SUCCESS = "Leave Request Submitted Successfully";
        public const string EMAIL_BODY_FOR_LEAVE_SUCCESS = "Your Leave Request from {0:dd/MM/yyyy} to {1:dd/MM/yyyy} have been submittted for approval";
        public const string EMAIL_BODY_FOR_LEAVE_REQUEST_CHANGED = "Your Leave Request from {0:dd/MM/yyyy} to {1:dd/MM/yyyy} have been {2}";



    }
}
