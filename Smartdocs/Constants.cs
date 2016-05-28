using System;

using Xamarin.Forms;

namespace Smartdocs
{
	public class Constants
	{
		public static string GET_WORKITEMS_URL = "getWorkItemDataList";

		public static string SERVER = "http://130.211.130.79:8080/";
		public static string LOGIN_API = "rest/authentication/getToken";
		public static string SECRET_TOKEN { get; set; }
	}
}