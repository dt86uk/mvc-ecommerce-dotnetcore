using System.Linq;
using System.Collections.Generic;
using ECommerceService.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceWebsite.Helpers
{
    public static class SelectListItemHelper
    {
        public static List<SelectListItem> BuildDropDownList<T>(List<T> listEntities) where T : EntityDTO, new()
        {
            var dropdownlist = listEntities
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Value
                }).ToList();

            return dropdownlist;
        }

        public static List<SelectListItem> BuildGendersDropDownList(List<GenderDTO> listGenders)
        {
            var dropdownlist = listGenders
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Value
                }).ToList();

            return dropdownlist;
        }
    }
}
