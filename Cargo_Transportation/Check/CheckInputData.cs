using Cargo_Transportation.DIHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cargo_Transportation.Check
{
    public static class     CheckInputData
    {
        public static bool  CheckNotEmptyString(string _string)
        {
            if (_string == "")
                return false;
            else
                return true;
        }
        public static bool  CheckLatin(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!IsAlpha(str[i]) && !IsNumber(str[i]) && !IsSpecialSymbol(str[i]))
                    return false;
            }
            return true;
        }
        private static bool PasswordLength(string pass)
        {
            if (pass.Length < 7 && pass.Length > 15)
                return false;
            else
                return true;
        }
        private static bool PasswordDigits(string pass)
        {
            int counter = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] >= '0' && pass[i] <= '9')
                    counter++;
            }
            if (counter >= 2)
                return true;
            else
                return false;
        }
        private static bool PasswordSpecialSymbols(string pass)
        {
            int _counter = 0;
            char[] specialSymbols = { '!', '@', '#', '$', '%', '&', '*' };
            for (int i = 0; i < specialSymbols.Length; i++)
            {
                for (int j = 0; j < pass.Length; j++)
                {
                    if (pass[j] == specialSymbols[i])
                        _counter++;
                }
            }
            if (_counter >= 2)
                return true;
            else
                return false;
        }
        public static bool  PasswordCheck(string pass)
        {
            if (PasswordLength(pass) && PasswordDigits(pass) && PasswordSpecialSymbols(pass))
                return true;
            else
                return false;
        }
        public static bool  LoginCheck(string login)
        {
            List<string> logins = IoC.Application_Work.All_Users.Select(l => l.Login).ToList();
            for (int i = 0; i < logins.Count; i++)
            {
                if (login == logins[i])
                    return false;
            }
            return true;
        }
        public static bool  EmailCheck(string email)
        {
            string cond = "^[a-zA-Z0-9_.+-]+@[a-zA-Z_]+.[a-zA-Z_.]+$";
            if (Regex.IsMatch(email, cond))
                return true;
            else
                return false;
        }
        public static bool  NumberCheck(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!Char.IsDigit(number[i]))
                    return false;
            }
            return true;
        }
        public static bool  CostCheck(string cost)
        {
            try
            {
                int nbr = int.Parse(cost);
                if (nbr < 500 || nbr > 500000)
                    return false;
                else
                    return true;
            }
            catch (Exception EX)
            {
                IoC.UI.CommunicationDialog(new Cargo_Transportation.Dialog.MessageBoxDialogViewModel { Message = EX.Message, Title = "Ошибка" });
                return (false);
            }
        }
        public static bool  PhoneCheck(string phone)
        {
            if (phone.Count() != 11)
                return (false);
            return true;
        }
        public static bool  IsAlpha(char ch) => (ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z');
        public static bool  IsNumber(char ch) => (ch >= '0' && ch <= '9');
        public static bool  IsSpecialSymbol(char ch) => (ch == '!' || ch == '@' || ch == '#' || ch == '$' ||
                                                        ch == '%' || ch == '&' || ch == '*' || ch == '.');
    }
}

