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
        page.Size(PageSizes.A4);
        page.Margin(1, Unit.Centimetre);
        page.PageColor(Colors.White);
        //page.DefaultTextStyle(x => x.FontSize(20));

        page.Header().ShowOnce().Row(row =>
        {
            row.ConstantItem(140).Height(60).Placeholder(); //Logo

            row.RelativeItem().Column(col =>
            {
                col.Item().AlignCenter().Text("Giovanny Alonso Alzate S.A").Bold().FontSize(14);
                col.Item().AlignCenter().Text("Bello Antioquia").FontSize(11);
                col.Item().AlignCenter().Text("123 456 78 99").FontSize(11);
                col.Item().AlignCenter().Text("giovanny@hotmail.com").FontSize(11);
                //col.Item().Background(Colors.Orange.Medium).Height(10);
            });

            row.RelativeItem().Border(1).Column(col =>
            {
                col.Item().Background("#257272").AlignCenter().Text($"Cotizacion Nº: {Math.Floor(5.0)}").FontSize(14).SemiBold();
                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text($"Fecha: {DateTime.Now.ToShortDateString()}").Bold().FontSize(12);
                col.Item().AlignCenter().Text("Medellin - Antioquia").FontSize(9);
            });
        });

        page.Content().PaddingVertical(10).Column(col1 =>
        {
            col1.Item().Column(col2 =>
            {
                col2.Item().Text("Datos del Cliente").Underline().Bold().FontSize(12);

                col2.Item().Text(text =>
                {
                    text.Span("Nombre/Empresa: ").SemiBold().FontSize(11);
                    text.Span("Capricentro").FontSize(11);
                });

                col2.Item().Text(text =>
                {
                    text.Span("Direccion ").SemiBold().FontSize(11);
                    text.Span("Itagui Antioquia").FontSize(11);
                });

                col2.Item().Text(text =>
                {
                    text.Span("Contacto: ").SemiBold().FontSize(11);
                    text.Span("12334566").FontSize(11);
                });
            });

            col1.Item().PaddingVertical(5).LineHorizontal(0.5f);

            col1.Item().Table(table =>
            {
                table.ColumnsDefinition(cols =>
                {
                    cols.RelativeColumn(3);
                    cols.RelativeColumn();
                    cols.RelativeColumn();
                    cols.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Background("257272").Padding(2).Text("Descripcion").FontColor(Colors.White);
                    header.Cell().Background("257272").Padding(2).Text("Precio Unitario").FontColor(Colors.White);
                    header.Cell().Background("257272").Padding(2).Text("Cantidad").FontColor(Colors.White);
                    header.Cell().Background("257272").Padding(2).Text("Total").FontColor(Colors.White);
                });

                foreach (var item in Enumerable.Range(1, 45))
                {
                    var cantidad = Placeholders.Random.Next(1, 10);
                    var precio = Placeholders.Random.Next(5, 15);
                    var total = cantidad * precio;

                    table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(Placeholders.Label()).FontSize(10);

                    table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text($"{precio.ToString()}").FontSize(10);

                    table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(cantidad.ToString()).FontSize(10);

                    table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(total.ToString()).FontSize(10);
                }

                col1.Item().PaddingRight(1, Unit.Centimetre).PaddingVertical(5).AlignRight().Text("Total: $1500").Bold().FontSize(12);

                col1.Item().Background(Colors.Grey.Lighten3).Padding(10).Column(col =>
                {
                    col.Item().Text("Comentarios").FontSize(14);
                    col.Item().Text(Placeholders.LoremIpsum());
                    col.Spacing(5);
                });

                col1.Spacing(0);
            });

        });

        page.Footer()
            .AlignRight()
            .Text(x =>
            {
                x.Span("Pagina ");
                x.CurrentPageNumber();
                x.Span(" de ");
                x.TotalPages();
            });
    });
})
.ShowInPreviewer();