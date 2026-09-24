namespace Yandex.Checkout.V3;

/// <summary>
/// Код товара для формирования чека по ФФД 1.2 (тег в 54-ФЗ — 1163).
/// Должно быть заполнено хотя бы одно поле.
/// </summary>
/// <remarks>
/// See https://yookassa.ru/developers/api#create_receipt_items_mark_code_info
/// </remarks>
// ReSharper disable once ClassNeverInstantiated.Global
public class MarkCodeInfo
{
    /// <summary>
    /// Код товара в том виде, в котором он был прочитан сканером (тег в 54-ФЗ — 2000).
    /// </summary>
    [JsonProperty("mark_code_raw")]
    public string MarkCodeRaw { get; set; }

    /// <summary>
    /// Нераспознанный код товара (тег в 54-ФЗ — 1300).
    /// </summary>
    [JsonProperty("unknown")]
    public string Unknown { get; set; }

    /// <summary>
    /// Код товара в формате EAN-8 (тег в 54-ФЗ — 1301).
    /// </summary>
    [JsonProperty("ean_8")]
    public string Ean8 { get; set; }

    /// <summary>
    /// Код товара в формате EAN-13 (тег в 54-ФЗ — 1302).
    /// </summary>
    [JsonProperty("ean_13")]
    public string Ean13 { get; set; }

    /// <summary>
    /// Код товара в формате ITF-14 (тег в 54-ФЗ — 1303).
    /// </summary>
    [JsonProperty("itf_14")]
    public string Itf14 { get; set; }

    /// <summary>
    /// Код товара в формате GS1.0 (тег в 54-ФЗ — 1304).
    /// </summary>
    [JsonProperty("gs_10")]
    public string Gs10 { get; set; }

    /// <summary>
    /// Код товара в формате GS1.M (тег в 54-ФЗ — 1305).
    /// </summary>
    [JsonProperty("gs_1m")]
    public string Gs1M { get; set; }

    /// <summary>
    /// Код товара в формате короткого кода маркировки (тег в 54-ФЗ — 1306).
    /// </summary>
    [JsonProperty("short")]
    public string Short { get; set; }

    /// <summary>
    /// Контрольно-идентификационный знак мехового изделия (тег в 54-ФЗ — 1307).
    /// </summary>
    [JsonProperty("fur")]
    public string Fur { get; set; }

    /// <summary>
    /// Код товара в формате ЕГАИС-2.0 (тег в 54-ФЗ — 1308).
    /// </summary>
    [JsonProperty("egais_20")]
    public string Egais20 { get; set; }

    /// <summary>
    /// Код товара в формате ЕГАИС-3.0 (тег в 54-ФЗ — 1309).
    /// </summary>
    [JsonProperty("egais_30")]
    public string Egais30 { get; set; }
}
