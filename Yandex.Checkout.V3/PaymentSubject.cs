namespace Yandex.Checkout.V3;

/// <summary>
/// Признак предмета расчета
/// </summary>
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum PaymentSubject
{
    /// <summary>
    /// Товар
    /// </summary>
    Commodity,

    /// <summary>
    /// Подакцизный товар
    /// </summary>
    Excise,

    /// <summary>
    /// Работа
    /// </summary>
    Job,

    /// <summary>
    /// Услуга
    /// </summary>
    Service,

    /// <summary>
    /// Ставка в азартной игре
    /// </summary>
    GamblingBet,

    /// <summary>
    /// Выигрыш в азартной игре
    /// </summary>
    GamblingPrize,

    /// <summary>
    /// Лотерейный билет
    /// </summary>
    Lottery,

    /// <summary>
    /// Выигрыш в лотерее
    /// </summary>
    LotteryPrize,

    /// <summary>
    /// Результаты интеллектуальной деятельности
    /// </summary>
    IntellectualActivity,

    /// <summary>
    /// Платеж
    /// </summary>
    Payment,

    /// <summary>
    /// Платеж казино.
    /// </summary>
    Casino,

    /// <summary>
    /// Агентское вознаграждение
    /// </summary>
    AgentCommission,

    /// <summary>
    /// Имущественное право.
    /// </summary>
    PropertyRight,

    /// <summary>
    /// Внереализационный доход.
    /// </summary>
    NonOperatingGain,

    /// <summary>
    /// Страховой сбор.
    /// </summary>
    InsurancePremium,

    /// <summary>
    /// Торговый сбор.
    /// </summary>
    SalesTax,

    /// <summary>
    /// Курортный сбор.
    /// </summary>
    ResortFee,

    /// <summary>
    /// Несколько вариантов
    /// </summary>
    Composite,

    /// <summary>
    /// Другое
    /// </summary>
    Another,

    /// <summary>
    /// Маркированный товар.
    /// </summary>
    Marked,

    /// <summary>
    /// Маркированный товар без кода маркировки.
    /// </summary>
    NonMarked,

    /// <summary>
    /// Маркированный подакцизный товар.
    /// </summary>
    MarkedExcise,

    /// <summary>
    /// Маркированный подакцизный товар без кода маркировки.
    /// </summary>
    NonMarkedExcise,

    /// <summary>
    /// Пени, штраф, вознаграждение или бонус.
    /// </summary>
    Fine,

    /// <summary>
    /// Страховые взносы.
    /// </summary>
    Tax,

    /// <summary>
    /// Залог.
    /// </summary>
    Lien,

    /// <summary>
    /// Расход.
    /// </summary>
    Cost,

    /// <summary>
    /// Выдача денежных средств.
    /// </summary>
    AgentWithdrawals,

    /// <summary>
    /// Пенсионные взносы без выплат физическим лицам.
    /// </summary>
    PensionInsuranceWithoutPayouts,

    /// <summary>
    /// Пенсионные взносы с выплатами физическим лицам.
    /// </summary>
    PensionInsuranceWithPayouts,

    /// <summary>
    /// Медицинские взносы без выплат физическим лицам.
    /// </summary>
    HealthInsuranceWithoutPayouts,

    /// <summary>
    /// Медицинские взносы с выплатами физическим лицам.
    /// </summary>
    HealthInsuranceWithPayouts,

    /// <summary>
    /// Взносы на обязательное социальное страхование.
    /// </summary>
    HealthInsurance
}
