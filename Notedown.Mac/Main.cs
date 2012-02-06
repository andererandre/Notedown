using System;
using Eto;
using Eto.Forms;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace Notedown
{
    class Startup
    {
        static void Main(string[] args)
        {
            Style.Add<ListBox, NSScrollView>("ListNative", (widget, control) => {
                control.BorderType = NSBorderType.NoBorder;
				var list = control.DocumentView as NSTableView;
                list.SelectionHighlightStyle = NSTableViewSelectionHighlightStyle.SourceList;
            });
			
            Style.Add<TextArea, NSScrollView>("TextConsole", (widget, control) => {
                control.BorderType = NSBorderType.NoBorder;
				var textbox = control.DocumentView as NSTextView;
                textbox.RichText = false;
				textbox.Font = NSFont.FromFontName("Monaco", 12);
            });
			
            Style.Add<ToolBar, NSToolbar>("ToolBar", (widget, control) => {
                control.DisplayMode = NSToolbarDisplayMode.Icon;
            });
			
            Style.Add<Window, NSWindow> ("MainWindow", (widget, control) => {
                control.CollectionBehavior |= NSWindowCollectionBehavior.FullScreenPrimary;
            });
            
            var generator = Generator.GetGenerator("Eto.Platform.Mac.Generator, Eto.Platform.Mac");
            var app = new Program(generator);
            app.Run();
        }
	}
}
