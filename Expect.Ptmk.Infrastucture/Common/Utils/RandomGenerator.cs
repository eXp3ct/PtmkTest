using Expect.Ptmk.Domain.Enums;
using System.Text;

namespace Expect.Ptmk.Infrastucture.Common.Utils
{
	public static class RandomGenerator
	{
		private const string _alphabet = "abcdefghijklmnopqrstuvwxyz";
		public static string GetRandomName(int length)
		{
			var stringBuilder = new StringBuilder();
			var alphabetLength = _alphabet.Length;

			for (var i = 0; i < length; i++)
			{
				stringBuilder.Append(_alphabet[new Random(DateTime.Now.Microsecond).Next(alphabetLength)]);
			}

			return stringBuilder.ToString();
		}

		public static Gender GetRandomGender()
		{
			var genders = Enum.GetValues<Gender>();

			return genders[new Random().Next(genders.Length)];
		}

		public static DateTime GetRandomDateOfBirth()
		{
			var random = new Random(DateTime.Now.Millisecond);
			int year = random.Next(2000, 2024);

			int month = random.Next(1, 13);

			int daysInMonth = DateTime.DaysInMonth(year, month);

			int day = random.Next(1, daysInMonth + 1);

			int hour = random.Next(0, 24);
			int minute = random.Next(0, 60);
			int second = random.Next(0, 60);
			int millisecond = random.Next(0, 1000);

			var randomDateTime = new DateTime(year, month, day, hour, minute, second, millisecond);

			return randomDateTime;
		}
	}
}
