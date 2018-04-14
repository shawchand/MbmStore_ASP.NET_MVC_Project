using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbmStore.Models
{
	//derived class from base Product class
	[Table("MusicCD")]
	public class MusicCD : Product
	{
		//field
		private List<Track> tracks = new List<Track>();

		//read-only property
		public List<Track> Tracks
		{
			set { tracks = value; }
			get { return tracks; }
		}	

		//automatic properties
		public string Artist { get; set; }
		public string Label { get; set; }
		public short Released { get; set; }

		//constructors
		public MusicCD()
		{

		}
		public MusicCD(string artist, string title, decimal price, short released, string imageurl) : base(title, price)
		{
			this.Artist = artist;
			this.Released = released;
			this.ImageUrl = imageurl;
		}
		public void AddTrack(Track track)
		{
			tracks.Add(track);
		}

		public TimeSpan GetPlayingTime()
		{
			TimeSpan totalPlayingTime = new TimeSpan(0);

			foreach (Track track in Tracks)
			{
				totalPlayingTime += track.Length;
			}
			return totalPlayingTime;
			
		}
	}
}