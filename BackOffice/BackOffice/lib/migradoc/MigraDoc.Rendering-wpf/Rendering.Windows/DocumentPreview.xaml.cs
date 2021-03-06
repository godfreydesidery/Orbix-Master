#region MigraDoc - Creating Documents on the Fly
//
// Authors:
//   Klaus Potzesny
//
// Copyright (c) 2001-2019 empira Software GmbH, Cologne Area (Germany)
//
// http://www.pdfsharp.com
// http://www.migradoc.com
// http://sourceforge.net/projects/pdfsharp
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using PdfSharp.Drawing;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.IO;
using System.Windows.Markup;

namespace MigraDoc.Rendering.Windows
{
  /// <summary>
  /// Interaction logic for DocumentPreview.xaml
  /// </summary>
  public partial class DocumentPreview : UserControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DocumentPreview"/> class.
    /// </summary>
    public DocumentPreview()
    {
      InitializeComponent();
      Width = Double.NaN;
      Height = Double.NaN;
      //this.preview.SetRenderEvent(new PdfSharp.Forms.PagePreview.RenderEvent(RenderPage));
    }

    /// <summary>
    /// Gets or sets a DDL string or file.
    /// </summary>
    public string Ddl
    {
      get { return _ddl; }
      set
      {
        _ddl = value;
        DdlUpdated();
      }
    }
    string _ddl;

    ///////// <summary>
    ///////// Sets a delegate that is invoked when the preview needs to be painted.
    ///////// </summary>
    //////public void SetRenderEvent(RenderEvent renderEvent)
    //////{
    //////  this.renderEvent = renderEvent;
    //////  Invalidate();
    //////}
    //////RenderEvent renderEvent;

    /// <summary>
    /// Gets or sets the current page.
    /// </summary>
    public int Page
    {
      get { return _page; }
      set
      {
        try
        {
          if (viewer != null)
          {
            if (_page != value)
            {
              _page = value;
              //PageInfo pageInfo = this.renderer.formattedDocument.GetPageInfo(this.page);
              //if (pageInfo.Orientation == PdfSharp.PageOrientation.Portrait)
              //  this.viewer.PageSize = new Size((int)pageInfo.Width, (int)pageInfo.Height);
              //else
              //  this.viewer.PageSize = new Size((int)pageInfo.Height, (int)pageInfo.Width);

              //this.viewer.Invalidate();
              //OnPageChanged(new EventArgs());
            }
          }
          else
            _page = -1;
        }
        catch { }
      }
    }
    int _page;

    /// <summary>
    /// Gets the number of pages of the underlying formatted document.
    /// </summary>
    public int PageCount
    {
      get
      {
        if (_renderer != null)
          return _renderer.FormattedDocument.PageCount;
        return 0;
      }
    }

    /// <summary>
    /// Goes to the first page.
    /// </summary>
    public void FirstPage()
    {
      if (_renderer != null)
      {
        Page = 1;
        viewer.GoToPage(1);
      }
    }

    /// <summary>
    /// Goes to the next page.
    /// </summary>
    public void NextPage()
    {
      if (_renderer != null && _page < PageCount)
      {
        Page++;
        //this.preview.Invalidate();
        //OnPageChanged(new EventArgs());
      }
    }

    /// <summary>
    /// Goes to the previous page.
    /// </summary>
    public void PrevPage()
    {
      if (_renderer != null && _page > 1)
      {
        Page--;
      }
    }

    /// <summary>
    /// Goes to the last page.
    /// </summary>
    public void LastPage()
    {
      if (_renderer != null)
      {
        Page = PageCount;
        //this.preview.Invalidate();
        //OnPageChanged(new EventArgs());
      }
    }

