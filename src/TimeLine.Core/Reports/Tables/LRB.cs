using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TimeLine.Reports.Tables
{
    public class LRB
    {
        /// <summary>
        /// 
        /// </summary>
        public string SECURITYCODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string REPORTTYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime REPORTDATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TOTALOPERATEREVE { get; set; }
        /// <summary>
        /// 营业收入
        /// </summary>
        [Display(Name = "营业收入")]
        public string OPERATEREVE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INTREVE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PREMIUMEARNED { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMREVE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHERREVE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TOTALOPERATEEXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OPERATEEXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INTEXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMEXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RDEXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SURRENDERPREMIUM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NETINDEMNITYEXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NETCONTACTRESERVE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string POLICYDIVIEXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RIEXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHEREXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OPERATETAX { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SALEEXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MANAGEEXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FINANCEEXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ASSETDEVALUELOSS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FVALUEINCOME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INVESTINCOME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INVESTJOINTINCOME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EXCHANGEINCOME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OPERATEPROFIT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NONOPERATEREVE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NONLASSETREVE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NONOPERATEEXP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NONLASSETNETLOSS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMPROFIT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INCOMETAX { get; set; }
        /// <summary>
        /// 净利润
        /// </summary>
        [Display(Name = "净利润")]
        public string NETPROFIT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMBINEDNETPROFITB { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PARENTNETPROFIT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MINORITYINCOME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KCFJCXSYJLR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BASICEPS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DILUTEDEPS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHERCINCOME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PARENTOTHERCINCOME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MINORITYOTHERCINCOME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMCINCOME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PARENTCINCOME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MINORITYCINCOME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TOTALOPERATEREVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OPERATEREVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INTREVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PREMIUMEARNED_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMREVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHERREVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TOTALOPERATEEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OPERATEEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INTEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RDEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SURRENDERPREMIUM_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NETINDEMNITYEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NETCONTACTRESERVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string POLICYDIVIEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RIEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHEREXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OPERATETAX_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SALEEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MANAGEEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FINANCEEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ASSETDEVALUELOSS_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FVALUEINCOME_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INVESTINCOME_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INVESTJOINTINCOME_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EXCHANGEINCOME_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OPERATEPROFIT_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NONOPERATEREVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NONLASSETREVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NONOPERATEEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NONLASSETNETLOSS_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMPROFIT_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INCOMETAX_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NETPROFIT_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMBINEDNETPROFITB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PARENTNETPROFIT_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MINORITYINCOME_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KCFJCXSYJLR_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BASICEPS_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DILUTEDEPS_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHERCINCOME_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PARENTOTHERCINCOME_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MINORITYOTHERCINCOME_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMCINCOME_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PARENTCINCOME_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MINORITYCINCOME_YOY { get; set; }
        /// <summary>
        /// 人民币
        /// </summary>
        public string CURRENCY { get; set; }
    }
}
