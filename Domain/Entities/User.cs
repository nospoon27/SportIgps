using Domain.Common;
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

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Внешний ключ таблицы Gender - пол
        /// </summary>
        public int GenderId { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Внешний ключ таблицы CountryCode - код страны
        /// </summary>
        public int CountryCodeId { get; set; }

        /// <summary>
        /// Код страны
        /// </summary>
        public CountryCode CountryCode { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Роль - пользователь
        /// </summary>
        [JsonIgnore]
        public ICollection<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Токены обновления
        /// </summary>
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }

        /// <summary>
        /// Специализации тренера по спорту
        /// </summary>
        [JsonIgnore]
        public ICollection<TrainerSpecialization> TrainerSpecialization { get; set; }

        /// <summary>
        /// Биография
        /// </summary>
        public string Biography { get; set; }
    }
}
