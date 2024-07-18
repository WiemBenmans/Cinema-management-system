
using cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Planification {
    public int id { get; set; }
    public FilmDTO? Film { get; set; }
    public int? FilmId { get; set; }
    public salleDTO? Salle { get; set; }
    public int SalleId { get; set; }
    public Date? Date { get; set; }
    public int? IdDate { get; set; }
    public int? prixticket{ get; set; }
    public string planinfo =>  $"{FilmId}-{IdDate}-{SalleId}";
   


    public Planification() {
        
    }

}