using System;

namespace ComparisonOfRefValues
{
    class Program
    {
        static void Main(string[] args)
        {
            int horsePower1 = 350;
            int horsePower2 = 350;

            bool valueTypeEquality = horsePower1 == horsePower2;

            Car car1 = new Car(horsePower1);
            Car car2 = new Car(horsePower2);

            bool referenceTypeEquality = car1 == car2;

            Console.WriteLine($"valueTypeEquiality: {valueTypeEquality}");
            Console.WriteLine($"referenceTypeEquality: {referenceTypeEquality}");

        }
    }

    class Car
    {
        public static bool operator ==(Car left, Car right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Car left, Car right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            if(obj == null)
            {
                return false;
            }
            if (this.GetType() != obj.GetType())
                return false;

            Car carObj = (Car)obj;

            return this.HorsePower == carObj.HorsePower;
        }

        public Car(int horsePower)
        {
            HorsePower = horsePower;
        } 
        public int HorsePower { get; set; }
    }
}
