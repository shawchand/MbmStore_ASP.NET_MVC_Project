using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
	public class Track : MusicCD
	{
		//fields
		public string title;
		public string composer;
		public TimeSpan lengt;

		//properties
		public string Title1 { get; set; }
		public string Composer { get; set; }
		public TimeSpan Length { get; set; }

		public Track()
		{

		}

		public Track(string title, string composer, TimeSpan lenght)
		{
			this.Title1 = title;
			this.Composer = composer;
			this.Length = lenght;
		}
	}
}