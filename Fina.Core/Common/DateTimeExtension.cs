namespace Fina.Core.Common;

// Vamos criar a função DateTime.FirstDate através do Extension Methods
public static class DateTimeExtension
{
    public static DateTime GetFirstDay(this DateTime date, int? year = null, int? month = null)
        => new(year ?? date.Year, month ?? date.Month, 1);

    // "year ??" é Operador de Coalescência Nula em C# onde eu posso ou não passar o ano, se eu não passar, o programa pega o ano atual do objeto date


    public static DateTime GetLastDay(this DateTime date, int? year = null, int? month = null)
       => new DateTime(
               year ?? date.Year,
               month ?? date.Month,
               1)
           .AddMonths(1)
           .AddDays(-1);

}
