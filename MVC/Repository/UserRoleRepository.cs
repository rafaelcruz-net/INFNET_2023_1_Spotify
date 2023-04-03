using Entidades;
using Microsoft.AspNetCore.Identity;
using MVC.Models.Account;

namespace MVC.Repository
{
    public class UserRoleRepository : IRoleStore<UserRole>
    {
        public Task<UserRole?> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            //Pegando os nomes dos perfils
            var rolesValues = Enum.GetValues(typeof(RoleEnum));

            foreach (var item in rolesValues)
            {
                var role = Convert.ToInt32(roleId);

                if (item.Equals(Convert.ToInt32(roleId)))
                {
                    var roleEnum = (RoleEnum)role;

                    return Task.FromResult(new UserRole()
                    {
                        Id = (int)roleEnum,
                        Name = roleEnum.ToString(),
                    });
                }

            }

            throw new Exception("Perfil não cadastrado");
        }

        public Task<UserRole?> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            //Pegando os nomes dos perfils
            var rolesName = Enum.GetNames(typeof(RoleEnum));

            foreach (var item in rolesName)
            {
                if (item.Equals(normalizedRoleName))
                {
                    var role = Enum.Parse<RoleEnum>(item);

                    return Task.FromResult(new UserRole()
                    {
                        Id = (int)role,
                        Name = item,
                    });
                }

            }

            throw new Exception("Perfil não cadastrado");
                           
        }

        public Task<string?> GetNormalizedRoleNameAsync(UserRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task<string> GetRoleIdAsync(UserRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string?> GetRoleNameAsync(UserRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }


        #region Metodos não utilizados
        public Task<IdentityResult> CreateAsync(UserRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(UserRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

       
        public Task SetRoleNameAsync(UserRole role, string? roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(UserRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(UserRole role, string? normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {

        }

        #endregion
    }
}
