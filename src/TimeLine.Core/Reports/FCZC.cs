using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Reports
{
    public class ZCFZ
    {
        /// <summary>
        /// 人民币
        /// </summary>
        public string CURRENCY { get; set; }

        /// <summary>
        /// 代码
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
        /// 报告日期
        /// </summary>
        public DateTime REPORTDATE { get; set; }

        /// <summary>
        /// 货币资金
        /// </summary>
        public string MONETARYFUND { get; set; }

        /// <summary>
        /// 结算备付金
        /// </summary>
        public string SETTLEMENTPROVISION { get; set; }

        /// <summary>
        /// 拆除资金
        /// </summary>
        public string LENDFUND { get; set; }

        /// <summary>
        /// 以公允价值计量且其变动计入当期损益的金融资产
        /// </summary>
        public string FVALUEFASSET { get; set; }

        /// <summary>
        /// 交易性金融资产
        /// </summary>
        public string TRADEFASSET { get; set; }

        /// <summary>
        /// 指定为以公允价值计量且其变动计入当期损益的金融资产
        /// </summary>
        public string DEFINEFVALUEFASSET { get; set; }

        /// <summary>
        /// 应收票据
        /// </summary>
        public string BILLREC { get; set; }

        /// <summary>
        /// 应收账款
        /// </summary>
        public string ACCOUNTREC { get; set; }

        /// <summary>
        /// 预付款项
        /// </summary>
        public string ADVANCEPAY { get; set; }

        /// <summary>
        /// 应收保费
        /// </summary>
        public string PREMIUMREC { get; set; }

        /// <summary>
        /// 应收分保账款
        /// </summary>
        public string RIREC { get; set; }

        /// <summary>
        /// 应收分保合同准备金
        /// </summary>
        public string RICONTACTRESERVEREC { get; set; }

        /// <summary>
        /// 应收利息
        /// </summary>
        public string INTERESTREC { get; set; }

        /// <summary>
        /// 应收股利
        /// </summary>
        public string DIVIDENDREC { get; set; }

        /// <summary>
        /// 其他应收款
        /// </summary>
        public string OTHERREC { get; set; }

        /// <summary>
        /// 应收出口退税
        /// </summary>
        public string EXPORTREBATEREC { get; set; }

        /// <summary>
        /// 应收补贴款
        /// </summary>
        public string SUBSIDYREC { get; set; }

        /// <summary>
        /// 内部应收款
        /// </summary>
        public string INTERNALREC { get; set; }

        /// <summary>
        /// 买入返售金融资产
        /// </summary>
        public string BUYSELLBACKFASSET { get; set; }

        /// <summary>
        /// 存货
        /// </summary>
        public string INVENTORY { get; set; }

        /// <summary>
        /// 划分为持有待售的资产
        /// </summary>
        public string CLHELDSALEASS { get; set; }

        /// <summary>
        /// 一年内到期的非流动资产
        /// </summary>
        public string NONLASSETONEYEAR { get; set; }

        /// <summary>
        /// 其他流动资产
        /// </summary>
        public string OTHERLASSET { get; set; }

        /// <summary>
        /// 流动资产合计
        /// </summary>
        public string SUMLASSET { get; set; }

        /// <summary>
        /// 发放委托贷款及垫款
        /// </summary>
        public string LOANADVANCES { get; set; }

        /// <summary>
        /// 可供出售金融资产
        /// </summary>
        public string SALEABLEFASSET { get; set; }

        /// <summary>
        /// 持有至到期投资
        /// </summary>
        public string HELDMATURITYINV { get; set; }

        /// <summary>
        /// 长期应收款
        /// </summary>
        public string LTREC { get; set; }

        /// <summary>
        /// 长期股权投资
        /// </summary>
        public string LTEQUITYINV { get; set; }

        /// <summary>
        /// 投资性房地产
        /// </summary>
        public string ESTATEINVEST { get; set; }

        /// <summary>
        /// 固定资产
        /// </summary>
        public string FIXEDASSET { get; set; }

        /// <summary>
        /// 在建工程
        /// </summary>
        public string CONSTRUCTIONPROGRESS { get; set; }

        /// <summary>
        /// 工程物资
        /// </summary>
        public string CONSTRUCTIONMATERIAL { get; set; }

        /// <summary>
        /// 固定资产清理
        /// </summary>
        public string LIQUIDATEFIXEDASSET { get; set; }

        /// <summary>
        /// 生产性生物资产
        /// </summary>
        public string PRODUCTBIOLOGYASSET { get; set; }

        /// <summary>
        /// 油气资产
        /// </summary>
        public string OILGASASSET { get; set; }

        /// <summary>
        /// 无形资产
        /// </summary>
        public string INTANGIBLEASSET { get; set; }

        /// <summary>
        /// 开发支出
        /// </summary>
        public string DEVELOPEXP { get; set; }

        /// <summary>
        /// 商誉
        /// </summary>
        public string GOODWILL { get; set; }

        /// <summary>
        /// 长期待摊费用
        /// </summary>
        public string LTDEFERASSET { get; set; }

        /// <summary>
        /// 递延所得税资产
        /// </summary>
        public string DEFERINCOMETAXASSET { get; set; }

        /// <summary>
        /// 其他非流动资产
        /// </summary>
        public string OTHERNONLASSET { get; set; }

        /// <summary>
        /// 非流动资产合计
        /// </summary>
        public string SUMNONLASSET { get; set; }

        /// <summary>
        /// 资产总计
        /// </summary>
        public string SUMASSET { get; set; }

        /// <summary>
        /// 短期借款
        /// </summary>
        public string STBORROW { get; set; }

        /// <summary>
        /// 向中央银行借款
        /// </summary>
        public string BORROWFROMCBANK { get; set; }

        /// <summary>
        /// 吸收存款及同业存放
        /// </summary>
        public string DEPOSIT { get; set; }

        /// <summary>
        /// 拆入资金
        /// </summary>
        public string BORROWFUND { get; set; }

        /// <summary>
        /// 以公允价值计量且其变动计入当期损益的金融负债
        /// </summary>
        public string FVALUEFLIAB { get; set; }

        /// <summary>
        /// 交易性金融负债
        /// </summary>
        public string TRADEFLIAB { get; set; }

        /// <summary>
        /// 指定以公允价值计量且其变动计入当期损益的金融负债
        /// </summary>
        public string DEFINEFVALUEFLIAB { get; set; }

        /// <summary>
        /// 应付票据
        /// </summary>
        public string BILLPAY { get; set; }

        /// <summary>
        /// 应付账款
        /// </summary>
        public string ACCOUNTPAY { get; set; }

        /// <summary>
        /// 预收款项
        /// </summary>
        public string ADVANCERECEIVE { get; set; }

        /// <summary>
        /// 卖出回购金融资产款
        /// </summary>
        public string SELLBUYBACKFASSET { get; set; }

        /// <summary>
        /// 应付手续费及佣金
        /// </summary>
        public string COMMPAY { get; set; }

        /// <summary>
        /// 应付职工薪酬
        /// </summary>
        public string SALARYPAY { get; set; }

        /// <summary>
        /// 应交税费
        /// </summary>
        public string TAXPAY { get; set; }

        /// <summary>
        /// 应付利息
        /// </summary>
        public string INTERESTPAY { get; set; }

        /// <summary>
        /// 应付股利
        /// </summary>
        public string DIVIDENDPAY { get; set; }

        /// <summary>
        /// 应付分保账款
        /// </summary>
        public string RIPAY { get; set; }

        /// <summary>
        /// 内部应付款
        /// </summary>
        public string INTERNALPAY { get; set; }

        /// <summary>
        /// 其他应付款
        /// </summary>
        public string OTHERPAY { get; set; }

        /// <summary>
        /// 预计流动负债
        /// </summary>
        public string ANTICIPATELLIAB { get; set; }

        /// <summary>
        /// 保险合同准备金
        /// </summary>
        public string CONTACTRESERVE { get; set; }

        /// <summary>
        /// 代理买卖证券款
        /// </summary>
        public string AGENTTRADESECURITY { get; set; }

        /// <summary>
        /// 代理承销证券款
        /// </summary>
        public string AGENTUWSECURITY { get; set; }

        /// <summary>
        /// 一年内的递延收益
        /// </summary>
        public string DEFERINCOMEONEYEAR { get; set; }

        /// <summary>
        /// 应付短期债券
        /// </summary>
        public string STBONDREC { get; set; }

        /// <summary>
        /// 划分为持有待售的负债
        /// </summary>
        public string CLHELDSALELIAB { get; set; }

        /// <summary>
        /// 一年内到期的非流动负债
        /// </summary>
        public string NONLLIABONEYEAR { get; set; }

        /// <summary>
        /// 其他流动负债
        /// </summary>
        public string OTHERLLIAB { get; set; }

        /// <summary>
        /// 流动负债合计
        /// </summary>
        public string SUMLLIAB { get; set; }

        /// <summary>
        /// 长期借款
        /// </summary>
        public string LTBORROW { get; set; }

        /// <summary>
        /// 应付债券
        /// </summary>
        public string BONDPAY { get; set; }

        /// <summary>
        /// 优先股
        /// </summary>
        public string PREFERSTOCBOND { get; set; }

        /// <summary>
        /// 永续债
        /// </summary>
        public string SUSTAINBOND { get; set; }

        /// <summary>
        /// 长期应付款
        /// </summary>
        public string LTACCOUNTPAY { get; set; }

        /// <summary>
        /// 长期应付职工薪酬
        /// </summary>
        public string LTSALARYPAY { get; set; }

        /// <summary>
        /// 专项应付款
        /// </summary>
        public string SPECIALPAY { get; set; }

        /// <summary>
        /// 预计负债
        /// </summary>
        public string ANTICIPATELIAB { get; set; }

        /// <summary>
        /// 递延收益
        /// </summary>
        public string DEFERINCOME { get; set; }

        /// <summary>
        /// 递延所得税负债
        /// </summary>
        public string DEFERINCOMETAXLIAB { get; set; }

        /// <summary>
        /// 其他非流动负债
        /// </summary>
        public string OTHERNONLLIAB { get; set; }

        /// <summary>
        /// 非流动负债合计
        /// </summary>
        public string SUMNONLLIAB { get; set; }

        /// <summary>
        /// 负债合计
        /// </summary>
        public string SUMLIAB { get; set; }

        /// <summary>
        /// 实收资本（或股本）
        /// </summary>
        public string SHARECAPITAL { get; set; }

        /// <summary>
        /// 其他权益工具
        /// </summary>
        public string OTHEREQUITY { get; set; }

        /// <summary>
        /// 优先股
        /// </summary>
        public string PREFERREDSTOCK { get; set; }

        /// <summary>
        /// 永续债
        /// </summary>
        public string SUSTAINABLEDEBT { get; set; }

        /// <summary>
        /// 其他权益工具
        /// </summary>
        public string OTHEREQUITYOTHER { get; set; }

        /// <summary>
        /// 资本公积
        /// </summary>
        public string CAPITALRESERVE { get; set; }

        /// <summary>
        /// 库存股
        /// </summary>
        public string INVENTORYSHARE { get; set; }

        /// <summary>
        /// 专项储备
        /// </summary>
        public string SPECIALRESERVE { get; set; }

        /// <summary>
        /// 盈余公积
        /// </summary>
        public string SURPLUSRESERVE { get; set; }

        /// <summary>
        /// 一般风险准备
        /// </summary>
        public string GENERALRISKPREPARE { get; set; }

        /// <summary>
        /// 未确定的投资损失
        /// </summary>
        public string UNCONFIRMINVLOSS { get; set; }

        /// <summary>
        /// 未分配利润
        /// </summary>
        public string RETAINEDEARNING { get; set; }

        /// <summary>
        /// 拟分配现金股利
        /// </summary>
        public string PLANCASHDIVI { get; set; }

        /// <summary>
        /// 外币报表折算差额
        /// </summary>
        public string DIFFCONVERSIONFC { get; set; }

        /// <summary>
        /// 归属于母公司股东权益合计
        /// </summary>
        public string SUMPARENTEQUITY { get; set; }

        /// <summary>
        /// 少数股东权益
        /// </summary>
        public string MINORITYEQUITY { get; set; }

        /// <summary>
        /// 股东权益合计
        /// </summary>
        public string SUMSHEQUITY { get; set; }

        /// <summary>
        /// 负债和股东权益合计
        /// </summary>
        public string SUMLIABSHEQUITY { get; set; }

        /// <summary>
        /// 其他应收款合计
        /// </summary>
        public string TOTAL_OTHER_RECE { get; set; }

        /// <summary>
        /// 其他应付款合计
        /// </summary>
        public string TOTAL_OTHER_PAYABLE { get; set; }

        /// <summary>
        /// 应付票据及应付账款
        /// </summary>
        public string ACCOUNTBILLPAY { get; set; }

        /// <summary>
        /// 应收票据及应收账款
        /// </summary>
        public string ACCOUNTBILLREC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MONETARYFUND_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SETTLEMENTPROVISION_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LENDFUND_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FVALUEFASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TRADEFASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEFINEFVALUEFASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BILLREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ACCOUNTREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ADVANCEPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PREMIUMREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RIREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RICONTACTRESERVEREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INTERESTREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DIVIDENDREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHERREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EXPORTREBATEREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUBSIDYREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INTERNALREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BUYSELLBACKFASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INVENTORY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CLHELDSALEASS_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NONLASSETONEYEAR_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHERLASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMLASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LOANADVANCES_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SALEABLEFASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HELDMATURITYINV_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LTREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LTEQUITYINV_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ESTATEINVEST_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIXEDASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CONSTRUCTIONPROGRESS_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CONSTRUCTIONMATERIAL_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LIQUIDATEFIXEDASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PRODUCTBIOLOGYASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OILGASASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INTANGIBLEASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEVELOPEXP_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GOODWILL_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LTDEFERASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEFERINCOMETAXASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHERNONLASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMNONLASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string STBORROW_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BORROWFROMCBANK_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEPOSIT_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BORROWFUND_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FVALUEFLIAB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TRADEFLIAB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEFINEFVALUEFLIAB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BILLPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ACCOUNTPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ADVANCERECEIVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SELLBUYBACKFASSET_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SALARYPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TAXPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INTERESTPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DIVIDENDPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RIPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INTERNALPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHERPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ANTICIPATELLIAB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CONTACTRESERVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AGENTTRADESECURITY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AGENTUWSECURITY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEFERINCOMEONEYEAR_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string STBONDREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CLHELDSALELIAB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NONLLIABONEYEAR_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHERLLIAB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMLLIAB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LTBORROW_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BONDPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PREFERSTOCBOND_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUSTAINBOND_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LTACCOUNTPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LTSALARYPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SPECIALPAY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ANTICIPATELIAB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEFERINCOME_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEFERINCOMETAXLIAB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHERNONLLIAB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMNONLLIAB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMLIAB_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SHARECAPITAL_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHEREQUITY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PREFERREDSTOCK_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUSTAINABLEDEBT_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OTHEREQUITYOTHER_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CAPITALRESERVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INVENTORYSHARE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SPECIALRESERVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SURPLUSRESERVE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GENERALRISKPREPARE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UNCONFIRMINVLOSS_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RETAINEDEARNING_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PLANCASHDIVI_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DIFFCONVERSIONFC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMPARENTEQUITY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MINORITYEQUITY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMSHEQUITY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SUMLIABSHEQUITY_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ACCOUNTBILLREC_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TOTAL_OTHER_RECE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TOTAL_OTHER_PAYABLE_YOY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ACCOUNTBILLPAY_YOY { get; set; }
    }
}
