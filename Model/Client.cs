
using cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Client : userDTO {

    public Client() {
        Discriminator = "Client";
    }

   

}