using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Rookie.AssetManagement.Business.Extensions
{
    public static class GenerateUserNameExtension
    {
        public static string GenerateUserName(string firstName, string lastName, UserManager<User> _userManager)
        {
            var firstChars = lastName.Where((ch, index) => ch != ' '
                                && (index == 0 || lastName[index - 1] == ' '));
            string userName = firstName.ToLower();
            foreach (var c in firstChars)
            {
                userName += c.ToString().ToLower();
            }
            var countTheSameUserName = 0;
            var letters = "abcdefghijklmnopqrstuvwxyz";

            var listTheSameUserName = _userManager.Users.Any(s => s.UserName == userName);
            if (listTheSameUserName)
            {
                countTheSameUserName = (from u in _userManager.Users
                                        where u.UserName != userName &&
                                            u.UserName.StartsWith(userName) &&
                                            !letters.Contains(u.UserName.Substring(userName.Length, 1))
                                        select u
                                        ).Count();
                countTheSameUserName++;
            }

            userName = countTheSameUserName != 0 ? userName + (countTheSameUserName).ToString() : userName;
            return userName;
        }
    }
}

