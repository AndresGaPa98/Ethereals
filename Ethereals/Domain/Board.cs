using System;
using System.ComponentModel.DataAnnotations;
namespace Scm.Domain{
    public class Board{
        public int BoardId { get; set; }
        public AppUser Player1 { get; set; }
        public AppUser Player2 { get; set; }
        public string Grid { get; set; }
        public AppUser Turno { get; set; }
        public int Status { get; set; }
    }
}