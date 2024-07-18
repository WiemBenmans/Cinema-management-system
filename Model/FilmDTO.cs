
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
namespace cinema.Model{ 

public class FilmDTO {


        [Key]
        public int idFilm { get; set; }

    public String? nom { get; set; }

    public String? categorie { get; set; }
        public FilmDTO() { }
        public FilmDTO(int idFilm, string nom, string categorie)
        {
            this.idFilm = idFilm;
            this.nom = nom;
            this.categorie = categorie;
        }
        public string NomCategorie => $"{nom} ({categorie})";



    }
}