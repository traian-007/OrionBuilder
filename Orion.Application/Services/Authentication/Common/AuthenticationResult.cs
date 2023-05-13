﻿using Orion.Domain.Entities;

namespace Orion.Application.Services.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
