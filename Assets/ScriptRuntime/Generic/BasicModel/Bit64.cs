using System;
using System.Runtime.InteropServices;

namespace WOW {

    [StructLayout(LayoutKind.Explicit)]
    public struct Bit64 {

        [FieldOffset(0)]
        public int i32_0;
        [FieldOffset(4)]
        public int i32_1;
        [FieldOffset(0)]
        public long i64;
        [FieldOffset(0)]
        public ulong u64;

        public Bit64(int i32_0, int i32_1) {
            this.i64 = 0;
            this.u64 = 0;
            this.i32_0 = i32_0;
            this.i32_1 = i32_1;
        }

        public static bool operator ==(Bit64 a, Bit64 b) {
            return a.i64 == b.i64;
        }

        public static bool operator !=(Bit64 a, Bit64 b) {
            return a.i64 != b.i64;
        }

        public static bool operator <(Bit64 a, Bit64 b) {
            return a.i64 < b.i64;
        }

        public static bool operator >(Bit64 a, Bit64 b) {
            return a.i64 > b.i64;
        }

        public override bool Equals(object obj) {
            return this == (Bit64)obj;
        }

        public override int GetHashCode() {
            return i32_0 ^ i32_1;
        }
    }
}