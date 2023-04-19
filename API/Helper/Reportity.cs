using Reportity.Core;
using Reportity.Enums;
using System.Collections.Generic;

using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Xml;
using Reportity.Abstractions;
using Reportity.Exception;
using System.Linq.Expressions;
using System.Linq;
using Reportity.Attributes;
using Reportity.Helper;
using System.Collections;
using Reportity.Utils;
using Reportity.Common;
using System.Text;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Style;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Reportity.Utils.PDF;
using System.Drawing.Imaging;
using Font = iTextSharp.text.Font;

namespace Reportity.Helper
{
    public class PageEventHelper : PdfPageEventHelper
    {
        private PdfContentByte cb;

        private PdfTemplate template;

        private BaseFont baseFont = BaseFont.CreateFont("Helvetica", "CP1254", embedded: false, forceRead: false);

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            cb = writer.DirectContent;
            template = cb.CreateTemplate(50f, 50f);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            string text = "Page " + writer.PageNumber + " of ";
            float widthPoint = baseFont.GetWidthPoint(text, 11f);
            iTextSharp.text.Rectangle pageSize = document.PageSize;
            cb.SetRgbColorFill(100, 100, 100);
            cb.BeginText();
            cb.SetFontAndSize(baseFont, 11f);
            cb.SetTextMatrix(document.LeftMargin, pageSize.GetBottom(document.BottomMargin));
            cb.ShowText(text);
            cb.EndText();
            cb.AddTemplate(template, document.LeftMargin + widthPoint, pageSize.GetBottom(document.BottomMargin));
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            template.BeginText();
            template.SetFontAndSize(baseFont, 11f);
            template.SetTextMatrix(0f, 0f);
            template.ShowText((writer.PageNumber - 1).ToString() ?? "");
            template.EndText();
        }
    }
}
namespace Reportity.Utils.PDF
{
    public class PDFCreator : IDisposable
    {
        private const int Ceiling = 25;

        public PdfPTable? ReportTable { get; set; }

        public int ColumnCount { get; set; }

        public BaseFont ReportBaseFont { get; set; }

        public int[]? ColumnsWidth { get; set; }

        public PdfPCell? ReportCell { get; set; }

        public string? ReportCellText { get; set; }

        public float FontSize { get; set; }

        public bool SwitchColor { get; set; } = false;


        public int HorizontalAlignment { get; set; } = 1;


        public float WidthPercentage { get; set; } = 100f;


        public Document PDFDocument { get; set; } = new Document(PageSize.A4);


        public int ImageDpiSettings { get; set; } = 70;


        public void setColumnSettings(int ColumnSize)
        {
            if (ColumnSize < 1)
            {
                throw new ReportitiyException("No column to be processed, Make sure you add column attribute.");
            }

            ColumnCount = ColumnSize;
            ColumnsWidth = new int[ColumnSize];
        }

        public void setFontSettings()
        {
            ReportBaseFont = BaseFont.CreateFont("Helvetica", "CP1254", embedded: false, forceRead: false);
            FontSize = (25 - ColumnCount) / 2;
            if (FontSize < 6f)
            {
                FontSize = 6f;
            }
            else if (FontSize > 15f)
            {
                FontSize = 15f;
            }
        }

        public void setTableSettings()
        {
            ReportTable = new PdfPTable(ColumnCount);
            ReportTable!.HorizontalAlignment = HorizontalAlignment;
            ReportTable!.WidthPercentage = WidthPercentage;
        }

        public void setHeaderValues(ArrayList Cells)
        {
            foreach (object Cell in Cells)
            {
                iTextSharp.text.Font font = new iTextSharp.text.Font(ReportBaseFont, FontSize, 0, BaseColor.White);
                ReportCell = new PdfPCell(new Phrase(Cell.ToString()?.Replace("<br />", Environment.NewLine), font));
                ReportCell!.HorizontalAlignment = 1;
                ReportCell!.VerticalAlignment = 5;
                ReportCell!.FixedHeight = 55f;
                ReportCell!.BackgroundColor = new BaseColor(ColorTranslator.FromHtml("#a52a2a"));
                ReportTable!.AddCell(ReportCell);
            }
        }

