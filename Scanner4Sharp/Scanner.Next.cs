using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner4Sharp
{
	public partial class Scanner
	{
		/// <summary>
		/// Scan for the next string.
		/// </summary>
		/// <returns>Next string.</returns>
		public string NextString()
		{
			return NextPart();
		}

		/// <summary>
		/// Scan for the next short.
		/// </summary>
		/// <returns>Next short.</returns>
		public short NextShort()
		{
			return short.Parse(NextPart());
		}

		/// <summary>
		/// Scan for the next ushort.
		/// </summary>
		/// <returns>Next ushort.</returns>
		public ushort NextUShort()
		{
			return ushort.Parse(NextPart());
		}

		/// <summary>
		/// Scan for the next int.
		/// </summary>
		/// <returns>Next int.</returns>
		public int NextInt()
		{
			return int.Parse(NextPart());
		}

		/// <summary>
		/// Scan for the next uint.
		/// </summary>
		/// <returns>Next uint.</returns>
		public uint NextUInt()
		{
			return uint.Parse(NextPart());
		}

		/// <summary>
		/// Scan for the next long.
		/// </summary>
		/// <returns>Next long.</returns>
		public long NextLong()
		{
			return long.Parse(NextPart());
		}

		/// <summary>
		/// Scan for the next ulong.
		/// </summary>
		/// <returns>Next ulong.</returns>
		public ulong NextULong()
		{
			return ulong.Parse(NextPart());
		}

		/// <summary>
		/// Scan for the next float.
		/// </summary>
		/// <returns>Next float.</returns>
		public float NextFloat()
		{
			return float.Parse(NextPart());
		}

		/// <summary>
		/// Scan for the next double.
		/// </summary>
		/// <returns>Next double.</returns>
		public double NextDouble()
		{
			return double.Parse(NextPart());
		}
	}
}
