using System.Threading.Tasks;

 
    public interface IAuthenticationService
    {
        Task<string> Login();
    }
 