﻿namespace WebDevProject.Services
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> ReadByUsernameAsync(string username);
    }
}
