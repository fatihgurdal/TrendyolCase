using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.Enums
{
    public enum ErrorType
    {
        /// <summary>
        /// Kritik kırmızı
        /// </summary>
        Critical = 0,
        /// <summary>
        /// Validation
        /// </summary>
        Validation = 1,
        /// <summary>
        /// Uyarı
        /// </summary>
        Warning = 2,
        /// <summary>
        /// Uyarı
        /// </summary>
        Info = 3
    }
}
