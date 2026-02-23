using System.Diagnostics;
namespace LlavesSSH;

public class Llave
{
     public string Comando { get; set; } = "comando";
     public string Usuario { get; set; } = "Mi-Usuario";
     public string Correo { get; set; } = "Mi-Correo";
     public string RutaClave { get; set; } = "~/ruta/de/la/clave";
     public string ComandoCompleto => $"ssh-add -D && ssh-add {RutaClave} && git config --global user.email \"{Correo}\" && git config --global user.name \"{Usuario}\" && git config --list";

     public static Llave Crear(string comando, string usuario, string correo, string rutaClave)
     {
          return new Llave { Comando = comando, Usuario = usuario, Correo = correo, RutaClave = rutaClave };
     }

     public string EjecutarCambio()
     {
          var processStartInfo = new ProcessStartInfo()
          {
               FileName = "/bin/bash",
               Arguments = $"-c \"{this.ComandoCompleto}\"",
               RedirectStandardOutput = true,
               UseShellExecute = false,
               CreateNoWindow = true,
          };
          var process = new Process()
          {
               StartInfo = processStartInfo,
          };
          process.Start();
          string result = process.StandardOutput.ReadToEnd();
          process.WaitForExit();

          return result;
     }
}