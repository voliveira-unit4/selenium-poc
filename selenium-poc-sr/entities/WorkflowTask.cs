using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_poc_sr.entities
{
    public class TaskDetails
    {
        public string col10Descr { get; set; }
        public string col10Value { get; set; }
        public string col1Descr { get; set; }
        public string col1Value { get; set; }
        public string col2Descr { get; set; }
        public string col2Value { get; set; }
        public string col3Descr { get; set; }
        public string col3Value { get; set; }
        public string col4Descr { get; set; }
        public string col4Value { get; set; }
        public string col5Descr { get; set; }
        public string col5Value { get; set; }
        public string col6Descr { get; set; }
        public string col6Value { get; set; }
        public string col7Descr { get; set; }
        public string col7Value { get; set; }
        public string col8Descr { get; set; }
        public string col8Value { get; set; }
        public string col9escr { get; set; }
        public string col9Value { get; set; }        
        public string distributionDate { get; set; }
        public string distributionType { get; set; }
        public string dueDate { get; set; }
        public string roleId { get; set; }
        public string taskCreated { get; set; }
        public string taskCreator { get; set; }
        public string taskImportance { get; set; }
        public string taskOwner { get; set; }
        public string workflowComment { get; set; }
        public string workflowStatus { get; set; }
    }

    public class WorkflowProcess
    {
        public string companyId { get; set; }
        public string elementTypeId { get; set; }
        public int nodeID { get; set; }
        public string objectId { get; set; }
        public string processDescription { get; set; }
        public int processVersion { get; set; }
        public string workflowUserStep { get; set; }
    }

    public class TaskAction
    {
        public string actionCode { get; set; }
        public string actionDescription { get; set; }
    }
    public class WorkflowTask
    {
        public string col2DataType { get; set; }
        public decimal id { get; set; }
        public string lockID { get; set; }
        public string loggedValues { get; set; }
        public string mapID { get; set; }
        public string revisionDescription { get; set; }
        public Boolean shareTask { get; set; }
        public TaskDetails taskDetails { get; set;}
        public WorkflowProcess workflowProcess { get; set; }
        public List<TaskAction> taskActions { get; set; }
    }
}
