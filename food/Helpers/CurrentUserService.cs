namespace food
{
    public class CurrentUserService:ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor) 
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
        public string GetCurrentUsername()
        {
            return httpContextAccessor.HttpContext.User.Identity.Name;
        }
    }
}
