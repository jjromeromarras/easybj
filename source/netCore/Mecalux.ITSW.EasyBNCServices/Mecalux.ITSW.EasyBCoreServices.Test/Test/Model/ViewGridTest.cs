using Mecalux.ITSW.EasyB.Model;
using System;
using System.IO;
using Xunit;

namespace Mecalux.ITSW.EasyBCoreServices.Test
{
    public class ViewGridTest
    {
        #region Test Methods
        [Fact]
        public void ViewGrid05SaverJSON()
        {
            ViewGrid obj = CreateEntity();
            SaverJson saver = new SaverJson();
            saver.BuildDefaultJsonSettings();
            saver.SerializeObject(@".\Data\ViewGrid05SaverJSON.EasyBpart", obj);
            Assert.True(File.Exists(@".\Data\ViewGrid05SaverJSON.EasyBpart"));

           // ViewField impobj = saver.ImportPart<ViewField>(@".\Data\ViewField05SaverJSON.EasyBpart");

           

        }
        #endregion

        #region Aux Methods
        private ViewField CreateEntityViewField()
        {
            


            ViewField obj = new ViewField();
           

            obj.AllowEdit = true;
            obj.Name = "ProductCode";
            obj.CheckStatus = CheckStatus.Default;
            obj.ColSpan = 1;
            obj.IsVisible = true;
            obj.Property = "26a00de9-61f9-4c27-b73a-5d0840c7b2dc";
            obj.RowSpan = 1;
            obj.Sequence = 1;
            obj.Title = "55c22cca-2dd9-46a5-9c74-0340df368504";
            obj.ViewFieldType = ViewFieldType.Link;

            obj.CreateDrillDownLink();
            obj.DrillDownLink.TargetViewInternal = "View-ProductsVList-{522967ec-c5bd-440c-a930-17d270eaa721}.EasyBpart";
            obj.DrillDownLink.TargetViewProperty = "ca467839-09dd-4f55-9d51-ed4ddd323db8";
            LinkParameter lp = new LinkParameter();
            lp.Expression = "Prueba";
            lp.ViewParameterInternal = "Codigo";
            obj.DrillDownLink.AddLinkParameter(lp);

            obj.CreateViewFielLov();
            obj.Lov.DisplayProperty = "14017e77 - 39ff - 4141 - bc7e - 41e1198534dc";
            obj.Lov.EntityInternal = "Entity-AccountType-{e27b5580-1c07-4a7a-9fcc-e03e921f0b0d}.EasyBpart";
            obj.Lov.CreateInLineLink();
            obj.Lov.InLineLink.TargetViewInternal = "View-AccountTypeInLineViewEdit-{8602d3d0-75cc-4c75-8868-b3dcaf6ccfba}.EasyBpart";
            obj.Lov.InLineLink.ExpressionCode = "Where a = 1";
            obj.Lov.ShowPropertiesInternal.Add(Guid.Parse("7d4c8f88-ca8e-459e-9e07-503f87c6f3e4"));
            obj.Lov.SqlOrderBy = "Code ASC";
            obj.Lov.SqlWhere = "IsActive";
            obj.Lov.ValueProperty = "7d4c8f88-ca8e-459e-9e07-503f87c6f3e4";



            Lov lv = new Lov();
            lv.DisplayValue = "15b4a1a1-aea3-42ec-ba6f-ca77b47b6a85";
            lv.Value = "Available";

            Lov lv2 = new Lov();
            lv2.DisplayValue = "f71449c4-786b-4f4a-85b4-b19fa24b5e13";
            lv2.Value = "Loaded";

            obj.Lov.AddLov(lv);
            obj.Lov.AddLov(lv2);




            return obj;
        }

        private ViewGrid CreateEntity()
        {
            ViewList viewlist = new ViewList();
            viewlist.VersionId = Guid.Parse("9602d3d0-75cc-4c75-8868-b3dcaf6ccfba");
            ViewGrid viewgrid = viewlist.ViewGrid;
            viewgrid.ColSpan = 1;
            viewgrid.Name = "Tabla";
            viewgrid.RowSpan = 1;
            viewgrid.Sequence = 1;
            viewgrid.AddVF(CreateEntityViewField());
            viewgrid.AddVF(CreateEntityViewField());
            return viewgrid;

        }
        #endregion
    }
}
