
using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;

namespace BibliotekaWSB.Services;

public class UserService
{
    private IUserRepository _userRepository; // Repozytorium użytkowników
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public User GetUser(string username)
    {
        return _userRepository.GetByUsername(username);
    }
}

