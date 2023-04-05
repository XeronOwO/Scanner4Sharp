using Scanner4Sharp;

namespace Test
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// create a scanner
			var scanner = new Scanner();
			// the data used as input
			var s = new string[]
			{
				"a b c",
				"-111 12.5 8888888888 TTT",
			};

			// append "a b c" to the scanner.
			scanner.AppendBuffer(s[0]);
			// read "a"
			Console.WriteLine(scanner.NextString());

			// clear buffer: " b c"
			scanner.ClearBuffer();
			// append "-111 12.5 8888888888 TTT"
			scanner.AppendBuffer(s[1]);
			// read -111
			Console.WriteLine(scanner.NextInt());
			// read 12.5
			Console.WriteLine(scanner.NextDouble());
			// read 8888888888
			Console.WriteLine(scanner.NextLong());

			// check if the next value exists
			Console.WriteLine(scanner.HasNext());
			// clear buffer: " TTT"
			scanner.ClearBuffer();
			// check if the next value exists
			Console.WriteLine(scanner.HasNext());
		}
	}
}