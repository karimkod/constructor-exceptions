using System.Runtime.InteropServices;

public class MemoryDumper : IDisposable
{
    private IntPtr _unmanagedBuffer;
    private readonly int _size;
    private readonly Stream _destinationStream;

    public MemoryDumper(int size, string filePath)
    {
        this._size = size;
        _unmanagedBuffer = Marshal.AllocHGlobal(size);
        _destinationStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
    }

    public void DumpToFile()
    {
        using (var bw = new BinaryWriter(_destinationStream))
        {
            byte[] buffer = new byte[_size];
            Marshal.Copy(_unmanagedBuffer, buffer, 0, _size);
            bw.Write(buffer);
        }
    }

    public void Dispose()
    {
        if (_unmanagedBuffer != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(_unmanagedBuffer);
            _unmanagedBuffer = IntPtr.Zero;
        }
    }
}
