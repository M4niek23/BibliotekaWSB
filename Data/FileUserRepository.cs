using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BibliotekaWSB.Data;

public class FileUserRepository : IUserRepository
{
    private string _filePath = "users.json";

    // DTO do serializacji i deserializacji
    private class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime LastLogin { get; set; }
        public string Role { get; set; } // "Student" lub "Staff"
        public string StudentNumber { get; set; } // jeśli Student
        public string Position { get; set; } // jeśli Staff
    }

    private List<User> _users;

    public FileUserRepository()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            var dtos = JsonSerializer.Deserialize<List<UserDto>>(json) ?? new List<UserDto>();
            _users = dtos.Select(ToUser).ToList();
        }
        else
        {
            _users = new List<User>();
            Save();
        }
    }

    private void Save()
    {
        var dtos = _users.Select(ToDto).ToList();
        var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    private UserDto ToDto(User user)
    {

        var dto = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            PasswordHash = user.PasswordHash,
            FullName = user.FullName,
            Email = user.Email,
            Phone = user.Phone,
            LastLogin = user.LastLogin,
            Role = user.Role
        };

        if (user is Student s)
        {
            dto.StudentNumber = s.StudentNumeber;
        }
        else if (user is Staff staff)
        {
            dto.Position = staff.Position;
        }

        return dto;
    }

    private User ToUser(UserDto dto)
    {
        if (dto.Role == "Student")
        {
            var student = new Student(dto.Id, dto.Username, dto.PasswordHash, dto.FullName, dto.StudentNumber, dto.Email, dto.Phone)
            {
                LastLogin = dto.LastLogin
            };
            return student;
        }
        else if (dto.Role == "Staff")
        {
            var staff = new Staff(dto.Id, dto.Username, dto.PasswordHash, dto.FullName, dto.Email, dto.Phone, dto.Position)
            {
                LastLogin = dto.LastLogin
            };
            return staff;
        }
        else
        {
            throw new Exception("Nieznany typ użytkownika w danych: " + dto.Role);
        }
    }

    public void Add(User entity)
    {
        _users.Add(entity);
        Save();
    }
    public void Update(User entity)
    {
        // Szukamy użytkownika w liście po Id (lub innym unikalnym polu)
        var existingUserIndex = _users.FindIndex(u => u.Id == entity.Id);

        if (existingUserIndex != -1)
        {
            // Nadpisujemy całą referencję (lub możesz zaktualizować poszczególne pola)
            _users[existingUserIndex] = entity;
            Save();
        }
        else
        {
            // Możesz np. rzucić wyjątek lub dodać go, jeśli wolisz
            throw new InvalidOperationException("Nie znaleziono użytkownika do zaktualizowania.");
        }
    }

    public IEnumerable<User> GetAll() => _users;

    public User GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public User GetByUsername(string username) => _users.FirstOrDefault(u => u.Username == username);

    public void Remove(User entity)
    {
        _users.Remove(entity);
        Save();
    }

}