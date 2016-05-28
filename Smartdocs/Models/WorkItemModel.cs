using System;
using System.Collections.Generic;

namespace Smartdocs.Models
{
	public class AdminData
	{
		public string DocumnetType { get; set; }
		public string SAPWorkItem { get; set; }
		public string Mode { get; set; }
	}

	public class HeaderData
	{
		public string Advance_amount { get; set; }
		public string Company_name { get; set; }
		public string Other_deductions { get; set; }
		public string Remarks2 { get; set; }
		public string Remarks1 { get; set; }
		public string Nature_of_Work { get; set; }
		public string Retention { get; set; }
		public string Fund_Centre_Name { get; set; }
		public string Project_site { get; set; }
		public string WBS_Element { get; set; }
		public string Cost_Centre_No { get; set; }
		public string Date { get; set; }
		public string Invoice_Value { get; set; }
		public string Payment_Terms1 { get; set; }
		public string GL_Name { get; set; }
		public string GL_Cmtmt_item { get; set; }
		public string Vendor_Code { get; set; }
		public string Payment_Terms3 { get; set; }
		public string Net_amount_to_be_paid { get; set; }
		public string Payment_Terms2 { get; set; }
		public string Invoice_No { get; set; }
		public string Company_Code { get; set; }
		public string Budgeted_Amount { get; set; }
		public string Plant { get; set; }
		public string TDS_amount { get; set; }
		public string Budget_Utilized { get; set; }
		public string Vendor_Name { get; set; }
		public string Remarks3 { get; set; }
		public string Invoice_Date { get; set; }
		public string Agmt_Work_order_No { get; set; }
		public string Material_Service_status { get; set; }
		public string Cost_centre_Name { get; set; }
		public string Fund_Centre_No { get; set; }
		public string Network_Activity_No { get; set; }
		public string Inspection_Status { get; set; }
		public string Proforma_Invoice_No { get; set; }
		public string Project_Site { get; set; }
		public string Proforma_Invoice_Value { get; set; }
		public string Reference_No { get; set; }
		public string Net_Amount_to_be_paid { get; set; }
		public string Advance_Amount { get; set; }
		public string Cost_Centre_Name { get; set; }
		public string Inspected_by { get; set; }
		public string Network_activity_No { get; set; }
		public string Doc_Type { get; set; }
		public string Purchase_Group { get; set; }
		public string PO_Value { get; set; }
		public string Nature_Of_Contract { get; set; }
		public string Warranty { get; set; }
		public string Frieght_scope { get; set; }
		public string Project_Common_Infra { get; set; }
		public string Insurance_scope { get; set; }
		public string Purchase_Document_Type { get; set; }
		public string Vendor { get; set; }
		public string PO_Date { get; set; }
		public string Purchasing_Type { get; set; }
		public string Purchasing_Group { get; set; }
		public string Project { get; set; }
		public string Purchase_Order { get; set; }
		public string Work_Description { get; set; }
		public string GRN_Type { get; set; }
		public string PO_Number { get; set; }
		public string Mtrl_Work_Status2 { get; set; }
		public string Invoice_DC_JMS_No { get; set; }
		public string Mtrl_Work_Status1 { get; set; }
		public string Invoice_DC_JMS_Date { get; set; }
		public string Advance_Paid { get; set; }
		public string WTG_Model { get; set; }
		public string Reference_Id { get; set; }
		public string Scope_of_Work_BUIL { get; set; }
		public string Site_Name { get; set; }
		public string WTG_Capacity { get; set; }
		public string WTG_Quantity { get; set; }
		public string WTG_Make { get; set; }
		public string Scope_of_Work_SPV { get; set; }
		public string SPV_Name { get; set; }
		public string State { get; set; }
		public string Scope_of_Work_MEIL { get; set; }
		public string Capacity { get; set; }
		public string Phase { get; set; }
	}

	public class Log
	{
		public string User { get; set; }
		public object Comments { get; set; }
		public string Activity { get; set; }
		public string Time { get; set; }
		public string Date { get; set; }
	}

	public class Activity
	{
		public string CommentsRequired { get; set; }
		public string ButtonText { get; set; }
		public string ActivityName { get; set; }
		public object Icon { get; set; }
	}

	public class Attachment
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public string URL { get; set; }
	}

	public class WorkItem
	{
		public string workItemId { get; set; }
		public AdminData adminData { get; set; }
		public HeaderData headerData { get; set; }
		public List<Log> logs { get; set; }
		public List<Activity> activities { get; set; }
		public List<Attachment> attachments { get; set; }
	}
}

