//  
//  MainWindow.cs
//  
//  Author:
//       Peter Stuifzand  <peter@stuifzand.eu>
// 
//  Copyright (c) 2011 Peter Stuifzand
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using Gtk;
using System.Text.RegularExpressions;

public partial class MainWindow : Gtk.Window
{
	public WindowPipe.ScriptRunner Runner {
		get; set;
	}
	
	private static Gtk.TargetEntry[] target_table = new TargetEntry[] {
		new TargetEntry("text/uri-list", 0, 0),
	};
	
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		Gtk.Drag.DestSet(lblDrop, DestDefaults.All, target_table, Gdk.DragAction.Copy);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected virtual void lbl_drop_drag_data_received (object o, Gtk.DragDataReceivedArgs args)
	{
		bool success = false;
		string data = System.Text.Encoding.UTF8.GetString(args.SelectionData.Data);
		switch (args.Info) {
		case 0: //uri-list
			string[] uri_list = Regex.Split(data, "\r\n");
			foreach (string u in uri_list) {
				if (u.Length > 0) {
					Runner.Run(u);
				}
			}
			success = true;
			break;
		}
		Gtk.Drag.Finish(args.Context, success,false,args.Time);
	}
	
	
}

