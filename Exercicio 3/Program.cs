using SkiaSharp;

namespace Projeto
{
	class Program
	{
		static void Main(string[] args)
		{
			using (SKBitmap bitmapEntrada = SKBitmap.Decode("C:\\Users\\User\\Desktop\\Atv_Individual2\\Exercicio 3\\Exercicio 3.png"))
			{

				unsafe
				{
					byte* entrada = (byte*)bitmapEntrada.GetPixels();

					int altura = bitmapEntrada.Height;
					int largura = bitmapEntrada.Width;

					int[] qtd_pixels = new int[256];

					for (int i = 0; i < altura; i++)
					{
						for (int j = 0; j < largura; j++)
						{
							qtd_pixels[entrada[(i * largura) + j]] += 1;
						}
					}

					for (int k = 0; k <= 255; k++)
					{
						Console.WriteLine("Quantidade de pixels com valor " + k + ": " + qtd_pixels[k]);
					}
				}
			}
		}
	}
}