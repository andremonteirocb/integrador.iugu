using Integrador.Iugu.Entity;
using Integrador.Iugu.Filters;
using Integrador.Iugu.Request;
using Integrador.Iugu.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integrador.Iugu.Lib
{
    /// <summary>
    /// https://dev.iugu.com/reference#criar-assinatura
    /// </summary>
    public class Subscription : APIResource
    {
        public Subscription()
        {
            BaseURI = "/subscriptions";
        }

        //limit (opcional)	Máximo de registros retornados
        //start (opcional)	Quantos registros pular do início da pesquisa (muito utilizado para paginação)
        //created_at_from (opcional)	Registros criados a partir desta data passada no parâmetro
        //created_at_to (opcional)	Registros criados até esta data passada no parâmetro
        //query (opcional)	Neste parâmetro pode ser passado um texto para pesquisa
        //updated_since (opcional)	Registros atualizados desde o valor passado no parâmetro
        //sortBy (opcional)	Um hash sendo a chave o nome do campo para ordenação e o valor sendo DESC ou ASC para descendente e ascendente, respectivamente
        //customer_id (opcional)	ID do Cliente
        public async Task<SubscriptionModel> GetAsync()
        {
            //TODO: Implementar GET com parametros
            var retorno = await GetAllAsync(null).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Lista todas as ultimas(1000) faturas possibilitando enviar um ApiToken de subconta, geralmente utilizado em marketplaces
        /// </summary>
        /// <param name="customApiToken">ApiToken customizado</param>
        /// <returns></returns>
        public async Task<SubscriptionModel> GetAllAsync(string customApiToken)
        {
            var filter = new QueryStringFilter { MaxResults = 1000 };
            var queryStringFilter = filter?.ToQueryStringUrl();
            var retorno = await GetAsync<SubscriptionModel>(null, queryStringFilter, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Lista todas as faturas possibilitando enviar um ApiToken de subconta, geralmente utilizado em marketplaces e filtros customizaveis.
        /// </summary>
        /// <param name="customApiToken">ApiToken customizado</param>
        /// <param name="filter">Opções de filtros, para paginação e ordenação</param>
        /// <returns></returns>
        public async Task<PaggedResponseMessage<SubscriptionModel>> GetAllAsync(string customApiToken, QueryStringFilter filter)
        {
            var queryStringFilter = filter?.ToQueryStringUrl();
            var retorno = await GetAsync<PaggedResponseMessage<SubscriptionModel>>(null, queryStringFilter, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionModel> GetAsync(string id)
        {
            var retorno = await GetAsync(id, null).ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionModel> GetAsync(string id, string customApiToken)
        {
            var retorno = await GetAsync<SubscriptionModel>(id, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Cria uma assinatura para um cliente cadastrado
        /// </summary>
        /// <param name="request">Request para criar uma assinatura</param>
        public async Task<SubscriptionModel> CreateAsync(SubscriptionRequestMessage request)
        {
            var retorno = await CreateAsync(request, null).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Cria uma assinatura para um cliente cadastrado
        /// </summary>
        /// <param name="request">Request para criar uma assinatura</param>
        /// <param name="customApiToken">Um token customizado, por exemplo, de um cliente de uma subconta, comum em marketplaces</param>
        public async Task<SubscriptionModel> CreateAsync(SubscriptionRequestMessage request, string customApiToken)
        {
            var retorno = await PostAsync<SubscriptionModel>(request, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionModel> DeleteAsync(string id, string customApiToken)
        {
            var retorno = await DeleteAsync<SubscriptionModel>(id, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionModel> PutAsync(string id, SubscriptionModel model)
        {
            var retorno = await PutAsync<SubscriptionModel>(id, model).ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionModel> SuspendAsync(string id)
        {
            var retorno = await PostAsync<SubscriptionModel>(null, $"{id}/suspend").ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionModel> ActivateAsync(string id)
        {
            var retorno = await PostAsync<SubscriptionModel>(null, $"{id}/activate").ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionModel> ChangePlanAsync(string id, string plan_identifier)
        {
            var retorno = await PostAsync<SubscriptionModel>(null, $"{id}/change_plan/{plan_identifier}").ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionModel> AddCreditsAsync(string id, int quantity)
        {
            var retorno = await PostAsync<SubscriptionModel>(null, $"{id}/add_credits/{quantity}").ConfigureAwait(false);
            return retorno;
        }
    }
}
