using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace Capri.Services.DiplomaCard
{
    public class DrawingGetter: IDrawingGetter
    {
        public Drawing getPutLogo(MainDocumentPart mainPart, string imagePath)
        {
            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Png);
            using (FileStream stream = new FileStream(imagePath, FileMode.Open))
            {
                imagePart.FeedData(stream);
            }

            var image = new Drawing(
                 new DW.Anchor(
                     new DW.SimplePosition() { X = 0L, Y = 0L },
                     new DW.HorizontalPosition(new DW.PositionOffset("18415")) { RelativeFrom = DW.HorizontalRelativePositionValues.Column },
                     new DW.VerticalPosition(new DW.PositionOffset("-635")) { RelativeFrom = DW.VerticalRelativePositionValues.Paragraph },
                     new DW.Extent() { Cx = 880110L, Cy = 880110L },
                     new DW.EffectExtent()
                     {
                         LeftEdge = 19050L,
                         TopEdge = 0L,
                         RightEdge = 0L,
                         BottomEdge = 0L
                     },
                     new DW.WrapSquare() { WrapText = DW.WrapTextValues.BothSides },
                     new DW.DocProperties()
                     {
                         Id = (UInt32Value)1U,
                         Name = "PUT_Logo"
                     },
                     new DW.NonVisualGraphicFrameDrawingProperties(
                         new A.GraphicFrameLocks() { NoChangeAspect = true }),
                     new A.Graphic(
                         new A.GraphicData(
                             new PIC.Picture(
                                 new PIC.NonVisualPictureProperties(
                                     new PIC.NonVisualDrawingProperties()
                                     {
                                         Id = (UInt32Value)0U,
                                         Name = "PUT_Logo.jpg"
                                     },
                                     new PIC.NonVisualPictureDrawingProperties()),
                                 new PIC.BlipFill(
                                     new A.Blip()
                                     {
                                         Embed = mainPart.GetIdOfPart(imagePart),
                                         CompressionState = A.BlipCompressionValues.Print
                                     },
                                     new A.Stretch(new A.FillRectangle())),
                                 new PIC.ShapeProperties(
                                     new A.Transform2D(
                                         new A.Offset() { X = 0L, Y = 0L },
                                         new A.Extents() { Cx = 880110L, Cy = 880110L }),
                                     new A.PresetGeometry(
                                         new A.AdjustValueList()
                                     )
                                     { Preset = A.ShapeTypeValues.Rectangle }))
                         )
                         { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                 )
                 {
                     DistanceFromTop = (UInt32Value)0U,
                     DistanceFromBottom = (UInt32Value)0U,
                     DistanceFromLeft = (UInt32Value)114300U,
                     DistanceFromRight = (UInt32Value)114300U,
                     AllowOverlap = new BooleanValue(true),
                     LayoutInCell = new BooleanValue(true),
                     Locked = new BooleanValue(false),
                     BehindDoc = new BooleanValue(false),
                     RelativeHeight = (UInt32Value)251658240U,
                     SimplePos = new BooleanValue(false)
                 });

            return image;
        }
    }
}
