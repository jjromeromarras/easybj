﻿using Mecalux.ITSW.EasyBServices.Base;
using System;

namespace Mecalux.ITSW.EasyBServices.Model
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