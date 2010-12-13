using System;
using Owin;

public class Program {
	public static void Main(string[] args) {
		Owin.Handlers.Cgi.Run(new WebApps.MyApp());
	}
}
