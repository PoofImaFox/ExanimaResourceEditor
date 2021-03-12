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

        // TOD: Find DDS header sig
        public static byte[] Dds = new byte[] {
                0x01,
                0x0C,
                0xBF,
                0xAF
        };
    }
}
