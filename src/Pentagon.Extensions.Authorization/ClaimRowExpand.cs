// -----------------------------------------------------------------------
//  <copyright file="ClaimRowExpand.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Pentagon.Extensions.Authorization
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    public class ClaimRowExpand
    {
        public string Type { get; set; }

        public List<string[]> Values { get; set; }

        public static IEnumerable<ClaimRowExpand> Parse(IEnumerable<Claim> claims)
        {
            // converts flat-array-representation to collection
            // values are normalized and unique
            var categorization = claims.GroupBy(a => a.Type);

            foreach (var category in categorization)
            {
                var row = new ClaimRowExpand
                          {
                                  Type = category.Key
                          };

                // get values normalized
                var normalized = category.Select(b => b.Value)
                                         .Select(b => b.Trim().ToLowerInvariant())
                                         .Distinct();

                row.Values = normalized.Select(value => value.Split('.')).ToList();

                yield return row;
            }
        }
    }
}