// This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild
// Generated/taken from https://formats.kaitai.io/windows_lnk_file/csharp.html (cc0-1.0)


namespace Kaitai
{

    /// <summary>
    /// Windows .lnk files (AKA &quot;shell link&quot; file) are most frequently used
    /// in Windows shell to create &quot;shortcuts&quot; to another files, usually for
    /// purposes of running a program from some other directory, sometimes
    /// with certain preconfigured arguments and some other options.
    /// </summary>
    /// <remarks>
    /// Reference: <a href="https://winprotocoldoc.blob.core.windows.net/productionwindowsarchives/MS-SHLLINK/[MS-SHLLINK].pdf">Source</a>
    /// </remarks>
    public partial class WindowsLnkFile : KaitaiStruct
    {
        public static WindowsLnkFile FromFile(string fileName)
        {
            using (var k = new KaitaiStream(fileName))
            {
                return new WindowsLnkFile(k);
            }
        }


        public enum WindowState
        {
            Normal = 1,
            Maximized = 3,
            MinNoActive = 7,
        }

        public enum DriveTypes
        {
            Unknown = 0,
            NoRootDir = 1,
            Removable = 2,
            Fixed = 3,
            Remote = 4,
            Cdrom = 5,
            Ramdisk = 6,
        }
        public WindowsLnkFile(KaitaiStream p__io, KaitaiStruct p__parent = null, WindowsLnkFile p__root = null) : base(p__io)
        {
            m_parent = p__parent;
            m_root = p__root ?? this;
            _read();
        }
        private void _read()
        {
            _header = new FileHeader(m_io, this, m_root);
            if (Header.Flags.HasLinkTargetIdList) {
                _targetIdList = new LinkTargetIdList(m_io, this, m_root);
            }
            if (Header.Flags.HasLinkInfo) {
                _info = new LinkInfo(m_io, this, m_root);
            }
            if (Header.Flags.HasName) {
                _name = new StringData(m_io, this, m_root);
            }
            if (Header.Flags.HasRelPath) {
                _relPath = new StringData(m_io, this, m_root);
            }
            if (Header.Flags.HasWorkDir) {
                _workDir = new StringData(m_io, this, m_root);
            }
            if (Header.Flags.HasArguments) {
                _arguments = new StringData(m_io, this, m_root);
            }
            if (Header.Flags.HasIconLocation) {
                _iconLocation = new StringData(m_io, this, m_root);
            }
        }

        /// <remarks>
        /// Reference: <a href="https://winprotocoldoc.blob.core.windows.net/productionwindowsarchives/MS-SHLLINK/[MS-SHLLINK].pdf">Section 2.2</a>
        /// </remarks>
        public partial class LinkTargetIdList : KaitaiStruct
        {
            public static LinkTargetIdList FromFile(string fileName)
            {
                using (var k = new KaitaiStream(fileName))
                {
                    return new LinkTargetIdList(k);
                }
            }

            public LinkTargetIdList(KaitaiStream p__io, WindowsLnkFile p__parent = null, WindowsLnkFile p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _lenIdList = m_io.ReadU2le();
                __raw_idList = m_io.ReadBytes(LenIdList);
            }
            private ushort _lenIdList;
            private WindowsLnkFile m_root;
            private WindowsLnkFile m_parent;
            private byte[] __raw_idList;
            public ushort LenIdList { get { return _lenIdList; } }
            public WindowsLnkFile M_Root { get { return m_root; } }
            public WindowsLnkFile M_Parent { get { return m_parent; } }
            public byte[] M_RawIdList { get { return __raw_idList; } }
        }
        public partial class StringData : KaitaiStruct
        {
            public static StringData FromFile(string fileName)
            {
                using (var k = new KaitaiStream(fileName))
                {
                    return new StringData(k);
                }

            }

            public StringData(KaitaiStream p__io, WindowsLnkFile p__parent = null, WindowsLnkFile p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _charsStr = m_io.ReadU2le();
                _str = System.Text.Encoding.GetEncoding("UTF-16LE").GetString(m_io.ReadBytes((CharsStr * 2)));
            }
            private ushort _charsStr;
            private string _str;
            private WindowsLnkFile m_root;
            private WindowsLnkFile m_parent;
            public ushort CharsStr { get { return _charsStr; } }
            public string Str { get { return _str; } }
            public WindowsLnkFile M_Root { get { return m_root; } }
            public WindowsLnkFile M_Parent { get { return m_parent; } }
        }

