using System;
using System.Linq;
using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ECommerceRepository.BusinessLogic
{
    public class RoleRepository : IRoleRepository
    {
        public bool Add(Role role)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var roleEntity = context.Roles.Add(role);
                context.Entry(role).State = EntityState.Added;
                context.SaveChanges();

                return context.Brands.Any(p => p.Id == roleEntity.Entity.Id);
            }
        }

        public bool Update(Role role)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var roleEntity = context.Roles.SingleOrDefault(p => p.Id == role.Id);

                if (roleEntity != null)
                {
                    roleEntity.RoleName = roleEntity.RoleName;

                    context.Entry(roleEntity).State = EntityState.Modified;
                    context.Roles.Update(roleEntity);
                    context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool Delete(int roleId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var roleEntity = context.Roles.SingleOrDefault(p => p.Id == roleId);

                if (roleEntity != null)
                {
                    context.Entry(roleEntity).State = EntityState.Deleted;
                    context.Roles.Remove(roleEntity);
                    context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public List<Role> GetAllRoles()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Roles.ToList();
            }
        }

        public bool RoleHasUsers(int roleId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Users.Any(p => p.RoleId == roleId);
            }
        }

        public bool RoleNameExists(Role role)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                if (role.Id != 0)
                {
                    return context.Roles.Any(p => string.Equals(p.RoleName, role.RoleName, StringComparison.InvariantCultureIgnoreCase) &&
                        p.Id != role.Id);
                }

                return context.Roles.Any(p => string.Equals(p.RoleName, role.RoleName, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public Role GetRoleById(int roleId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Roles.Single(p => p.Id == roleId);
            }
        }
    }
}