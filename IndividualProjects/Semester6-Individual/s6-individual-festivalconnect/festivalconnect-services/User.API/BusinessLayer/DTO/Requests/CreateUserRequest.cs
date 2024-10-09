using System;

namespace BusinessLayer.DTO.Requests
{
    public class CreateUserRequest
    {
        public CreateUserRequest() { }
        public string Username { get; set; } = string.Empty;
    }
}
