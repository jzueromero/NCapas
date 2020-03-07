using SLC;
using System;
using System.Collections.Generic;
using System.Text;
using EntitiesStandart;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
/// <summary>
/// bibliotecas  necesarias para el get
/// </summary>
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NWindProxyService
{
    public class Proxy : IService
    {
        string BaseAddress = "http://localhost:59167";

        public async Task<T> SendPost<T, PostData>
            (string requestURI, PostData data)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    //URL ABSOLUTO
                    requestURI = BaseAddress + requestURI;
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add
                        (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var JSONdata = JsonConvert.SerializeObject(data);
                    HttpResponseMessage Response = await Client.PostAsync(requestURI, new StringContent(JSONdata.tostin
                        (), Encoding.UTF8, "application/json"));

                    var ResultWebAPI = await Response.Content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<T>(ResultWebAPI);

                }
                catch
                { }
                return Result;
            }
        }


        public async Task<T> SendGet<T>(string requestURI)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    requestURI = BaseAddress + requestURI; //URL absoluto

                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("applicaction/json"));

                    var resultJSON = await Client.GetStringAsync(requestURI);
                    Result = JsonConvert.DeserializeObject<T>(resultJSON);
                }
                catch
                { }
            }
            return Result;
        }

        public async Task<Products> CreateProductAsync(Products newProduct)
        {
            return await SendPost<Products, Products>
                ("/api/nwind/createproduct", newProduct);
        }

        public Products CreateProduct(Products newProduct)
        {
            Products Result = null;
            //Ejecutar la tarea en un nuevo hilo
            //para que no se bloquee el hilo sincrono
            //con wait esperamos la operacion asincrona
            Task.Run(async () => Result =
                     await CreateProductAsync(newProduct)).Wait();
            return Result;
        }

        public async Task<Products> RetrieveProductByIDAsync(int ID)
        {
            return await SendGet<Products>($"/api/nwind/RetrievProductByID/{ID}");
        }

        public Products RetrieveProductByID(int ID)
        {
            Products Result = null;
            Task.Run(async () =>
                     Result = await RetrieveProductByIDAsync(ID)).Wait();
            return Result;
        }

        public async Task<bool> UpdateProductAsync(Products productToUpdate)
        {
            return await SendPost<bool, Products>
                ("/api/nwind/UpdateProduct", productToUpdate);
        }

        public bool UpdateProduct(Products productToUPdate)
        {
            bool Result = false;
            Task.Run(async () => Result = await
                    UpdateProductAsync(productToUPdate)).Wait();
            return Result;
        }

        public async Task<bool> DeleteProductAsync(int ID)
        {
            return await SendGet<bool>($"/api/nwind/DeleteProduct/{ID}");
        }

        public bool DeleteProduct(int ID)
        {
            bool Result = false;
            Task.Run(async () => Result = await
                                DeleteProductAsync(ID)).Wait();
            return Result;
        }
            
    }
}
