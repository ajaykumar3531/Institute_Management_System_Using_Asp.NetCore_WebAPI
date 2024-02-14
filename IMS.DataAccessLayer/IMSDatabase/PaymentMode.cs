using System;
using System.Collections.Generic;

namespace IMS.DataAccessLayer.IMSDatabase
{
    public partial class PaymentMode
    {
        public PaymentMode()
        {
            BillWisePaymentDetails = new HashSet<BillWisePaymentDetail>();
        }

        public int PaymentModeId { get; set; }
        public string PaymentModeName { get; set; } = null!;

        public virtual ICollection<BillWisePaymentDetail> BillWisePaymentDetails { get; set; }
    }
}
