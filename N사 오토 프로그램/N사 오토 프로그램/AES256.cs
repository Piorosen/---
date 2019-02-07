using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace 암호화
{
    public class Cry
    {
        public String Key = "?xpacket end='w'?>? C#%'%#//33//@@@@@@@@@@@@@@@? C&&0##0+.'''.+550055@@?@@@@@@@@@@@@? @? ?           	? ? 3 !1AQaq?몼켃#$R햍34r귂C%뭆趙?s5∑?D밫dE짙t6??祉꽸?身F'뵥뀾빫竇處돼呂?fv넆╋팻念7GWgw뇳㎎항惡?          ? ? 5 !1AQaq2걨”B#핾蘭3$b?굮CScs4?∑?&5쫘D밫?dEU6te蕣퀎촨u身F뵥뀾빫竇處돼呂?fv넆╋팻念'7GWgw뇳㎎??   ? 肅t?叭8? 뽐꾱1뷅쌖뭃?^?6?잡R?헸1쭅첇窯@껂굫?O뎁p&S?[`H괬誓봗뙨??d?ㄶ;S?C??ILv6S??쾃	Iv랺냵 ?%+h?텱킑R섷Km	??8K옥%(?믖紗杭%?0뮇粕붳?(?RB? J?3?JJP 뵅? ??!%0 ? 궺쬴 :>늃2^U9|鶩-?걡3LqUM? 퉘뼌하鎬D?7톞U[od侄n슕m餘I???	역!랫!?0멐5";
        public String AESEncrypt256(String InputText)
        {
            string Password = Key;

            RijndaelManaged RijndaelCipher = new RijndaelManaged();

            // 입력받은 문자열을 바이트 배열로 변환  
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);

            // 딕셔너리 공격을 대비해서 키를 더 풀기 어렵게 만들기 위해서   
            // Salt를 사용한다.  
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);

            // Create a encryptor from the existing SecretKey bytes.  
            // encryptor 객체를 SecretKey로부터 만든다.  
            // Secret Key에는 32바이트  
            // Initialization Vector로 16바이트를 사용  
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));

            MemoryStream memoryStream = new MemoryStream();

            // CryptoStream객체를 암호화된 데이터를 쓰기 위한 용도로 선언  
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);

            cryptoStream.Write(PlainText, 0, PlainText.Length);

            cryptoStream.FlushFinalBlock();

            byte[] CipherBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            string EncryptedData = Convert.ToBase64String(CipherBytes);

            return EncryptedData;
        }

        //AES_256 복호화  
        public String AESDecrypt256(String InputText)
        {
            string Password = Key;

            RijndaelManaged RijndaelCipher = new RijndaelManaged();

            byte[] EncryptedData = Convert.FromBase64String(InputText);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);

            // Decryptor 객체를 만든다.  
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));

            MemoryStream memoryStream = new MemoryStream(EncryptedData);

            // 데이터 읽기 용도의 cryptoStream객체  
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);

            // 복호화된 데이터를 담을 바이트 배열을 선언한다.  
            byte[] PlainText = new byte[EncryptedData.Length];

            int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);

            memoryStream.Close();
            cryptoStream.Close();

            string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);

            return DecryptedData;
        }
    }
}
