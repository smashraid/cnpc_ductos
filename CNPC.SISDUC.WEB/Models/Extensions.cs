﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CNPC.SISDUC.WEB.Models
{
    public static class EnumerableExt
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
        {

            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            var result = from TEnum e in values
                         select new { ID = (int)Enum.Parse(typeof(TEnum), e.ToString()), Name = e.ToString() };

            var tempValue = new { ID = 0, Name = "-- Select --" };

            var list = result.ToList(); // Create mutable list

            list.Insert(0, tempValue); // Add at beginning of list

            return new SelectList(list, "Id", "Name", enumObj);
        }
    }
}