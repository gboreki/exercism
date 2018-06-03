using System;
using System.Linq;
using System.Collections.Generic;

//10:46
public static class VariableLengthQuantity
{
    static uint byteUsedMask = 0x80;
    static uint sevenBitMask = 0x7F;

    public static uint[] Encode(uint[] numbers)
    {
        List<uint> list = new List<uint>();
        for (int i = 0; i < numbers.Length; i++)
        {
            // Acumulate bytes of one number, this will have the 'last bit' marked appropriately
            LinkedList<uint> currentNumber = new LinkedList<uint>();
            uint number = numbers[i];
            if (number == 0)
            {
                list.Add(0);
            }
            else
            {
                while (number > 0)
                {
                    // get the 7 bits
                    uint value = number & sevenBitMask;

                    // Add to list and mark the first bit to indicate its used
                    currentNumber.AddFirst(value | byteUsedMask);
                    number >>= 7;
                }

                // Now we need to uncheck the bit of the last number in the sequence
                if (currentNumber.Any())
                {
                    var last = currentNumber.Last();
                    currentNumber.RemoveLast();
                    last &= sevenBitMask;
                    currentNumber.AddLast(last);
                }

                //  Add to the final list
                list.AddRange(currentNumber);
            }
        }
        return list.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        LinkedList<uint> result = new LinkedList<uint>();
        int i = 0;
        uint currentNumber = 0;
        bool isLastNumber = false;
        while (i < bytes.Length)
        {
            var currentByte = bytes[i];

            // Check if is last number based on the state of the most relevant bit
            isLastNumber = (currentByte & byteUsedMask) == 0;

            // get the value of the 7-bit 
            currentByte &= sevenBitMask;

            // shift 7 bits left to make space
            currentNumber <<= 7;

            // add the number

            currentNumber |= currentByte;
            i++;
            if (isLastNumber)
            {
                result.AddLast(currentNumber);
                currentNumber = 0;
            }
        }

        // If the final number did'nt have the bit unset, the input was corrupt
        if (!isLastNumber)
            throw new InvalidOperationException();

        return result.ToArray();

    }
}