using SkiaSharp;
using System.IO;

namespace Projeto
{
	class Program
	{
		static void Main(string[] args)
		{
			using (SKBitmap bitmapEntrada = SKBitmap.Decode("C:\\Users\\User\\Desktop\\Atv_Individual2\\Exercicio 2\\Exercicio 2.png"),
				bitmapSaida = new SKBitmap(new SKImageInfo(bitmapEntrada.Width, bitmapEntrada.Height, SKColorType.Gray8)))
			{

				static void AjusteDeBrilho(byte r, byte g, byte b, out byte saida)
				{
					unsafe
					{
						double R = (double)r / 255.0;
						double G = (double)g / 255.0;
						double B = (double)b / 255.0;

						double max = Math.Max(Math.Max(R, G), B);
						double V = max;

						double v = 255.0 * V;
						saida = 0;

						if (v < 0)
						{
							saida = (byte)(saida * (1 + v));
						}
						else
						{
							saida = (byte)(saida + ((255 - saida) * v));
						}

						if (saida < 0)
						{
							saida = 0;
						}

						if (saida > 255)
						{
							saida = 255;
						}
					}
				}

				unsafe
				{
					byte* entrada = (byte*)bitmapEntrada.GetPixels();
					byte* saida = (byte*)bitmapSaida.GetPixels();

					long pixelsTotais = bitmapEntrada.Width * bitmapEntrada.Height;

					unsafe
					{
						for (int e = 0, s = 0; s < pixelsTotais; e += 4, s++)
						{
							if (e + 2 < pixelsTotais * 4 && s < pixelsTotais)
							{
								AjusteDeBrilho(entrada[e + 2], entrada[e + 1], entrada[e], out saida[s]);
							}
						}
					}
				}
				unsafe
				{
					using (FileStream stream = new FileStream("C:\\Users\\User\\Desktop\\Atv_Individual2\\Exercicio 2\\Saida_Exercicio 2.png", FileMode.OpenOrCreate, FileAccess.Write))
					{
						bitmapSaida.Encode(stream, SKEncodedImageFormat.Png, 100);
					}
				}
			}
		}
	}
}
