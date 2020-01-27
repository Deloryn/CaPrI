using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capri.Services.DiplomaCard
{
    public class TablePropertiesGetter: ITablePropertiesGetter
    {
        public TableProperties getHorizontalBorderTableProperties()
        {
            return new TableProperties(
                new TableBorders(
                    new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 },
                    new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 },
                    new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Space = 0, Size = 0 },
                    new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Space = 0, Size = 0 },
                    new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 },
                    new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Space = 0, Size = 0 }
                ),
                new TableCellMarginDefault(
                    new LeftMargin() { Type = TableWidthUnitValues.Dxa, Width = "30" },
                    new RightMargin() { Type = TableWidthUnitValues.Dxa, Width = "30" }),
                new TableLayout() { Type = new EnumValue<TableLayoutValues>(TableLayoutValues.Fixed) }
            );
        }

        public TableCellProperties getTableCellPropBorderless(string width)
        {
            return new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = width },
                new TableCellBorders(
                    new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Nil) },
                    new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Nil) }
            ));
        }

        public TableCellProperties getTableCellPropFilled(string width, string color)
        {
            return new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = width },
                new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center },
                new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = color },
                new TableCellBorders(new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Nil) })
            );
        }

        public TableCellProperties getTableCellPropCentered(string width)
        {
            return new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = width },
                new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center },
                new TableCellBorders(new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Nil) })
            );
        }
    }
}
