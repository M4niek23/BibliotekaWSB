using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;

namespace BibliotekaWSB.Services;

public class AuthenticationService
{
    private IUserRepository _userRepository; // Repozytorium użytkowników
    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public User? Login(string username, string password)
    {
        // Sprawdzanie poprawności hasła
        User user = _userRepository.GetByUsername(username);
        if (user != null && user.VerifyPassword(password))
        {
            return user;
        }
        return null;
    }
}
