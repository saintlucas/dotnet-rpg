using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Data

{
    public class AuthRepository : IAuthRepository
    {   
        private readonly DataContext _context;

        public AuthRepository(DataContext context)//injecting through constructor
        {
            _context = context;
            
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            CreatePasswordHash(password, out[] passwordHash, out[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.User.Add(user);//adding new user through context
            await _context.SaveChangesAsync();//save changes
            ServiceResponse<id> response = new ServiceResponse<int>();
            response.Data = user.Id;
            return response;
        }

        Task<ServiceResponse<string>> Login(string username, string password)
        {

        }

        public async Task<bool> UserExists(string username)
        {
            
        }

        private void CreatePasswordHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


    }
}