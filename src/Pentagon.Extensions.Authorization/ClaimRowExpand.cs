// -----------------------------------------------------------------------
//  <copyright file="ClaimRowExpand.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Pentagon.Extensions.Authorization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using JetBrains.Annotations;

    /// <summary> Represents a claim values grouped per type. </summary>
    public readonly struct ClaimRowExpand
    {
        public ClaimRowExpand([NotNull] string type, [NotNull] IEnumerable<string[]> values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            Type = type ?? throw new ArgumentNullException(nameof(type));

            Values = values.ToList().AsReadOnly();
        }

        [NotNull]
        public string Type { get; }

        [NotNull]
        public IReadOnlyCollection<string[]> Values { get; }

        [NotNull]
        public static IEnumerable<ClaimRowExpand> Parse([NotNull] IEnumerable<Claim> claims)
        {
            if (claims == null)
                throw new ArgumentNullException(nameof(claims));

            // converts flat-array-representation to collection
            // values are normalized and unique
            var categorization = claims.GroupBy(a => a.Type);

            foreach (var category in categorization)
            {
                // get values normalized
                var normalized = category.Where(a => a != null)
                                         .Select(b => b.Value)
                                         .Where(a => a != null)
                                         .Select(b => b.Trim().ToLowerInvariant())
                                         .Distinct();

                yield return new ClaimRowExpand(category.Key ?? string.Empty, normalized.Select(value => value.Split('.')));
            }
        }
    }
}