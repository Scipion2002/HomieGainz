using HomieGainz.ApplicationDb.Db;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace HomieGainz.Api.ApplicationDb.Handler
{
    public class BasicAuth : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ApplicationDbContext DbContext;

        public BasicAuth(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock, ApplicationDbContext dbContext) : base(options, logger, encoder, clock)
        {
            this.DbContext = dbContext;
        }
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No header found");

            var _headerValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(_headerValue.Parameter);
            string credentials = Encoding.UTF8.GetString(bytes);
            if (!string.IsNullOrEmpty(credentials))
            {
                string[] array = credentials.Split(":");
                string username = array[0];
                string password = array[1];
                var user = await this.DbContext.Users.FirstOrDefaultAsync(user => user.Username == username && user.Password == password);
                if (user == null)
                    return AuthenticateResult.Fail("Unauthorized");

                var claim = new[] { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claim, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            else
            {
                return AuthenticateResult.Fail("Unauthorized");
            }
        }
    }
}
