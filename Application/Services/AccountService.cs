﻿using Application.DTOs.Request.Account;
using Application.DTOs.Response;
using Application.DTOs.Response.Account;
using Application.Extensions;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class AccountService(HttpClientService httpClientService) : IAccountService
    {
        

        public async Task<LoginResponse> LoginAccountAsync(LoginDTO model)
        {
            try
            {
                var publicClient = httpClientService.GetPublicClient();
                var response = await publicClient.PostAsJsonAsync(Constant.LoginRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new LoginResponse(false, error);
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return result!;
            }
            catch (Exception ex)
            {

                return new LoginResponse(false, ex.Message);
            }
        }
        public async Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model)
        {
            try
            {
                var publicClient = httpClientService.GetPublicClient();
                var response = await publicClient.PostAsJsonAsync(Constant.RegisterRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new GeneralResponse(false, error);
                var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
                return result!;
            }
            catch (Exception ex)
            {

                return new GeneralResponse(false, ex.Message);
            }
        }
        private string CheckResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                return $"Sorry unknown error occurred.{Environment.NewLine}Error Description:{Environment.NewLine}Status code:{response.StatusCode}{Environment.NewLine}Reason Phrase:{response.ReasonPhrase}";
            }
            else return null;
        }
        public async Task CreateAdminAtFirstStart()
        {
            try
            {
                var client = httpClientService.GetPublicClient();
                await client.PostAsync(Constant.CreateAdminRoute, null);
            }
            catch { }
        }
        public async Task<IEnumerable<GetRoleDTO>> GetRolesAsync()
        {
            try
            {
                var privateClient = await httpClientService.GetPrivateClient();
                var response = await privateClient.GetAsync(Constant.GetRolesRoute);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    throw new Exception(error);
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<GetRoleDTO>>();
                return result!;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        
        //public IEnumerable<GetRoleDTO> GetDefaultRoles()
        //{
        //    var list=new List<GetRoleDTO>();
        //    list?.Clear();
        //    list.Add(new GetRoleDTO(1.ToString(), Constant.Role.Admin));
        //    list.Add(new GetRoleDTO (1.ToString(),Constant.Role.User));
        //    return list;
        //}
        public async Task<IEnumerable<GetUsersWithRolesResponseDTO>> GetUsersWithRolesAsync()
        {
            try
            {
                var privateClient = await httpClientService.GetPrivateClient();
                var response = await privateClient.GetAsync(Constant.GetUserWithRoleRoute);
                var error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    throw new Exception(error);
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<GetUsersWithRolesResponseDTO>>();
                return result!;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<GeneralResponse> ChangeUserRoleAsync(ChangeUserRoleRequestDTO model)
        {
            try
            {
                var publicClient = await httpClientService.GetPrivateClient();
                var response = await publicClient.PostAsJsonAsync(Constant.ChangeUserRoleRoute, model);
                var error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new GeneralResponse(false,error);
                var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
                return result!;
            }
            catch (Exception ex)
            {

                return new GeneralResponse(false,ex.Message);
            }
        }
        public async Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model)
        {
            try
            {
                var publicClient =  httpClientService.GetPublicClient();
                var response = await publicClient.PostAsJsonAsync(Constant.RefreshTokenRoute, model);
                var error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new LoginResponse(false,error);
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return result!;
            }
            catch (Exception ex)
            {

                return new LoginResponse(false, ex.Message);
            }
        }

        public Task CreateAdmin()
        {
            throw new NotImplementedException();
        }

       
        public Task<GeneralResponse> CreateRoleAsync(CreateRoleDTO model)
        {
            throw new NotImplementedException();
        }

       
    }
}
