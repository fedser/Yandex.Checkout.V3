using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yandex.Checkout.V3.Tests
{
    [TestClass]
    public sealed class MarkCodeInfoSerializerTests
    {
        [TestMethod]
        public void MarkCodeInfoProperties_AreDeclaredNullable()
        {
            // Arrange
            var propertyNames = new[]
            {
                nameof(MarkCodeInfo.MarkCodeRaw),
                nameof(MarkCodeInfo.Unknown),
                nameof(MarkCodeInfo.Ean8),
                nameof(MarkCodeInfo.Ean13),
                nameof(MarkCodeInfo.Itf14),
                nameof(MarkCodeInfo.Gs10),
                nameof(MarkCodeInfo.Gs1M),
                nameof(MarkCodeInfo.Short),
                nameof(MarkCodeInfo.Fur),
                nameof(MarkCodeInfo.Egais20),
                nameof(MarkCodeInfo.Egais30)
            };
            var nullabilityContext = new NullabilityInfoContext();

            foreach (var propertyName in propertyNames)
            {
                // Act
                var property = typeof(MarkCodeInfo).GetProperty(propertyName);
                var nullability = nullabilityContext.Create(property);

                // Assert
                Assert.AreEqual(
                    NullabilityState.Nullable,
                    nullability.ReadState,
                    $"Property {propertyName} must be optional.");
            }
        }

        [TestMethod]
        public void MarkCodeInfoProperty_IsDeclaredNullable()
        {
            // Arrange
            var property = typeof(ReceiptItem).GetProperty(nameof(ReceiptItem.MarkCodeInfo));

            // Act
            var nullability = new NullabilityInfoContext().Create(property);

            // Assert
            Assert.AreEqual(NullabilityState.Nullable, nullability.ReadState);
        }

        [TestMethod]
        public void SerializeObject_ReceiptItemWithoutMarkCodeInfo_OmitsField()
        {
            // Act
            var json = Serializer.SerializeObject(new ReceiptItem());

            // Assert
            Assert.AreEqual("{\"quantity\":0.0,\"vat_code\":0}", json);
        }

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
