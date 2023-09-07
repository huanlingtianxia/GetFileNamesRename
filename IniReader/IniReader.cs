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

/* ����˵��
 1 ini�ļ���д   

kernel32.dll��Windows�зǳ���Ҫ��32λ��̬���ӿ��ļ��������ں˼��ļ�����������ϵͳ���ڴ�������ݵ���������������жϴ�����Windows����ʱ��kernel32.dll��פ�����ڴ����ض���д��������ʹ��ĳ����޷�ռ������ڴ�����

ΪʲôҪ�����۶�дini�ļ��أ��ѵ������ݿ����ǾͲ��ö�д�ļ�����ʲô���ݶ������ݿ��ȡ��������Щ�����Ǹ��ݿͻ���ϰ�ߣ���û��Ҫȥ��ȡ���ݿ��ˣ�����˵��������Ҫ��һ����ס����Ĺ��ܣ������web�ˣ��㻹������cookie�ⶫ��������Ҫ��winform�أ���ʱ��ini�ļ��Ϳ��������ó��ˡ����ǿ��԰��û����������ini�ļ��

ע�����

ini�ļ�·����������
�ɽ�ini���ڳ�������Ŀ¼����ʱIpFileName����Ϊ��.\FileName.ini��
2 ����  

��1�� GetPrivateProfileInt �� ʹ�ø÷����ɻ�ȡini�������ݣ�δ��ȡ��ʱ���ȡ���õ�Ĭ������


UINT WINAPI GetPrivateProfileInt
(
_In_LPCTSTR lpAppName, //ini�ļ�����������
_In_LPCTSTR lpKeyName, //����
_In_INT nDefault, //Ĭ��ֵ
_In_LPCTSTR lpFileName //ini�ļ�·��
);

(2)  GetPrivateProfileString�� ʹ�ø÷����ɻ�ȡstring�������ݣ�δ��ȡ��ʱ���ȡ���õ�Ĭ������


UINT WINAPI GetPrivateProfileString
(
_In_LPCTSTR lpAppName, //ini�ļ�����������
_In_LPCTSTR lpKeyName, //����
_In_INT nDefault, //Ĭ��ֵ
_In_LPSTR lpReturnedString,//����ini�ļ���ֵ��CString����ָ��һ���ַ�������������������ΪnSize
_In_DWORD nSize,//ָ��װ�ص�IpReturnedString������������ַ���
_In_LPCTSTR lpFileName //ini�ļ�·��
);

��3�� WritePrivateProfileString�� ��ini��дֵ�����Խ���д��string���㹻��


BOOL WritePrivateProfileString(
LPCTSTR lpAppName,//ini�ļ���������
LPCTSTR lpKeyName,//����
LPCTSTR lpString,//��ֵ
LPCTSTR lpFileName
);

 
 */
