using Mecalux.ITSW.EasyBCoreServices.Base;
using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public static class CommonEntityExtension
    {

        public static void SetCreateData(this ICommonEntity entity)
        {
            if (entity != null)
            {
                entity.CreateDate = DateTime.UtcNow.ToLocalTime();
                if (Context.CurrentUser != null)
                    entity.CreatedBy = Context.CurrentUser.Name;
            }
        }
    }
}
