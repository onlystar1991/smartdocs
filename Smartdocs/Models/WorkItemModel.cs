using System;
using System.Collections.Generic;

namespace Smartdocs
{
	public class WorkItemModel
	{
		List<DocDataModel> _docDatas;
		public List<DocDataModel> DocDatas {
			get { return _docDatas; }
			set {
				foreach (DocDataModel field in value) {
					DocDataModel model = new DocDataModel ();
					model.Initiator = field.Initiator;
					model.DocDateTime = field.DocDateTime;
					model.DocType = field.DocType;
					model.DocTypeId = field.DocTypeId;
					model.DocName = field.DocName;
					model.DocDesc = field.DocDesc;
					_docDatas.Add (model);
				}
			}
		}

		List<HeaderModel> _headers;
		public List<HeaderModel> HeaderModels {
			get { return _headers; }
			set {
				foreach (HeaderModel field in value) {
					HeaderModel model = new HeaderModel ();
					model.WorkItemId = field.WorkItemId;
					model.Fields = field.Fields;

					_headers.Add (model);
				}
			}
		}

		List<WorkFlowFieldModel> _workFlowFields;
		public List<WorkFlowFieldModel> WorkFlowFields {
			get { return _workFlowFields; }
			set {
				foreach (WorkFlowFieldModel field in value) {
					WorkFlowFieldModel model = new WorkFlowFieldModel ();
					model.FieldId = field.FieldId;
					model.FieldName = field.FieldName;
					model.FieldValue = field.FieldValue;
					model.SequenceNo = field.SequenceNo;
					_workFlowFields.Add (model);
				}
			}
		}

		List<LogModel> _logs;
		public List<LogModel> Logs {
			get { return _logs; }
			set { 
				foreach (LogModel field in value) {
					LogModel model = new LogModel ();
					model.DocId = field.DocId;
					model.FlowId = field.FlowId;
					model.WorkItemId = field.WorkItemId;
					model.Activity = field.Activity;
					model.Comments = field.Comments;
					model.CurrentAgent = field.CurrentAgent;

					_logs.Add (model);
				}
			}
		}
	}
}

