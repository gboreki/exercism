using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class LedgerEntry
{
   public LedgerEntry(DateTime date, string desc, float chg)
   {
       Date = date;
       Desc = desc;
       Change = chg;
   }

   public DateTime Date { get; }
   public string Desc { get; }
   public float Change { get; }

    public override string ToString()
    {
        return string.Format("{3}@{0}@{1}@{2}", Date, Desc, Change, Change >= 0);
    }
}

public static class Ledger
{
    private class LocaleSettings
    {
        public string HeadDescription { get; set; }
        public string DatePattern { get; set; }
        public int NegativePattern { get; set; }
    }

    private static Dictionary<string, LocaleSettings> localeSettings = new Dictionary<string, LocaleSettings>();

    static Ledger()
    {
        localeSettings.Add("en-US",
            new LocaleSettings
            {
                HeadDescription = "Date       | Description               | Change       ",
                DatePattern = "MM/dd/yyyy",
                NegativePattern = 0
            });

        localeSettings.Add("nl-NL",
             new LocaleSettings
            {
                HeadDescription = "Datum      | Omschrijving              | Verandering  ",
                DatePattern = "dd/MM/yyyy",
                NegativePattern = 12
            });
    }
    public static LedgerEntry CreateEntry(string date, string desc, int chng)
    {
        return new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0f);
    }

   private static CultureInfo CreateCulture(string cur, string loc)
   {
       var locale = localeSettings[loc];
       var culture = new CultureInfo(loc);
       culture.NumberFormat.CurrencySymbol = cur == "USD" ? "$" : "€"; ;
       culture.NumberFormat.CurrencyNegativePattern = locale.NegativePattern;
       culture.DateTimeFormat.ShortDatePattern = locale.DatePattern;
       return culture;
   }

   private static string Description(string desc)
   {
       if (desc.Length > 25)
       {
           var trunc = desc.Substring(0, 22);
           trunc += "...";
           return trunc;
       }

       return desc;
   }

   private static string Change(IFormatProvider culture, float cgh)
   {
       return cgh < 0.0 ? cgh.ToString("C", culture) : cgh.ToString("C", culture) + " ";
   }

   private static string PrintEntry(IFormatProvider culture, LedgerEntry entry)
   {
       var formatted = "";
        var date = entry.Date.ToString("d", culture);
       var description = Description(entry.Desc);
       var change = Change(culture, entry.Change);

       formatted += date;
       formatted += " | ";
       formatted += string.Format("{0,-25}", description);
       formatted += " | ";
       formatted += string.Format("{0,13}", change);

       return formatted;
   }

    private static void Validate(string currency, string loc)
    {
        if (!localeSettings.ContainsKey(loc) || (currency != "EUR" && currency != "USD"))
        {
            throw new ArgumentException("Invalid currency");
        }
    }

   public static string Format(string currency, string locale, LedgerEntry[] entries)
   {
       Validate(currency, locale);

       var formatted = new StringBuilder();
       formatted.Append(localeSettings[loc].HeadDescription);

       var culture = CreateCulture(currency, locale);

        foreach(var entry in entries.OrderBy(x => x.ToString()))
        {
            formatted.Append("\n");
            formatted.Append(PrintEntry(culture, entry));
        }

       return formatted.ToString();
   }
}
