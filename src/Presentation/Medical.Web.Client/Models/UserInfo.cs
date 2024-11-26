using System;
using System.Security.Claims;

namespace Medical.Web.Client.Models;

// Add properties to this class and update the server and client AuthenticationStateProviders
// to expose more information about the authenticated user to the client.
public sealed class UserInfo
{
    public required string UserId { get; init; }
    public required string Name { get; init; }
    public required string NickName { get; init; }
    public required string Picture { get; init; }
    public required string Email { get; init; }
    public required string EmailVerified { get; init; }
    public required string FamilyName { get; init; }
    //public required string Scope { get; init; }

    public const string UserIdClaimType = "sub";
    public const string NameClaimType = "name";
    public const string NickNameClaimType = "nickname";
    public const string PictureClaimType = "picture";
    public const string EmailClaimType = "email";
    public const string EmailVerifiedClaimType = "email_verified";
    public const string FamilyNameClaimType = "family_name";
    //public const string ScopeClaimType = "scope";

    public static UserInfo FromClaimsPrincipal(ClaimsPrincipal principal) =>
        new()
        {
            UserId = GetRequiredClaim(principal, UserIdClaimType),
            Name = GetRequiredClaim(principal, NameClaimType),
            NickName = GetClaim(principal, NickNameClaimType),
            Picture = GetClaim(principal, PictureClaimType),
            Email = GetClaim(principal, EmailClaimType),
            EmailVerified = GetClaim(principal, EmailVerifiedClaimType),
            FamilyName = GetClaim(principal, FamilyNameClaimType),
            //Scope = "Weather.Get"
        };

    public ClaimsPrincipal ToClaimsPrincipal() =>
        new(new ClaimsIdentity(
            [new(UserIdClaimType, UserId), new(NameClaimType, Name), new(NickNameClaimType, NickName), new(PictureClaimType, Picture), new(EmailClaimType, Email), new(EmailVerifiedClaimType, EmailVerified), new(FamilyNameClaimType, FamilyName)],
            authenticationType: nameof(UserInfo),
            nameType: NameClaimType,
            roleType: null));

    //, new(ScopeClaimType, Scope)
    private static string GetRequiredClaim(ClaimsPrincipal principal, string claimType) =>
        principal.FindFirst(claimType)?.Value ?? throw new InvalidOperationException($"Could not find required '{claimType}' claim.");

    private static string GetClaim(ClaimsPrincipal principal, string claimType) =>
        principal.FindFirst(claimType)?.Value ?? string.Empty;
}
