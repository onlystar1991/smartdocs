﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smartdocs
{
	public partial class SettingPage : ContentPage
	{
		public SettingPage ()
		{
			InitializeComponent ();

			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}

