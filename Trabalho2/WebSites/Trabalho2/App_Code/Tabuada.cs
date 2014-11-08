public class Tabuada
{
    public static string[] GeraTabuada(int valor)
    {
        string[] tabuadas = new string[valor];
        for (int numero = 1; numero <= valor; numero++)
        {
            string linhas = string.Empty;
            for (int i = 0; i <= 10; i++)
            {
                string linha = (numero + " X " + i + " = " + (numero * i)+"<br>").ToString();
                linhas += linha;
            }
            tabuadas[numero-1] = linhas;
        }
        return tabuadas;
    }

    //Construtor
	public Tabuada()
	{
		
	}
}