using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExanimaResourceEditor {
    public static class ArrayExtensions {
        public static T[] RemoveAt<T>(this T[] sourceArray, int index) {
            var destination = new T[sourceArray.Length - 1];
            if (index > 0) {
                Array.Copy(sourceArray, 0, destination, 0, index);
            }

            if (index < sourceArray.Length - 1) {
                Array.Copy(sourceArray, index + 1, destination, index, sourceArray.Length - index - 1);
            }

            return destination;
        }

        public static T[] AddItem<T>(this T[] destination, T additionalItem) {
            Array.Resize(ref destination, destination.Length + 1);
            destination[destination.Length - 1] = additionalItem;
            return destination;
        }
    }
}