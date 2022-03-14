using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLab
{
    public class WhereLab
    {
        private static IEnumerable<Sample> Source { get; set; }
        public WhereLab()
        {
            Source = new SampleDate().GetData();
        }
        public List<Sample> 搜尋Id大於8的資料()
        {
            var result = new List<Sample>();
            result = Source.Where(x => x.Id > 8).ToList();
            return result;
        }

        public List<Sample> 搜尋Price等於200的資料()
        {
            var result = new List<Sample>();
            result = Source.Where(x => x.Price == 200).ToList();
            return result;
        }

        public List<Sample> 搜尋UserName開頭為d的資料()
        {
            var result = new List<Sample>();
            result = Source.Where(x => x.UserName.StartsWith("d")).ToList();
            return result;
        }

        public List<Sample> 搜尋UserName包含e的資料()
        {
            var result = new List<Sample>();
            result = Source.Where(x => x.UserName.Contains("e")).ToList();
            return result;
        }

        public List<Sample> 搜尋UserName結尾為o的資料()
        {
            var result = new List<Sample>();
            result = Source.Where(x => x.UserName.EndsWith("o")).ToList();
            return result;
        }

        public List<Sample> 搜尋UserName是demo和joey的資料()
        {
            var whereStr = new[] {"demo","joey" };
            var result = new List<Sample>();
            result = Source.Where(x => whereStr.Contains(x.UserName)).ToList();
            return result;
        }

        public bool 判斷是否有Id等於99的資料()
        {
            var result = true;
            result = Source.Where(x => x.Id == 99).Any();
            return result;
        }


        public int SumOfPriceOfOneUser(string username)
        {
            var result = 0;
            result = Source.Where(x => x.UserName == username).Select(j => j.Price).Sum();
            return result;
        }

        public List<Sample> SampleFromYearMonth(DateTime dateTime)
        {
            var result = new List<Sample>();
            result = Source.Where(x => x.CreateTime.Year == dateTime.Year && x.CreateTime.Month == dateTime.Month).ToList();
            return result;
        }

        public int NumberOfSampleWithIn30Days(DateTime dateTime)
        {
            var result = 0;
            result = Source.Where(x => Math.Abs((x.CreateTime - dateTime).TotalDays) < 30).Count();
            return result;
        }

        public int NumberOfPeopleHaveItem(int itemId)
        {
            var result = 0;
            result = Source.Where(x => x.Item.Contains(itemId)).Select(j => j.UserName).Distinct().Count();
            return result;
        }
    }
}
