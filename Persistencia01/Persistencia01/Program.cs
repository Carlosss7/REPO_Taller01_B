/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 17/04/2026
 * Hora: 14:16
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace Persistencia01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("=====TALLER SECCION B ===");
			
			// directorio
			
			string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DATOSIUJO");
			
			string rutaReportes = Path.Combine(rutaRaiz, "REPORTES");
			
			Console.WriteLine(rutaRaiz);
			Console.WriteLine(rutaReportes);
			
			if(!Directory.Exists(rutaReportes)){
			   	//crear el directorio reportes
			   	Directory.CreateDirectory(rutaReportes);
			   	Console.WriteLine("Directorio creado correctamente");
			   }
			
			// --- DESAFÍO 1: El Validador de Seguridad ---
            Console.WriteLine("\n--- Desafío 1: Validador ---");
            Console.Write("Ingrese la cadena (usuario;clave): ");
            string entrada = Console.ReadLine();

            // Dividimos la cadena usando el separador ';'
            string[] partes = entrada.Split(';');

            // Verificamos que existan al menos dos partes (usuario y clave)
            if (partes.Length >= 2)
            {
                string usuario = partes[0];
                string clave = partes[1];

                // Si la clave contiene "123", guardamos el aviso
                if (clave.Contains("123"))
                {
                    string rutaSeguridad = Path.Combine(rutaReportes, "seguridad.txt");
                    
                    // Usamos StreamWriter para escribir el archivo
                    // El parámetro 'true' es para que no borre lo que ya existe (Append)
                    using (StreamWriter sw = new StreamWriter(rutaSeguridad, true))
                    {
                        sw.WriteLine("[{DateTime.Now}] Clave Débil detectada para el usuario: {usuario}");
                    }
                    
                    Console.WriteLine("¡Alerta! Clave débil detectada y registrada en seguridad.txt");
                }
                else
                {
                    Console.WriteLine("Clave segura. No se generaron avisos.");
                }
            }
            else
            {
                Console.WriteLine("Error: Formato incorrecto. Debe ser 'usuario;clave'.");
            }

            Console.WriteLine("\n---------------------------");
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}