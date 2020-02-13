using System;
using System.ComponentModel.DataAnnotations;
namespace Scm.Controllers.Dtos{
    public class BoardRegisterDto{
        [Required]
        public string Player1Id { get; set; }
        [Required]
        public string Player2Id { get; set; }
    }
    public class BoardDto{
        public int BoardId { get; set; }
        public string Player1Id { get; set; }
        public string Player2Id { get; set; }
        public string Grid { get; set; }
        public string Turno { get; set; }
        public int Status { get; set; }
    }
}