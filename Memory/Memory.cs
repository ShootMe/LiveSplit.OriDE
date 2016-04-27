using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
namespace LiveSplit.OriDE.Memory {
	public static class MemoryReader {
		const int MEM_COMMIT = 0x00001000;
		const int MEM_PRIVATE = 0x00020000;
		const int PAGE_EXECUTE_READWRITE = 0x40;

		private enum AllocationProtect : uint {
			PAGE_EXECUTE = 0x00000010,
			PAGE_EXECUTE_READ = 0x00000020,
			PAGE_EXECUTE_READWRITE = 0x00000040,
			PAGE_EXECUTE_WRITECOPY = 0x00000080,
			PAGE_NOACCESS = 0x00000001,
			PAGE_READONLY = 0x00000002,
			PAGE_READWRITE = 0x00000004,
			PAGE_WRITECOPY = 0x00000008,
			PAGE_GUARD = 0x00000100,
			PAGE_NOCACHE = 0x00000200,
			PAGE_WRITECOMBINE = 0x00000400
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct MEMORY_BASIC_INFORMATION {
			public IntPtr BaseAddress;
			public IntPtr AllocationBase;
			public uint AllocationProtect;
			public IntPtr RegionSize;
			public uint State;
			public uint Protect;
			public uint Type;
		}

		public static T Read<T>(this Process targetProcess, IntPtr address, params int[] offsets) {
			byte[] buffer = new byte[8];
			int bytesRead;

			try {
				for (int i = 0; i < offsets.Length - 1; i++) {
					SafeNativeMethods.ReadProcessMemory(targetProcess.Handle, (IntPtr)(address + offsets[i]), buffer, 4, out bytesRead);
					address = (IntPtr)BitConverter.ToInt32(buffer, 0);
				}
				int last = offsets.Length > 0 ? offsets[offsets.Length - 1] : 0;
				if (typeof(T) == typeof(int)) {
					SafeNativeMethods.ReadProcessMemory(targetProcess.Handle, (IntPtr)(address + last), buffer, 4, out bytesRead);
					return (T)(object)BitConverter.ToInt32(buffer, 0);
				} else if (typeof(T) == typeof(long)) {
					SafeNativeMethods.ReadProcessMemory(targetProcess.Handle, (IntPtr)(address + last), buffer, 8, out bytesRead);
					return (T)(object)BitConverter.ToInt64(buffer, 0);
				} else if (typeof(T) == typeof(byte)) {
					SafeNativeMethods.ReadProcessMemory(targetProcess.Handle, (IntPtr)(address + last), buffer, 1, out bytesRead);
					buffer[1] = 0;
					return (T)(object)(byte)BitConverter.ToInt16(buffer, 0);
				} else if (typeof(T) == typeof(short)) {
					SafeNativeMethods.ReadProcessMemory(targetProcess.Handle, (IntPtr)(address + last), buffer, 2, out bytesRead);
					return (T)(object)BitConverter.ToInt64(buffer, 0);
				} else if (typeof(T) == typeof(float)) {
					SafeNativeMethods.ReadProcessMemory(targetProcess.Handle, (IntPtr)(address + last), buffer, 4, out bytesRead);
					return (T)(object)BitConverter.ToSingle(buffer, 0);
				} else if (typeof(T) == typeof(double)) {
					SafeNativeMethods.ReadProcessMemory(targetProcess.Handle, (IntPtr)(address + last), buffer, 8, out bytesRead);
					return (T)(object)BitConverter.ToDouble(buffer, 0);
				} else if (typeof(T) == typeof(bool)) {
					SafeNativeMethods.ReadProcessMemory(targetProcess.Handle, (IntPtr)(address + last), buffer, 1, out bytesRead);
					return (T)(object)BitConverter.ToBoolean(buffer, 0);
				} else if (typeof(T) == typeof(IntPtr)) {
					SafeNativeMethods.ReadProcessMemory(targetProcess.Handle, (IntPtr)(address + last), buffer, 4, out bytesRead);
					return (T)(object)(IntPtr)BitConverter.ToInt32(buffer, 0);
				}
			} catch { }
			return default(T);
		}
		public static byte[] GetBytes(this Process proc, IntPtr addr, int numBytes) {
			byte[] buffer = new byte[numBytes];
			int bytesRead;
			SafeNativeMethods.ReadProcessMemory(proc.Handle, addr, buffer, numBytes, out bytesRead);
			return buffer;
		}
		public static string GetString(this Process proc, IntPtr address) {
			if (address == IntPtr.Zero) { return string.Empty; }
			int length = Read<int>(proc, address, 0x8);
			return System.Text.Encoding.Unicode.GetString(GetBytes(proc, address + 0x0C, 2 * length));
		}
		public static void Write<T>(this Process targetProcess, IntPtr address, T value, params int[] offsets) {
			byte[] buffer = new byte[8];
			int bytesRead;

			try {
				for (int i = 0; i < offsets.Length - 1; i++) {
					SafeNativeMethods.ReadProcessMemory(targetProcess.Handle, (IntPtr)(address + offsets[i]), buffer, 4, out bytesRead);
					address = (IntPtr)BitConverter.ToInt32(buffer, 0);
				}
				int last = offsets.Length > 0 ? offsets[offsets.Length - 1] : 0;
				if (typeof(T) == typeof(int)) {
					buffer = BitConverter.GetBytes((int)((object)value));
					SafeNativeMethods.WriteProcessMemory(targetProcess.Handle, address + last, buffer, 4, out bytesRead);
				} else if (typeof(T) == typeof(long)) {
					buffer = BitConverter.GetBytes((long)((object)value));
					SafeNativeMethods.WriteProcessMemory(targetProcess.Handle, address + last, buffer, 8, out bytesRead);
				} else if (typeof(T) == typeof(byte)) {
					buffer = BitConverter.GetBytes((byte)((object)value));
					SafeNativeMethods.WriteProcessMemory(targetProcess.Handle, address + last, buffer, 1, out bytesRead);
				} else if (typeof(T) == typeof(short)) {
					buffer = BitConverter.GetBytes((short)((object)value));
					SafeNativeMethods.WriteProcessMemory(targetProcess.Handle, address + last, buffer, 2, out bytesRead);
				} else if (typeof(T) == typeof(float)) {
					buffer = BitConverter.GetBytes((float)((object)value));
					SafeNativeMethods.WriteProcessMemory(targetProcess.Handle, address + last, buffer, 4, out bytesRead);
				} else if (typeof(T) == typeof(double)) {
					buffer = BitConverter.GetBytes((double)((object)value));
					SafeNativeMethods.WriteProcessMemory(targetProcess.Handle, address + last, buffer, 8, out bytesRead);
				} else if (typeof(T) == typeof(bool)) {
					buffer = BitConverter.GetBytes((bool)((object)value));
					SafeNativeMethods.WriteProcessMemory(targetProcess.Handle, address + last, buffer, 1, out bytesRead);
				}
			} catch { }
		}
		public static void WriteBytes(this Process proc, IntPtr addr, byte[] data) {
			int num = 0;
			SafeNativeMethods.WriteProcessMemory(proc.Handle, addr, data, data.Length, out num);
		}

