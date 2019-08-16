using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TimeLine.Axis.Lines
{
    public enum AuthorityType
    {
        /// <summary>
        /// 查看
        /// </summary>
        [Limited(Name = "查看", BasicNeed = true)]
        View = 0,
        /// <summary>
        /// 添加
        /// </summary>
        [Limited(Name = "添加")]
        AddItem = 1,
        /// <summary>
        /// 删除
        /// </summary>
        [Limited(Name = "删除")]
        DeleteItem = 2,
        /// <summary>
        /// 编辑
        /// </summary>
        [Limited(Name = "编辑")]
        EditItem = 3,
        /// <summary>
        /// 审核
        /// </summary>
        [Limited(Name = "审核")]
        AuditItem = 4,
        /// <summary>
        /// 禁止查看
        /// </summary>
        [Limited(Name = "禁止查看", Exclusive = true)]
        Ban
    }
}
