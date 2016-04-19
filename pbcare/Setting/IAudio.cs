using System;

namespace pbcare
{
	public interface IAudio
	{
		bool PlayMp3File(string fileName);
		bool StopMP3File();
	}
}