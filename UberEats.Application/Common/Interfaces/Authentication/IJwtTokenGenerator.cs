﻿
using UberEats.Domain.User;

namespace UberEats.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
