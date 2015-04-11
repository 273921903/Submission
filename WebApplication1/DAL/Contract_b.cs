using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COFCOsubmission.DAL
{
    public class Contract_b
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// 主表编码
        /// </summary>
        public string Mid { get; set; }
        /// <summary>
        /// 存货编码
        /// </summary>
        public string Invcode { get; set; }
        /// <summary>
        /// 存货名称
        /// </summary>
        public string Invname { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Invspec { get; set; }
        /// <summary>
        /// 存货单位
        /// </summary>
        public string Measname { get; set; }
        /// <summary>
        /// 转换率
        /// </summary>
        public string Measrate { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 合计
        /// </summary>
        public string Nmoney { get; set; }

        public string Def1 { get; set; }

        public string Def2 { get; set; }

        public string Def3 { get; set; }
    }
}