﻿using Microsoft.AspNetCore.Identity;
using MVC.Models.Account;
using System.IdentityModel.Tokens.Jwt;

namespace MVC.Repository
{
    public class UserAccountRepository : IUserStore<UserAccount>
    {

        public Task<string?> GetNormalizedUserNameAsync(UserAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Name);
        }

        public Task<string> GetUserIdAsync(UserAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string?> GetUserNameAsync(UserAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Name);
        }

        #region Metodos Nao Utilizados
        public Task<IdentityResult> CreateAsync(UserAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(UserAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(UserAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public Task<UserAccount?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UserAccount?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(UserAccount user, string? normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(UserAccount user, string? userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
