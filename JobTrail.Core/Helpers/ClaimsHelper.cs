using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JobTrail.Core.Helpers
{
    public static class ClaimsHelper
    {
        public static Guid GetId(IEnumerable<Claim> claims) => Guid.Parse(claims.FirstOrDefault(m => m.Type == ClaimTypes.Sid).Value);
    }
}
