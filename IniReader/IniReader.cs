using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Syntronic.IniReader
{
	internal class IniReader
	{
		private const int MAX_ENTRY = 32768;

		public string Filename
		{
			get;
			set;
		}

		public string Section
		{
			get;
			set;
		}

		[DllImport("KERNEL32.DLL", CharSet = CharSet.Ansi, EntryPoint = "GetPrivateProfileIntA")]
		private static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);

		[DllImport("KERNEL32.DLL", CharSet = CharSet.Ansi, EntryPoint = "WritePrivateProfileStringA")]
		private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

		[DllImport("KERNEL32.DLL", CharSet = CharSet.Ansi, EntryPoint = "GetPrivateProfileStringA")]
		private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

		[DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetPrivateProfileStringW", ExactSpelling = true, SetLastError = true)]
		private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, string lpReturnString, int nSize, string lpFilename);

		[DllImport("KERNEL32.DLL", CharSet = CharSet.Ansi, EntryPoint = "GetPrivateProfileSectionNamesA")]
		private static extern int GetPrivateProfileSectionNames(byte[] lpszReturnBuffer, int nSize, string lpFileName);

		[DllImport("KERNEL32.DLL", CharSet = CharSet.Ansi, EntryPoint = "WritePrivateProfileSectionA")]
		private static extern int WritePrivateProfileSection(string lpAppName, string lpString, string lpFileName);

		public IniReader(string filename)
		{
			Filename = filename;
		}

		public int ReadInteger(string section, string key, int defVal)
		{
			return GetPrivateProfileInt(section, key, defVal, Filename);
		}

		public int ReadInteger(string section, string key)
		{
			return ReadInteger(section, key, 0);
		}

		public int ReadInteger(string key, int defVal)
		{
			return ReadInteger(Section, key, defVal);
		}

		public int ReadInteger(string key)
		{
			return ReadInteger(key, 0);
		}

		public string ReadString(string section, string key, string defVal)
		{
			StringBuilder stringBuilder = new StringBuilder(32768);
			GetPrivateProfileString(section, key, defVal, stringBuilder, 32768, Filename);
			return stringBuilder.ToString();
		}

		public string ReadString(string section, string key)
		{
			return ReadString(section, key, "");
		}

		public string ReadString(string key)
		{
			return ReadString(Section, key);
		}

		public long ReadLong(string section, string key, long defVal)
		{
			return long.Parse(ReadString(section, key, defVal.ToString(CultureInfo.InvariantCulture)));
		}

		public long ReadLong(string section, string key)
		{
			return ReadLong(section, key, 0L);
		}

		public long ReadLong(string key, long defVal)
		{
			return ReadLong(Section, key, defVal);
		}

		public long ReadLong(string key)
		{
			return ReadLong(key, 0L);
		}

		public byte[] ReadByteArray(string section, string key)
		{
			try
			{
				return Convert.FromBase64String(ReadString(section, key));
			}
			catch
			{
			}
			return null;
		}

		public byte[] ReadByteArray(string key)
		{
			return ReadByteArray(Section, key);
		}

		public bool ReadBoolean(string section, string key, bool defVal)
		{
			return bool.Parse(ReadString(section, key, defVal.ToString()));
		}

		public bool ReadBoolean(string section, string key)
		{
			return ReadBoolean(section, key, defVal: false);
		}

		public bool ReadBoolean(string key, bool defVal)
		{
			return ReadBoolean(Section, key, defVal);
		}

		public bool ReadBoolean(string key)
		{
			return ReadBoolean(Section, key);
		}

		public bool Write(string section, string key, int value)
		{
			return Write(section, key, value.ToString(CultureInfo.InvariantCulture));
		}

		public bool Write(string key, int value)
		{
			return Write(Section, key, value);
		}

		public bool Write(string section, string key, string value)
		{
			return WritePrivateProfileString(section, key, value, Filename) != 0;
		}

		public bool Write(string key, string value)
		{
			return Write(Section, key, value);
		}

		public bool Write(string section, string key, long value)
		{
			return Write(section, key, value.ToString(CultureInfo.InvariantCulture));
		}

		public bool Write(string key, long value)
		{
			return Write(Section, key, value);
		}

		public bool Write(string section, string key, byte[] value)
		{
			if (value == null)
			{
				return Write(section, key, (string)null);
			}
			return Write(section, key, value, 0, value.Length);
		}

		public bool Write(string key, byte[] value)
		{
			return Write(Section, key, value);
		}

		public bool Write(string section, string key, byte[] value, int offset, int length)
		{
			if (value == null)
			{
				return Write(section, key, (string)null);
			}
			return Write(section, key, Convert.ToBase64String(value, offset, length));
		}

		public bool Write(string section, string key, bool value)
		{
			return Write(section, key, value.ToString());
		}

		public bool Write(string key, bool value)
		{
			return Write(Section, key, value);
		}

		public bool DeleteKey(string section, string key)
		{
			return WritePrivateProfileString(section, key, null, Filename) != 0;
		}

		public bool DeleteKey(string key)
		{
			return WritePrivateProfileString(Section, key, null, Filename) != 0;
		}

		public bool DeleteSection(string section)
		{
			return WritePrivateProfileSection(section, null, Filename) != 0;
		}

		public string[] GetSectionNames()
		{
			try
			{
				byte[] array = new byte[32768];
				GetPrivateProfileSectionNames(array, 32768, Filename);
				return Encoding.ASCII.GetString(array).Trim(default(char)).Split(default(char));
			}
			catch
			{
			}
			return null;
		}

		public string[] GetKeyNames(string section)
		{
			try
			{
				string text = new string(' ', 32768);
				GetPrivateProfileString(section, null, null, text, 32768, Filename);
				text = text.Substring(0, text.LastIndexOf('\0'));
				return text.Trim(default(char)).Split(default(char));
			}
			catch
			{
			}
			return null;
		}
	}
}