        /// <remarks>
        /// Reference: <a href="https://winprotocoldoc.blob.core.windows.net/productionwindowsarchives/MS-SHLLINK/[MS-SHLLINK].pdf">Section 2.3</a>
        /// </remarks>
        public partial class LinkInfo : KaitaiStruct
        {
            public static LinkInfo FromFile(string fileName)
            {
                using (var k = new KaitaiStream(fileName))
                {
                    return new LinkInfo(k);
                }
            }

            public LinkInfo(KaitaiStream p__io, WindowsLnkFile p__parent = null, WindowsLnkFile p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _lenAll = m_io.ReadU4le();
                __raw_all = m_io.ReadBytes((LenAll - 4));
                using (var io___raw_all = new KaitaiStream(__raw_all))
                {
                    _all = new All(io___raw_all, this, m_root);
                }
            }

            /// <remarks>
            /// Reference: <a href="https://winprotocoldoc.blob.core.windows.net/productionwindowsarchives/MS-SHLLINK/[MS-SHLLINK].pdf">Section 2.3.1</a>
            /// </remarks>
            public partial class VolumeIdBody : KaitaiStruct
            {
                public static VolumeIdBody FromFile(string fileName)
                {
                    using (var k = new KaitaiStream(fileName))
                    {
                        return new VolumeIdBody(k);
                    }
                }

                public VolumeIdBody(KaitaiStream p__io, WindowsLnkFile.LinkInfo.VolumeIdSpec p__parent = null, WindowsLnkFile p__root = null) : base(p__io)
                {
                    m_parent = p__parent;
                    m_root = p__root;
                    f_isUnicode = false;
                    f_volumeLabelAnsi = false;
                    _read();
                }
                private void _read()
                {
                    _driveType = ((WindowsLnkFile.DriveTypes) m_io.ReadU4le());
                    _driveSerialNumber = m_io.ReadU4le();
                    _ofsVolumeLabel = m_io.ReadU4le();
                    if (IsUnicode) {
                        _ofsVolumeLabelUnicode = m_io.ReadU4le();
                    }
                }
                private bool f_isUnicode;
                private bool _isUnicode;
                public bool IsUnicode
                {
                    get
                    {
                        if (f_isUnicode)
                            return _isUnicode;
                        _isUnicode = (bool) (OfsVolumeLabel == 20);
                        f_isUnicode = true;
                        return _isUnicode;
                    }
                }
                private bool f_volumeLabelAnsi;
                private string _volumeLabelAnsi;
                public string VolumeLabelAnsi
                {
                    get
                    {
                        if (f_volumeLabelAnsi)
                            return _volumeLabelAnsi;
                        if (!(IsUnicode)) {
                            long _pos = m_io.Pos;
                            m_io.Seek((OfsVolumeLabel - 4));
                            _volumeLabelAnsi = System.Text.Encoding.GetEncoding("cp437").GetString(m_io.ReadBytesTerm(0, false, true, true));
                            m_io.Seek(_pos);
                            f_volumeLabelAnsi = true;
                        }
                        return _volumeLabelAnsi;
                    }
                }
                private DriveTypes _driveType;
                private uint _driveSerialNumber;
                private uint _ofsVolumeLabel;
                private uint? _ofsVolumeLabelUnicode;
                private WindowsLnkFile m_root;
                private WindowsLnkFile.LinkInfo.VolumeIdSpec m_parent;
                public DriveTypes DriveType { get { return _driveType; } }
                public uint DriveSerialNumber { get { return _driveSerialNumber; } }
                public uint OfsVolumeLabel { get { return _ofsVolumeLabel; } }
                public uint? OfsVolumeLabelUnicode { get { return _ofsVolumeLabelUnicode; } }
                public WindowsLnkFile M_Root { get { return m_root; } }
                public WindowsLnkFile.LinkInfo.VolumeIdSpec M_Parent { get { return m_parent; } }
            }

            /// <remarks>
            /// Reference: <a href="https://winprotocoldoc.blob.core.windows.net/productionwindowsarchives/MS-SHLLINK/[MS-SHLLINK].pdf">Section 2.3</a>
            /// </remarks>
            public partial class All : KaitaiStruct
            {
                public static All FromFile(string fileName)
                {
                    using (var k = new KaitaiStream(fileName))
                    {
                        return new All(k);
                    }
                }

