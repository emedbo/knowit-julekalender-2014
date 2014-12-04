using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace Julekalender.Luker
{
    public class Luke4 : JulekalenderLukeBase<string>
    {
        public override string Solve()
        {
            var lowest = new Tuple<DateTime, double>(DateTime.MinValue, 0);
            var webRequest = WebRequest.Create(@"https://dl.dropboxusercontent.com/u/45621/kilma_data_blindern.txt");
            using (var response = webRequest.GetResponse())
            {
                using (var content = response.GetResponseStream())
                {
                    if (content == null)
                    {
                        return "FEIL";
                    }
                    using (var stream = new StreamReader(content))
                    {
                        for (int i = 0; i < 24; i++)
                        {
                            stream.ReadLine();
                        }
                        var lineOk = true;
                        var line = string.Empty;
                        
                        while (lineOk)
                        {
                            line = stream.ReadLine();
                            var split = line.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            DateTime date;

                            if (DateTime.TryParse(split[1], out date))
                            {
                                var temp = double.Parse(split[3], new CultureInfo("no"));
                                if (temp < lowest.Item2 && date.Month == 12)
                                {
                                    lowest = new Tuple<DateTime, double>(date, temp);
                                }
                            }
                            else
                            {
                                lineOk = false;
                            }
                        }
                    }

                }
            }
            return lowest.Item1.ToShortDateString();
        }

        protected override int GetNummer()
        {
            return 4;
        }
    }
}