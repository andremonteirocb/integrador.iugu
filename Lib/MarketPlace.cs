using Integrador.Iugu.Filters;
using Integrador.Iugu.Request;
using Integrador.Iugu.Response;
using System;
using System.Threading.Tasks;

namespace Integrador.Iugu.Lib
{
    /// <summary>
    /// Api que permite que uma conta tenha subcontas, possibilitando uma rede de clientes e subclientes
    /// <see cref="https://dev.iugu.com/reference#criar-subconta"/>
    /// </summary>
    public class MarketPlace : IDisposable
    {
        protected readonly IApiResources Api;

        public MarketPlace() : this(new APIResource()) { }

        public MarketPlace(IApiResources api)
        {
            Api = api;
            api.BaseURI = "/marketplace";
        }

        /// <summary>
        /// Permite a criação das sub-contas gerenciadas pela conta que gerencia o marketplace.
        /// </summary>
        /// <param name="underAccount">Informações da conta que se deseja criar</param>
        /// <returns>informações da conta recém criada</returns>
        public async Task<AccountResponseMessage> CreateUnderAccountAsync(AccountRequestMessage underAccount)
        {
            var retorno = await Api.PostAsync<AccountResponseMessage>(underAccount, "create_account").ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Listas todas as subcontas dentro de um marketplace
        /// </summary>
        /// <returns></returns>
        public async Task<MarketplaceAccoutsResponse> GetAllSubAccountsAsync()
        {
            var retorno = await Api.GetAsync<MarketplaceAccoutsResponse>().ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Listas todas(1000) as subcontas dentro de um marketplace
        /// </summary>
        /// <param name="customApiToken">api token customizado</param>
        /// <returns></returns>
        public async Task<MarketplaceAccoutsResponse> GetAllSubAccountsAsync(string customApiToken)
        {
            var retorno = await Api.GetAsync<MarketplaceAccoutsResponse>(null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Listas todas as subcontas dentro de um marketplace com paginação e filtro
        /// </summary>
        /// <param name="customApiToken">api token customizado</param>
        /// <param name="filter">Opções de filtros e ordenação</param>
        /// <returns></returns>
        public async Task<PaggedResponseMessage<MarketPlaceAccountItem>> GetAllSubAccountsAsync(string customApiToken, QueryStringFilter filter)
        {
            var queryStringFilter = filter?.ToQueryStringUrl();
            var retorno = await Api.GetAsync<PaggedResponseMessage<MarketPlaceAccountItem>>(null, queryStringFilter, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public void Dispose()
        {
            Api.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
