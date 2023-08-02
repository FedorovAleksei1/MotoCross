using System;

namespace MotoCross.Json
{
    public enum JsonResponseStatuses
    {
        Ok = 0,
        Error = 1,
        NotFound = 3,
        NotPrice = 4,
    }

    /// <summary>
    /// 
    /// </summary>
    public class JsonResponse
    {

        /// <summary>
        /// статус обработки запроса
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// сообщение обработки запроса
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// возвращаемые данные
        /// </summary>
        public object data { get; set; }
    }
}
