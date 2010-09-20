namespace RedBadger.Xpf.Presentation
{
    using System;
    using System.Diagnostics;

    /// <summary>
    ///     A structure representing a Size that stores <see cref = "Width">Width</see> and <see cref = "Height">Height</see>.
    /// </summary>
    [DebuggerDisplay("{Width} x {Height}")]
    public struct Size : IEquatable<Size>
    {
        /// <summary>
        ///     A double-precision positive value for the Height of the <see cref = "Size">Size</see>.
        /// </summary>
        public double Height;

        /// <summary>
        ///     A double-precision positive value for the Width of the <see cref = "Size">Size</see>.
        /// </summary>
        public double Width;

        private static readonly Size empty = new Size
            {
               Width = double.NegativeInfinity, Height = double.NegativeInfinity 
            };

        /// <summary>
        ///     A structure representing a <see cref = "Width">Width</see> and <see cref = "Height">Height</see>.
        /// </summary>
        /// <param name = "width">The <see cref = "Width">Width</see> of the <see cref = "Size">Size</see>.</param>
        /// <param name = "height">The <see cref = "Height">Height</see> of the <see cref = "Size">Size</see>.</param>
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     An Empty <see cref = "Size">Size</see> with <see cref = "Width">Width</see> and <see cref = "Height">Height</see> of negative infinity.
        /// </summary>
        public static Size Empty
        {
            get
            {
                return empty;
            }
        }

        /// <summary>
        ///     Adds the <see cref = "Width">Width</see> and <see cref = "Height">Height</see> of a <see cref = "Size">Size</see> to those of another Size
        /// </summary>
        /// <param name = "value1">The first <see cref = "Size">Size</see></param>
        /// <param name = "value2">The second <see cref = "Size">Size</see></param>
        /// <returns>A <see cref = "Size">Size</see> whose <see cref = "Width">Width</see> and <see cref = "Height">Height</see> is the sum of the two Size structures supplied</returns>
        public static Size operator +(Size value1, Size value2)
        {
            return new Size(value1.Width + value2.Width, value1.Height + value2.Height);
        }

        /// <summary>
        ///     Compares two <see cref = "Size">Size</see> structs for equality in their <see cref = "Width">Width</see> and <see cref = "Height">Height</see>.
        /// </summary>
        /// <param name = "left">The first <see cref = "Size">Size</see> to compare.</param>
        /// <param name = "right">The second <see cref = "Size">Size</see> to compare.</param>
        /// <returns>Returns true if the two <see cref = "Size">Size</see> instances are equal.</returns>
        public static bool operator ==(Size left, Size right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Converts a <see cref = "Size">Size</see> into a <see cref = "Vector">Vector</see>
        /// </summary>
        /// <param name = "size">The input <see cref = "Size">Size</see></param>
        /// <returns>An equivalent <see cref = "Vector">Vector</see></returns>
        public static explicit operator Vector(Size size)
        {
            return new Vector(size.Width, size.Height);
        }

        /// <summary>
        ///     Converts a <see cref = "Size">Size</see> into a <see cref = "Point">Point</see>
        /// </summary>
        /// <param name = "size">The input <see cref = "Size">Size</see></param>
        /// <returns>An equivalent <see cref = "Point">Point</see></returns>
        public static explicit operator Point(Size size)
        {
            return new Point(size.Width, size.Height);
        }

        /// <summary>
        ///     Compares two <see cref = "Size">Size</see> structs for inequality in either their <see cref = "Width">Width</see> or their <see cref = "Height">Height</see>.
        /// </summary>
        /// <param name = "left">The first <see cref = "Size">Size</see> to compare.</param>
        /// <param name = "right">The second <see cref = "Size">Size</see> to compare.</param>
        /// <returns>Returns true if the two <see cref = "Size">Size</see> instances are not equal.</returns>
        public static bool operator !=(Size left, Size right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Subtracts the <see cref = "Width">Width</see> and <see cref = "Height">Height</see> of a <see cref = "Size">Size</see> from those of another Size
        /// </summary>
        /// <param name = "value1">The first <see cref = "Size">Size</see></param>
        /// <param name = "value2">The second <see cref = "Size">Size</see></param>
        /// <returns>A <see cref = "Size">Size</see> whose <see cref = "Width">Width</see> and <see cref = "Height">Height</see> is the difference of the two Size structures supplied</returns>
        public static Size operator -(Size value1, Size value2)
        {
            return new Size(value1.Width - value2.Width, value1.Height - value2.Height);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (obj.GetType() != typeof(Size))
            {
                return false;
            }

            return this.Equals((Size)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Width.GetHashCode() * 397) ^ this.Height.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("Width: {0}, Height: {1}", this.Width, this.Height);
        }

        public bool Equals(Size other)
        {
            return other.Width.Equals(this.Width) && other.Height.Equals(this.Height);
        }
    }
}