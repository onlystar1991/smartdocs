using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace Smartdocs
{
	public class HttpHandler : ContentPage
	{
		HttpClient httpClient;

		public HttpHandler ()
		{
			httpClient = new HttpClient ();
			httpClient.MaxResponseContentBufferSize = 256000;
			httpClient.Timeout = 20000;
		}
	}
}


