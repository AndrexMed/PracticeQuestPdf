using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

QuestPDF.Settings.License = LicenseType.Community;
// code in your main method
Document.Create(document =>
{
    document.Page(page =>
    {
        //page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);
        page.PageColor(Colors.White);
        //page.DefaultTextStyle(x => x.FontSize(20));

        //page.Header()
        //    .Text("Hello PDF!")
        //    .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);
        page.Header().Row(row =>
        {
            row.ConstantItem(140).Height(60).Placeholder(); //Logo

            row.RelativeItem().Column(col =>
            {
                col.Item().AlignCenter().Text("Giovanny Alonso Alzate S.A.S").Bold().FontSize(14);
                col.Item().AlignCenter().Text("Bello Antioquia").FontSize(9);
                col.Item().AlignCenter().Text("321 883 3424").FontSize(9);
                col.Item().AlignCenter().Text("giovanny-0001@hotmail.com").FontSize(9);
                //col.Item().Background(Colors.Orange.Medium).Height(10);
            });

            row.RelativeItem().Border(1).Column(col =>
            {
                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text($"Fecha: {DateTime.Now.ToShortDateString()}").Bold().FontSize(14);
                col.Item().Background("#257272").AlignCenter().Text($"Cotizacion Nº: {Math.Floor(5.0)}").FontSize(9);
                col.Item().AlignCenter().Text("987 987 123/ 02020202").FontSize(9);
                col.Item().AlignCenter().Text("giovanny-0001@hotmail.com").FontSize(9);
            });
        });

        page.Content()
            .PaddingVertical(1, Unit.Centimetre)
            .Column(x =>
            {
                x.Spacing(20);

                x.Item().Text(Placeholders.LoremIpsum());
                x.Item().Image(Placeholders.Image(200, 100));
            });

        page.Footer()
            .AlignCenter()
            .Text(x =>
            {
                x.Span("Page ");
                x.CurrentPageNumber();
            });
    });
})
.ShowInPreviewer();