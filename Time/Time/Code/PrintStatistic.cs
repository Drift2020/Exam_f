using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Time.Code
{
   

    public class StoreDataSetPaginator : DocumentPaginator
    {



        private List<StatisticSite> dt; 
        private Typeface typeface;
        private double fontSize;
        private double margin;

        private Size pageSize;
        public override Size PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value;
                PaginateData();
            }
        }

        public StoreDataSetPaginator(List<StatisticSite> statisticSites, Typeface typeface, double fontSize, double margin, Size pageSize)
        {
            this.dt = statisticSites;
            this.typeface = typeface;
            this.fontSize = fontSize;
            this.margin = margin;
            this.pageSize = pageSize;
            PaginateData();
        }

        private int pageCount;
        private int rowsPerPage;
        private void PaginateData()
        {
            // Создать тестовую строку для измерения
            FormattedText text = GetFormattedText("A");

            // Подсчитать строки, которые умещаются на странице
            rowsPerPage = (int)((pageSize.Height - margin * 2) / text.Height);

            // Оставить строку для заголовка 
            rowsPerPage -= 1;

            pageCount = (int)Math.Ceiling((double)dt.Count / rowsPerPage);
        }

        private FormattedText GetFormattedText(string text)
        {
            return GetFormattedText(text, typeface);
        }

        private FormattedText GetFormattedText(string text, Typeface typeface)
        {
            return new FormattedText(
                 text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                      typeface, fontSize, Brushes.Black);
        }

        // Всегда возвращает true, потому что количество страниц обновляется 
        // немедленно и синхронно, когда изменяется размер страницы. 
        // Никогда не находится в неопределенном состоянии
        public override bool IsPageCountValid
        {
            get { return true; }
        }

        public override int PageCount
        {
            get { return pageCount; }
        }

        public override IDocumentPaginatorSource Source
        {
            get { return null; }
        }

        public override DocumentPage GetPage(int pageNumber)
        {
            // Создать тестовую строку для измерения
            FormattedText text = GetFormattedText("A");
            text.MaxTextWidth = 30;
            // Размеры столбцов относительно ширины символа "A"
            double col1_X = margin;
            double col2_X = col1_X + text.Width * 30;

            // Вычислить диапазон строк, которые попадают в эту страницу
            int minRow = pageNumber * rowsPerPage;
            int maxRow = minRow + rowsPerPage;

            // Создать визуальный элемент для страницы
            DrawingVisual visual = new DrawingVisual();

            // Установить позицию в верхний левый угол печатаемой области
            Point point = new Point(margin, margin);

            using (DrawingContext dc = visual.RenderOpen())
            {
             
                // Нарисовать заголовки столбцов
                Typeface columnHeaderTypeface = new Typeface(typeface.FontFamily, FontStyles.Normal, FontWeights.Bold, FontStretches.Normal);
                point.X = col1_X;
                text = GetFormattedText("Name", columnHeaderTypeface);
                dc.DrawText(text, point);
                text = GetFormattedText("Type", columnHeaderTypeface);
                point.X = col2_X;
                dc.DrawText(text, point);

                // Нарисовать линию подчеркивания
                dc.DrawLine(new Pen(Brushes.Black, 2),
                    new Point(margin, margin + text.Height),
                    new Point(pageSize.Width - margin, margin + text.Height));

                point.Y += text.Height;

                // Нарисовать значения столбцов
                for (int i = minRow; i < maxRow; i++)
                {
                    // Проверить конец последней (частично заполненной) страницы
                    if (i > (dt.Count - 1)) break;

                    point.X = col1_X;
                    text = GetFormattedText(dt[i].Name.ToString());
                    dc.DrawText(text, point);

                    // Добавить второй столбец                    
                    text = GetFormattedText(dt[i].Status.ToString());
                    point.X = col2_X;
                    dc.DrawText(text, point);
                    point.Y += text.Height;
                }
            }
            return new DocumentPage(visual, pageSize, new Rect(pageSize), new Rect(pageSize));
        }

        }

    }
