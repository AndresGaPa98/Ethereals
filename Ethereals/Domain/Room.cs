using System;
using System.ComponentModel.DataAnnotations;
namespace Scm.Domain{
    public class Room{
        public int RoomId { get; set; }
        public AppUser Player1 { get; set; }
        public AppUser Player2 { get; set; }
        public Board Board { get; set; }
        public int Status {get; set;}
    }
}