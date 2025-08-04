´´´ cs
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese el valor de n: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            ImprimirPrimosFibonacci(n);
        }
        else
        {
            Console.WriteLine("Por favor, ingrese un número entero positivo.");
        }
    }

    static void ImprimirPrimosFibonacci(int n)
    {
        int a = 0, b = 1;
        for (int i = 1; i <= n; i++)
        {
            int fib = a;
            if (EsPrimo(fib))
            {
                Console.WriteLine(fib);
            }
            int temp = a + b;
            a = b;
            b = temp;
        }
    }

    static bool EsPrimo(int numero)
    {
        if (numero < 2) return false;
        if (numero == 2) return true;
        if (numero % 2 == 0) return false;
        int raiz = (int)Math.Sqrt(numero);
        for (int i = 3; i <= raiz; i += 2)
        {
            if (numero % i == 0) return false;
        }
        return true;
    }

    ///formato HH:MM:SS
    static string SegundosAFormatoHora(int segundos)
    {
        int horas = segundos / 3600;
        int minutos = (segundos % 3600) / 60;
        int segs = segundos % 60;
        return $"{horas:D2}:{minutos:D2}:{segs:D2}";
    }


   /// Jugar chance
    static void JugarChance()
    {
        const int apuesta = 1000;
        int numUsuario;

        // Solicitar número de 4 dígitos al usuario
        while (true)
        {
            Console.Write("Ingrese su número de 4 dígitos (0000-9999): ");
            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out numUsuario) && numUsuario >= 0 && numUsuario <= 9999)
                break;
            Console.WriteLine("Número inválido. Intente de nuevo.");
        }

        // Generar número ganador aleatorio de 4 dígitos
        Random rnd = new Random();
        int numGanador = rnd.Next(0, 10000);

        Console.WriteLine($"Usted apostó ${apuesta} al número {numUsuario:D4}.");
        Console.WriteLine($"El número ganador del sorteo es: {numGanador:D4}");

        if (numUsuario == numGanador)
            Console.WriteLine("¡Felicidades! Ha ganado el chance.");
        else
            Console.WriteLine("Lo sentimos, no ha ganado esta vez.");
    }
    static int CalcularPremio(int numApostado, int numGanador, int valorApostado)
    {
        string apostado = numApostado.ToString("D4");
        string ganador = numGanador.ToString("D4");

        // 1. Cuatro cifras en orden
        if (apostado == ganador)
            return 4500 * valorApostado;

        // 2. Cuatro cifras en desorden
        char[] a = apostado.ToCharArray();
        char[] g = ganador.ToCharArray();
        Array.Sort(a);
        Array.Sort(g);
        if (new string(a) == new string(g))
            return 200 * valorApostado;

        // 3. Últimas 3 cifras en orden
        if (apostado.Substring(1, 3) == ganador.Substring(1, 3))
            return 400 * valorApostado;

        // 4. Últimas 2 cifras en orden
        if (apostado.Substring(2, 2) == ganador.Substring(2, 2))
            return 50 * valorApostado;

        // 5. Última cifra
        if (apostado[3] == ganador[3])
            return 5 * valorApostado;

        // Sin premio
        return 0;


    }
   



abstract class AbstractSample
{
    private string message;

    protected string Message
    {
        get => message;
        set => message = value;
    }

    public AbstractSample(string message)
    {
        this.message = message;
    }

    public abstract void PrintMessage(string msg);

    public virtual void InvertMessage(string msg)
    {
        // Invierte el mensaje y lo guarda en el atributo privado
        char[] arr = msg.ToCharArray();
        Array.Reverse(arr);
        Message = new string(arr);
    }
}

class PrintNormal : AbstractSample
{
    public PrintNormal(string message) : base(message) { }

    public override void PrintMessage(string msg)
    {
        // Imprime el mensaje tal cual
        Console.WriteLine(msg);
    }
}

class PrintSwapCase : AbstractSample
{
    public PrintSwapCase(string message) : base(message) { }

    public override void PrintMessage(string msg)
    {
        // Imprime el mensaje con mayúsculas y minúsculas invertidas
        Console.WriteLine(SwapCase(msg));
    }

    public override void InvertMessage(string msg)
    {
        // Invierte el mensaje y cambia mayúsculas por minúsculas y viceversa
        base.InvertMessage(msg);
        Message = SwapCase(Message);
    }

    private string SwapCase(string input)
    {
        char[] arr = input.ToCharArray();
        for (int i = 0; i < arr.Length; i++)
        {
            if (char.IsUpper(arr[i]))
                arr[i] = char.ToLower(arr[i]);
            else if (char.IsLower(arr[i]))
                arr[i] = char.ToUpper(arr[i]);
        }
        return new string(arr);
    }
}

class MessageManager
{
    public void EjecutarMensajes()
    {
        AbstractSample normal = new PrintNormal("Hola Mundo!");
        AbstractSample swapCase = new PrintSwapCase("Hola Mundo!");

        normal.PrintMessage("Hola Mundo!");
        swapCase.PrintMessage("Hola Mundo!");
    }
}


}


´´´