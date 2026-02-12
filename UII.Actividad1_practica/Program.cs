using System;
using System.Collections.Generic;

namespace Practica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cantidadPersonas = SolicitarCantidadPersonas();

            List<string> nombres = new List<string>();
            List<int> edades = new List<int>();

            RegistrarPersonas(cantidadPersonas, nombres, edades);

            if (cantidadPersonas == 1)
            {
                MostrarCasoIndividual(nombres[0], edades[0]);
                return;
            }

            MostrarListaGeneral(nombres, edades);
            ClasificarYMostrar(nombres, edades);
        }



        static int SolicitarCantidadPersonas()
        {
            int cantidad;

            while (true)
            {
                Console.Write("Ingresa la cantidad de personas a clasificar: ");
                string entrada = Console.ReadLine();

                if (!int.TryParse(entrada, out cantidad) || cantidad < 1)
                {
                    Console.WriteLine("⚠ Dato no válido, vuelve a ingresar una cantidad mayor o igual a 1.\n");
                }
                else
                {
                    return cantidad;
                }
            }
        }

        static void RegistrarPersonas(int cantidad, List<string> nombres, List<int> edades)
        {
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"\nNombre de la persona {i + 1}: ");
                string nombre = Console.ReadLine();

                int edad = SolicitarEdad(nombre);

                nombres.Add(nombre);
                edades.Add(edad);
            }
        }

        static int SolicitarEdad(string nombre)
        {
            int edad;

            while (true)
            {
                Console.Write($"Edad de {nombre}: ");
                string entrada = Console.ReadLine();

                if (!int.TryParse(entrada, out edad))
                {
                    Console.WriteLine("⚠ Dato no válido, vuelve a ingresar una edad correcta.\n");
                }
                else
                {
                    return edad;
                }
            }
        }

        static void MostrarCasoIndividual(string nombre, int edad)
        {
            Console.WriteLine("\n--- RESULTADO ---");

            if (edad >= 18)
                Console.WriteLine($"{nombre} es mayor de edad.");
            else
                Console.WriteLine($"{nombre} es menor de edad.");
        }

        static void MostrarListaGeneral(List<string> nombres, List<int> edades)
        {
            Console.WriteLine("\n--- LISTA GENERAL ---");

            for (int i = 0; i < nombres.Count; i++)
            {
                Console.WriteLine($"{nombres[i]} - {edades[i]}");
            }
        }

        static void ClasificarYMostrar(List<string> nombres, List<int> edades)
        {
            List<string> mayores = new List<string>();
            List<int> edadesMayores = new List<int>();

            List<string> menores = new List<string>();
            List<int> edadesMenores = new List<int>();

            for (int i = 0; i < edades.Count; i++)
            {
                if (edades[i] >= 18)
                {
                    mayores.Add(nombres[i]);
                    edadesMayores.Add(edades[i]);
                }
                else
                {
                    menores.Add(nombres[i]);
                    edadesMenores.Add(edades[i]);
                }
            }

            if (mayores.Count > 0)
            {
                Console.WriteLine("\n--- MAYORES DE EDAD ---");

                for (int i = 0; i < mayores.Count; i++)
                {
                    Console.WriteLine($"{mayores[i]} - {edadesMayores[i]}");
                }
            }

            if (menores.Count > 0)
            {
                Console.WriteLine("\n--- MENORES DE EDAD ---");

                for (int i = 0; i < menores.Count; i++)
                {
                    Console.WriteLine($"{menores[i]} - {edadesMenores[i]}");
                }
            }
        }
    }
}