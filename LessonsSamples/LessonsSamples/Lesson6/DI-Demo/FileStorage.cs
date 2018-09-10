using System;
using System.IO;

namespace LessonsSamples.Lesson6
{
  class FileStorage : ITextStorage
	{
		private readonly string filename;

		public FileStorage()
		{
			filename = $"{Guid.NewGuid()}.txt";
		}

		public void Write(string text)
		{
			using (var s = File.AppendText(filename))
			{
				s.Write(text);
				s.Close();
			}
		}

		public void WriteLine(string line)
		{
			using (var s = File.AppendText(filename))
			{
				s.WriteLine(line);
				s.Close();
			}
		}

		public string ReadAll()
		{
			try
			{
				using (var s = File.OpenText(filename))
				{
					return s.ReadToEnd();
				}
			}
			catch (FileNotFoundException)
			{
				return string.Empty;
			}
			
		}

		public string ReadLine(int lineNumber)
		{
			using (var s = File.OpenText(filename))
			{
				int count = 0;
				while (!s.EndOfStream)
				{
					string line = s.ReadLine();
					count++;
					if (count == lineNumber)
						return line;
				}
			}
			return string.Empty;
		}

		public void Clear()
		{
			File.WriteAllText(filename, string.Empty);
		}
	}
}