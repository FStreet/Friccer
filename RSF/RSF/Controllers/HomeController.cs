﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSF.Models;
using RSF.Models.DataAccess;

namespace RSF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registracion()
        {
            return View();
        }
        public ActionResult Equipo()
        {
            return View();
        }
        public ActionResult Cancha()
        {
            return View();
        }
        public ActionResult Logueado()
        {
            return View();
        }
        public ActionResult CrearEquipo3()
        {
            return View("CrearEquipo");
        }
        public ActionResult Endesarrollo()
        {
            return View("Endesarrollo");
        }
        public ActionResult EliminarEquipo3()
        {
            return View("EliminarEquipo");
        }

        public ActionResult LoguearJugador(Jugador unJugador)
        {
            Jugador Jugadordevuelto = Jugadores.TraerUnJugador(unJugador);
            if (Jugadordevuelto.id > 0)
            {
                return View("Logueado");
            }
            else
            {
                ViewBag.A = "No se encontro al Jugador";
                return View("Index");
            }
        }
        public ActionResult Registrar(Jugador unJugador)
        {
            if (unJugador.contraseña == unJugador.Confcontraseña)
            {
                bool jugadorGuardado = Jugadores.AgregarUnJugador(unJugador);
                if (jugadorGuardado)
                {
                    return View("Index");
                }
                else
                {
                    ViewBag.Error = "Error en la registracion";
                    return View("Registracion");
                }
            }
            else
            {
                ViewBag.Error = "Error en la contraseña";
                return View("Registracion");
            }
        }
        public ActionResult BuscarJugador(Jugador unJugador)
        {
            if (unJugador.id > 0)
            {
                Jugador Jugadordevuelto = Jugadores.TraerUnJugador(unJugador);
                if (Jugadordevuelto.id > 0)
                {
                    ViewBag.A = Jugadordevuelto;
                    return View("PerfilJugador");
                }
                else
                {
                    ViewBag.Error = "No funciono";
                    return View("Logueado");
                }
            }
            else
            {
                List<Jugador> ListadeJugadores = Jugadores.TraerJugadores(unJugador);
                if (ListadeJugadores.Count > 0)
                {
                    ViewBag.A = ListadeJugadores;
                    return View("Jugadores");
                }
                else
                {
                    ViewBag.Error = "No funciono";
                    return View("Logueado");
                }
            }   
        }
        public ActionResult ModificarJugador(Jugador unJugador)
        {
            bool funciono = Jugadores.ModificarUnJugador(unJugador);
            if (funciono)
            {
                return View("Logueado");
            }
            else
            {
                return View("PerfilJugador");
            }
        }
        public ActionResult EliminarJugador(int A)
        {
            bool Funciono = Jugadores.EliminarUnJugador(A);
            if (Funciono)
            {
                return View("Index");
            }
            else
            {
                return View("Logueado");
            }
        }

        public ActionResult AgregarCancha(Cancha unaCancha)
        {
            bool canchaagregada = Canchas.AgregarUnaCancha(unaCancha);
            if (canchaagregada)
            {
                return View("Logueado");
            }
            else
            {
                ViewBag.Funciono = "Error en la registracion";
                return View("Cancha");
            }
        }
        public ActionResult BuscarCanchas(Cancha unaCancha)
        {
            if (unaCancha.id > 0)
            {
                Cancha unaCancha2 = Canchas.TraerUnaCancha(unaCancha);
                if (unaCancha2.id > 0)
                {
                    ViewBag.A = unaCancha2;
                    return View("PerfilCancha");
                }
                else
                {
                    ViewBag.Error = "No se pudo";
                    return View("Cancha");
                }
            }
            else
            {
                List<Cancha> ListadeCanchas = Canchas.TraerCanchas(unaCancha);
                if (ListadeCanchas.Count > 0)
                {
                    ViewBag.A = ListadeCanchas;
                    return View("Canchas");
                }
                else
                {
                    return View("Cancha");
                }
            }                        
        }
        public ActionResult ModificarCancha(Cancha unaCancha)
        {
            bool funciono = Canchas.ModificarUnaCancha(unaCancha);
            return View("Logueado");
        }
        public ActionResult EliminarCancha(int A)
        {
            bool Funciono = Canchas.EliminarUnaCancha(A);
            if (Funciono)
            {
                return View("Logueado");
            }
            else
            {
                return View("Logueado");
            }
        }

        public ActionResult CrearEquipo(Equipo unEquipo)
        {
            bool equipoagregado = Equipos.AgregarUnEquipo(unEquipo);
            if (equipoagregado)
            {
                return View("CrearEquipo");
            }
            else
            {
                ViewBag.Funciono = "Error en la registracion";
                return View("Logueado");
            }
        }
        public ActionResult CrearEquipo2(EquipoJugador unEquipo)
        {
            bool equipoagregado = EquiposJugadores.Agregar(unEquipo);
            if (equipoagregado)
            {
                return View("Logueado");
            }
            else
            {
                ViewBag.Funciono = "Error en la registracion";
                return View("Logueado");
            }
        }
        public ActionResult BuscarEquipos(Equipo unequipo)
        {
            if (unequipo.id > 0)
            {
                Equipo unequipo2 = Equipos.TraerUnEquipo(unequipo);
                if (unequipo2.id > 0)
                {
                    ViewBag.A = unequipo2;
                    return View("PerfilEquipo");
                }
                else
                {
                    ViewBag.Error = "No se pudo";
                    return View("Equipo");
                }
            }
            else
            {
                List<Equipo> ListadeEquipos = Equipos.TraerEquipos(unequipo);
                if (ListadeEquipos.Count > 0)
                {
                    ViewBag.A = ListadeEquipos;
                    return View("Equipos");
                }
                else
                {
                    return View("Equipo");
                }
            }
        }
        public ActionResult ModificarEquipo(Equipo unEquipo)
        {
            bool funciono = Equipos.ModificarUnEquipo(unEquipo);
            return View("Logueado");

        }
        public ActionResult EliminarEquipo(int A)
        {
            bool Funciono = Equipos.EliminarUnEquipo(A);
            bool Funcionob = EquiposJugadores.EliminarEquipo(A);
            if (Funciono)
            {
                return View("Logueado");
            }
            else
            {
                return View("Logueado");
            }
        }
        public ActionResult VerPlantel(int A)
        {
            EquipoJugador B = new EquipoJugador();
            B.idEquipo = A;
            List<int> Lista = EquiposJugadores.TraerJugadores(B);
            if (Lista.Count > 0)
            {
                List<Jugador> W = new List<Jugador>();
                foreach (int J in Lista)
                {
                    Jugador m = new Jugador();
                    m.id = J;
                    m = Jugadores.TraerUnJugador(m);
                    W.Add(m);
                }
                ViewBag.A = W;
                return View("Plantel");
            }
            else
            {
                return View("Logueado");
            }
        }
        public ActionResult EliminarEquipo2(EquipoJugador jugador)
        {
            jugador = EquiposJugadores.Traer(jugador);
            bool funciono = EquiposJugadores.Eliminar(jugador.id);
            return View("Logueado");
        }
    }
}