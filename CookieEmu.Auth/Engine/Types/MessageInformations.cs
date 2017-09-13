using System;
using CookieEmu.API.IO;
using CookieEmu.Auth.Network;

namespace CookieEmu.Auth.Engine.Types
{
    public class MessageInformations
    {
        #region Fields
        private readonly BigEndianReader _mReader = new BigEndianReader();
        private int? _mHeader;
        private int? _mLength;
        private byte[] _mData;
        private int? _mLenghtType;
        private int? _mProtocolId;
        private uint? _instanceId;
        private readonly Client _socket;
        #endregion

        public MessageInformations(Client s)
        {
            _socket = s;
        }
        #region Public methods

        public void ParseBuffer(byte[] data)
        {
            _mReader.Add(data, 0, data.Length);
            if (_mReader.BytesAvailable <= 0)
                return;
            while (_mReader.BytesAvailable != 0)
            {
                if (Build())
                {
                    var treatment = new Treatment();

                    if (_mProtocolId != null)
                        treatment.Treat(_mProtocolId.Value, _mData, _socket);

                    _mHeader = null;
                    _mLength = null;
                    _mData = null;
                    _mLenghtType = null;
                    _mProtocolId = null;
                }
                else
                    break;
            }
        }
        #endregion

        #region Private methods
        private bool Build()
        {
            if ((_mHeader.HasValue) && (_mLength.HasValue) && (_mLength == _mData.Length))
                return true;
            if ((_mReader.BytesAvailable >= 2) && (!_mHeader.HasValue))
            {
                _mHeader = _mReader.ReadShort();
                _mProtocolId = _mHeader >> 2;
                _mLenghtType = _mHeader & 0x3;
                _instanceId = _mReader.ReadUInt();
            }
            if ((_mLenghtType.HasValue) &&
            (_mReader.BytesAvailable >= _mLenghtType) && (!_mLength.HasValue))
            {
                if ((_mLenghtType < 0) || (_mLenghtType > 3))
                    throw new Exception("Malformated Message Header, invalid bytes number to read message length (inferior to 0 or superior to 3)");
                _mLength = 0;
                for (var i = _mLenghtType.Value - 1; i >= 0; i--)
                    _mLength |= _mReader.ReadByte() << (i * 8);
            }
            if ((_mData == null) && (_mLength.HasValue))
            {
                if (_mLength == 0)
                    _mData = new byte[0];
                if (_mReader.BytesAvailable >= _mLength)
                    _mData = _mReader.ReadBytes(_mLength.Value);
                else if (_mLength > _mReader.BytesAvailable)
                    _mData = _mReader.ReadBytes((int)_mReader.BytesAvailable);
            }
            if ((_mData == null) || (!_mLength.HasValue) || (!(_mData.Length < _mLength)))
                return _mData != null && ((_mHeader.HasValue) && (_mLength.HasValue) && (_mLength == _mData.Length));
            var bytesToRead = 0;
            if (_mData.Length + _mReader.BytesAvailable < _mLength)
                bytesToRead = (int)_mReader.BytesAvailable;
            else if (_mData.Length + _mReader.BytesAvailable >= _mLength)
                bytesToRead = _mLength.Value - _mData.Length;
            if (bytesToRead == 0)
                return _mData != null && ((_mHeader.HasValue) && (_mLength == _mData.Length));
            var oldLength = _mData.Length;
            Array.Resize(ref _mData, _mData.Length + bytesToRead);
            Array.Copy(_mReader.ReadBytes(bytesToRead), 0, _mData, oldLength, bytesToRead);
            return _mData != null && ((_mHeader.HasValue) && (_mLength == _mData.Length));
        }
        #endregion
    }
}