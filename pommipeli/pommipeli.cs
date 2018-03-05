/*https://github.com/jptsav/pommipeli */

using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

public class pommipeli : PhysicsGame
{

    Vector LiikutaVasen = new Vector(-200, 0);
    Vector LiikutaOikea = new Vector(200, 0);


    PhysicsObject pallo;
    PhysicsObject pelaaja;


    public override void Begin()
    {

        LuoKentta();
        AsetaOhjaimet();
        LuoPallot(30.0, 5);
        // Gravity = new Vector (0, -800);
        // pallo.Hit(kokeilu);



        /* Timer ajastin = new Timer();
        ajastin.Interval = 5.0;
        ajastin.Timeout += LuoPallot;
        ajastin.Start(); */


        // PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
    void LuoPallot(double koko, int lukuMaara)
    {
        for (int i = 0; i < lukuMaara; i++) // lukumäärä riippuu mistä? https://trac.cc.jyu.fi/projects/npo/wiki/AjastintenKaytto
        {
            pallo = new PhysicsObject(koko, koko, Shape.Circle);
            pallo.Y = Level.Top - 50;
            pallo.X = RandomGen.NextDouble(Level.Left, Level.Right); // tällaista mietin... tai pitäisi vaan jotenkin taikoa se nyt siihen.
            pallo.Color = Color.Black; // muista laittaa pelin tausta valkoiseksi!!! tai siniseksi whatever...
            Add(pallo);

            // pallo.Hit(); // tarvitseeko tää jotakin toteutusta? eli pallo laitetaan liikkelle. Push() instead?
            // https://trac.cc.jyu.fi/projects/npo/wiki/PainovoimanLisaaminen 
        }

        // return pallo; // vai pitääkö tallentaa johonkin taulukkoon ja sieltä sitten laukaista? kun tuota miten ne kaikki voisi muuten saada käyttöön? jos tähän tehdään toisenlainen toteutus...

        // https://trac.cc.jyu.fi/projects/npo/wiki/TormaysTarkistukset

    }

    void LuoKentta()
    { // tässä luodaan pelikenttä, eli annetaan siihen liittyvät parametrit...
      // pitää luoda ne rajat, että jos niihin törmätään, niin no go...
        Level.CreateBorders(1.0, false);
        Level.Background.Color = Color.White;
        Camera.ZoomToLevel();

        pelaaja = LuoPelaaja();

        // Gravity, borders!!!

    }

    PhysicsObject LuoPelaaja()
    { // vaihtoehtoisesti sisällytetään LuoKenttaan...


        pelaaja = new PhysicsObject(50.0, 15.0, Shape.Rectangle);
        pelaaja.Color = Color.Blue;
        pelaaja.X = Level.Left + 50;
        pelaaja.Y = Level.Bottom + 50;
        Add(pelaaja);
        return pelaaja;

    }


    void AsetaOhjaimet() // https://trac.cc.jyu.fi/projects/npo/wiki/OhjaintenLisaysB 
    {

        Keyboard.Listen(Key.A, ButtonState.Down, AsetaNopeus, "Pelaaja liikuta mailaa vasemmalle", pelaaja, LiikutaVasen);
        Keyboard.Listen(Key.D, ButtonState.Down, AsetaNopeus, "Pelaaja liikuta mailaa oikealle", pelaaja, LiikutaOikea);
    }

    void AsetaNopeus(PhysicsObject pelaaja, Vector nopeus)
    {
        pelaaja.Velocity = nopeus;
        // tai...

    }

    void KasitteleTormays(PhysicsObject pelaaja, PhysicsObject pallo)
    {


    }


}





