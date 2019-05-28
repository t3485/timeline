using Abp.Domain.Entities.Auditing;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Authorization.Users;
using TimeLine.Axis.Lines;

namespace TimeLine.Service
{
    public interface IAuthorityManager : IDomainService
    {
        /// <summary>
        /// 检查是否为创建者
        /// </summary>
        /// <param name="user"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool IsCreatedUser(User user, ICreationAudited entity);

        /// <summary>
        /// 检查是否为创建者
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool IsCreatedUser(long id, ICreationAudited entity);

        /// <summary>
        /// 检查时间轴权限
        /// </summary>
        /// <param name="user"></param>
        /// <param name="line"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        bool HasAuthority(User user, TimeAxis line, params AuthorityType[] types);

        /// <summary>
        /// 检查时间轴权限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="line"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        bool HasAuthority(long id, TimeAxis line, params AuthorityType[] types);

        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="user"></param>
        /// <param name="line"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        TimeAxis AssignTo(User user, TimeAxis line, AuthorityType type);

        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="user"></param>
        /// <param name="line"></param>
        /// <param name="auth"></param>
        /// <returns></returns>
        TimeAxis AssignTo(User user, TimeAxis line, TimeAxisAuthority auth);

        /// <summary>
        /// 分配所有权限
        /// </summary>
        /// <param name="user"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        TimeAxis AssignAllTo(User user, TimeAxis line);
    }
}
