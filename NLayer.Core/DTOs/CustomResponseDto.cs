using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
   public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        public List<String>Erorrs { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        //new oluştıurmak yerine statık metot olustur.bu metotlar gerıye yenı nesneler donsun succes falan.
        public static CustomResponseDto<T> Sucess (int StatusCode,T data)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode, Data = data,Erorrs=null };
        }

        public static CustomResponseDto<T> Sucess(int StatusCode )
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode };
        }
        public static CustomResponseDto<T> Fail(int statusCode ,List<string>erorrs)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode,Erorrs=erorrs };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Erorrs = new List<string> { error } };
        }

    }


   
}

