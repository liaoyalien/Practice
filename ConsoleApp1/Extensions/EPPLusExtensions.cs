﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ERPWebSite.Common.Enums.Attributes;
using OfficeOpenXml;

namespace ERPWebSite.Common.Extensions
{
    public static class EPPLusExtension
    {
        public static IEnumerable<T> ConvertSheetToObjects<T>(this ExcelWorksheet worksheet, int startFromRow)
            where T : new()
        {
            Func<CustomAttributeData, bool> columnOnly = y => y.AttributeType == typeof(ColumnAttr);

            var columns = typeof(T).GetProperties().Where(x => x.CustomAttributes.Any(columnOnly)).Select(
                p => new
                {
                    Property = p,
                    Column = p.GetCustomAttributes<ColumnAttr>().First().ColumnIndex // safe because if where above
                }).ToList();

            var rows = worksheet.Cells.Select(cell => cell.Start.Row).Distinct().OrderBy(x => x);

            // Create the collection container
            var collection = rows.Skip(startFromRow).Select(
                row =>
                {
                    var tnew = new T();

                    columns.ForEach(
                        col =>
                        {
                            // This is the real wrinkle to using reflection - Excel stores all numbers as double including int
                            var val = worksheet.Cells[row, col.Column];

                            // If it is numeric it is a double since that is how excel stores all numbers
                            if (val.Value == null)
                            {
                                col.Property.SetValue(tnew, null);

                                return;
                            }

                            if (col.Property.PropertyType == typeof(Int32))
                            {
                                col.Property.SetValue(tnew, val.GetValue<int>());

                                return;
                            }

                            if (col.Property.PropertyType == typeof(double))
                            {
                                col.Property.SetValue(tnew, val.GetValue<double>());

                                return;
                            }

                            if (col.Property.PropertyType == typeof(DateTime))
                            {
                                col.Property.SetValue(tnew, val.GetValue<DateTime>());

                                return;
                            }

                            // Its a string
                            col.Property.SetValue(tnew, val.GetValue<string>());
                        });

                    return tnew;
                });

            // Send it back
            return collection;
        }
    }
}