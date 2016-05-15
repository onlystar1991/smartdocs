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
			httpClient.BaseAddress = new Uri (Constants.SERVER_URL);
		}

		public async Task<List<WorkItemModel>> GetAllWorkItemsAsync()
		{
			var uri = new Uri (Constants.SERVER_URL + Constants.GET_WORKITEMS_URL);

			try {
				var response = await httpClient.GetAsync (uri);

				Debug.WriteLine(response);
				if (response.IsSuccessStatusCode) {
					var content = await response.Content.ReadAsStringAsync ();
					Debug.WriteLine (@"response {0}", content.ToString());
				}
			} catch (Exception ex) {
				Debug.WriteLine (@"ERROR {0}", ex.Message);
			}
			return WorkItems;
		}

		public async Task<String> LoginAsync(string username, string password)
		{
			try {
				string api = Constants.LOGIN_API + String.Format ("j_username={0}&j_password={1}", username, password);

				var response = await httpClient.GetAsync(api);

				return response.StatusCode.ToString();
			
			} catch(Exception ex) {
				Debug.WriteLine (ex.ToString ());
				return null;
			}
		}
	}
}
