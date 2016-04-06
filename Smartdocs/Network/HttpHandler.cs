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
		HttpClient httpClient;
		public List<WorkItemModel> WorkItems { get; private set; }

		public HttpHandler ()
		{
			httpClient = new HttpClient ();
			httpClient.MaxResponseContentBufferSize = Constants.SERVER_MAX_BUFF;
			httpClient.Timeout = new TimeSpan(Constants.SERVER_TIMEOUT);
		}

		public async Task<List<WorkItemModel>> GetAllWorkItemsAsync()
		{
			var uri = new Uri (Constants.SERVER_URL + Constants.GET_WORKITEMS_URL);

			try {
				var response = await httpClient.GetAsync (uri);

				Debug.WriteLine(response);
				if (response.IsSuccessStatusCode) {
					var content = await response.Content.ReadAsStringAsync ();
					JToken token = JObject.Parse(response);
				}
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
			return WorkItems;
		}
	}
}


