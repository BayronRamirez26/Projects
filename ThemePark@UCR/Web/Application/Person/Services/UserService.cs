﻿using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
namespace UCR.ECCI.PI.ThemePark_UCR.Application.Person.Services;



public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
        
    public Task<IEnumerable<User>> GetUserCredentialsAsync()
    {
        return _userRepository.GetUserCredentialsAsync();
    }
    public Task<bool> CreateUserAsync(User userEntitie)
    {
        return _userRepository.CreateUserAsync(userEntitie);
    }
}
