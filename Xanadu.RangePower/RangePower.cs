using System;

namespace Xanadu
{
    /// <summary>
    /// 与えられた変域内での指数演算によって値の増減を制御します。
    /// </summary>
    public sealed class RangePower
    {
        /// <summary>
        /// 基底部を取得します。
        /// </summary>
        public double Base { get; }

        /// <summary>
        /// 値の変域の最小値を取得します。
        /// </summary>
        public double MinValue { get; }

        /// <summary>
        /// 値の変域の最大値を取得します。
        /// </summary>
        public double MaxValue { get; }

        /// <summary>
        /// <see cref="RangePower"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="basePart">基底部。</param>
        /// <param name="minValue">値の変域の最小値。</param>
        /// <param name="maxValue">値の変域の最大値。</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public RangePower(double basePart, double minValue, double maxValue)
        {
            if (double.IsNaN(basePart) | double.IsInfinity(basePart))
                throw new ArgumentOutOfRangeException(nameof(basePart));

            if (double.IsNaN(minValue) | double.IsInfinity(minValue))
                throw new ArgumentOutOfRangeException(nameof(minValue));

            if (double.IsNaN(maxValue) | double.IsInfinity(maxValue))
                throw new ArgumentOutOfRangeException(nameof(maxValue));

            if (basePart < minValue | basePart > maxValue)
                throw new ArgumentOutOfRangeException(nameof(basePart));

            Base = basePart;
            MinValue = minValue;
            MaxValue = maxValue;
            Exponent = 1;
        }

        /// <summary>
        /// 値が変更された場合に発生します。
        /// </summary>
        public event EventHandler ValueChanged;

        double _value;
        /// <summary>
        /// 現在の値を取得します。
        /// </summary>
        public double Value
        {
            get { return _value; }
            private set
            {
                _value = value;

                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        int _exponent;
        /// <summary>
        /// 指数部を取得または設定します。
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int Exponent
        {
            get { return _exponent; }
            set
            {
                var newValue = Math.Pow(Base, value);

                if (MinValue <= newValue & newValue <= MaxValue)
                {
                    _exponent = value;

                    Value = newValue;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        /// <summary>
        /// 指数部を 1 増加させることが出来るかどうかを取得します。
        /// </summary>
        public bool CanUp => Math.Pow(Base, Exponent + 1) <= MaxValue;

        /// <summary>
        /// 指数部を 1 減少させることが出来るかどうかを取得します。
        /// </summary>
        public bool CanDown => Math.Pow(Base, Exponent - 1) >= MinValue;

        /// <summary>
        /// 指数部を 0 に設定することが出来るかどうかを取得します。
        /// </summary>
        public bool CanZero => MinValue <= 1 & 1 <= MaxValue;

        /// <summary>
        /// 指数部を 1 増加させます。
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public void Up()
        {
            if (!CanUp) throw new InvalidOperationException();

            Exponent++;
        }

        /// <summary>
        /// 指数部を 1 減少させます。
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public void Down()
        {
            if (!CanDown) throw new InvalidOperationException();

            Exponent--;
        }

        /// <summary>
        /// 指数部を 0 に設定します。
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Zero()
        {
            if (!CanZero) throw new InvalidOperationException();

            Exponent = 0;
        }

        /// <summary>
        /// 指定された値に最も近くなるように指数部を設定します。
        /// </summary>
        /// <param name="value"></param>
        public void Approximate(double value)
        {
            int approximate(double v)
            {
                var newExponent = (int)Math.Round(Math.Log(v, Base), 0);

                var newValue = Math.Pow(Base, newExponent);

                if (newValue < MinValue)
                {
                    return (int)Math.Ceiling(Math.Log(MinValue, Base));
                }
                else if (newValue > MaxValue)
                {
                    return (int)Math.Floor(Math.Log(MaxValue, Base));
                }
                else
                {
                    return newExponent;
                }
            }

            Exponent = approximate(value);
        }
    }
}