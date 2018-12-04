using System;
using System.IO;
using System.Linq;
using Mecalux.ITSW.EasyB.Model;
using Xunit;

namespace Mecalux.ITSW.EasyBService.Test
{
    
    public class FieldTypesTest
    {        
        #region Methods       

        [Fact]
        public void FieldTypeTest05SaverJSON()
        {
            FieldType fieldtype = CreateFieldType();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\FieldTypeTest05SaverJSON.EasyBpart", fieldtype);
            Assert.True(File.Exists(@".\Data\FieldTypeTest05SaverJSON.EasyBpart"));

            FieldType impfield = saver.ImportPart<FieldType>(@".\Data\FieldTypeTest05SaverJSON.EasyBpart");

            Assert.Equal(fieldtype.Guid, impfield.Guid);
            Assert.Equal(fieldtype.Name, impfield.Name);
            Assert.Equal(fieldtype.CheckDigit, impfield.CheckDigit);
            Assert.Equal(fieldtype.CheckStatus, impfield.CheckStatus);
            Assert.Equal(fieldtype.Description, impfield.Description);
            Assert.Equal(fieldtype.EditionLengthMode, impfield.EditionLengthMode);
            Assert.Equal(fieldtype.FillMode, impfield.FillMode);
            Assert.Equal(fieldtype.InputMask, impfield.InputMask);
            Assert.Equal(fieldtype.Length, impfield.Length);
            Assert.Equal(fieldtype.Stereotype, impfield.Stereotype);
            Assert.Equal(fieldtype.TruncateType, impfield.TruncateType);
            Assert.Equal(fieldtype.EntityStereotypeInternal, impfield.EntityStereotypeInternal);
        }
        [Fact]
        public void FieldTypeTest06SaverJSON()
        {

            FieldType fieldtype = CreateFieldType();
            ApplicationTag apptag = new ApplicationTag();
            Application app = new Application();
            app.Name = "APP_FieldTypeTest06";
            app.FieldTypeContainer.Add(fieldtype);
            apptag.Entity = app;

            SaverJson saver = new SaverJson();
            saver.ExportApplicationTag(@".\Data\", apptag);

            Assert.True(Directory.Exists(@".\Data\APP_FieldTypeTest06\FieldTypes"));

            var fileCount = (from file in Directory.EnumerateFiles(@".\Data\APP_FieldTypeTest06\FieldTypes", "*.EasyBpart", SearchOption.AllDirectories)
                             select file).Count();

            Assert.True(fileCount==1);
        }

        [Fact]
        public void FieldTypeTest07ImportJSON()
        {
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            Assert.True(File.Exists(@".\Data\FieldType-ObjectDictionary-{6e8b5c8a-9bae-4da0-a83b-3fb4690cbd86}.EasyBpart"));

            FieldType fieldtype = saver.ImportPart<FieldType>(@".\Data\FieldType-ObjectDictionary-{6e8b5c8a-9bae-4da0-a83b-3fb4690cbd86}.EasyBpart");

            Assert.Equal(fieldtype.Name, "ObjectDictionary");
            Assert.Equal(fieldtype.CheckDigit, CheckDigit.Modulus43);
            Assert.Equal(fieldtype.CheckStatus, CheckStatus.Default);
            Assert.Equal(fieldtype.EditionLengthMode, EditionLengthMode.AllowShorter);
            Assert.Equal(fieldtype.FillMode, FillMode.None);
            Assert.Equal(fieldtype.Length, 0);
            Assert.Equal(fieldtype.Stereotype, Stereotype.ObjectDictionary);
            Assert.Equal(fieldtype.TruncateType, TruncateType.TruncateRight);
            Assert.Equal(fieldtype.EntityStereotypeInternal.ToString(), "4740ce9f-bdfe-4ce6-b485-05b93cb9de57");
        }
        #endregion Methods

        #region Aux Methods
        private FieldType CreateFieldType()
        {
            FieldType fieldtype = new FieldType();
            fieldtype.Name = "AisleList";
            fieldtype.CheckDigit = CheckDigit.Modulus43;
            fieldtype.CheckStatus = CheckStatus.Default;
            fieldtype.Description = "Aisle list";
            fieldtype.EditionLengthMode = EditionLengthMode.AllowShorter;
            fieldtype.FillMode = FillMode.Zero;
            fieldtype.InputMask = "";
            fieldtype.Guid = Guid.Parse("0ae52206-7a2d-497a-af56-00f6f7e3eba6");
            fieldtype.Length = 0;
            fieldtype.Stereotype = Stereotype.List;
            fieldtype.TruncateType = TruncateType.TruncateRight;
            fieldtype.EntityStereotypeInternal = Guid.Parse("4f3283e6-9501-4a8e-b3bb-bc60d3ed3cea");
            return fieldtype;
        }
        #endregion
    }
}
