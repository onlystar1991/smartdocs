using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Smartdocs
{
	public class HttpHandler
	{
		System.Net.Http.HttpClient httpClient;
		public List<WorkItemModel> WorkItems { get; private set; }

		public HttpHandler ()
		{
			httpClient = new System.Net.Http.HttpClient ();
		}

		public async Task<WorkItemModel[]> GetAllWorkItemsAsync()
		{
			var url = new Uri ("http://1-dot-dummyrestapis.appspot.com/getworkitemdatalist/admin");

			var response = await httpClient.GetAsync (url);

			var content = response.Content.ReadAsStringAsync ().Result;

			dynamic dynObj = JsonConvert.DeserializeObject(content);

			foreach (JToken obj in dynObj) {
				Debug.WriteLine (obj);
			}

			var model = JsonConvert.DeserializeObject<WorkListObject> (content);

			return model.workItems;
		}

		public async Task<String> LoginAsync(string username, string password)
		{
			try {
//				var uri = new Uri(Constants.LOGIN_SERVER + Constants.LOGIN_API);

				httpClient.BaseAddress = new Uri(Constants.LOGIN_SERVER);

				httpClient.DefaultRequestHeaders
					.Accept
					.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "rest/authentication/getToken");
				request.Content = new StringContent("{\"userId\":\"" + username + "\",\"password\": \"" + password + "\"}",
					Encoding.UTF8, 
					"application/json");

				var response = await httpClient.SendAsync(request);

				return response.StatusCode.ToString();
			
			} catch(Exception ex) {
				Debug.WriteLine (ex.ToString ());
				return null;
			}
		}
	}
}