        public void setReportValues<T>(IEnumerable<T> List, ReportityReportObject ReportObject)
        {
            foreach (T item in List)
            {
                PropertyInfo[] properties = item.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in properties)
                {
                    if (TypeChecker.CheckType(propertyInfo.PropertyType))
                    {
                        ReportObject.takeSummaryObjects(propertyInfo, item);
                        ReportCellText = propertyInfo.GetValue(item)?.ToString();
                        iTextSharp.text.Font font = new iTextSharp.text.Font(ReportBaseFont, FontSize, 0, BaseColor.Black);
                        ReportCell = new PdfPCell(new Phrase(ReportCellText?.Replace("<br />", Environment.NewLine), font));
                        ReportCell!.HorizontalAlignment = 1;
                        ReportCell!.VerticalAlignment = 5;
                        ReportCell!.MinimumHeight = 35f;
                        ReportCell!.BackgroundColor = new BaseColor(SwitchColor ? Color.LightGray : Color.AliceBlue);
                        ReportTable!.AddCell(ReportCell);
                    }
                }

                SwitchColor = !SwitchColor;
            }
        }

        public void setReportSummaryItem(decimal? SummaryTotal, string SummaryName)
        {
            iTextSharp.text.Font font = new iTextSharp.text.Font(ReportBaseFont, FontSize, 3, BaseColor.Black);
            for (int i = 0; i < ColumnCount - 2; i++)
            {
                ReportCell = new PdfPCell(new Phrase(""));
                ReportCell!.BackgroundColor = new BaseColor(Color.Gray);
                ReportTable!.AddCell(ReportCell);
            }

            ReportCell = new PdfPCell(new Phrase(("Toplam " + SummaryName).Replace("<br />", Environment.NewLine), font));
            ReportCell!.HorizontalAlignment = 1;
            ReportCell!.VerticalAlignment = 5;
            ReportCell!.MinimumHeight = 35f;
            ReportCell!.BackgroundColor = new BaseColor(Color.Gray);
            ReportTable!.AddCell(ReportCell);
            ReportCell = new PdfPCell(new Phrase(SummaryTotal.ToString()?.Replace("<br />", Environment.NewLine), font));
            ReportCell!.HorizontalAlignment = 1;
            ReportCell!.VerticalAlignment = 5;
            ReportCell!.MinimumHeight = 35f;
            ReportCell!.BackgroundColor = new BaseColor(Color.Gray);
            ReportTable!.AddCell(ReportCell);
        }

        public void setPDFDocument(int ColumnSize)
        {
            if (ColumnSize > 7)
            {
                PDFDocument = new Document(PageSize.A4.Rotate());
            }
        }

        public void setReportImage(string LogoPath)
        {
            if (!(LogoPath != ""))
            {
                return;
            }

            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(LogoPath);
                string[] source = LogoPath.Split(".");
                string text = source.Last().ToUpper();
                iTextSharp.text.Image ımage = null;
                string text2 = text;
                string text3 = text2;
                if (!(text3 == "PNG"))
                {
                    if (text3 == "JPG")
                    {
                        ımage = iTextSharp.text.Image.GetInstance(image, ImageFormat.Jpeg);
                    }
                }
                else
                {
                    ımage = iTextSharp.text.Image.GetInstance(image, ImageFormat.Png);
                }

                ımage?.SetDpi(ImageDpiSettings, ImageDpiSettings);
                ımage?.SetAbsolutePosition(PDFDocument.LeftMargin, PDFDocument.Top - PDFDocument.TopMargin);
                ımage?.ScaleToFit(ImageDpiSettings, ImageDpiSettings);
                PDFDocument.Add(ımage);
            }
            catch (System.Exception ex)
            {
                throw new ReportitiyException(ex.Message);
            }
        }

        public void Dispose()
        {
            ReportTable = null;
            ColumnCount = 0;
            ReportBaseFont = null;
            ColumnsWidth = null;
            ReportCell = null;
            ReportCellText = null;
            FontSize = 0f;
            HorizontalAlignment = 0;
            WidthPercentage = 0f;
            PDFDocument = null;
        }
    }
}
namespace Reportity.Common
{
    public class PDFRenderer<T> : Renderer<T>, IStringExporter<T>, IByteExporter<T>
    {
        public byte[] ExportToStream(IEnumerable<T> list)
        {
            return RenderData(list);
        }

