using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Domain.Entities
{
    /// <summary>
    ///  實體引用此介面時，實現非實體刪除，
    ///  當進行刪除時只是在資料中寫入
    ///  IsDeleted = true 
    ///  並且在爾後的搜尋中皆不會出現已經標記為true的資料紀錄
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// 將實體標記為刪除
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
