using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegaDonLucas
{
    class Program
    {
        static void Registrar(ref int cantidad, ref double caja, string producto, bool esVenta)
        {
            Console.WriteLine($"================================\nRegistrar {(esVenta ? "venta" : "devolución")} de {producto}\n================================");
            Console.Write("Ingrese cantidad (unidades): ");
            int unidades = int.Parse(Console.ReadLine());
            Console.Write("Ingrese precio: S/ ");
            double precio = double.Parse(Console.ReadLine());
            double total = unidades * precio;

            if (esVenta)
            {
                caja += total;
                cantidad += unidades;
            }
            else
            {
                caja -= total;
                cantidad -= unidades;
            }

            Console.WriteLine($"================================\n{(esVenta ? "Se han ingresado" : "Se han regresado")} {unidades} unidades");
            Console.WriteLine($"{(esVenta ? "Se han ingresado" : "Se han devuelto")} S/ {total} {(esVenta ? "a" : "de")} caja");
            Console.WriteLine($"================================");
            Console.WriteLine($"1: {(esVenta ? "Registrar más productos de" : "Devolver más productos de")} {producto}\n2: <- Regresar");
            Console.Write("Ingrese una opción: ");
        }

        static void Main()
        {
            double caja = 0, cajaLimpieza = 0, cajaAbarrotes = 0, cajaGolosinas = 0, cajaElectro = 0;
            int vendidosLimpieza = 0, devueltosLimpieza = 0;
            int vendidosAbarrotes = 0, devueltosAbarrotes = 0;
            int vendidosGolosinas = 0, devueltosGolosinas = 0;
            int vendidosElectro = 0, devueltosElectro = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("================================\nTienda de Don Lucas\n================================");
                Console.WriteLine("1: Registrar venta\n2: Registrar devolución\n3: Cerrar Caja\n================================");
                Console.Write("Ingrese una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("================================\nRegistrar Venta de:\n================================");
                        Console.WriteLine("1: Limpieza\n2: Abarrotes\n3: Golosinas\n4: Electrónicos\n5: <- Regresar");
                        Console.Write("Seleccione producto: ");
                        int productoVenta = int.Parse(Console.ReadLine());
                        switch (productoVenta)
                        {
                            case 1:
                                Registrar(ref vendidosLimpieza, ref cajaLimpieza, "Limpieza", true);
                                break;
                            case 2:
                                Registrar(ref vendidosAbarrotes, ref cajaAbarrotes, "Abarrotes", true);
                                break;
                            case 3:
                                Registrar(ref vendidosGolosinas, ref cajaGolosinas, "Golosinas", true);
                                break;
                            case 4:
                                Registrar(ref vendidosElectro, ref cajaElectro, "Electro", true);
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("================================\nRegistrar Devolución de:\n================================");
                        Console.WriteLine("1: Limpieza\n2: Abarrotes\n3: Golosinas\n4: Electrónicos\n5: <- Regresar");
                        Console.Write("Seleccione producto: ");
                        int productoDevolucion = int.Parse(Console.ReadLine());
                        switch (productoDevolucion)
                        {
                            case 1:
                                Registrar(ref devueltosLimpieza, ref cajaLimpieza, "Limpieza", false);
                                break;
                            case 2:
                                Registrar(ref devueltosAbarrotes, ref cajaAbarrotes, "Abarrotes", false);
                                break;
                            case 3:
                                Registrar(ref devueltosGolosinas, ref cajaGolosinas, "Golosinas", false);
                                break;
                            case 4:
                                Registrar(ref devueltosElectro, ref cajaElectro, "Electro", false);
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("================================\nTotales\n================================");
                        caja = cajaLimpieza + cajaAbarrotes + cajaGolosinas + cajaElectro;
                        Console.WriteLine($"Limpieza | {vendidosLimpieza - devueltosLimpieza} vendidos | {devueltosLimpieza} devueltos | S/ {cajaLimpieza} en caja");
                        Console.WriteLine($"Abarrotes | {vendidosAbarrotes - devueltosAbarrotes} vendidos | {devueltosAbarrotes} devueltos | S/ {cajaAbarrotes} en caja");
                        Console.WriteLine($"Golosinas | {vendidosGolosinas - devueltosGolosinas} vendidos | {devueltosGolosinas} devueltos | S/ {cajaGolosinas} en caja");
                        Console.WriteLine($"Electro | {vendidosElectro - devueltosElectro} vendidos | {devueltosElectro} devueltos | S/ {cajaElectro} en caja");
                        Console.WriteLine($"================================\nQueda en caja S/{caja}");
                        Console.WriteLine("Presione cualquier tecla para cerrar...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
    }
}