        public string ExportToString(IEnumerable<T> list)
        {
            return Convert.ToBase64String(RenderData(list));
        }

        public override byte[] RenderData(IEnumerable<T> list)
        {
            using MemoryStream memoryStream = new MemoryStream();
            try
            {
                using ReportityReportObject reportityReportObject = new ReportityReportObject(typeof(T));
                reportityReportObject.setHeaders();
                reportityReportObject.setAttributes();
                using PDFCreator pDFCreator = new PDFCreator();
                pDFCreator.setColumnSettings(reportityReportObject.Cells.Count);
                pDFCreator.setTableSettings();
                pDFCreator.setFontSettings();
                pDFCreator.setHeaderValues(reportityReportObject.Cells);
                pDFCreator.setReportValues(list, reportityReportObject);
                if (reportityReportObject.SummaryType != null)
                {
                    pDFCreator.setReportSummaryItem(reportityReportObject.SummaryValues.Sum(), reportityReportObject.SummaryName);
                }

                pDFCreator.setPDFDocument(reportityReportObject.Cells.Count);
                PdfWriter ınstance = PdfWriter.GetInstance(pDFCreator.PDFDocument, memoryStream);
                PageEventHelper pageEventHelper = (PageEventHelper)(ınstance.PageEvent = new PageEventHelper());
                pDFCreator.PDFDocument.Open();
                pDFCreator.ReportTable!.HeaderRows = 1;
                iTextSharp.text.Font font = new Font(pDFCreator.ReportBaseFont, 15f, 1, BaseColor.Black);
                Font font2 = new Font(pDFCreator.ReportBaseFont, 11f, 2, BaseColor.Black);
                pDFCreator.PDFDocument.Add(new Paragraph(DateTime.Now.ToString(), font2)
                {
                    Alignment = 2
                });
                pDFCreator.PDFDocument.Add(new Paragraph(reportityReportObject.ReportHeader, font)
                {
                    Alignment = 1
                });
                pDFCreator.setReportImage(reportityReportObject.LogoPath);
                pDFCreator.PDFDocument.Add(new Paragraph(" "));
                pDFCreator.PDFDocument.Add(pDFCreator.ReportTable);
                pDFCreator.PDFDocument.Close();
            }
            catch (System.Exception ex)
            {
                throw new ReportitiyException(ex.Message);
            }

            return memoryStream.ToArray();
        }
    }
}
namespace Reportity.Enums
{
    public enum ReportTypes
    {
        XmlReport,
        CsvReport,
        ExcelReport,
        PdfReport
    }
}

namespace Reportity.Core
{
    public interface IStringExporter<T>
    {
        string ExportToString(IEnumerable<T> list);
    }
}
namespace Reportity.Utils
{
    public partial class ReportityReportObject : IDisposable
    {
        public string? ReportHeader { get; set; }
        public string? LogoPath { get; set; }
        public string? SummaryField { get; set; }
        public string? SummaryName { get; set; }
        public ArrayList Cells { get; set; } = new ArrayList();
        public Type? EntityType { get; set; }
        public Type? SummaryType { get; set; }
        public List<decimal?> SummaryValues { get; set; } = new List<decimal?>();
        public Dictionary<string, string> ColumnNameMap { get; set; } = new Dictionary<string, string>();

        public ReportityReportObject(Type _entityType)
        {
            EntityType = _entityType;
        }

        public void Dispose()
        {
            ReportHeader = null;
            LogoPath = null;
            SummaryField = null;
            SummaryName = null;
            Cells.Clear();
            EntityType = null;
            SummaryType = null;
            SummaryValues.Clear();
        }
    }
}

