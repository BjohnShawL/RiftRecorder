using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace R_R.Common.Extensions
{
    public static class ListExtensions
    {
        public static SelectList ToSelectList<TEntity>(this List<TEntity> items, string valueField, string textField) where TEntity:class
        {
            return new SelectList(items,valueField,textField);
        }
    }
}
