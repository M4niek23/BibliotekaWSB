using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Services;

public class AuthenticationService
{
    private IUserRepository _userRepository;
    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public User? Login(string username, string password)
    {
        User user = _userRepository.GetByUsername(username);
        if (user != null && user.VerifyPassword(password))
        {
            return user;
        }
        return null;
    }
}
