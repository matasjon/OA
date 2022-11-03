using System.ComponentModel.DataAnnotations;

namespace OnAct.Auth.Model;



public record RegisterUserDto([Required] string UserName, [EmailAddress] [Required] string Email,
    [Required] string Password);

public record LoginDto(string UserName, string Password);

public record UserDto(string Id, string UserName, string Email);

//cia galimas ir refresh token
public record SuccessfulLoginDto(string AccessToken);