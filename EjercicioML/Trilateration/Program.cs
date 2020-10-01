/*
 * This file is part of the Trilateration package.
 *
 *
 * Licensed under the MIT license:
 *   http://www.opensource.org/licenses/mit-license.php
 *
 * @author Matias Gutierrez <soporte@tbmsp.net>
 * @file Program.cs
 *
 * Project home:
 *   https://github.com/tbmsp/trilateration
 *
 */
using EjercicioML.Models;
using System;

namespace EjercicioML
{
     class Program
     {
        public Tuple<ModDataProvider, string> Get(double dist1, double dist2, double dist3)
        {
            Point p1 = new Point(-19.6685, -69.1942, dist1);
            Point p2 = new Point(-20.2705, -70.1311, dist2);
            Point p3 = new Point(-20.5656, -70.1807, dist3);
            double[] a = Trilateration.Compute(p1, p2, p3);
            Console.WriteLine("LatLon: " + a[0] + ", " + a[1]);

            ModDataProvider datos = new ModDataProvider();
            datos.message = "este es un mensaje secreto";
            Position post = new Position();
            post.x = a[0];
            post.y = a[1];
            datos.position = post;
            return new Tuple<ModDataProvider, string>(datos, string.Empty);

            

        }

        public Tuple<ModDataProvider, string> GetDetail(double dist1)
        {
            Point p1 = new Point(-19.6685, -69.1942, dist1);
            Point p2 = new Point(-20.2705, -70.1311, 100);
            Point p3 = new Point(-20.5656, -70.1807, 100);
            double[] a = Trilateration.Compute(p1, p2, p3);
            Console.WriteLine("LatLon: " + a[0] + ", " + a[1]);

            ModDataProvider datos = new ModDataProvider();
            datos.message = "este es un mensaje secreto";
            Position post = new Position();
            post.x = a[0];
            post.y = a[1];
            datos.position = post;
            return new Tuple<ModDataProvider, string>(datos, string.Empty);



        }

        public Tuple<ModDistance, string> GetDistance(double dist1)
        {
            Point p1 = new Point(-19.6685, -69.1942, dist1);
            Point p2 = new Point(-20.2705, -70.1311, 100);
            Point p3 = new Point(-20.5656, -70.1807, 100);
            double[] a = Trilateration.Compute(p1, p2, p3);
            Console.WriteLine("LatLon: " + a[0] + ", " + a[1]);

            ModDistance datos = new ModDistance();
            datos.x = a[0];
            datos.y = a[1];
            
            return new Tuple<ModDistance, string>(datos, string.Empty);



        }

    }
}