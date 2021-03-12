using System;
using System.Collections.Generic;
using System.Text;

namespace ExanimaResrouceSdk {
    public struct FileHeaders {
        public static byte[] RpkHeader = new byte[] {
            0x01,
            0x0C,
            0xBF,
            0xAF
        };

        public static byte[] Wave = new byte[] {
            0x52,
            0x49,
            0x46,
            0x46
        };

        public static byte[] Texture = new byte[] {
            0xC6,
            0x3D,
            0x2D,
            0x1D
        };
    }
}