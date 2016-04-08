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
			var authData = string.Format ("{0}:{1}", Constants.USER_NAME, Constants.PASSWORD );
			var authHeaderValue = "Basic " + Convert.ToBase64String (Encoding.UTF8.GetBytes (authData));
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Authentication", authHeaderValue);
		}

		public async Task<List<WorkItemModel>> GetAllWorkItemsAsync()
		{
			var uri = new Uri (Constants.SERVER_URL + Constants.GET_WORKITEMS_URL);

			try {
				var response = await httpClient.GetAsync (uri);

				Debug.WriteLine(response);
				if (response.IsSuccessStatusCode) {
					var content = await response.Content.ReadAsStringAsync ();
					Debug.WriteLine (@"				response {0}", content.ToString());
				}
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
			return WorkItems;
		}


	}
}


