using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fpzslib
{
    public class DocumentItem
    {
        public string DocumentNo { get; set; }
        public int SerialNo { get; set; }
        public string ItemNo { get; set; }
        public string Name { get; set; }
        public string Spec { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Value { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Tax { get; set; }
        /// <summary>
        /// 扣除额
        /// </summary>
        public decimal Deduction { get; set; }
        /// <summary>
        /// 税收分类编码
        /// </summary>
        public string TaxCatalogItemNo { get; set; }
        /// <summary>
        /// 适用优惠政策标志
        /// </summary>
        public bool IsFreeTax { get; set; }
        /// <summary>
        /// 优惠政策
        /// </summary>
        public string FreeTaxName { get; set; }
        /// <summary>
        /// 零税率标志
        /// </summary>
        public ZeroTax ZeroTax { get; set; }
        
    }
}
