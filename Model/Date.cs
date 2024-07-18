
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

public class Date {

    public Date() {
    }
    [Key] 
    public int Id { get; set; }
    [Range(1, 31)]
    public int jour { get; set; }
    public enum Mois
    {
        Janvier = 1,
        Fevrier = 2,
        Mars = 3,
        Avril = 4,
        Mai = 5,
        Juin = 6,
        Juillet = 7,
        Aout = 8,
        Septembre = 9,
        Octobre = 10,
        Novembre = 11,
        Decembre = 12
    }
    public Mois mois { get; set; }
    [Range(1900, 2100)]
    public int année { get; set; }
    public string DateText => $"{jour}-{mois}-{année}";

}