using Mecalux.ITSW.EasyB.Model;

using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Mecalux.ITSW.EasyBService.Test
{
    
    public class WorkflowCommandTest
    {
        #region Test
        [Fact]
        public void WorkflowCommandTest05SaverJSON()
        {
            WorkflowCommand obj = CreateObject();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\WorkflowCommandTest05SaverJSON.EasyBpart", obj);
            Assert.True(File.Exists(@".\Data\WorkflowCommandTest05SaverJSON.EasyBpart"));

            WorkflowCommand imprecord = saver.ImportPart<WorkflowCommand>(@".\Data\WorkflowCommandTest05SaverJSON.EasyBpart");

            Assert.Equal(imprecord.VersionId, obj.VersionId);
            Assert.Equal(imprecord.Name, obj.Name);
            Assert.Equal(imprecord.CheckStatus, obj.CheckStatus);
            Assert.Equal(imprecord.Description, obj.Description);
            Assert.Equal(imprecord.WorkflowCommandType, obj.WorkflowCommandType);
            Assert.Equal(imprecord.FormalParametersInternal.Count, obj.FormalParametersInternal.Count);
            Assert.Equal(imprecord.FormalParametersInternal.ElementAt(0).Name, obj.FormalParametersInternal.ElementAt(0).Name);
        }

        [Fact]
        public void WorkflowCommandTest06SaverJSON()
        {

            WorkflowCommand obj = CreateObject();
            ApplicationTag apptag = new ApplicationTag();
            Application app = new Application();
            app.Name = "APP_WorkflowCommandTest06";
            app.WorkflowCommandContainer.Add(obj);
            apptag.Entity = app;

            SaverJson saver = new SaverJson();
            saver.ExportApplicationTag(@".\Data\", apptag);

            Assert.True(Directory.Exists(@".\Data\APP_WorkflowCommandTest06\Commands"));

            var fileCount = (from file in Directory.EnumerateFiles(@".\Data\APP_WorkflowCommandTest06\Commands", "*.EasyBpart", SearchOption.AllDirectories)
                             select file).Count();

            Assert.True(fileCount == 1);
        }
        #endregion

        #region Aux
        private WorkflowCommand CreateObject()
        {
            WorkflowCommand obj = new WorkflowCommand();
            obj.CheckStatus = CheckStatus.Default;
            obj.Description = "Command for activate a account";
            obj.InternalCommandName = "Mecalux.ITSW.EasyWMS.Modules.MasterData.Contracts.Commands.AccountActivateCommand, Mecalux.ITSW.EasyWMS.Modules.Contracts";
            obj.Guid = Guid.Parse("211c1a83-b796-4f7f-8fb3-2ec7e31cd751");
            obj.VersionId = Guid.Parse("211c1a83-b796-4f7f-8fb3-2ec7e31cd751");
            obj.Name = "AccountActivateCommand";
            obj.WorkflowCommandType = WorkflowCommandType.Bus;

            WorkflowFormalParameter fp = new WorkflowFormalParameter();
            fp.Description = "Account identifier";
            fp.EntityStereotypeInternal = Guid.Parse("4740ce9f-bdfe-4ce6-b485-05b93cb9de57");
            fp.Index = 0;
            fp.IsEditableParameter = false;
            fp.IsRequiredParameter = false;
            fp.Mode = WorkflowInOutMode.In;
            fp.Name = "AccountId";
            fp.Stereotype = Stereotype.Guid;
            fp.WorkflowFormalParameterType = WorkflowFormalParameterType.UserCreated;

            obj.AddFormaParameter(fp);
            return obj;
        }
        #endregion
    }

}
