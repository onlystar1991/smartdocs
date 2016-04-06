using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smartdocs
{
	public class WorkItemManager
	{
		HttpHandler _httpHandler;

		public WorkItemManager (HttpHandler httpHandler)
		{
			_httpHandler = httpHandler;
		}

		public Task<List<WorkItemModel>> GetAllWorkItems()
		{
			return _httpHandler.GetAllWorkItemsAsync ();
		}
	}
}

