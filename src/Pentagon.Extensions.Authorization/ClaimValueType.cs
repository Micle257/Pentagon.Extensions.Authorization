// -----------------------------------------------------------------------
//  <copyright file="ClaimValueType.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Pentagon.Extensions.Authorization
{
    public abstract class ClaimValueType : IClaimValueType
    {
        protected ClaimValueType(string type, string value)
        {
            Type = type;
            BaseValue = value;
        }

        /// <inheritdoc />
        public virtual string BaseValue { get; }

        /// <inheritdoc />
        public virtual string AppendValue { get; }

        /// <inheritdoc />
        public string Type { get; }

        /// <inheritdoc />
        public abstract string Value { get; }
    }
}