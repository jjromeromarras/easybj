using Mecalux.ITSW.EasyBServices.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Mecalux.ITSW.EasyBService.Test
{
    [TestClass]
    public class EntityTest
    {
        #region Test
        
        [TestMethod]
        public void Entity05SaverJSON()
        {
            Entity obj = CreateEntity();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\EntityTest05SaverJSON.EasyBpart", obj);
            Assert.IsTrue(File.Exists(@".\Data\EntityTest05SaverJSON.EasyBpart"));

            Entity impobj= saver.ImportPart<Entity>(@".\Data\EntityTest05SaverJSON.EasyBpart");
            
            Assert.AreEqual(impobj.Guid, obj.Guid);
            Assert.AreEqual(impobj.Name, obj.Name);
            Assert.AreEqual(impobj.CheckStatus, obj.CheckStatus);
            Assert.AreEqual(impobj.Description, obj.Description);
            Assert.AreEqual(impobj.IsDataWarehouse, obj.IsDataWarehouse);
            Assert.AreEqual(impobj.IsNew, obj.IsNew);
            Assert.AreEqual(impobj.SingularName, obj.SingularName);
            Assert.AreEqual(impobj.PluralName, obj.PluralName);

            Assert.AreEqual(impobj.PropertiesInternal.Count(), obj.PropertiesInternal.Count());

            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).Name, obj.PropertiesInternal.ElementAt(0).Name);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).ColumnName, obj.PropertiesInternal.ElementAt(0).ColumnName);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).DataType.ToString(), obj.PropertiesInternal.ElementAt(0).DataType.ToString());
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).IsActiveProperty, obj.PropertiesInternal.ElementAt(0).IsActiveProperty);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).IsCustomField, obj.PropertiesInternal.ElementAt(0).IsCustomField);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).IsDataWarehouse, obj.PropertiesInternal.ElementAt(0).IsDataWarehouse);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).IsIndex, obj.PropertiesInternal.ElementAt(0).IsIndex);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).IsPrimaryKey, obj.PropertiesInternal.ElementAt(0).IsPrimaryKey);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).IsReadOnly, obj.PropertiesInternal.ElementAt(0).IsReadOnly);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).IsRequiered, obj.PropertiesInternal.ElementAt(0).IsRequiered);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).IsVisible, obj.PropertiesInternal.ElementAt(0).IsVisible);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).Lenght, obj.PropertiesInternal.ElementAt(0).Lenght);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).Precision, obj.PropertiesInternal.ElementAt(0).Precision);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(0).Title, obj.PropertiesInternal.ElementAt(0).Title);

            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).Name, obj.PropertiesInternal.ElementAt(1).Name);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).ColumnName, obj.PropertiesInternal.ElementAt(1).ColumnName);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).DataType.ToString(), obj.PropertiesInternal.ElementAt(1).DataType.ToString());
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).IsActiveProperty, obj.PropertiesInternal.ElementAt(1).IsActiveProperty);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).IsCustomField, obj.PropertiesInternal.ElementAt(1).IsCustomField);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).IsDataWarehouse, obj.PropertiesInternal.ElementAt(1).IsDataWarehouse);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).IsIndex, obj.PropertiesInternal.ElementAt(1).IsIndex);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).IsPrimaryKey, obj.PropertiesInternal.ElementAt(1).IsPrimaryKey);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).IsReadOnly, obj.PropertiesInternal.ElementAt(1).IsReadOnly);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).IsRequiered, obj.PropertiesInternal.ElementAt(1).IsRequiered);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).IsVisible, obj.PropertiesInternal.ElementAt(1).IsVisible);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).Lenght, obj.PropertiesInternal.ElementAt(1).Lenght);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).Precision, obj.PropertiesInternal.ElementAt(1).Precision);
            Assert.AreEqual(impobj.PropertiesInternal.ElementAt(1).Title, obj.PropertiesInternal.ElementAt(1).Title);

        }
        [TestMethod]
        public void Entity06SaverJSON()
        {

            Entity obj = CreateEntity();
            ApplicationTag apptag = new ApplicationTag();
            Application app = new Application();
            app.Name = "APP_EntityTest06";
            app.EntityContainer.Add(obj);
            apptag.Entity = app;

            SaverJson saver = new SaverJson();
            saver.ExportApplicationTag(@".\Data\", apptag);

            Assert.IsTrue(Directory.Exists(@".\Data\APP_EntityTest06\Entities"));

            var fileCount = (from file in Directory.EnumerateFiles(@".\Data\APP_EntityTest06\Entities", "*.EasyBpart", SearchOption.AllDirectories)
                             select file).Count();

            Assert.IsTrue(fileCount == 1);
        }
        #endregion

        #region Aux Methods
        private Entity CreateEntity()
        {
            Entity obj = new Entity();
            obj.Description = "Reading model for an account";
            obj.Name = "Account";
            obj.CheckStatus = CheckStatus.Default;
            obj.FromMetadata = true;
            obj.IsDataWarehouse = false;
            obj.Guid = Guid.Parse("836ba28e-e640-405b-aff8-29c137005344");
            obj.SingularName = "050c3c81-2a72-4960-ad98-92f220328630";
            obj.PluralName = "3ddad1ed-255a-4fd0-a5a6-1501f68d17cb";
            obj.TableName = "Accounts";

            Property fr = new Property();
            fr.Name = "AccountTypeCode";
            fr.Guid = Guid.Parse("c00a0b9c-0fdb-416f-8584-a42746189d45");
            fr.ColumnName = "AccountTypeCode";
            fr.DataType = PropertyDataType.String;
            fr.Help = "Gets or sets the account type code.";
            fr.IsActiveProperty = false;
            fr.IsCustomField = false;
            fr.IsDataWarehouse = false;
            fr.IsIndex = false;
            fr.IsPrimaryKey = false;
            fr.IsReadOnly = false;
            fr.IsRequiered = false;
            fr.IsVisible = true;
            fr.Lenght = 50;
            fr.Precision = 0;
            fr.Title = "f694d499-822e-4df1-93fe-b5f5b3273162";

            obj.AddProperty(fr);

            fr = new Property();
            fr.Name = "AccountTypeId";
            fr.Guid = Guid.Parse("c00a0b9c-0fdb-416f-8584-a42746189d45");
            fr.ColumnName = "AccountTypeId";
            fr.DataType = PropertyDataType.Guid;
            fr.Help = "Gets or sets the account type identifier.";
            fr.IsActiveProperty = false;
            fr.IsCustomField = false;
            fr.IsDataWarehouse = false;
            fr.IsIndex = false;
            fr.IsPrimaryKey = false;
            fr.IsReadOnly = false;
            fr.IsRequiered = false;
            fr.IsVisible = false;
            fr.Lenght = 16;
            fr.Precision = 0;
            fr.Title = "c66fda6e-49cf-47ff-b855-922928fbdfaf";

            obj.AddProperty(fr);
            return obj;
        }
        
        #endregion
    }
}
