using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capri.Services.DiplomaCard
{
    public interface ITablePropertiesGetter
    {
        TableProperties getHorizontalBorderTableProperties();
        TableCellProperties getTableCellPropBorderless(string width);
        TableCellProperties getTableCellPropFilled(string width, string color);
        TableCellProperties getTableCellPropCentered(string width);
    }
}
