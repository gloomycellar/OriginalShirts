using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using OriginalShirts.Domain;
using OriginalShirts.Dal;

namespace OriginalShirts.Utility.NovaPoshta
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> t = GeteRawString();
            t.Wait();

            File.WriteAllText("nova_poshta.json", t.Result);

            string json = File.ReadAllText("nova_poshta.json");
            List<NpDepartment> departments = ConvertToObjects(json);

            using (ApplicationContext context = new ApplicationContext())
            {
                context.Set<NpDepartment>().RemoveRange(context.Set<NpDepartment>());
                context.Set<NpDepartment>().AddRange(departments);
                context.SaveChanges();
            }
        }

        private static List<NpDepartment> ConvertToObjects(string json)
        {
            JToken token = JToken.Parse(json);
            JToken responce = token.SelectToken("response");
            List<NpDepartment> departments = new List<NpDepartment>();
            NpDepartment d;

            foreach (JToken item in responce)
            {
                d = new NpDepartment();

                try
                {
                    d.Address = (string)item.SelectToken("address");
                }
                catch (Exception)
                {
                    d.Address = null;
                }

                try
                {
                    d.AddressRu = (string)item.SelectToken("addressRu");
                }
                catch (Exception)
                {
                    d.AddressRu = null;
                }

                try
                {
                    d.City = (string)item.SelectToken("city");
                }
                catch (Exception)
                {
                    d.City = null;
                }

                try
                {
                    d.CityRef = (string)item.SelectToken("city_ref");
                }
                catch (Exception)
                {
                    d.CityRef = null;
                }

                try
                {
                    d.CityRu = (string)item.SelectToken("cityRu");
                }
                catch (Exception)
                {
                    d.CityRu = null;
                }

                try
                {
                    d.Number = (string)item.SelectToken("number");
                }
                catch (Exception)
                {
                    d.Number = null;
                }

                try
                {
                    d.Ref = (string)item.SelectToken("ref");
                }
                catch (Exception)
                {
                    d.Ref = null;
                }

                try
                {
                    d.WarehouseType = (string)item.SelectToken("warehouseType");
                }
                catch (Exception)
                {
                    d.WarehouseType = null;
                }

                try
                {
                    d.WarehouseTypeDescription = (string)item.SelectToken("warehouseTypeDescription");
                }
                catch (Exception)
                {
                    d.WarehouseTypeDescription = null;
                }

                try
                {
                    d.X = (string)item.SelectToken("x");
                }
                catch (Exception)
                {
                    d.X = null;
                }

                try
                {
                    d.Y = (string)item.SelectToken("y");
                }
                catch (Exception)
                {
                    d.Y = null;
                }

                //departments.Add(new Department
                //{
                //    Address = (object)item.SelectToken("address"). as string,
                //    AddressRu = (object)item.SelectToken("addressRu") as string,
                //    City = (object)item.SelectToken("city") as string,
                //    CityRef = (object)item.SelectToken("city_ref") as string,
                //    CityRu = (object)item.SelectToken("cityRu") as string,
                //    Number = (object)item.SelectToken("number") as string,
                //    Ref = (object)item.SelectToken("ref") as string,
                //    WarehouseType = (object)item.SelectToken("warehouseType") as string,
                //    WarehouseTypeDescription = (object)item.SelectToken("warehouseTypeDescription") as string,
                //    X = (object)item.SelectToken("x") as string,
                //    Y = (object)item.SelectToken("y") as string
                //});

                departments.Add(d);
            }

            return departments;
        }

        public static async Task<string> GeteRawString()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["GetJsonWarehouseListUrl"];
                Dictionary<string,string> values = new Dictionary<string, string>();
                
                FormUrlEncodedContent content = new FormUrlEncodedContent(values);
                HttpResponseMessage response = await client.PostAsync(url, content);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
