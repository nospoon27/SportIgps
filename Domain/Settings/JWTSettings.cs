using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Settings
{
    public class JWTSettings
    {
        /// <summary>
        /// Приватный ключ
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// Публичный ключ
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// Продолжительность жизни токена в минутах
        /// </summary>
        public int DurationInMinutes { get; set; }
    }
}
