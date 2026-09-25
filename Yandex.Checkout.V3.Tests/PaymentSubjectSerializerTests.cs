using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yandex.Checkout.V3.Tests;

[TestClass]
public sealed class PaymentSubjectSerializerTests
{
    [DataTestMethod]
    [DataRow(PaymentSubject.Casino, "casino")]
    [DataRow(PaymentSubject.PropertyRight, "property_right")]
    [DataRow(PaymentSubject.NonOperatingGain, "non_operating_gain")]
    [DataRow(PaymentSubject.InsurancePremium, "insurance_premium")]
    [DataRow(PaymentSubject.SalesTax, "sales_tax")]
    [DataRow(PaymentSubject.ResortFee, "resort_fee")]
    [DataRow(PaymentSubject.Marked, "marked")]
    [DataRow(PaymentSubject.NonMarked, "non_marked")]
    [DataRow(PaymentSubject.MarkedExcise, "marked_excise")]
    [DataRow(PaymentSubject.NonMarkedExcise, "non_marked_excise")]
    [DataRow(PaymentSubject.Fine, "fine")]
    [DataRow(PaymentSubject.Tax, "tax")]
    [DataRow(PaymentSubject.Lien, "lien")]
    [DataRow(PaymentSubject.Cost, "cost")]
    [DataRow(PaymentSubject.AgentWithdrawals, "agent_withdrawals")]
    [DataRow(PaymentSubject.PensionInsuranceWithoutPayouts, "pension_insurance_without_payouts")]
    [DataRow(PaymentSubject.PensionInsuranceWithPayouts, "pension_insurance_with_payouts")]
    [DataRow(PaymentSubject.HealthInsuranceWithoutPayouts, "health_insurance_without_payouts")]
    [DataRow(PaymentSubject.HealthInsuranceWithPayouts, "health_insurance_with_payouts")]
    [DataRow(PaymentSubject.HealthInsurance, "health_insurance")]
    public void SerializeObject_PaymentSubject_UsesYooKassaValue(PaymentSubject subject, string expectedValue)
    {
        var json = Serializer.SerializeObject(new ReceiptItem { PaymentSubject = subject });

        StringAssert.Contains(json, $"\"payment_subject\":\"{expectedValue}\"");
    }

    [TestMethod]
    public void DeserializeObject_ReceiptItemWithInsurancePremium_UsesPaymentSubjectInsurancePremium()
    {
        var item = Serializer.DeserializeObject<ReceiptItem>("{\"payment_subject\":\"insurance_premium\"}");

        Assert.AreEqual(PaymentSubject.InsurancePremium, item.PaymentSubject);
    }
}
