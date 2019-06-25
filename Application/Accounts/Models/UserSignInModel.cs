namespace Application.Accounts.Models
{
    using Infrastructure.Exceptions;

    public class UserSignInModel
    {
        public string UserName { get; set; }
        
        public string UserPwd { get; set; }

        internal void Valid()
        {
            var isValid = string.IsNullOrEmpty(UserName) == false;

            isValid &= string.IsNullOrEmpty(UserName) == false;

            if (!isValid)
            {
                throw new AppException("Error");
            }
        }
    }
}
