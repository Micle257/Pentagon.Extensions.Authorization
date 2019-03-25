// -----------------------------------------------------------------------
//  <copyright file="ClaimValueTypeExtensions.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Pentagon.Extensions.Authorization
{
    using System.Security.Claims;

    public static class ClaimValueTypeExtensions
    {
        public static Claim ToClaim(this IClaimValueType claimValueType) => new Claim(claimValueType.Type, claimValueType.Value);
    }
}