		public static IntPtr[] FindSignatures(this Process targetProcess, params string[] searchStrings) {
			IntPtr[] returnAddresses = new IntPtr[searchStrings.Length];
			MemorySignature[] byteCodes = new MemorySignature[searchStrings.Length];
			for (int i = 0; i < searchStrings.Length; i++) {
				byteCodes[i] = GetSignature(searchStrings[i]);
			}

			try {
				long minAddress = 0;
				long maxAddress = 0x7fffffff;

				MEMORY_BASIC_INFORMATION memInfo;

				int totalBytesRead = 0;
				int foundAddresses = 0;
				while (minAddress < maxAddress && foundAddresses < searchStrings.Length) {
					SafeNativeMethods.VirtualQueryEx(targetProcess.Handle, (IntPtr)minAddress, out memInfo, (uint)Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));

					// if this memory chunk is accessible
					if ((memInfo.AllocationProtect & PAGE_EXECUTE_READWRITE) != 0 && memInfo.Type == MEM_PRIVATE && memInfo.State == MEM_COMMIT) {
						byte[] buffer = new byte[memInfo.RegionSize.ToInt32()];

						int bytesRead = 0;
						// read everything in the buffer above
						if (SafeNativeMethods.ReadProcessMemory(targetProcess.Handle, (IntPtr)memInfo.BaseAddress, buffer, memInfo.RegionSize.ToInt32(), out bytesRead)) {
							totalBytesRead += bytesRead;

							for (int i = 0; i < searchStrings.Length; i++) {
								if (returnAddresses[i] == IntPtr.Zero) {
									if (SearchMemory(buffer, byteCodes[i], (IntPtr)minAddress, ref returnAddresses[i])) {
										foundAddresses++;
									}
								}
							}
						}
					}

					// move to the next memory chunk
					minAddress += memInfo.RegionSize.ToInt32();
				}

			} catch { }

			return returnAddresses;
		}
		private static bool SearchMemory(byte[] buffer, MemorySignature byteCode, IntPtr currentAddress, ref IntPtr foundAddress) {
			byte[] bytes = byteCode.byteCode;
			byte[] wild = byteCode.wildCards;
			for (int i = 0, j = 0; i <= buffer.Length - bytes.Length; i++) {
				int k = i;
				while (j < bytes.Length && (wild[j] == 1 || buffer[k] == bytes[j])) {
					k++; j++;
				}
				if (j == bytes.Length) {
					foundAddress = currentAddress + i + bytes.Length + byteCode.offset;
					return true;
				}
				j = 0;
			}
			return false;
		}
		private static MemorySignature GetSignature(string searchString) {
			int offsetIndex = searchString.IndexOf("|");
			offsetIndex = offsetIndex < 0 ? searchString.Length : offsetIndex;

			if (offsetIndex % 2 != 0) {
				Console.WriteLine(searchString + " is of odd length.");
				return null;
			}

			byte[] byteCode = new byte[offsetIndex / 2];
			byte[] wildCards = new byte[offsetIndex / 2];
			for (int i = 0, j = 0; i < offsetIndex; i++) {
				byte temp = (byte)(((int)searchString[i] - 0x30) & 0x1F);
				byteCode[j] |= temp > 0x09 ? (byte)(temp - 7) : temp;
				if (searchString[i] == '?') {
					wildCards[j] = 1;
				}
				if ((i & 1) == 1) {
					j++;
				} else {
					byteCode[j] <<= 4;
				}
			}
			int offset = 0;
			if (offsetIndex < searchString.Length) {
				int.TryParse(searchString.Substring(offsetIndex + 1), out offset);
			}
			return new MemorySignature(byteCode, wildCards, offset);
		}

		private class MemorySignature {
			public byte[] byteCode;
			public byte[] wildCards;
			public int offset;

			public MemorySignature(byte[] byteCode, byte[] wildCards, int offset) {
				this.byteCode = byteCode;
				this.wildCards = wildCards;
				this.offset = offset;
			}
		}

		private static class SafeNativeMethods {
			[DllImport("kernel32.dll", SetLastError = true)]
			public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);
			[DllImport("kernel32.dll", SetLastError = true)]
			public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesWritten);
			[DllImport("kernel32.dll", SetLastError = true)]
			public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);
		}
	}
}