                public All(KaitaiStream p__io, WindowsLnkFile.LinkInfo p__parent = null, WindowsLnkFile p__root = null) : base(p__io)
                {
                    m_parent = p__parent;
                    m_root = p__root;
                    f_volumeId = false;
                    f_localBasePath = false;
                    _read();
                }
                private void _read()
                {
                    _lenHeader = m_io.ReadU4le();
                    __raw_header = m_io.ReadBytes((LenHeader - 8));
                    using (var io___raw_header = new KaitaiStream(__raw_header))
                    {
                        _header = new Header(io___raw_header, this, m_root);
                    }
                }
                private bool f_volumeId;
                private VolumeIdSpec _volumeId;
                public VolumeIdSpec VolumeId
                {
                    get
                    {
                        if (f_volumeId)
                            return _volumeId;
                        if (Header.Flags.HasVolumeIdAndLocalBasePath) {
                            long _pos = m_io.Pos;
                            m_io.Seek((Header.OfsVolumeId - 4));
                            _volumeId = new VolumeIdSpec(m_io, this, m_root);
                            m_io.Seek(_pos);
                            f_volumeId = true;
                        }
                        return _volumeId;
                    }
                }
                private bool f_localBasePath;
                private byte[] _localBasePath;
                public byte[] LocalBasePath
                {
                    get
                    {
                        if (f_localBasePath)
                            return _localBasePath;
                        if (Header.Flags.HasVolumeIdAndLocalBasePath) {
                            long _pos = m_io.Pos;
                            m_io.Seek((Header.OfsLocalBasePath - 4));
                            _localBasePath = m_io.ReadBytesTerm(0, false, true, true);
                            m_io.Seek(_pos);
                            f_localBasePath = true;
                        }
                        return _localBasePath;
                    }
                }
                private uint _lenHeader;
                private Header _header;
                private WindowsLnkFile m_root;
                private WindowsLnkFile.LinkInfo m_parent;
                private byte[] __raw_header;
                public uint LenHeader { get { return _lenHeader; } }
                public Header Header { get { return _header; } }
                public WindowsLnkFile M_Root { get { return m_root; } }
                public WindowsLnkFile.LinkInfo M_Parent { get { return m_parent; } }
                public byte[] M_RawHeader { get { return __raw_header; } }
            }

            /// <remarks>
            /// Reference: <a href="https://winprotocoldoc.blob.core.windows.net/productionwindowsarchives/MS-SHLLINK/[MS-SHLLINK].pdf">Section 2.3.1</a>
            /// </remarks>
            public partial class VolumeIdSpec : KaitaiStruct
            {
                public static VolumeIdSpec FromFile(string fileName)
                {

                    using (var k = new KaitaiStream(fileName))
                    {
                        return new VolumeIdSpec(k);
                    }
                }

                public VolumeIdSpec(KaitaiStream p__io, WindowsLnkFile.LinkInfo.All p__parent = null, WindowsLnkFile p__root = null) : base(p__io)
                {
                    m_parent = p__parent;
                    m_root = p__root;
                    _read();
                }
                private void _read()
                {
                    _lenAll = m_io.ReadU4le();
                    __raw_body = m_io.ReadBytes((LenAll - 4));
                    using (var io___raw_body = new KaitaiStream(__raw_body))
                    {

                        _body = new VolumeIdBody(io___raw_body, this, m_root);
                    }
                }
                private uint _lenAll;
                private VolumeIdBody _body;
                private WindowsLnkFile m_root;
                private WindowsLnkFile.LinkInfo.All m_parent;
                private byte[] __raw_body;
                public uint LenAll { get { return _lenAll; } }
                public VolumeIdBody Body { get { return _body; } }
                public WindowsLnkFile M_Root { get { return m_root; } }
                public WindowsLnkFile.LinkInfo.All M_Parent { get { return m_parent; } }
                public byte[] M_RawBody { get { return __raw_body; } }
            }

            /// <remarks>
            /// Reference: <a href="https://winprotocoldoc.blob.core.windows.net/productionwindowsarchives/MS-SHLLINK/[MS-SHLLINK].pdf">Section 2.3</a>
            /// </remarks>
            public partial class LinkInfoFlags : KaitaiStruct
            {
                public static LinkInfoFlags FromFile(string fileName)
                {
                    using (var k = new KaitaiStream(fileName))
                    {
                        return new LinkInfoFlags(k);
                    }
                }

