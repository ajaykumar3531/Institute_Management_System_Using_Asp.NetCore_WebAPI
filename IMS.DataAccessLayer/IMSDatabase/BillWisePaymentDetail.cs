using System;
using System.Collections.Generic;

namespace IMS.DataAccessLayer.IMSDatabase
{
    public partial class BillWisePaymentDetail
    {
        public int PaymentDetailId { get; set; }
        public int? StudentBillId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PaidDate { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? PaymentModeId { get; set; }
        public int CollectedBy { get; set; }

        public virtual Course? Course { get; set; }
        public virtual PaymentMode? PaymentMode { get; set; }
        public virtual Student? Student { get; set; }
        public virtual StudentBill? StudentBill { get; set; }
    }
}
