using Newtonsoft.Json;

namespace Integrador.Iugu.Request
{
    /// <summary>
    /// Requisição para a API de contas
    /// </summary>
    public class AccountRequestMessage
    {
        /// <summary>
        /// Nome da Conta. Caso não seja enviado, um valor padrão com o ID da conta é atribuído
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Percentual de comissionamento enviado para a conta que gerencia o marketplace (Valor entre 0 e 70)
        /// </summary>
        [JsonProperty("commissions")]
        public Commissions Commissions { get; set; }
    }

    public class Commissions
    {
        /// <summary>
        /// Valor em centavos.
        /// </summary>
        [JsonProperty("cents")]
        public int? Cents { get; set; }
        /// <summary>
        /// Valor em porcentagem
        /// </summary>
        [JsonProperty("percent")]
        public float? Percent { get; set; }
        /// <summary>
        /// Valor em centavos a ser cobrado apenas em transações no cartão de crédito. Precisa do parâmetro cents acima configurado.
        /// </summary>
        [JsonProperty("credit_card_cents")]
        public float? Credit_card_cents { get; set; }
        /// <summary>
        /// Valor em porcentagem a ser cobrado apenas em transações no cartão de crédito. Precisa do parâmetro percent acima configurado.
        /// </summary>
        [JsonProperty("credit_card_percent")]
        public float? Credit_card_percent { get; set; }
        /// <summary>
        /// Valor em centavos a ser cobrado apenas em transações no boleto. Precisa do parâmetro cents acima configurado.
        /// </summary>
        [JsonProperty("bank_slip_cents")]
        public float? Bank_slip_cents { get; set; }
        /// <summary>
        /// Valor em porcentagem a ser cobrado apenas em transações no boleto. Precisa do parâmetro percent acima configurado.
        /// </summary>
        [JsonProperty("bank_slip_percent")]
        public float? Bank_slip_percent { get; set; }
        /// <summary>
        /// Permite agregar comissionamento percentual e fixo
        /// </summary>
        [JsonProperty("permit_aggregated")]
        public bool? Permit_aggregated { get; set; }
    }
}
