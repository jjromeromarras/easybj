using Mecalux.ITSW.EasyB.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Mecalux.ITSW.EasyBService.Test
{
    [TestClass]
    public class DialogsTest
    {
        #region Test
        [TestMethod]
        public void DialogsTestTest05SaverJSON()
        {
            WorkflowUICommand obj = CreateObject();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\DialogsTest05SaverJSON.EasyBpart", obj);
            Assert.IsTrue(File.Exists(@".\Data\DialogsTest05SaverJSON.EasyBpart"));

            /*WorkflowCommand imprecord = saver.ImportPart<WorkflowCommand>(@".\Data\DialogsTest05SaverJSON.EasyBpart");

            Assert.AreEqual(imprecord.VersionId, obj.VersionId);
            Assert.AreEqual(imprecord.Name, obj.Name);
            Assert.AreEqual(imprecord.CheckStatus, obj.CheckStatus);
            Assert.AreEqual(imprecord.Description, obj.Description);
            Assert.AreEqual(imprecord.WorkflowCommandType, obj.WorkflowCommandType);
            Assert.AreEqual(imprecord.FormalParametersInternal.Count, obj.FormalParametersInternal.Count);
            Assert.AreEqual(imprecord.FormalParametersInternal.ElementAt(0).Name, obj.FormalParametersInternal.ElementAt(0).Name);*/
        }

       /* [TestMethod]
        public void DialogsTestTest06SaverJSON()
        {

            WorkflowCommand obj = CreateObject();
            ApplicationTag apptag = new ApplicationTag();
            Application app = new Application();
            app.Name = "APP_WorkflowCommandTest06";
            app.WorkflowCommandContainer.Add(obj);
            apptag.Entity = app;

            SaverJson saver = new SaverJson();
            saver.ExportApplicationTag(@".\Data\", apptag);

            Assert.IsTrue(Directory.Exists(@".\Data\APP_WorkflowCommandTest06\Commands"));

            var fileCount = (from file in Directory.EnumerateFiles(@".\Data\APP_WorkflowCommandTest06\Commands", "*.EasyBpart", SearchOption.AllDirectories)
                             select file).Count();

            Assert.IsTrue(fileCount == 1);
        }*/
        #endregion

        #region Aux
        private WorkflowUICommand CreateObject()
        {
            WorkflowUICommand obj = new WorkflowUICommand();
            obj.CheckStatus = CheckStatus.Default;
            obj.Description = "Select adjust reason";
            obj.Guid = Guid.Parse("3bbc42bf-df1f-41c7-b203-42dff51a58e4");
            obj.VersionId = Guid.Parse("3bbc42bf-df1f-41c7-b203-42dff51a58e4");
            obj.Name = "AdjustReason_SelectReason";
            obj.IsSelector = true;
            obj.SelectorList = "DialogList-Dialog-{3bbc42bf-df1f-41c7-b203-42dff51a58e4}-AdjustReason_SelectReason-ReasonList";
            obj.ShowPromptDefaultValue = false;
            obj.WorkflowUICommandEditionKind = WorkflowUICommandEditionKind.Parameters;
            obj.WorkflowUICommandPromptTypeInternal = WorkflowUICommandPromptType.Integer;

            WorkflowFormalParameter fp = new WorkflowFormalParameter();
            fp.Description = "Action string";
            fp.EntityStereotypeInternal = Guid.Parse("4740ce9f-bdfe-4ce6-b485-05b93cb9de57");
            fp.Index = 0;
            fp.IsEditableParameter = false;
            fp.IsRequiredParameter = false;
            fp.Mode = WorkflowInOutMode.Out;
            fp.Name = "Action";
            fp.Stereotype = Stereotype.String;
            fp.WorkflowFormalParameterType = WorkflowFormalParameterType.Mandatory;
            obj.AddWorkflowFormalParameter(fp);

            WorkflowUICommandFormat cf = new WorkflowUICommandFormat();
            cf.Height = 320;
            cf.IsDefault = true;
            cf.Name = "Format";
            cf.IsDefault = true;
            cf.UIXml = "<UIFormat> <header>{param:Header}</header> <body> <label visible=\"{list:ReasonList.HasPages}\" style=\"right\">{res:PageCounter,{list:ReasonList.Page},{list:ReasonList.PageCount}}</label>" +
                " <label>{res:AdjustStock_SelectAdjustReason}</label> <list name=\"ReasonList\" index=\"0\">1.-{list:ReasonList[0].Code}</list> <list name=\"ReasonList\" index=\"1\">2.-{list:ReasonList[1].Code}</list> <list name=\"ReasonList\" index=\"2\">3.-{list:ReasonList[2].Code}</list>" +
                " <list name=\"ReasonList\" index=\"3\">4.-{list:ReasonList[3].Code}</list>  <prompt></prompt> <option accesskey=\"1\" name=\"PreviousPage\" visible=\"{list:ReasonList.HasPages}\">{res:Previous}</option>" +
                " <option accesskey=\"2\" name=\"NextPage\" visible=\"{list:ReasonList.HasPages}\">{res:Next}</option> </body> <footer>{param:Footer}</footer> </UIFormat>";
            cf.Width= 240;
            cf.WorkflowUICommandFormatType = WorkflowUICommandFormatType.UI;
            obj.AddWorkflowUICommandFormat(cf);

            obj.OptionsInternal.Add("PreviousPage");
            obj.OptionsInternal.Add("NextPage");

            WorkflowUICommandList list = new WorkflowUICommandList();
            list.Name = "ReasonList";
            list.NavigationNextPageOptionInternal = "NextPage";
            list.NavigationOptionsExitsDialog = WorkflowUICommandNavigationOptions.None;
            list.NavigationPreviousPageOptionInternal = "PreviousPage";
            list.SelectedValueParameterName = "FOPA-Dialog-{3bbc42bf-df1f-41c7-b203-42dff51a58e4}-SelectedReason";
            list.SelectOptionDisplayProperty = "Code";

            obj.AddWorkflowUICommandList(list);
            return obj;
        }
        #endregion
    }

}