                public LinkInfoFlags(KaitaiStream p__io, WindowsLnkFile.LinkInfo.Header p__parent = null, WindowsLnkFile p__root = null) : base(p__io)
                {
                    m_parent = p__parent;
                    m_root = p__root;
                    _read();
                }
                private void _read()
                {
                    _reserved1 = m_io.ReadBitsIntBe(6);
                    _hasCommonNetRelLink = m_io.ReadBitsIntBe(1) != 0;
                    _hasVolumeIdAndLocalBasePath = m_io.ReadBitsIntBe(1) != 0;
                    _reserved2 = m_io.ReadBitsIntBe(24);
                }
                private ulong _reserved1;
                private bool _hasCommonNetRelLink;
                private bool _hasVolumeIdAndLocalBasePath;
                private ulong _reserved2;
                private WindowsLnkFile m_root;
                private WindowsLnkFile.LinkInfo.Header m_parent;
                public ulong Reserved1 { get { return _reserved1; } }
                public bool HasCommonNetRelLink { get { return _hasCommonNetRelLink; } }
                public bool HasVolumeIdAndLocalBasePath { get { return _hasVolumeIdAndLocalBasePath; } }
                public ulong Reserved2 { get { return _reserved2; } }
                public WindowsLnkFile M_Root { get { return m_root; } }
                public WindowsLnkFile.LinkInfo.Header M_Parent { get { return m_parent; } }
            }

            /// <remarks>
            /// Reference: <a href="https://winprotocoldoc.blob.core.windows.net/productionwindowsarchives/MS-SHLLINK/[MS-SHLLINK].pdf">Section 2.3</a>
            /// </remarks>
            public partial class Header : KaitaiStruct
            {
                public static Header FromFile(string fileName)
                {
                    using (var k = new KaitaiStream(fileName))
                    {
                        return new Header(k);
                    }
                }

                public Header(KaitaiStream p__io, WindowsLnkFile.LinkInfo.All p__parent = null, WindowsLnkFile p__root = null) : base(p__io)
                {
                    m_parent = p__parent;
                    m_root = p__root;
                    _read();
                }
                private void _read()
                {
                    _flags = new LinkInfoFlags(m_io, this, m_root);
                    _ofsVolumeId = m_io.ReadU4le();
                    _ofsLocalBasePath = m_io.ReadU4le();
                    _ofsCommonNetRelLink = m_io.ReadU4le();
                    _ofsCommonPathSuffix = m_io.ReadU4le();
                    if (!(M_Io.IsEof)) {
                        _ofsLocalBasePathUnicode = m_io.ReadU4le();
                    }
                    if (!(M_Io.IsEof)) {
                        _ofsCommonPathSuffixUnicode = m_io.ReadU4le();
                    }
                }
                private LinkInfoFlags _flags;
                private uint _ofsVolumeId;
                private uint _ofsLocalBasePath;
                private uint _ofsCommonNetRelLink;
                private uint _ofsCommonPathSuffix;
                private uint? _ofsLocalBasePathUnicode;
                private uint? _ofsCommonPathSuffixUnicode;
                private WindowsLnkFile m_root;
                private WindowsLnkFile.LinkInfo.All m_parent;
                public LinkInfoFlags Flags { get { return _flags; } }
                public uint OfsVolumeId { get { return _ofsVolumeId; } }
                public uint OfsLocalBasePath { get { return _ofsLocalBasePath; } }
                public uint OfsCommonNetRelLink { get { return _ofsCommonNetRelLink; } }
                public uint OfsCommonPathSuffix { get { return _ofsCommonPathSuffix; } }
                public uint? OfsLocalBasePathUnicode { get { return _ofsLocalBasePathUnicode; } }
                public uint? OfsCommonPathSuffixUnicode { get { return _ofsCommonPathSuffixUnicode; } }
                public WindowsLnkFile M_Root { get { return m_root; } }
                public WindowsLnkFile.LinkInfo.All M_Parent { get { return m_parent; } }
            }
            private uint _lenAll;
            private All _all;
            private WindowsLnkFile m_root;
            private WindowsLnkFile m_parent;
            private byte[] __raw_all;
            public uint LenAll { get { return _lenAll; } }
            public WindowsLnkFile M_Root { get { return m_root; } }
            public WindowsLnkFile M_Parent { get { return m_parent; } }
            public byte[] M_RawAll { get { return __raw_all; } }
        }

