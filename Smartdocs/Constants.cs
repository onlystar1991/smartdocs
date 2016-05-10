using System;

using Xamarin.Forms;

namespace Smartdocs
{
	public class Constants
	{
		public static string SERVER_URL = "http://1-dot-dummyrestapis.appspot.com/";
		public static string GET_WORKITEMS_URL = "getWorkItemDataList";
		public static string LOGIN_API = "getInitiateRequestCreation/json/?";


		public static int SERVER_MAX_BUFF = 256000;
		public static int SERVER_TIMEOUT = 20000;
		public static string USER_NAME = "admin";
		public static string PASSWORD = "admin";
	}
}