using Mecalux.ITSW.EasyBServices.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Mecalux.ITSW.EasyBService.Test
{
    [TestClass]
    public class RecordsTest
    {
        #region Test
        [TestMethod]
        public void RecordTest04ImportJSON()
        {
            SaverJson saver = new SaverJson();
            Record imprecord = saver.ImportPart<Record>(@".\Data\Record-AdjustReasonCommentWF-{4838b7c9-8358-48c6-b10e-b187b485d909}.EasyBpart");

            Assert.AreEqual(imprecord.Name, "AdjustReasonCommentWF");
            Assert.AreEqual(imprecord.CheckStatus, CheckStatus.Default);
            Assert.AreEqual(imprecord.AutoUpdateLength, false);
            Assert.AreEqual(imprecord.RecordType, RecordType.FixedRecord);
            Assert.AreEqual(imprecord.FieldRecordsInternal.Count(), 2);

            Assert.AreEqual(imprecord.FieldRecordsInternal.ElementAt(0).Name, "Comment");
            Assert.AreEqual(imprecord.FieldRecordsInternal.ElementAt(0).FieldType, "FieldType-string-{e4660b14-dd69-4f56-8465-2e3100e8569b}.EasyBpart");
            Assert.AreEqual(imprecord.FieldRecordsInternal.ElementAt(1).Name, "Reason");
            Assert.AreEqual(imprecord.FieldRecordsInternal.ElementAt(1).FieldType, "FieldType-ReasonWF-{84e469e1-43f0-4405-9772-ada200776a98}.EasyBpart");


        }
        [TestMethod]
        public void RecordTest05SaverJSON()
        {
            Record obj = CreateRecord();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\RecordTest05SaverJSON.EasyBpart", obj);
            Assert.IsTrue(File.Exists(@".\Data\RecordTest05SaverJSON.EasyBpart"));

            Record imprecord= saver.ImportPart<Record>(@".\Data\RecordTest05SaverJSON.EasyBpart");
            
            Assert.AreEqual(imprecord.Guid, obj.Guid);
            Assert.AreEqual(imprecord.Name, obj.Name);
            Assert.AreEqual(imprecord.CheckStatus, obj.CheckStatus);
            Assert.AreEqual(imprecord.Description, obj.Description);
            Assert.AreEqual(imprecord.AutoUpdateLength, obj.AutoUpdateLength);
            Assert.AreEqual(imprecord.Separator, obj.Separator);
            Assert.AreEqual(imprecord.RecordType, obj.RecordType);
            Assert.AreEqual(imprecord.FieldRecordsInternal.Count(), obj.FieldRecordsInternal.Count());

        }
        [TestMethod]
        public void RecordTest06SaverJSON()
        {

            Record obj = CreateRecord();
            ApplicationTag apptag = new ApplicationTag();
            Application app = new Application();
            app.Name = "APP_RecordTest06";
            app.RecordContainer.Add(obj);
            apptag.Entity = app;

            SaverJson saver = new SaverJson();
            saver.ExportApplicationTag(@".\Data\", apptag);

            Assert.IsTrue(Directory.Exists(@".\Data\APP_RecordTest06\Records"));

            var fileCount = (from file in Directory.EnumerateFiles(@".\Data\APP_RecordTest06\Records", "*.EasyBpart", SearchOption.AllDirectories)
                             select file).Count();

            Assert.IsTrue(fileCount == 1);
        }
        #endregion

        #region Aux Methods
        private Record CreateRecord()
        {
            Record obj = new Record();
            obj.AutoUpdateLength = false;
            obj.Description = "Account";
            obj.Name = "AccountWF";
            obj.RecordType = RecordType.FixedRecord;
            obj.Separator = "";
            obj.CheckStatus = CheckStatus.Default;

            FieldRecord fr = new FieldRecord();
            fr.Name = "Id";
            fr.Length = 0;
            fr.Guid = Guid.Parse("9ae7d931-b14a-4855-b3ad-a0bdc8e9369f");
            fr.Start = 0;
            fr.FieldType = "FieldType-guid-{248cb253-1bd1-4166-9285-f7749a2b5a8d}.EasyBpart";            
            fr.End = 0;
            obj.AddFieldRecord(fr);

            fr = new FieldRecord();
            fr.Name = "Id";
            fr.Length = 10;
            fr.Guid = Guid.Parse("9ae7d932-b14a-4855-b3ad-a0bdc8e9369f");
            fr.Start = 0;
            fr.FieldType = "FieldType-guid-{248cb253-1bd1-4166-2285-f7749a2b5a8d}.EasyBpart";
            fr.End = 0;
            obj.AddFieldRecord(fr);
            return obj;
        }
        #endregion
    }
}
