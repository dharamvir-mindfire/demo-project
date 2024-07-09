using DemoProject.Models;
using Newtonsoft.Json;

namespace DemoProject
{
    public static class DemoData
    {
        public static IList<Person> CreatePersons()
        {
            List<Person> list = new List<Person>();
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://dummy.restapiexample.com/api/v1/employees");
                response.Wait();
                var result = response.Result.Content.ReadAsStringAsync();
                result.Wait();
                var data = JsonConvert.DeserializeObject<dynamic>(result.Result);
                if (data != null)
                {
                    foreach (var item in data["data"])
                    {
                        list.Add(new Person()
                        {
                            Id = item["id"],
                            Name = item["employee_name"],
                            Email = $"{item["employee_name"]}@example.com".ToLower().Replace(" ", ""),
                            PhoneNumber = item["employee_salary"],
                            Address = $"{item["employee_name"]}, Hisar, Haryana - 125052"
                        });
                    }
                }
                return list;
            }
        }
    }
}
