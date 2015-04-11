using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COFCOsubmission.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginUser
    {
        public string UserCode{get;set;}
        /// <summary>
        /// 业务员名称
        /// </summary>
        public string UserName { get; set; }
        //对应OA业务用户登陆名
        public string OaAccount { get; set; }
        public string OaAccountName { get; set; }

    }
}