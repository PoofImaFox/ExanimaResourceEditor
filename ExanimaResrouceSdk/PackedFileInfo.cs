using System;
using System.Collections.Generic;
using System.Text;

namespace ExanimaResrouceSdk {
    public class PackedFileInfo {
        /// <summary>
        /// Name of the packed file.
        /// </summary>
        public string name;

        /// <summary>
        /// The offset of the file starting when the details list ends.
        /// </summary>
        public uint dataStartOffset;

        /// <summary>
        /// Size of the packed file in bytes.
        /// </summary>
        public uint size;

        /// <summary>
        /// Address of the file.
        /// </summary>
        public uint location;

        /// <summary>
        /// This is used when packing the file to find the file data.
        /// </summary>
        public string coldStorageLocation;

        /// <summary>
        /// The file type.
        /// </summary>
        public string extension;
    }
}