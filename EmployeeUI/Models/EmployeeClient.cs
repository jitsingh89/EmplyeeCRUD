using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace EmployeeUI.Models
{

    public class EmployeeClient
    {
        private string Base_URL = "http://localhost:49697/api/";


        public IEnumerable<EmployeeModel> GetEmployees()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("employee").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<EmployeeModel>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public EmployeeModel GetEmployeeByEmpCode(int empCode)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("employee?empcode=" + empCode).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<EmployeeModel>().Result;
                return null;
            }
            catch(Exception ex)
            {
                //Exception Logging go here
                return null;
            }
        }

        public bool SaveEmployee(EmployeeModel employee)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("employee", employee).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                //Exception Logging go here
                return false;
            }
        }
        public bool UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("employee", employee).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                //Exception Logging go here
                return false;
            }
        }
        public bool DeleteEmployeeByEmpCode(int empCode)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("employee?empcode=" + empCode).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                //Exception Logging go here
                return false;
            }
        }


    }
}