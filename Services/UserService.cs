
using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Services;

public class UserService
{
    private IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public User GetUser(string username)
    {
        return _userRepository.GetByUsername(username);
    }
}

