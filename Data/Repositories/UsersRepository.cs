using JobFinder.Models;
using JobFinder.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Data.Repositories
{
    public class UsersRepository
    {
        private readonly DBApplicationContext _dbContext;

        public UsersRepository(DBApplicationContext context)
        {
            _dbContext = context;
        }

        public List<JobFinderUser> getApplicationUsers()
        {
            return _dbContext.JobFinderUsers.Include(j => j.UserRole).OrderBy(u => u.UserRole).ToList();
        }

        public JobFinderUser findUserById(int? id)
        {
            return _dbContext.JobFinderUsers.Find(id);
        }

        public List<JobFinderUser> GetUsersWithRoleHR()
        {
            return _dbContext.JobFinderUsers.Include(u => u.UserRole).Where(u => u.UserRole.RoleName == "hr").ToList();
        }

        public int addUser(JobFinderUser jobFinderUser)
        {
            jobFinderUser.Password = sha256_hash(jobFinderUser.Password);
            jobFinderUser.UserAddedAt = DateTime.Now;
            jobFinderUser.UserUpdatedAt = DateTime.Now;
            _dbContext.JobFinderUsers.Add(jobFinderUser);
            _dbContext.SaveChanges();
            return jobFinderUser.UserId;
        }

        public void editUser(JobFinderUser targetUser)
        {
            _dbContext.Update(targetUser);
            _dbContext.SaveChanges();
        }

        public void deleteUser(JobFinderUser user, bool status)
        {
            if(status)
            {
                user.IsActive = false;
            } else
            {
                user.IsActive = true;
            }
            _dbContext.JobFinderUsers.Update(user);
            _dbContext.SaveChanges();
        }

        public bool UserEmailExists(string email)
        {
            return _dbContext.JobFinderUsers.Any(user => user.Email == email);
        }

        public bool UserExists(int id)
        {
            return _dbContext.JobFinderUsers.Any(e => e.UserId == id);
        }

        public async Task<bool> isCredentialsMatching(string email, string password)
        {
            return await _dbContext.JobFinderUsers.AnyAsync((user) => user.Email == email && user.Password == sha256_hash(password));
        }

        public async Task<bool> isApproved(string email)
        {
            return await _dbContext.JobFinderUsers.AnyAsync(u => u.Email == email && u.IsApproved == true);
        }

        public async Task<bool> isActive(string email)
        {
            return await _dbContext.JobFinderUsers.AnyAsync(u => u.Email == email && u.IsActive == true);
        }

        public string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public List<Claim> identifyAndSetClaims(UserLoginViewModel user)
        {


            var dbUserId = _dbContext.JobFinderUsers.Single(u => u.Email == user.UserEmail).UserId;
            var dbUserRole = _dbContext.JobFinderUsers.Include(u => u.UserRole).SingleOrDefault(u => u.Email == user.UserEmail).UserRole.RoleName;
            var dbUserLastName = _dbContext.JobFinderUsers.Single(u => u.Email == user.UserEmail).LastName;
            var dbUserFirstName = _dbContext.JobFinderUsers.Single(u => u.Email == user.UserEmail).FirstName;
            var dbUserFullName = $"{dbUserLastName} {dbUserFirstName}";

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, $"{dbUserFullName}"));
            claims.Add(new Claim(ClaimTypes.Email, $"{user.UserEmail}"));
            claims.Add(new Claim(ClaimTypes.Role, $"{dbUserRole}"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, $"{dbUserId}"));
            return claims;
        }


    }
}
