using System;
using System.Linq;

public class PhoneNumber
{
    //9:48-10:18
    public static string Clean(string phoneNumber)
    {
        char[] valie = { '.', ' ', '-','+', '(', ')' };

        if (!string.IsNullOrEmpty(phoneNumber) && phoneNumber.All(p => char.IsNumber(p) || valie.Contains(p)))
        {
            int max = IsInternational(phoneNumber) ? 11 : 10;

            var phone = new string(phoneNumber.TrimStart('+').TrimStart('1').Where(p => char.IsNumber(p)).ToArray());
            if (phone.Length >9  && phone.Length <=max && IsValidArea(phone) && IsValidExchange(phoneNumber))
                return phone;
        }
        throw new ArgumentException("You need to implement this function.");
    }

    private static bool IsInternational(string phoneNumber)
    {
        return (phoneNumber.StartsWith('+') || phoneNumber.StartsWith('1'));
    }

    private static bool IsValidArea(string phoneNumber)
    {
        return !phoneNumber.StartsWith('1');
    }

    private static bool IsValidExchange(string phoneNumber)
    {
        if (phoneNumber.Contains(')'))
            return phoneNumber.SkipWhile(p => p != ')').SkipWhile(p => !char.IsNumber(p)).First() > '1';

        return true;
    }

}