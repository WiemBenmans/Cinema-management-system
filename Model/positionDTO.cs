
using cinema.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

public class positionDTO {


    [Key]
    public int idPos { get; set; }
   
    public int ligne { get; set; }

    public int colonne { get; set; }
    public salleDTO? Salle { get; set; }
    public int SalleId { get; set; }

}