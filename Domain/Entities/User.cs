using Domain.Common;
using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        /// <summary>
        /// Внешний ключ таблицы CountryCode - код страны
        /// </summary>
        public int CountryCodeId { get; set; }

        /// <summary>
        /// Код страны
        /// </summary>
        public CountryCode CountryCode { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        /// <summary>
        /// Роль - пользователь
        /// </summary>
        [JsonIgnore]
        public IList<UserRole> UserRoles { get; set; }

        public object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Токены обновления
        /// </summary>
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }

        [JsonIgnore]
        public IList<WorkoutGroupClient> WorkoutGroupClients { get; set; }

        /// <summary>
        /// Биография
        /// </summary>
        public string Biography { get; set; }
    }
}