    /// <summary>
    /// Called when the Ddl property has changed.
    /// </summary>
    void DdlUpdated()
    {
      if (_ddl != null)
      {
        _document = DdlReader.DocumentFromString(_ddl);
        _renderer = new DocumentRenderer(_document);

        //this.renderer.PrivateFonts = this.privateFonts;
        _renderer.PrepareDocument();

        //IDocumentPaginatorSource source = this.documentViewer.Document;

        //IDocumentPaginatorSource source = this.documentViewer.Document;

        int pageCount = _renderer.FormattedDocument.PageCount;
        if (pageCount == 0)
          return;

        // HACK: hardcoded A4 size
        //double pageWidth = XUnit.FromMillimeter(210).Presentation;
        //double pageHeight = XUnit.FromMillimeter(297).Presentation;
        //Size a4 = new Size(pageWidth, pageHeight);

        XUnit pageWidth, pageHeight;
        Size size96 = GetSizeOfPage(1, out pageWidth, out pageHeight);

        FixedDocument fixedDocument = new FixedDocument();
        fixedDocument.DocumentPaginator.PageSize = size96;

        for (int pageNumber = 1; pageNumber <= pageCount; pageNumber++)
        {
          try
          {
            size96 = GetSizeOfPage(pageNumber, out pageWidth, out pageHeight);

            DrawingVisual dv = new DrawingVisual();
            DrawingContext dc = dv.RenderOpen();
            //XGraphics gfx = XGraphics.FromDrawingContext(dc, new XSize(XUnit.FromMillimeter(210).Point, XUnit.FromMillimeter(297).Point), XGraphicsUnit.Point);
            XGraphics gfx = XGraphics.FromDrawingContext(dc, new XSize(pageWidth.Point, pageHeight.Presentation), XGraphicsUnit.Point);
            _renderer.RenderPage(gfx, pageNumber, PageRenderOptions.All);
            dc.Close();

            // Create page content
            PageContent pageContent = new PageContent();
            pageContent.Width = size96.Width;
            pageContent.Height = size96.Height;
            FixedPage fixedPage = new FixedPage();
            fixedPage.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFE, 0xFE, 0xFE));

            UIElement visual = new DrawingVisualPresenter(dv);
            FixedPage.SetLeft(visual, 0);
            FixedPage.SetTop(visual, 0);

            fixedPage.Width = size96.Width;
            fixedPage.Height =size96.Height;

            fixedPage.Children.Add(visual);

            fixedPage.Measure(size96);
            fixedPage.Arrange(new Rect(new Point(), size96));
            fixedPage.UpdateLayout();

            ((IAddChild)pageContent).AddChild(fixedPage);

            fixedDocument.Pages.Add(pageContent);
          }
          catch (Exception)
          {
            // eat exception
          }
          
          viewer.Document = fixedDocument;
        }
      }
      else
        viewer.Document = null;
    }

    Size GetSizeOfPage(int page, out XUnit width, out XUnit height)
    {
      PageInfo pageInfo = _renderer.FormattedDocument.GetPageInfo(page);
      if (pageInfo.Orientation == PdfSharp.PageOrientation.Portrait)
      {
        width = pageInfo.Width;
        height = pageInfo.Height;
      }
      else
      {
        width = pageInfo.Height;
        height = pageInfo.Width;
      }
      return new Size(width.Presentation, height.Presentation);
    }

    /// <summary>
    /// Gets or sets the MigraDoc document that is previewed in this control.
    /// </summary>
    public Document Document
    {
      get { return _document; }
      set
      {
        if (value != null)
        {
          _document = value;
          _renderer = new DocumentRenderer(value);
          _renderer.PrepareDocument();
          Page = 1;
          //this.preview.Invalidate();
        }
        else
        {
          _document = null;
          _renderer = null;
          //this.preview.Invalidate();
        }
      }
    }
    Document _document;

    /// <summary>
    /// Gets the underlying DocumentRenderer of the document currently in preview, or null, if no rederer exists.
    /// You can use this renderer for printing or creating PDF file. This evades the necessity to format the
    /// document a second time when you want to print it and convert it into PDF.
    /// </summary>
    public DocumentRenderer Renderer
    {
      get { return _renderer; }
    }
    DocumentRenderer _renderer;


    /// <summary>
    /// Helper class to render a single visual.
    /// </summary>
    public class DrawingVisualPresenter : FrameworkElement
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="DrawingVisualPresenter"/> class.
      /// </summary>
      public DrawingVisualPresenter(DrawingVisual visual)
      {
        _visual = visual;
      }

      /// <summary>
      /// Gets the number of visual child elements within this element, which is 1 in this class.
      /// </summary>
      protected override int VisualChildrenCount
      {
        get { return 1; }
      }

      /// <summary>
      /// Overrides <see cref="M:System.Windows.Media.Visual.GetVisualChild(System.Int32)"/>, and returns a child at the specified index from a collection of child elements.
      /// </summary>
      protected override Visual GetVisualChild(int index)
      {
        if (index != 0)
          throw new ArgumentOutOfRangeException("index");
        return _visual;
      }

      readonly DrawingVisual _visual;
    }
  }
}
