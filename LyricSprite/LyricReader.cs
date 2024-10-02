using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LyricSprite
{
	public static class LyricReader
	{
		private static List<Lyric> LrcHandling(TextReader reader)
		{
			List<Lyric> result = [];
			string? line;
			while ((line = reader.ReadLine()) != null) {
				MatchCollection matches = Regex.Matches(line, @"\[(\d{2}):(\d{2})\.(\d{2,3})\]");
				string text = Regex.Match(line, @"(?<=\])[^\[\]].+?$").Value.Replace("\\", "");
				foreach (Match match in matches) { 
					TimeSpan time = new(0, 0, 
						int.Parse(match.Groups[1].Value), 
						int.Parse(match.Groups[2].Value),
						int.Parse(match.Groups[3].Value));
					if(text != "")
						result.Add(new(time, text));
				}
			}
			return [.. result.OrderBy(i => i.Time)];
		}
		private static List<Lyric> TxtHandling(TextReader reader)
		{
			List<Lyric> result = [];
			string? line;
			while ((line = reader.ReadLine()) != null) { 
				if(line != "")
					result.Add(new(TimeSpan.Zero, line));
			}
			return result;
		}
		public static List<Lyric> Read(string filename)
		{
			return Path.GetExtension(filename) switch
			{
				".lrc" => LrcHandling(new StreamReader(filename)),
				".txt" => TxtHandling(new StreamReader(filename)),
				_ => throw new NotImplementedException()
			};
		}
	}
}
