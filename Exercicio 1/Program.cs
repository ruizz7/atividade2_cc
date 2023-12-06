using SkiaSharp;

namespace Projeto
{
	class Program
	{
		static void Main(string[] args)
		{
			using (SKBitmap bitmap = SKBitmap.Decode("C:\\Users\\User\\Desktop\\Atv_Individual2\\Exercicio 1\\Exercicio 1.png"))
			{
				int contador = 0;
				int largura = bitmap.Width;
				int altura = bitmap.Height;

				unsafe
				{
					byte* ptr = (byte*)bitmap.GetPixels();

					byte[] padrao = new byte[]
					{
						0, 0, 0, 0,
						0, 255, 255, 0,
						0, 255, 255, 0,
						0, 0, 0, 0
					};

					for (int y = 0; y < altura - 3; y++)
					{
						for (int x = 0; x < largura - 3; x++)
						{
							bool padrao_encontrado = true;

							for (int py = 0; py < 4; py++)
							{
								for (int px = 0; px < 4; px++)
								{
									byte* pixel_atual = ptr + ((y + py) * largura + (x + px));

									byte valor_pixel = pixel_atual[0];

									if (valor_pixel != padrao[py * 4 + px])
									{
										padrao_encontrado = false;
										break;
									}
								}

								if (!padrao_encontrado)
								{
									break;
								}
							}

							if (padrao_encontrado)
							{
								contador++;
							}
						}
					}
				}

				Console.WriteLine("O padrão de 16 pixels aparece " + contador + " vezes");
			}
		}
	}
}
