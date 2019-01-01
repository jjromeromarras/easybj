using Mecalux.ITSW.EasyB.Model;

using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Mecalux.ITSW.EasyBService.Test
{
    
    public class RecordsTest
    {
        #region Test
        [Fact]
        public void RecordTest04ImportJSON()
        {
            SaverJson saver = new SaverJson();
            EasyB.Model.Record imprecord = saver.ImportPart<EasyB.Model.Record>(@".\Data\Record-AdjustReasonCommentWF-{4838b7c9-8358-48c6-b10e-b187b485d909}.EasyBpart");

            Assert.Equal("AdjustReasonCommentWF", imprecord.Name);
            Assert.Equal(CheckStatus.Default, imprecord.CheckStatus);
            Assert.False(imprecord.AutoUpdateLength);
            Assert.Equal(RecordType.FixedRecord, imprecord.RecordType);
            Assert.Equal(2, imprecord.FieldRecordsInternal.Count());

            Assert.Equal("Comment", imprecord.FieldRecordsInternal.ElementAt(0).Name);
            Assert.Equal("FieldType-string-{e4660b14-dd69-4f56-8465-2e3100e8569b}.EasyBpart", imprecord.FieldRecordsInternal.ElementAt(0).FieldType);
            Assert.Equal("Reason", imprecord.FieldRecordsInternal.ElementAt(1).Name);
            Assert.Equal("FieldType-ReasonWF-{84e469e1-43f0-4405-9772-ada200776a98}.EasyBpart", imprecord.FieldRecordsInternal.ElementAt(1).FieldType);


        }
        [Fact]
        public void RecordTest05SaverJSON()
        {
            EasyB.Model.Record obj = CreateRecord();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\RecordTest05SaverJSON.EasyBpart", obj);
            Assert.True(File.Exists(@".\Data\RecordTest05SaverJSON.EasyBpart"));

            EasyB.Model.Record imprecord = saver.ImportPart<EasyB.Model.Record>(@".\Data\RecordTest05SaverJSON.EasyBpart");
            
            Assert.Equal(imprecord.Guid, obj.Guid);
            Assert.Equal(imprecord.Name, obj.Name);
            Assert.Equal(imprecord.CheckStatus, obj.CheckStatus);
            Assert.Equal(imprecord.Description, obj.Description);
            Assert.Equal(imprecord.AutoUpdateLength, obj.AutoUpdateLength);
            Assert.Equal(imprecord.Separator, obj.Separator);
            Assert.Equal(imprecord.RecordType, obj.RecordType);
            Assert.Equal(imprecord.FieldRecordsInternal.Count(), obj.FieldRecordsInternal.Count());

        }
        [Fact]
        public void RecordTest06SaverJSON()
        {

            EasyB.Model.Record obj = CreateRecord();
            ApplicationTag apptag = new ApplicationTag();
            Application app = new Application();
            app.Name = "APP_RecordTest06";
            app.RecordContainer.Add(obj);
            apptag.Entity = app;

            SaverJson saver = new SaverJson();
            saver.ExportApplicationTag(@".\Data\", apptag);

            Assert.True(Directory.Exists(@".\Data\APP_RecordTest06\Records"));

            var fileCount = (from file in Directory.EnumerateFiles(@".\Data\APP_RecordTest06\Records", "*.EasyBpart", SearchOption.AllDirectories)
                             select file).Count();

            Assert.True(fileCount == 1);
        }
        #endregion

        #region Aux Methods
        private EasyB.Model.Record CreateRecord()
        {
            EasyB.Model.Record obj = new EasyB.Model.Record();
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
