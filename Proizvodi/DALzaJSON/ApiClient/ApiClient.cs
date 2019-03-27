using DALzaJSON.StaticClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DALzaJSON.ApiClient
{
    public class ApiClient<T> : IApiClient<T> where T : class
    {
        #region Implementacija IApiClient interfejsa kada se podaci preuzimaju sa rest api-a
        //public bool Post(string apiString, T entity)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:9090/api/");
        //        //HTTP POST
        //        var postTask = client.PostAsJsonAsync<T>(apiString, entity);

        //        postTask.Wait();

        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return true;
        //        }
        //        else //web api sent error response 
        //        {
        //            //log greske
        //            return false;
        //        }
        //    }
        //}

        //public bool Delete(string apiString, object id)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:9090/api/");
        //        //HTTP DELETE
        //        var responseTask = client.DeleteAsync(apiString + "/" + id);
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return true;
        //        }
        //        else //web api sent error response 
        //        {
        //            //log greske

        //            return false;
        //        }
        //    }
        //}

        //public IEnumerable<T> GetMultipleItems(string apiString)
        //{
        //    IEnumerable<T> t = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:9090/api/");
        //        //HTTP GET
        //        var responseTask = client.GetAsync(apiString);
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsStringAsync();
        //            readTask.Wait();

        //            t = JsonConvert.DeserializeObject<IEnumerable<T>>(readTask.Result);
        //        }
        //        else //web api sent error response 
        //        {
        //            //log greske

        //        }
        //        return t;
        //    }
        //}

        //public T GetSingleItem(string apiString, object id)
        //{
        //    T t = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:9090/api/");
        //        //HTTP GET
        //        var responseTask = client.GetAsync(apiString + "/" + id);
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsStringAsync();
        //            readTask.Wait();

        //            t = JsonConvert.DeserializeObject<T>(readTask.Result);
        //        }
        //        else //web api sent error response 
        //        {
        //            //log greske

        //        }
        //        return t;
        //    }
        //}

        //public bool Put(string apiString, T entity)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:9090/api/");
        //        //HTTP PUT
        //        var putTask = client.PutAsJsonAsync<T>(apiString, entity);
        //        putTask.Wait();
        //        var result = putTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
        #endregion

        #region Implementacija IApiClient interfejsa kada se podaci citaju iz json fajla
        public IList<T> GetMultipleItems(string jsonFilePath)
        {
            IList<T> list = new List<T>();
            if (!System.IO.File.Exists(jsonFilePath))
                return list;
            using (StreamReader json = File.OpenText(jsonFilePath))
            {
                list = JsonConvert.DeserializeObject<List<T>>(json.ReadToEnd());
                return list;
            }
        }

        public bool Save(string jsonFilePath, IList<T> list)
        {
            try
            {
                var json = JsonConvert.SerializeObject(list);
                if (System.IO.File.Exists(jsonFilePath))
                    File.Delete(jsonFilePath);
                StreamWriter sw;
                using (sw = File.AppendText(jsonFilePath))
                {
                    sw.Write(json);
                }
            }
            catch (Exception e)
            {
                Pomocna.LogError(e.ToString());
                return false;
            }
            return true;
        }
        #endregion
    }
}
