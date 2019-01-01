using Mecalux.ITSW.EasyB.Model;

using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Mecalux.ITSW.EasyBService.Test
{
    
    public class RecordListTest
    {
        #region Test
        [Fact]
        public void RecordListTest05SaverJSON()
        {
            RecordList obj = CreateRecordList();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\RecordListTest05SaverJSON.EasyBpart", obj);
            Assert.True(File.Exists(@".\Data\RecordListTest05SaverJSON.EasyBpart"));

            RecordList imprecord = saver.ImportPart<RecordList>(@".\Data\RecordListTest05SaverJSON.EasyBpart");

            Assert.Equal(imprecord.Guid, obj.Guid);
            Assert.Equal(imprecord.Name, obj.Name);
            Assert.Equal(imprecord.CheckStatus, obj.CheckStatus);
            Assert.Equal(imprecord.Description, obj.Description);
            Assert.Equal(imprecord.Files, obj.Files);
            Assert.Equal(imprecord.Record, obj.Record);

        }

        [Fact]
        public void RecordListTest06SaverJSON()
        {

            RecordList obj = CreateRecordList();
            ApplicationTag apptag = new ApplicationTag();
            Application app = new Application();
            app.Name = "APP_RecordListTest06";
            app.RecordListContainer.Add(obj);
            apptag.Entity = app;

            SaverJson saver = new SaverJson();
            saver.ExportApplicationTag(@".\Data\", apptag);

            Assert.True(Directory.Exists(@".\Data\APP_RecordListTest06\Lists"));

            var fileCount = (from file in Directory.EnumerateFiles(@".\Data\APP_RecordListTest06\Lists", "*.EasyBpart", SearchOption.AllDirectories)
                             select file).Count();

            Assert.True(fileCount == 1);
        }
        #endregion

        #region Aux
        private RecordList CreateRecordList()
        {
            RecordList obj = new RecordList();
            obj.CheckStatus = CheckStatus.Deleted;
            obj.Description = "Description";
            obj.Files = 2;
            obj.Guid = Guid.Parse("4f3283e6-9501-4a8e-b3bb-bc60d3ed3cea");
            obj.Name = "AisleList";
            obj.Record = "Record-AisleWF-{a36b49e1-27bb-4c37-8bc9-7f83f34a9984}.EasyBpart";
            return obj;
        }
        #endregion
    }

}
