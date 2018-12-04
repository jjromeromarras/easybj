using System;
using Xunit;
using System.IO;
using System.Linq;
using Mecalux.ITSW.EasyB.Model;

namespace Mecalux.ITSW.EasyBService.Test
{
    public class DialogsTest
    {
        #region Test
        [Fact]
        public void DialogsTestTest05SaverJSON()
        {
            WorkflowUICommand obj = CreateObject();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\DialogsTest05SaverJSON.EasyBpart", obj);
            Assert.True(File.Exists(@".\Data\DialogsTest05SaverJSON.EasyBpart"));

            WorkflowUICommand imprecord = saver.ImportPart<WorkflowUICommand>(@".\Data\DialogsTest05SaverJSON.EasyBpart");

            Assert.Equal(imprecord.VersionId, obj.VersionId);
            Assert.Equal(imprecord.Name, obj.Name);
            Assert.Equal(imprecord.CheckStatus, obj.CheckStatus);
            Assert.Equal(imprecord.Description, obj.Description);
            Assert.Equal(imprecord.FormalParametersInternal.Count, obj.FormalParametersInternal.Count);
            Assert.Equal(imprecord.FormalParametersInternal.ElementAt(0).Name, obj.FormalParametersInternal.ElementAt(0).Name);

            Assert.Equal(imprecord.OptionsInternal.Count, obj.OptionsInternal.Count);
            Assert.Equal(imprecord.OptionsInternal.ElementAt(0), obj.OptionsInternal.ElementAt(0));

            Assert.Equal(imprecord.ListsInternal.Count(), obj.ListsInternal.Count());
            Assert.Equal(imprecord.ListsInternal.ElementAt(0).Name, obj.ListsInternal.ElementAt(0).Name);
            Assert.Equal(imprecord.FormatsInternal.Count(), obj.FormatsInternal.Count());
            Assert.Equal(imprecord.FormatsInternal.ElementAt(0).Height, obj.FormatsInternal.ElementAt(0).Height);

        }

         [Fact]
         public void DialogsTestTest06SaverJSON()
         {

             WorkflowUICommand obj = CreateObject();
             ApplicationTag apptag = new ApplicationTag();
             Application app = new Application();
             app.Name = "APP_WorkflowUICommandTest06";
             app.WorkflowUICommandContainer.Add(obj);
             apptag.Entity = app;

             SaverJson saver = new SaverJson();
             saver.ExportApplicationTag(@".\Data\", apptag);

             Assert.True(Directory.Exists(@".\Data\APP_WorkflowUICommandTest06\Dialogs"));

             var fileCount = (from file in Directory.EnumerateFiles(@".\Data\APP_WorkflowUICommandTest06\Dialogs", "*.EasyBpart", SearchOption.AllDirectories)
                              select file).Count();

             Assert.True(fileCount == 1);
         }
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
