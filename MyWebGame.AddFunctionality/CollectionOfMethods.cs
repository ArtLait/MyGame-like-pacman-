﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; 

namespace MyWebGam.AddFunctionality
{
    public class CollectionOfMethods
    { 
  
        public static string GetHashString(string s)  
            {  
              //переводим строку в байт-массим  
              byte[] bytes = Encoding.Unicode.GetBytes(s);  
  
              //создаем объект для получения средст шифрования  
              MD5CryptoServiceProvider CSP =  
                  new MD5CryptoServiceProvider();  
          
              //вычисляем хеш-представление в байтах  
              byte[] byteHash = CSP.ComputeHash(bytes);  
  
              string hash = string.Empty;  
  
              //формируем одну цельную строку из массива  
              foreach (byte b in byteHash)  
                  hash += string.Format("{0:x2}", b);  
  
              return hash;  
           }  
    }
}
