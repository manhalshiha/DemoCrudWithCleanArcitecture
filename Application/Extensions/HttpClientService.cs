﻿using System.Net.Http.Headers;

namespace Application.Extensions
{
    public class HttpClientService(IHttpClientFactory httpClientFactory, LocalStorageService localStorageService)
    {
        private HttpClient CreateClient() => httpClientFactory!.CreateClient(Constant.HttpClientName);
        public HttpClient GetPublicClient() => CreateClient();
        public async Task<HttpClient> GetPrivateClient()
        {
            try
            {
                var client = CreateClient();
                var localStorageDto = await localStorageService.GetModelFromToken();
                if (string.IsNullOrEmpty(localStorageDto.Token)) return client;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constant.HttpClientHeaderScheme, localStorageDto.Token);
                return client;
            }
            catch
            {
                return new HttpClient();

            }

        }
    }
}
