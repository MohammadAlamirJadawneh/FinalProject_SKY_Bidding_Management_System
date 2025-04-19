using SKY_Bidding_Management_System_Library.Data.DTOs.NewFolder;

namespace SKY_Bidding_Management_System_Library.Helpers
{
    public static class PaymentTermTextGenerator
    {


        public static string GeneratePaymentTermText(PaymentTermDto paymentTerm)
        {
       
            return $@"
Payment Term Details:
----------------------
PaymentTermId: {paymentTerm.PaymentTermId}
Payment Schedule: {paymentTerm.PaymentSchedule}
Payment Method: {paymentTerm.PaymentMethod}
Penalties for Delays: {paymentTerm.PenaltiesForDelays}
";
        }
    }


}
