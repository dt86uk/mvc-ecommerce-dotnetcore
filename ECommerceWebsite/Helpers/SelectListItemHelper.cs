﻿using ECommerceService.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ECommerceWebsite.Helpers
{
    public static class SelectListItemHelper
    {
        //public static List<SelectListItem> BuildDropDownList(List<EntityDTO> listEntities)
        //{
        //    var listSelectListItem = new List<SelectListItem>();

        //    foreach (var entity in listEntities)
        //    {
        //        listSelectListItem.Add(new SelectListItem()
        //        {
        //            Value = entity.Id.ToString(),
        //            Text = entity.Value
        //        });
        //    }
        //}

        public static List<SelectListItem> BuildDropDownList<T>(List<T> listEntities) where T : EntityDTO, new()
        {
            var listSelectListItem = new List<SelectListItem>();

            foreach (var entity in listEntities)
            {
                listSelectListItem.Add(new SelectListItem()
                {
                    Value = entity.Id.ToString(),
                    Text = entity.Value
                });
            }

            return listSelectListItem;
        }
    }
}
