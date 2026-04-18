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
            
	        // --- DESAFÍO 2: El Clonador de Imágenes (FileStream) ---
			Console.WriteLine("\n--- Desafío 2: Clonador ---");
	
			// Definimos los nombres exactos que pide el reto
			string archivoOrigen = Path.Combine(rutaRaiz, "avatar.jpg"); 
			string archivoDestino = Path.Combine(rutaReportes, "respaldo.jpg");
		
			if (File.Exists(archivoOrigen))
			{
		   	 // Usamos FileStream para la copia byte a byte
		    using (FileStream fsEntrada = new FileStream(archivoOrigen, FileMode.Open, FileAccess.Read))
		    using (FileStream fsSalida = new FileStream(archivoDestino, FileMode.Create, FileAccess.Write))
		    {
		        byte[] buffer = new byte[1024]; // La "cubeta" para los bytes
		        int cantidadLeida;
		
		        while ((cantidadLeida = fsEntrada.Read(buffer, 0, buffer.Length)) > 0)
		        {
		            fsSalida.Write(buffer, 0, cantidadLeida);
		        }
		    }
		    Console.WriteLine("Reto cumplido: avatar.jpg copiado a respaldo.jpg byte a byte.");
		}
		else
		{
		    Console.WriteLine("Error: No se encontró 'avatar.jpg' en la carpeta DATOSIUJO.");
		}
		            
		            
		
		            Console.WriteLine("\n---------------------------");
		            Console.Write("Press any key to continue . . . ");
		            Console.ReadKey(true);
		        }
		    }
		}
	
	           