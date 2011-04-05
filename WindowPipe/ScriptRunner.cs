//  
//  ScriptRunner.cs
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
using System.Diagnostics;

	
namespace WindowPipe
{
	public class ScriptRunner
	{
		public ScriptRunner()
		{
		}
		
		//public bool UseFilenames {get; set;}
		public string[] Script {get;set;}
		
		public void Run(string uri) {
			string file_arg = uri;
			//string file_arg = new Uri(uri).AbsolutePath;
			
			if (Script == null || Script.Length == 0) {
				System.Console.WriteLine("Script not set, but file dropped: {0}", file_arg);
			}
			else {
				ProcessStartInfo info = new ProcessStartInfo();
				info.FileName = Script[0];
				info.Arguments = String.Join(" ", Script, 1, Script.Length-1);
				info.Arguments += " \"" + file_arg + "\"";
				info.UseShellExecute = false;
				Process.Start(info);
			}
		}
	}
}

