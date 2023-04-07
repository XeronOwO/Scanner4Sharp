using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner4Sharp
{
	/// <summary>
	/// The main scanner.
	/// </summary>
	public partial class Scanner
	{
		/// <summary>
		/// Stores the data to be processed.<br/>
		/// Index of 0 is under processing, others are in queue.
		/// </summary>
		private readonly List<string> _buffers = new();

		/// <summary>
		/// The position to be processed from.
		/// </summary>
		private int _position;

		/// <summary>
		/// The chars which should be skipped.
		/// </summary>
		private static readonly char[] _skipChars = new char[]
		{
			'\t', '\r', '\n', ' ',
		};

		/// <summary>
		/// Append a buffer to the queue to be processed.
		/// </summary>
		/// <param name="buffer"></param>
		public void AppendBuffer(string buffer)
		{
			_buffers.Add(buffer);
		}

		/// <summary>
		/// Append buffers to the queue to be processed.
		/// </summary>
		/// <param name="buffers"></param>
		public void AppendBuffers(IEnumerable<string> buffers)
		{
			_buffers.AddRange(buffers);
		}

		/// <summary>
		/// Clear buffers.
		/// </summary>
		public void ClearBuffer()
		{
			_buffers.Clear();
			_position = 0;
		}

		/// <summary>
		/// Whether the next value exists.
		/// </summary>
		/// <returns><b>true</b> if exists, <b>false</b> otherwise.</returns>
		public bool HasNext
		{
			get
			{
				if (_buffers.Count == 0)
				{
					return false;
				}

				// Check _buffers[0]
				for (int i = _position; i < _buffers[0].Length; i++)
				{
					if (!_skipChars.Contains(_buffers[0][i]))
					{
						return true;
					}
				}

				// Check _buffers[1..]
				for (int i = 1; i < _buffers.Count; i++)
				{
					var buffer = _buffers[i];
					for (int j = 0; j < buffer.Length; j++)
					{
						if (!_skipChars.Contains(_buffers[0][i]))
						{
							return true;
						}
					}
				}

				return false;
			}
		}

		/// <summary>
		/// Intercept the next part of the buffer.<br/>
		/// A <b>part</b> ends with <b>_skipChars</b> or EOF.
		/// </summary>
		/// <returns>The next part of the buffer.</returns>
		private string NextPart()
		{
			var result = new StringBuilder();
			while (true)
			{
				// _buffers is empty. Read one line from console.
				if (_buffers.Count == 0)
				{
					_buffers.Add(Console.ReadLine());
					_position = 0;
				}

				// Scan the next part
				var buffer = _buffers.First();
				bool find = false;
				for (; _position < buffer.Length; _position++)
				{
					var ch = buffer[_position];
					if (!find)
					{
						if (_skipChars.Contains(ch))
						{
							continue;
						}
						find = true;
						result.Append(ch);
					}
					else
					{
						if (_skipChars.Contains(ch))
						{
							break;
						}
						result.Append(ch);
					}
				}

				// End of the buffer.
				if (_position >= buffer.Length)
				{
					_buffers.RemoveAt(0);
				}

				// Next part found
				if (find)
				{
					break;
				}
			}

			return result.ToString();
		}
	}
}