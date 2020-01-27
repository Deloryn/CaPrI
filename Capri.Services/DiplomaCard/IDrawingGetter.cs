using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Capri.Services.DiplomaCard
{
    public interface IDrawingGetter
    {
        Drawing getPutLogo(MainDocumentPart mainPart, string imagePath);
    }
}