        /// <remarks>
        /// Reference: <a href="https://winprotocoldoc.blob.core.windows.net/productionwindowsarchives/MS-SHLLINK/[MS-SHLLINK].pdf">Section 2.1.1</a>
        /// </remarks>
        public partial class LinkFlags : KaitaiStruct
        {
            public static LinkFlags FromFile(string fileName)
            {
                using (var k = new KaitaiStream(fileName))
                {
                    return new LinkFlags(k);
                }

            }

            public LinkFlags(KaitaiStream p__io, WindowsLnkFile.FileHeader p__parent = null, WindowsLnkFile p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _isUnicode = m_io.ReadBitsIntBe(1) != 0;
                _hasIconLocation = m_io.ReadBitsIntBe(1) != 0;
                _hasArguments = m_io.ReadBitsIntBe(1) != 0;
                _hasWorkDir = m_io.ReadBitsIntBe(1) != 0;
                _hasRelPath = m_io.ReadBitsIntBe(1) != 0;
                _hasName = m_io.ReadBitsIntBe(1) != 0;
                _hasLinkInfo = m_io.ReadBitsIntBe(1) != 0;
                _hasLinkTargetIdList = m_io.ReadBitsIntBe(1) != 0;
                __unnamed8 = m_io.ReadBitsIntBe(16);
                _reserved = m_io.ReadBitsIntBe(5);
                _keepLocalIdListForUncTarget = m_io.ReadBitsIntBe(1) != 0;
                __unnamed11 = m_io.ReadBitsIntBe(2);
            }
            private bool _isUnicode;
            private bool _hasIconLocation;
            private bool _hasArguments;
            private bool _hasWorkDir;
            private bool _hasRelPath;
            private bool _hasName;
            private bool _hasLinkInfo;
            private bool _hasLinkTargetIdList;
            private ulong __unnamed8;
            private ulong _reserved;
            private bool _keepLocalIdListForUncTarget;
            private ulong __unnamed11;
            private WindowsLnkFile m_root;
            private WindowsLnkFile.FileHeader m_parent;
            public bool IsUnicode { get { return _isUnicode; } }
            public bool HasIconLocation { get { return _hasIconLocation; } }
            public bool HasArguments { get { return _hasArguments; } }
            public bool HasWorkDir { get { return _hasWorkDir; } }
            public bool HasRelPath { get { return _hasRelPath; } }
            public bool HasName { get { return _hasName; } }
            public bool HasLinkInfo { get { return _hasLinkInfo; } }
            public bool HasLinkTargetIdList { get { return _hasLinkTargetIdList; } }
            public ulong Unnamed_8 { get { return __unnamed8; } }
            public ulong Reserved { get { return _reserved; } }
            public bool KeepLocalIdListForUncTarget { get { return _keepLocalIdListForUncTarget; } }
            public ulong Unnamed_11 { get { return __unnamed11; } }
            public WindowsLnkFile M_Root { get { return m_root; } }
            public WindowsLnkFile.FileHeader M_Parent { get { return m_parent; } }
        }

        /// <remarks>
        /// Reference: <a href="https://winprotocoldoc.blob.core.windows.net/productionwindowsarchives/MS-SHLLINK/[MS-SHLLINK].pdf">Section 2.1</a>
        /// </remarks>
        public partial class FileHeader : KaitaiStruct
        {
            public static FileHeader FromFile(string fileName)
            {
                using (var k = new KaitaiStream(fileName))
                {
                    return new FileHeader(k);
                }
            }

