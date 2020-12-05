namespace Integrador.Iugu
{
    /// <summary>
    /// Tipo de intervalos de plano
    /// </summary>
    public enum PlanIntervalType
    {
        /// <summary>
        /// Plano com um ciclo semanal
        /// </summary>
        Weekly,
        /// <summary>
        /// Plano com um ciclo mensal
        /// </summary>
        Monthly
    }

    /// <summary>
    /// Moedas suportadas
    /// </summary>
    public enum CurrencyType
    {
        /// <summary>
        /// Moeda brasileira
        /// </summary>
        BRL
    }

    /// <summary>
    /// Bancos disponíveis
    /// </summary>
    public enum AvailableBanks
    {
        CaixaEconomicaFederal = 104,
        BancoDoBrasil = 001,
        Bradesco = 237,
        Itau = 341,
        Santander = 033,
        HSBC = 399, Banrisul = 041,
        Sicredi = 748,
        Sicoob = 756,
        Inter = 077,
        BRB = 070,
        ViaCredi = 085,
        Neon = 655,
        Nubank = 260,
        Pagseguro = 290,
        BancoOriginal = 212,
        Safra = 422,
        Modal = 746,
        Banestes = 021,
        Unicred = 136,
        MoneyPlus = 274,
        Mercantil = 389,
        JpMorgan = 376,
        Gerencianet = 364
    }

    /// <summary>
    /// Status da Fatura
    /// </summary>
    public enum InvoiceAvailableStatus
    {
        Paid, Canceled, Partially_Paid, Pending, Draft, Refunded, Expired, Authorized
    }

    /// <summary>
    /// Person type
    /// </summary>
    public enum PersonType
    {
        /// <summary>
        /// Pessoa Jurídica
        /// </summary>
        CorporateEntity,

        /// <summary>
        /// Pessoa física
        /// </summary>
        IndividualPerson
    }

    /// <summary>
    /// Bank account type
    /// </summary>
    public enum BankAccountType
    {
        /// <summary>
        /// Conta poupança
        /// </summary>
        SavingAccount,

        /// <summary>
        /// Conta Corrente
        /// </summary>
        CheckingAccount
    }

    public enum BankAccountTypeAbbreviation
    {
        /// <summary>
        /// Conta poupança
        /// </summary>
        CP,

        /// <summary>
        /// Conta Corrente
        /// </summary>
        CC
    }

    /// <summary>
    /// Metodos de pagamento suportado
    /// </summary>
    public enum PaymentMethod
    {
        /// <summary>
        /// Todos os tipos de pagamentos serão aceitos
        /// </summary>
        All,
        /// <summary>
        /// Cartão de crédito
        /// </summary>
        CreditCard,

        /// <summary>
        /// Boleto bancário
        /// </summary>
        BankSlip
    }

    /// <summary>
    /// Tipo de Ordenaçãp
    /// </summary>
    public enum ResultOrderType
    {
        /// <summary>
        /// Menor para o maior
        /// </summary>
        Ascending,
        /// <summary>
        /// Maior para o menor
        /// </summary>
        Descending
    }

    /// <summary>
    /// Campos com Ordenações suportadas
    /// </summary>
    public enum FieldSort
    {
        Id,
        Status,
        CreateAt,
        UpdateAt,
        Amount,
        AccountName,
        Name,
    }
}
