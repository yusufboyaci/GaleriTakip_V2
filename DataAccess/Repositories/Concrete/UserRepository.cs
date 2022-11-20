using DataAccess.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class UserRepository : Repository<User>
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        /// <summary>
        /// Kullanıcı adına göre kullanıcı yı getirir.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Kullanıcı döner.</returns>
        public User FindByUserName(string username)
        {
            return GetByDefault(x => x.Username == username);
        }
        /// <summary>
        /// Database de kullanıcının kullanıcı adı ve şifresine göre kontrol eden metottur.
        /// </summary>
        /// <param name="kullaniciAdi"></param>
        /// <param name="sifre"></param>
        /// <returns>Kullanıcı varsa True kullanıcı yoksa False döner.</returns>
        public bool CheckCredential(string username, string password)
        {
            return Any(x => x.Username == username && x.Password == password);   
        }   
    }
}
