using System;
using Eto;
using Eto.Forms;
using MonoMac.AppKit;
using MonoMac.Foundation;
using Eto.Mac;
using Eto.Mac.Forms;
using Eto.Mac.Forms.Controls;
using Eto.Mac.Forms.ToolBar;

namespace Notedown
{
    class Startup
    {
        static void Main(string[] args)
        {
            Style.Add<ListBoxHandler>("ListNative", handler => {
                handler.Scroll.BorderType = NSBorderType.NoBorder;
                handler.Control.SelectionHighlightStyle = NSTableViewSelectionHighlightStyle.SourceList;
            });
            
            Style.Add<TextAreaHandler>("TextConsole", handler => {
                handler.Scroll.BorderType = NSBorderType.NoBorder;
                handler.Control.RichText = false;
                handler.Control.Font = NSFont.FromFontName("Monaco", 12);
            });
            
            Style.Add<ToolBarHandler>("ToolBar", handler => {
                handler.Control.DisplayMode = NSToolbarDisplayMode.Icon;
            });
            
            Style.Add<FormHandler> ("MainWindow", handler => {
                handler.Control.CollectionBehavior |= NSWindowCollectionBehavior.FullScreenPrimary;
            });
            
            var app = new Program(Eto.Platforms.Mac);
            app.Run();
        }
    }
}
