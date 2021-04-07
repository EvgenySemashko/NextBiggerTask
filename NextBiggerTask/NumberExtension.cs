using System;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace NextBiggerTask
{
    public static class NumberExtension
    {
        /// <summary>
        /// Finds the nearest largest integer consisting of the digits of the given positive integer number and null if no such number exists.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        /// The nearest largest integer consisting of the digits  of the given positive integer and null if no such number exists.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when source number is less than 0.</exception>
        public static int? NextBiggerThan(int number)
        {
            var nums = number.ToString(CultureInfo.InvariantCulture).ToCharArray();

            if (number < 0 || number == int.MinValue)
            {
                throw new ArgumentException($"Value of {nameof(number)} cannot be less zero.");
            }
            else if (number == int.MaxValue)
            {
                return null;
            }

            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i - 1] < nums[i])
                {
                    int temp = nums[i];
                    nums[i] = nums[i - 1];
                    nums[i - 1] = (char)temp;

                    for (int k = i; k < nums.Length - 1; k++)
                    {
                        for (int j = k + 1; j < nums.Length; j++)
                        {
                            if (nums[k] > nums[j])
                            {
                                int t = nums[k];
                                nums[k] = nums[j];
                                nums[j] = (char)t;
                            }
                        }
                    }

                    return int.Parse(nums);
                }
            }

            return null;
        }
    }
}
