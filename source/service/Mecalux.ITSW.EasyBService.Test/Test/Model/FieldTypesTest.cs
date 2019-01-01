using System;
using System.IO;
using System.Linq;
using Mecalux.ITSW.Core.Abstraction.Testing;
using Mecalux.ITSW.EasyB.Model;
using Mecalux.ITSW.EasyBServices.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mecalux.ITSW.EasyBService.Test
{
    [TestClass]
    public class FieldTypesTest
    {        
        #region Methods

        /// <summary>
        /// En la creación de un FieldType es obligatorio indicar:
        /// TipoBase, TruncateType, EditionLengthMode, FillMode, CheckDigit
        /// </summary>
        [TestMethod, TestCategory(TimeCategoryTest.Continuous), TestCategory(TypeCategoryTest.UnitTest), TestCategory(ApplicationDictionaryEntities.FieldType), TestCategory(SourceCategoryTest.Config), TestCategory(ApplicationDictionaryTestCategory.EasyBuilderModel)]
        public void FieldTypeTest01Creation()
        {
            FieldType fieldtype = new FieldType();

            fieldtype.Name = "AisleList";
            fieldtype.CheckDigit = CheckDigit.Modulus43;
            fieldtype.CheckStatus = CheckStatus.Default;
            fieldtype.Description = "Aisle list";
            fieldtype.EditionLengthMode = EditionLengthMode.AllowShorter;
            fieldtype.FillMode = FillMode.Blank;
            fieldtype.InputMask = "";
            fieldtype.Guid = Guid.Parse("0ae52206-7a2d-497a-af56-00f6f7e3eba6");
            fieldtype.Length = 0;
            fieldtype.Stereotype = Stereotype.Date;
            fieldtype.TruncateType = TruncateType.TruncateRight;
            fieldtype.EntityStereotypeInternal = Guid.Parse("4f3283e6-9501-4a8e-b3bb-bc60d3ed3cea");

            Assert.AreEqual(fieldtype.Stereotype, Stereotype.Date, "Fallo en el constructor con parámetros");
            Assert.AreEqual(fieldtype.CheckDigit, CheckDigit.Modulus43, "Fallo en el constructor con parámetros");
            Assert.AreEqual(fieldtype.EditionLengthMode, EditionLengthMode.AllowShorter, "Fallo en el constructor con parámetros");
            Assert.AreEqual(fieldtype.FillMode, FillMode.Blank, "Fallo en el constructor con parámetros");
            Assert.AreEqual(fieldtype.TruncateType, TruncateType.TruncateRight, "Fallo en el constructor con parámetros");
        }
        
        /// <summary>
        /// Crear un tipo de dato nuevo implica crear un GUID
        /// </summary>
        [TestMethod, TestCategory(TimeCategoryTest.Continuous), TestCategory(TypeCategoryTest.UnitTest), TestCategory(ApplicationDictionaryEntities.FieldType), TestCategory(SourceCategoryTest.Config), TestCategory(ApplicationDictionaryTestCategory.EasyBuilderModel)]
        public void FieldTypeTest02GenerateGuidOnCreation()
        {
            FieldType fieldType = new FieldType();
            Assert.AreNotEqual(fieldType.Guid, Guid.Empty, "No se ha creado un GUID");
        }

        /// <summary>
        /// Al crear un nuevo tipo de dato se marcará directamente como nuevo
        /// </summary>
        [TestMethod, TestCategory(TimeCategoryTest.Continuous), TestCategory(TypeCategoryTest.UnitTest), TestCategory(ApplicationDictionaryEntities.FieldType), TestCategory(SourceCategoryTest.Config), TestCategory(ApplicationDictionaryTestCategory.EasyBuilderModel)]
        public void FieldTypeTest03OnCreationMarkAsNew()
        {
            FieldType fieldType = new FieldType();
            Assert.AreEqual(fieldType.CheckStatus, CheckStatus.New, "No se ha marcado la entidad como nueva al construirla");
        }

        /// <summary>
        /// Caso de uso: Probar el método Delete. Se borra el elemento de la colección padre y del repositorio.
        /// Test: El elemento esta en estado editable. Se debe eliminar correctamente
        /// </summary>
        [TestMethod, TestCategory(TimeCategoryTest.Continuous), TestCategory(TypeCategoryTest.UnitTest), TestCategory(ApplicationDictionaryEntities.FieldType), TestCategory(SourceCategoryTest.Config), TestCategory(ApplicationDictionaryTestCategory.EasyBuilderModel)]
        public void FieldTypeTest04DeleteCorrect()
        {
            Application application = new Application("Application", string.Empty);
            FieldTypeContainer container = application.FieldTypeContainer;
            FieldType fieldType = new FieldType();
            container.Add(fieldType);

            Assert.AreEqual(1, container.FieldTypeListsInternal.Count());
            Assert.IsTrue(container.Remove(fieldType));
            Assert.AreEqual(0, container.FieldTypeListsInternal.Count());
        }

        [TestMethod]
        public void FieldTypeTest05SaverJSON()
        {
            FieldType fieldtype = CreateFieldType();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\FieldTypeTest05SaverJSON.EasyBpart", fieldtype);
            Assert.IsTrue(File.Exists(@".\Data\FieldTypeTest05SaverJSON.EasyBpart"));

            FieldType impfield = saver.ImportPart<FieldType>(@".\Data\FieldTypeTest05SaverJSON.EasyBpart");

            Assert.AreEqual(fieldtype.Guid, impfield.Guid);
            Assert.AreEqual(fieldtype.Name, impfield.Name);
            Assert.AreEqual(fieldtype.CheckDigit, impfield.CheckDigit);
            Assert.AreEqual(fieldtype.CheckStatus, impfield.CheckStatus);
            Assert.AreEqual(fieldtype.Description, impfield.Description);
            Assert.AreEqual(fieldtype.EditionLengthMode, impfield.EditionLengthMode);
            Assert.AreEqual(fieldtype.FillMode, impfield.FillMode);
            Assert.AreEqual(fieldtype.InputMask, impfield.InputMask);
            Assert.AreEqual(fieldtype.Length, impfield.Length);
            Assert.AreEqual(fieldtype.Stereotype, impfield.Stereotype);
            Assert.AreEqual(fieldtype.TruncateType, impfield.TruncateType);
            Assert.AreEqual(fieldtype.EntityStereotypeInternal, impfield.EntityStereotypeInternal);
        }
        [TestMethod]
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

            Assert.IsTrue(Directory.Exists(@".\Data\APP_FieldTypeTest06\FieldTypes"));

            var fileCount = (from file in Directory.EnumerateFiles(@".\Data\APP_FieldTypeTest06\FieldTypes", "*.EasyBpart", SearchOption.AllDirectories)
                             select file).Count();

            Assert.IsTrue(fileCount==1);
        }

        [TestMethod]
        public void FieldTypeTest07ImportJSON()
        {
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            Assert.IsTrue(File.Exists(@".\Data\FieldType-ObjectDictionary-{6e8b5c8a-9bae-4da0-a83b-3fb4690cbd86}.EasyBpart"));

            FieldType fieldtype = saver.ImportPart<FieldType>(@".\Data\FieldType-ObjectDictionary-{6e8b5c8a-9bae-4da0-a83b-3fb4690cbd86}.EasyBpart");

            Assert.AreEqual(fieldtype.Name, "ObjectDictionary");
            Assert.AreEqual(fieldtype.CheckDigit, CheckDigit.Modulus43);
            Assert.AreEqual(fieldtype.CheckStatus, CheckStatus.Default);
            Assert.AreEqual(fieldtype.EditionLengthMode, EditionLengthMode.AllowShorter);
            Assert.AreEqual(fieldtype.FillMode, FillMode.None);
            Assert.AreEqual(fieldtype.Length, 0);
            Assert.AreEqual(fieldtype.Stereotype, Stereotype.ObjectDictionary);
            Assert.AreEqual(fieldtype.TruncateType, TruncateType.TruncateRight);
            Assert.AreEqual(fieldtype.EntityStereotypeInternal.ToString(), "4740ce9f-bdfe-4ce6-b485-05b93cb9de57");
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
