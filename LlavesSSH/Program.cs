using LlavesSSH;
internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Colocar una llave");
            return;
        }
        var respuesta = "";
        var input = args[0];
        var llave = new Llave();
        var _misLlaves = new[]
        {
            // Aqui agregar datos de llaves de ssh
            Llave.Crear("comando", "usuario", "correo@ejemplo.com", "~/ruta/a/clave"),
        };
        try
        {
            llave = _misLlaves.Where(x => x.Comando == input).First();
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Coloque una llave");
            return;
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Llave no válida");
            return;
        }
        respuesta = llave.EjecutarCambio();
        Console.WriteLine(respuesta);
    }
}
