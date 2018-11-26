using Mecalux.ITSW.EasyB.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Mecalux.ITSW.EasyBService.Test
{
    [TestClass]
    public class EventTest
    {
        #region Test
        [TestMethod]
        public void EventTestTest05SaverJSON()
        {
            Event obj = CreateObject();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\EventTest05SaverJSON.EasyBpart", obj);
            Assert.IsTrue(File.Exists(@".\Data\EventTest05SaverJSON.EasyBpart"));

            Event impobj = saver.ImportPart<Event>(@".\Data\EventTest05SaverJSON.EasyBpart");

            Assert.AreEqual(impobj.VersionId, obj.VersionId);
            Assert.AreEqual(impobj.Name, obj.Name);
            Assert.AreEqual(impobj.CheckStatus, obj.CheckStatus);
            Assert.AreEqual(impobj.Description, obj.Description);
            Assert.AreEqual(impobj.PropertiesInternal.Count, obj.PropertiesInternal.Count);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).Name, obj.PropertiesInternal.ElementAt(0).Name);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).DataType.ToString(), obj.PropertiesInternal.ElementAt(1).DataType.ToString());
        }

         [TestMethod]
         public void DialogsTestTest06SaverJSON()
         {

             Event obj = CreateObject();
             ApplicationTag apptag = new ApplicationTag();
             Application app = new Application();
             app.Name = "APP_EventTest06";
             app.EventContainer.Add(obj);
             apptag.Entity = app;

             SaverJson saver = new SaverJson();
             saver.ExportApplicationTag(@".\Data\", apptag);

             Assert.IsTrue(Directory.Exists(@".\Data\APP_EventTest06\Events"));

             var fileCount = (from file in Directory.EnumerateFiles(@".\Data\APP_EventTest06\Events", "*.EasyBpart", SearchOption.AllDirectories)
                              select file).Count();

             Assert.IsTrue(fileCount == 1);
         }
        #endregion

        #region Aux
        private Event CreateObject()
        {
            Event obj = new Event();
            obj.CheckStatus = CheckStatus.Default;
            obj.Description = "An account has been activated.";
            obj.Guid = Guid.Parse("22a1d55d-2feb-4f5f-93d3-56658772a700");
            obj.VersionId = Guid.Parse("22a1d55d-2feb-4f5f-93d3-56658772a700");
            obj.Name = "AccountActivatedEvent";
            obj.IsPublic = false;
            obj.InternalName = "Mecalux.ITSW.EasyWMS.Modules.MasterData.Contracts.Events.AccountActivatedEvent, Mecalux.ITSW.EasyWMS.Modules.Contracts";

            EventProperty p1 = new EventProperty();
            p1.DataType = EventPropertyDataType.NullableGuid;
            p1.Description = "Gets or sets the carrier identifier";
            p1.Name = "AgencyId";
            obj.AddEventProperty(p1);

            EventProperty p2 = new EventProperty();
            p2.DataType = EventPropertyDataType.Guid;
            p2.Name = "SourceId";
            obj.AddEventProperty(p2);
            return obj;
        }
        #endregion
    }

}
