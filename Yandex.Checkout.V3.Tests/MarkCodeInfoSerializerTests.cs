using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yandex.Checkout.V3.Tests
{
    [TestClass]
    public sealed class MarkCodeInfoSerializerTests
    {
        [TestMethod]
        public void SerializeObject_ReceiptItemWithMarkCodeInfo_UsesYooKassaFieldNames()
        {
            // Arrange
            var item = new ReceiptItem
            {
                MarkCodeInfo = new MarkCodeInfo
                {
                    MarkCodeRaw = "raw",
                    Unknown = "unknown",
                    Ean8 = "12345678",
                    Ean13 = "1234567890123",
                    Itf14 = "12345678901234",
                    Gs10 = "gs10",
                    Gs1M = "gs1m",
                    Short = "short",
                    Fur = "12345678901234567890",
                    Egais20 = "123456789012345678901234567890123",
                    Egais30 = "12345678901234"
                }
            };

            // Act
            var json = Serializer.SerializeObject(item);

            // Assert
            Assert.AreEqual(
                "{\"quantity\":0.0,\"vat_code\":0,\"mark_code_info\":{" +
                "\"mark_code_raw\":\"raw\",\"unknown\":\"unknown\",\"ean_8\":\"12345678\"," +
                "\"ean_13\":\"1234567890123\",\"itf_14\":\"12345678901234\",\"gs_10\":\"gs10\"," +
                "\"gs_1m\":\"gs1m\",\"short\":\"short\",\"fur\":\"12345678901234567890\"," +
                "\"egais_20\":\"123456789012345678901234567890123\",\"egais_30\":\"12345678901234\"}}",
                json);
        }

        [TestMethod]
        public void DeserializeObject_ReceiptItemWithMarkCodeInfo_PopulatesAllSupportedFormats()
        {
            // Arrange
            const string json = "{\"mark_code_info\":{" +
                                "\"mark_code_raw\":\"raw\",\"unknown\":\"unknown\",\"ean_8\":\"12345678\"," +
                                "\"ean_13\":\"1234567890123\",\"itf_14\":\"12345678901234\",\"gs_10\":\"gs10\"," +
                                "\"gs_1m\":\"gs1m\",\"short\":\"short\",\"fur\":\"12345678901234567890\"," +
                                "\"egais_20\":\"123456789012345678901234567890123\",\"egais_30\":\"12345678901234\"}}";

            // Act
            var item = Serializer.DeserializeObject<ReceiptItem>(json);

            // Assert
            Assert.IsNotNull(item.MarkCodeInfo);
            Assert.AreEqual("raw", item.MarkCodeInfo.MarkCodeRaw);
            Assert.AreEqual("unknown", item.MarkCodeInfo.Unknown);
            Assert.AreEqual("12345678", item.MarkCodeInfo.Ean8);
            Assert.AreEqual("1234567890123", item.MarkCodeInfo.Ean13);
            Assert.AreEqual("12345678901234", item.MarkCodeInfo.Itf14);
            Assert.AreEqual("gs10", item.MarkCodeInfo.Gs10);
            Assert.AreEqual("gs1m", item.MarkCodeInfo.Gs1M);
            Assert.AreEqual("short", item.MarkCodeInfo.Short);
            Assert.AreEqual("12345678901234567890", item.MarkCodeInfo.Fur);
            Assert.AreEqual("123456789012345678901234567890123", item.MarkCodeInfo.Egais20);
            Assert.AreEqual("12345678901234", item.MarkCodeInfo.Egais30);
        }
    }
}
