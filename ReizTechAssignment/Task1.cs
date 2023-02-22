using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ReizTechAssignment
{
    internal static class Task1
    {
        public static void GetAngleInBetween()
        
        {
            int hourNum;
            int minuteNum;

            Console.WriteLine("Please give clock regarding data: ");
            for (; ; )
            {
                try
                {
                    Console.WriteLine("\nHour (from 0-12): ");
                    hourNum = Convert.ToInt32(Console.ReadLine());

                    if (hourNum < 0 || hourNum > 12)
                    {
                        Console.WriteLine("Please input the number in range");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please input the data in correct format");
                }
            }

            for (; ; )
            {
                try
                {
                    Console.WriteLine("\nMinute (from 0-60): ");
                    minuteNum = Convert.ToInt32(Console.ReadLine());

                    if (hourNum < 0 || hourNum > 60)
                    {
                        Console.WriteLine("Please input the number in range");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please input the data in correct format");
                }
            }
            double[] clockArrowAngles = GetSeparateArrowPositions(hourNum, minuteNum);

            double hourAngle = clockArrowAngles[0];
            double minuteAngle = clockArrowAngles[1];
            double differenceBetweenAngles;

            if (hourAngle >= minuteAngle)
            {
                Console.WriteLine("The angle between Hour arrow and Minute arrow is: ");
                differenceBetweenAngles = hourAngle - minuteAngle;

                Console.WriteLine($"Clockwise: {differenceBetweenAngles}\nCounter clockwise: {360 - differenceBetweenAngles}");
            }
            else
            {
                Console.WriteLine("The angle between Minute arrow and Hour arrow is: ");
                differenceBetweenAngles = minuteAngle - hourAngle;

                Console.WriteLine($"Clockwise: {differenceBetweenAngles}\nCounter clockwise: {360 - differenceBetweenAngles}");
            }
        }

        static double[] GetSeparateArrowPositions(int hour, int minute)
        {
            double hourArrowAngle;
            double minuteArrowAngle;
            const double HourDegreeConst = 360 / 12;
            const double MinuteDegreeConst = 360 / 60;

            hourArrowAngle = hour * HourDegreeConst + minute * (HourDegreeConst / 60);
            minuteArrowAngle = minute * MinuteDegreeConst;

            if (hourArrowAngle >= 360) { hourArrowAngle -= 360; }
            if (minuteArrowAngle >= 360) { minuteArrowAngle -= 360; }

            double[] result = { hourArrowAngle, minuteArrowAngle };
            return result;
        }
    }
}