namespace Reportity.Utils
{
    public partial class ReportityReportObject
    {
        public void setHeaders()
        {
            object[] attrs = EntityType.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                ReportityHeaderAttribute? ReportityAttr = attr as ReportityHeaderAttribute;
                if (ReportityAttr != null)
                {
                    ReportHeader = ReportityAttr.ReportHeader;
                    LogoPath = ReportityAttr.LogoPath;
                    SummaryField = ReportityAttr.SummaryField;
                }
            }
        }

        public void setAttributes()
        {
            foreach (PropertyInfo PropertyInfo in EntityType.GetProperties())
            {
                object[] colattrs = PropertyInfo.GetCustomAttributes(true);
                foreach (object colattr in colattrs)
                {
                    Cells.Add(PropertyInfo.Name);
                    ReportityColumnName? columnNameAttr = colattr as ReportityColumnName;
                    if (columnNameAttr != null)
                    {
                        if (TypeChecker.CheckType(PropertyInfo.PropertyType))
                        {
                            string Name = columnNameAttr.ColumnName == "" ? PropertyInfo.Name : columnNameAttr.ColumnName;

                            ColumnNameMap.Add(PropertyInfo.Name, columnNameAttr.ColumnName);

                            if (SummaryField == PropertyInfo.Name)
                            {
                                if (TypeChecker.isNumeric(PropertyInfo.PropertyType))
                                {
                                    SummaryType = PropertyInfo.GetType();
                                    SummaryName = Name;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void takeSummaryObjects<T>(PropertyInfo propertyInfo, T data)
        {
            if (propertyInfo.Name == SummaryField)
            {
                if (TypeChecker.isNumeric(propertyInfo.PropertyType))
                    SummaryValues.Add(decimal.Parse(propertyInfo.GetValue(data) == null ? "0" : propertyInfo.GetValue(data).ToString()));
            }
        }
    }
}

namespace Reportity.Helper
{
    public static class ColumnHelper
    {
        public static string ColumnIndexToColumnLetter(
            int colIndex)
        {
            var div = colIndex;
            var colLetter = string.Empty;
            var mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (div - mod) / 26;
            }

            return colLetter;
        }
    }

    public static class ReflectionHelper
    {
        /// <summary>
        /// Creates an instance of type T.
        /// </summary>
        /// <typeparam name="T">The type of instance to create.</typeparam>
        /// <returns>A new instance of type T.</returns>
        public static T CreateInstance<T>()
        {
            var constructor = Expression.New(typeof(T));
            var compiled = (Func<T>)Expression.Lambda(constructor).Compile();
            return compiled();
        }

        /// <summary>
        /// Creates an instance of the specified type.
        /// </summary>
        /// <param name="type">The type of instance to create.</param>
        /// <param name="args">The constructor arguments.</param>
        /// <returns>A new instance of the specified type.</returns>
        public static object CreateInstance(
            Type type,
            params object[] args)
        {
            var argumentTypes = args.Select(a => a.GetType()).ToArray();
            var argumentExpressions = argumentTypes.Select((t, i) => Expression.Parameter(t, "var" + i)).ToArray();
            var constructorInfo = type.GetConstructor(argumentTypes);
            var constructor = Expression.New(constructorInfo, argumentExpressions);
            var compiled = Expression.Lambda(constructor, argumentExpressions).Compile();
            return compiled.DynamicInvoke(args);
        }

        /// <summary>
        /// Gets the constructor <see cref="NewExpression"/> from the give <see cref="Expression"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the object that will be constructed.</typeparam>
        /// <param name="expression">The constructor <see cref="Expression"/>.</param>
        /// <returns>A constructor <see cref="NewExpression"/>.</returns>
        /// <exception cref="System.ArgumentException">Not a constructor expression.;expression</exception>
        public static NewExpression GetConstructor<T>(
            Expression<Func<T>> expression)
        {
            if (!(expression.Body is NewExpression newExpression))
            {
                throw new ArgumentException("Not a constructor expression.", nameof(expression));
            }

            return newExpression;
        }

        /// <summary>
        /// Gets the property from the expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The <see cref="PropertyInfo"/> for the expression.</returns>
        public static PropertyInfo GetProperty<TModel>(
            Expression<Func<TModel, object>> expression)
        {
            var member = GetMemberExpression(expression).Member;
            var property = member as PropertyInfo;
            if (property == null)
            {
                throw new System.Exception($"'{member.Name}' is not a property. Did you try to map a field by accident?");
            }

            return property;
        }

        /// <summary>
        /// Gets the member expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        private static MemberExpression GetMemberExpression<TModel, T>(
            Expression<Func<TModel, T>> expression)
        {
            // This method was taken from FluentNHibernate.Utils.ReflectionHelper.cs and modified.
            // http://fluentnhibernate.org/
            MemberExpression memberExpression = null;
            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                var body = (UnaryExpression)expression.Body;
                memberExpression = body.Operand as MemberExpression;
            }
            else if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = expression.Body as MemberExpression;
            }

            if (memberExpression == null)
            {
                throw new ArgumentException("Not a member access", nameof(expression));
            }

            return memberExpression;
        }
    }

    /// <summary>
    /// Common reflection tasks.
    /// </summary>

    public class TypeChecker
    {
        private static readonly HashSet<Type> NumericTypes = new HashSet<Type>
    {
        typeof(int),  typeof(double),  typeof(decimal),
        typeof(long), typeof(short),
        typeof(ulong),   typeof(ushort),
        typeof(uint), typeof(float)
    };
        private static readonly HashSet<Type> AvailableType = new HashSet<Type>
    {
        typeof(int),  typeof(double),  typeof(decimal), typeof(string),
        typeof(long), typeof(short), typeof(bool),
        typeof(ulong),   typeof(ushort),typeof(char),
        typeof(uint), typeof(float), typeof(DateTime)
    };
        public static bool CheckType(Type source)
        {
            return AvailableType.Contains(Nullable.GetUnderlyingType(source) ?? source);
        }

        public static bool isNumeric(Type source)
        {
            return NumericTypes.Contains(Nullable.GetUnderlyingType(source) ?? source);
        }
    }

    public class ExcelHelperException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelHelperException"/> class.
        /// </summary>
        public ExcelHelperException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelHelperException"/> class
        /// with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ExcelHelperException(
            string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelHelperException"/> class
        /// with a specified error message and a reference to the inner exception that 
        /// is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ExcelHelperException(
            string message,
            System.Exception innerException)
            : base(message, innerException)
        {
        }
    }

