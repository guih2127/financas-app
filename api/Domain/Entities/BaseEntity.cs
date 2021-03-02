using System;

namespace api.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public StatusEnum Status { get; set; }
    }
}