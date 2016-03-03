using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Model
{
    public class IdentityCard
    {
        public string ProvinceCode { get; private set; }
        public string CityCode { get; private set; }
        public string CountyCode { get; private set; }
        public string BirthdayCode { get; private set; }
        public string PoliceStationCode { get; private set; }
        public string SexCode { get; private set; }
        public string CheckCode { get; private set; }

        public DateTime Birthday { get; private set; }
        /// <summary>
        /// 性别
        /// 1,男;2,女
        /// </summary>
        public int Sex { get; private set; }

        public static bool Check(string identityCard, out IdentityCard model)
        {
            model = null;
            //判断长度
            if (identityCard.Length != 15 || identityCard.Length != 18)
            {
                return false;
            }
            //判断0,1,2,3,4,5,6,7,8,9,x,X
            for (int i = 0; i < identityCard.Length; i++)
            {
                byte b = Convert.ToByte(identityCard[i]);
                if (i == 18)
                {
                    if (!(((b >= 48 && b <= 57) || b == 88 || b == 120)))
                    {
                        return false;
                    }
                }
                else if (!(b >= 48 && b <= 57))
                {
                    return false;
                }
            }
            if (identityCard.Length == 15)
            {
                model = new IdentityCard();
                model.ProvinceCode = identityCard.Substring(0, 2);
                model.CityCode = identityCard.Substring(2, 2);
                model.CountyCode = identityCard.Substring(4, 2);
                model.BirthdayCode = identityCard.Substring(6, 6);
                model.PoliceStationCode = identityCard.Substring(12, 2);
                model.SexCode = identityCard.Substring(14, 1);
                model.CheckCode = null;//15位,不存在该位

                DateTime defaultValue = new DateTime(1900, 1, 1);
                DateTime tempBirthday;
                if (DateTime.TryParse("19" + model.BirthdayCode, out tempBirthday) && tempBirthday >= defaultValue)
                {
                    model = null;
                    return false;
                }
                model.Birthday = tempBirthday;
                int sexCode = int.Parse(model.SexCode);
                if (sexCode % 2 == 1)
                {
                    model.Sex = 1;
                }
                else
                {
                    model.Sex = 2;
                }
            }
            else
            {
                model = new IdentityCard();
                model.ProvinceCode = identityCard.Substring(0, 2);
                model.CityCode = identityCard.Substring(2, 2);
                model.CountyCode = identityCard.Substring(4, 2);
                model.BirthdayCode = identityCard.Substring(6, 8);
                model.PoliceStationCode = identityCard.Substring(14, 2);
                model.SexCode = identityCard.Substring(16, 1);
                model.CheckCode = identityCard.Substring(17, 1).ToUpper();

                #region 校验位

                char[] Ai = identityCard.Remove(17).ToCharArray();               //Ai 表示第 i 位置上的身份证号码数字值
                string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');//Wi 表示第 i 位置上的加权因子
                string[] arrCheckCode = ("1,0,X,9,8,7,6,5,4,3,2").Split(',');    //校验位(R)
                int sum = 0;
                for (int i = 0; i < 17; i++)
                {
                    sum += int.Parse(Ai[i].ToString()) * int.Parse(Wi[i]);
                }
                int y = -1;
                Math.DivRem(sum, 11, out y);//Y = mod(S, 11)
                //Y   值： 0 1 2 3 4 5 6 7 8 9 10 
                //校验码： 1 0 X 9 8 7 6 5 4 3 2
                if (arrCheckCode[y] != model.CheckCode)
                {
                    model = null;
                    return false;
                }

                #endregion

                //生日
                DateTime defaultValue = new DateTime(1900, 1, 1);
                DateTime tempBirthday;
                if (!DateTime.TryParse(model.BirthdayCode, out tempBirthday) || tempBirthday < defaultValue)
                {
                    model = null;
                    return false;
                }
                model.Birthday = tempBirthday;
                //性别
                int sexCode = int.Parse(model.SexCode);
                if (sexCode % 2 == 1)
                {
                    model.Sex = 1;
                }
                else
                {
                    model.Sex = 2;
                }
            }
            return true;
        }
    }
}
