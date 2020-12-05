using Newtonsoft.Json;

namespace Integrador.Iugu.Request
{
    /// <summary>
    /// Requisição para a API de contas
    /// </summary>
    public class AccountUpdateRequestMessage
    {
        /// <summary>
        /// Nome da Conta. Caso não seja enviado, um valor padrão com o ID da conta é atribuído
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