    //public static void JsonToExcel(List<Entity> vocabs, string filename)
    //{
    //    try
    //    {
    //        string sheetName = "Sheet";
    //        XLWorkbook wb = new XLWorkbook();

    //        wb.Worksheets.Add(sheetName);

    //        if (filename.Contains("."))
    //        {
    //            int IndexOfLastFullStop = filename.LastIndexOf('.');

    //            filename = filename.Substring(0, IndexOfLastFullStop) + ".xlsx";

    //        }
    //        int row = 1;
    //        foreach (Vocab vocab in vocabs)
    //        {
    //            var ws = wb.Worksheet(sheetName);

    //            ws.Cell("A" + row.ToString()).Value = vocab.English.ToString();
    //            ws.Cell("B" + row.ToString()).Value = vocab.Persian.ToString();
    //            row++;
    //        }
    //        filename = filename + ".xlsx";

    //        wb.SaveAs(filename);
    //        Console.WriteLine("Excel file saved SuccessFully In Path: {0}", filename);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
    //        + ex.Message);
    //    }

    //}

}

namespace Reportity.Exception
{
    public class ReportitiyException : System.Exception
    {
        public ReportitiyException(string ex) : base(ex)
        {

        }
    }
}

namespace Reportity.Abstractions
{
    public abstract class Renderer<T>
    {
        public abstract byte[] RenderData(IEnumerable<T> list);
    }
}
namespace Reportity.Common
{
    public class XmlRenderer<T> : Renderer<T>, IStringExporter<T>, IByteExporter<T>
    {
        public byte[] ExportToStream(IEnumerable<T> list)
        {
            return RenderData(list);
        }

        public string ExportToString(IEnumerable<T> list)
        {
            return Convert.ToBase64String(RenderData(list));
        }

