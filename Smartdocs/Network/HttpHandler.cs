using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Smartdocs.Models;

namespace Smartdocs
{
	public class HttpHandler
	{
		private HttpClient httpClient;

		public HttpHandler ()
		{
			httpClient = new System.Net.Http.HttpClient ();
		}

		public async Task<List<WorkItem>> GetAllWorkItemsAsync()
		{
			try {

				httpClient.BaseAddress = new Uri(Constants.SERVER);
				httpClient.DefaultRequestHeaders.Clear();
				httpClient.DefaultRequestHeaders.Add ("Authorization", "Bearer " + Constants.SECRET_TOKEN);

				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "rest/api/getworkitemdatalist/admin");

				var response = await httpClient.SendAsync(request);

				string result = "";

				List<WorkItem> workItemList = new List<WorkItem>();

				if (response.StatusCode == HttpStatusCode.OK) {
					result = response.Content.ReadAsStringAsync ().Result;

					JToken jsonArray = JValue.Parse(result);

					foreach (var json in jsonArray) {
						WorkItem tmp = JsonConvert.DeserializeObject<WorkItem>(json.ToString());
						workItemList.Add(tmp);
					}
				}

				return workItemList;
			} catch (Exception ex) {
				Debug.WriteLine (ex.ToString ());
				return null;
			}
		}

		public async Task<HttpResponseMessage> LoginAsync(string username, string password)
		{
			try {
				httpClient.BaseAddress = new Uri(Constants.SERVER);
				httpClient.DefaultRequestHeaders
					.Accept
					.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "rest/authentication/getToken");
				request.Content = new StringContent("{\"userId\":\"" + username + "\",\"password\": \"" + password + "\"}",
					Encoding.UTF8, 
					"application/json");

				var response = await httpClient.SendAsync(request);

				return response;
			
			} catch(Exception ex) {
				Debug.WriteLine (ex.ToString ());
				return null;
			}
		}
	}
}
