using Mecalux.ITSW.EasyBServices.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Mecalux.ITSW.EasyBService.Test
{
    [TestClass]
    public class RecordListTest
    {
        #region Test
        [TestMethod]
        public void RecordListTest05SaverJSON()
        {
            RecordList obj = CreateRecordList();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\RecordListTest05SaverJSON.EasyBpart", obj);
            Assert.IsTrue(File.Exists(@".\Data\RecordListTest05SaverJSON.EasyBpart"));

            RecordList imprecord = saver.ImportPart<RecordList>(@".\Data\RecordListTest05SaverJSON.EasyBpart");

            Assert.AreEqual(imprecord.Guid, obj.Guid);
            Assert.AreEqual(imprecord.Name, obj.Name);
            Assert.AreEqual(imprecord.CheckStatus, obj.CheckStatus);
            Assert.AreEqual(imprecord.Description, obj.Description);
            Assert.AreEqual(imprecord.Files, obj.Files);
            Assert.AreEqual(imprecord.Record, obj.Record);

        }

        [TestMethod]
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

            Assert.IsTrue(Directory.Exists(@".\Data\APP_RecordListTest06\Records"));

            var fileCount = (from file in Directory.EnumerateFiles(@".\Data\APP_RecordListTest06\Lists", "*.EasyBpart", SearchOption.AllDirectories)
                             select file).Count();

            Assert.IsTrue(fileCount == 1);
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
