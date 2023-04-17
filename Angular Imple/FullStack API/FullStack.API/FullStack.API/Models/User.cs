﻿namespace FullStack.API.Models
{
    public class User
    {
        public Guid UserId { get; set; }   
        public string name { get; set; }
        public string Email { get; set; }
        public long phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