        public override byte[] RenderData(IEnumerable<T> list)
        {
            using (MemoryStream ReportData = new MemoryStream())
            {
                try
                {
                    using (ReportityReportObject ReportObject = new ReportityReportObject(typeof(T)))
                    {
                        ReportObject.setHeaders();
                        ReportObject.setAttributes();

                        if (ReportObject.Cells.Count < 1)
                            throw new ReportitiyException("No column to be processed, Make sure you add column attribute.");
                        List<Dictionary<string, object>> NewValues = new List<Dictionary<string, object>>();
                        foreach (var data in list)
                        {
                            Dictionary<string, object> Values = new Dictionary<string, object>();
                            foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
                            {
                                if (TypeChecker.CheckType(propertyInfo.PropertyType))
                                {
                                    Values.Add((ReportObject.ColumnNameMap[propertyInfo.Name] == "" ? propertyInfo.Name : ReportObject.ColumnNameMap[propertyInfo.Name]).Replace(" ", ""), propertyInfo.GetValue(data)?.ToString());
                                }
                            }
                            NewValues.Add(Values);
                        }

                        string JsonValue = JsonConvert.SerializeObject(NewValues);
                        XmlDocument? doc = JsonConvert.DeserializeXmlNode("{\"Row\":" + JsonValue + "}", ReportObject.ReportHeader?.Replace(" ", ""));
                        if (doc != null)
                        {
                            doc.Save(ReportData);
                            ReportData.Flush();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw new ReportitiyException(ex.Message);
                }
                return ReportData.ToArray();
            }

        }
    }
}
namespace Reportity.Core
{
    public interface IByteExporter<T>
    {
        byte[] ExportToStream(IEnumerable<T> list);
    }
}
namespace Reportity.Common
{
    public class CSVRenderer<T> : Renderer<T>, IStringExporter<T>, IByteExporter<T>
    {
        public string ExportToString(IEnumerable<T> list)
        {
            return Convert.ToBase64String(RenderData(list));
        }

        public byte[] ExportToStream(IEnumerable<T> list)
        {
            return RenderData(list);
        }

        public override byte[] RenderData(IEnumerable<T> list)
        {
            using MemoryStream memoryStream = new MemoryStream();
            try
            {
                using ReportityReportObject reportityReportObject = new ReportityReportObject(typeof(T));
                reportityReportObject.setHeaders();
                reportityReportObject.setAttributes();
                if (reportityReportObject.Cells.Count < 1)
                {
                    throw new ReportitiyException("No column to be processed, Make sure you add column attribute.");
                }

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(string.Join(",", reportityReportObject.Cells.Cast<string>().ToList()) + Environment.NewLine);
                foreach (T item in list)
                {
                    List<string> list2 = new List<string>();
                    PropertyInfo[] properties = item.GetType().GetProperties();
                    foreach (PropertyInfo propertyInfo in properties)
                    {
                        if (TypeChecker.CheckType(propertyInfo.PropertyType))
                        {
                            list2.Add(propertyInfo.GetValue(item)?.ToString());
                        }
                    }

                    stringBuilder.Append(string.Join(",", list2) + Environment.NewLine);
                }

                TextWriter textWriter = new StreamWriter(memoryStream);
                textWriter.Write(stringBuilder.ToString());
                textWriter.Flush();
            }
            catch (System.Exception ex)
            {
                throw new ReportitiyException(ex.Message);
            }

            return memoryStream.ToArray();
        }
    }
}
namespace Reportity.Common
{
    public class ExcelRenderer<T> : Renderer<T>, IStringExporter<T>, IByteExporter<T>
    {
        public byte[] ExportToStream(IEnumerable<T> list)
        {
            return RenderData(list);
        }

