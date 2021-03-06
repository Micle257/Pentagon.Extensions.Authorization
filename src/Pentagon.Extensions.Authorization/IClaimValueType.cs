﻿// -----------------------------------------------------------------------
//  <copyright file="IClaimValueType.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Pentagon.Extensions.Authorization
{
    using JetBrains.Annotations;

    [PublicAPI]
    public interface IClaimValueType
    {
        string Type { get; }

        string BaseValue { get; }

        string AppendValue { get; }

        string Value { get; }
    }
}