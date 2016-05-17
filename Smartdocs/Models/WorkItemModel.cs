using System;
using System.Collections.Generic;

namespace Smartdocs
{
	public class AdminData 
	{
		public string DocumentType { get; set; }
		public string SAPWorkItem { get; set; }
		public string Mode { get; set; }
	}

	public class HeaderData
	{
		public string Nature_of_Work { get; set; }
		public string Company_name { get; set; }
		public string GL_Name { get; set; }
		public string GL_Cmtmt_item { get; set; }
		public string Plant { get; set; }
		public string Fund_Centre_Name { get; set; }
		public string Remarks2 { get; set; }
		public string Other_deductions { get; set; }
		public string Payment_Terms2 { get; set; }
		public string Fund_Centre_No { get; set; }
		public string Invoice_Value { get; set; }
		public string Retention { get; set; }
		public string Network_Activity_No { get; set; }
		public string Vendor_Name { get; set; }
		public string Budgeted_Amount { get; set; }
		public string Cost_centre_Name { get; set; }
		public string Material_Service_status { get; set; }
		public string Advance_amount { get; set; }
		public string Invoice_No { get; set; }
		public string Vendor_Code { get; set; }
		public string TDS_amount { get; set; }
		public string WBS_Element { get; set; }
		public string Remarks1 { get; set; }
		public string Date { get; set; }
		public string Company_Code { get; set; }
		public string Agmt_Work_order_No { get; set; }
		public string Payment_Terms3 { get; set; }
		public string Budget_Utilized { get; set; }
		public string Remarks3 { get; set; }
		public string Cost_Centre_No { get; set; }
		public string Invoice_Date { get; set; }
		public string Project_site { get; set; }
		public string Net_amount_to_be_paid { get; set; }
		public string Payment_Terms1 { get; set; }
	}

	public class Log
	{
		public string User { get; set; }
		public string Comments { get; set; }
		public string Activity { get; set; }
		public string Time { get; set; }
		public string Date { get; set; }
	}

	public class Activity
	{
		public string CommentsRequired { get; set; }
		public string ButtonText { get; set; }
		public string ActivityName { get; set; }
		public string Icon { get; set; }
	}

	public class Attachment
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public string URL { get; set; }
	}


	public class WorkItemModel
	{
		public string workItemId { get; set; }
		public AdminData adminData { get; set; }
		public HeaderData headerData { get; set; }

		public Log[] logs { get; set; }
		public Activity[] activities { get; set; }
		public Attachment[] attachments { get; set; }
	}


	public class WorkListObject {
		public WorkItemModel[] workItems { get; set; }
	}
}