        public string ExportToString(IEnumerable<T> list)
        {
            return Convert.ToBase64String(RenderData(list));
        }
        //
        // Summary:
        //     Represents an Excel 2007/2010 XLSX file package. This is the top-level object
        //     to access all parts of the document.
        //         FileInfo newFile = new FileInfo(outputDir.FullName + @"\sample1.xlsx");
        //      if (newFile.Exists)
        //      {
        //          newFile.Delete();  // ensures we create a new workbook
        //          newFile = new FileInfo(outputDir.FullName + @"\sample1.xlsx");
        //      }
        //      using (ExcelPackage package = new ExcelPackage(newFile))
        //         {
        //             // add a new worksheet to the empty workbook
        //             ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Inventory");
        //             //Add the headers
        //             worksheet.Cells[1, 1].Value = "ID";
        //             worksheet.Cells[1, 2].Value = "Product";
        //             worksheet.Cells[1, 3].Value = "Quantity";
        //             worksheet.Cells[1, 4].Value = "Price";
        //             worksheet.Cells[1, 5].Value = "Value";
        //             //Add some items...
        //             worksheet.Cells["A2"].Value = "12001";
        //             worksheet.Cells["B2"].Value = "Nails";
        //             worksheet.Cells["C2"].Value = 37;
        //             worksheet.Cells["D2"].Value = 3.99;
        //             worksheet.Cells["A3"].Value = "12002";
        //             worksheet.Cells["B3"].Value = "Hammer";
        //             worksheet.Cells["C3"].Value = 5;
        //             worksheet.Cells["D3"].Value = 12.10;
        //             worksheet.Cells["A4"].Value = "12003";
        //             worksheet.Cells["B4"].Value = "Saw";
        //             worksheet.Cells["C4"].Value = 12;
        //             worksheet.Cells["D4"].Value = 15.37;
        //             //Add a formula for the value-column
        //             worksheet.Cells["E2:E4"].Formula = "C2*D2";
        //                //Ok now format the values;
        //             using (var range = worksheet.Cells[1, 1, 1, 5])
        //              {
        //                 range.Style.Font.Bold = true;
        //                 range.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                 range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
        //                 range.Style.Font.Color.SetColor(Color.White);
        //             }
        //             worksheet.Cells["A5:E5"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //             worksheet.Cells["A5:E5"].Style.Font.Bold = true;
        //             worksheet.Cells[5, 3, 5, 5].Formula = string.Format("SUBTOTAL(9,{0})",
        //     new ExcelAddress(2,3,4,3).Address);
        //             worksheet.Cells["C2:C5"].Style.Numberformat.Format = "#,##0";
        //             worksheet.Cells["D2:E5"].Style.Numberformat.Format = "#,##0.00";
        //             //Create an autofilter for the range
        //             worksheet.Cells["A1:E4"].AutoFilter = true;
        //             worksheet.Cells["A1:E5"].AutoFitColumns(0);
        //             // lets set the header text
        //             worksheet.HeaderFooter.oddHeader.CenteredText = "&24&U&\"Arial,Regular
        //     Bold\" Inventory";
        //             // add the page number to the footer plus the total number of pages
        //             worksheet.HeaderFooter.oddFooter.RightAlignedText =
        //             string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
        //             // add the sheet name to the footer
        //             worksheet.HeaderFooter.oddFooter.CenteredText = ExcelHeaderFooter.SheetName;
        //             // add the file path to the footer
        //             worksheet.HeaderFooter.oddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath
        //     + ExcelHeaderFooter.FileName;
        //             worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:2"];
        //             worksheet.PrinterSettings.RepeatColumns = worksheet.Cells["A:G"];
        //              // Change the sheet view to show it in page layout mode
        //               worksheet.View.PageLayoutView = true;
        //             // set some document properties
        //             package.Workbook.Properties.Title = "Invertory";
        //             package.Workbook.Properties.Author = "Jan Källman";
        //             package.Workbook.Properties.Comments = "This sample demonstrates how
        //     to create an Excel 2007 workbook using EPPlus";
        //             // set some extended property values
        //             package.Workbook.Properties.Company = "AdventureWorks Inc.";
        //             // set some custom property values
        //             package.Workbook.Properties.SetCustomPropertyValue("Checked by", "Jan
        //     Källman");
        //             package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "EPPlus");
        //             // save our new workbook and we are done!
        //             package.Save();
        //           }
        //           return newFile.FullName;
        //     More samples can be found at http://epplus.codeplex.com/
        public override byte[] RenderData(IEnumerable<T> list)
        {
            MemoryStream memoryStream = null;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                try
                {
                    using ReportityReportObject reportityReportObject = new ReportityReportObject(typeof(T));
                    reportityReportObject.setHeaders();
                    reportityReportObject.setAttributes();
                    if (reportityReportObject.Cells.Count < 1)
                    {
                        throw new ReportitiyException("No column to be processed, Make sure you add column attribute.");
                    }

                    int num = 1;
                    ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(reportityReportObject.ReportHeader);
                    excelWorksheet.Row(1).Height = 20.0;
                    excelWorksheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    excelWorksheet.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    excelWorksheet.Row(1).Style.Font.Bold = true;
                    for (int i = 0; i < reportityReportObject.Cells.Count; i++)
                    {
                        excelWorksheet.Cells[1, i + 1].Value = reportityReportObject.Cells[i]!.ToString();
                        excelWorksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        excelWorksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.Wheat);
                        excelWorksheet.Cells[1, i + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        excelWorksheet.Cells[1, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        excelWorksheet.Cells[1, i + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        excelWorksheet.Cells[1, i + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    }

                    int num2 = 2;
                    bool flag = false;
                    foreach (T item in list)
                    {
                        List<string> list2 = new List<string>();
                        PropertyInfo[] properties = item.GetType().GetProperties();
                        foreach (PropertyInfo propertyInfo in properties)
                        {
                            if (TypeChecker.CheckType(propertyInfo.PropertyType))
                            {
                                excelWorksheet.Cells[num2, num].Value = propertyInfo.GetValue(item)?.ToString();
                                excelWorksheet.Cells[num2, num].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                excelWorksheet.Cells[num2, num].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                excelWorksheet.Cells[num2, num].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                excelWorksheet.Cells[num2, num].Style.Fill.BackgroundColor.SetColor(flag ? Color.LightGray : Color.AliceBlue);
                                excelWorksheet.Cells[num2, num].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                excelWorksheet.Cells[num2, num].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                excelWorksheet.Cells[num2, num].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                excelWorksheet.Cells[num2, num].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                num++;
                            }
                        }

                        num2++;
                        num = 1;
                        flag = !flag;
                    }

                    for (int k = 0; k < reportityReportObject.Cells.Count; k++)
                    {
                        excelWorksheet.Column(k + 1).AutoFit();
                    }

                    memoryStream = new MemoryStream(excelPackage.GetAsByteArray());
                }
                catch (System.Exception ex)
                {
                    throw new ReportitiyException(ex.Message);
                }
            }

            return memoryStream.ToArray();
        }
    }
}
namespace Reportity
{
    public static class Reportity
    {
        public static byte[] ToStreamReport<T>(this IEnumerable<T> list, ReportTypes type)
        {
            IByteExporter<T>? Renderer = null;
            switch (type)
            {
                case ReportTypes.XmlReport:
                    Renderer = new XmlRenderer<T>();
                    break;
                case ReportTypes.CsvReport:
                    Renderer = new CSVRenderer<T>();
                    break;
                case ReportTypes.ExcelReport:
                    Renderer = new ExcelRenderer<T>();
                    break;
                case ReportTypes.PdfReport:
                    Renderer = new PDFRenderer<T>();
                    break;
                default:
                    break;
            }
            if (Renderer != null)
                return Renderer.ExportToStream(list);
            else
                throw new ReportitiyException("Not implemented report type.");
        }

        public static string ToStringReport<T>(this IEnumerable<T> list, ReportTypes type)
        {
            IStringExporter<T>? Renderer = null;
            switch (type)
            {
                case ReportTypes.XmlReport:
                    Renderer = new XmlRenderer<T>();
                    break;
                case ReportTypes.CsvReport:
                    Renderer = new CSVRenderer<T>();
                    break;
                case ReportTypes.ExcelReport:
                    Renderer = new ExcelRenderer<T>();
                    break;
                case ReportTypes.PdfReport:
                    Renderer = new PDFRenderer<T>();
                    break;
                default:
                    break;
            }
            if (Renderer != null)
                return Renderer.ExportToString(list);
            else
                throw new ReportitiyException("Not implemented report type.");
        }
    }
}
