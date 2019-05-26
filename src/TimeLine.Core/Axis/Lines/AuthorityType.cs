using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Axis.Lines
{
    public enum AuthorityType
    {
        /// <summary>
        /// 查看
        /// </summary>
        View = 0,
        /// <summary>
        /// 添加
        /// </summary>
        AddItem = 1,
        /// <summary>
        /// 删除
        /// </summary>
        DeleteItem = 2,
        /// <summary>
        /// 编辑
        /// </summary>
        EditItem = 3,
        /// <summary>
        /// 审核
        /// </summary>
        AuditItem = 4,
        /// <summary>
        /// 禁止查看
        /// </summary>
        Ban
    }
}
