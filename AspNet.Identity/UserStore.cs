using Microsoft.AspNet.Identity;
using System;
using System.Text;
using System.Threading.Tasks;
using IO = System.IO;

namespace AspNet.Identity.File
{
    public class UserStore : IUserStore<IdentityUser>, IUserPasswordStore<IdentityUser>
    {
        private string _filePath;
        public UserStore()
        { }

        public UserStore(string filePath)
        {
            _filePath = filePath;
        }


        public async Task DeleteAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        // 创建用户
        public async Task CreateAsync(IdentityUser user)
        {
            user.Id = Guid.NewGuid().ToString();
            using (var stream = new IO.StreamWriter(_filePath, true, Encoding.UTF8))
            {
                await stream.WriteLineAsync(user.ToString());
            }
        }

        // 根据用户名找用户
        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            using (var stream = new IO.StreamReader(_filePath))
            {
                string line;
                IdentityUser result = null;
                while ((line = await stream.ReadLineAsync()) != null)
                {
                    var user = IdentityUser.FromString(line);
                    if (user.UserName == userName)
                    {
                        result = user;
                        break;
                    }
                }
                return result;
            }
        }

        public async Task<IdentityUser> FindByIdAsync(string userId)
        {
            using (var stream = new IO.StreamReader(_filePath))
            {
                string line;
                IdentityUser result = null;
                while ((line = await stream.ReadLineAsync()) != null)
                {
                    var user = IdentityUser.FromString(line);
                    if (user.Id == userId)
                    {
                        result = user;
                        break;
                    }
                }
                return result;
            }
        }



        public async Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public async Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            return await Task.Run(() =>
            {
                return user.PasswordHash;
            });
        }

        public async Task<bool> HasPasswordAsync(IdentityUser user)
        {
            return await Task.Run(() =>
            {
                return !string.IsNullOrWhiteSpace(user.PasswordHash);
            });
        }

        public async Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            await Task.Run(() =>
            {
                user.PasswordHash = passwordHash;
            });
        }
    }
}
