using System;

namespace Logic
{
    public struct Turn
    {
        public (int Row, int Column) Coordinates { get; set; }

        public Turn((int, int) i_Coordinates)
        {
            Coordinates = i_Coordinates;
        }

        public override bool Equals(object obj)
        {
            bool isEqual = base.Equals(obj);

            if (obj is Turn)
            {
                Turn other = (Turn) obj;
                isEqual = other.Coordinates == Coordinates;
            }

            return isEqual;
        }
    }
}
