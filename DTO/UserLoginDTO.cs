﻿namespace UserMvcApp.DTO
{
    public class UserLoginDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool KeepLoggedIn { get; set; }
    }
}
