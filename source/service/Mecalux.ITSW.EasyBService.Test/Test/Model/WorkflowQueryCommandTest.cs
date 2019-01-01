using Mecalux.ITSW.EasyB.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Mecalux.ITSW.EasyBService.Test
{
    [TestClass]
    public class WorkflowQueryCommandTest
    {
        #region Test
        [TestMethod]
        public void WorkflowQueryCommandTest05SaverJSON()
        {
            WorkflowQueryCommand obj = CreateObject();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\WorkflowQueryCommandTest05SaverJSON.EasyBpart", obj);
            Assert.IsTrue(File.Exists(@".\Data\WorkflowQueryCommandTest05SaverJSON.EasyBpart"));

            WorkflowQueryCommand imprecord = saver.ImportPart<WorkflowQueryCommand>(@".\Data\WorkflowQueryCommandTest05SaverJSON.EasyBpart");

            Assert.AreEqual(imprecord.VersionId, obj.VersionId);
            Assert.AreEqual(imprecord.Name, obj.Name);
            Assert.AreEqual(imprecord.CheckStatus, obj.CheckStatus);
            Assert.AreEqual(imprecord.Description, obj.Description);
            Assert.AreEqual(imprecord.QueryType, obj.QueryType);
            Assert.AreEqual(imprecord.FormalParametersInternal.Count, obj.FormalParametersInternal.Count);
            Assert.AreEqual(imprecord.FormalParametersInternal.ElementAt(0).Name, obj.FormalParametersInternal.ElementAt(0).Name);
        }

        [TestMethod]
        public void WorkflowQueryCommandTest06SaverJSON()
        {

            WorkflowQueryCommand obj = CreateObject();
            ApplicationTag apptag = new ApplicationTag();
            Application app = new Application();
            app.Name = "APP_WorkflowQueryCommandTest06";
            app.WorkflowQueryCommandContainer.Add(obj);
            apptag.Entity = app;

            SaverJson saver = new SaverJson();
            saver.ExportApplicationTag(@".\Data\", apptag);

            Assert.IsTrue(Directory.Exists(@".\Data\APP_WorkflowQueryCommandTest06\Queries"));

            var fileCount = (from file in Directory.EnumerateFiles(@".\Data\APP_WorkflowQueryCommandTest06\Queries", "*.EasyBpart", SearchOption.AllDirectories)
                             select file).Count();

            Assert.IsTrue(fileCount == 1);
        }
        #endregion

        #region Aux
        private WorkflowQueryCommand CreateObject()
        {
            WorkflowQueryCommand obj = new WorkflowQueryCommand();
            obj.CheckStatus = CheckStatus.Default;
            obj.Description = "Gets all containers remounted over a given container code";
            obj.Expression = "Context.Containers.GetEntityByUnique(c=>c.UniqueCode,containerCode).TransformOrDefault(c => c.ContainersTotal, Enumerable.Empty<Mecalux.ITSW.EasyWMS.Modules.MasterData.Contracts.Domain.IContainer>())";
            obj.Guid = Guid.Parse("a56e0b2d-9a12-4420-8f42-f8042c119d8d");
            obj.VersionId = Guid.Parse("a56e0b2d-9a12-4420-8f42-f8042c119d8d");
            obj.Name = "Container_GetContainersTotalByParentContainerCode";
            obj.QueryType = WorkflowQueryCommandType.Writing;

            WorkflowFormalParameter fp = new WorkflowFormalParameter();
            fp.Description = "Container code";
            fp.EntityStereotypeInternal = Guid.Parse("4740ce9f-bdfe-4ce6-b485-05b93cb9de57");
            fp.Index = 0;
            fp.IsEditableParameter = false;
            fp.IsRequiredParameter = false;
            fp.Mode = WorkflowInOutMode.In;
            fp.Name = "containerCode";
            fp.Stereotype = Stereotype.String;
            fp.WorkflowFormalParameterType = WorkflowFormalParameterType.UserCreated;

            obj.AddFormaParameter(fp);
            return obj;
        }
        #endregion
    }

}
