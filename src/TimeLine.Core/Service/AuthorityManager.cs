using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeLine.Authorization.Users;
using TimeLine.Axis.Lines;

namespace TimeLine.Service
{
    public class AuthorityManager : DomainService, IAuthorityManager
    {
        public bool IsCreatedUser(User user, ICreationAudited entity)
        {
            if (user == null || entity == null)
                return false;

            if (user.Id == entity.CreatorUserId)
                return true;

            return false;
        }

        public bool IsCreatedUser(long id, ICreationAudited entity)
        {
            if (entity == null)
                return false;

            if (id == entity.CreatorUserId)
                return true;

            return false;
        }

        public bool HasAuthority(User user, TimeAxis line, params AuthorityType[] types)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return HasAuthority(user.Id, line, types);
        }

        public bool HasAuthority(long id, TimeAxis line, params AuthorityType[] types)
        {
            if (line == null)
                throw new ArgumentNullException(nameof(line));
            if (types == null || types.Count() == 0)
                return true;

            var hasAuth = line.GetAuthorities(id);

            var _t =  types.Except(hasAuth);

            //若为开放状态则不验证查看权限
            if (line.IsPublic)
                _t = _t.Where(x => x != AuthorityType.View);

            return _t.Count() == 0;
        }

        public TimeAxis AssignTo(User user, TimeAxis line, AuthorityType type)
        {
            var auth = new TimeAxisAuthority(user, type);

            return AssignTo(user, line, auth);
        }

        public TimeAxis AssignTo(User user, TimeAxis line, TimeAxisAuthority auth)
        {
            if (user == null || line == null || auth == null)
                throw new ArgumentNullException();

            if (HasAuthority(user, line, auth.AuthorityType))
                return line;

            line.AddAuth(auth);
            user.AddAuth(auth);

            return line;
        }

        public TimeAxis AssignNo(User user, TimeAxis line, AuthorityType auth)
        {
            if (user == null || line == null)
                throw new ArgumentNullException();

            line.RemoveAuth(auth, user);
            user.RemoveAuth(auth);

            return line;
        }
        
        public TimeAxis AssignAllTo(User user, TimeAxis line)
        {
            AssignTo(user, line, AuthorityType.View);
            AssignTo(user, line, AuthorityType.AddItem);
            AssignTo(user, line, AuthorityType.AuditItem);
            AssignTo(user, line, AuthorityType.DeleteItem);
            AssignTo(user, line, AuthorityType.EditItem);

            return line;
        }

    }
}
