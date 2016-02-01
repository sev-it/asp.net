using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;
using System.Windows.Controls.Primitives;

namespace SilverlightPanoram
{
    public partial class MainPage : UserControl
    {
        public FloatableWindow floatableWindow = new FloatableWindow();
        System.Windows.Browser.HtmlElement myFrame = System.Windows.Browser.HtmlPage.Document.GetElementById("htmlcontentIFrame");
        public MainPage()
        {
            InitializeComponent();
           
            if (myFrame != null)
            {
                myFrame.SetStyleAttribute("width", "1024");
                myFrame.SetStyleAttribute("height", "768");
                myFrame.SetAttribute("src", "http://google.ru");
                myFrame.SetStyleAttribute("left", "0");
                myFrame.SetStyleAttribute("top", "50");
                myFrame.SetStyleAttribute("visibility", "visible");
            }
            
        }
        private void cmdButton_Click(object sender, RoutedEventArgs e)
        {
            Uri myURI = new Uri("/Panorama/panorama_maps.google.com.html", UriKind.Relative);
       
            floatableWindow.ParentLayoutRoot = this.LayoutRoot;
            floatableWindow.Title = "Панорама";
            floatableWindow.ResizeMode = ResizeMode.CanResize;
            Canvas.SetLeft(floatableWindow, (double)25);
            Canvas.SetTop(floatableWindow, (double)25);
            floatableWindow.Height = 200;
            floatableWindow.Width = 200;
            floatableWindow.VerticalOffset = 200;
            floatableWindow.HorizontalOffset = 100;
            WebBrowser wb = new WebBrowser();
            wb.Source = new Uri("/Panorama/panorama_maps.google.com.html", UriKind.Relative);
            floatableWindow.Name = "floatableWindow";
          //  HtmlPopupWindowOptions options = new HtmlPopupWindowOptions();
          //  options.Resizeable = true;
          //  HtmlWindow hp = HtmlPage.PopupWindow(new Uri("http://google.com"), null, options);
            floatableWindow.Content = wb;
            floatableWindow.Show();                  
        }
    }
}