/* 函数说明
 1 ini文件读写   

kernel32.dll是Windows中非常重要的32位动态链接库文件，属于内核级文件。它控制着系统的内存管理、数据的输入输出操作和中断处理，当Windows启动时，kernel32.dll就驻留在内存中特定的写保护区域，使别的程序无法占用这个内存区域。

为什么要来讨论读写ini文件呢，难道有数据库我们就不用读写文件了吗，什么数据都从数据库读取出来吗，有些东西是根据客户的习惯，就没必要去读取数据库了，或者说，比如你要做一个记住密码的功能，如果在web端，你还可以用cookie这东西，但是要是winform呢，这时候ini文件就可以派上用场了。我们可以把用户和密码存在ini文件里。

注意事项：

ini文件路径必须完整
可将ini放在程序所在目录，此时IpFileName参数为“.\FileName.ini”
2 方法  

（1） GetPrivateProfileInt ： 使用该方法可获取ini类型数据，未获取到时则会取设置的默认数据


UINT WINAPI GetPrivateProfileInt
(
_In_LPCTSTR lpAppName, //ini文件中区块名称
_In_LPCTSTR lpKeyName, //键名
_In_INT nDefault, //默认值
_In_LPCTSTR lpFileName //ini文件路径
);

(2)  GetPrivateProfileString： 使用该方法可获取string类型数据，未获取到时则会取设置的默认数据


UINT WINAPI GetPrivateProfileString
(
_In_LPCTSTR lpAppName, //ini文件中区块名称
_In_LPCTSTR lpKeyName, //键名
_In_INT nDefault, //默认值
_In_LPSTR lpReturnedString,//接受ini文件中值的CString对象，指定一个字符串缓冲区，长度至少为nSize
_In_DWORD nSize,//指定装载到IpReturnedString缓冲区的最大字符数
_In_LPCTSTR lpFileName //ini文件路径
);

（3） WritePrivateProfileString： 向ini中写值，所以仅有写入string就足够了


BOOL WritePrivateProfileString(
LPCTSTR lpAppName,//ini文件中区块名
LPCTSTR lpKeyName,//键名
LPCTSTR lpString,//键值
LPCTSTR lpFileName
);

 
 */
