//  
//  Main.cs
//  
//  Author:
//		Peter Stuifzand <peter@stuifzand.eu>
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

namespace WindowPipe
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow();
			
			win.Runner = new WindowPipe.ScriptRunner();
			win.Runner.Script = args;
			
			win.Show ();
			Application.Run ();
		}
	}
}