            public FileHeader(KaitaiStream p__io, WindowsLnkFile p__parent = null, WindowsLnkFile p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _lenHeader = m_io.ReadBytes(4);
                if (!((KaitaiStream.ByteArrayCompare(LenHeader, new byte[] { 76, 0, 0, 0 }) == 0)))
                {
                    throw new ValidationNotEqualError(new byte[] { 76, 0, 0, 0 }, LenHeader, M_Io, "/types/file_header/seq/0");
                }
                _linkClsid = m_io.ReadBytes(16);
                if (!((KaitaiStream.ByteArrayCompare(LinkClsid, new byte[] { 1, 20, 2, 0, 0, 0, 0, 0, 192, 0, 0, 0, 0, 0, 0, 70 }) == 0)))
                {
                    throw new ValidationNotEqualError(new byte[] { 1, 20, 2, 0, 0, 0, 0, 0, 192, 0, 0, 0, 0, 0, 0, 70 }, LinkClsid, M_Io, "/types/file_header/seq/1");
                }
                __raw_flags = m_io.ReadBytes(4);
                using (var io___raw_flags = new KaitaiStream(__raw_flags))
                {
                    _flags = new LinkFlags(io___raw_flags, this, m_root);
                    _fileAttrs = m_io.ReadU4le();
                    _timeCreation = m_io.ReadU8le();
                    _timeAccess = m_io.ReadU8le();
                    _timeWrite = m_io.ReadU8le();
                    _targetFileSize = m_io.ReadU4le();
                    _iconIndex = m_io.ReadS4le();
                    _showCommand = ((WindowsLnkFile.WindowState)m_io.ReadU4le());
                    _hotkey = m_io.ReadU2le();
                    _reserved = m_io.ReadBytes(10);
                    if (!((KaitaiStream.ByteArrayCompare(Reserved, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }) == 0)))
                    {
                        throw new ValidationNotEqualError(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, Reserved, M_Io, "/types/file_header/seq/11");
                    }
                }
            }
            private byte[] _lenHeader;
            private byte[] _linkClsid;
            private LinkFlags _flags;
            private uint _fileAttrs;
            private ulong _timeCreation;
            private ulong _timeAccess;
            private ulong _timeWrite;
            private uint _targetFileSize;
            private int _iconIndex;
            private WindowState _showCommand;
            private ushort _hotkey;
            private byte[] _reserved;
            private WindowsLnkFile m_root;
            private WindowsLnkFile m_parent;
            private byte[] __raw_flags;

            /// <summary>
            /// Technically, a size of the header, but in reality, it's
            /// fixed by standard.
            /// </summary>
            public byte[] LenHeader { get { return _lenHeader; } }

            /// <summary>
            /// 16-byte class identified (CLSID), reserved for Windows shell
            /// link files.
            /// </summary>
            public byte[] LinkClsid { get { return _linkClsid; } }
            public LinkFlags Flags { get { return _flags; } }
            public uint FileAttrs { get { return _fileAttrs; } }
            public ulong TimeCreation { get { return _timeCreation; } }
            public ulong TimeAccess { get { return _timeAccess; } }
            public ulong TimeWrite { get { return _timeWrite; } }

            /// <summary>
            /// Lower 32 bits of the size of the file that this link targets
            /// </summary>
            public uint TargetFileSize { get { return _targetFileSize; } }

            /// <summary>
            /// Index of an icon to use from target file
            /// </summary>
            public int IconIndex { get { return _iconIndex; } }

            /// <summary>
            /// Window state to set after the launch of target executable
            /// </summary>
            public WindowState ShowCommand { get { return _showCommand; } }
            public ushort Hotkey { get { return _hotkey; } }
            public byte[] Reserved { get { return _reserved; } }
            public WindowsLnkFile M_Root { get { return m_root; } }
            public WindowsLnkFile M_Parent { get { return m_parent; } }
            public byte[] M_RawFlags { get { return __raw_flags; } }
        }
        private FileHeader _header;
        private LinkTargetIdList _targetIdList;
        private LinkInfo _info;
        private StringData _name;
        private StringData _relPath;
        private StringData _workDir;
        private StringData _arguments;
        private StringData _iconLocation;
        private WindowsLnkFile m_root;
        private KaitaiStruct m_parent;
        public FileHeader Header { get { return _header; } }
        public LinkTargetIdList TargetIdList { get { return _targetIdList; } }
        public LinkInfo Info { get { return _info; } }
        public StringData Name { get { return _name; } }
        public StringData RelPath { get { return _relPath; } }
        public StringData WorkDir { get { return _workDir; } }
        public StringData Arguments { get { return _arguments; } }
        public StringData IconLocation { get { return _iconLocation; } }
        public WindowsLnkFile M_Root { get { return m_root; } }
        public KaitaiStruct M_Parent { get { return m_parent; } }
    }
}
