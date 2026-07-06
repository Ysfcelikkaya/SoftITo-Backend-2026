using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EmlakProjectORM.Models.ViewModels
{
    public class PropertyVM
    {
        public Property Property { get; set; }

        // Combobox için kullanılacak liste
        public IEnumerable<SelectListItem> PropertyTypeList { get; set; }
    }
}