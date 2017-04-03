﻿using System.IO;
using System.Text;

namespace Microsoft.Rest.ClientRuntime.Test
{
    public sealed class Utf8Writer
    {
        private readonly Stream _Stream;

        public const string Eol = "\n"; 

        public Utf8Writer(Stream stream)
        {
            _Stream = stream;
        }

        public Utf8Writer Write(string value)
        {
            var array = Encoding.UTF8.GetBytes(value);
            _Stream.Write(array, 0, array.Length);
            return this;
        }

        public Utf8Writer WriteLine()
            => Write(Eol);

        public Utf8Writer WriteLine(string value)
            => Write(value).WriteLine();
    }
}
