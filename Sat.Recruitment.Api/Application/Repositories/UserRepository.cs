using Sat.Recruitment.Api.Domain;
using Sat.Recruitment.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sat.Recruitment.Api.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _filePath = string.Empty;

        public UserRepository()
        {
            _filePath = Directory.GetCurrentDirectory() + "/Files/Users.txt";
        }

        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }


        private async Task<List<User>> ReadUsersFromFile()
        {
            var lines = await File.ReadAllLinesAsync(_filePath);

            var users = lines.Select(line =>
            {
                var fields = line.Split(',');
                return new User
                {
                    Name = fields[0],
                    Email = fields[1],
                    Phone = fields[2],
                    Address = fields[3],
                    UserType = fields[4],
                    Money = decimal.Parse(fields[5])
                };

            }


                ).ToList();


            return users;
        }

        public async Task<List<User>> GetAll()
        {
            return await ReadUsersFromFile();
        }

        public async Task<bool> FindDuplicate(User user)
        {
            var users = await GetAll();
            return users.Any(x =>
            
                x.Email == user.Email
                || x.Phone == user.Phone
                || x.Name == user.Name
                || x.Address == user.Address
            );

        }

        public async Task<User> Add(User user)
        {
            await File.AppendAllTextAsync(_filePath, Environment.NewLine + GetUserLineToWrite(user));
            return user;
        }

        private string GetUserLineToWrite(User user)
        {
            return $"{user.Name},{user.Email},{user.Phone},{user.Address},{user.UserType}, {string.Join("", user.Money.ToString().Where(char.IsDigit))}";


        }
    }
}
