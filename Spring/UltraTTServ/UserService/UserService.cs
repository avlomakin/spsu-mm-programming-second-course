using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using DatabaseAccess;
using StatDto = UserService.Dto.StatDto;
using UserDto = UserService.Dto.UserDto;

namespace UserService
{

    public class UserService : IUserService
    {
        //TODO:NINJECT
        public UserDAO UserDao { private get; set; }
        public StatDAO StatDao { private get; set; }

        public UserService()
        {
            UttContext context = new UttContext();
            UserDao = new UserDAO()
            {
                Context =  context
            };

            StatDao = new StatDAO()
            {
                Context = context
            };
        }

        #region SECURITY

        public UserDto Auth(string username, string password)
        {
            Console.WriteLine(username + " connected");

            try
            {
                var user = UserDao.Validate(username, CalculateHash(password));

                //TODO: REMASTER IT!!!!!
                var roles = new List<int> { (int)Role.Adminsitrator, (int)Role.User };
                return new UserDto
                {
                    Username = user.Username,
                    Roles = roles
                };
            }
            catch (Exception)
            {
                throw new FaultException(new FaultReason("auth failed"));
            }




        }

        public void Reg(string username, string password)
        {

            try
            {
                var hash = CalculateHash(password);
                UserDao.CreateUser(username, hash);
                StatDao.CreatetStat(username);
                Console.WriteLine(username + " reged");
            }
            catch (Exception)
            {
                throw new FaultException(new FaultReason("reg failed"));
            }

        }

        private static string CalculateHash(string textPassword)
        {
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(textPassword);

            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);

            return Convert.ToBase64String(hash);
        }


        #endregion


        #region SOCIAL


        public List<UserDto> GetTop()
        {
            return StatDao.GetTop().Select(i => new UserDto(i.User.Username, i.Score)).ToList();
        }

        public int GetScore(string username)
        {
            try
            {
                return StatDao.GetScore(username);
            }
            catch (Exception)
            {
                throw new FaultException(new FaultReason("failed"));
            }
        }

        public StatDto GetStat(string username)
        {
            try
            {
                var stat = StatDao.GetStat(username);
                var result = new StatDto();
                result.Score = stat.Score;
                result.CrossWinrate = Math.Round(stat.WonCross / (double) stat.PlayedCross, 2);
                result.NoughtWinrate = Math.Round(stat.WonNought / (double)stat.PlayedNought, 2);
                result.TotalWinrate = Math.Round((stat.WonCross + stat.WonNought) /
                                      (double) (stat.PlayedCross + stat.PlayedNought), 2);

                return result;
            }
            catch (Exception)
            {
                throw new FaultException(new FaultReason("Blabla"));
            }
        }

        #endregion

    }
}
